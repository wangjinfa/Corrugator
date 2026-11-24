using SqlSugar;

namespace Corrugator.Domain.Entities.Dictionary;

/// <summary>
/// 数据字典类型表
/// </summary>
[SugarTable("W_DictTypes", TableDescription = "数据字典类型表")]
public class W_DictTypes
{
    /// <summary>父ID</summary>
    [SugarColumn(ColumnName = "WPD_PID", IsNullable = true, ColumnDescription = "父ID")]
    public int? WPD_PID { get; set; }

    /// <summary>类型名称</summary>
    [SugarColumn(ColumnName = "WPD_Name", Length = 50, IsNullable = true, ColumnDescription = "类型名称")]
    public string? WPD_Name { get; set; }

    /// <summary>WPD_Code</summary>
    [SugarColumn(ColumnName = "WPD_Code", Length = 50, IsNullable = true, ColumnDescription = "WPD_Code")]
    public string? WPD_Code { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WPD_Creator", Length = 20, ColumnDescription = "创建人")]
    public string WPD_Creator { get; set; } = default!;

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