using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_SplicerTensionFactor
/// </summary>
[SugarTable("TB_QDM_SplicerTensionFactor", TableDescription = "TB_QDM_SplicerTensionFactor")]
public class TB_QDM_SplicerTensionFactor
{
    /// <summary>F_LS0_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_LS0_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_LS0_TensionFactor")]
    public decimal? F_LS0_TensionFactor { get; set; }

    /// <summary>F_MS1_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_MS1_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_MS1_TensionFactor")]
    public decimal? F_MS1_TensionFactor { get; set; }

    /// <summary>F_LS1_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_LS1_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_LS1_TensionFactor")]
    public decimal? F_LS1_TensionFactor { get; set; }

    /// <summary>F_MS2_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_MS2_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_MS2_TensionFactor")]
    public decimal? F_MS2_TensionFactor { get; set; }

    /// <summary>F_LS2_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_LS2_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_LS2_TensionFactor")]
    public decimal? F_LS2_TensionFactor { get; set; }

    /// <summary>F_MS3_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_MS3_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_MS3_TensionFactor")]
    public decimal? F_MS3_TensionFactor { get; set; }

    /// <summary>F_LS3_TensionFactor</summary>
    [SugarColumn(ColumnName = "F_LS3_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_LS3_TensionFactor")]
    public decimal? F_LS3_TensionFactor { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}