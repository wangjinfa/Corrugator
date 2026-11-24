using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷雾车速系数表
/// </summary>
[SugarTable("TB_Plc_SpraySpeedCoef", TableDescription = "PLC喷雾车速系数表")]
public class TB_Plc_SpraySpeedCoef
{
    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "F_Position")]
    public string F_Position { get; set; } = default!;

    /// <summary>F_Speed</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "F_Speed")]
    public int F_Speed { get; set; }

    /// <summary>F_Coef</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "F_Coef")]
    public decimal F_Coef { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}