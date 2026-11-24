using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Contracts.Dashboard;
using Corrugator.Shared.Contracts.Orders;
using Corrugator.Shared.Contracts.Process;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>图形化控制页的一行排程工单</summary>
public class GraphicOrderRow
{
    public int WoId { get; init; }
    public string Wave { get; init; } = string.Empty;
    public int Width { get; init; }
    public string PaperCode { get; init; } = string.Empty;
    public string CustName { get; init; } = string.Empty;
    public int CutLength { get; init; }
    public int CutWidth { get; init; }
    public int Trim { get; init; }
    public decimal ScheduleMeter { get; init; }
    public bool IsUrgent { get; init; }

    /// <summary>0=当前生产 1=插单 2=待生产 3=普通</summary>
    public int StatusIndex { get; init; }
}

/// <summary>
/// 图形化控制：左侧机台示意图 + 右侧速度仪表与"当前订单备注"面板（Prism）。
/// PLC 实时点位（弯曲辊开关、热板温度、实际线速）需接 PLC 网关后才能取到，这里先展示工艺设定值与排程数据。
/// </summary>
public class GraphicControlViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<GraphicOrderRow> _orders = new();
    private GraphicOrderRow? _selectedOrder;

    private double _gaugeValue;
    private string _gaugeText = "0";

    private string _glue1stText = "胶量 --";
    private string _glue0Text = "糊量 --";

    private string _shiftTotal = "0";
    private string _shiftProduced = "0";
    private string _shiftRemain = "0";
    private string _shiftSquare = "0";
    private string _shiftAvgSpeed = "0";
    private string _shiftBadRate = "0";
    private string _shiftTrimRate = "0";
    private string _shiftRunTime = "0";
    private string _shiftStopTime = "0";
    private string _shiftStopCount = "0";

    private string _orderTotal = "0";
    private string _orderProduced = "0";
    private string _orderRemain = "0";
    private string _orderSquare = "0";
    private string _orderAvgSpeed = "0";
    private string _orderBadRate = "0";
    private string _orderTrimRate = "0";
    private string _orderRunTime = "0";
    private string _orderStopTime = "0";
    private string _orderStopCount = "0";

    private string _totalRemain = "0";
    private string _currentRemain = "0";
    private string _estimateTime = "--";
    private string _pageInfo = "0/0";
    private string _selectedTotal = "0";

    private string _statusMessage = string.Empty;

    public AsyncCommand LoadCommand { get; }

    public GraphicControlViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
    }

    public ObservableCollection<GraphicOrderRow> Orders
    {
        get => _orders;
        set => SetProperty(ref _orders, value);
    }

    public GraphicOrderRow? SelectedOrder
    {
        get => _selectedOrder;
        set
        {
            if (SetProperty(ref _selectedOrder, value))
            {
                SelectedTotal = value is null ? "0" : value.ScheduleMeter.ToString("N0");
            }
        }
    }

    public double GaugeValue
    {
        get => _gaugeValue;
        set => SetProperty(ref _gaugeValue, value);
    }

    public string GaugeText
    {
        get => _gaugeText;
        set => SetProperty(ref _gaugeText, value);
    }

    public string Glue1stText
    {
        get => _glue1stText;
        set => SetProperty(ref _glue1stText, value);
    }

    public string Glue0Text
    {
        get => _glue0Text;
        set => SetProperty(ref _glue0Text, value);
    }

    public string ShiftTotal
    {
        get => _shiftTotal;
        set => SetProperty(ref _shiftTotal, value);
    }

    public string ShiftProduced
    {
        get => _shiftProduced;
        set => SetProperty(ref _shiftProduced, value);
    }

    public string ShiftRemain
    {
        get => _shiftRemain;
        set => SetProperty(ref _shiftRemain, value);
    }

    public string ShiftSquare
    {
        get => _shiftSquare;
        set => SetProperty(ref _shiftSquare, value);
    }

    public string ShiftAvgSpeed
    {
        get => _shiftAvgSpeed;
        set => SetProperty(ref _shiftAvgSpeed, value);
    }

    public string ShiftBadRate
    {
        get => _shiftBadRate;
        set => SetProperty(ref _shiftBadRate, value);
    }

    public string ShiftTrimRate
    {
        get => _shiftTrimRate;
        set => SetProperty(ref _shiftTrimRate, value);
    }

    public string ShiftRunTime
    {
        get => _shiftRunTime;
        set => SetProperty(ref _shiftRunTime, value);
    }

    public string ShiftStopTime
    {
        get => _shiftStopTime;
        set => SetProperty(ref _shiftStopTime, value);
    }

    public string ShiftStopCount
    {
        get => _shiftStopCount;
        set => SetProperty(ref _shiftStopCount, value);
    }

    public string OrderTotal
    {
        get => _orderTotal;
        set => SetProperty(ref _orderTotal, value);
    }

    public string OrderProduced
    {
        get => _orderProduced;
        set => SetProperty(ref _orderProduced, value);
    }

    public string OrderRemain
    {
        get => _orderRemain;
        set => SetProperty(ref _orderRemain, value);
    }

    public string OrderSquare
    {
        get => _orderSquare;
        set => SetProperty(ref _orderSquare, value);
    }

    public string OrderAvgSpeed
    {
        get => _orderAvgSpeed;
        set => SetProperty(ref _orderAvgSpeed, value);
    }

    public string OrderBadRate
    {
        get => _orderBadRate;
        set => SetProperty(ref _orderBadRate, value);
    }

    public string OrderTrimRate
    {
        get => _orderTrimRate;
        set => SetProperty(ref _orderTrimRate, value);
    }

    public string OrderRunTime
    {
        get => _orderRunTime;
        set => SetProperty(ref _orderRunTime, value);
    }

    public string OrderStopTime
    {
        get => _orderStopTime;
        set => SetProperty(ref _orderStopTime, value);
    }

    public string OrderStopCount
    {
        get => _orderStopCount;
        set => SetProperty(ref _orderStopCount, value);
    }

    public string TotalRemain
    {
        get => _totalRemain;
        set => SetProperty(ref _totalRemain, value);
    }

    public string CurrentRemain
    {
        get => _currentRemain;
        set => SetProperty(ref _currentRemain, value);
    }

    public string EstimateTime
    {
        get => _estimateTime;
        set => SetProperty(ref _estimateTime, value);
    }

    public string PageInfo
    {
        get => _pageInfo;
        set => SetProperty(ref _pageInfo, value);
    }

    public string SelectedTotal
    {
        get => _selectedTotal;
        set => SetProperty(ref _selectedTotal, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var orderResult = await _api.GetAsync<Corrugator.Shared.Api.PagedResult<OrderDto>>(
            "api/orders", new Dictionary<string, string?> { ["PageIndex"] = "1", ["PageSize"] = "30" });

        if (!orderResult.Success || orderResult.Data is null)
        {
            StatusMessage = orderResult.Message ?? "排程数据加载失败";
            return;
        }

        var items = orderResult.Data.Items;
        var rows = new List<GraphicOrderRow>();
        for (var i = 0; i < items.Count; i++)
        {
            var o = items[i];
            var meter = o.WO_ScheduleMeter
                ?? (o.WO_CutLength > 0 && o.WO_CutQty > 0 ? o.WO_CutLength * o.WO_CutQty / 1000m : 0);

            rows.Add(new GraphicOrderRow
            {
                WoId = o.WO_ID,
                Wave = o.WO_Wave,
                Width = o.WO_Width,
                PaperCode = o.WO_PaperCode,
                CustName = o.WO_CustName ?? string.Empty,
                CutLength = o.WO_CutLength,
                CutWidth = o.WO_CutWidth,
                Trim = o.WO_Trim,
                ScheduleMeter = meter,
                IsUrgent = o.WO_IsUrgent,
                StatusIndex = i == 0 ? 0 : o.WO_IsUrgent ? 1 : (i % 2 == 1 ? 2 : 3),
            });
        }

        Orders = new ObservableCollection<GraphicOrderRow>(rows);
        SelectedOrder = Orders.FirstOrDefault();
        PageInfo = $"1/{Math.Max(1, orderResult.Data.Total)}";

        var totalMeter = rows.Sum(r => r.ScheduleMeter);
        TotalRemain = totalMeter.ToString("N0");
        CurrentRemain = rows.FirstOrDefault()?.StatusIndex == 0 ? rows[0].ScheduleMeter.ToString("N0") : "0";
        EstimateTime = items.FirstOrDefault(o => o.WO_EstFinshTime is not null)?.WO_EstFinshTime?.ToString("MM-dd HH:mm:ss") ?? "--";

        OrderTotal = totalMeter.ToString("N0");
        OrderRemain = totalMeter.ToString("N0");

        // 班次产量：来自看板聚合
        var overview = await _api.GetAsync<DashboardOverviewDto>("api/dashboard/overview");
        if (overview.Success && overview.Data is not null)
        {
            var d = overview.Data;
            ShiftProduced = d.FinishedMeterToday.ToString("N0");
            ShiftAvgSpeed = d.AvgSpeedToday.ToString("0");
            ShiftTotal = totalMeter.ToString("N0");
            ShiftRemain = Math.Max(0, totalMeter - d.FinishedMeterToday).ToString("N0");
            var avgWidth = rows.Count == 0 ? 0 : rows.Average(r => r.Width);
            ShiftSquare = (d.FinishedMeterToday * (decimal)avgWidth / 1000m).ToString("N0");
            ShiftRunTime = d.FinishedToday.ToString("N0");
            OrderProduced = d.FinishedMeterToday.ToString("N0");
            GaugeValue = d.AvgSpeedToday;
            GaugeText = d.AvgSpeedToday.ToString("0");
        }

        // 工艺设定值：糊机/单面机胶水系数
        var factors = await _api.GetAsync<List<ProcessFactorItemDto>>("api/process-params/factors");
        if (factors.Success && factors.Data is not null)
        {
            var glue1 = factors.Data.FirstOrDefault(f => f.Key == "WF_Glue_GU_1st_Form_Factor");
            var glue0 = factors.Data.FirstOrDefault(f => f.Key == "F_Glue_GU_0_Form_Factor");
            Glue1stText = $"胶量 {glue1?.Value?.ToString("0.##") ?? "--"}";
            Glue0Text = $"糊量 {glue0?.Value?.ToString("0.##") ?? "--"}";
        }

        StatusMessage = $"已加载 {rows.Count} 条排程工单";
    }
}
