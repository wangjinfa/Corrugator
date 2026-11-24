using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// SF糊间隙克重表
/// </summary>
[SugarTable("W_QDM_SFGlueGram", TableDescription = "SF糊间隙克重表")]
public class W_QDM_SFGlueGram
{
    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "WF_Position")]
    public string? WF_Position { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>最小糊间隙</summary>
    [SugarColumn(ColumnName = "WF_MinGlueGap", IsNullable = true, ColumnDescription = "最小糊间隙")]
    public int? WF_MinGlueGap { get; set; }

    /// <summary>最大糊间隙</summary>
    [SugarColumn(ColumnName = "WF_MaxGlueGap", IsNullable = true, ColumnDescription = "最大糊间隙")]
    public int? WF_MaxGlueGap { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? WF_MaxGram { get; set; }

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "WF_FluteFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "楞型系数")]
    public decimal? WF_FluteFactor { get; set; }

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