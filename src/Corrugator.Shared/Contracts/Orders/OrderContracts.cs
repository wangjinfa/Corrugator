using Corrugator.Shared.Api;

namespace Corrugator.Shared.Contracts.Orders;

/// <summary>未完工订单（W_Orders）列表项</summary>
public class OrderDto
{
    public int WO_ID { get; set; }
    public string? WEO_Guid { get; set; }
    public bool WO_IsUrgent { get; set; }
    public int WO_WorkNo { get; set; }
    public string? WO_ClassNo { get; set; }
    public string WO_PaperCode { get; set; } = string.Empty;
    public string WO_Wave { get; set; } = string.Empty;
    public int WO_Floor { get; set; }
    public int WO_Width { get; set; }
    public int WO_Trim { get; set; }
    public int? WO_Weight { get; set; }
    public decimal? WO_Deep { get; set; }
    public int WO_Speed { get; set; }
    public decimal? WO_ScheduleMeter { get; set; }

    public bool WO_Stop { get; set; }
    public bool WO_UGoD { get; set; }
    public DateTime? WO_StartTime { get; set; }
    public DateTime? WO_EstFinshTime { get; set; }

    public string? WO_OrderNo { get; set; }
    public string? WO_CustNo { get; set; }
    public string? WO_CustName { get; set; }
    public int WO_CutWidth { get; set; }
    public int WO_CutLength { get; set; }
    public int WO_CutQty { get; set; }
    public int? WO_OrderQty { get; set; }
    public decimal? WO_OrderMeter { get; set; }
    public int WO_CN { get; set; }
    public string WO_ScorType { get; set; } = string.Empty;
    public string? WO_Scor { get; set; }
    public decimal WO_ScorDeep { get; set; }

    public string? WO_OrderNo_D { get; set; }
    public string? WO_CustName_D { get; set; }
    public int? WO_CutWidth_D { get; set; }
    public int? WO_CutLength_D { get; set; }
    public int? WO_CutQty_D { get; set; }

    public int WO_SortSN { get; set; }
    public int IndexNo { get; set; }
    public string? WO_Remark { get; set; }

    /// <summary>生产状态（由开始/预计完工时间推导）</summary>
    public string Status { get; set; } = string.Empty;
}

/// <summary>订单查询条件</summary>
public class OrderQuery : PageQuery
{
    public string? Wave { get; set; }
    public string? PaperCode { get; set; }
    public int? WorkNo { get; set; }
    public string? ClassNo { get; set; }
    public bool? IsUrgent { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
    public bool? Finished { get; set; }
}

/// <summary>新增/修改订单</summary>
public class OrderInput
{
    public int? WO_ID { get; set; }
    public string? WEO_Guid { get; set; }
    public bool WO_IsUrgent { get; set; }
    public int WO_WorkNo { get; set; }
    public string? WO_ClassNo { get; set; }
    public string WO_PaperCode { get; set; } = string.Empty;
    public string WO_Wave { get; set; } = string.Empty;
    public int WO_Floor { get; set; } = 5;
    public int WO_Width { get; set; }
    public int WO_Trim { get; set; }
    public int? WO_Weight { get; set; }
    public decimal? WO_Deep { get; set; }
    public int WO_Speed { get; set; }
    public decimal? WO_ScheduleMeter { get; set; }
    public string? WO_OrderNo { get; set; }
    public string? WO_CustNo { get; set; }
    public string? WO_CustName { get; set; }
    public int WO_CutWidth { get; set; }
    public int WO_CutLength { get; set; }
    public int WO_CutQty { get; set; }
    public int WO_CN { get; set; }
    public string WO_ScorType { get; set; } = "普压线";
    public string? WO_Scor { get; set; }
    public decimal WO_ScorDeep { get; set; }
    public int WO_SortSN { get; set; }
    public string? WO_Remark { get; set; }
    public DateTime? WO_OrderDate { get; set; }
    public DateTime? WO_DeliDate { get; set; }
}

/// <summary>已完工订单（W_OrderFinishs）列表项</summary>
public class FinishedOrderDto
{
    public int WOF_ID { get; set; }
    public int WO_ID { get; set; }
    public int WOF_WorkNo { get; set; }
    public string? WOF_ClassNo { get; set; }
    public string WOF_PaperCode { get; set; } = string.Empty;
    public string WOF_Wave { get; set; } = string.Empty;
    public int WOF_Floor { get; set; }
    public int WOF_Width { get; set; }
    public int WOF_Speed { get; set; }
    public int? WOF_AvgSpeed { get; set; }
    public int? WOF_StopNum { get; set; }
    public int? WOF_StopTime { get; set; }
    public DateTime? WOF_StartTime { get; set; }
    public DateTime? WOF_FinishTime { get; set; }
    public string? WOF_OrderNo { get; set; }
    public string? WOF_CustName { get; set; }
    public int? WOF_CutQty { get; set; }
    public decimal? WOF_OrderMeter { get; set; }
}
