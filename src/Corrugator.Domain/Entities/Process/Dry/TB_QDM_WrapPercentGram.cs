using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 包角百分比克重表
/// </summary>
[SugarTable("W_QDM_WrapPercentGram", TableDescription = "包角百分比克重表")]
public class W_QDM_WrapPercentGram
{
    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "WF_Position")]
    public string? WF_Position { get; set; }

    /// <summary>最小包角</summary>
    [SugarColumn(ColumnName = "WF_MinPercent", IsNullable = true, ColumnDescription = "最小包角")]
    public int? WF_MinPercent { get; set; }

    /// <summary>最大包角</summary>
    [SugarColumn(ColumnName = "WF_MaxPercent", IsNullable = true, ColumnDescription = "最大包角")]
    public int? WF_MaxPercent { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? WF_MaxGram { get; set; }

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "WF_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? WF_SortNo { get; set; }

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