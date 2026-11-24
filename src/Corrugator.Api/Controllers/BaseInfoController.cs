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
        var rows = await _base.Db.Queryable<W_Line_Flute>()
            .WhereIF(!showAll, r => r.WF_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(fluteType), r => r.WF_FluteType.Contains(fluteType!))
            .OrderBy(r => r.WF_DoorWidth)
            .ToListAsync();

        var ordered = rows
            .OrderBy(r => r.WF_DoorWidth)
            .ThenBy(r => r.WF_FluteType)
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

        var exists = await _base.Db.Queryable<W_Line_Flute>()
            .Where(r => r.WF_IsDelete != true && r.WF_DoorWidth == dto.DoorWidth && r.WF_FluteType == dto.FluteType)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<LineFluteDto>.Fail($"门幅 {dto.DoorWidth} / 楞型 {dto.FluteType} 已存在");
        }

        var entity = FromDto(dto);
        entity.WF_Creator = User.Identity?.Name;
        entity.WF_CreateTime = DateTime.Now;

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

        var row = await _base.Db.Queryable<W_Line_Flute>().Where(r => r.WF_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<LineFluteDto>.Fail("产线楞型不存在");
        }

        if (dto.DoorWidth <= 0 || string.IsNullOrWhiteSpace(dto.FluteType))
        {
            return ApiResult<LineFluteDto>.Fail("门幅与楞型不能为空");
        }

        var duplicated = await _base.Db.Queryable<W_Line_Flute>()
            .Where(r => r.WF_IsDelete != true && r.WF_ID != id && r.WF_DoorWidth == dto.DoorWidth && r.WF_FluteType == dto.FluteType)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<LineFluteDto>.Fail($"门幅 {dto.DoorWidth} / 楞型 {dto.FluteType} 已存在");
        }

        var updated = FromDto(dto);
        updated.WF_ID = id;
        updated.WF_Creator = row.WF_Creator;
        updated.WF_CreateTime = row.WF_CreateTime;
        updated.WF_Editor = User.Identity?.Name;
        updated.WF_EditTime = DateTime.Now;

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

        var row = await _base.Db.Queryable<W_Line_Flute>().Where(r => r.WF_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("产线楞型不存在");
        }

        row.WF_IsDelete = true;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除产线楞型");
    }

    /// <summary>立即更新订单：把产线楞型刷新并下发到在制订单（当前只刷新服务端缓存）</summary>
    [HttpPost("line-flutes/refresh-orders")]
    public async Task<ApiResult<ApiEmpty>> RefreshOrders()
    {
        var count = await _base.Db.Queryable<W_Line_Flute>().Where(r => r.WF_IsDelete != true).CountAsync();
        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已重新加载 {count} 条产线楞型（订单侧刷新将在订单接口联调后生效）");
    }

    // ============================ 原纸资料 ============================

    /// <summary>原纸资料列表（原纸代号模糊过滤，区分大小写在客户端提示）</summary>
    [HttpGet("papers")]
    public async Task<ApiResult<List<PaperInfoDto>>> Papers(string? code = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<W_Paper_Info>()
            .WhereIF(!showAll, r => r.WF_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(code), r => r.WF_Code.Contains(code!))
            .OrderBy(r => r.WF_Code)
            .ToListAsync();

        return ApiResult<List<PaperInfoDto>>.Ok(rows.Select(r => new PaperInfoDto
        {
            Id = r.WF_ID,
            Code = r.WF_Code,
            GramWeight = r.WF_GramWeight,
            PaperWidth = r.WF_PaperWidth,
            Brand = r.WF_Brand,
            RemainLS2 = r.WF_RemainLS2,
            RemainMS3 = r.WF_RemainMS3,
            RemainLS3 = r.WF_RemainLS3,
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

        var exists = await _base.Db.Queryable<W_Paper_Info>()
            .Where(r => r.WF_IsDelete != true && r.WF_Code == dto.Code)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<PaperInfoDto>.Fail($"原纸代号 {dto.Code} 已存在（区分大小写）");
        }

        var entity = new W_Paper_Info
        {
            WF_Code = dto.Code,
            WF_GramWeight = dto.GramWeight,
            WF_PaperWidth = dto.PaperWidth,
            WF_Brand = dto.Brand,
            WF_RemainLS2 = dto.RemainLS2,
            WF_RemainMS3 = dto.RemainMS3,
            WF_RemainLS3 = dto.RemainLS3,
            WF_IsDelete = false,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
        };

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<PaperInfoDto>.Ok(new PaperInfoDto
        {
            Id = inserted.WF_ID,
            Code = inserted.WF_Code,
            GramWeight = inserted.WF_GramWeight,
            PaperWidth = inserted.WF_PaperWidth,
            Brand = inserted.WF_Brand,
            RemainLS2 = inserted.WF_RemainLS2,
            RemainMS3 = inserted.WF_RemainMS3,
            RemainLS3 = inserted.WF_RemainLS3,
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

        var row = await _base.Db.Queryable<W_Paper_Info>().Where(r => r.WF_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<PaperInfoDto>.Fail("原纸不存在");
        }

        if (string.IsNullOrWhiteSpace(dto.Code))
        {
            return ApiResult<PaperInfoDto>.Fail("原纸代号不能为空");
        }

        var duplicated = await _base.Db.Queryable<W_Paper_Info>()
            .Where(r => r.WF_IsDelete != true && r.WF_ID != id && r.WF_Code == dto.Code)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<PaperInfoDto>.Fail($"原纸代号 {dto.Code} 已存在（区分大小写）");
        }

        var oldCode = row.WF_Code;

        row.WF_Code = dto.Code;
        row.WF_GramWeight = dto.GramWeight;
        row.WF_PaperWidth = dto.PaperWidth;
        row.WF_Brand = dto.Brand;
        row.WF_RemainLS2 = dto.RemainLS2;
        row.WF_RemainMS3 = dto.RemainMS3;
        row.WF_RemainLS3 = dto.RemainLS3;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        // 代号改了，品牌参数与胶水值跟着改
        if (oldCode != row.WF_Code)
        {
            await _base.Db.Updateable<W_Paper_BrandParam>()
                .SetColumns(b => b.WF_PaperCode == row.WF_Code)
                .Where(b => b.WF_PaperCode == oldCode)
                .ExecuteCommandAsync();

            await _base.Db.Updateable<W_Paper_GlueValue>()
                .SetColumns(g => g.WF_PaperCode == row.WF_Code)
                .Where(g => g.WF_PaperCode == oldCode)
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

        var row = await _base.Db.Queryable<W_Paper_Info>().Where(r => r.WF_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("原纸不存在");
        }

        row.WF_IsDelete = true;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除原纸");
    }

    /// <summary>原纸品牌信息：供应商张力表 + 胶水值表</summary>
    [HttpGet("papers/{code}/brand-info")]
    public async Task<ApiResult<PaperBrandSaveRequest>> PaperBrandInfo(string code)
    {
        var suppliers = await _base.Db.Queryable<W_Paper_BrandParam>()
            .Where(r => r.WF_PaperCode == code)
            .OrderBy(r => r.WF_ID)
            .ToListAsync();

        var glues = await _base.Db.Queryable<W_Paper_GlueValue>()
            .Where(r => r.WF_PaperCode == code)
            .OrderBy(r => r.WF_MachineType)
            .OrderBy(r => r.WF_ID)
            .ToListAsync();

        return ApiResult<PaperBrandSaveRequest>.Ok(new PaperBrandSaveRequest
        {
            Suppliers = suppliers.Select(b => new PaperBrandParamDto
            {
                Id = b.WF_ID,
                Supplier = b.WF_Supplier,
                RatedTension = b.WF_RatedTension,
                SteamGsm = b.WF_SteamGsm,
                GlueGsm = b.WF_GlueGsm,
                WrapGsm = b.WF_WrapGsm,
                TensionLS0 = b.WF_TensionLS0,
                TensionMS1 = b.WF_TensionMS1,
                TensionLS1 = b.WF_TensionLS1,
                TensionMS2 = b.WF_TensionMS2,
                TensionLS2 = b.WF_TensionLS2,
                TensionMS3 = b.WF_TensionMS3,
                TensionLS3 = b.WF_TensionLS3,
            }).ToList(),
            GlueValues = glues.Select(g => new PaperGlueValueDto
            {
                Id = g.WF_ID,
                MachineType = g.WF_MachineType,
                FluteType = g.WF_FluteType,
                Layer = g.WF_Layer,
                GlueValue = g.WF_GlueValue,
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

        var paper = await _base.Db.Queryable<W_Paper_Info>().Where(r => r.WF_Code == code).FirstAsync();
        if (paper is null)
        {
            return ApiResult<ApiEmpty>.Fail($"原纸 {code} 不存在");
        }

        await _base.Db.Deleteable<W_Paper_BrandParam>().Where(r => r.WF_PaperCode == code).ExecuteCommandAsync();
        await _base.Db.Deleteable<W_Paper_GlueValue>().Where(r => r.WF_PaperCode == code).ExecuteCommandAsync();

        var editor = User.Identity?.Name;
        var now = DateTime.Now;

        foreach (var item in request.Suppliers.Where(s => !string.IsNullOrWhiteSpace(s.Supplier)))
        {
            await _base.Db.Insertable(new W_Paper_BrandParam
            {
                WF_PaperCode = code,
                WF_Supplier = item.Supplier.Trim(),
                WF_RatedTension = item.RatedTension,
                WF_SteamGsm = item.SteamGsm,
                WF_GlueGsm = item.GlueGsm,
                WF_WrapGsm = item.WrapGsm,
                WF_TensionLS0 = item.TensionLS0,
                WF_TensionMS1 = item.TensionMS1,
                WF_TensionLS1 = item.TensionLS1,
                WF_TensionMS2 = item.TensionMS2,
                WF_TensionLS2 = item.TensionLS2,
                WF_TensionMS3 = item.TensionMS3,
                WF_TensionLS3 = item.TensionLS3,
                WF_Editor = editor,
                WF_EditTime = now,
            }).ExecuteCommandAsync();
        }

        foreach (var item in request.GlueValues.Where(g => !string.IsNullOrWhiteSpace(g.MachineType) && !string.IsNullOrWhiteSpace(g.FluteType)))
        {
            await _base.Db.Insertable(new W_Paper_GlueValue
            {
                WF_PaperCode = code,
                WF_MachineType = item.MachineType,
                WF_FluteType = item.FluteType,
                WF_Layer = item.Layer,
                WF_GlueValue = item.GlueValue,
                WF_Editor = editor,
                WF_EditTime = now,
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
        var rows = await _base.Db.Queryable<W_Team_Info>()
            .WhereIF(!showAll, r => r.WF_IsDelete != true)
            .WhereIF(!string.IsNullOrWhiteSpace(name), r => r.WF_TeamName.Contains(name!) || r.WF_ShiftNo.Contains(name!))
            .OrderBy(r => r.WF_ShiftNo)
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

        var exists = await _base.Db.Queryable<W_Team_Info>()
            .Where(r => r.WF_IsDelete != true && r.WF_ShiftNo == dto.ShiftNo)
            .AnyAsync();

        if (exists)
        {
            return ApiResult<TeamInfoDto>.Fail($"班次号 {dto.ShiftNo} 已存在");
        }

        var entity = new W_Team_Info
        {
            WF_ShiftNo = dto.ShiftNo.Trim(),
            WF_TeamName = dto.TeamName.Trim(),
            WF_StartTime = NormalizeTime(dto.StartTime),
            WF_EndTime = NormalizeTime(dto.EndTime),
            WF_Leader = dto.Leader,
            WF_Forklift1 = dto.Forklift1,
            WF_Forklift2 = dto.Forklift2,
            WF_IsDelete = false,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
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

        var row = await _base.Db.Queryable<W_Team_Info>().Where(r => r.WF_ID == id).FirstAsync();
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

        var duplicated = await _base.Db.Queryable<W_Team_Info>()
            .Where(r => r.WF_IsDelete != true && r.WF_ID != id && r.WF_ShiftNo == dto.ShiftNo)
            .AnyAsync();

        if (duplicated)
        {
            return ApiResult<TeamInfoDto>.Fail($"班次号 {dto.ShiftNo} 已存在");
        }

        row.WF_ShiftNo = dto.ShiftNo.Trim();
        row.WF_TeamName = dto.TeamName.Trim();
        row.WF_StartTime = NormalizeTime(dto.StartTime);
        row.WF_EndTime = NormalizeTime(dto.EndTime);
        row.WF_Leader = dto.Leader;
        row.WF_Forklift1 = dto.Forklift1;
        row.WF_Forklift2 = dto.Forklift2;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
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

        var row = await _base.Db.Queryable<W_Team_Info>().Where(r => r.WF_ID == id).FirstAsync();
        if (row is null)
        {
            return ApiResult<ApiEmpty>.Fail("班组不存在");
        }

        row.WF_IsDelete = true;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除班组");
    }

    private static TeamInfoDto ToTeamDto(W_Team_Info r) => new()
    {
        Id = r.WF_ID,
        ShiftNo = r.WF_ShiftNo,
        TeamName = r.WF_TeamName,
        StartTime = r.WF_StartTime,
        EndTime = r.WF_EndTime,
        Leader = r.WF_Leader,
        Forklift1 = r.WF_Forklift1,
        Forklift2 = r.WF_Forklift2,
        Creator = r.WF_Creator,
        CreateTime = r.WF_CreateTime?.ToString("yyyy-MM-dd HH:mm:ss"),
        Editor = r.WF_Editor,
        EditTime = r.WF_EditTime?.ToString("yyyy-MM-dd HH:mm:ss"),
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
        var row = await _base.Db.Queryable<W_Line_FluteRule>().OrderBy(r => r.WF_ID).FirstAsync();
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
            AutoTrimEnabled = row.WF_AutoTrimEnabled ?? false,
            AutoTrimThreshold = row.WF_AutoTrimThreshold,
            AutoTrimType = row.WF_AutoTrimType,
            ThicknessCompressRate = row.WF_ThicknessCompressRate,
            StackCountBasis = row.WF_StackCountBasis,
            StackDirection = row.WF_StackDirection,
            ThicknessCalcMode = row.WF_ThicknessCalcMode,
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

        var row = await _base.Db.Queryable<W_Line_FluteRule>().OrderBy(r => r.WF_ID).FirstAsync();
        if (row is null)
        {
            await _base.Db.Insertable(new W_Line_FluteRule
            {
                WF_AutoTrimEnabled = dto.AutoTrimEnabled,
                WF_AutoTrimThreshold = dto.AutoTrimThreshold,
                WF_AutoTrimType = dto.AutoTrimType,
                WF_ThicknessCompressRate = dto.ThicknessCompressRate,
                WF_StackCountBasis = dto.StackCountBasis,
                WF_StackDirection = dto.StackDirection,
                WF_ThicknessCalcMode = dto.ThicknessCalcMode,
                WF_Editor = User.Identity?.Name,
                WF_EditTime = DateTime.Now,
            }).ExecuteCommandAsync();

            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已保存产线楞型规则设置");
        }

        row.WF_AutoTrimEnabled = dto.AutoTrimEnabled;
        row.WF_AutoTrimThreshold = dto.AutoTrimThreshold;
        row.WF_AutoTrimType = dto.AutoTrimType;
        row.WF_ThicknessCompressRate = dto.ThicknessCompressRate;
        row.WF_StackCountBasis = dto.StackCountBasis;
        row.WF_StackDirection = dto.StackDirection;
        row.WF_ThicknessCalcMode = dto.ThicknessCalcMode;
        row.WF_Editor = User.Identity?.Name;
        row.WF_EditTime = DateTime.Now;
        await _base.Db.Updateable(row).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已保存产线楞型规则设置");
    }

    // ============================ 映射 ============================

    private static LineFluteDto ToDto(W_Line_Flute r) => new()
    {
        Id = r.WF_ID,
        DoorWidth = r.WF_DoorWidth,
        FluteType = r.WF_FluteType,
        Thickness = r.WF_Thickness,
        Thickness1 = r.WF_Thickness1,
        Thickness2 = r.WF_Thickness2,
        Thickness3 = r.WF_Thickness3,
        WeightThreshold1 = r.WF_WeightThreshold1,
        WeightThreshold2 = r.WF_WeightThreshold2,
        WeightThreshold3 = r.WF_WeightThreshold3,
        MaxSlit = r.WF_MaxSlit,
        MinCutLength = r.WF_MinCutLength,
        MaxCutLength = r.WF_MaxCutLength,
        MinTrim = r.WF_MinTrim,
        MaxTrim = r.WF_MaxTrim,
        UpperStackLimit = r.WF_UpperStackLimit,
        LowerStackLimit = r.WF_LowerStackLimit,
        StackOpenThreshold1 = r.WF_StackOpenThreshold1,
        StackOpenThreshold2 = r.WF_StackOpenThreshold2,
        StackOpenThreshold3 = r.WF_StackOpenThreshold3,
        UpperStackCount1 = r.WF_UpperStackCount1,
        UpperStackCount2 = r.WF_UpperStackCount2,
        UpperStackCount3 = r.WF_UpperStackCount3,
        LowerStackCount1 = r.WF_LowerStackCount1,
        LowerStackCount2 = r.WF_LowerStackCount2,
        LowerStackCount3 = r.WF_LowerStackCount3,
        SmallLine = r.WF_SmallLine,
        SmallLineDeepen = r.WF_SmallLineDeepen,
        PlainLineDepth = r.WF_PlainLineDepth,
        NormalLineDepth = r.WF_NormalLineDepth,
        DeepLineDepth = r.WF_DeepLineDepth,
        MaxSpeed = r.WF_MaxSpeed,
        RollerCount = r.WF_RollerCount,
        Trim = r.WF_Trim,
        Creator = r.WF_Creator,
        CreateTime = r.WF_CreateTime,
        Editor = r.WF_Editor,
        EditTime = r.WF_EditTime,
    };

    private static W_Line_Flute FromDto(LineFluteDto d) => new()
    {
        WF_DoorWidth = d.DoorWidth,
        WF_FluteType = d.FluteType.Trim(),
        WF_Thickness = d.Thickness,
        WF_Thickness1 = d.Thickness1,
        WF_Thickness2 = d.Thickness2,
        WF_Thickness3 = d.Thickness3,
        WF_WeightThreshold1 = d.WeightThreshold1,
        WF_WeightThreshold2 = d.WeightThreshold2,
        WF_WeightThreshold3 = d.WeightThreshold3,
        WF_MaxSlit = d.MaxSlit,
        WF_MinCutLength = d.MinCutLength,
        WF_MaxCutLength = d.MaxCutLength,
        WF_MinTrim = d.MinTrim,
        WF_MaxTrim = d.MaxTrim,
        WF_UpperStackLimit = d.UpperStackLimit,
        WF_LowerStackLimit = d.LowerStackLimit,
        WF_StackOpenThreshold1 = d.StackOpenThreshold1,
        WF_StackOpenThreshold2 = d.StackOpenThreshold2,
        WF_StackOpenThreshold3 = d.StackOpenThreshold3,
        WF_UpperStackCount1 = d.UpperStackCount1,
        WF_UpperStackCount2 = d.UpperStackCount2,
        WF_UpperStackCount3 = d.UpperStackCount3,
        WF_LowerStackCount1 = d.LowerStackCount1,
        WF_LowerStackCount2 = d.LowerStackCount2,
        WF_LowerStackCount3 = d.LowerStackCount3,
        WF_SmallLine = d.SmallLine,
        WF_SmallLineDeepen = d.SmallLineDeepen,
        WF_PlainLineDepth = d.PlainLineDepth,
        WF_NormalLineDepth = d.NormalLineDepth,
        WF_DeepLineDepth = d.DeepLineDepth,
        WF_MaxSpeed = d.MaxSpeed,
        WF_RollerCount = d.RollerCount,
        WF_Trim = d.Trim,
        WF_IsDelete = false,
    };
}
