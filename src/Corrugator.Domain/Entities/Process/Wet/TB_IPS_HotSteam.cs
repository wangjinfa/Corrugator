using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 三段热板蒸汽设置表
/// </summary>
[SugarTable("W_IPS_HotSteam", TableDescription = "三段热板蒸汽设置表")]
public class W_IPS_HotSteam
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 100, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinWeight", ColumnDescription = "最小克重")]
    public int WF_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxWeight", ColumnDescription = "最大克重")]
    public int WF_MaxWeight { get; set; }

    /// <summary>一段热板值</summary>
    [SugarColumn(ColumnName = "WF_Part1", Length = 18, DecimalDigits = 2, ColumnDescription = "一段热板值")]
    public decimal WF_Part1 { get; set; }

    /// <summary>二段热板值</summary>
    [SugarColumn(ColumnName = "WF_Part2", Length = 18, DecimalDigits = 2, ColumnDescription = "二段热板值")]
    public decimal WF_Part2 { get; set; }

    /// <summary>三段热板值</summary>
    [SugarColumn(ColumnName = "WF_Part3", Length = 18, DecimalDigits = 2, ColumnDescription = "三段热板值")]
    public decimal WF_Part3 { get; set; }

    /// <summary>最小气压</summary>
    [SugarColumn(ColumnName = "WF_MinValue", Length = 18, DecimalDigits = 2, ColumnDescription = "最小气压")]
    public decimal WF_MinValue { get; set; }

    /// <summary>最大气压</summary>
    [SugarColumn(ColumnName = "WF_MaxValue", Length = 18, DecimalDigits = 2, ColumnDescription = "最大气压")]
    public decimal WF_MaxValue { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}