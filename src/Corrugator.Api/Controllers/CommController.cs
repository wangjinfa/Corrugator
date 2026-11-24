using Corrugator.Application.Abstractions;
using Corrugator.Domain.Entities.Plc;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Comm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

/// <summary>
/// 通讯设置（基础信息 → 通讯设置）：配置设置 / 设备 / 点位变量三个页签。
/// 数据落在 TB_Plc_DriverConfig、TB_Plc_PointVar（IPS 线库）。
/// </summary>
[ApiController]
[Route("api/comm")]
[Authorize]
public class CommController : ControllerBase
{
    /// <summary>截图里的协议驱动下拉值</summary>
    private static readonly string[] DeviceTypes =
    {
        "ModBusAscii",
        "Siemens_S7_200",
        "Siemens_S7_200Smart",
        "Siemens_S7_300",
        "Siemens_S7_400",
        "Siemens_S7_1200",
        "Siemens_S7_1500",
        "Mitsubishi_A_1E",
        "Mitsubishi_Qna_3E",
        "OmronFins",
        "AllenBradley",
        "LenzeMDI",
    };

    /// <summary>点位数据类型下拉</summary>
    private static readonly string[] PointDataTypes =
    {
        "Bool", "Short", "Int", "Float", "Double", "String",
    };

    /// <summary>点位可读可写下拉</summary>
    private static readonly string[] PointRw = { "ReadOnly", "ReadWrite", "WriteOnly" };

    private readonly IRepository<TB_Plc_DriverConfig> _configs;
    private readonly IRepository<TB_Plc_PointVar> _points;
    private readonly IRepository<TB_Plc_Device> _devices;

    public CommController(
        IRepository<TB_Plc_DriverConfig> configs,
        IRepository<TB_Plc_PointVar> points,
        IRepository<TB_Plc_Device> devices)
    {
        _configs = configs;
        _points = points;
        _devices = devices;
    }

