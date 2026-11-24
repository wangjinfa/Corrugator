using SqlSugar;

namespace Corrugator.Domain.Entities.Dictionary;

/// <summary>
/// 数据字典明细表
/// </summary>
[SugarTable("P_DictDatas", TableDescription = "数据字典明细表")]
public class P_DictDatas
{
    /// <summary>类型ID</summary>
    [SugarColumn(ColumnName = "PD_TypeID", ColumnDescription = "类型ID")]
    public int PD_TypeID { get; set; }

    /// <summary>属性</summary>
    [SugarColumn(ColumnName = "PD_Property", Length = 50, IsNullable = true, ColumnDescription = "属性")]
    public string? PD_Property { get; set; }

    /// <summary>英文名</summary>
    [SugarColumn(ColumnName = "PD_EnglishName", Length = 50, IsNullable = true, ColumnDescription = "英文名")]
    public string? PD_EnglishName { get; set; }

    /// <summary>值</summary>
    [SugarColumn(ColumnName = "PD_Value", Length = 100, IsNullable = true, ColumnDescription = "值")]
    public string? PD_Value { get; set; }

    /// <summary>排序号</summary>
    [SugarColumn(ColumnName = "PD_SortNo", IsNullable = true, ColumnDescription = "排序号")]
    public int? PD_SortNo { get; set; }

    /// <summary>中文名</summary>
    [SugarColumn(ColumnName = "PD_ChineseName", Length = 100, IsNullable = true, ColumnDescription = "中文名")]
    public string? PD_ChineseName { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "PD_Ctreator", Length = 20, ColumnDescription = "创建人")]
    public string PD_Ctreator { get; set; } = default!;

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "PD_CreateTime", ColumnDescription = "创建时间")]
    public DateTime PD_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "PD_Editor", Length = 20, IsNullable = true, ColumnDescription = "修改人")]
    public string? PD_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "PD_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? PD_EditTime { get; set; }

    /// <summary>PD_ID</summary>
    [SugarColumn(ColumnName = "PD_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "PD_ID")]
    public int PD_ID { get; set; }

}