using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 包角楞型系数
/// </summary>
[SugarTable("W_QDM_WrapFlute", TableDescription = "包角楞型系数")]
public class W_QDM_WrapFlute
{
    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "WF_Position")]
    public string? WF_Position { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "系数")]
    public decimal? WF_Factor { get; set; }

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "WF_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? WF_SortNo { get; set; }

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

    /// <summary>WF_Type</summary>
    [SugarColumn(ColumnName = "WF_Type", IsNullable = true, ColumnDescription = "WF_Type")]
    public int? WF_Type { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}