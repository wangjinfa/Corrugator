using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单生产路线分配设置表
/// </summary>
[SugarTable("TB_OrderRoute", TableDescription = "订单生产路线分配设置表")]
public class TB_OrderRoute
{
    /// <summary>订单数量</summary>
    [SugarColumn(ColumnName = "F_OrderNum", ColumnDescription = "订单数量")]
    public int F_OrderNum { get; set; }

    /// <summary>订单1/订单2(Order1/Order2)</summary>
    [SugarColumn(ColumnName = "F_OrderName", Length = 20, ColumnDescription = "订单1/订单2(Order1/Order2)")]
    public string F_OrderName { get; set; } = default!;

    /// <summary>横切刀分配</summary>
    [SugarColumn(ColumnName = "F_CutoffAllocation", ColumnDescription = "横切刀分配")]
    public int F_CutoffAllocation { get; set; }

    /// <summary>操作侧1/驱动侧2</summary>
    [SugarColumn(ColumnName = "F_OSDS", ColumnDescription = "操作侧1/驱动侧2")]
    public int F_OSDS { get; set; }

    /// <summary>F_IsDouble</summary>
    [SugarColumn(ColumnName = "F_IsDouble", IsNullable = true, ColumnDescription = "F_IsDouble")]
    public bool? F_IsDouble { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}