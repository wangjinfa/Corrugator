using SqlSugar;

namespace Corrugator.Domain.Entities.BaseAuth;

// BaseDB 的账号/角色/权限表（合并进 IPS 库后作为公共权限库）。
// 这几张表不属于某条瓦线，登录时始终走 BaseDB 连接，不进各线业务库。

/// <summary>用户表 W_Users</summary>
[SugarTable("W_Users", "用户表（BaseDB）")]
public class S_User
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSU_ID")]
    public int WSU_ID { get; set; }

    [SugarColumn(ColumnName = "WSU_Account", Length = 50, ColumnDescription = "账号")]
    public string WSU_Account { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "WSU_Password", Length = 200, IsNullable = true, ColumnDescription = "密码（PBKDF2，兼容历史明文）")]
    public string? WSU_Password { get; set; }

    [SugarColumn(ColumnName = "WSU_UserName", Length = 50, IsNullable = true, ColumnDescription = "姓名")]
    public string? WSU_UserName { get; set; }

    [SugarColumn(ColumnName = "WSU_Gender", Length = 10, IsNullable = true)]
    public string? WSU_Gender { get; set; }

    [SugarColumn(ColumnName = "WSU_PhoneNo", Length = 50, IsNullable = true)]
    public string? WSU_PhoneNo { get; set; }

    /// <summary>是否允许多瓦线（现场语义：可切换多条线）</summary>
    [SugarColumn(ColumnName = "WSU_IsMulti", IsNullable = true, ColumnDescription = "是否多厂/多线")]
    public bool? WSU_IsMulti { get; set; }

    [SugarColumn(ColumnName = "WSU_IsDel", IsNullable = true, ColumnDescription = "是否删除")]
    public bool? WSU_IsDel { get; set; }

    [SugarColumn(ColumnName = "WSU_StopPosition", Length = 50, IsNullable = true)]
    public string? WSU_StopPosition { get; set; }

    [SugarColumn(ColumnName = "WSU_Creator", Length = 20, IsNullable = true)]
    public string? WSU_Creator { get; set; }

    [SugarColumn(ColumnName = "WSU_CreateTime", IsNullable = true)]
    public DateTime? WSU_CreateTime { get; set; }

    [SugarColumn(ColumnName = "WSU_Editor", Length = 20, IsNullable = true)]
    public string? WSU_Editor { get; set; }

    [SugarColumn(ColumnName = "WSU_EditTime", IsNullable = true)]
    public DateTime? WSU_EditTime { get; set; }
}

/// <summary>角色表 W_Roles</summary>
[SugarTable("W_Roles", "角色表（BaseDB）")]
public class S_Role
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSR_ID")]
    public int WSR_ID { get; set; }

    [SugarColumn(ColumnName = "WSR_Name", Length = 50, ColumnDescription = "角色名/编码")]
    public string WSR_Name { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "WSR_SortNo", IsNullable = true)]
    public int? WSR_SortNo { get; set; }

    [SugarColumn(ColumnName = "WSR_IsDel", IsNullable = true)]
    public bool? WSR_IsDel { get; set; }

    [SugarColumn(ColumnName = "WSR_Creator", Length = 20, IsNullable = true)]
    public string? WSR_Creator { get; set; }

    [SugarColumn(ColumnName = "WSR_CreateTime", IsNullable = true)]
    public DateTime? WSR_CreateTime { get; set; }

    [SugarColumn(ColumnName = "WSR_Editor", Length = 20, IsNullable = true)]
    public string? WSR_Editor { get; set; }

    [SugarColumn(ColumnName = "WSR_EditTime", IsNullable = true)]
    public DateTime? WSR_EditTime { get; set; }
}

/// <summary>用户-角色 W_User_Roles</summary>
[SugarTable("W_User_Roles", "用户角色关联（BaseDB）")]
public class S_UserRole
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSUR_ID")]
    public int WSUR_ID { get; set; }

    [SugarColumn(ColumnName = "WSU_ID", ColumnDescription = "用户ID")]
    public int WSU_ID { get; set; }

    [SugarColumn(ColumnName = "WSR_ID", ColumnDescription = "角色ID")]
    public int WSR_ID { get; set; }
}

/// <summary>权限表 W_Permissions</summary>
[SugarTable("W_Permissions", "菜单功能权限（BaseDB）")]
public class S_Permission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSP_ID")]
    public int WSP_ID { get; set; }

    [SugarColumn(ColumnName = "WSP_PID", ColumnDescription = "父ID")]
    public int WSP_PID { get; set; }

    [SugarColumn(ColumnName = "WSP_Name", Length = 50, ColumnDescription = "权限编码/名称")]
    public string WSP_Name { get; set; } = string.Empty;

    [SugarColumn(ColumnName = "WSP_Type", Length = 10, ColumnDescription = "类型：菜单/功能")]
    public string WSP_Type { get; set; } = "功能";

    [SugarColumn(ColumnName = "WSP_NameSpace", Length = 100, IsNullable = true, ColumnDescription = "命名空间")]
    public string? WSP_NameSpace { get; set; }

    [SugarColumn(ColumnName = "WSP_IsDel", IsNullable = true)]
    public bool? WSP_IsDel { get; set; }

    [SugarColumn(ColumnName = "WSP_SortNo", IsNullable = true)]
    public int? WSP_SortNo { get; set; }

    [SugarColumn(ColumnName = "WSP_Creator", Length = 20, IsNullable = true)]
    public string? WSP_Creator { get; set; }

    [SugarColumn(ColumnName = "WSP_CreateTime", IsNullable = true)]
    public DateTime? WSP_CreateTime { get; set; }

    [SugarColumn(ColumnName = "WSP_Editor", Length = 20, IsNullable = true)]
    public string? WSP_Editor { get; set; }

    [SugarColumn(ColumnName = "WSP_EditTime", IsNullable = true)]
    public DateTime? WSP_EditTime { get; set; }

    [SugarColumn(ColumnName = "WSP_Remark", Length = 500, IsNullable = true)]
    public string? WSP_Remark { get; set; }
}

/// <summary>角色-权限 W_Role_Permissions</summary>
[SugarTable("W_Role_Permissions", "角色权限关联（BaseDB）")]
public class S_RolePermission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSRP_ID")]
    public int WSRP_ID { get; set; }

    [SugarColumn(ColumnName = "WSR_ID")]
    public int WSR_ID { get; set; }

    [SugarColumn(ColumnName = "WSP_ID")]
    public int WSP_ID { get; set; }
}

/// <summary>用户-权限 W_User_Permissions（可越过角色单独授权）</summary>
[SugarTable("W_User_Permissions", "用户权限关联（BaseDB）")]
public class S_UserPermission
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnName = "WSUP_ID")]
    public int WSUP_ID { get; set; }

    [SugarColumn(ColumnName = "WSU_ID")]
    public int WSU_ID { get; set; }

    [SugarColumn(ColumnName = "WSP_ID")]
    public int WSP_ID { get; set; }
}
