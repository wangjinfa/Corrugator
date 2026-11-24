using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 瓦楞辊压力设置表
/// </summary>
[SugarTable("W_IPS_CorrugatedRollPaperPress", TableDescription = "瓦楞辊压力设置表")]
public class W_IPS_CorrugatedRollPaperPress
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 50, IsNullable = true, ColumnDescription = "瓦纸代号")]
    public string? WF_PaperCode { get; set; }

    /// <summary>压力值</summary>
    [SugarColumn(ColumnName = "WF_PressValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压力值")]
    public decimal? WF_PressValue { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}