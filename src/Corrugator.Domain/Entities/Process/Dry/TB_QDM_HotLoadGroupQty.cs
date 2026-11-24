using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压板组数
/// </summary>
[SugarTable("W_QDM_HotLoadGroupQty", TableDescription = "压板组数")]
public class W_QDM_HotLoadGroupQty
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>起压车速</summary>
    [SugarColumn(ColumnName = "WF_StartLoadSpeed", IsNullable = true, ColumnDescription = "起压车速")]
    public int? WF_StartLoadSpeed { get; set; }

    /// <summary>起压组数</summary>
    [SugarColumn(ColumnName = "WF_StartLoadGroupQty", IsNullable = true, ColumnDescription = "起压组数")]
    public int? WF_StartLoadGroupQty { get; set; }

    /// <summary>最低克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", IsNullable = true, ColumnDescription = "最低克重")]
    public int? WF_MinGram { get; set; }

    /// <summary>最高克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", IsNullable = true, ColumnDescription = "最高克重")]
    public int? WF_MaxGram { get; set; }

    /// <summary>最低克重全压车速</summary>
    [SugarColumn(ColumnName = "WF_MinGramFullLoadSpeed", IsNullable = true, ColumnDescription = "最低克重全压车速")]
    public int? WF_MinGramFullLoadSpeed { get; set; }

    /// <summary>最高克重全压车速</summary>
    [SugarColumn(ColumnName = "WF_MaxGramFullLoadSpeed", IsNullable = true, ColumnDescription = "最高克重全压车速")]
    public int? WF_MaxGramFullLoadSpeed { get; set; }

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

    /// <summary>WF_SortNo</summary>
    [SugarColumn(ColumnName = "WF_SortNo", IsNullable = true, ColumnDescription = "WF_SortNo")]
    public int? WF_SortNo { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}