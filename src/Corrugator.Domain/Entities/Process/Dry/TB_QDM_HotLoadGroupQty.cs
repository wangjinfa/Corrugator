using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压板组数
/// </summary>
[SugarTable("TB_QDM_HotLoadGroupQty", TableDescription = "压板组数")]
public class TB_QDM_HotLoadGroupQty
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? F_Flute { get; set; }

    /// <summary>起压车速</summary>
    [SugarColumn(ColumnName = "F_StartLoadSpeed", IsNullable = true, ColumnDescription = "起压车速")]
    public int? F_StartLoadSpeed { get; set; }

    /// <summary>起压组数</summary>
    [SugarColumn(ColumnName = "F_StartLoadGroupQty", IsNullable = true, ColumnDescription = "起压组数")]
    public int? F_StartLoadGroupQty { get; set; }

    /// <summary>最低克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", IsNullable = true, ColumnDescription = "最低克重")]
    public int? F_MinGram { get; set; }

    /// <summary>最高克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", IsNullable = true, ColumnDescription = "最高克重")]
    public int? F_MaxGram { get; set; }

    /// <summary>最低克重全压车速</summary>
    [SugarColumn(ColumnName = "F_MinGramFullLoadSpeed", IsNullable = true, ColumnDescription = "最低克重全压车速")]
    public int? F_MinGramFullLoadSpeed { get; set; }

    /// <summary>最高克重全压车速</summary>
    [SugarColumn(ColumnName = "F_MaxGramFullLoadSpeed", IsNullable = true, ColumnDescription = "最高克重全压车速")]
    public int? F_MaxGramFullLoadSpeed { get; set; }

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

    /// <summary>F_SortNo</summary>
    [SugarColumn(ColumnName = "F_SortNo", IsNullable = true, ColumnDescription = "F_SortNo")]
    public int? F_SortNo { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}