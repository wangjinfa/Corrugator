using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单扩展字段对应关系表
/// </summary>
[SugarTable("TB_Order_JsonTrans", TableDescription = "订单扩展字段对应关系表")]
public class TB_Order_JsonTrans
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>Json字段编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 50, IsNullable = true, ColumnDescription = "Json字段编码")]
    public string? F_Code { get; set; }

    /// <summary>字段显示名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 50, IsNullable = true, ColumnDescription = "字段显示名称")]
    public string? F_Name { get; set; }

    /// <summary>数据类型</summary>
    [SugarColumn(ColumnName = "F_DataType", Length = 20, IsNullable = true, ColumnDescription = "数据类型")]
    public string? F_DataType { get; set; }

    /// <summary>是否在订单列表显示</summary>
    [SugarColumn(ColumnName = "F_IsShow", ColumnDescription = "是否在订单列表显示")]
    public bool F_IsShow { get; set; }

    /// <summary>扩展字段编号</summary>
    [SugarColumn(ColumnName = "F_DCode", Length = 50, ColumnDescription = "扩展字段编号", DefaultValue = "0")]
    public string F_DCode { get; set; } = default!;

    /// <summary>序号</summary>
    [SugarColumn(ColumnName = "F_Sort", ColumnDescription = "序号", DefaultValue = "0")]
    public int F_Sort { get; set; }

}