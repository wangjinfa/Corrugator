using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 天桥张力克重表
/// </summary>
[SugarTable("TB_QDM_BridgeTension", TableDescription = "天桥张力克重表")]
public class TB_QDM_BridgeTension
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? F_Position { get; set; }

    /// <summary>最小张力</summary>
    [SugarColumn(ColumnName = "F_MinTension", IsNullable = true, ColumnDescription = "最小张力")]
    public int? F_MinTension { get; set; }

    /// <summary>最大张力</summary>
    [SugarColumn(ColumnName = "F_MaxTension", IsNullable = true, ColumnDescription = "最大张力")]
    public int? F_MaxTension { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? F_MaxGram { get; set; }

    /// <summary>克重系数</summary>
    [SugarColumn(ColumnName = "F_GramFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "克重系数")]
    public decimal? F_GramFactor { get; set; }

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