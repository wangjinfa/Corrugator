using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单扩展字段对应关系表
/// </summary>
[SugarTable("W_Order_JsonTrans", TableDescription = "订单扩展字段对应关系表")]
public class W_Order_JsonTrans
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>Json字段编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 50, IsNullable = true, ColumnDescription = "Json字段编码")]
    public string? WF_Code { get; set; }

    /// <summary>字段显示名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 50, IsNullable = true, ColumnDescription = "字段显示名称")]
    public string? WF_Name { get; set; }

    /// <summary>数据类型</summary>
    [SugarColumn(ColumnName = "WF_DataType", Length = 20, IsNullable = true, ColumnDescription = "数据类型")]
    public string? WF_DataType { get; set; }

    /// <summary>是否在订单列表显示</summary>
    [SugarColumn(ColumnName = "WF_IsShow", ColumnDescription = "是否在订单列表显示")]
    public bool WF_IsShow { get; set; }

    /// <summary>扩展字段编号</summary>
    [SugarColumn(ColumnName = "WF_DCode", Length = 50, ColumnDescription = "扩展字段编号", DefaultValue = "0")]
    public string WF_DCode { get; set; } = default!;

    /// <summary>序号</summary>
    [SugarColumn(ColumnName = "WF_Sort", ColumnDescription = "序号", DefaultValue = "0")]
    public int WF_Sort { get; set; }

}