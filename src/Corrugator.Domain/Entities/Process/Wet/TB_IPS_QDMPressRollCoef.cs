using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 压力辊QDM系数表
/// </summary>
[SugarTable("W_IPS_QDMPressRollCoef", TableDescription = "压力辊QDM系数表")]
public class W_IPS_QDMPressRollCoef
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>qdm表ID</summary>
    [SugarColumn(ColumnName = "WF_QdmID", ColumnDescription = "qdm表ID")]
    public int WF_QdmID { get; set; }

    /// <summary>SF1系数</summary>
    [SugarColumn(ColumnName = "WF_CoefSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "SF1系数")]
    public decimal WF_CoefSF1 { get; set; }

    /// <summary>SF2系数</summary>
    [SugarColumn(ColumnName = "WF_CoefSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "SF2系数")]
    public decimal WF_CoefSF2 { get; set; }

    /// <summary>SF3系数</summary>
    [SugarColumn(ColumnName = "WF_CoefSF3", Length = 18, DecimalDigits = 2, ColumnDescription = "SF3系数")]
    public decimal WF_CoefSF3 { get; set; }

}