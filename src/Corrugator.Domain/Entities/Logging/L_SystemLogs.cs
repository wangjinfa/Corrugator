using SqlSugar;

namespace Corrugator.Domain.Entities.Logging;

/// <summary>
/// 系统日志表
/// </summary>
[SugarTable("W_SystemLogs", TableDescription = "系统日志表")]
public class W_SystemLogs
{
    /// <summary>生成日期</summary>
    [SugarColumn(ColumnName = "WLSL_Time", ColumnDescription = "生成日期")]
    public DateTime WLSL_Time { get; set; }

    /// <summary>操作用户</summary>
    [SugarColumn(ColumnName = "WLSL_UserName", Length = 50, IsNullable = true, ColumnDescription = "操作用户")]
    public string? WLSL_UserName { get; set; }

    /// <summary>操作电脑IP</summary>
    [SugarColumn(ColumnName = "WLSL_MachineIp", Length = 50, IsNullable = true, ColumnDescription = "操作电脑IP")]
    public string? WLSL_MachineIp { get; set; }

    /// <summary>操作电脑名称</summary>
    [SugarColumn(ColumnName = "WLSL_MachineName", Length = 50, IsNullable = true, ColumnDescription = "操作电脑名称")]
    public string? WLSL_MachineName { get; set; }

    /// <summary>操作软件</summary>
    [SugarColumn(ColumnName = "WLSL_SoftwareName", Length = 50, ColumnDescription = "操作软件")]
    public string WLSL_SoftwareName { get; set; } = default!;

    /// <summary>软件功能模块</summary>
    [SugarColumn(ColumnName = "WLSL_Module", Length = 50, ColumnDescription = "软件功能模块")]
    public string WLSL_Module { get; set; } = default!;

    /// <summary>日志信息</summary>
    [SugarColumn(ColumnName = "WLSL_Content", ColumnDescription = "日志信息")]
    public string WLSL_Content { get; set; } = default!;

    /// <summary>类型(0系统日志，1操作日志)</summary>
    [SugarColumn(ColumnName = "WLSL_Type", ColumnDescription = "类型(0系统日志，1操作日志)")]
    public int WLSL_Type { get; set; }

    /// <summary>操作时生产订单信息</summary>
    [SugarColumn(ColumnName = "WLSL_Order", Length = 200, IsNullable = true, ColumnDescription = "操作时生产订单信息")]
    public string? WLSL_Order { get; set; }

    /// <summary>WLSL_ID</summary>
    [SugarColumn(ColumnName = "WLSL_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WLSL_ID")]
    public int WLSL_ID { get; set; }

}