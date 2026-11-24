using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 瓦楞辊压力设置表
/// </summary>
[SugarTable("TB_IPS_CorrugatedRollPaperPress", TableDescription = "瓦楞辊压力设置表")]
public class TB_IPS_CorrugatedRollPaperPress
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "F_PaperCode", Length = 50, IsNullable = true, ColumnDescription = "瓦纸代号")]
    public string? F_PaperCode { get; set; }

    /// <summary>压力值</summary>
    [SugarColumn(ColumnName = "F_PressValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压力值")]
    public decimal? F_PressValue { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}