using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 包角温度克重表
/// </summary>
[SugarTable("TB_QDM_WrapTemperature", TableDescription = "包角温度克重表")]
public class TB_QDM_WrapTemperature
{
    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "F_Position")]
    public string? F_Position { get; set; }

    /// <summary>最小温度</summary>
    [SugarColumn(ColumnName = "F_MinTemperature", IsNullable = true, ColumnDescription = "最小温度")]
    public int? F_MinTemperature { get; set; }

    /// <summary>最大温度</summary>
    [SugarColumn(ColumnName = "F_MaxTemperature", IsNullable = true, ColumnDescription = "最大温度")]
    public int? F_MaxTemperature { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", IsNullable = true, ColumnDescription = "最小克重")]
    public int? F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", IsNullable = true, ColumnDescription = "最大克重")]
    public int? F_MaxGram { get; set; }

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "F_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? F_SortNo { get; set; }

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