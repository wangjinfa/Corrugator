using SqlSugar;

namespace Corrugator.Domain.Entities.Dictionary;

/// <summary>
/// 数据字典类型表
/// </summary>
[SugarTable("P_DictTypes", TableDescription = "数据字典类型表")]
public class P_DictTypes
{
    /// <summary>父ID</summary>
    [SugarColumn(ColumnName = "PD_PID", IsNullable = true, ColumnDescription = "父ID")]
    public int? PD_PID { get; set; }

    /// <summary>类型名称</summary>
    [SugarColumn(ColumnName = "PD_Name", Length = 50, IsNullable = true, ColumnDescription = "类型名称")]
    public string? PD_Name { get; set; }

    /// <summary>PD_Code</summary>
    [SugarColumn(ColumnName = "PD_Code", Length = 50, IsNullable = true, ColumnDescription = "PD_Code")]
    public string? PD_Code { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "PD_Creator", Length = 20, ColumnDescription = "创建人")]
    public string PD_Creator { get; set; } = default!;

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