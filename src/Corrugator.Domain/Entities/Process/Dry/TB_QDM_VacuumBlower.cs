using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 真空泵参数设置
/// </summary>
[SugarTable("W_QDM_VacuumBlower", TableDescription = "真空泵参数设置")]
public class W_QDM_VacuumBlower
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

    /// <summary>最低转速比</summary>
    [SugarColumn(ColumnName = "WF_MinSpeedRatio", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最低转速比")]
    public decimal? WF_MinSpeedRatio { get; set; }

    /// <summary>最高转速比</summary>
    [SugarColumn(ColumnName = "WF_MaxSpeedRatio", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最高转速比")]
    public decimal? WF_MaxSpeedRatio { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最大克重")]
    public decimal? WF_MaxGram { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最小克重")]
    public decimal? WF_MinGram { get; set; }

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

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}