using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_PressRoll_MP
/// </summary>
[SugarTable("W_IPS_PressRoll_MP", TableDescription = "W_IPS_PressRoll_MP")]
public class W_IPS_PressRoll_MP
{
    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>WF_Machine</summary>
    [SugarColumn(ColumnName = "WF_Machine", Length = 255, ColumnDescription = "WF_Machine")]
    public string WF_Machine { get; set; } = default!;

    /// <summary>WF_Flute</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 255, ColumnDescription = "WF_Flute")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>WF_WgtMin</summary>
    [SugarColumn(ColumnName = "WF_WgtMin", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_WgtMin")]
    public decimal WF_WgtMin { get; set; }

    /// <summary>WF_WgtMax</summary>
    [SugarColumn(ColumnName = "WF_WgtMax", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_WgtMax")]
    public decimal WF_WgtMax { get; set; }

    /// <summary>WF_ValueMin</summary>
    [SugarColumn(ColumnName = "WF_ValueMin", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_ValueMin")]
    public decimal WF_ValueMin { get; set; }

    /// <summary>WF_ValueMax</summary>
    [SugarColumn(ColumnName = "WF_ValueMax", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_ValueMax")]
    public decimal WF_ValueMax { get; set; }

}