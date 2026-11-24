using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压力辊压力
/// </summary>
[SugarTable("TB_QDM_PressRollPressure", TableDescription = "压力辊压力")]
public class TB_QDM_PressRollPressure
{
    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", ColumnDescription = "最大门幅")]
    public int F_MaxWidth { get; set; }

    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "F_MinWidth", ColumnDescription = "最小门幅")]
    public int F_MinWidth { get; set; }

    /// <summary>门幅系数</summary>
    [SugarColumn(ColumnName = "F_WidthFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅系数")]
    public decimal? F_WidthFactor { get; set; }

    /// <summary>最高压力</summary>
    [SugarColumn(ColumnName = "F_MaxPressure", IsNullable = true, ColumnDescription = "最高压力")]
    public int? F_MaxPressure { get; set; }

    /// <summary>最低压力</summary>
    [SugarColumn(ColumnName = "F_MinPressure", IsNullable = true, ColumnDescription = "最低压力")]
    public int? F_MinPressure { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最大克重")]
    public decimal? F_MaxGram { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最小克重")]
    public decimal? F_MinGram { get; set; }

    /// <summary>驱动测系数</summary>
    [SugarColumn(ColumnName = "F_DriverFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "驱动测系数")]
    public decimal? F_DriverFactor { get; set; }

    /// <summary>操作测系数</summary>
    [SugarColumn(ColumnName = "F_OperationFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "操作测系数")]
    public decimal? F_OperationFactor { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? F_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? F_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}