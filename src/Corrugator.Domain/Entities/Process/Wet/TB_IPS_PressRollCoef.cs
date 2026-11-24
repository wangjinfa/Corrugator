using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_PressRollCoef
/// </summary>
[SugarTable("TB_IPS_PressRollCoef", TableDescription = "TB_IPS_PressRollCoef")]
public class TB_IPS_PressRollCoef
{
    /// <summary>F_Flute</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "F_Flute")]
    public string F_Flute { get; set; } = default!;

    /// <summary>F_CoefSF1</summary>
    [SugarColumn(ColumnName = "F_CoefSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "F_CoefSF1")]
    public decimal F_CoefSF1 { get; set; }

    /// <summary>F_CoefSF2</summary>
    [SugarColumn(ColumnName = "F_CoefSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "F_CoefSF2")]
    public decimal F_CoefSF2 { get; set; }

    /// <summary>F_CoefSF3</summary>
    [SugarColumn(ColumnName = "F_CoefSF3", Length = 18, DecimalDigits = 2, ColumnDescription = "F_CoefSF3")]
    public decimal F_CoefSF3 { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}