using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 弯翘调平设置表
/// </summary>
[SugarTable("TB_IPS_WarpSet", TableDescription = "弯翘调平设置表")]
public class TB_IPS_WarpSet
{
    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", ColumnDescription = "F_Position")]
    public int F_Position { get; set; }

    /// <summary>F_ThreeUp1</summary>
    [SugarColumn(ColumnName = "F_ThreeUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeUp1", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeUp1 { get; set; }

    /// <summary>F_ThreeUp2</summary>
    [SugarColumn(ColumnName = "F_ThreeUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeUp2", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeUp2 { get; set; }

    /// <summary>F_ThreeUp3</summary>
    [SugarColumn(ColumnName = "F_ThreeUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeUp3", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeUp3 { get; set; }

    /// <summary>F_ThreeDown1</summary>
    [SugarColumn(ColumnName = "F_ThreeDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeDown1", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeDown1 { get; set; }

    /// <summary>F_ThreeDown2</summary>
    [SugarColumn(ColumnName = "F_ThreeDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeDown2", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeDown2 { get; set; }

    /// <summary>F_ThreeDown3</summary>
    [SugarColumn(ColumnName = "F_ThreeDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ThreeDown3", DefaultValue = "NULL::numeric")]
    public decimal? F_ThreeDown3 { get; set; }

    /// <summary>F_FourUp1</summary>
    [SugarColumn(ColumnName = "F_FourUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourUp1", DefaultValue = "NULL::numeric")]
    public decimal? F_FourUp1 { get; set; }

    /// <summary>F_FourUp2</summary>
    [SugarColumn(ColumnName = "F_FourUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourUp2", DefaultValue = "NULL::numeric")]
    public decimal? F_FourUp2 { get; set; }

    /// <summary>F_FourUp3</summary>
    [SugarColumn(ColumnName = "F_FourUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourUp3", DefaultValue = "NULL::numeric")]
    public decimal? F_FourUp3 { get; set; }

    /// <summary>F_FourDown1</summary>
    [SugarColumn(ColumnName = "F_FourDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourDown1", DefaultValue = "NULL::numeric")]
    public decimal? F_FourDown1 { get; set; }

    /// <summary>F_FourDown2</summary>
    [SugarColumn(ColumnName = "F_FourDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourDown2", DefaultValue = "NULL::numeric")]
    public decimal? F_FourDown2 { get; set; }

    /// <summary>F_FourDown3</summary>
    [SugarColumn(ColumnName = "F_FourDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FourDown3", DefaultValue = "NULL::numeric")]
    public decimal? F_FourDown3 { get; set; }

    /// <summary>F_FiveUp1</summary>
    [SugarColumn(ColumnName = "F_FiveUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveUp1", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveUp1 { get; set; }

    /// <summary>F_FiveUp2</summary>
    [SugarColumn(ColumnName = "F_FiveUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveUp2", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveUp2 { get; set; }

    /// <summary>F_FiveUp3</summary>
    [SugarColumn(ColumnName = "F_FiveUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveUp3", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveUp3 { get; set; }

    /// <summary>F_FiveDown1</summary>
    [SugarColumn(ColumnName = "F_FiveDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveDown1", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveDown1 { get; set; }

    /// <summary>F_FiveDown2</summary>
    [SugarColumn(ColumnName = "F_FiveDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveDown2", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveDown2 { get; set; }

    /// <summary>F_FiveDown3</summary>
    [SugarColumn(ColumnName = "F_FiveDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_FiveDown3", DefaultValue = "NULL::numeric")]
    public decimal? F_FiveDown3 { get; set; }

    /// <summary>F_SixUp1</summary>
    [SugarColumn(ColumnName = "F_SixUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixUp1", DefaultValue = "NULL::numeric")]
    public decimal? F_SixUp1 { get; set; }

    /// <summary>F_SixUp2</summary>
    [SugarColumn(ColumnName = "F_SixUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixUp2", DefaultValue = "NULL::numeric")]
    public decimal? F_SixUp2 { get; set; }

    /// <summary>F_SixUp3</summary>
    [SugarColumn(ColumnName = "F_SixUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixUp3", DefaultValue = "NULL::numeric")]
    public decimal? F_SixUp3 { get; set; }

    /// <summary>F_SixDown1</summary>
    [SugarColumn(ColumnName = "F_SixDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixDown1", DefaultValue = "NULL::numeric")]
    public decimal? F_SixDown1 { get; set; }

    /// <summary>F_SixDown2</summary>
    [SugarColumn(ColumnName = "F_SixDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixDown2", DefaultValue = "NULL::numeric")]
    public decimal? F_SixDown2 { get; set; }

    /// <summary>F_SixDown3</summary>
    [SugarColumn(ColumnName = "F_SixDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SixDown3", DefaultValue = "NULL::numeric")]
    public decimal? F_SixDown3 { get; set; }

    /// <summary>F_SevenUp1</summary>
    [SugarColumn(ColumnName = "F_SevenUp1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenUp1", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenUp1 { get; set; }

    /// <summary>F_SevenUp2</summary>
    [SugarColumn(ColumnName = "F_SevenUp2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenUp2", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenUp2 { get; set; }

    /// <summary>F_SevenUp3</summary>
    [SugarColumn(ColumnName = "F_SevenUp3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenUp3", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenUp3 { get; set; }

    /// <summary>F_SevenDown1</summary>
    [SugarColumn(ColumnName = "F_SevenDown1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenDown1", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenDown1 { get; set; }

    /// <summary>F_SevenDown2</summary>
    [SugarColumn(ColumnName = "F_SevenDown2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenDown2", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenDown2 { get; set; }

    /// <summary>F_SevenDown3</summary>
    [SugarColumn(ColumnName = "F_SevenDown3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_SevenDown3", DefaultValue = "NULL::numeric")]
    public decimal? F_SevenDown3 { get; set; }

}