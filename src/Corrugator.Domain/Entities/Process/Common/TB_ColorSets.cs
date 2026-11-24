using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单列表行背景色设置
/// </summary>
[SugarTable("TB_ColorSets", TableDescription = "订单列表行背景色设置")]
public class TB_ColorSets
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>条件因素编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 255, ColumnDescription = "条件因素编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>条件因素名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 255, ColumnDescription = "条件因素名称")]
    public string F_Name { get; set; } = default!;

    /// <summary>颜色色号</summary>
    [SugarColumn(ColumnName = "F_BackColor", Length = 255, ColumnDescription = "颜色色号")]
    public string F_BackColor { get; set; } = default!;

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "是否启用")]
    public bool F_IsUse { get; set; }

    /// <summary>优先级</summary>
    [SugarColumn(ColumnName = "F_Sort", Length = 255, ColumnDescription = "优先级")]
    public string F_Sort { get; set; } = default!;

    /// <summary>前景色</summary>
    [SugarColumn(ColumnName = "F_ForeColor", Length = 255, ColumnDescription = "前景色")]
    public string F_ForeColor { get; set; } = default!;

}