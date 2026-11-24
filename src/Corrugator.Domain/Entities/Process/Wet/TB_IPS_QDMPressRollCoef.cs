using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 压力辊QDM系数表
/// </summary>
[SugarTable("TB_IPS_QDMPressRollCoef", TableDescription = "压力辊QDM系数表")]
public class TB_IPS_QDMPressRollCoef
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>qdm表ID</summary>
    [SugarColumn(ColumnName = "F_QdmID", ColumnDescription = "qdm表ID")]
    public int F_QdmID { get; set; }

    /// <summary>SF1系数</summary>
    [SugarColumn(ColumnName = "F_CoefSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "SF1系数")]
    public decimal F_CoefSF1 { get; set; }

    /// <summary>SF2系数</summary>
    [SugarColumn(ColumnName = "F_CoefSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "SF2系数")]
    public decimal F_CoefSF2 { get; set; }

    /// <summary>SF3系数</summary>
    [SugarColumn(ColumnName = "F_CoefSF3", Length = 18, DecimalDigits = 2, ColumnDescription = "SF3系数")]
    public decimal F_CoefSF3 { get; set; }

}