using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Contracts.Dashboard;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>生产看板：班次汇总 + 最近工单（Prism BindableBase + AsyncCommand）</summary>
public class DashboardViewModel : BindableBase
{
    private readonly ApiClient _api;

    private int _activeOrders;
    private int _urgentOrders;
    private int _finishedToday;
    private decimal _finishedMeterToday;
    private double _avgSpeedToday;
    private int _unconfirmedAlarms;
    private string _statusMessage = string.Empty;

    public ObservableCollection<DashboardOrderRow> RecentOrders { get; } = new();

    public AsyncCommand LoadCommand { get; }

    public DashboardViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
    }

    public int ActiveOrders
    {
        get => _activeOrders;
        set => SetProperty(ref _activeOrders, value);
    }

    public int UrgentOrders
    {
        get => _urgentOrders;
        set => SetProperty(ref _urgentOrders, value);
    }

    public int FinishedToday
    {
        get => _finishedToday;
        set => SetProperty(ref _finishedToday, value);
    }

    public decimal FinishedMeterToday
    {
        get => _finishedMeterToday;
        set => SetProperty(ref _finishedMeterToday, value);
    }

    public double AvgSpeedToday
    {
        get => _avgSpeedToday;
        set => SetProperty(ref _avgSpeedToday, value);
    }

    public int UnconfirmedAlarms
    {
        get => _unconfirmedAlarms;
        set => SetProperty(ref _unconfirmedAlarms, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var result = await _api.GetAsync<DashboardOverviewDto>("api/dashboard/overview");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "看板数据加载失败";
            return;
        }

        var data = result.Data;
        ActiveOrders = data.ActiveOrders;
        UrgentOrders = data.UrgentOrders;
        FinishedToday = data.FinishedToday;
        FinishedMeterToday = data.FinishedMeterToday;
        AvgSpeedToday = data.AvgSpeedToday;
        UnconfirmedAlarms = data.UnconfirmedAlarms;

        RecentOrders.Clear();
        foreach (var row in data.RecentOrders)
        {
            RecentOrders.Add(row);
        }

        StatusMessage = $"更新于 {DateTime.Now:HH:mm:ss}";
    }
}
