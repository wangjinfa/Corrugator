using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 天桥张力克重表
/// </summary>
[SugarTable("W_QDM_BridgeTension", TableDescription = "天桥张力克重表")]
public class W_QDM_BridgeTension
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? WF_Position { get; set; }

    /// <summary>最小张力</summary>
    [SugarColumn(ColumnName = "WF_MinTension", IsNullable = true, ColumnDescription = "最小张力")]
    public int? WF_MinTension { get; set; }

    /// <summary>最大张力</summary>
    [SugarColumn(ColumnName = "WF_MaxTension", IsNullable = true, ColumnDescription = "最大张力")]
    public int? WF_MaxTension { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? WF_MaxGram { get; set; }

    /// <summary>克重系数</summary>
    [SugarColumn(ColumnName = "WF_GramFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "克重系数")]
    public decimal? WF_GramFactor { get; set; }

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