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
    private const string SettingsType = "W_Sys_Config";

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
            .WhereIF(!showAll, u => !u.WF_IsDelete)
            .OrderBy(u => u.WF_ID)
            .ToListAsync();

        var list = rows.Select(u => new ApiAccountDto
        {
            Id = u.WF_ID,
            Account = u.WF_Account,
            Secret = u.WF_Secret,
            SystemName = u.WF_SystemName,
            IsUse = u.WF_IsUse ?? false,
            IsDeleted = u.WF_IsDelete,
            Creator = u.WF_Creator,
            CreateTime = u.WF_CreateTime,
            Editor = u.WF_Editor,
            EditTime = u.WF_EditTime,
        }).ToList();

        return ApiResult<List<ApiAccountDto>>.Ok(list);
    }

    /// <summary>接口清单（右表）；传 userId 时带出授权状态</summary>
    [HttpGet("apis")]
    public async Task<ApiResult<List<ApiItemDto>>> Apis(long? userId = null, bool showAll = false)
    {
        var rows = await _base.Db.Queryable<S_Api>()
            .WhereIF(!showAll, a => !a.WF_IsDelete)
            .OrderBy(a => a.WF_ID)
            .ToListAsync();

        var authorizedIds = new HashSet<long>();
        if (userId is not null and > 0)
        {
            var links = await _base.Db.Queryable<S_ApiAuthorize>()
                .Where(l => l.WF_ApiUserId == userId && (l.WF_IsUse == null || l.WF_IsUse == true))
                .ToListAsync();
            authorizedIds = links.Select(l => l.WF_ApiId).ToHashSet();
        }

        var list = rows.Select(a => new ApiItemDto
        {
            Id = a.WF_ID,
            Desc = a.WF_Desc,
            Url = a.WF_Url,
            SystemName = a.WF_SystemName,
            IsUse = a.WF_IsUse ?? false,
            IsDeleted = a.WF_IsDelete,
            Authorized = authorizedIds.Contains(a.WF_ID),
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
            .Where(u => u.WF_Account == account && !u.WF_IsDelete).AnyAsync();
        if (exists)
        {
            return ApiResult<ApiAccountDto>.Fail("账号已存在");
        }

        var entity = new S_ApiUser
        {
            WF_Account = account,
            WF_Secret = request.Secret?.Trim(),
            WF_SystemName = request.SystemName?.Trim(),
            WF_IsUse = request.IsUse,
            WF_Creator = User.Identity?.Name,
            WF_CreateTime = DateTime.Now,
        };

        var inserted = await _base.Db.Insertable(entity).ExecuteReturnEntityAsync();
        return ApiResult<ApiAccountDto>.Ok(new ApiAccountDto
        {
            Id = inserted.WF_ID,
            Account = inserted.WF_Account,
            Secret = inserted.WF_Secret,
            SystemName = inserted.WF_SystemName,
            IsUse = inserted.WF_IsUse ?? false,
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

        var entity = await _base.Db.Queryable<S_ApiUser>().FirstAsync(u => u.WF_ID == id);
        if (entity is null)
        {
            return ApiResult<ApiAccountDto>.Fail("记录不存在", 404);
        }

        entity.WF_Account = request.Account?.Trim() ?? entity.WF_Account;
        entity.WF_Secret = request.Secret?.Trim();
        entity.WF_SystemName = request.SystemName?.Trim();
        entity.WF_IsUse = request.IsUse;
        entity.WF_Editor = User.Identity?.Name;
        entity.WF_EditTime = DateTime.Now;

        await _base.Db.Updateable(entity).ExecuteCommandAsync();
        return ApiResult<ApiAccountDto>.Ok(new ApiAccountDto
        {
            Id = entity.WF_ID,
            Account = entity.WF_Account,
            Secret = entity.WF_Secret,
            SystemName = entity.WF_SystemName,
            IsUse = entity.WF_IsUse ?? false,
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

        var account = await _base.Db.Queryable<S_ApiUser>().FirstAsync(u => u.WF_ID == request.UserId);
        if (account is null)
        {
            return ApiResult<ApiEmpty>.Fail("账号不存在", 404);
        }

        var apiIds = request.ApiIds.Distinct().ToList();

        // 先清掉该账号现有授权，再按本次勾选重建
        await _base.Db.Deleteable<S_ApiAuthorize>().Where(l => l.WF_ApiUserId == request.UserId).ExecuteCommandAsync();

        foreach (var apiId in apiIds)
        {
            await _base.Db.Insertable(new S_ApiAuthorize
            {
                WF_ApiUserId = request.UserId,
                WF_ApiId = apiId,
                WF_IsUse = true,
                WF_Editor = User.Identity?.Name,
                WF_EditTime = DateTime.Now,
            }).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已授权 {account.WF_Account} 共 {apiIds.Count} 个接口");
    }

    // ============================ 订单扩展字段设置 ============================

    /// <summary>订单扩展字段：整表读取（固定 18 槽位）</summary>
    [HttpGet("order-ext-fields")]
    public async Task<ApiResult<List<OrderExtFieldDto>>> OrderExtFields()
    {
        var rows = await _base.Db.Queryable<W_Order_ExtField>()
            .OrderBy(r => r.WF_Seq)
            .ToListAsync();

        return ApiResult<List<OrderExtFieldDto>>.Ok(rows.Select(r => new OrderExtFieldDto
        {
            Id = r.WF_ID,
            Seq = r.WF_Seq,
            Code = r.WF_Code,
            JsonCode = r.WF_JsonCode,
            Name = r.WF_Name,
            DataType = r.WF_DataType,
            IsShowInList = r.WF_IsShowInList ?? false,
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

        var existing = await _base.Db.Queryable<W_Order_ExtField>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.WF_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.WF_Code == item.Code);

            if (row is null)
            {
                await _base.Db.Insertable(new W_Order_ExtField
                {
                    WF_Seq = item.Seq,
                    WF_Code = item.Code,
                    WF_JsonCode = item.JsonCode,
                    WF_Name = item.Name,
                    WF_DataType = item.DataType,
                    WF_IsShowInList = item.IsShowInList,
                    WF_Editor = User.Identity?.Name,
                    WF_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.WF_Seq = item.Seq;
            row.WF_Code = item.Code;
            row.WF_JsonCode = item.JsonCode;
            row.WF_Name = item.Name;
            row.WF_DataType = item.DataType;
            row.WF_IsShowInList = item.IsShowInList;
            row.WF_Editor = User.Identity?.Name;
            row.WF_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 个扩展字段");
    }

    // ============================ IPS 部位显示/隐藏 ============================

    /// <summary>IPS 部位显示/隐藏：整表读取</summary>
    [HttpGet("ips-parts")]
    public async Task<ApiResult<List<IpsPartDto>>> IpsParts()
    {
        var rows = await _base.Db.Queryable<W_Ips_PartDisplay>()
            .OrderBy(r => r.WF_SortNo)
            .ToListAsync();

        return ApiResult<List<IpsPartDto>>.Ok(rows.Select(r => new IpsPartDto
        {
            Id = r.WF_ID,
            Code = r.WF_Code,
            Name = r.WF_Name,
            IsShow = r.WF_IsShow ?? true,
            SortNo = r.WF_SortNo ?? 0,
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

        var existing = await _base.Db.Queryable<W_Ips_PartDisplay>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.WF_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.WF_Code == item.Code);

            if (row is null)
            {
                await _base.Db.Insertable(new W_Ips_PartDisplay
                {
                    WF_Code = item.Code,
                    WF_Name = item.Name,
                    WF_IsShow = item.IsShow,
                    WF_SortNo = item.SortNo,
                    WF_Editor = User.Identity?.Name,
                    WF_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.WF_Code = item.Code;
            row.WF_Name = item.Name;
            row.WF_IsShow = item.IsShow;
            row.WF_SortNo = item.SortNo;
            row.WF_Editor = User.Identity?.Name;
            row.WF_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 个部位的显示设置");
    }

    // ============================ 订单颜色设置 ============================

    /// <summary>订单颜色设置：整表读取</summary>
    [HttpGet("order-colors")]
    public async Task<ApiResult<List<OrderColorDto>>> OrderColors()
    {
        var rows = await _base.Db.Queryable<W_Order_ColorSet>()
            .OrderBy(r => r.WF_Priority)
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

        var existing = await _base.Db.Queryable<W_Order_ColorSet>().ToListAsync();

        foreach (var item in request.Items)
        {
            var row = existing.FirstOrDefault(r => r.WF_ID == item.Id)
                      ?? existing.FirstOrDefault(r => r.WF_Condition == item.Condition);

            if (row is null)
            {
                await _base.Db.Insertable(new W_Order_ColorSet
                {
                    WF_Condition = item.Condition,
                    WF_Priority = item.Priority,
                    WF_BackColor = Normalize(item.BackColor),
                    WF_FontColor = Normalize(item.FontColor),
                    WF_IsUse = item.IsUse,
                    WF_Editor = User.Identity?.Name,
                    WF_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
                continue;
            }

            row.WF_Condition = item.Condition;
            row.WF_Priority = item.Priority;
            row.WF_BackColor = Normalize(item.BackColor);
            row.WF_FontColor = Normalize(item.FontColor);
            row.WF_IsUse = item.IsUse;
            row.WF_Editor = User.Identity?.Name;
            row.WF_EditTime = DateTime.Now;
            await _base.Db.Updateable(row).ExecuteCommandAsync();
        }

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已保存 {request.Items.Count} 条订单颜色设置");
    }

    private static string? Normalize(string? color)
        => string.IsNullOrWhiteSpace(color) ? string.Empty : color.Trim();

    private static OrderColorDto ToOrderColorDto(W_Order_ColorSet r) => new()
    {
        Id = r.WF_ID,
        Condition = r.WF_Condition,
        Priority = r.WF_Priority,
        BackColor = r.WF_BackColor,
        FontColor = r.WF_FontColor,
        IsUse = r.WF_IsUse ?? false,
    };

    // ============================ 系统设置 ============================

    /// <summary>系统设置：参数值 + 下拉选项</summary>
    [HttpGet("settings")]
    public async Task<ApiResult<SystemSettingsDto>> Settings()
    {
        var rows = await _base.Db.Queryable<W_Sys_Config>().ToListAsync();
        var map = rows
            .GroupBy(r => r.WF_Key)
            .ToDictionary(g => g.Key, g => g.OrderBy(r => r.WF_ID).Last().WF_Value);

        var dto = new SystemSettingsDto
        {
            UpdateUrl = Get(map, "UpdateUrl", "http://127.0.0.1:7776/BtsClientUpdate.xml")!,
            StartPage = Get(map, "StartPage", "SF1生管")!,
            ShowTaskbar = Get(map, "ShowTaskbar", "True")!.Equals("True", StringComparison.OrdinalIgnoreCase),
            Language = Get(map, "Language", "zh-CN")!,
            ShowGluePosition = Get(map, "ShowGluePosition", "False")!.Equals("True", StringComparison.OrdinalIgnoreCase),
        };

        var menus = await _base.Db.Queryable<S_Permission>()
            .Where(p => p.WSP_Type == "菜单" && p.WSP_PID != 0 && (p.WSP_IsDel == null || p.WSP_IsDel == false))
            .OrderBy(p => p.WSP_SortNo)
            .ToListAsync();

        dto.StartPageOptions = menus.Select(p => p.WSP_Name).Distinct().ToList();
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
            var row = await _base.Db.Queryable<W_Sys_Config>().FirstAsync(r => r.WF_Key == pair.Key);
            if (row is null)
            {
                await _base.Db.Insertable(new W_Sys_Config
                {
                    WF_Key = pair.Key,
                    WF_Value = pair.Value,
                    WF_Desc = "系统设置",
                    WF_Editor = User.Identity?.Name,
                    WF_EditTime = DateTime.Now,
                }).ExecuteCommandAsync();
            }
            else
            {
                row.WF_Value = pair.Value;
                row.WF_Editor = User.Identity?.Name;
                row.WF_EditTime = DateTime.Now;
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
            query = query.Where(u => u.WSU_IsDel == null || u.WSU_IsDel == false);
        }

        if (!string.IsNullOrWhiteSpace(account))
        {
            var keyword = account.Trim();
            query = query.Where(u => u.WSU_Account.Contains(keyword));
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(u => u.WSU_UserName != null && u.WSU_UserName.Contains(keyword));
        }

        var users = await query.OrderBy(u => u.WSU_ID).ToListAsync();
        var links = await db.Queryable<S_UserRole>().ToListAsync();
        var roles = await db.Queryable<S_Role>().ToListAsync();
        var roleNames = roles.ToDictionary(r => r.WSR_ID, r => r.WSR_Name);

        var items = users.Select(u =>
        {
            var userRoles = links
                .Where(l => l.WSU_ID == u.WSU_ID)
                .Select(l => roleNames.TryGetValue(l.WSR_ID, out var name) ? name : l.WSR_ID.ToString())
                .ToList();

            return new SystemUserDto
            {
                SuId = u.WSU_ID,
                Account = u.WSU_Account,
                UserName = u.WSU_UserName ?? string.Empty,
                PhoneNo = u.WSU_PhoneNo,
                Gender = u.WSU_Gender,
                StopPosition = u.WSU_StopPosition,
                IsMultiLine = u.WSU_IsMulti ?? false,
                IsDeleted = u.WSU_IsDel ?? false,
                Roles = string.Join(" / ", userRoles),
                RoleIds = links.Where(l => l.WSU_ID == u.WSU_ID).Select(l => l.WSR_ID).Distinct().ToList(),
                CreateTime = u.WSU_CreateTime,
                Creator = u.WSU_Creator,
                Editor = u.WSU_Editor,
                EditTime = u.WSU_EditTime,
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
            .Where(u => u.WSU_Account == account && (u.WSU_IsDel == null || u.WSU_IsDel == false))
            .AnyAsync();
        if (exists)
        {
            return ApiResult<SystemUserDto>.Fail("账号已存在");
        }

        var entity = new S_User
        {
            WSU_Account = account,
            WSU_Password = PasswordHasher.Hash(request.Password.Trim()),
            WSU_UserName = string.IsNullOrWhiteSpace(request.UserName) ? account : request.UserName.Trim(),
            WSU_PhoneNo = request.PhoneNo,
            WSU_Gender = request.Gender,
            WSU_StopPosition = request.StopPosition,
            WSU_IsMulti = request.IsMultiLine,
            WSU_IsDel = false,
            WSU_Creator = User.Identity?.Name,
            WSU_CreateTime = DateTime.Now,
        };
        entity = await db.Insertable(entity).ExecuteReturnEntityAsync();

        await ApplyUserRolesAsync(db, entity.WSU_ID, request.RoleIds);

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

        var entity = await db.Queryable<S_User>().Where(u => u.WSU_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemUserDto>.Fail("记录不存在", 404);
        }

        var account = request.Account?.Trim();
        if (!string.IsNullOrWhiteSpace(account) && !string.Equals(account, entity.WSU_Account, StringComparison.Ordinal))
        {
            var exists = await db.Queryable<S_User>()
                .Where(u => u.WSU_ID != id && u.WSU_Account == account && (u.WSU_IsDel == null || u.WSU_IsDel == false))
                .AnyAsync();
            if (exists)
            {
                return ApiResult<SystemUserDto>.Fail("账号已存在");
            }

            entity.WSU_Account = account;
        }

        if (!string.IsNullOrWhiteSpace(request.UserName))
        {
            entity.WSU_UserName = request.UserName.Trim();
        }

        entity.WSU_PhoneNo = request.PhoneNo;
        entity.WSU_Gender = request.Gender;
        entity.WSU_StopPosition = request.StopPosition;
        entity.WSU_IsMulti = request.IsMultiLine;

        if (request.IsDeleted)
        {
            entity.WSU_IsDel = true;
        }

        if (!string.IsNullOrWhiteSpace(request.Password))
        {
            entity.WSU_Password = PasswordHasher.Hash(request.Password.Trim());
        }

        entity.WSU_Editor = User.Identity?.Name;
        entity.WSU_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();
        await ApplyUserRolesAsync(db, entity.WSU_ID, request.RoleIds);

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

        var entity = await db.Queryable<S_User>().Where(u => u.WSU_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        if (string.Equals(entity.WSU_Account, "admin", StringComparison.OrdinalIgnoreCase))
        {
            return ApiResult<ApiEmpty>.Fail("内置管理员账号不可删除");
        }

        entity.WSU_IsDel = true;
        entity.WSU_Editor = User.Identity?.Name;
        entity.WSU_EditTime = DateTime.Now;
        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    /// <summary>清理该账号的登录缓存（T_UserLoginCache.F_Account，遗留表列名不改）</summary>
    [HttpPost("users/{id:int}/clear-login-cache")]
    public async Task<ApiResult<ApiEmpty>> ClearLoginCache(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可清理登录缓存", 403);
        }

        var db = _base.Db;

        var user = await db.Queryable<S_User>().Where(u => u.WSU_ID == id).FirstAsync();
        if (user is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        try
        {
            var affected = await db.Ado.ExecuteCommandAsync(
                "DELETE FROM T_UserLoginCache WHERE F_Account = @account",
                new { account = user.WSU_Account });
            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"已清理 {affected} 条登录缓存");
        }
        catch (Exception ex)
        {
            // 没建缓存表（或旧库结构不同）时不让页面报红，明确说明即可
            return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), $"未执行清理：{ex.Message}");
        }
    }

    /// <summary>整组替换用户的 W_User_Roles</summary>
    private static async Task ApplyUserRolesAsync(SqlSugar.ISqlSugarClient db, int suId, List<int> roleIds)
    {
        await db.Deleteable<S_UserRole>().Where(l => l.WSU_ID == suId).ExecuteCommandAsync();

        var ids = roleIds.Distinct().ToList();
        if (ids.Count == 0)
        {
            return;
        }

        await db.Insertable(ids.Select(rid => new S_UserRole { WSU_ID = suId, WSR_ID = rid }).ToList())
            .ExecuteCommandAsync();
    }

    private static async Task<SystemUserDto> ToUserDtoAsync(SqlSugar.ISqlSugarClient db, S_User u)
    {
        var links = await db.Queryable<S_UserRole>().Where(l => l.WSU_ID == u.WSU_ID).ToListAsync();
        var roleNames = links.Count == 0
            ? new List<string>()
            : await db.Queryable<S_Role>()
                .Where(r => links.Select(l => l.WSR_ID).Contains(r.WSR_ID))
                .Select(r => r.WSR_Name)
                .ToListAsync();

        return new SystemUserDto
        {
            SuId = u.WSU_ID,
            Account = u.WSU_Account,
            UserName = u.WSU_UserName ?? string.Empty,
            PhoneNo = u.WSU_PhoneNo,
            Gender = u.WSU_Gender,
            StopPosition = u.WSU_StopPosition,
            IsMultiLine = u.WSU_IsMulti ?? false,
            IsDeleted = u.WSU_IsDel ?? false,
            Roles = string.Join(" / ", roleNames),
            RoleIds = links.Select(l => l.WSR_ID).Distinct().ToList(),
            CreateTime = u.WSU_CreateTime,
            Creator = u.WSU_Creator,
            Editor = u.WSU_Editor,
            EditTime = u.WSU_EditTime,
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
            query = query.Where(r => r.WSR_Name.Contains(keyword));
        }

        var roles = await query.OrderBy(r => r.WSR_SortNo).ToListAsync();
        var userLinks = await db.Queryable<S_UserRole>().ToListAsync();
        var permissionLinks = await db.Queryable<S_RolePermission>().ToListAsync();

        var items = roles.Select(r => new SystemRoleDto
        {
            RoleId = r.WSR_ID,
            Name = r.WSR_Name,
            SortNo = r.WSR_SortNo,
            UserCount = userLinks.Count(l => l.WSR_ID == r.WSR_ID),
            PermissionCount = permissionLinks.Count(l => l.WSR_ID == r.WSR_ID),
            IsDeleted = r.WSR_IsDel ?? false,
            Creator = r.WSR_Creator,
            CreateTime = r.WSR_CreateTime,
            Editor = r.WSR_Editor,
            EditTime = r.WSR_EditTime,
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
            .Where(r => r.WSR_Name == name && (r.WSR_IsDel == null || r.WSR_IsDel == false))
            .AnyAsync();
        if (exists)
        {
            return ApiResult<SystemRoleDto>.Fail("角色名称已存在");
        }

        var entity = new S_Role
        {
            WSR_Name = name,
            WSR_SortNo = request.SortNo ?? 0,
            WSR_IsDel = false,
            WSR_Creator = User.Identity?.Name,
            WSR_CreateTime = DateTime.Now,
        };
        entity = await db.Insertable(entity).ExecuteReturnEntityAsync();

        return ApiResult<SystemRoleDto>.Ok(new SystemRoleDto
        {
            RoleId = entity.WSR_ID,
            Name = entity.WSR_Name,
            SortNo = entity.WSR_SortNo,
            IsDeleted = false,
            Creator = entity.WSR_Creator,
            CreateTime = entity.WSR_CreateTime,
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

        var entity = await db.Queryable<S_Role>().Where(r => r.WSR_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemRoleDto>.Fail("记录不存在", 404);
        }

        var name = request.Name?.Trim();
        if (!string.IsNullOrWhiteSpace(name))
        {
            var exists = await db.Queryable<S_Role>()
                .Where(r => r.WSR_ID != id && r.WSR_Name == name && (r.WSR_IsDel == null || r.WSR_IsDel == false))
                .AnyAsync();
            if (exists)
            {
                return ApiResult<SystemRoleDto>.Fail("角色名称已存在");
            }

            entity.WSR_Name = name;
        }

        entity.WSR_SortNo = request.SortNo ?? entity.WSR_SortNo;
        entity.WSR_Editor = User.Identity?.Name;
        entity.WSR_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();

        var links = await db.Queryable<S_RolePermission>().Where(l => l.WSR_ID == id).ToListAsync();

        return ApiResult<SystemRoleDto>.Ok(new SystemRoleDto
        {
            RoleId = entity.WSR_ID,
            Name = entity.WSR_Name,
            SortNo = entity.WSR_SortNo,
            PermissionCount = links.Count,
            IsDeleted = entity.WSR_IsDel ?? false,
            Creator = entity.WSR_Creator,
            CreateTime = entity.WSR_CreateTime,
            Editor = entity.WSR_Editor,
            EditTime = entity.WSR_EditTime,
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

        var entity = await db.Queryable<S_Role>().Where(r => r.WSR_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        if (string.Equals(entity.WSR_Name, "admin", StringComparison.OrdinalIgnoreCase))
        {
            return ApiResult<ApiEmpty>.Fail("内置管理员角色不可删除");
        }

        var used = await db.Queryable<S_UserRole>().Where(l => l.WSR_ID == id).AnyAsync();
        if (used)
        {
            return ApiResult<ApiEmpty>.Fail("仍有用户使用该角色，请先调整用户角色");
        }

        entity.WSR_IsDel = true;
        entity.WSR_Editor = User.Identity?.Name;
        entity.WSR_EditTime = DateTime.Now;
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
        var links = await db.Queryable<S_RolePermission>().Where(l => l.WSR_ID == id).ToListAsync();

        return ApiResult<RolePermissionsDto>.Ok(new RolePermissionsDto
        {
            RoleId = id,
            PermissionIds = links.Select(l => l.WSP_ID).Distinct().ToList(),
        });
    }

    /// <summary>保存角色授权（整组替换 W_Role_Permissions）</summary>
    [HttpPut("roles/{id:int}/permissions")]
    public async Task<ApiResult<ApiEmpty>> SaveRolePermissions(int id, [FromBody] RolePermissionSaveRequest request)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护角色授权", 403);
        }

        var db = _base.Db;

        var role = await db.Queryable<S_Role>().Where(r => r.WSR_ID == id).FirstAsync();
        if (role is null)
        {
            return ApiResult<ApiEmpty>.Fail("角色不存在", 404);
        }

        var ids = request.PermissionIds.Distinct().ToList();

        await db.Deleteable<S_RolePermission>().Where(l => l.WSR_ID == id).ExecuteCommandAsync();

        if (ids.Count > 0)
        {
            var links = ids.Select(pid => new S_RolePermission { WSR_ID = id, WSP_ID = pid }).ToList();
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

        var all = await db.Queryable<S_Permission>().OrderBy(p => p.WSP_SortNo).ToListAsync();
        var nameMap = all.ToDictionary(p => p.WSP_ID, p => p.WSP_Name);

        var query = all.AsEnumerable();

        if (!showAll)
        {
            query = query.Where(p => p.WSP_IsDel != true);
        }

        if (!string.IsNullOrWhiteSpace(name))
        {
            var keyword = name.Trim();
            query = query.Where(p => p.WSP_Name.Contains(keyword, StringComparison.OrdinalIgnoreCase));
        }

        if (parentId > 0)
        {
            query = query.Where(p => p.WSP_PID == parentId);
        }
        else
        {
            // 默认只列菜单/功能本身，不把每个节点的子项全平铺出来（点左树再筛）
            query = query.Where(p => p.WSP_PID == 0 || p.WSP_Type == "菜单");
        }

        var items = query.Select(p => new SystemPermissionDto
        {
            PermissionId = p.WSP_ID,
            ParentId = p.WSP_PID,
            ParentName = p.WSP_PID == 0 ? "根节点" : nameMap.TryGetValue(p.WSP_PID, out var parent) ? parent : p.WSP_PID.ToString(),
            Name = p.WSP_Name,
            Type = p.WSP_Type,
            NameSpace = p.WSP_NameSpace,
            SortNo = p.WSP_SortNo,
            Remark = p.WSP_Remark,
            IsDeleted = p.WSP_IsDel ?? false,
            Creator = p.WSP_Creator,
            CreateTime = p.WSP_CreateTime,
            Editor = p.WSP_Editor,
            EditTime = p.WSP_EditTime,
        }).ToList();

        return ApiResult<List<SystemPermissionDto>>.Ok(items);
    }

    /// <summary>左侧菜单树（WSP_Type = 菜单）</summary>
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
            .Where(p => p.WSP_IsDel == null || p.WSP_IsDel == false)
            .OrderBy(p => p.WSP_SortNo)
            .ToListAsync();

        // 同层先菜单分组、后功能；再按排序号
        var nodes = menus
            .OrderBy(m => string.Equals(m.WSP_Type, "功能", StringComparison.Ordinal) ? 1 : 0)
            .ThenBy(m => m.WSP_SortNo ?? 0)
            .Select(m => new PermissionNodeDto
        {
            Id = m.WSP_ID,
            ParentId = m.WSP_PID,
            Name = m.WSP_Name,
            Type = m.WSP_Type,
            SortNo = m.WSP_SortNo,
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
            .Where(p => p.WSP_Name == request.Name && p.WSP_PID == request.ParentId && (p.WSP_IsDel == null || p.WSP_IsDel == false))
            .AnyAsync();

        if (exists)
        {
            return ApiResult<SystemPermissionDto>.Fail("同级下已存在同名菜单/功能");
        }

        var entity = new S_Permission
        {
            WSP_PID = request.ParentId,
            WSP_Name = request.Name.Trim(),
            WSP_Type = string.IsNullOrWhiteSpace(request.Type) ? "功能" : request.Type.Trim(),
            WSP_NameSpace = request.NameSpace,
            WSP_IsDel = false,
            WSP_SortNo = request.SortNo ?? 0,
            WSP_Remark = request.Remark,
            WSP_Creator = User.Identity?.Name,
            WSP_CreateTime = DateTime.Now,
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

        var entity = await db.Queryable<S_Permission>().Where(p => p.WSP_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<SystemPermissionDto>.Fail("记录不存在，可能已被删除", 404);
        }

        entity.WSP_PID = request.ParentId;
        entity.WSP_Name = string.IsNullOrWhiteSpace(request.Name) ? entity.WSP_Name : request.Name.Trim();
        entity.WSP_Type = string.IsNullOrWhiteSpace(request.Type) ? entity.WSP_Type : request.Type.Trim();
        entity.WSP_NameSpace = request.NameSpace;
        entity.WSP_SortNo = request.SortNo ?? entity.WSP_SortNo;
        entity.WSP_Remark = request.Remark;
        entity.WSP_Editor = User.Identity?.Name;
        entity.WSP_EditTime = DateTime.Now;

        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<SystemPermissionDto>.Ok(ToDto(entity, db), "已保存");
    }

    /// <summary>删除（软删除，写 WSP_IsDel = 1）</summary>
    [HttpDelete("permissions/{id:int}")]
    public async Task<ApiResult<ApiEmpty>> DeletePermission(int id)
    {
        if (!IsAdmin)
        {
            return ApiResult<ApiEmpty>.Fail("仅管理员可维护功能权限", 403);
        }

        var db = _base.Db;

        var entity = await db.Queryable<S_Permission>().Where(p => p.WSP_ID == id).FirstAsync();
        if (entity is null)
        {
            return ApiResult<ApiEmpty>.Fail("记录不存在", 404);
        }

        var hasChildren = await db.Queryable<S_Permission>()
            .Where(p => p.WSP_PID == id && (p.WSP_IsDel == null || p.WSP_IsDel == false))
            .AnyAsync();

        if (hasChildren)
        {
            return ApiResult<ApiEmpty>.Fail("请先删除下级菜单/功能");
        }

        entity.WSP_IsDel = true;
        entity.WSP_Editor = User.Identity?.Name;
        entity.WSP_EditTime = DateTime.Now;
        await db.Updateable(entity).ExecuteCommandAsync();

        return ApiResult<ApiEmpty>.Ok(new ApiEmpty(), "已删除");
    }

    private static SystemPermissionDto ToDto(S_Permission entity, SqlSugar.ISqlSugarClient db)
    {
        var parentName = entity.WSP_PID == 0
            ? "根节点"
            : db.Queryable<S_Permission>().Where(p => p.WSP_ID == entity.WSP_PID).Select(p => p.WSP_Name).First() ?? entity.WSP_PID.ToString();

        return new SystemPermissionDto
        {
            PermissionId = entity.WSP_ID,
            ParentId = entity.WSP_PID,
            ParentName = parentName,
            Name = entity.WSP_Name,
            Type = entity.WSP_Type,
            NameSpace = entity.WSP_NameSpace,
            SortNo = entity.WSP_SortNo,
            Remark = entity.WSP_Remark,
            IsDeleted = entity.WSP_IsDel ?? false,
            Creator = entity.WSP_Creator,
            CreateTime = entity.WSP_CreateTime,
            Editor = entity.WSP_Editor,
            EditTime = entity.WSP_EditTime,
        };
    }
}
