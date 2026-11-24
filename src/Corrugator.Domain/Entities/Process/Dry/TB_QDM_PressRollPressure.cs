using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压力辊压力
/// </summary>
[SugarTable("W_QDM_PressRollPressure", TableDescription = "压力辊压力")]
public class W_QDM_PressRollPressure
{
    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "WF_MaxWidth", ColumnDescription = "最大门幅")]
    public int WF_MaxWidth { get; set; }

    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "WF_MinWidth", ColumnDescription = "最小门幅")]
    public int WF_MinWidth { get; set; }

    /// <summary>门幅系数</summary>
    [SugarColumn(ColumnName = "WF_WidthFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅系数")]
    public decimal? WF_WidthFactor { get; set; }

    /// <summary>最高压力</summary>
    [SugarColumn(ColumnName = "WF_MaxPressure", IsNullable = true, ColumnDescription = "最高压力")]
    public int? WF_MaxPressure { get; set; }

    /// <summary>最低压力</summary>
    [SugarColumn(ColumnName = "WF_MinPressure", IsNullable = true, ColumnDescription = "最低压力")]
    public int? WF_MinPressure { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最大克重")]
    public decimal? WF_MaxGram { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最小克重")]
    public decimal? WF_MinGram { get; set; }

    /// <summary>驱动测系数</summary>
    [SugarColumn(ColumnName = "WF_DriverFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "驱动测系数")]
    public decimal? WF_DriverFactor { get; set; }

    /// <summary>操作测系数</summary>
    [SugarColumn(ColumnName = "WF_OperationFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "操作测系数")]
    public decimal? WF_OperationFactor { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? WF_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? WF_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}