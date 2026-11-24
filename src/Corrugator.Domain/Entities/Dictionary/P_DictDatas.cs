using SqlSugar;

namespace Corrugator.Domain.Entities.Dictionary;

/// <summary>
/// 数据字典明细表
/// </summary>
[SugarTable("W_DictDatas", TableDescription = "数据字典明细表")]
public class W_DictDatas
{
    /// <summary>类型ID</summary>
    [SugarColumn(ColumnName = "WPD_TypeID", ColumnDescription = "类型ID")]
    public int WPD_TypeID { get; set; }

    /// <summary>属性</summary>
    [SugarColumn(ColumnName = "WPD_Property", Length = 50, IsNullable = true, ColumnDescription = "属性")]
    public string? WPD_Property { get; set; }

    /// <summary>英文名</summary>
    [SugarColumn(ColumnName = "WPD_EnglishName", Length = 50, IsNullable = true, ColumnDescription = "英文名")]
    public string? WPD_EnglishName { get; set; }

    /// <summary>值</summary>
    [SugarColumn(ColumnName = "WPD_Value", Length = 100, IsNullable = true, ColumnDescription = "值")]
    public string? WPD_Value { get; set; }

    /// <summary>排序号</summary>
    [SugarColumn(ColumnName = "WPD_SortNo", IsNullable = true, ColumnDescription = "排序号")]
    public int? WPD_SortNo { get; set; }

    /// <summary>中文名</summary>
    [SugarColumn(ColumnName = "WPD_ChineseName", Length = 100, IsNullable = true, ColumnDescription = "中文名")]
    public string? WPD_ChineseName { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WPD_Ctreator", Length = 20, ColumnDescription = "创建人")]
    public string WPD_Ctreator { get; set; } = default!;

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WPD_CreateTime", ColumnDescription = "创建时间")]
    public DateTime WPD_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "WPD_Editor", Length = 20, IsNullable = true, ColumnDescription = "修改人")]
    public string? WPD_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WPD_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WPD_EditTime { get; set; }

    /// <summary>WPD_ID</summary>
    [SugarColumn(ColumnName = "WPD_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WPD_ID")]
    public int WPD_ID { get; set; }

}