using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>
/// 订单颜色设置（基础信息 → 订单颜色设置）。
/// 图形化控制页工单彩条按「条件」匹配，优先级数字越小越优先。
/// </summary>
[SugarTable("TB_Order_ColorSet", TableDescription = "订单颜色设置")]
public class TB_Order_ColorSet
{
    /// <summary>条件（首笔订单/前3笔订单/插单/修改订单/新增订单/复制订单/重做订单/默认）</summary>
    [SugarColumn(ColumnName = "F_Condition", Length = 50, ColumnDescription = "条件")]
    public string F_Condition { get; set; } = default!;

    /// <summary>优先级，越小越高</summary>
    [SugarColumn(ColumnName = "F_Priority", ColumnDescription = "优先级")]
    public int F_Priority { get; set; }

    /// <summary>背景颜色（#RRGGBB，空=无色）</summary>
    [SugarColumn(ColumnName = "F_BackColor", Length = 20, IsNullable = true, ColumnDescription = "背景颜色")]
    public string? F_BackColor { get; set; }

    /// <summary>字体颜色（#RRGGBB，空=默认黑）</summary>
    [SugarColumn(ColumnName = "F_FontColor", Length = 20, IsNullable = true, ColumnDescription = "字体颜色")]
    public string? F_FontColor { get; set; }

    /// <summary>启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? F_IsUse { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
