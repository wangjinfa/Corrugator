using SqlSugar;

namespace Corrugator.Domain.Entities.BaseAuth;

// BaseDB 的账号/角色/权限表（合并进 IPS 库后作为公共权限库）。
// 这几张表不属于某条瓦线，登录时始终走 BaseDB 连接，不进各线业务库。

/// <summary>用户表 S_Users</summary>
[SugarTable("S_Users", "用户表（BaseDB）")]
public class S_User
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SU_ID")]
    public int SU_ID { get; set; }

    [SugarColumn(ColumnName = "SU_Account", Length = 50, ColumnDescription = "账号")]
    public string SU_Account { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "SU_Password", Length = 200, IsNullable = true, ColumnDescription = "密码（PBKDF2，兼容历史明文）")]
    public string? SU_Password { get; set; }

    [SugarColumn(ColumnName = "SU_UserName", Length = 50, IsNullable = true, ColumnDescription = "姓名")]
    public string? SU_UserName { get; set; }

    [SugarColumn(ColumnName = "SU_Gender", Length = 10, IsNullable = true)]
    public string? SU_Gender { get; set; }

    [SugarColumn(ColumnName = "SU_PhoneNo", Length = 50, IsNullable = true)]
    public string? SU_PhoneNo { get; set; }

    /// <summary>是否允许多瓦线（现场语义：可切换多条线）</summary>
    [SugarColumn(ColumnName = "SU_IsMulti", IsNullable = true, ColumnDescription = "是否多厂/多线")]
    public bool? SU_IsMulti { get; set; }

    [SugarColumn(ColumnName = "SU_IsDel", IsNullable = true, ColumnDescription = "是否删除")]
    public bool? SU_IsDel { get; set; }

    [SugarColumn(ColumnName = "SU_StopPosition", Length = 50, IsNullable = true)]
    public string? SU_StopPosition { get; set; }

    [SugarColumn(ColumnName = "SU_Creator", Length = 20, IsNullable = true)]
    public string? SU_Creator { get; set; }

    [SugarColumn(ColumnName = "SU_CreateTime", IsNullable = true)]
    public DateTime? SU_CreateTime { get; set; }

    [SugarColumn(ColumnName = "SU_Editor", Length = 20, IsNullable = true)]
    public string? SU_Editor { get; set; }

    [SugarColumn(ColumnName = "SU_EditTime", IsNullable = true)]
    public DateTime? SU_EditTime { get; set; }
}

/// <summary>角色表 S_Roles</summary>
[SugarTable("S_Roles", "角色表（BaseDB）")]
public class S_Role
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SR_ID")]
    public int SR_ID { get; set; }

    [SugarColumn(ColumnName = "SR_Name", Length = 50, ColumnDescription = "角色名/编码")]
    public string SR_Name { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "SR_SortNo", IsNullable = true)]
    public int? SR_SortNo { get; set; }

    [SugarColumn(ColumnName = "SR_IsDel", IsNullable = true)]
    public bool? SR_IsDel { get; set; }

    [SugarColumn(ColumnName = "SR_Creator", Length = 20, IsNullable = true)]
    public string? SR_Creator { get; set; }

    [SugarColumn(ColumnName = "SR_CreateTime", IsNullable = true)]
    public DateTime? SR_CreateTime { get; set; }

    [SugarColumn(ColumnName = "SR_Editor", Length = 20, IsNullable = true)]
    public string? SR_Editor { get; set; }

    [SugarColumn(ColumnName = "SR_EditTime", IsNullable = true)]
    public DateTime? SR_EditTime { get; set; }
}

/// <summary>用户-角色 S_User_Roles</summary>
[SugarTable("S_User_Roles", "用户角色关联（BaseDB）")]
public class S_UserRole
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SUR_ID")]
    public int SUR_ID { get; set; }

    [SugarColumn(ColumnName = "SU_ID", ColumnDescription = "用户ID")]
    public int SU_ID { get; set; }

    [SugarColumn(ColumnName = "SR_ID", ColumnDescription = "角色ID")]
    public int SR_ID { get; set; }
}

/// <summary>权限表 S_Permissions</summary>
[SugarTable("S_Permissions", "菜单功能权限（BaseDB）")]
public class S_Permission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SP_ID")]
    public int SP_ID { get; set; }

    [SugarColumn(ColumnName = "SP_PID", ColumnDescription = "父ID")]
    public int SP_PID { get; set; }

    [SugarColumn(ColumnName = "SP_Name", Length = 50, ColumnDescription = "权限编码/名称")]
    public string SP_Name { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "SP_Type", Length = 10, ColumnDescription = "类型：菜单/功能")]
    public string SP_Type { get; set; } = "功能";

    [SugarColumn(ColumnName = "SP_NameSpace", Length = 100, IsNullable = true, ColumnDescription = "命名空间")]
    public string? SP_NameSpace { get; set; }

    [SugarColumn(ColumnName = "SP_IsDel", IsNullable = true)]
    public bool? SP_IsDel { get; set; }

    [SugarColumn(ColumnName = "SP_SortNo", IsNullable = true)]
    public int? SP_SortNo { get; set; }

    [SugarColumn(ColumnName = "SP_Creator", Length = 20, IsNullable = true)]
    public string? SP_Creator { get; set; }

    [SugarColumn(ColumnName = "SP_CreateTime", IsNullable = true)]
    public DateTime? SP_CreateTime { get; set; }

    [SugarColumn(ColumnName = "SP_Editor", Length = 20, IsNullable = true)]
    public string? SP_Editor { get; set; }

    [SugarColumn(ColumnName = "SP_EditTime", IsNullable = true)]
    public DateTime? SP_EditTime { get; set; }

    [SugarColumn(ColumnName = "SP_Remark", Length = 500, IsNullable = true)]
    public string? SP_Remark { get; set; }
}

/// <summary>角色-权限 S_Role_Permissions</summary>
[SugarTable("S_Role_Permissions", "角色权限关联（BaseDB）")]
public class S_RolePermission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SRP_ID")]
    public int SRP_ID { get; set; }

    [SugarColumn(ColumnName = "SR_ID")]
    public int SR_ID { get; set; }

    [SugarColumn(ColumnName = "SP_ID")]
    public int SP_ID { get; set; }
}

/// <summary>用户-权限 S_User_Permissions（可越过角色单独授权）</summary>
[SugarTable("S_User_Permissions", "用户权限关联（BaseDB）")]
public class S_UserPermission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "SUP_ID")]
    public int SUP_ID { get; set; }

    [SugarColumn(ColumnName = "SU_ID")]
    public int SU_ID { get; set; }

    [SugarColumn(ColumnName = "SP_ID")]
    public int SP_ID { get; set; }
}
