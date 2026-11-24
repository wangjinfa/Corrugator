using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_PressRollWidth_MP
/// </summary>
[SugarTable("TB_IPS_PressRollWidth_MP", TableDescription = "TB_IPS_PressRollWidth_MP")]
public class TB_IPS_PressRollWidth_MP
{
    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>F_Width</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "F_Width")]
    public int F_Width { get; set; }

    /// <summary>F_Flute</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 255, ColumnDescription = "F_Flute")]
    public string F_Flute { get; set; } = default!;

    /// <summary>F_Coef</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 4, ColumnDescription = "F_Coef")]
    public decimal F_Coef { get; set; }

    /// <summary>F_Machine</summary>
    [SugarColumn(ColumnName = "F_Machine", Length = 255, ColumnDescription = "F_Machine")]
    public string F_Machine { get; set; } = default!;

}