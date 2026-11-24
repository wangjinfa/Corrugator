using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// SF糊间隙克重表
/// </summary>
[SugarTable("TB_QDM_SFGlueGram", TableDescription = "SF糊间隙克重表")]
public class TB_QDM_SFGlueGram
{
    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "F_Position")]
    public string? F_Position { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? F_Flute { get; set; }

    /// <summary>最小糊间隙</summary>
    [SugarColumn(ColumnName = "F_MinGlueGap", IsNullable = true, ColumnDescription = "最小糊间隙")]
    public int? F_MinGlueGap { get; set; }

    /// <summary>最大糊间隙</summary>
    [SugarColumn(ColumnName = "F_MaxGlueGap", IsNullable = true, ColumnDescription = "最大糊间隙")]
    public int? F_MaxGlueGap { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? F_MaxGram { get; set; }

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "F_FluteFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "楞型系数")]
    public decimal? F_FluteFactor { get; set; }

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "F_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? F_SortNo { get; set; }

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

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}