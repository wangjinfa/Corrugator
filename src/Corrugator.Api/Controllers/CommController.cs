using Corrugator.Application.Abstractions;
using Corrugator.Domain.Entities.Plc;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Comm;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

/// <summary>
/// 通讯设置（基础信息 → 通讯设置）：配置设置 / 设备 / 点位变量三个页签。
/// 数据落在 W_Plc_DriverConfig、W_Plc_PointVar（IPS 线库）。
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

    private readonly IRepository<W_Plc_DriverConfig> _configs;
    private readonly IRepository<W_Plc_PointVar> _points;
    private readonly IRepository<W_Plc_Device> _devices;

    public CommController(
        IRepository<W_Plc_DriverConfig> configs,
        IRepository<W_Plc_PointVar> points,
        IRepository<W_Plc_Device> devices)
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
        var list = await _configs.ListAsync(showAll ? null : c => !c.WF_IsDelete, "WF_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(c => c.WF_Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(c => c.WF_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(parCode))
        {
            var keyword = parCode.Trim();
            query = query.Where(c => c.WF_ParCode?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        return ApiResult<List<CommConfigDto>>.Ok(query.Select(ToDto).ToList());
    }

    /// <summary>参数编码下拉值（现有数据去重）</summary>
    [HttpGet("par-codes")]
    public async Task<ApiResult<List<string>>> ParCodes()
    {
        var list = await _configs.ListAsync(c => !c.WF_IsDelete, "WF_ID ASC");
        var codes = list.Select(c => c.WF_ParCode).Where(c => !string.IsNullOrWhiteSpace(c)).Distinct().ToList();
        return ApiResult<List<string>>.Ok(codes!);
    }

    /// <summary>通讯设备列表</summary>
    [HttpGet("devices")]
    public async Task<ApiResult<List<CommDeviceDto>>> Devices(
        string? name = null, string? commType = null, string? config = null, bool showAll = false,
        string? code = null)
    {
        var list = await _devices.ListAsync(showAll ? null : d => !d.WF_IsDelete, "WF_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(d => d.WF_Name?.Contains(keyword, StringComparison.OrdinalIgnoreCase) == true);
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(d => d.WF_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(commType))
        {
            query = query.Where(d => string.Equals(d.WF_CommType, commType.Trim(), StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(config))
        {
            query = query.Where(d => string.Equals(d.WF_ConfigName, config.Trim(), StringComparison.OrdinalIgnoreCase));
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
        var list = await _configs.ListAsync(c => !c.WF_IsDelete, "WF_ID ASC");
        var options = list
            .Where(c => !string.IsNullOrWhiteSpace(c.WF_Name))
            .Select(c => new CommConfigOption { Code = c.WF_Code, Name = c.WF_Name })
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

        var exists = await _devices.ExistsAsync(d => d.WF_Code == request.Code.Trim() && !d.WF_IsDelete);
        if (exists)
        {
            return ApiResult<CommDeviceDto>.Fail("设备编码已存在");
        }

        var entity = new W_Plc_Device
        {
            WF_Code = request.Code.Trim(),
            WF_Name = request.Name?.Trim(),
            WF_CommType = request.CommType?.Trim(),
            WF_ConfigName = request.ConfigName?.Trim(),
            WF_IsUse = request.IsUse,
            WF_IsDelete = request.IsDelete,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
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
        if (!string.Equals(code, entity.WF_Code, StringComparison.Ordinal))
        {
            var exists = await _devices.ExistsAsync(d => d.WF_ID != id && d.WF_Code == code && !d.WF_IsDelete);
            if (exists)
            {
                return ApiResult<CommDeviceDto>.Fail("设备编码已存在");
            }
        }

        entity.WF_Code = code;
        entity.WF_Name = request.Name?.Trim();
        entity.WF_CommType = request.CommType?.Trim();
        entity.WF_ConfigName = request.ConfigName?.Trim();
        entity.WF_IsUse = request.IsUse;
        entity.WF_IsDelete = request.IsDelete;
        entity.WF_Editor = User.Identity?.Name;
        entity.WF_EditTime = DateTime.Now;

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

            entity.WF_IsDelete = true;
            entity.WF_Editor = User.Identity?.Name;
            entity.WF_EditTime = DateTime.Now;
            await _devices.UpdateAsync(entity);
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已删除 {ids.Count} 条");
    }

    private static CommDeviceDto ToDeviceDto(W_Plc_Device d) => new()
    {
        Id = d.WF_ID,
        Code = d.WF_Code,
        Name = d.WF_Name,
        CommType = d.WF_CommType,
        ConfigName = d.WF_ConfigName,
        IsUse = d.WF_IsUse ?? false,
        IsDelete = d.WF_IsDelete,
        Creator = d.WF_Creator,
        CreateTime = d.WF_CreateTime,
        Editor = d.WF_Editor,
        EditTime = d.WF_EditTime,
    };

    /// <summary>通讯点位变量列表</summary>
    [HttpGet("points")]
    public async Task<ApiResult<List<CommPointDto>>> Points(
        string? position = null, string? device = null, string? code = null, bool showAll = false)
    {
        var list = await _points.ListAsync(showAll ? null : p => !p.WF_IsDelete, "WF_ID ASC");

        var query = list.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(position))
        {
            var keyword = position.Trim();
            query = query.Where(p => string.Equals(p.WF_Position, keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(device))
        {
            var keyword = device.Trim();
            query = query.Where(p => string.Equals(p.WF_DriverCode, keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            var keyword = code.Trim();
            query = query.Where(p => p.WF_Code.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        return ApiResult<List<CommPointDto>>.Ok(query.Select(ToPointDto).ToList());
    }

    /// <summary>点位页下拉：部位 / 所属设备 / 数据类型 / 可读可写</summary>
    [HttpGet("point-options")]
    public async Task<ApiResult<CommPointOptions>> PointOptions()
    {
        var points = await _points.ListAsync(null, "WF_ID ASC");
        var devices = await _devices.ListAsync(d => !d.WF_IsDelete, "WF_ID ASC");

        var positions = points.Select(p => p.WF_Position).Where(p => !string.IsNullOrWhiteSpace(p)).Distinct().ToList()!;
        var deviceNames = devices.Select(d => d.WF_Name).Where(d => !string.IsNullOrWhiteSpace(d)).Distinct().ToList()!;

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

        var entity = new W_Plc_PointVar
        {
            WF_Code = request.Code.Trim(),
            WF_Name = request.Name?.Trim(),
            WF_Desc = request.Desc?.Trim(),
            WF_Position = request.Position?.Trim(),
            WF_DriverCode = request.DriverCode?.Trim(),
            WF_VarAddress = request.VarAddress?.Trim(),
            WF_DataType = request.DataType?.Trim(),
            WF_RW = RwToInt(request.RW),
            WF_Interval = request.Interval,
            WF_Priority = request.Priority,
            WF_IsUse = request.IsUse,
            WF_CurValue = request.CurValue,
            WF_IsAlarm = request.IsAlarm,
            WF_AlarmInterval = request.AlarmInterval,
            WF_AlarmOffset = request.AlarmOffset,
            WF_IsDelete = request.IsDelete,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
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

        entity.WF_Code = request.Code.Trim();
        entity.WF_Name = request.Name?.Trim();
        entity.WF_Desc = request.Desc?.Trim();
        entity.WF_Position = request.Position?.Trim();
        entity.WF_DriverCode = request.DriverCode?.Trim();
        entity.WF_VarAddress = request.VarAddress?.Trim();
        entity.WF_DataType = request.DataType?.Trim();
        entity.WF_RW = RwToInt(request.RW);
        entity.WF_Interval = request.Interval;
        entity.WF_Priority = request.Priority;
        entity.WF_IsUse = request.IsUse;
        entity.WF_CurValue = request.CurValue;
        entity.WF_IsAlarm = request.IsAlarm;
        entity.WF_AlarmInterval = request.AlarmInterval;
        entity.WF_AlarmOffset = request.AlarmOffset;
        entity.WF_IsDelete = request.IsDelete;
        entity.WF_Editor = User.Identity?.Name;
        entity.WF_EditTime = DateTime.Now;

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

            entity.WF_IsDelete = true;
            entity.WF_Editor = User.Identity?.Name;
            entity.WF_EditTime = DateTime.Now;
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

    private static CommPointDto ToPointDto(W_Plc_PointVar p) => new()
    {
        Id = p.WF_ID,
        Code = p.WF_Code,
        Name = p.WF_Name,
        Desc = p.WF_Desc,
        Position = p.WF_Position,
        DriverCode = p.WF_DriverCode,
        VarAddress = p.WF_VarAddress,
        DataType = p.WF_DataType,
        RW = RwToText(p.WF_RW),
        Interval = p.WF_Interval,
        Priority = p.WF_Priority,
        IsUse = p.WF_IsUse ?? false,
        CurValue = p.WF_CurValue,
        IsAlarm = p.WF_IsAlarm,
        AlarmInterval = p.WF_AlarmInterval,
        AlarmOffset = p.WF_AlarmOffset,
        DataOkAddress = p.WF_DataOKAddress,
        DataOkDataType = p.WF_DataOKDataType,
        TransferKeyAddress = p.WF_TransferKeyAddress,
        TransferKeyDataType = p.WF_TransferKeyDataType,
        Creator = p.WF_Creator,
        CreateTime = p.WF_CreateTime,
        Editor = p.WF_Editor,
        EditTime = p.WF_EditTime,
        IsDelete = p.WF_IsDelete,
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

        var entity = new W_Plc_DriverConfig
        {
            WF_Code = request.Code.Trim(),
            WF_Name = request.Name?.Trim(),
            WF_Desc = request.Desc?.Trim(),
            WF_ParCode = request.ParCode?.Trim(),
            WF_ParValue = request.ParValue?.Trim(),
            WF_IsDelete = request.IsDelete,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
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

        entity.WF_Code = request.Code.Trim();
        entity.WF_Name = request.Name?.Trim();
        entity.WF_Desc = request.Desc?.Trim();
        entity.WF_ParCode = request.ParCode?.Trim();
        entity.WF_ParValue = request.ParValue?.Trim();
        entity.WF_IsDelete = request.IsDelete;
        entity.WF_Editor = User.Identity?.Name;
        entity.WF_EditTime = DateTime.Now;

        await _configs.UpdateAsync(entity);
        return ApiResult<CommConfigDto>.Ok(ToDto(entity), "已保存");
    }

    /// <summary>删除通讯配置（置 WF_IsDelete）</summary>
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

        entity.WF_IsDelete = true;
        entity.WF_Editor = User.Identity?.Name;
        entity.WF_EditTime = DateTime.Now;
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

            entity.WF_IsDelete = true;
            entity.WF_Editor = User.Identity?.Name;
            entity.WF_EditTime = DateTime.Now;
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

        var count = await _configs.CountAsync(c => !c.WF_IsDelete);
        var deviceCount = await _devices.CountAsync(d => !d.WF_IsDelete);
        var pointCount = await _points.CountAsync(p => !p.WF_IsDelete);
        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(),
            $"已重新加载 {count} 条通讯配置、{deviceCount} 个通讯设备、{pointCount} 个点位变量（PLC 网关未接入，本次仅刷新服务端缓存）");
    }

    private static CommConfigDto ToDto(W_Plc_DriverConfig c) => new()
    {
        Id = c.WF_ID,
        Code = c.WF_Code,
        Name = c.WF_Name,
        Desc = c.WF_Desc,
        ParCode = c.WF_ParCode,
        ParValue = c.WF_ParValue,
        IsDelete = c.WF_IsDelete,
        Creator = c.WF_Creator,
        CreateTime = c.WF_CreateTime,
        Editor = c.WF_Editor,
        EditTime = c.WF_EditTime,
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
