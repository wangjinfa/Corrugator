using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷雾车速系数表
/// </summary>
[SugarTable("W_Plc_SpraySpeedCoef", TableDescription = "PLC喷雾车速系数表")]
public class W_Plc_SpraySpeedCoef
{
    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "WF_Position")]
    public string WF_Position { get; set; } = default!;

    /// <summary>WF_Speed</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "WF_Speed")]
    public int WF_Speed { get; set; }

    /// <summary>WF_Coef</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Coef")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}