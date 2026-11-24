using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 包角克重修正表
/// </summary>
[SugarTable("W_IPS_WrapWeightOfMP", TableDescription = "包角克重修正表")]
public class W_IPS_WrapWeightOfMP
{
    /// <summary>标识 0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "WF_Flag", ColumnDescription = "标识 0-->面纸；1-->夹层；2-->上层")]
    public int WF_Flag { get; set; }

    /// <summary>纸张克重差</summary>
    [SugarColumn(ColumnName = "WF_Weight", ColumnDescription = "纸张克重差")]
    public int WF_Weight { get; set; }

    /// <summary>修正值</summary>
    [SugarColumn(ColumnName = "WF_Value", Length = 18, DecimalDigits = 2, ColumnDescription = "修正值")]
    public decimal WF_Value { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}