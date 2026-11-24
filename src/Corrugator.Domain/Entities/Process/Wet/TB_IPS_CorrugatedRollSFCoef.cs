using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 瓦楞辊机台系数表
/// </summary>
[SugarTable("TB_IPS_CorrugatedRollSFCoef", TableDescription = "瓦楞辊机台系数表")]
public class TB_IPS_CorrugatedRollSFCoef
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>SF1系数</summary>
    [SugarColumn(ColumnName = "F_SF1Coef", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "SF1系数")]
    public decimal? F_SF1Coef { get; set; }

    /// <summary>SF2系数</summary>
    [SugarColumn(ColumnName = "F_SF2Coef", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "SF2系数")]
    public decimal? F_SF2Coef { get; set; }

    /// <summary>SF3系数</summary>
    [SugarColumn(ColumnName = "F_SF3Coef", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "SF3系数")]
    public decimal? F_SF3Coef { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}