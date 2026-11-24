using Corrugator.Application.Abstractions;
using Corrugator.Domain.Entities.BaseLine;
using Corrugator.Domain.Entities.Paper;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Base;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

/// <summary>
/// 基础信息模块（产线楞型）：门幅+楞型主数据与页面底部的规则设置。
/// </summary>
[ApiController]
[Route("api/base")]
[Authorize]
public class BaseInfoController : ControllerBase
{
    private readonly IBaseDbAccess _base;

    public BaseInfoController(IBaseDbAccess baseDb)
    {
        _base = baseDb;
    }

    private bool IsAdmin => User.IsInRole("admin");

    // ============================ 产线楞型 ============================

    /// <summary>产线楞型列表（按楞型名称模糊过滤）</summary>
    [HttpGet("line-flutes")]
    public async Task<ApiResult<List<LineFluteDto>>> LineFlutes(string? fluteType = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<TB_Line_Flute>()
            .WhereIF(!showAll, r => r.F_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(fluteType), r => r.F_FluteType.Contains(fluteType!))
            .OrderBy(r => r.F_DoorWidth)
            .ToListAsync();

        var ordered = rows
            .OrderBy(r => r.F_DoorWidth)
            .ThenBy(r => r.F_FluteType)
            .ToList();

        return ApiResult<List<LineFluteDto>>.Ok(ordered.Select(ToDto).ToList());
    }

    /// <summary>新增产线楞型（管理员）</summary>
    [HttpPost("line-flutes")]
    public async Task<ApiResult<LineFluteDto>> CreateLineFlute([FromBody] LineFluteDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<LineFluteDto>.Fail("仅管理员可维护产线楞型", 403);
        }

        if (dto.DoorWidth <= 0 || string.IsNullOrWhiteSpace(dto.FluteType))
        {
            return ApiResult<LineFluteDto>.Fail("门幅与楞型不能为空");
        }

