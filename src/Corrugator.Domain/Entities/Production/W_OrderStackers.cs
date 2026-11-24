using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 订单堆码表
/// </summary>
[SugarTable("W_OrderStackers", TableDescription = "订单堆码表")]
public class W_OrderStackers
{
    /// <summary>堆码机编号</summary>
    [SugarColumn(ColumnName = "WOS_No", ColumnDescription = "堆码机编号")]
    public int WOS_No { get; set; }

    /// <summary>堆叠模式（多单堆叠 0 非，1是）</summary>
    [SugarColumn(ColumnName = "WOS_Stack", ColumnDescription = "堆叠模式（多单堆叠 0 非，1是）")]
    public int WOS_Stack { get; set; }

    /// <summary>订单号</summary>
    [SugarColumn(ColumnName = "WOS_OrderNo", Length = 50, ColumnDescription = "订单号")]
    public string WOS_OrderNo { get; set; } = default!;

    /// <summary>客户名称</summary>
    [SugarColumn(ColumnName = "WOS_CustName", Length = 100, ColumnDescription = "客户名称")]
    public string WOS_CustName { get; set; } = default!;

    /// <summary>切长 mm/100</summary>
    [SugarColumn(ColumnName = "WOS_CutLength", ColumnDescription = "切长 mm/100")]
    public int WOS_CutLength { get; set; }

    /// <summary>切宽 mm/100</summary>
    [SugarColumn(ColumnName = "WOS_CutWidth", ColumnDescription = "切宽 mm/100")]
    public int WOS_CutWidth { get; set; }

    /// <summary>堆码纸板数量</summary>
    [SugarColumn(ColumnName = "WOS_Qty", ColumnDescription = "堆码纸板数量")]
    public int WOS_Qty { get; set; }

    /// <summary>堆码纸板高度</summary>
    [SugarColumn(ColumnName = "WOS_Height", ColumnDescription = "堆码纸板高度")]
    public int WOS_Height { get; set; }

    /// <summary>是否最后堆垛(0非，1是)</summary>
    [SugarColumn(ColumnName = "WOS_Last", ColumnDescription = "是否最后堆垛(0非，1是)")]
    public int WOS_Last { get; set; }

    /// <summary>是否最后客户堆垛(0非，1是)</summary>
    [SugarColumn(ColumnName = "WOS_LastCust", ColumnDescription = "是否最后客户堆垛(0非，1是)")]
    public int WOS_LastCust { get; set; }

    /// <summary>未完工表ID(排单标识)</summary>
    [SugarColumn(ColumnName = "WO_ID", ColumnDescription = "未完工表ID(排单标识)")]
    public int WO_ID { get; set; }

    /// <summary>剖数</summary>
    [SugarColumn(ColumnName = "WOS_CN", ColumnDescription = "剖数")]
    public int WOS_CN { get; set; }

    /// <summary>堆码纸板总数量</summary>
    [SugarColumn(ColumnName = "WOS_SumQty", ColumnDescription = "堆码纸板总数量")]
    public int WOS_SumQty { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WOS_CreateTime", ColumnDescription = "创建日期")]
    public DateTime WOS_CreateTime { get; set; }

    /// <summary>打印次数(0没打印)</summary>
    [SugarColumn(ColumnName = "WOS_Print", ColumnDescription = "打印次数(0没打印)")]
    public int WOS_Print { get; set; }

    /// <summary>WOS_ID</summary>
    [SugarColumn(ColumnName = "WOS_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WOS_ID")]
    public int WOS_ID { get; set; }

}