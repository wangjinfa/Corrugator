using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// TB_Plc_AcceleratorSet
/// </summary>
[SugarTable("TB_Plc_AcceleratorSet", TableDescription = "TB_Plc_AcceleratorSet")]
public class TB_Plc_AcceleratorSet
{
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