        var exists = await _base.Db.Queryable<TB_Line_Flute>()
            .Where(r => r.F_IsDelete != true && r.F_DoorWidth == dto.DoorWidth && r.F_FluteType == dto.FluteType)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<LineFluteDto>.Fail($"门幅 {dto.DoorWidth} / 楞型 {dto.FluteType} 已存在");
        }

        var entity = FromDto(dto);
        entity.F_Creator = User.Identity?.Name;
        entity.F_CreateTime = DateTime.Now;

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<LineFluteDto>.Ok(ToDto(inserted), "已新增产线楞型");
    }

    /// <summary>修改产线楞型（管理员）</summary>
    [HttpPut("line-flutes/{id:long}")]
    public async Task<ApiResult<LineFluteDto>> UpdateLineFlute(long id, [FromBody] LineFluteDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<LineFluteDto>.Fail("仅管理员可维护产线楞型", 403);
        }

        var row = await _base.Db.Queryable<TB_Line_Flute>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<LineFluteDto>.Fail("产线楞型不存在");
        }

        if (dto.DoorWidth <= 0 || string.IsNullOrWhiteSpace(dto.FluteType))
        {
            return ApiResult<LineFluteDto>.Fail("门幅与楞型不能为空");
        }

        var duplicated = await _base.Db.Queryable<TB_Line_Flute>()
            .Where(r => r.F_IsDelete != true && r.F_ID != id && r.F_DoorWidth == dto.DoorWidth && r.F_FluteType == dto.FluteType)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<LineFluteDto>.Fail($"门幅 {dto.DoorWidth} / 楞型 {dto.FluteType} 已存在");
        }

        var updated = FromDto(dto);
        updated.F_ID = id;
        updated.F_Creator = row.F_Creator;
        updated.F_CreateTime = row.F_CreateTime;
        updated.F_Editor = User.Identity?.Name;
        updated.F_EditTime = DateTime.Now;

        await _base.Db.Updateable(updated).ExecuteCommandAsync();
        return ApiResult<LineFluteDto>.Ok(ToDto(updated), "已保存产线楞型");
    }

    /// <summary>删除产线楞型（软删，管理员）</summary>
    [HttpDelete("line-flutes/{id:long}")]
    public async Task<ApiResult<ApiEmpty>> DeleteLineFlute(long id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护产线楞型", 403);
        }

        var row = await _base.Db.Queryable<TB_Line_Flute>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("产线楞型不存在");
        }

        row.F_IsDelete = true;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除产线楞型");
    }

    /// <summary>立即更新订单：把产线楞型刷新并下发到在制订单（当前只刷新服务端缓存）</summary>
    [HttpPost("line-flutes/refresh-orders")]
    public async Task<ApiResult<ApiEmpty>> RefreshOrders()
    {
        var count = await _base.Db.Queryable<TB_Line_Flute>().Where(r => r.F_IsDelete != true).CountAsync();
        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已重新加载 {count} 条产线楞型（订单侧刷新将在订单接口联调后生效）");
    }

    // ============================ 原纸资料 ============================

    /// <summary>原纸资料列表（原纸代号模糊过滤，区分大小写在客户端提示）</summary>
    [HttpGet("papers")]
    public async Task<ApiResult<List<PaperInfoDto>>> Papers(string? code = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<TB_Paper_Info>()
            .WhereIF(!showAll, r => r.F_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(code), r => r.F_Code.Contains(code!))
            .OrderBy(r => r.F_Code)
            .ToListAsync();

        return ApiResult<List<PaperInfoDto>>.Ok(rows.Select(r => new PaperInfoDto
        {
            Id = r.F_ID,
            Code = r.F_Code,
            GramWeight = r.F_GramWeight,
            PaperWidth = r.F_PaperWidth,
            Brand = r.F_Brand,
            RemainLS2 = r.F_RemainLS2,
            RemainMS3 = r.F_RemainMS3,
            RemainLS3 = r.F_RemainLS3,
        }).ToList());
    }

    /// <summary>新增原纸</summary>
    [HttpPost("papers")]
    public async Task<ApiResult<PaperInfoDto>> CreatePaper([FromBody] PaperInfoDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<PaperInfoDto>.Fail("仅管理员可维护原纸资料", 403);
        }

        if (string.IsNullOrWhiteSpace(dto.Code))
        {
            return ApiResult<PaperInfoDto>.Fail("原纸代号不能为空");
        }

        var exists = await _base.Db.Queryable<TB_Paper_Info>()
            .Where(r => r.F_IsDelete != true && r.F_Code == dto.Code)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<PaperInfoDto>.Fail($"原纸代号 {dto.Code} 已存在（区分大小写）");
        }

        var entity = new TB_Paper_Info
        {
            F_Code = dto.Code,
            F_GramWeight = dto.GramWeight,
            F_PaperWidth = dto.PaperWidth,
            F_Brand = dto.Brand,
            F_RemainLS2 = dto.RemainLS2,
            F_RemainMS3 = dto.RemainMS3,
            F_RemainLS3 = dto.RemainLS3,
            F_IsDelete = false,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<PaperInfoDto>.Ok(new PaperInfoDto
        {
            Id = inserted.F_ID,
            Code = inserted.F_Code,
            GramWeight = inserted.F_GramWeight,
            PaperWidth = inserted.F_PaperWidth,
            Brand = inserted.F_Brand,
            RemainLS2 = inserted.F_RemainLS2,
            RemainMS3 = inserted.F_RemainMS3,
            RemainLS3 = inserted.F_RemainLS3,
        }, "已新增原纸");
    }

    /// <summary>修改原纸</summary>
    [HttpPut("papers/{id:long}")]
    public async Task<ApiResult<PaperInfoDto>> UpdatePaper(long id, [FromBody] PaperInfoDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<PaperInfoDto>.Fail("仅管理员可维护原纸资料", 403);
        }

        var row = await _base.Db.Queryable<TB_Paper_Info>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<PaperInfoDto>.Fail("原纸不存在");
        }

        if (string.IsNullOrWhiteSpace(dto.Code))
        {
            return ApiResult<PaperInfoDto>.Fail("原纸代号不能为空");
        }

        var duplicated = await _base.Db.Queryable<TB_Paper_Info>()
            .Where(r => r.F_IsDelete != true && r.F_ID != id && r.F_Code == dto.Code)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<PaperInfoDto>.Fail($"原纸代号 {dto.Code} 已存在（区分大小写）");
        }

        var oldCode = row.F_Code;

        row.F_Code = dto.Code;
        row.F_GramWeight = dto.GramWeight;
        row.F_PaperWidth = dto.PaperWidth;
        row.F_Brand = dto.Brand;
        row.F_RemainLS2 = dto.RemainLS2;
        row.F_RemainMS3 = dto.RemainMS3;
        row.F_RemainLS3 = dto.RemainLS3;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        // 代号改了，品牌参数与胶水值跟着改
        if (oldCode != row.F_Code)
        {
            await _base.Db.Updateable<TB_Paper_BrandParam>()
                .SetColumns(b => b.F_PaperCode == row.F_Code)
                .Where(b => b.F_PaperCode == oldCode)
                .ExecuteCommandAsync();

            await _base.Db.Updateable<TB_Paper_GlueValue>()
                .SetColumns(g => g.F_PaperCode == row.F_Code)
                .Where(g => g.F_PaperCode == oldCode)
                .ExecuteCommandAsync();
        }

        return ApiResult<PaperInfoDto>.Ok(dto, "已保存原纸");
    }

    /// <summary>删除原纸（软删）</summary>
    [HttpDelete("papers/{id:long}")]
    public async Task<ApiResult<ApiEmpty>> DeletePaper(long id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护原纸资料", 403);
        }

        var row = await _base.Db.Queryable<TB_Paper_Info>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("原纸不存在");
        }

        row.F_IsDelete = true;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除原纸");
    }

    /// <summary>原纸品牌信息：供应商张力表 + 胶水值表</summary>
    [HttpGet("papers/{code}/brand-info")]
    public async Task<ApiResult<PaperBrandSaveRequest>> PaperBrandInfo(string code)
    {
        var suppliers = await _base.Db.Queryable<TB_Paper_BrandParam>()
            .Where(r => r.F_PaperCode == code)
            .OrderBy(r => r.F_ID)
            .ToListAsync();

        var glues = await _base.Db.Queryable<TB_Paper_GlueValue>()
            .Where(r => r.F_PaperCode == code)
            .OrderBy(r => r.F_MachineType)
            .OrderBy(r => r.F_ID)
            .ToListAsync();

        return ApiResult<PaperBrandSaveRequest>.Ok(new PaperBrandSaveRequest
        {
            Suppliers = suppliers.Select(b => new PaperBrandParamDto
            {
                Id = b.F_ID,
                Supplier = b.F_Supplier,
                RatedTension = b.F_RatedTension,
                SteamGsm = b.F_SteamGsm,
                GlueGsm = b.F_GlueGsm,
                WrapGsm = b.F_WrapGsm,
                TensionLS0 = b.F_TensionLS0,
                TensionMS1 = b.F_TensionMS1,
                TensionLS1 = b.F_TensionLS1,
                TensionMS2 = b.F_TensionMS2,
                TensionLS2 = b.F_TensionLS2,
                TensionMS3 = b.F_TensionMS3,
                TensionLS3 = b.F_TensionLS3,
            }).ToList(),
            GlueValues = glues.Select(g => new PaperGlueValueDto
            {
                Id = g.F_ID,
                MachineType = g.F_MachineType,
                FluteType = g.F_FluteType,
                Layer = g.F_Layer,
                GlueValue = g.F_GlueValue,
            }).ToList(),
        });
    }

    /// <summary>保存原纸品牌信息（整组替换该原纸的供应商行与胶水值）</summary>
    [HttpPost("papers/{code}/brand-info")]
    public async Task<ApiResult<ApiEmpty>> SavePaperBrandInfo(string code, [FromBody] PaperBrandSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护原纸品牌信息", 403);
        }

        var paper = await _base.Db.Queryable<TB_Paper_Info>().Where(r => r.F_Code == code).FirstAsync();
        if (paper is null)
        {
            return ApiResult<ApiEmpty>.Fail($"原纸 {code} 不存在");
        }

        await _base.Db.Deleteable<TB_Paper_BrandParam>().Where(r => r.F_PaperCode == code).ExecuteCommandAsync();
        await _base.Db.Deleteable<TB_Paper_GlueValue>().Where(r => r.F_PaperCode == code).ExecuteCommandAsync();

        var editor = User.Identity?.Name;
        var now = DateTime.Now;

        foreach (var item in request.Suppliers.Where(s => !string.IsNullOrWhiteSpace(s.Supplier)))
        {
            await _base.Db.Insertable(new TB_Paper_BrandParam
            {
                F_PaperCode = code,
                F_Supplier = item.Supplier.Trim(),
                F_RatedTension = item.RatedTension,
                F_SteamGsm = item.SteamGsm,
                F_GlueGsm = item.GlueGsm,
                F_WrapGsm = item.WrapGsm,
                F_TensionLS0 = item.TensionLS0,
                F_TensionMS1 = item.TensionMS1,
                F_TensionLS1 = item.TensionLS1,
                F_TensionMS2 = item.TensionMS2,
                F_TensionLS2 = item.TensionLS2,
                F_TensionMS3 = item.TensionMS3,
                F_TensionLS3 = item.TensionLS3,
                F_Editor = editor,
                F_EditTime = now,
            }).ExecuteCommandAsync();
        }

        foreach (var item in request.GlueValues.Where(g => !string.IsNullOrWhiteSpace(g.MachineType) && !string.IsNullOrWhiteSpace(g.FluteType)))
        {
            await _base.Db.Insertable(new TB_Paper_GlueValue
            {
                F_PaperCode = code,
                F_MachineType = item.MachineType,
                F_FluteType = item.FluteType,
                F_Layer = item.Layer,
                F_GlueValue = item.GlueValue,
                F_Editor = editor,
                F_EditTime = now,
            }).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(),
            $"已保存原纸 {code} 的 {request.Suppliers.Count} 个供应商参数与 {request.GlueValues.Count} 条胶水值");
    }

    // ============================ 班组资料 ============================

    /// <summary>班组资料列表</summary>
    [HttpGet("teams")]
    public async Task<ApiResult<List<TeamInfoDto>>> Teams(string? name = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<TB_Team_Info>()
            .WhereIF(!showAll, r => r.F_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(name), r => r.F_TeamName.Contains(name!) || r.F_ShiftNo.Contains(name!))
            .OrderBy(r => r.F_ShiftNo)
            .ToListAsync();

        return ApiResult<List<TeamInfoDto>>.Ok(rows.Select(ToTeamDto).ToList());
    }

    /// <summary>新增班组</summary>
    [HttpPost("teams")]
    public async Task<ApiResult<TeamInfoDto>> CreateTeam([FromBody] TeamInfoDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<TeamInfoDto>.Fail("仅管理员可维护班组资料", 403);
        }

        if (string.IsNullOrWhiteSpace(dto.ShiftNo))
        {
            return ApiResult<TeamInfoDto>.Fail("班次号不能为空");
        }

        if (string.IsNullOrWhiteSpace(dto.TeamName))
        {
            return ApiResult<TeamInfoDto>.Fail("班组名称不能为空");
        }

        var exists = await _base.Db.Queryable<TB_Team_Info>()
            .Where(r => r.F_IsDelete != true && r.F_ShiftNo == dto.ShiftNo)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<TeamInfoDto>.Fail($"班次号 {dto.ShiftNo} 已存在");
        }

        var entity = new TB_Team_Info
        {
            F_ShiftNo = dto.ShiftNo.Trim(),
            F_TeamName = dto.TeamName.Trim(),
            F_StartTime = NormalizeTime(dto.StartTime),
            F_EndTime = NormalizeTime(dto.EndTime),
            F_Leader = dto.Leader,
            F_Forklift1 = dto.Forklift1,
            F_Forklift2 = dto.Forklift2,
            F_IsDelete = false,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<TeamInfoDto>.Ok(ToTeamDto(inserted), "已新增班组");
    }

    /// <summary>修改班组</summary>
    [HttpPut("teams/{id:long}")]
    public async Task<ApiResult<TeamInfoDto>> UpdateTeam(long id, [FromBody] TeamInfoDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<TeamInfoDto>.Fail("仅管理员可维护班组资料", 403);
        }

        var row = await _base.Db.Queryable<TB_Team_Info>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<TeamInfoDto>.Fail("班组不存在");
        }

        if (string.IsNullOrWhiteSpace(dto.ShiftNo))
        {
            return ApiResult<TeamInfoDto>.Fail("班次号不能为空");
        }

        if (string.IsNullOrWhiteSpace(dto.TeamName))
        {
            return ApiResult<TeamInfoDto>.Fail("班组名称不能为空");
        }

        var duplicated = await _base.Db.Queryable<TB_Team_Info>()
            .Where(r => r.F_IsDelete != true && r.F_ID != id && r.F_ShiftNo == dto.ShiftNo)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<TeamInfoDto>.Fail($"班次号 {dto.ShiftNo} 已存在");
        }

        row.F_ShiftNo = dto.ShiftNo.Trim();
        row.F_TeamName = dto.TeamName.Trim();
        row.F_StartTime = NormalizeTime(dto.StartTime);
        row.F_EndTime = NormalizeTime(dto.EndTime);
        row.F_Leader = dto.Leader;
        row.F_Forklift1 = dto.Forklift1;
        row.F_Forklift2 = dto.Forklift2;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<TeamInfoDto>.Ok(ToTeamDto(row), "已保存班组");
    }

    /// <summary>删除班组（软删）</summary>
    [HttpDelete("teams/{id:long}")]
    public async Task<ApiResult<ApiEmpty>> DeleteTeam(long id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护班组资料", 403);
        }

        var row = await _base.Db.Queryable<TB_Team_Info>().Where(r => r.F_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("班组不存在");
        }

        row.F_IsDelete = true;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除班组");
    }

    private static TeamInfoDto ToTeamDto(TB_Team_Info r) => new()
    {
        Id = r.F_ID,
        ShiftNo = r.F_ShiftNo,
        TeamName = r.F_TeamName,
        StartTime = r.F_StartTime,
        EndTime = r.F_EndTime,
        Leader = r.F_Leader,
        Forklift1 = r.F_Forklift1,
        Forklift2 = r.F_Forklift2,
        Creator = r.F_Creator,
        CreateTime = r.F_CreateTime?.ToString("yyyy-MM-dd HH:mm:ss"),
        Editor = r.F_Editor,
        EditTime = r.F_EditTime?.ToString("yyyy-MM-dd HH:mm:ss"),
    };

    /// <summary>时间串统一成 HH:mm:ss，空串转 null</summary>
    private static string? NormalizeTime(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        var text = value.Trim();
        if (TimeSpan.TryParse(text, out var span))
        {
            return new TimeSpan(span.Hours, span.Minutes, span.Seconds).ToString(@"hh\:mm\:ss");
        }

        return text;
    }

    // ============================ 规则设置 ============================

    /// <summary>产线楞型规则设置（自动修边/出垛判定/排垛方向/厚度计算模式）</summary>
    [HttpGet("line-flute-rules")]
    public async Task<ApiResult<LineFluteRuleDto>> LineFluteRules()
    {
        var row = await _base.Db.Queryable<TB_Line_FluteRule>().OrderBy(r => r.F_ID).FirstAsync();
        if (row is null)
        {
            return ApiResult<LineFluteRuleDto>.Ok(new LineFluteRuleDto
            {
                AutoTrimEnabled = false,
                AutoTrimThreshold = 10m,
                AutoTrimType = "不修边",
                ThicknessCompressRate = 0.8m,
                StackCountBasis = "剁数",
                StackDirection = "操作侧",
                ThicknessCalcMode = "克重区间模式",
            });
        }

        return ApiResult<LineFluteRuleDto>.Ok(new LineFluteRuleDto
        {
            AutoTrimEnabled = row.F_AutoTrimEnabled ?? false,
            AutoTrimThreshold = row.F_AutoTrimThreshold,
            AutoTrimType = row.F_AutoTrimType,
            ThicknessCompressRate = row.F_ThicknessCompressRate,
            StackCountBasis = row.F_StackCountBasis,
            StackDirection = row.F_StackDirection,
            ThicknessCalcMode = row.F_ThicknessCalcMode,
        });
    }

    /// <summary>保存规则设置（管理员）</summary>
    [HttpPost("line-flute-rules")]
    public async Task<ApiResult<ApiEmpty>> SaveLineFluteRules([FromBody] LineFluteRuleDto dto)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可保存产线楞型规则设置", 403);
        }

        var row = await _base.Db.Queryable<TB_Line_FluteRule>().OrderBy(r => r.F_ID).FirstAsync();
        if (row is null)
        {
            await _base.Db.Insertable(new TB_Line_FluteRule
            {
                F_AutoTrimEnabled = dto.AutoTrimEnabled,
                F_AutoTrimThreshold = dto.AutoTrimThreshold,
                F_AutoTrimType = dto.AutoTrimType,
                F_ThicknessCompressRate = dto.ThicknessCompressRate,
                F_StackCountBasis = dto.StackCountBasis,
                F_StackDirection = dto.StackDirection,
                F_ThicknessCalcMode = dto.ThicknessCalcMode,
                F_Editor = User.Identity?.Name,
                F_EditTime = DateTime.Now,
            }).ExecuteCommandAsync();

            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已保存产线楞型规则设置");
        }

        row.F_AutoTrimEnabled = dto.AutoTrimEnabled;
        row.F_AutoTrimThreshold = dto.AutoTrimThreshold;
        row.F_AutoTrimType = dto.AutoTrimType;
        row.F_ThicknessCompressRate = dto.ThicknessCompressRate;
        row.F_StackCountBasis = dto.StackCountBasis;
        row.F_StackDirection = dto.StackDirection;
        row.F_ThicknessCalcMode = dto.ThicknessCalcMode;
        row.F_Editor = User.Identity?.Name;
        row.F_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已保存产线楞型规则设置");
    }

    // ============================ 映射 ============================

    private static LineFluteDto ToDto(TB_Line_Flute r) => new()
    {
        Id = r.F_ID,
        DoorWidth = r.F_DoorWidth,
        FluteType = r.F_FluteType,
        Thickness = r.F_Thickness,
        Thickness1 = r.F_Thickness1,
        Thickness2 = r.F_Thickness2,
        Thickness3 = r.F_Thickness3,
        WeightThreshold1 = r.F_WeightThreshold1,
        WeightThreshold2 = r.F_WeightThreshold2,
        WeightThreshold3 = r.F_WeightThreshold3,
        MaxSlit = r.F_MaxSlit,
        MinCutLength = r.F_MinCutLength,
        MaxCutLength = r.F_MaxCutLength,
        MinTrim = r.F_MinTrim,
        MaxTrim = r.F_MaxTrim,
        UpperStackLimit = r.F_UpperStackLimit,
        LowerStackLimit = r.F_LowerStackLimit,
        StackOpenThreshold1 = r.F_StackOpenThreshold1,
        StackOpenThreshold2 = r.F_StackOpenThreshold2,
        StackOpenThreshold3 = r.F_StackOpenThreshold3,
        UpperStackCount1 = r.F_UpperStackCount1,
        UpperStackCount2 = r.F_UpperStackCount2,
        UpperStackCount3 = r.F_UpperStackCount3,
        LowerStackCount1 = r.F_LowerStackCount1,
        LowerStackCount2 = r.F_LowerStackCount2,
        LowerStackCount3 = r.F_LowerStackCount3,
        SmallLine = r.F_SmallLine,
        SmallLineDeepen = r.F_SmallLineDeepen,
        PlainLineDepth = r.F_PlainLineDepth,
        NormalLineDepth = r.F_NormalLineDepth,
        DeepLineDepth = r.F_DeepLineDepth,
        MaxSpeed = r.F_MaxSpeed,
        RollerCount = r.F_RollerCount,
        Trim = r.F_Trim,
        Creator = r.F_Creator,
        CreateTime = r.F_CreateTime,
        Editor = r.F_Editor,
        EditTime = r.F_EditTime,
    };

    private static TB_Line_Flute FromDto(LineFluteDto d) => new()
    {
        F_DoorWidth = d.DoorWidth,
        F_FluteType = d.FluteType.Trim(),
        F_Thickness = d.Thickness,
        F_Thickness1 = d.Thickness1,
        F_Thickness2 = d.Thickness2,
        F_Thickness3 = d.Thickness3,
        F_WeightThreshold1 = d.WeightThreshold1,
        F_WeightThreshold2 = d.WeightThreshold2,
        F_WeightThreshold3 = d.WeightThreshold3,
        F_MaxSlit = d.MaxSlit,
        F_MinCutLength = d.MinCutLength,
        F_MaxCutLength = d.MaxCutLength,
        F_MinTrim = d.MinTrim,
        F_MaxTrim = d.MaxTrim,
        F_UpperStackLimit = d.UpperStackLimit,
        F_LowerStackLimit = d.LowerStackLimit,
        F_StackOpenThreshold1 = d.StackOpenThreshold1,
        F_StackOpenThreshold2 = d.StackOpenThreshold2,
        F_StackOpenThreshold3 = d.StackOpenThreshold3,
        F_UpperStackCount1 = d.UpperStackCount1,
        F_UpperStackCount2 = d.UpperStackCount2,
        F_UpperStackCount3 = d.UpperStackCount3,
        F_LowerStackCount1 = d.LowerStackCount1,
        F_LowerStackCount2 = d.LowerStackCount2,
        F_LowerStackCount3 = d.LowerStackCount3,
        F_SmallLine = d.SmallLine,
        F_SmallLineDeepen = d.SmallLineDeepen,
        F_PlainLineDepth = d.PlainLineDepth,
        F_NormalLineDepth = d.NormalLineDepth,
        F_DeepLineDepth = d.DeepLineDepth,
        F_MaxSpeed = d.MaxSpeed,
        F_RollerCount = d.RollerCount,
        F_Trim = d.Trim,
        F_IsDelete = false,
    };
}
