using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 弯翘调平设置表
/// </summary>
[SugarTable("W_IPS_WarpSet", TableDescription = "弯翘调平设置表")]
public class W_IPS_WarpSet
{
    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", ColumnDescription = "WF_Position")]
    public int WF_Position { get; set; }

    /// <summary>WF_ThreeUp1</summary>
    [SugarColumn(ColumnName = "WF_ThreeUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeUp1", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeUp1 { get; set; }

    /// <summary>WF_ThreeUp2</summary>
    [SugarColumn(ColumnName = "WF_ThreeUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeUp2", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeUp2 { get; set; }

    /// <summary>WF_ThreeUp3</summary>
    [SugarColumn(ColumnName = "WF_ThreeUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeUp3", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeUp3 { get; set; }

    /// <summary>WF_ThreeDown1</summary>
    [SugarColumn(ColumnName = "WF_ThreeDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeDown1", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeDown1 { get; set; }

    /// <summary>WF_ThreeDown2</summary>
    [SugarColumn(ColumnName = "WF_ThreeDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeDown2", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeDown2 { get; set; }

    /// <summary>WF_ThreeDown3</summary>
    [SugarColumn(ColumnName = "WF_ThreeDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ThreeDown3", DefaultValue = "NULL::numeric")]
    public decimal? WF_ThreeDown3 { get; set; }

    /// <summary>WF_FourUp1</summary>
    [SugarColumn(ColumnName = "WF_FourUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourUp1", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourUp1 { get; set; }

    /// <summary>WF_FourUp2</summary>
    [SugarColumn(ColumnName = "WF_FourUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourUp2", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourUp2 { get; set; }

    /// <summary>WF_FourUp3</summary>
    [SugarColumn(ColumnName = "WF_FourUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourUp3", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourUp3 { get; set; }

    /// <summary>WF_FourDown1</summary>
    [SugarColumn(ColumnName = "WF_FourDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourDown1", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourDown1 { get; set; }

    /// <summary>WF_FourDown2</summary>
    [SugarColumn(ColumnName = "WF_FourDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourDown2", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourDown2 { get; set; }

    /// <summary>WF_FourDown3</summary>
    [SugarColumn(ColumnName = "WF_FourDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FourDown3", DefaultValue = "NULL::numeric")]
    public decimal? WF_FourDown3 { get; set; }

    /// <summary>WF_FiveUp1</summary>
    [SugarColumn(ColumnName = "WF_FiveUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveUp1", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveUp1 { get; set; }

    /// <summary>WF_FiveUp2</summary>
    [SugarColumn(ColumnName = "WF_FiveUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveUp2", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveUp2 { get; set; }

    /// <summary>WF_FiveUp3</summary>
    [SugarColumn(ColumnName = "WF_FiveUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveUp3", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveUp3 { get; set; }

    /// <summary>WF_FiveDown1</summary>
    [SugarColumn(ColumnName = "WF_FiveDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveDown1", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveDown1 { get; set; }

    /// <summary>WF_FiveDown2</summary>
    [SugarColumn(ColumnName = "WF_FiveDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveDown2", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveDown2 { get; set; }

    /// <summary>WF_FiveDown3</summary>
    [SugarColumn(ColumnName = "WF_FiveDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_FiveDown3", DefaultValue = "NULL::numeric")]
    public decimal? WF_FiveDown3 { get; set; }

    /// <summary>WF_SixUp1</summary>
    [SugarColumn(ColumnName = "WF_SixUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixUp1", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixUp1 { get; set; }

    /// <summary>WF_SixUp2</summary>
    [SugarColumn(ColumnName = "WF_SixUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixUp2", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixUp2 { get; set; }

    /// <summary>WF_SixUp3</summary>
    [SugarColumn(ColumnName = "WF_SixUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixUp3", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixUp3 { get; set; }

    /// <summary>WF_SixDown1</summary>
    [SugarColumn(ColumnName = "WF_SixDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixDown1", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixDown1 { get; set; }

    /// <summary>WF_SixDown2</summary>
    [SugarColumn(ColumnName = "WF_SixDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixDown2", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixDown2 { get; set; }

    /// <summary>WF_SixDown3</summary>
    [SugarColumn(ColumnName = "WF_SixDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SixDown3", DefaultValue = "NULL::numeric")]
    public decimal? WF_SixDown3 { get; set; }

    /// <summary>WF_SevenUp1</summary>
    [SugarColumn(ColumnName = "WF_SevenUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenUp1", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenUp1 { get; set; }

    /// <summary>WF_SevenUp2</summary>
    [SugarColumn(ColumnName = "WF_SevenUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenUp2", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenUp2 { get; set; }

    /// <summary>WF_SevenUp3</summary>
    [SugarColumn(ColumnName = "WF_SevenUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenUp3", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenUp3 { get; set; }

    /// <summary>WF_SevenDown1</summary>
    [SugarColumn(ColumnName = "WF_SevenDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenDown1", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenDown1 { get; set; }

    /// <summary>WF_SevenDown2</summary>
    [SugarColumn(ColumnName = "WF_SevenDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenDown2", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenDown2 { get; set; }

    /// <summary>WF_SevenDown3</summary>
    [SugarColumn(ColumnName = "WF_SevenDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_SevenDown3", DefaultValue = "NULL::numeric")]
    public decimal? WF_SevenDown3 { get; set; }

}