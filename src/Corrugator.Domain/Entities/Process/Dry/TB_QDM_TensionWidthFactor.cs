using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 张力门幅系数
/// </summary>
[SugarTable("W_QDM_TensionWidthFactor", TableDescription = "张力门幅系数")]
public class W_QDM_TensionWidthFactor
{
    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "WF_MinWidth", IsNullable = true, ColumnDescription = "最小门幅")]
    public int? WF_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "WF_MaxWidth", IsNullable = true, ColumnDescription = "最大门幅")]
    public int? WF_MaxWidth { get; set; }

    /// <summary>门幅系数</summary>
    [SugarColumn(ColumnName = "WF_WidthFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅系数")]
    public decimal? WF_WidthFactor { get; set; }

    /// <summary>WF_Type</summary>
    [SugarColumn(ColumnName = "WF_Type", IsNullable = true, ColumnDescription = "WF_Type")]
    public int? WF_Type { get; set; }

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