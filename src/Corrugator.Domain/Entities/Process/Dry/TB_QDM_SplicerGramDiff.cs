using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 接纸机张力克重差值表
/// </summary>
[SugarTable("TB_QDM_SplicerGramDiff", TableDescription = "接纸机张力克重差值表")]
public class TB_QDM_SplicerGramDiff
{
    /// <summary>最小差值</summary>
    [SugarColumn(ColumnName = "F_MinDiff", IsNullable = true, ColumnDescription = "最小差值")]
    public int? F_MinDiff { get; set; }

    /// <summary>最大差值</summary>
    [SugarColumn(ColumnName = "F_MaxDiff", IsNullable = true, ColumnDescription = "最大差值")]
    public int? F_MaxDiff { get; set; }

    /// <summary>补偿值</summary>
    [SugarColumn(ColumnName = "F_Offset", IsNullable = true, ColumnDescription = "补偿值")]
    public int? F_Offset { get; set; }

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