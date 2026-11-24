using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_PressRollCoef
/// </summary>
[SugarTable("W_IPS_PressRollCoef", TableDescription = "W_IPS_PressRollCoef")]
public class W_IPS_PressRollCoef
{
    /// <summary>WF_Flute</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "WF_Flute")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>WF_CoefSF1</summary>
    [SugarColumn(ColumnName = "WF_CoefSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CoefSF1")]
    public decimal WF_CoefSF1 { get; set; }

    /// <summary>WF_CoefSF2</summary>
    [SugarColumn(ColumnName = "WF_CoefSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CoefSF2")]
    public decimal WF_CoefSF2 { get; set; }

    /// <summary>WF_CoefSF3</summary>
    [SugarColumn(ColumnName = "WF_CoefSF3", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CoefSF3")]
    public decimal WF_CoefSF3 { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}