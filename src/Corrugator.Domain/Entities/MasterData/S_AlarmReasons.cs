using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警原因
/// </summary>
[SugarTable("S_AlarmReasons", TableDescription = "预警原因")]
public class S_AlarmReasons
{
    /// <summary>原因代码</summary>
    [SugarColumn(ColumnName = "SA_Code", Length = 20, ColumnDescription = "原因代码")]
    public string SA_Code { get; set; } = default!;

    /// <summary>原因名称</summary>
    [SugarColumn(ColumnName = "SA_Title", Length = 50, IsNullable = true, ColumnDescription = "原因名称")]
    public string? SA_Title { get; set; }

    /// <summary>原因内容</summary>
    [SugarColumn(ColumnName = "SA_Content", Length = 100, IsNullable = true, ColumnDescription = "原因内容")]
    public string? SA_Content { get; set; }

    /// <summary>发送次数</summary>
    [SugarColumn(ColumnName = "SA_SendTimes", IsNullable = true, ColumnDescription = "发送次数")]
    public int? SA_SendTimes { get; set; }

    /// <summary>间隔时间（ms）</summary>
    [SugarColumn(ColumnName = "SA_IntervalTime", IsNullable = true, ColumnDescription = "间隔时间（ms）")]
    public int? SA_IntervalTime { get; set; }

    /// <summary>报警部位编码</summary>
    [SugarColumn(ColumnName = "SA_PartCode", Length = 20, IsNullable = true, ColumnDescription = "报警部位编码")]
    public string? SA_PartCode { get; set; }

    /// <summary>SA_ID</summary>
    [SugarColumn(ColumnName = "SA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SA_ID")]
    public int SA_ID { get; set; }

}