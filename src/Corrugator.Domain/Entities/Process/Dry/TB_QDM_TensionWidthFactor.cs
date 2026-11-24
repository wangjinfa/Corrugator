using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 张力门幅系数
/// </summary>
[SugarTable("TB_QDM_TensionWidthFactor", TableDescription = "张力门幅系数")]
public class TB_QDM_TensionWidthFactor
{
    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "F_MinWidth", IsNullable = true, ColumnDescription = "最小门幅")]
    public int? F_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", IsNullable = true, ColumnDescription = "最大门幅")]
    public int? F_MaxWidth { get; set; }

    /// <summary>门幅系数</summary>
    [SugarColumn(ColumnName = "F_WidthFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅系数")]
    public decimal? F_WidthFactor { get; set; }

    /// <summary>F_Type</summary>
    [SugarColumn(ColumnName = "F_Type", IsNullable = true, ColumnDescription = "F_Type")]
    public int? F_Type { get; set; }

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