using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Alarms;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>预警管理：分页告警 + 确认（Prism）</summary>
public class AlarmsViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<AlarmDto> _items = new();
    private AlarmDto? _selectedAlarm;
    private int _pageIndex = 1;
    private int _pageSize = 20;
    private int _total;
    private string _statusMessage = string.Empty;
    private string? _reviewNote;

    public AsyncCommand LoadCommand { get; }
    public AsyncCommand ConfirmCommand { get; }

    public AlarmsViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
        ConfirmCommand = new AsyncCommand(ConfirmAsync);
    }

    public ObservableCollection<AlarmDto> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }

    public AlarmDto? SelectedAlarm
    {
        get => _selectedAlarm;
        set => SetProperty(ref _selectedAlarm, value);
    }

    public int PageIndex
    {
        get => _pageIndex;
        set => SetProperty(ref _pageIndex, value);
    }

    public int PageSize
    {
        get => _pageSize;
        set => SetProperty(ref _pageSize, value);
    }

    public int Total
    {
        get => _total;
        set => SetProperty(ref _total, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public string? ReviewNote
    {
        get => _reviewNote;
        set => SetProperty(ref _reviewNote, value);
    }

    public async Task LoadAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["PageIndex"] = PageIndex.ToString(),
            ["PageSize"] = PageSize.ToString(),
        };

        var result = await _api.GetAsync<PagedResult<AlarmDto>>("api/alarms", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "告警加载失败";
            return;
        }

        Items = new ObservableCollection<AlarmDto>(result.Data.Items);
        Total = result.Data.Total;
        StatusMessage = $"共 {Total} 条告警";
    }

    private async Task ConfirmAsync()
    {
        if (SelectedAlarm is null)
        {
            StatusMessage = "请先选中一条告警";
            return;
        }

        var result = await _api.PostAsync<AlarmDto>(
            $"api/alarms/{SelectedAlarm.WA_ID}/confirm",
            new AlarmConfirmInput { ReviewNote = ReviewNote });

        StatusMessage = result.Success ? "已确认" : (result.Message ?? "确认失败");

        if (result.Success)
        {
            await LoadAsync();
        }
    }
}
