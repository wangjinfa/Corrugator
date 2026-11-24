using Corrugator.Application.Abstractions;
using Corrugator.Application.Security;
using Corrugator.Domain.Entities.BaseAuth;
using Corrugator.Domain.Entities.System;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

/// <summary>
/// 基础信息页的后台数据：用户 / 角色 / 功能权限（含菜单树与增删改）。
/// 数据来自 BaseDB 公共表（已并入 IPS 库），与当前请求线路无关，仅管理员可见。
/// </summary>
[ApiController]
[Route("api/system")]
[Authorize]
public class SystemController : ControllerBase
{
    private const string SettingsType = "TB_Sys_Config";

    private readonly IBaseDbAccess _base;

    public SystemController(IBaseDbAccess baseDb)
    {
        _base = baseDb;
    }

    private bool IsAdmin => User.IsInRole("admin");

    // ============================ API 授权 ============================

    /// <summary>API 账号列表（左表）</summary>
    [HttpGet("api-users")]
    public async Task<ApiResult<List<ApiAccountDto>>> ApiUsers(bool showAll = false)
    {
        var rows = await _base.Db.Queryable<S_ApiUser>()
            .WhereIF(!showAll, u => !u.F_IsDelete)
            .OrderBy(u => u.F_ID)
            .ToListAsync();

        var list = rows.Select(u => new ApiAccountDto
        {
            Id = u.F_ID,
            Account = u.F_Account,
            Secret = u.F_Secret,
            SystemName = u.F_SystemName,
            IsUse = u.F_IsUse ?? false,
            IsDeleted = u.F_IsDelete,
            Creator = u.F_Creator,
            CreateTime = u.F_CreateTime,
            Editor = u.F_Editor,
            EditTime = u.F_EditTime,
        }).ToList();

        return ApiResult<List<ApiAccountDto>>.Ok(list);
    }

    /// <summary>接口清单（右表）；传 userId 时带出授权状态</summary>
    [HttpGet("apis")]
    public async Task<ApiResult<List<ApiItemDto>>> Apis(long? userId = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<S_Api>()
            .WhereIF(!showAll, a => !a.F_IsDelete)
            .OrderBy(a => a.F_ID)
            .ToListAsync();

        var authorizedIds = new HashSet<long>();
        if (userId is not null and > 0)
        {
            var links = await _base.Db.Queryable<S_ApiAuthorize>()
                .Where(l => l.F_ApiUserId == userId && (l.F_IsUse == null || l.F_IsUse == true))
                .ToListAsync();
            authorizedIds = links.Select(l => l.F_ApiId).ToHashSet();
        }

        var list = rows.Select(a => new ApiItemDto
        {
            Id = a.F_ID,
            Desc = a.F_Desc,
            Url = a.F_Url,
            SystemName = a.F_SystemName,
            IsUse = a.F_IsUse ?? false,
            IsDeleted = a.F_IsDelete,
            Authorized = authorizedIds.Contains(a.F_ID),
        }).ToList();

        return ApiResult<List<ApiItemDto>>.Ok(list);
    }

    /// <summary>新增 API 账号</summary>
    [HttpPost("api-users")]
    public async Task<ApiResult<ApiAccountDto>> CreateApiUser([FromBody] ApiAccountSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiAccountDto>.Fail("仅管理员可维护 API 授权", 403);
        }

        if (string.IsNullOrWhiteSpace(request.Account))
        {
            return ApiResult<ApiAccountDto>.Fail("账号不能为空");
        }

        var account = request.Account.Trim();
        var exists = await _base.Db.Queryable<S_ApiUser>()
            .Where(u => u.F_Account == account && !u.F_IsDelete).AnyAsync();
        if (exists)
        {
            return ApiResult<ApiAccountDto>.Fail("账号已存在");
        }

