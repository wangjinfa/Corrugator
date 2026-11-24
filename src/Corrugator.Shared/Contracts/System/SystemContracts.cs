namespace Corrugator.Shared.Contracts.System;

/// <summary>用户（W_Users，密码不下发）</summary>
public class SystemUserDto
{
    public int SuId { get; set; }
    public string Account { get; set; } = string.Empty;
    public string UserName { get; set; } = string.Empty;
    public string? PhoneNo { get; set; }
    public string? Gender { get; set; }
    public string? StopPosition { get; set; }
    public bool IsMultiLine { get; set; }
    public bool IsDeleted { get; set; }
    public string Roles { get; set; } = string.Empty;
    /// <summary>列表序号（客户端填充，不参与接口语义）</summary>
    public int RowNo { get; set; }
    /// <summary>角色 ID 列表（编辑弹窗回填勾选用）</summary>
    public List<int> RoleIds { get; set; } = new();
    public DateTime? CreateTime { get; set; }
    public string? Creator { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
}

/// <summary>用户新增/修改</summary>
public class UserSaveRequest
{
    public string Account { get; set; } = string.Empty;
    public string? UserName { get; set; }
    public string? PhoneNo { get; set; }
    /// <summary>密码：新增必填；修改时留空表示不改</summary>
    public string? Password { get; set; }
    public string? Gender { get; set; }
    public string? StopPosition { get; set; }
    public bool IsMultiLine { get; set; }
    /// <summary>是否删除（弹窗里可勾，勾上即软删除）</summary>
    public bool IsDeleted { get; set; }
    public List<int> RoleIds { get; set; } = new();
}

/// <summary>角色（W_Roles）</summary>
public class SystemRoleDto
{
    public int RoleId { get; set; }
    public string Name { get; set; } = string.Empty;
    public int? SortNo { get; set; }
    public int UserCount { get; set; }
    public int PermissionCount { get; set; }
    public bool IsDeleted { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
}

/// <summary>角色新增/修改</summary>
public class RoleSaveRequest
{
    public string Name { get; set; } = string.Empty;
    public int? SortNo { get; set; }
}

/// <summary>角色授权（整组替换）</summary>
public class RolePermissionSaveRequest
{
    public List<int> PermissionIds { get; set; } = new();
}

/// <summary>角色已授权限</summary>
public class RolePermissionsDto
{
    public int RoleId { get; set; }
    public List<int> PermissionIds { get; set; } = new();
}

/// <summary>功能/菜单权限（W_Permissions）</summary>
public class SystemPermissionDto
{
    public int PermissionId { get; set; }
    public int ParentId { get; set; }
    public string ParentName { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? NameSpace { get; set; }
    public int? SortNo { get; set; }
    public string? Remark { get; set; }
    public bool IsDeleted { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }

    /// <summary>客户端勾选位（批量操作预留，不落库）</summary>
    public bool IsSelected { get; set; }
}

/// <summary>菜单树节点（只含 WSP_Type = 菜单）</summary>
public class PermissionNodeDto
{
    public int Id { get; set; }
    public int ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
    /// <summary>菜单 / 功能</summary>
    public string Type { get; set; } = "菜单";
    public int? SortNo { get; set; }
    public List<PermissionNodeDto> Children { get; set; } = new();
}

/// <summary>新增/修改菜单功能</summary>
public class PermissionSaveRequest
{
    public string Name { get; set; } = string.Empty;
    public int ParentId { get; set; }
    public string Type { get; set; } = "功能";
    public string? NameSpace { get; set; }
    public int? SortNo { get; set; }
    public string? Remark { get; set; }
}

/// <summary>系统设置（基础信息 → 系统设置）</summary>
public class SystemSettingsDto
{
    /// <summary>自动更新URL</summary>
    public string UpdateUrl { get; set; } = "http://127.0.0.1:7776/BtsClientUpdate.xml";
    /// <summary>生管控制起始页</summary>
    public string StartPage { get; set; } = "SF1生管";
    /// <summary>是否显示任务栏</summary>
    public bool ShowTaskbar { get; set; } = true;
    /// <summary>语言</summary>
    public string Language { get; set; } = "zh-CN";
    /// <summary>显示糊机部位选择</summary>
    public bool ShowGluePosition { get; set; }
    /// <summary>起始页下拉（来自功能管理菜单）</summary>
    public List<string> StartPageOptions { get; set; } = new();
    /// <summary>语言下拉</summary>
    public List<string> LanguageOptions { get; set; } = new() { "zh-CN", "en-US" };
}

/// <summary>系统设置保存</summary>
public class SystemSettingsSaveRequest
{
    public string UpdateUrl { get; set; } = string.Empty;
    public string? StartPage { get; set; }
    public bool ShowTaskbar { get; set; }
    public string? Language { get; set; }
    public bool ShowGluePosition { get; set; }
}

// ======================= API 授权 =======================

/// <summary>对外接口账号（API授权 → 左表）</summary>
public class ApiAccountDto
{
    public long Id { get; set; }
    public string Account { get; set; } = string.Empty;
    public string? Secret { get; set; }
    public string? SystemName { get; set; }
    public bool IsUse { get; set; }
    public bool IsDeleted { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
}

/// <summary>对外接口（API授权 → 右表）</summary>
public class ApiItemDto
{
    public long Id { get; set; }
    public string? Desc { get; set; }
    public string? Url { get; set; }
    public string? SystemName { get; set; }
    public bool IsUse { get; set; }
    public bool IsDeleted { get; set; }
    /// <summary>当前账号是否已授权（客户端填充/服务端按 userId 计算）</summary>
    public bool Authorized { get; set; }
}

/// <summary>账号账号新增/修改</summary>
public class ApiAccountSaveRequest
{
    public string Account { get; set; } = string.Empty;
    public string? Secret { get; set; }
    public string? SystemName { get; set; }
    public bool IsUse { get; set; } = true;
}

/// <summary>接口新增/修改</summary>
public class ApiItemSaveRequest
{
    public string? Desc { get; set; }
    public string? Url { get; set; }
    public string? SystemName { get; set; }
    public bool IsUse { get; set; } = true;
}

/// <summary>保存某账号的接口授权（整组替换）</summary>
public class ApiAuthorizeRequest
{
    public long UserId { get; set; }
    public List<long> ApiIds { get; set; } = new();
}

/// <summary>订单颜色设置行</summary>
public class OrderColorDto
{
    public long Id { get; set; }
    public string Condition { get; set; } = string.Empty;
    public int Priority { get; set; }
    /// <summary>背景颜色 #RRGGBB</summary>
    public string? BackColor { get; set; }
    /// <summary>字体颜色 #RRGGBB</summary>
    public string? FontColor { get; set; }
    public bool IsUse { get; set; }
}

/// <summary>整表保存订单颜色设置</summary>
public class OrderColorSaveRequest
{
    public List<OrderColorDto> Items { get; set; } = new();
}

/// <summary>IPS 部位显示/隐藏行</summary>
public class IpsPartDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public bool IsShow { get; set; }
    public int SortNo { get; set; }
}

/// <summary>整表保存 IPS 部位显示/隐藏</summary>
public class IpsPartSaveRequest
{
    public List<IpsPartDto> Items { get; set; } = new();
}

/// <summary>订单扩展字段行</summary>
public class OrderExtFieldDto
{
    public long Id { get; set; }
    public int Seq { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? JsonCode { get; set; }
    public string? Name { get; set; }
    public string? DataType { get; set; }
    public bool IsShowInList { get; set; }
}

/// <summary>整表保存订单扩展字段</summary>
public class OrderExtFieldSaveRequest
{
    public List<OrderExtFieldDto> Items { get; set; } = new();
}
