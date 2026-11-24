using Corrugator.Application.Abstractions;
using Corrugator.Application.Exceptions;
using Corrugator.Application.Security;
using Corrugator.Domain.Entities.BaseAuth;
using Corrugator.Shared.Auth;
using System.Security.Cryptography;
using System.Text;

namespace Corrugator.Application.Services;

/// <summary>登录结果（不含 Token，Token 由 API 层签发）</summary>
public class AuthResult
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>主角色（兼容旧字段）：取第一个角色编码，没有则 operator</summary>
    public string Role { get; set; } = "operator";

    public List<string> Roles { get; set; } = new();

    /// <summary>功能权限编码（W_Permissions.WSP_Name）</summary>
    public List<string> Permissions { get; set; } = new();

    /// <summary>W_Users.WSU_IsMulti：是否开通多瓦线切换</summary>
    public bool IsMultiLine { get; set; }
}

public interface IAuthService
{
    Task<AuthResult> LoginAsync(LoginRequest request);

    /// <summary>初始化内置账号（首次启动时调用）</summary>
    Task EnsureSeedAsync();
}

/// <summary>
/// 登录服务：账号统一走 BaseDB 的 W_Users / W_Roles / W_Permissions。
/// BaseDB 已并入 IPS 库时就是同一个库；多瓦线部署时它只存在公共库，各线业务库不再各建一套账号。
/// </summary>
public class AuthService : IAuthService
{
    private readonly IBaseDbAccess _base;

    public AuthService(IBaseDbAccess baseDb)
    {
        _base = baseDb;
    }

