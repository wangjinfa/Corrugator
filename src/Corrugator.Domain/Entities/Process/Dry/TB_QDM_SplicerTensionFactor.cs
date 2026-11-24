using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_SplicerTensionFactor
/// </summary>
[SugarTable("W_QDM_SplicerTensionFactor", TableDescription = "W_QDM_SplicerTensionFactor")]
public class W_QDM_SplicerTensionFactor
{
    /// <summary>WF_LS0_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_LS0_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_LS0_TensionFactor")]
    public decimal? WF_LS0_TensionFactor { get; set; }

    /// <summary>WF_MS1_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_MS1_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_MS1_TensionFactor")]
    public decimal? WF_MS1_TensionFactor { get; set; }

    /// <summary>WF_LS1_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_LS1_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_LS1_TensionFactor")]
    public decimal? WF_LS1_TensionFactor { get; set; }

    /// <summary>WF_MS2_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_MS2_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_MS2_TensionFactor")]
    public decimal? WF_MS2_TensionFactor { get; set; }

    /// <summary>WF_LS2_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_LS2_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_LS2_TensionFactor")]
    public decimal? WF_LS2_TensionFactor { get; set; }

    /// <summary>WF_MS3_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_MS3_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_MS3_TensionFactor")]
    public decimal? WF_MS3_TensionFactor { get; set; }

    /// <summary>WF_LS3_TensionFactor</summary>
    [SugarColumn(ColumnName = "WF_LS3_TensionFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_LS3_TensionFactor")]
    public decimal? WF_LS3_TensionFactor { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}