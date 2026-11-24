using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警原因
/// </summary>
[SugarTable("W_AlarmReasons", TableDescription = "预警原因")]
public class W_AlarmReasons
{
    /// <summary>原因代码</summary>
    [SugarColumn(ColumnName = "WSA_Code", Length = 20, ColumnDescription = "原因代码")]
    public string WSA_Code { get; set; } = default!;

    /// <summary>原因名称</summary>
    [SugarColumn(ColumnName = "WSA_Title", Length = 50, IsNullable = true, ColumnDescription = "原因名称")]
    public string? WSA_Title { get; set; }

    /// <summary>原因内容</summary>
    [SugarColumn(ColumnName = "WSA_Content", Length = 100, IsNullable = true, ColumnDescription = "原因内容")]
    public string? WSA_Content { get; set; }

    /// <summary>发送次数</summary>
    [SugarColumn(ColumnName = "WSA_SendTimes", IsNullable = true, ColumnDescription = "发送次数")]
    public int? WSA_SendTimes { get; set; }

    /// <summary>间隔时间（ms）</summary>
    [SugarColumn(ColumnName = "WSA_IntervalTime", IsNullable = true, ColumnDescription = "间隔时间（ms）")]
    public int? WSA_IntervalTime { get; set; }

    /// <summary>报警部位编码</summary>
    [SugarColumn(ColumnName = "WSA_PartCode", Length = 20, IsNullable = true, ColumnDescription = "报警部位编码")]
    public string? WSA_PartCode { get; set; }

    /// <summary>WSA_ID</summary>
    [SugarColumn(ColumnName = "WSA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSA_ID")]
    public int WSA_ID { get; set; }

}