    public async Task<AuthResult> LoginAsync(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.UserName) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new BusinessException("账号和密码不能为空");
        }

        var db = _base.Db;

        var user = await db.Queryable<S_User>()
            .Where(u => u.WSU_Account == request.UserName && (u.WSU_IsDel == null || u.WSU_IsDel == false))
            .FirstAsync();

        if (user is null || !VerifyPassword(request.Password, user.WSU_Password))
        {
            throw new UnauthorizedException("账号或密码错误");
        }

        // 角色
        var roleIds = await db.Queryable<S_UserRole>()
            .Where(x => x.WSU_ID == user.WSU_ID)
            .Select(x => x.WSR_ID)
            .ToListAsync();

        var roles = roleIds.Count == 0
            ? new List<S_Role>()
            : await db.Queryable<S_Role>()
                .In(x => x.WSR_ID, roleIds)
                .Where(x => x.WSR_IsDel == null || x.WSR_IsDel == false)
                .ToListAsync();

        // 权限 = 角色权限 + 用户直授权限
        var permIds = new List<int>();
        if (roleIds.Count > 0)
        {
            permIds.AddRange(await db.Queryable<S_RolePermission>()
                .In(x => x.WSR_ID, roleIds)
                .Select(x => x.WSP_ID)
                .ToListAsync());
        }

        permIds.AddRange(await db.Queryable<S_UserPermission>()
            .Where(x => x.WSU_ID == user.WSU_ID)
            .Select(x => x.WSP_ID)
            .ToListAsync());

        var permissions = permIds.Count == 0
            ? new List<string>()
            : await db.Queryable<S_Permission>()
                .In(x => x.WSP_ID, permIds.Distinct().ToList())
                .Where(x => x.WSP_IsDel == null || x.WSP_IsDel == false)
                .Select(x => x.WSP_Name)
                .ToListAsync();

        var roleCodes = roles.Select(r => r.WSR_Name).ToList();

        return new AuthResult
        {
            UserId = user.WSU_ID,
            UserName = user.WSU_Account,
            DisplayName = string.IsNullOrWhiteSpace(user.WSU_UserName) ? user.WSU_Account : user.WSU_UserName!,
            Role = roleCodes.FirstOrDefault() ?? "operator",
            Roles = roleCodes,
            Permissions = permissions,
            IsMultiLine = user.WSU_IsMulti ?? false,
        };
    }

    public async Task EnsureSeedAsync()
    {
        var db = _base.Db;

        // 现场已有的 W_Users / W_Roles / W_Permissions 可能比代码实体短（如 WSU_Password 只有 nvarchar(20)），
        // 写入 PBKDF2 哈希会被 SQL Server 截断报错，先按需扩列再灌种子。
        await EnsureSeedColumnWidthsAsync(db);

        // 菜单树每次启动都补齐（幂等），保证「功能管理」左树有内容
        await EnsureMenusAsync(db);

        var hasUsers = await db.Queryable<S_User>().AnyAsync();
        if (hasUsers)
        {
            return;
        }

        // 角色
        var roleSeeds = new (string Code, string Name, int Sort)[]
        {
            ("admin", "系统管理员", 1),
            ("planner", "生管排程员", 2),
            ("operator", "车间操作工", 3),
        };

        var roleIds = new Dictionary<string, int>();
        foreach (var role in roleSeeds)
        {
            var existing = await db.Queryable<S_Role>().Where(r => r.WSR_Name == role.Code).FirstAsync();
            if (existing is null)
            {
                existing = new S_Role
                {
                    WSR_Name = role.Code,
                    WSR_SortNo = role.Sort,
                    WSR_IsDel = false,
                    WSR_Creator = "超级管理员",
                    WSR_CreateTime = DateTime.Now,
                };
                try
                {
                    existing = await db.Insertable(existing).ExecuteReturnEntityAsync();
                }
                catch (Exception ex)
                {
                    throw new BusinessException(
                        $"写入 W_Roles 失败（角色 {role.Code}，多半是 WSR_Name/WSR_Creator 列宽不足）：{ex.Message}");
                }
            }

            roleIds[role.Code] = existing.WSR_ID;
        }

        // 功能权限
        var permSeeds = new[]
        {
            ("lines:reload", "刷新瓦线配置"),
            ("orders:write", "工单新增/修改/删除"),
            ("params:write", "工艺参数修改"),
            ("alarms:confirm", "告警确认"),
        };

        var permIds = new Dictionary<string, int>();
        foreach (var perm in permSeeds)
        {
            var existing = await db.Queryable<S_Permission>().Where(p => p.WSP_Name == perm.Item1).FirstAsync();
            if (existing is null)
            {
                existing = new S_Permission
                {
                    WSP_PID = 0,
                    WSP_Name = perm.Item1,
                    WSP_Type = "功能",
                    WSP_NameSpace = "api",
                    WSP_IsDel = false,
                    WSP_SortNo = permIds.Count + 1,
                    WSP_Remark = perm.Item2,
                    WSP_Creator = "system",
                    WSP_CreateTime = DateTime.Now,
                };
                existing = await db.Insertable(existing).ExecuteReturnEntityAsync();
            }

            permIds[perm.Item1] = existing.WSP_ID;
        }

        // 角色-权限
        var grants = new Dictionary<string, string[]>
        {
            ["admin"] = new[] { "lines:reload", "orders:write", "params:write", "alarms:confirm" },
            ["planner"] = new[] { "orders:write", "params:write" },
            ["operator"] = new[] { "alarms:confirm" },
        };

        foreach (var grant in grants)
        {
            foreach (var perm in grant.Value)
            {
                await db.Insertable(new S_RolePermission
                {
                    WSR_ID = roleIds[grant.Key],
                    WSP_ID = permIds[perm],
                }).ExecuteCommandAsync();
            }
        }

        // 账号
        var userSeeds = new (string Account, string Name, string Role, bool Multi)[]
        {
            ("admin", "系统管理员", "admin", true),
            ("planner", "生管排程员", "planner", true),
            ("operator", "车间操作工", "operator", false),
        };

        foreach (var seed in userSeeds)
        {
            var user = new S_User
            {
                WSU_Account = seed.Account,
                WSU_UserName = seed.Name,
                WSU_Password = PasswordHasher.Hash("123456"),
                WSU_IsMulti = seed.Multi,
                WSU_IsDel = false,
                WSU_Creator = "system",
                WSU_CreateTime = DateTime.Now,
            };
            try
            {
                user = await db.Insertable(user).ExecuteReturnEntityAsync();
            }
            catch (Exception ex)
            {
                throw new BusinessException(
                    $"写入 W_Users 失败（账号 {seed.Account}，多半是 WSU_Password/WSU_UserName 列宽不足，" +
                    $"PBKDF2 哈希需要 nvarchar(200)）：{ex.Message}");
            }

            await db.Insertable(new S_UserRole
            {
                WSU_ID = user.WSU_ID,
                WSR_ID = roleIds[seed.Role],
            }).ExecuteCommandAsync();
        }
    }

    /// <summary>功能管理左侧菜单树的内置节点（与现场一致），已存在则跳过</summary>
    private async Task EnsureMenusAsync(SqlSugar.ISqlSugarClient db)
    {
        var menus = new (string Name, int Sort)[]
        {
            ("生管控制", 1),
            ("图形化控制", 2),
            ("工单管理", 3),
            ("系统管理", 4),
            ("预警管理", 5),
            ("报表管理", 6),
            ("基础档案", 7),
            ("QDM基础表", 8),
            ("DF系数修改", 9),
            ("SF1系数修改", 10),
            ("SF2系数修改", 11),
            ("SF3系数修改", 12),
            ("DF参数控制开关", 13),
            ("SF1参数控制开关", 14),
            ("SF2参数控制开关", 15),
            ("SF3参数控制开关", 16),
            ("弯翘自动控制开关", 17),
        };

        var existing = await db.Queryable<S_Permission>().Where(p => p.WSP_Type == "菜单").ToListAsync();
        var ids = existing.ToDictionary(p => p.WSP_Name, p => p.WSP_ID);

        foreach (var menu in menus)
        {
            if (ids.ContainsKey(menu.Name))
            {
                continue;
            }

            var entity = new S_Permission
            {
                WSP_PID = 0,
                WSP_Name = menu.Name,
                WSP_Type = "菜单",
                WSP_IsDel = false,
                WSP_SortNo = menu.Sort,
                WSP_Creator = "system",
                WSP_CreateTime = DateTime.Now,
            };
            entity = await db.Insertable(entity).ExecuteReturnEntityAsync();
            ids[menu.Name] = entity.WSP_ID;
        }

        // 示例分组（结构与现场一致，可按需删除）：生管控制 → 生管总控；图形化控制 → 总控右手机 / 总控左手机
        var demoGroups = new (string Parent, string Name, int Sort)[]
        {
            ("生管控制", "生管总控", 1),
            ("图形化控制", "总控右手机", 1),
            ("图形化控制", "总控左手机", 2),
        };

        foreach (var group in demoGroups)
        {
            var parentId = ids.TryGetValue(group.Parent, out var pid) ? pid : 0;
            if (parentId == 0)
            {
                continue;
            }

            var exists = await db.Queryable<S_Permission>()
                .Where(p => p.WSP_PID == parentId && p.WSP_Name == group.Name)
                .AnyAsync();
            if (exists)
            {
                continue;
            }

            var entity = new S_Permission
            {
                WSP_PID = parentId,
                WSP_Name = group.Name,
                WSP_Type = "菜单",
                WSP_IsDel = false,
                WSP_SortNo = group.Sort,
                WSP_Remark = "示例分组，可按需删除",
                WSP_Creator = "system",
                WSP_CreateTime = DateTime.Now,
            };
            entity = await db.Insertable(entity).ExecuteReturnEntityAsync();
            ids[group.Name] = entity.WSP_ID;
        }

        // 系统管理 → 切换班组
        var systemMenuId = ids.TryGetValue("系统管理", out var sid) ? sid : 0;
        if (systemMenuId > 0)
        {
            var hasChild = await db.Queryable<S_Permission>()
                .Where(p => p.WSP_PID == systemMenuId && p.WSP_Name == "切换班组")
                .AnyAsync();

            if (!hasChild)
            {
                await db.Insertable(new S_Permission
                {
                    WSP_PID = systemMenuId,
                    WSP_Name = "切换班组",
                    WSP_Type = "菜单",
                    WSP_IsDel = false,
                    WSP_SortNo = 1,
                    WSP_Creator = "system",
                    WSP_CreateTime = DateTime.Now,
                }).ExecuteCommandAsync();
            }
        }
    }

    /// <summary>
    /// 兼容三种存量密码：pbkdf2（本项目新建）、32 位 MD5（历史 BaseDB）、明文（极早期数据）。
    /// 新账号一律写 PBKDF2。
    /// </summary>
    /// <summary>
    /// 种子数据要写的列宽度要求。现场老库可能更窄（密码列常见 nvarchar(20)），
    /// SQL Server 写超长字符串会直接抛「将截断字符串或二进制数据」。
    /// </summary>
    private static readonly (string Table, string Column, int Length)[] SeedColumnWidths =
    {
        ("W_Users", "WSU_Account", 50),
        ("W_Users", "WSU_Password", 200),
        ("W_Users", "WSU_UserName", 50),
        ("W_Users", "WSU_Gender", 10),
        ("W_Users", "WSU_PhoneNo", 50),
        ("W_Users", "WSU_StopPosition", 50),
        ("W_Users", "WSU_Creator", 20),
        ("W_Users", "WSU_Editor", 20),
        ("W_Roles", "WSR_Name", 50),
        ("W_Roles", "WSR_Creator", 20),
        ("W_Roles", "WSR_Editor", 20),
        ("W_Permissions", "WSP_Name", 50),
        ("W_Permissions", "WSP_Type", 10),
        ("W_Permissions", "WSP_NameSpace", 100),
        ("W_Permissions", "WSP_Remark", 500),
        ("W_Permissions", "WSP_Creator", 20),
        ("W_Permissions", "WSP_Editor", 20),
    };

    /// <summary>检查并加宽种子要写的字符列（只动比代码要求更窄的列，已够宽的不动）</summary>
    private static async Task EnsureSeedColumnWidthsAsync(SqlSugar.ISqlSugarClient db)
    {
        if (db.CurrentConnectionConfig.DbType != SqlSugar.DbType.SqlServer)
        {
            return;
        }

        var meta = db.Ado.GetDataTable(
            "SELECT TABLE_NAME, COLUMN_NAME, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE, DATA_TYPE " +
            "FROM INFORMATION_SCHEMA.COLUMNS " +
            "WHERE TABLE_NAME IN ('W_Users', 'W_Roles', 'W_Permissions')");

        foreach (var row in meta.Rows.Cast<System.Data.DataRow>())
        {
            var table = row["TABLE_NAME"]?.ToString() ?? string.Empty;
            var column = row["COLUMN_NAME"]?.ToString() ?? string.Empty;
            var dataType = row["DATA_TYPE"]?.ToString() ?? string.Empty;
            var nullable = (row["IS_NULLABLE"]?.ToString() ?? "YES").Equals("YES", StringComparison.OrdinalIgnoreCase);

            // 只处理字符型列（nvarchar/varchar/nchar/char）
            if (!dataType.Contains("char", StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var required = SeedColumnWidths
                .Where(x => x.Table == table && x.Column == column)
                .Select(x => x.Length)
                .FirstOrDefault();

            if (required <= 0)
            {
                continue;
            }

            var current = row["CHARACTER_MAXIMUM_LENGTH"] is DBNull or null
                ? -1
                : Convert.ToInt32(row["CHARACTER_MAXIMUM_LENGTH"]);

            if (current < 0 || current >= required)
            {
                continue;
            }

            var sql = $"ALTER TABLE [dbo].[{table}] ALTER COLUMN [{column}] nvarchar({required}) {(nullable ? "NULL" : "NOT NULL")}";
            try
            {
                db.Ado.ExecuteCommand(sql);
                Console.WriteLine($"[SeedFix] {table}.{column} 由 {current} 加宽到 {required}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[SeedFix] {table}.{column} 加宽失败（可手工执行：{sql}）：{ex.Message}");
            }
        }
    }

    private static bool VerifyPassword(string password, string? stored)
    {
        if (string.IsNullOrWhiteSpace(stored))
        {
            return false;
        }

        if (stored.StartsWith("pbkdf2$", StringComparison.OrdinalIgnoreCase))
        {
            return PasswordHasher.Verify(password, stored);
        }

        if (stored.Length == 32 && stored.All(Uri.IsHexDigit))
        {
            var md5 = Convert.ToHexString(MD5.HashData(Encoding.UTF8.GetBytes(password))).ToLowerInvariant();
            return string.Equals(md5, stored.ToLowerInvariant(), StringComparison.Ordinal);
        }

        return string.Equals(stored, password, StringComparison.Ordinal);
    }
}
