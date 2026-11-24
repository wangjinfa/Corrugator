using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_PressRollSpeedCoef
/// </summary>
[SugarTable("W_IPS_PressRollSpeedCoef", TableDescription = "W_IPS_PressRollSpeedCoef")]
public class W_IPS_PressRollSpeedCoef
{
    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>WF_Machine</summary>
    [SugarColumn(ColumnName = "WF_Machine", Length = 255, ColumnDescription = "WF_Machine")]
    public string WF_Machine { get; set; } = default!;

    /// <summary>WF_Speed</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "WF_Speed")]
    public int WF_Speed { get; set; }

    /// <summary>WF_Coef</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 4, ColumnDescription = "WF_Coef")]
    public decimal WF_Coef { get; set; }

}