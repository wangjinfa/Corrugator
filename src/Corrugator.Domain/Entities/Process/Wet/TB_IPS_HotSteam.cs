using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 三段热板蒸汽设置表
/// </summary>
[SugarTable("TB_IPS_HotSteam", TableDescription = "三段热板蒸汽设置表")]
public class TB_IPS_HotSteam
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 100, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinWeight", ColumnDescription = "最小克重")]
    public int F_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxWeight", ColumnDescription = "最大克重")]
    public int F_MaxWeight { get; set; }

    /// <summary>一段热板值</summary>
    [SugarColumn(ColumnName = "F_Part1", Length = 18, DecimalDigits = 2, ColumnDescription = "一段热板值")]
    public decimal F_Part1 { get; set; }

    /// <summary>二段热板值</summary>
    [SugarColumn(ColumnName = "F_Part2", Length = 18, DecimalDigits = 2, ColumnDescription = "二段热板值")]
    public decimal F_Part2 { get; set; }

    /// <summary>三段热板值</summary>
    [SugarColumn(ColumnName = "F_Part3", Length = 18, DecimalDigits = 2, ColumnDescription = "三段热板值")]
    public decimal F_Part3 { get; set; }

    /// <summary>最小气压</summary>
    [SugarColumn(ColumnName = "F_MinValue", Length = 18, DecimalDigits = 2, ColumnDescription = "最小气压")]
    public decimal F_MinValue { get; set; }

    /// <summary>最大气压</summary>
    [SugarColumn(ColumnName = "F_MaxValue", Length = 18, DecimalDigits = 2, ColumnDescription = "最大气压")]
    public decimal F_MaxValue { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}