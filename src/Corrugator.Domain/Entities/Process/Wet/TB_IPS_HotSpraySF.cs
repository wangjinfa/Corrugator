using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 坑机热喷雾设置
/// </summary>
[SugarTable("TB_IPS_HotSpraySF", TableDescription = "坑机热喷雾设置")]
public class TB_IPS_HotSpraySF
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "F_PaperCode", Length = 50, IsNullable = true, ColumnDescription = "瓦纸代号")]
    public string? F_PaperCode { get; set; }

    /// <summary>值</summary>
    [SugarColumn(ColumnName = "F_Value", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "值")]
    public decimal? F_Value { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}