using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 接纸机张力克重差值表
/// </summary>
[SugarTable("W_QDM_SplicerGramDiff", TableDescription = "接纸机张力克重差值表")]
public class W_QDM_SplicerGramDiff
{
    /// <summary>最小差值</summary>
    [SugarColumn(ColumnName = "WF_MinDiff", IsNullable = true, ColumnDescription = "最小差值")]
    public int? WF_MinDiff { get; set; }

    /// <summary>最大差值</summary>
    [SugarColumn(ColumnName = "WF_MaxDiff", IsNullable = true, ColumnDescription = "最大差值")]
    public int? WF_MaxDiff { get; set; }

    /// <summary>补偿值</summary>
    [SugarColumn(ColumnName = "WF_Offset", IsNullable = true, ColumnDescription = "补偿值")]
    public int? WF_Offset { get; set; }

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