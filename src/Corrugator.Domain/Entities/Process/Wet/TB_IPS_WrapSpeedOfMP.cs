using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 车速修正
/// </summary>
[SugarTable("TB_IPS_WrapSpeedOfMP", TableDescription = "车速修正")]
public class TB_IPS_WrapSpeedOfMP
{
    /// <summary>0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "F_Flag", ColumnDescription = "0-->面纸；1-->夹层；2-->上层")]
    public int F_Flag { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "车速")]
    public int F_Speed { get; set; }

    /// <summary>修正值</summary>
    [SugarColumn(ColumnName = "F_Value", Length = 18, DecimalDigits = 2, ColumnDescription = "修正值")]
    public decimal F_Value { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}