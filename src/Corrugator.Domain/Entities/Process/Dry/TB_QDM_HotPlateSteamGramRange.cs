using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_HotPlateSteamGramRange
/// </summary>
[SugarTable("TB_QDM_HotPlateSteamGramRange", TableDescription = "TB_QDM_HotPlateSteamGramRange")]
public class TB_QDM_HotPlateSteamGramRange
{
    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? F_MaxGram { get; set; }

    /// <summary>F_SortNo</summary>
    [SugarColumn(ColumnName = "F_SortNo", ColumnDescription = "F_SortNo")]
    public int F_SortNo { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}