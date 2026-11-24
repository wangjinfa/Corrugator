using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 坑机热喷雾设置
/// </summary>
[SugarTable("W_IPS_HotSpraySF", TableDescription = "坑机热喷雾设置")]
public class W_IPS_HotSpraySF
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 50, IsNullable = true, ColumnDescription = "瓦纸代号")]
    public string? WF_PaperCode { get; set; }

    /// <summary>值</summary>
    [SugarColumn(ColumnName = "WF_Value", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "值")]
    public decimal? WF_Value { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}