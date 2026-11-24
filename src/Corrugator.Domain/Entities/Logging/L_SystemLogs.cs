using SqlSugar;

namespace Corrugator.Domain.Entities.Logging;

/// <summary>
/// 系统日志表
/// </summary>
[SugarTable("L_SystemLogs", TableDescription = "系统日志表")]
public class L_SystemLogs
{
    /// <summary>生成日期</summary>
    [SugarColumn(ColumnName = "LSL_Time", ColumnDescription = "生成日期")]
    public DateTime LSL_Time { get; set; }

    /// <summary>操作用户</summary>
    [SugarColumn(ColumnName = "LSL_UserName", Length = 50, IsNullable = true, ColumnDescription = "操作用户")]
    public string? LSL_UserName { get; set; }

    /// <summary>操作电脑IP</summary>
    [SugarColumn(ColumnName = "LSL_MachineIp", Length = 50, IsNullable = true, ColumnDescription = "操作电脑IP")]
    public string? LSL_MachineIp { get; set; }

    /// <summary>操作电脑名称</summary>
    [SugarColumn(ColumnName = "LSL_MachineName", Length = 50, IsNullable = true, ColumnDescription = "操作电脑名称")]
    public string? LSL_MachineName { get; set; }

    /// <summary>操作软件</summary>
    [SugarColumn(ColumnName = "LSL_SoftwareName", Length = 50, ColumnDescription = "操作软件")]
    public string LSL_SoftwareName { get; set; } = default!;

    /// <summary>软件功能模块</summary>
    [SugarColumn(ColumnName = "LSL_Module", Length = 50, ColumnDescription = "软件功能模块")]
    public string LSL_Module { get; set; } = default!;

    /// <summary>日志信息</summary>
    [SugarColumn(ColumnName = "LSL_Content", ColumnDescription = "日志信息")]
    public string LSL_Content { get; set; } = default!;

    /// <summary>类型(0系统日志，1操作日志)</summary>
    [SugarColumn(ColumnName = "LSL_Type", ColumnDescription = "类型(0系统日志，1操作日志)")]
    public int LSL_Type { get; set; }

    /// <summary>操作时生产订单信息</summary>
    [SugarColumn(ColumnName = "LSL_Order", Length = 200, IsNullable = true, ColumnDescription = "操作时生产订单信息")]
    public string? LSL_Order { get; set; }

    /// <summary>LSL_ID</summary>
    [SugarColumn(ColumnName = "LSL_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "LSL_ID")]
    public int LSL_ID { get; set; }

}