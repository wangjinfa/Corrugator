using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_HotPlateSteamGramRange
/// </summary>
[SugarTable("W_QDM_HotPlateSteamGramRange", TableDescription = "W_QDM_HotPlateSteamGramRange")]
public class W_QDM_HotPlateSteamGramRange
{
    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? WF_MaxGram { get; set; }

    /// <summary>WF_SortNo</summary>
    [SugarColumn(ColumnName = "WF_SortNo", ColumnDescription = "WF_SortNo")]
    public int WF_SortNo { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}