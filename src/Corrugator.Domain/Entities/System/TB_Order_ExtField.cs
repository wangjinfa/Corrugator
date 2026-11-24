using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>
/// 订单扩展字段设置（基础信息 → 订单扩展字段设置）。
/// 固定 18 个 Define 槽位，订单表里以 Json 存放扩展值。
/// </summary>
[SugarTable("W_Order_ExtField", TableDescription = "订单扩展字段设置")]
public class W_Order_ExtField
{
    /// <summary>序号 1..18</summary>
    [SugarColumn(ColumnName = "WF_Seq", ColumnDescription = "序号")]
    public int WF_Seq { get; set; }

    /// <summary>字段编码 Define1..Define18</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 40, ColumnDescription = "字段编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>Json 字段编码 ex1..ex18</summary>
    [SugarColumn(ColumnName = "WF_JsonCode", Length = 40, IsNullable = true, ColumnDescription = "Json字段编码")]
    public string? WF_JsonCode { get; set; }

    /// <summary>扩展字段显示名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, IsNullable = true, ColumnDescription = "扩展字段显示名称")]
    public string? WF_Name { get; set; }

    /// <summary>数据类型 string / int / bool / decimal / datetime</summary>
    [SugarColumn(ColumnName = "WF_DataType", Length = 20, IsNullable = true, ColumnDescription = "数据类型")]
    public string? WF_DataType { get; set; }

    /// <summary>是否在列表中显示</summary>
    [SugarColumn(ColumnName = "WF_IsShowInList", IsNullable = true, ColumnDescription = "是否要在列表中显示")]
    public bool? WF_IsShowInList { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
