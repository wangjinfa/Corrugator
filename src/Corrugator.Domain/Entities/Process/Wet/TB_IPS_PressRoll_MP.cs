using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_PressRoll_MP
/// </summary>
[SugarTable("TB_IPS_PressRoll_MP", TableDescription = "TB_IPS_PressRoll_MP")]
public class TB_IPS_PressRoll_MP
{
    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>F_Machine</summary>
    [SugarColumn(ColumnName = "F_Machine", Length = 255, ColumnDescription = "F_Machine")]
    public string F_Machine { get; set; } = default!;

    /// <summary>F_Flute</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 255, ColumnDescription = "F_Flute")]
    public string F_Flute { get; set; } = default!;

    /// <summary>F_WgtMin</summary>
    [SugarColumn(ColumnName = "F_WgtMin", Length = 18, DecimalDigits = 4, ColumnDescription = "F_WgtMin")]
    public decimal F_WgtMin { get; set; }

    /// <summary>F_WgtMax</summary>
    [SugarColumn(ColumnName = "F_WgtMax", Length = 18, DecimalDigits = 4, ColumnDescription = "F_WgtMax")]
    public decimal F_WgtMax { get; set; }

    /// <summary>F_ValueMin</summary>
    [SugarColumn(ColumnName = "F_ValueMin", Length = 18, DecimalDigits = 4, ColumnDescription = "F_ValueMin")]
    public decimal F_ValueMin { get; set; }

    /// <summary>F_ValueMax</summary>
    [SugarColumn(ColumnName = "F_ValueMax", Length = 18, DecimalDigits = 4, ColumnDescription = "F_ValueMax")]
    public decimal F_ValueMax { get; set; }

}