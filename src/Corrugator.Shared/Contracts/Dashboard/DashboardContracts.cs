namespace Corrugator.Shared.Contracts.Dashboard;

/// <summary>生管看板概览</summary>
public class DashboardOverviewDto
{
    /// <summary>在制（未完工）订单数</summary>
    public int ActiveOrders { get; set; }
    /// <summary>插单数</summary>
    public int UrgentOrders { get; set; }
    /// <summary>今日完工订单数</summary>
    public int FinishedToday { get; set; }
    /// <summary>今日完工米数</summary>
    public decimal FinishedMeterToday { get; set; }
    /// <summary>今日平均车速</summary>
    public double AvgSpeedToday { get; set; }
    /// <summary>未确认告警数</summary>
    public int UnconfirmedAlarms { get; set; }
    /// <summary>最近订单（用于看板表格）</summary>
    public List<DashboardOrderRow> RecentOrders { get; set; } = new();
}

public class DashboardOrderRow
{
    public int WO_ID { get; set; }
    public int WO_WorkNo { get; set; }
    public string WO_PaperCode { get; set; } = string.Empty;
    public string WO_Wave { get; set; } = string.Empty;
    public int WO_Width { get; set; }
    public int WO_CutLength { get; set; }
    public int WO_CutQty { get; set; }
    public bool WO_IsUrgent { get; set; }
    public string? WO_CustName { get; set; }
    public DateTime? WO_EstFinshTime { get; set; }
}
