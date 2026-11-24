using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单列表行背景色设置
/// </summary>
[SugarTable("W_ColorSets", TableDescription = "订单列表行背景色设置")]
public class W_ColorSets
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>条件因素编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 255, ColumnDescription = "条件因素编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>条件因素名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 255, ColumnDescription = "条件因素名称")]
    public string WF_Name { get; set; } = default!;

    /// <summary>颜色色号</summary>
    [SugarColumn(ColumnName = "WF_BackColor", Length = 255, ColumnDescription = "颜色色号")]
    public string WF_BackColor { get; set; } = default!;

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "是否启用")]
    public bool WF_IsUse { get; set; }

    /// <summary>优先级</summary>
    [SugarColumn(ColumnName = "WF_Sort", Length = 255, ColumnDescription = "优先级")]
    public string WF_Sort { get; set; } = default!;

    /// <summary>前景色</summary>
    [SugarColumn(ColumnName = "WF_ForeColor", Length = 255, ColumnDescription = "前景色")]
    public string WF_ForeColor { get; set; } = default!;

}