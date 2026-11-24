using SqlSugar;
using Corrugator.Domain.Common;

namespace Corrugator.Domain.Entities.System;

/// <summary>
/// 系统用户表（新增表，不来自 IPS 数据字典）
/// 演示软删除 + 审计字段 + 仓储层的统一填充
/// </summary>
[SugarTable("W_Sys_Users", TableDescription = "系统用户")]
public class Sys_User : ISoftDelete, IAuditable
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int Id { get; set; }

    [SugarColumn(Length = 50, ColumnDescription = "登录账号")]
    public string UserName { get; set; } = default!;

    [SugarColumn(Length = 200, ColumnDescription = "密码（PBKDF2 加盐哈希）")]
    public string PasswordHash { get; set; } = default!;

    [SugarColumn(Length = 50, ColumnDescription = "显示名")]
    public string DisplayName { get; set; } = default!;

    /// <summary>角色：admin / planner / operator</summary>
    [SugarColumn(Length = 20, ColumnDescription = "角色")]
    public string Role { get; set; } = "operator";

    [SugarColumn(ColumnDescription = "是否启用")]
    public bool IsActive { get; set; } = true;

    [SugarColumn(ColumnDescription = "是否删除")]
    public bool IsDeleted { get; set; }

    [SugarColumn(ColumnDescription = "创建时间")]
    public DateTime CreatedAt { get; set; }

    [SugarColumn(Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? CreatedBy { get; set; }

    [SugarColumn(IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? UpdatedAt { get; set; }

    [SugarColumn(Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? UpdatedBy { get; set; }
}

/// <summary>接口操作日志（新增表），用于记录前端调用轨迹</summary>
[SugarTable("W_Sys_OperationLogs", TableDescription = "接口操作日志")]
public class Sys_OperationLog
{
    [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
    public int Id { get; set; }

    [SugarColumn(Length = 100, IsNullable = true)]
    public string? UserName { get; set; }

    [SugarColumn(Length = 200, IsNullable = true)]
    public string? Path { get; set; }

    [SugarColumn(Length = 10, IsNullable = true)]
    public string? Method { get; set; }

    [SugarColumn(Length = 500, IsNullable = true)]
    public string? Query { get; set; }

    [SugarColumn(ColumnDescription = "耗时毫秒", IsNullable = true)]
    public int? ElapsedMs { get; set; }

    [SugarColumn(ColumnDescription = "是否成功", IsNullable = true)]
    public bool? Success { get; set; }

    [SugarColumn(Length = 500, IsNullable = true)]
    public string? Message { get; set; }

    [SugarColumn(ColumnDescription = "创建时间")]
    public DateTime CreatedAt { get; set; }
}