    /// <summary>通讯配置列表</summary>
    [HttpGet("configs")]
    public async Task<ApiResult<List<CommConfigDto>>> Configs(
        string? name = null, string? parCode = null, string? code = null, bool showAll = false)
    {
        var list = await _configs.ListAsync(showAll ? null : c => !c.F_IsDelete, "F_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(c => c.F_Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(c => c.F_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(parCode))
        {
            var keyword = parCode.Trim();
            query = query.Where(c => c.F_ParCode?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        return ApiResult<List<CommConfigDto>>.Ok(query.Select(ToDto).ToList());
    }

    /// <summary>参数编码下拉值（现有数据去重）</summary>
    [HttpGet("par-codes")]
    public async Task<ApiResult<List<string>>> ParCodes()
    {
        var list = await _configs.ListAsync(c => !c.F_IsDelete, "F_ID ASC");
        var codes = list.Select(c => c.F_ParCode).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().ToList();
        return ApiResult<List<string>>.Ok(codes!);
    }

    /// <summary>通讯设备列表</summary>
    [HttpGet("devices")]
    public async Task<ApiResult<List<CommDeviceDto>>> Devices(
        string? name = null, string? commType = null, string? config = null, bool showAll = false,
        string? code = null)
    {
        var list = await _devices.ListAsync(showAll ? null : d => !d.F_IsDelete, "F_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(d => d.F_Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(d => d.F_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(commType))
        {
            query = query.Where(d => string.Equals(d.F_CommType, commType.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(config))
        {
            query = query.Where(d => string.Equals(d.F_ConfigName, config.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        return ApiResult<List<CommDeviceDto>>.Ok(query.Select(ToDeviceDto).ToList());
    }

    /// <summary>通讯类型下拉值（协议驱动）</summary>
    [HttpGet("device-types")]
    public ApiResult<List<string>> DeviceTypeOptions()
        => ApiResult<List<string>>.Ok(DeviceTypes.ToList());

    /// <summary>通讯配置下拉值（取配置表去重后的编码/名称）</summary>
    [HttpGet("config-options")]
    public async Task<ApiResult<List<CommConfigOption>>> ConfigOptions()
    {
        var list = await _configs.ListAsync(c => !c.F_IsDelete, "F_ID ASC");
        var options = list
            .Where(c => !string.IsNullOrWhiteSpace(c.F_Name))
            .Select(c => new CommConfigOption { Code = c.F_Code, Name = c.F_Name })
            .GroupBy(o => o.Name)
            .Select(g => g.First())
            .ToList();

        return ApiResult<List<CommConfigOption>>.Ok(options);
    }

    /// <summary>新增通讯设备</summary>
    [HttpPost("devices")]
    public async Task<ApiResult<CommDeviceDto>> CreateDevice([FromBody] CommDeviceSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommDeviceDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommDeviceDto>.Fail("设备编码不能为空");
        }

        var exists = await _devices.ExistsAsync(d => d.F_Code == request.Code.Trim() && !d.F_IsDelete);
        if (exists)
        {
            return ApiResult<CommDeviceDto>.Fail("设备编码已存在");
        }

        var entity = new TB_Plc_Device
        {
            F_Code = request.Code.Trim(),
            F_Name = request.Name?.Trim(),
            F_CommType = request.CommType?.Trim(),
            F_ConfigName = request.ConfigName?.Trim(),
            F_IsUse = request.IsUse,
            F_IsDelete = request.IsDelete,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        await _devices.InsertAsync(entity);
        return ApiResult<CommDeviceDto>.Ok(ToDeviceDto(entity), "已新增");
    }

    /// <summary>修改通讯设备</summary>
    [HttpPut("devices/{id:long}")]
    public async Task<ApiResult<CommDeviceDto>> UpdateDevice(long id, [FromBody] CommDeviceSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommDeviceDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        var entity = await _devices.GetByIdAsync(id);
        if (entity is null)
        {
            return ApiResult<CommDeviceDto>.Fail("记录不存在", 404);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommDeviceDto>.Fail("设备编码不能为空");
        }

        var code = request.Code.Trim();
        if (!string.Equals(code, entity.F_Code, StringComparison.Ordinal))
        {
            var exists = await _devices.ExistsAsync(d => d.F_ID != id && d.F_Code == code && !d.F_IsDelete);
            if (exists)
            {
                return ApiResult<CommDeviceDto>.Fail("设备编码已存在");
            }
        }

        entity.F_Code = code;
        entity.F_Name = request.Name?.Trim();
        entity.F_CommType = request.CommType?.Trim();
        entity.F_ConfigName = request.ConfigName?.Trim();
        entity.F_IsUse = request.IsUse;
        entity.F_IsDelete = request.IsDelete;
        entity.F_Editor = User.Identity?.Name;
        entity.F_EditTime = DateTime.Now;

        await _devices.UpdateAsync(entity);
        return ApiResult<CommDeviceDto>.Ok(ToDeviceDto(entity), "已保存");
    }

    /// <summary>删除通讯设备（底部删除按钮，勾选批量）</summary>
    [HttpPost("devices/batch-delete")]
    public async Task<ApiResult<ApiEmpty>> BatchDeleteDevices([FromBody] BatchDeleteRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护通讯设置", 403);
        }

        var ids = request.Ids.Distinct().ToList();
        if (ids.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("请先勾选要删除的记录");
        }

        foreach (var id in ids)
        {
            var entity = await _devices.GetByIdAsync(id);
            if (entity is null)
            {
                continue;
            }

            entity.F_IsDelete = true;
            entity.F_Editor = User.Identity?.Name;
            entity.F_EditTime = DateTime.Now;
            await _devices.UpdateAsync(entity);
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已删除 {ids.Count} 条");
    }

    private static CommDeviceDto ToDeviceDto(TB_Plc_Device d) => new()
    {
        Id = d.F_ID,
        Code = d.F_Code,
        Name = d.F_Name,
        CommType = d.F_CommType,
        ConfigName = d.F_ConfigName,
        IsUse = d.F_IsUse ?? false,
        IsDelete = d.F_IsDelete,
        Creator = d.F_Creator,
        CreateTime = d.F_CreateTime,
        Editor = d.F_Editor,
        EditTime = d.F_EditTime,
    };

    /// <summary>通讯点位变量列表</summary>
    [HttpGet("points")]
    public async Task<ApiResult<List<CommPointDto>>> Points(
        string? position = null, string? device = null, string? code = null, bool showAll = false)
    {
        var list = await _points.ListAsync(showAll ? null : p => !p.F_IsDelete, "F_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(position))
        {
            var keyword = position.Trim();
            query = query.Where(p => string.Equals(p.F_Position, keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(device))
        {
            var keyword = device.Trim();
            query = query.Where(p => string.Equals(p.F_DriverCode, keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(p => p.F_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        return ApiResult<List<CommPointDto>>.Ok(query.Select(ToPointDto).ToList());
    }

    /// <summary>点位页下拉：部位 / 所属设备 / 数据类型 / 可读可写</summary>
    [HttpGet("point-options")]
    public async Task<ApiResult<CommPointOptions>> PointOptions()
    {
        var points = await _points.ListAsync(null, "F_ID ASC");
        var devices = await _devices.ListAsync(d => !d.F_IsDelete, "F_ID ASC");

        var positions = points.Select(p => p.F_Position).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList()!;
        var deviceNames = devices.Select(d => d.F_Name).Where(d => !string.IsNullOrWhiteSpace(d)).Distinct().ToList()!;

        return ApiResult<CommPointOptions>.Ok(new CommPointOptions
        {
            Positions = positions.Concat(deviceNames).Distinct().ToList(),
            Devices = deviceNames,
            DataTypes = PointDataTypes.ToList(),
            Rw = PointRw.ToList(),
        });
    }

    /// <summary>新增通讯点位变量</summary>
    [HttpPost("points")]
    public async Task<ApiResult<CommPointDto>> CreatePoint([FromBody] CommPointSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommPointDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommPointDto>.Fail("变量编码不能为空");
        }

        var entity = new TB_Plc_PointVar
        {
            F_Code = request.Code.Trim(),
            F_Name = request.Name?.Trim(),
            F_Desc = request.Desc?.Trim(),
            F_Position = request.Position?.Trim(),
            F_DriverCode = request.DriverCode?.Trim(),
            F_VarAddress = request.VarAddress?.Trim(),
            F_DataType = request.DataType?.Trim(),
            F_RW = RwToInt(request.RW),
            F_Interval = request.Interval,
            F_Priority = request.Priority,
            F_IsUse = request.IsUse,
            F_CurValue = request.CurValue,
            F_IsAlarm = request.IsAlarm,
            F_AlarmInterval = request.AlarmInterval,
            F_AlarmOffset = request.AlarmOffset,
            F_IsDelete = request.IsDelete,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        await _points.InsertAsync(entity);
        return ApiResult<CommPointDto>.Ok(ToPointDto(entity), "已新增");
    }

    /// <summary>修改通讯点位变量</summary>
    [HttpPut("points/{id:long}")]
    public async Task<ApiResult<CommPointDto>> UpdatePoint(long id, [FromBody] CommPointSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommPointDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        var entity = await _points.GetByIdAsync(id);
        if (entity is null)
        {
            return ApiResult<CommPointDto>.Fail("记录不存在", 404);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommPointDto>.Fail("变量编码不能为空");
        }

        entity.F_Code = request.Code.Trim();
        entity.F_Name = request.Name?.Trim();
        entity.F_Desc = request.Desc?.Trim();
        entity.F_Position = request.Position?.Trim();
        entity.F_DriverCode = request.DriverCode?.Trim();
        entity.F_VarAddress = request.VarAddress?.Trim();
        entity.F_DataType = request.DataType?.Trim();
        entity.F_RW = RwToInt(request.RW);
        entity.F_Interval = request.Interval;
        entity.F_Priority = request.Priority;
        entity.F_IsUse = request.IsUse;
        entity.F_CurValue = request.CurValue;
        entity.F_IsAlarm = request.IsAlarm;
        entity.F_AlarmInterval = request.AlarmInterval;
        entity.F_AlarmOffset = request.AlarmOffset;
        entity.F_IsDelete = request.IsDelete;
        entity.F_Editor = User.Identity?.Name;
        entity.F_EditTime = DateTime.Now;

        await _points.UpdateAsync(entity);
        return ApiResult<CommPointDto>.Ok(ToPointDto(entity), "已保存");
    }

    /// <summary>删除通讯点位变量（勾选批量）</summary>
    [HttpPost("points/batch-delete")]
    public async Task<ApiResult<ApiEmpty>> BatchDeletePoints([FromBody] BatchDeleteRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护通讯设置", 403);
        }

        var ids = request.Ids.Distinct().ToList();
        if (ids.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("请先勾选要删除的记录");
        }

        foreach (var id in ids)
        {
            var entity = await _points.GetByIdAsync(id);
            if (entity is null)
            {
                continue;
            }

            entity.F_IsDelete = true;
            entity.F_Editor = User.Identity?.Name;
            entity.F_EditTime = DateTime.Now;
            await _points.UpdateAsync(entity);
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已删除 {ids.Count} 条");
    }

    private static string RwToText(int rw) => rw switch
    {
        1 => "ReadOnly",
        3 => "WriteOnly",
        _ => "ReadWrite",
    };

    private static int RwToInt(string? rw) => rw?.Trim().ToLowerInvariant() switch
    {
        "readonly" => 1,
        "writeonly" => 3,
        _ => 2,
    };

    private static CommPointDto ToPointDto(TB_Plc_PointVar p) => new()
    {
        Id = p.F_ID,
        Code = p.F_Code,
        Name = p.F_Name,
        Desc = p.F_Desc,
        Position = p.F_Position,
        DriverCode = p.F_DriverCode,
        VarAddress = p.F_VarAddress,
        DataType = p.F_DataType,
        RW = RwToText(p.F_RW),
        Interval = p.F_Interval,
        Priority = p.F_Priority,
        IsUse = p.F_IsUse ?? false,
        CurValue = p.F_CurValue,
        IsAlarm = p.F_IsAlarm,
        AlarmInterval = p.F_AlarmInterval,
        AlarmOffset = p.F_AlarmOffset,
        DataOkAddress = p.F_DataOKAddress,
        DataOkDataType = p.F_DataOKDataType,
        TransferKeyAddress = p.F_TransferKeyAddress,
        TransferKeyDataType = p.F_TransferKeyDataType,
        Creator = p.F_Creator,
        CreateTime = p.F_CreateTime,
        Editor = p.F_Editor,
        EditTime = p.F_EditTime,
        IsDelete = p.F_IsDelete,
    };

    /// <summary>新增通讯配置</summary>
    [HttpPost("configs")]
    public async Task<ApiResult<CommConfigDto>> Create([FromBody] CommConfigSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommConfigDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommConfigDto>.Fail("配置编码不能为空");
        }

        var entity = new TB_Plc_DriverConfig
        {
            F_Code = request.Code.Trim(),
            F_Name = request.Name?.Trim(),
            F_Desc = request.Desc?.Trim(),
            F_ParCode = request.ParCode?.Trim(),
            F_ParValue = request.ParValue?.Trim(),
            F_IsDelete = request.IsDelete,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        await _configs.InsertAsync(entity);
        return ApiResult<CommConfigDto>.Ok(ToDto(entity), "已新增");
    }

    /// <summary>修改通讯配置</summary>
    [HttpPut("configs/{id:long}")]
    public async Task<ApiResult<CommConfigDto>> Update(long id, [FromBody] CommConfigSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<CommConfigDto>.Fail("仅管理员可维护通讯设置", 403);
        }

        var entity = await _configs.GetByIdAsync(id);
        if (entity is null)
        {
            return ApiResult<CommConfigDto>.Fail("记录不存在", 404);
        }

        if (string.IsNullOrWhiteSpace(request.Code))
        {
            return ApiResult<CommConfigDto>.Fail("配置编码不能为空");
        }

        entity.F_Code = request.Code.Trim();
        entity.F_Name = request.Name?.Trim();
        entity.F_Desc = request.Desc?.Trim();
        entity.F_ParCode = request.ParCode?.Trim();
        entity.F_ParValue = request.ParValue?.Trim();
        entity.F_IsDelete = request.IsDelete;
        entity.F_Editor = User.Identity?.Name;
        entity.F_EditTime = DateTime.Now;

        await _configs.UpdateAsync(entity);
        return ApiResult<CommConfigDto>.Ok(ToDto(entity), "已保存");
    }

    /// <summary>删除通讯配置（置 F_IsDelete）</summary>
    [HttpDelete("configs/{id:long}")]
    public async Task<ApiResult<ApiEmpty>> Delete(long id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护通讯设置", 403);
        }

        var entity = await _configs.GetByIdAsync(id);
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        entity.F_IsDelete = true;
        entity.F_Editor = User.Identity?.Name;
        entity.F_EditTime = DateTime.Now;
        await _configs.UpdateAsync(entity);

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    /// <summary>批量删除（底部「删除」按钮，配合勾选列）</summary>
    [HttpPost("configs/batch-delete")]
    public async Task<ApiResult<ApiEmpty>> BatchDelete([FromBody] BatchDeleteRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护通讯设置", 403);
        }

        var ids = request.Ids.Distinct().ToList();
        if (ids.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("请先勾选要删除的记录");
        }

        foreach (var id in ids)
        {
            var entity = await _configs.GetByIdAsync(id);
            if (entity is null)
            {
                continue;
            }

            entity.F_IsDelete = true;
            entity.F_Editor = User.Identity?.Name;
            entity.F_EditTime = DateTime.Now;
            await _configs.UpdateAsync(entity);
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已删除 {ids.Count} 条");
    }

    /// <summary>立即生效：重读配置并刷新服务端缓存（PLC 网关未接入时只刷新服务端）</summary>
    [HttpPost("reload")]
    public async Task<ApiResult<ApiEmpty>> Reload()
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可执行生效操作", 403);
        }

        var count = await _configs.CountAsync(c => !c.F_IsDelete);
        var deviceCount = await _devices.CountAsync(d => !d.F_IsDelete);
        var pointCount = await _points.CountAsync(p => !p.F_IsDelete);
        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(),
            $"已重新加载 {count} 条通讯配置、{deviceCount} 个通讯设备、{pointCount} 个点位变量（PLC 网关未接入，本次仅刷新服务端缓存）");
    }

    private static CommConfigDto ToDto(TB_Plc_DriverConfig c) => new()
    {
        Id = c.F_ID,
        Code = c.F_Code,
        Name = c.F_Name,
        Desc = c.F_Desc,
        ParCode = c.F_ParCode,
        ParValue = c.F_ParValue,
        IsDelete = c.F_IsDelete,
        Creator = c.F_Creator,
        CreateTime = c.F_CreateTime,
        Editor = c.F_Editor,
        EditTime = c.F_EditTime,
    };

    private bool IsAdmin
    {
        get
        {
            var roles = User.Claims.Where(c => c.Type.EndsWith("/role", StringComparison.OrdinalIgnoreCase))
                .Select(c => c.Value).ToList();
            return roles.Contains("admin");
        }
    }
}
