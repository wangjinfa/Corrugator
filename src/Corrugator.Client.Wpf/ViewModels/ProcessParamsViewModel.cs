using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Contracts.Process;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>工艺参数（系数 / 开关）维护（Prism）</summary>
public class ProcessParamsViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<ProcessFactorItemDto> _items = new();
    private ProcessFactorItemDto? _selectedItem;
    private string? _keyword;
    private string _editValue = string.Empty;
    private string _statusMessage = string.Empty;

    public AsyncCommand LoadCommand { get; }
    public AsyncCommand SaveCommand { get; }

    public ProcessParamsViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
        SaveCommand = new AsyncCommand(SaveAsync);
    }

    public ObservableCollection<ProcessFactorItemDto> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }

    public ProcessFactorItemDto? SelectedItem
    {
        get => _selectedItem;
        set
        {
            if (!SetProperty(ref _selectedItem, value))
            {
                return;
            }

            EditValue = value?.Value?.ToString() ?? (value?.IsOpen?.ToString() ?? string.Empty);
        }
    }

    public string? Keyword
    {
        get => _keyword;
        set => SetProperty(ref _keyword, value);
    }

    public string EditValue
    {
        get => _editValue;
        set => SetProperty(ref _editValue, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var query = new Dictionary<string, string?>();
        if (!string.IsNullOrWhiteSpace(Keyword))
        {
            query["keyword"] = Keyword;
        }

        var result = await _api.GetAsync<List<ProcessFactorItemDto>>("api/process-params/factors", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "工艺参数加载失败";
            return;
        }

        Items = new ObservableCollection<ProcessFactorItemDto>(result.Data);
        StatusMessage = $"共 {Items.Count} 项工艺系数";
    }

    private async Task SaveAsync()
    {
        if (SelectedItem is null)
        {
            StatusMessage = "请先选中一项参数";
            return;
        }

        var update = new ProcessFactorUpdateDto { Key = SelectedItem.Key };

        if (SelectedItem.Value is not null)
        {
            if (!decimal.TryParse(EditValue, out var value))
            {
                StatusMessage = "请输入合法数值";
                return;
            }

            update.Value = value;
        }
        else if (SelectedItem.IsOpen is not null)
        {
            if (!bool.TryParse(EditValue, out var open))
            {
                StatusMessage = "开关项请输入 true / false";
                return;
            }

            update.IsOpen = open;
        }

        var result = await _api.PutAsync<bool>("api/process-params/factors", update);
        StatusMessage = result.Success ? "已保存" : (result.Message ?? "保存失败");

        if (result.Success)
        {
            await LoadAsync();
        }
    }
}