        var entity = new S_ApiUser
        {
            F_Account = account,
            F_Secret = request.Secret?.Trim(),
            F_SystemName = request.SystemName?.Trim(),
            F_IsUse = request.IsUse,
            F_Creator = User.Identity?.Name,
            F_CreateTime = DateTime.Now,
        };

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<ApiAccountDto>.Ok(new ApiAccountDto
        {
            Id = inserted.F_ID,
            Account = inserted.F_Account,
            Secret = inserted.F_Secret,
            SystemName = inserted.F_SystemName,
            IsUse = inserted.F_IsUse ?? false,
        }, "已新增");
    }

    /// <summary>修改 API 账号</summary>
    [HttpPut("api-users/{id:long}")]
    public async Task<ApiResult<ApiAccountDto>> UpdateApiUser(long id, [FromBody] ApiAccountSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiAccountDto>.Fail("仅管理员可维护 API 授权", 403);
        }

        var entity = await _base.Db.Queryable<S_ApiUser>().FirstAsync(u => u.F_ID == id);
        if (entity is null)
        {
            return ApiResult<ApiAccountDto>.Fail("记录不存在", 404);
        }

        entity.F_Account = request.Account?.Trim() ?? entity.F_Account;
        entity.F_Secret = request.Secret?.Trim();
        entity.F_SystemName = request.SystemName?.Trim();
        entity.F_IsUse = request.IsUse;
        entity.F_Editor = User.Identity?.Name;
        entity.F_EditTime = DateTime.Now;

        await _base.Db.Updateable(entity).ExecuteCommandAsync();
        return ApiResult<ApiAccountDto>.Ok(new ApiAccountDto
        {
            Id = entity.F_ID,
            Account = entity.F_Account,
            Secret = entity.F_Secret,
            SystemName = entity.F_SystemName,
            IsUse = entity.F_IsUse ?? false,
        }, "已保存");
    }

    /// <summary>保存账号的接口授权（整组替换：勾选的授权，未勾选的取消）</summary>
    [HttpPost("apis/authorize")]
    public async Task<ApiResult<ApiEmpty>> AuthorizeApis([FromBody] ApiAuthorizeRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护 API 授权", 403);
        }

        if (request.UserId <= 0)
        {
            return ApiResult<ApiEmpty>.Fail("请先在左侧选择账号");
        }

        var account = await _base.Db.Queryable<S_ApiUser>().FirstAsync(u => u.F_ID == request.UserId);
        if (account is null)
        {
            return ApiResult<ApiEmpty>.Fail("账号不存在", 404);
        }

        var apiIds = request.ApiIds.Distinct().ToList();

        // 先清掉该账号现有授权，再按本次勾选重建
        await _base.Db.Deleteable<S_ApiAuthorize>().Where(l => l.F_ApiUserId == request.UserId).ExecuteCommandAsync();

        foreach (var apiId in apiIds)
        {
            await _base.Db.Insertable(new S_ApiAuthorize
            {
                F_ApiUserId = request.UserId,
                F_ApiId = apiId,
                F_IsUse = true,
                F_Editor = User.Identity?.Name,
                F_EditTime = DateTime.Now,
            }).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已授权 {account.F_Account} 共 {apiIds.Count} 个接口");
    }

    // ============================ 订单扩展字段设置 ============================

    /// <summary>订单扩展字段：整表读取（固定 18 槽位）</summary>
    [HttpGet("order-ext-fields")]
    public async Task<ApiResult<List<OrderExtFieldDto>>> OrderExtFields()
    {
        var rows = await _base.Db.Queryable<TB_Order_ExtField>()
            .OrderBy(r => r.F_Seq)
            .ToListAsync();

        return ApiResult<List<OrderExtFieldDto>>.Ok(rows.Select(r => new OrderExtFieldDto
        {
            Id = r.F_ID,
            Seq = r.F_Seq,
            Code = r.F_Code,
            JsonCode = r.F_JsonCode,
            Name = r.F_Name,
            DataType = r.F_DataType,
            IsShowInList = r.F_IsShowInList ?? false,
        }).ToList());
    }

    /// <summary>订单扩展字段：整表保存（管理员）。页面为自动保存，一次提交全部行</summary>
    [HttpPost("order-ext-fields")]
    public async Task<ApiResult<ApiEmpty>> SaveOrderExtFields([FromBody] OrderExtFieldSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可保存订单扩展字段设置", 403);
        }

        if (request.Items.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("没有需要保存的行");
        }

        var existing = await _base.Db.Queryable<TB_Order_ExtField>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.F_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.F_Code == item.Code);

            if (row is null)
            {
                await _base.Db.Insertable(new TB_Order_ExtField
                {
                    F_Seq = item.Seq,
                    F_Code = item.Code,
                    F_JsonCode = item.JsonCode,
                    F_Name = item.Name,
                    F_DataType = item.DataType,
                    F_IsShowInList = item.IsShowInList,
                    F_Editor = User.Identity?.Name,
                    F_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.F_Seq = item.Seq;
            row.F_Code = item.Code;
            row.F_JsonCode = item.JsonCode;
            row.F_Name = item.Name;
            row.F_DataType = item.DataType;
            row.F_IsShowInList = item.IsShowInList;
            row.F_Editor = User.Identity?.Name;
            row.F_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 个扩展字段");
    }

    // ============================ IPS 部位显示/隐藏 ============================

    /// <summary>IPS 部位显示/隐藏：整表读取</summary>
    [HttpGet("ips-parts")]
    public async Task<ApiResult<List<IpsPartDto>>> IpsParts()
    {
        var rows = await _base.Db.Queryable<TB_Ips_PartDisplay>()
            .OrderBy(r => r.F_SortNo)
            .ToListAsync();

        return ApiResult<List<IpsPartDto>>.Ok(rows.Select(r => new IpsPartDto
        {
            Id = r.F_ID,
            Code = r.F_Code,
            Name = r.F_Name,
            IsShow = r.F_IsShow ?? true,
            SortNo = r.F_SortNo ?? 0,
        }).ToList());
    }

    /// <summary>IPS 部位显示/隐藏：整表保存（管理员）</summary>
    [HttpPost("ips-parts")]
    public async Task<ApiResult<ApiEmpty>> SaveIpsParts([FromBody] IpsPartSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可保存 IPS 部位显示设置", 403);
        }

        if (request.Items.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("没有需要保存的行");
        }

        var existing = await _base.Db.Queryable<TB_Ips_PartDisplay>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.F_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.F_Code == item.Code);

            if (row is null)
            {
                await _base.Db.Insertable(new TB_Ips_PartDisplay
                {
                    F_Code = item.Code,
                    F_Name = item.Name,
                    F_IsShow = item.IsShow,
                    F_SortNo = item.SortNo,
                    F_Editor = User.Identity?.Name,
                    F_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.F_Code = item.Code;
            row.F_Name = item.Name;
            row.F_IsShow = item.IsShow;
            row.F_SortNo = item.SortNo;
            row.F_Editor = User.Identity?.Name;
            row.F_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 个部位的显示设置");
    }

    // ============================ 订单颜色设置 ============================

    /// <summary>订单颜色设置：整表读取</summary>
    [HttpGet("order-colors")]
    public async Task<ApiResult<List<OrderColorDto>>> OrderColors()
    {
        var rows = await _base.Db.Queryable<TB_Order_ColorSet>()
            .OrderBy(r => r.F_Priority)
            .ToListAsync();

        return ApiResult<List<OrderColorDto>>.Ok(rows.Select(ToOrderColorDto).ToList());
    }

    /// <summary>订单颜色设置：整表保存（管理员）</summary>
    [HttpPost("order-colors")]
    public async Task<ApiResult<ApiEmpty>> SaveOrderColors([FromBody] OrderColorSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可保存订单颜色设置", 403);
        }

        if (request.Items.Count == 0)
        {
            return ApiResult<ApiEmpty>.Fail("没有需要保存的行");
        }

        var existing = await _base.Db.Queryable<TB_Order_ColorSet>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.F_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.F_Condition == item.Condition);

            if (row is null)
            {
                await _base.Db.Insertable(new TB_Order_ColorSet
                {
                    F_Condition = item.Condition,
                    F_Priority = item.Priority,
                    F_BackColor = Normalize(item.BackColor),
                    F_FontColor = Normalize(item.FontColor),
                    F_IsUse = item.IsUse,
                    F_Editor = User.Identity?.Name,
                    F_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.F_Condition = item.Condition;
            row.F_Priority = item.Priority;
            row.F_BackColor = Normalize(item.BackColor);
            row.F_FontColor = Normalize(item.FontColor);
            row.F_IsUse = item.IsUse;
            row.F_Editor = User.Identity?.Name;
            row.F_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 条订单颜色设置");
    }

    private static string? Normalize(string? color)
        => string.IsNullOrWhiteSpace(color) ? string.Empty : color.Trim();

    private static OrderColorDto ToOrderColorDto(TB_Order_ColorSet r) => new()
    {
        Id = r.F_ID,
        Condition = r.F_Condition,
        Priority = r.F_Priority,
        BackColor = r.F_BackColor,
        FontColor = r.F_FontColor,
        IsUse = r.F_IsUse ?? false,
    };

    // ============================ 系统设置 ============================

    /// <summary>系统设置：参数值 + 下拉选项</summary>
    [HttpGet("settings")]
    public async Task<ApiResult<SystemSettingsDto>> Settings()
    {
        var rows = await _base.Db.Queryable<TB_Sys_Config>().ToListAsync();
        var map = rows
            .GroupBy(r => r.F_Key)
            .ToDictionary(g => g.Key, g => g.OrderBy(r => r.F_ID).Last().F_Value);

        var dto = new SystemSettingsDto
        {
            UpdateUrl = Get(map, "UpdateUrl", "http://127.0.0.1:7776/BtsClientUpdate.xml")!,
            StartPage = Get(map, "StartPage", "SF1生管")!,
            ShowTaskbar = Get(map, "ShowTaskbar", "True")!.Equals("True", StringComparison.OrdinalIgnoreCase),
            Language = Get(map, "Language", "zh-CN")!,
            ShowGluePosition = Get(map, "ShowGluePosition", "False")!.Equals("True", StringComparison.OrdinalIgnoreCase),
        };

        var menus = await _base.Db.Queryable<S_Permission>()
            .Where(p => p.SP_Type == "菜单" && p.SP_PID != 0 && (p.SP_IsDel == null || p.SP_IsDel == false))
            .OrderBy(p => p.SP_SortNo)
            .ToListAsync();

        dto.StartPageOptions = menus.Select(p => p.SP_Name).Distinct().ToList();
        if (dto.StartPageOptions.Count == 0)
        {
            dto.StartPageOptions = new List<string> { "生管总控", "SF1生管", "SF2生管", "SF3生管", "DF生管", "同步屏", "办公室" };
        }

        if (!dto.StartPageOptions.Contains(dto.StartPage))
        {
            dto.StartPageOptions.Insert(0, dto.StartPage);
        }

        return ApiResult<SystemSettingsDto>.Ok(dto);
    }

    /// <summary>保存系统设置（管理员）</summary>
    [HttpPost("settings")]
    public async Task<ApiResult<ApiEmpty>> SaveSettings([FromBody] SystemSettingsSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可保存系统设置", 403);
        }

        if (string.IsNullOrWhiteSpace(request.UpdateUrl))
        {
            return ApiResult<ApiEmpty>.Fail("自动更新URL不能为空");
        }

        var values = new Dictionary<string, string>
        {
            ["UpdateUrl"] = request.UpdateUrl.Trim(),
            ["StartPage"] = request.StartPage?.Trim() ?? string.Empty,
            ["ShowTaskbar"] = request.ShowTaskbar ? "True" : "False",
            ["Language"] = request.Language?.Trim() ?? "zh-CN",
            ["ShowGluePosition"] = request.ShowGluePosition ? "True" : "False",
        };

        foreach (var pair in values)
        {
            var row = await _base.Db.Queryable<TB_Sys_Config>().FirstAsync(r => r.F_Key == pair.Key);
            if (row is null)
            {
                await _base.Db.Insertable(new TB_Sys_Config
                {
                    F_Key = pair.Key,
                    F_Value = pair.Value,
                    F_Desc = "系统设置",
                    F_Editor = User.Identity?.Name,
                    F_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
            }
            else
            {
                row.F_Value = pair.Value;
                row.F_Editor = User.Identity?.Name;
                row.F_EditTime = DateTime.Now;
                await _base.Db.Updateable(row).ExecuteCommandAsync();
            }
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已保存配置（客户端下次启动生效）");
    }

    private static string? Get(Dictionary<string, string?> map, string key, string fallback)
        => map.TryGetValue(key, out var value) && !string.IsNullOrWhiteSpace(value) ? value : fallback;

    // ============================ 用户 ============================

    [HttpGet("users")]
    public async Task<ApiResult<List<SystemUserDto>>> Users(string? account = null, string? name = null, bool showAll = false)
    {
        if (!IsAdmin)
        {
            return ApiResult<List<SystemUserDto>>.Fail("仅管理员可查看用户管理", 403);
        }

        var db = _base.Db;

        var query = db.Queryable<S_User>();

        if (!showAll)
        {
            query = query.Where(u => u.SU_IsDel == null || u.SU_IsDel == false);
        }

        if (!string.IsNullOrWhiteSpace(account))
        {
            var keyword = account.Trim();
            query = query.Where(u => u.SU_Account.Contains(keyword));
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(u => u.SU_UserName != null && u.SU_UserName.Contains(keyword));
        }

        var users = await query.OrderBy(u => u.SU_ID).ToListAsync();
        var links = await db.Queryable<S_UserRole>().ToListAsync();
        var roles = await db.Queryable<S_Role>().ToListAsync();
        var roleNames = roles.ToDictionary(r => r.SR_ID, r => r.SR_Name);

        var items = users.Select(u =>
        {
            var userRoles = links
                .Where(l => l.SU_ID == u.SU_ID)
                .Select(l => roleNames.TryGetValue(l.SR_ID, out var name) ? name : l.SR_ID.ToString())
                .ToList();

            return new SystemUserDto
            {
                SuId = u.SU_ID,
                Account = u.SU_Account,
                UserName = u.SU_UserName ?? string.Empty,
                PhoneNo = u.SU_PhoneNo,
                Gender = u.SU_Gender,
                StopPosition = u.SU_StopPosition,
                IsMultiLine = u.SU_IsMulti ?? false,
                IsDeleted = u.SU_IsDel ?? false,
                Roles = string.Join(" / ", userRoles),
                RoleIds = links.Where(l => l.SU_ID == u.SU_ID).Select(l => l.SR_ID).Distinct().ToList(),
                CreateTime = u.SU_CreateTime,
                Creator = u.SU_Creator,
                Editor = u.SU_Editor,
                EditTime = u.SU_EditTime,
            };
        }).ToList();

        return ApiResult<List<SystemUserDto>>.Ok(items);
    }

    /// <summary>新增用户（账号唯一，密码 PBKDF2）</summary>
    [HttpPost("users")]
    public async Task<ApiResult<SystemUserDto>> CreateUser([FromBody] UserSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemUserDto>.Fail("仅管理员可维护用户", 403);
        }

        var account = request.Account?.Trim();
        if (string.IsNullOrWhiteSpace(account))
        {
            return ApiResult<SystemUserDto>.Fail("账号不能为空");
        }

        if (string.IsNullOrWhiteSpace(request.Password))
        {
            return ApiResult<SystemUserDto>.Fail("新增用户必须设置密码");
        }

        var db = _base.Db;

        var exists = await db.Queryable<S_User>()
            .Where(u => u.SU_Account == account && (u.SU_IsDel == null || u.SU_IsDel == false))
            .AnyAsync();
        if (exists)
        {
            return ApiResult<SystemUserDto>.Fail("账号已存在");
        }

        var entity = new S_User
        {
            SU_Account = account,
            SU_Password = PasswordHasher.Hash(request.Password.Trim()),
            SU_UserName = string.IsNullOrWhiteSpace(request.UserName) ? account : request.UserName.Trim(),
            SU_PhoneNo = request.PhoneNo,
            SU_Gender = request.Gender,
            SU_StopPosition = request.StopPosition,
            SU_IsMulti = request.IsMultiLine,
            SU_IsDel = false,
            SU_Creator = User.Identity?.Name,
            SU_CreateTime = DateTime.Now,
        };
        entity = await db.Insertable(entity).ExecuteReturnEntityAsync();

        await ApplyUserRolesAsync(db, entity.SU_ID, request.RoleIds);

        return ApiResult<SystemUserDto>.Ok(await ToUserDtoAsync(db, entity), "已新增");
    }

    /// <summary>修改用户资料 / 重置密码 / 调整角色</summary>
    [HttpPut("users/{id:int}")]
    public async Task<ApiResult<SystemUserDto>> UpdateUser(int id, [FromBody] UserSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemUserDto>.Fail("仅管理员可维护用户", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_User>().Where(u => u.SU_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemUserDto>.Fail("记录不存在", 404);
        }

        var account = request.Account?.Trim();
        if (!string.IsNullOrWhiteSpace(account) && !string.Equals(account, entity.SU_Account, StringComparison.Ordinal))
        {
            var exists = await db.Queryable<S_User>()
                .Where(u => u.SU_ID != id && u.SU_Account == account && (u.SU_IsDel == null || u.SU_IsDel == false))
                .AnyAsync();
            if (exists)
            {
                return ApiResult<SystemUserDto>.Fail("账号已存在");
            }

            entity.SU_Account = account;
        }

        if (!string.IsNullOrWhiteSpace(request.UserName))
        {
            entity.SU_UserName = request.UserName.Trim();
        }

        entity.SU_PhoneNo = request.PhoneNo;
        entity.SU_Gender = request.Gender;
        entity.SU_StopPosition = request.StopPosition;
        entity.SU_IsMulti = request.IsMultiLine;

        if (request.IsDeleted)
        {
            entity.SU_IsDel = true;
        }

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            entity.SU_Password = PasswordHasher.Hash(request.Password.Trim());
        }

        entity.SU_Editor = User.Identity?.Name;
        entity.SU_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();
        await ApplyUserRolesAsync(db, entity.SU_ID, request.RoleIds);

        return ApiResult<SystemUserDto>.Ok(await ToUserDtoAsync(db, entity), "已保存");
    }

    /// <summary>删除用户（软删除；内置 admin 账号拒绝）</summary>
    [HttpDelete("users/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeleteUser(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护用户", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_User>().Where(u => u.SU_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        if (string.Equals(entity.SU_Account, "admin", StringComparison.OrdinalIgnoreCase))
        {
            return ApiResult<ApiEmpty>.Fail("内置管理员账号不可删除");
        }

        entity.SU_IsDel = true;
        entity.SU_Editor = User.Identity?.Name;
        entity.SU_EditTime = DateTime.Now;
        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    /// <summary>清理该账号的登录缓存（T_UserLoginCache.F_Account）</summary>
    [HttpPost("users/{id:int}/clear-login-cache")]
    public async Task<ApiResult<ApiEmpty>> ClearLoginCache(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可清理登录缓存", 403);
        }

        var db = _base.Db;

        var user = await db.Queryable<S_User>().Where(u => u.SU_ID == id).FirstAsync();
        if (user is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        try
        {
            var affected = await db.Ado.ExecuteCommandAsync(
                "DELETE FROM T_UserLoginCache WHERE F_Account = @account",
                new { account = user.SU_Account });
            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已清理 {affected} 条登录缓存");
        }
        catch (Exception ex)
        {
            // 没建缓存表（或旧库结构不同）时不让页面报红，明确说明即可
            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"未执行清理：{ex.Message}");
        }
    }

    /// <summary>整组替换用户的 S_User_Roles</summary>
    private static async Task ApplyUserRolesAsync(SqlSugar.ISqlSugarClient db, int suId, List<int> roleIds)
    {
        await db.Deleteable<S_UserRole>().Where(l => l.SU_ID == suId).ExecuteCommandAsync();

        var ids = roleIds.Distinct().ToList();
        if (ids.Count == 0)
        {
            return;
        }

        await db.Insertable(ids.Select(rid => new S_UserRole { SU_ID = suId, SR_ID = rid }).ToList())
            .ExecuteCommandAsync();
    }

    private static async Task<SystemUserDto> ToUserDtoAsync(SqlSugar.ISqlSugarClient db, S_User u)
    {
        var links = await db.Queryable<S_UserRole>().Where(l => l.SU_ID == u.SU_ID).ToListAsync();
        var roleNames = links.Count == 0
            ? new List<string>()
            : await db.Queryable<S_Role>()
                .Where(r => links.Select(l => l.SR_ID).Contains(r.SR_ID))
                .Select(r => r.SR_Name)
                .ToListAsync();

        return new SystemUserDto
        {
            SuId = u.SU_ID,
            Account = u.SU_Account,
            UserName = u.SU_UserName ?? string.Empty,
            PhoneNo = u.SU_PhoneNo,
            Gender = u.SU_Gender,
            StopPosition = u.SU_StopPosition,
            IsMultiLine = u.SU_IsMulti ?? false,
            IsDeleted = u.SU_IsDel ?? false,
            Roles = string.Join(" / ", roleNames),
            RoleIds = links.Select(l => l.SR_ID).Distinct().ToList(),
            CreateTime = u.SU_CreateTime,
            Creator = u.SU_Creator,
            Editor = u.SU_Editor,
            EditTime = u.SU_EditTime,
        };
    }

    // ============================ 角色 ============================

    [HttpGet("roles")]
    public async Task<ApiResult<List<SystemRoleDto>>> Roles(string? name = null)
    {
        if (!IsAdmin)
        {
            return ApiResult<List<SystemRoleDto>>.Fail("仅管理员可查看角色管理", 403);
        }

        var db = _base.Db;

        var query = db.Queryable<S_Role>();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(r => r.SR_Name.Contains(keyword));
        }

        var roles = await query.OrderBy(r => r.SR_SortNo).ToListAsync();
        var userLinks = await db.Queryable<S_UserRole>().ToListAsync();
        var permissionLinks = await db.Queryable<S_RolePermission>().ToListAsync();

        var items = roles.Select(r => new SystemRoleDto
        {
            RoleId = r.SR_ID,
            Name = r.SR_Name,
            SortNo = r.SR_SortNo,
            UserCount = userLinks.Count(l => l.SR_ID == r.SR_ID),
            PermissionCount = permissionLinks.Count(l => l.SR_ID == r.SR_ID),
            IsDeleted = r.SR_IsDel ?? false,
            Creator = r.SR_Creator,
            CreateTime = r.SR_CreateTime,
            Editor = r.SR_Editor,
            EditTime = r.SR_EditTime,
        }).ToList();

        return ApiResult<List<SystemRoleDto>>.Ok(items);
    }

    /// <summary>新增角色</summary>
    [HttpPost("roles")]
    public async Task<ApiResult<SystemRoleDto>> CreateRole([FromBody] RoleSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemRoleDto>.Fail("仅管理员可维护角色", 403);
        }

        var name = request.Name?.Trim();
        if (string.IsNullOrWhiteSpace(name))
        {
            return ApiResult<SystemRoleDto>.Fail("角色名称不能为空");
        }

        var db = _base.Db;

        var exists = await db.Queryable<S_Role>()
            .Where(r => r.SR_Name == name && (r.SR_IsDel == null || r.SR_IsDel == false))
            .AnyAsync();
        if (exists)
        {
            return ApiResult<SystemRoleDto>.Fail("角色名称已存在");
        }

        var entity = new S_Role
        {
            SR_Name = name,
            SR_SortNo = request.SortNo ?? 0,
            SR_IsDel = false,
            SR_Creator = User.Identity?.Name,
            SR_CreateTime = DateTime.Now,
        };
        entity = await db.Insertable(entity).ExecuteReturnEntityAsync();

        return ApiResult<SystemRoleDto>.Ok(new SystemRoleDto
        {
            RoleId = entity.SR_ID,
            Name = entity.SR_Name,
            SortNo = entity.SR_SortNo,
            IsDeleted = false,
            Creator = entity.SR_Creator,
            CreateTime = entity.SR_CreateTime,
        }, "已新增");
    }

    /// <summary>修改角色</summary>
    [HttpPut("roles/{id:int}")]
    public async Task<ApiResult<SystemRoleDto>> UpdateRole(int id, [FromBody] RoleSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemRoleDto>.Fail("仅管理员可维护角色", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_Role>().Where(r => r.SR_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemRoleDto>.Fail("记录不存在", 404);
        }

        var name = request.Name?.Trim();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var exists = await db.Queryable<S_Role>()
                .Where(r => r.SR_ID != id && r.SR_Name == name && (r.SR_IsDel == null || r.SR_IsDel == false))
                .AnyAsync();
            if (exists)
            {
                return ApiResult<SystemRoleDto>.Fail("角色名称已存在");
            }

            entity.SR_Name = name;
        }

        entity.SR_SortNo = request.SortNo ?? entity.SR_SortNo;
        entity.SR_Editor = User.Identity?.Name;
        entity.SR_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();

        var links = await db.Queryable<S_RolePermission>().Where(l => l.SR_ID == id).ToListAsync();

        return ApiResult<SystemRoleDto>.Ok(new SystemRoleDto
        {
            RoleId = entity.SR_ID,
            Name = entity.SR_Name,
            SortNo = entity.SR_SortNo,
            PermissionCount = links.Count,
            IsDeleted = entity.SR_IsDel ?? false,
            Creator = entity.SR_Creator,
            CreateTime = entity.SR_CreateTime,
            Editor = entity.SR_Editor,
            EditTime = entity.SR_EditTime,
        }, "已保存");
    }

    /// <summary>删除角色（软删除；有用户在用或内置 admin 时拒绝）</summary>
    [HttpDelete("roles/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeleteRole(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护角色", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_Role>().Where(r => r.SR_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        if (string.Equals(entity.SR_Name, "admin", StringComparison.OrdinalIgnoreCase))
        {
            return ApiResult<ApiEmpty>.Fail("内置管理员角色不可删除");
        }

        var used = await db.Queryable<S_UserRole>().Where(l => l.SR_ID == id).AnyAsync();
        if (used)
        {
            return ApiResult<ApiEmpty>.Fail("仍有用户使用该角色，请先调整用户角色");
        }

        entity.SR_IsDel = true;
        entity.SR_Editor = User.Identity?.Name;
        entity.SR_EditTime = DateTime.Now;
        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    /// <summary>读取角色已勾选的功能权限</summary>
    [HttpGet("roles/{id:int}/permissions")]
    public async Task<ApiResult<RolePermissionsDto>> RolePermissions(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<RolePermissionsDto>.Fail("仅管理员可查看角色授权", 403);
        }

        var db = _base.Db;
        var links = await db.Queryable<S_RolePermission>().Where(l => l.SR_ID == id).ToListAsync();

        return ApiResult<RolePermissionsDto>.Ok(new RolePermissionsDto
        {
            RoleId = id,
            PermissionIds = links.Select(l => l.SP_ID).Distinct().ToList(),
        });
    }

    /// <summary>保存角色授权（整组替换 S_Role_Permissions）</summary>
    [HttpPut("roles/{id:int}/permissions")]
    public async Task<ApiResult<ApiEmpty>> SaveRolePermissions(int id, [FromBody] RolePermissionSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护角色授权", 403);
        }

        var db = _base.Db;

        var role = await db.Queryable<S_Role>().Where(r => r.SR_ID == id).FirstAsync();
        if (role is null)
        {
            return ApiResult<ApiEmpty>.Fail("角色不存在", 404);
        }

        var ids = request.PermissionIds.Distinct().ToList();

        await db.Deleteable<S_RolePermission>().Where(l => l.SR_ID == id).ExecuteCommandAsync();

        if (ids.Count > 0)
        {
            var links = ids.Select(pid => new S_RolePermission { SR_ID = id, SP_ID = pid }).ToList();
            await db.Insertable(links).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存授权 {ids.Count} 项");
    }

    // ============================ 功能/菜单权限 ============================

    /// <summary>功能管理列表：按菜单名称模糊查、是否显示已删除、按父节点过滤</summary>
    [HttpGet("permissions")]
    public async Task<ApiResult<List<SystemPermissionDto>>> Permissions(
        [FromQuery] string? name = null,
        [FromQuery] bool showAll = false,
        [FromQuery] int parentId = 0)
    {
        if (!IsAdmin)
        {
            return ApiResult<List<SystemPermissionDto>>.Fail("仅管理员可查看功能管理", 403);
        }

        var db = _base.Db;

        var all = await db.Queryable<S_Permission>().OrderBy(p => p.SP_SortNo).ToListAsync();
        var nameMap = all.ToDictionary(p => p.SP_ID, p => p.SP_Name);

        var query = all.AsEnumerable();

        if (!showAll)
        {
            query = query.Where(p => p.SP_IsDel != true);
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(p => p.SP_Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (parentId > 0)
        {
            query = query.Where(p => p.SP_PID == parentId);
        }
        else
        {
            // 默认只列菜单/功能本身，不把每个节点的子项全平铺出来（点左树再筛）
            query = query.Where(p => p.SP_PID == 0 || p.SP_Type == "菜单");
        }

        var items = query.Select(p => new SystemPermissionDto
        {
            PermissionId = p.SP_ID,
            ParentId = p.SP_PID,
            ParentName = p.SP_PID == 0 ? "根节点" : nameMap.TryGetValue(p.SP_PID, out var parent) ? parent : p.SP_PID.ToString(),
            Name = p.SP_Name,
            Type = p.SP_Type,
            NameSpace = p.SP_NameSpace,
            SortNo = p.SP_SortNo,
            Remark = p.SP_Remark,
            IsDeleted = p.SP_IsDel ?? false,
            Creator = p.SP_Creator,
            CreateTime = p.SP_CreateTime,
            Editor = p.SP_Editor,
            EditTime = p.SP_EditTime,
        }).ToList();

        return ApiResult<List<SystemPermissionDto>>.Ok(items);
    }

    /// <summary>左侧菜单树（SP_Type = 菜单）</summary>
    [HttpGet("permissions/tree")]
    public async Task<ApiResult<List<PermissionNodeDto>>> PermissionTree()
    {
        if (!IsAdmin)
        {
            return ApiResult<List<PermissionNodeDto>>.Fail("仅管理员可查看功能管理", 403);
        }

        var db = _base.Db;

        // 菜单与功能都进树：菜单分组，功能作为叶子（同现场 IPS）
        var menus = await db.Queryable<S_Permission>()
            .Where(p => p.SP_IsDel == null || p.SP_IsDel == false)
            .OrderBy(p => p.SP_SortNo)
            .ToListAsync();

        // 同层先菜单分组、后功能；再按排序号
        var nodes = menus
            .OrderBy(m => string.Equals(m.SP_Type, "功能", StringComparison.Ordinal) ? 1 : 0)
            .ThenBy(m => m.SP_SortNo ?? 0)
            .Select(m => new PermissionNodeDto
        {
            Id = m.SP_ID,
            ParentId = m.SP_PID,
            Name = m.SP_Name,
            Type = m.SP_Type,
            SortNo = m.SP_SortNo,
        }).ToList();

        var lookup = nodes.ToDictionary(n => n.Id);
        var roots = new List<PermissionNodeDto>();

        foreach (var node in nodes)
        {
            if (node.ParentId != 0 && lookup.TryGetValue(node.ParentId, out var parent))
            {
                parent.Children.Add(node);
            }
            else
            {
                roots.Add(node);
            }
        }

        return ApiResult<List<PermissionNodeDto>>.Ok(roots);
    }

    /// <summary>新增菜单功能</summary>
    [HttpPost("permissions")]
    public async Task<ApiResult<SystemPermissionDto>> CreatePermission([FromBody] PermissionSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemPermissionDto>.Fail("仅管理员可维护功能权限", 403);
        }

        if (string.IsNullOrWhiteSpace(request.Name))
        {
            return ApiResult<SystemPermissionDto>.Fail("名称不能为空");
        }

        var db = _base.Db;

        var exists = await db.Queryable<S_Permission>()
            .Where(p => p.SP_Name == request.Name && p.SP_PID == request.ParentId && (p.SP_IsDel == null || p.SP_IsDel == false))
            .AnyAsync();

        if (exists)
        {
            return ApiResult<SystemPermissionDto>.Fail("同级下已存在同名菜单/功能");
        }

        var entity = new S_Permission
        {
            SP_PID = request.ParentId,
            SP_Name = request.Name.Trim(),
            SP_Type = string.IsNullOrWhiteSpace(request.Type) ? "功能" : request.Type.Trim(),
            SP_NameSpace = request.NameSpace,
            SP_IsDel = false,
            SP_SortNo = request.SortNo ?? 0,
            SP_Remark = request.Remark,
            SP_Creator = User.Identity?.Name,
            SP_CreateTime = DateTime.Now,
        };

        entity = await db.Insertable(entity).ExecuteReturnEntityAsync();

        return ApiResult<SystemPermissionDto>.Ok(ToDto(entity, db), "已新增");
    }

    /// <summary>修改菜单功能</summary>
    [HttpPut("permissions/{id:int}")]
    public async Task<ApiResult<SystemPermissionDto>> UpdatePermission(int id, [FromBody] PermissionSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<SystemPermissionDto>.Fail("仅管理员可维护功能权限", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_Permission>().Where(p => p.SP_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemPermissionDto>.Fail("记录不存在，可能已被删除", 404);
        }

        entity.SP_PID = request.ParentId;
        entity.SP_Name = string.IsNullOrWhiteSpace(request.Name) ? entity.SP_Name : request.Name.Trim();
        entity.SP_Type = string.IsNullOrWhiteSpace(request.Type) ? entity.SP_Type : request.Type.Trim();
        entity.SP_NameSpace = request.NameSpace;
        entity.SP_SortNo = request.SortNo ?? entity.SP_SortNo;
        entity.SP_Remark = request.Remark;
        entity.SP_Editor = User.Identity?.Name;
        entity.SP_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<SystemPermissionDto>.Ok(ToDto(entity, db), "已保存");
    }

    /// <summary>删除（软删除，写 SP_IsDel = 1）</summary>
    [HttpDelete("permissions/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeletePermission(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护功能权限", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_Permission>().Where(p => p.SP_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        var hasChildren = await db.Queryable<S_Permission>()
            .Where(p => p.SP_PID == id && (p.SP_IsDel == null || p.SP_IsDel == false))
            .AnyAsync();

        if (hasChildren)
        {
            return ApiResult<ApiEmpty>.Fail("请先删除下级菜单/功能");
        }

        entity.SP_IsDel = true;
        entity.SP_Editor = User.Identity?.Name;
        entity.SP_EditTime = DateTime.Now;
        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    private static SystemPermissionDto ToDto(S_Permission entity, SqlSugar.ISqlSugarClient db)
    {
        var parentName = entity.SP_PID == 0
            ? "根节点"
            : db.Queryable<S_Permission>().Where(p => p.SP_ID == entity.SP_PID).Select(p => p.SP_Name).First() ?? entity.SP_PID.ToString();

        return new SystemPermissionDto
        {
            PermissionId = entity.SP_ID,
            ParentId = entity.SP_PID,
            ParentName = parentName,
            Name = entity.SP_Name,
            Type = entity.SP_Type,
            NameSpace = entity.SP_NameSpace,
            SortNo = entity.SP_SortNo,
            Remark = entity.SP_Remark,
            IsDeleted = entity.SP_IsDel ?? false,
            Creator = entity.SP_Creator,
            CreateTime = entity.SP_CreateTime,
            Editor = entity.SP_Editor,
            EditTime = entity.SP_EditTime,
        };
    }
}
