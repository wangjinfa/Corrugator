using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_PressRollWidth_MP
/// </summary>
[SugarTable("W_IPS_PressRollWidth_MP", TableDescription = "W_IPS_PressRollWidth_MP")]
public class W_IPS_PressRollWidth_MP
{
    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>WF_Width</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "WF_Width")]
    public int WF_Width { get; set; }

    /// <summary>WF_Flute</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 255, ColumnDescription = "WF_Flute")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>WF_Coef</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_Coef")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_Machine</summary>
    [SugarColumn(ColumnName = "WF_Machine", Length = 255, ColumnDescription = "WF_Machine")]
    public string WF_Machine { get; set; } = default!;

}