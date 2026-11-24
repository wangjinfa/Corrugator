using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 包角克重修正表
/// </summary>
[SugarTable("TB_IPS_WrapWeightOfMP", TableDescription = "包角克重修正表")]
public class TB_IPS_WrapWeightOfMP
{
    /// <summary>标识 0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "F_Flag", ColumnDescription = "标识 0-->面纸；1-->夹层；2-->上层")]
    public int F_Flag { get; set; }

    /// <summary>纸张克重差</summary>
    [SugarColumn(ColumnName = "F_Weight", ColumnDescription = "纸张克重差")]
    public int F_Weight { get; set; }

    /// <summary>修正值</summary>
    [SugarColumn(ColumnName = "F_Value", Length = 18, DecimalDigits = 2, ColumnDescription = "修正值")]
    public decimal F_Value { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}