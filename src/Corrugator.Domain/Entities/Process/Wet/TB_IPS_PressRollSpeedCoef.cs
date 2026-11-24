using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_PressRollSpeedCoef
/// </summary>
[SugarTable("TB_IPS_PressRollSpeedCoef", TableDescription = "TB_IPS_PressRollSpeedCoef")]
public class TB_IPS_PressRollSpeedCoef
{
    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>F_Machine</summary>
    [SugarColumn(ColumnName = "F_Machine", Length = 255, ColumnDescription = "F_Machine")]
    public string F_Machine { get; set; } = default!;

    /// <summary>F_Speed</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "F_Speed")]
    public int F_Speed { get; set; }

    /// <summary>F_Coef</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 4, ColumnDescription = "F_Coef")]
    public decimal F_Coef { get; set; }

}