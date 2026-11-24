using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 订单生产路线分配设置表
/// </summary>
[SugarTable("W_OrderRoute", TableDescription = "订单生产路线分配设置表")]
public class W_OrderRoute
{
    /// <summary>订单数量</summary>
    [SugarColumn(ColumnName = "WF_OrderNum", ColumnDescription = "订单数量")]
    public int WF_OrderNum { get; set; }

    /// <summary>订单1/订单2(Order1/Order2)</summary>
    [SugarColumn(ColumnName = "WF_OrderName", Length = 20, ColumnDescription = "订单1/订单2(Order1/Order2)")]
    public string WF_OrderName { get; set; } = default!;

    /// <summary>横切刀分配</summary>
    [SugarColumn(ColumnName = "WF_CutoffAllocation", ColumnDescription = "横切刀分配")]
    public int WF_CutoffAllocation { get; set; }

    /// <summary>操作侧1/驱动侧2</summary>
    [SugarColumn(ColumnName = "WF_OSDS", ColumnDescription = "操作侧1/驱动侧2")]
    public int WF_OSDS { get; set; }

    /// <summary>WF_IsDouble</summary>
    [SugarColumn(ColumnName = "WF_IsDouble", IsNullable = true, ColumnDescription = "WF_IsDouble")]
    public bool? WF_IsDouble { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}