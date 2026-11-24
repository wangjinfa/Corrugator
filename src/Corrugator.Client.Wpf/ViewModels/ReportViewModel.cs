using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Orders;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>按楞型汇总的产量行</summary>
public class ReportRow
{
    public string Wave { get; init; } = string.Empty;
    public int OrderCount { get; init; }
    public decimal Meter { get; init; }
    public double AvgSpeed { get; init; }
    public string LastFinish { get; init; } = string.Empty;
}

/// <summary>报表管理：完工记录按楞型汇总（Prism）</summary>
public class ReportViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<ReportRow> _rows = new();
    private string _totalOrders = "0";
    private string _totalMeter = "0";
    private string _avgSpeed = "0";
    private string _statusMessage = string.Empty;

    public AsyncCommand LoadCommand { get; }

    public ReportViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
    }

    public ObservableCollection<ReportRow> Rows
    {
        get => _rows;
        set => SetProperty(ref _rows, value);
    }

    public string TotalOrders
    {
        get => _totalOrders;
        set => SetProperty(ref _totalOrders, value);
    }

    public string TotalMeter
    {
        get => _totalMeter;
        set => SetProperty(ref _totalMeter, value);
    }

    public string AvgSpeed
    {
        get => _avgSpeed;
        set => SetProperty(ref _avgSpeed, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var result = await _api.GetAsync<PagedResult<FinishedOrderDto>>(
            "api/orders/finished", new Dictionary<string, string?> { ["PageIndex"] = "1", ["PageSize"] = "100" });

        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "完工记录加载失败";
            return;
        }

        var items = result.Data.Items;
        var rows = items
            .GroupBy(o => string.IsNullOrEmpty(o.WOF_Wave) ? "未标注" : o.WOF_Wave)
            .Select(g => new ReportRow
            {
                Wave = g.Key,
                OrderCount = g.Count(),
                Meter = g.Sum(o => o.WOF_OrderMeter ?? 0),
                AvgSpeed = g.Average(o => (double)(o.WOF_AvgSpeed ?? o.WOF_Speed)),
                LastFinish = g.Max(o => o.WOF_FinishTime)?.ToString("MM-dd HH:mm") ?? "--",
            })
            .OrderByDescending(r => r.Meter)
            .ToList();

        Rows = new ObservableCollection<ReportRow>(rows);
        TotalOrders = items.Count.ToString("N0");
        TotalMeter = items.Sum(o => o.WOF_OrderMeter ?? 0).ToString("N0");
        AvgSpeed = items.Count == 0 ? "0" : items.Average(o => (double)(o.WOF_AvgSpeed ?? o.WOF_Speed)).ToString("0");
        StatusMessage = $"统计完工记录 {items.Count} 条（总数 {result.Data.Total}）";
    }
}
