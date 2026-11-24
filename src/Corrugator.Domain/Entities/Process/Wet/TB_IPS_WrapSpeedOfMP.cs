using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 车速修正
/// </summary>
[SugarTable("W_IPS_WrapSpeedOfMP", TableDescription = "车速修正")]
public class W_IPS_WrapSpeedOfMP
{
    /// <summary>0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "WF_Flag", ColumnDescription = "0-->面纸；1-->夹层；2-->上层")]
    public int WF_Flag { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "车速")]
    public int WF_Speed { get; set; }

    /// <summary>修正值</summary>
    [SugarColumn(ColumnName = "WF_Value", Length = 18, DecimalDigits = 2, ColumnDescription = "修正值")]
    public decimal WF_Value { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}