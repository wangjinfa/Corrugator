using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 瓦楞辊压力
/// </summary>
[SugarTable("TB_QDM_CorrugatedRollerPress", TableDescription = "瓦楞辊压力")]
public class TB_QDM_CorrugatedRollerPress
{
    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "F_MinWidth", ColumnDescription = "最小门幅")]
    public int F_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", ColumnDescription = "最大门幅")]
    public int F_MaxWidth { get; set; }

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

    /// <summary>门幅系数</summary>
    [SugarColumn(ColumnName = "F_WidthFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "门幅系数")]
    public decimal F_WidthFactor { get; set; }

    /// <summary>最小压力</summary>
    [SugarColumn(ColumnName = "F_MinPressure", ColumnDescription = "最小压力")]
    public int F_MinPressure { get; set; }

    /// <summary>最大压力</summary>
    [SugarColumn(ColumnName = "F_MaxPressure", ColumnDescription = "最大压力")]
    public int F_MaxPressure { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal F_MaxGram { get; set; }

    /// <summary>驱动侧系数</summary>
    [SugarColumn(ColumnName = "F_DSFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "驱动侧系数")]
    public decimal F_DSFactor { get; set; }

    /// <summary>操作侧系数</summary>
    [SugarColumn(ColumnName = "F_OSFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "操作侧系数")]
    public decimal F_OSFactor { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}