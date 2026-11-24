using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>IPS 部位显示/隐藏的一行</summary>
public class IpsPartRow : BindableBase
{
    private string _code = string.Empty;
    private string? _name;
    private bool _isShow = true;

    public long Id { get; set; }

    public int SortNo { get; set; }

    public string Code
    {
        get => _code;
        set => SetProperty(ref _code, value);
    }

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public bool IsShow
    {
        get => _isShow;
        set => SetProperty(ref _isShow, value);
    }
}

/// <summary>IPS 部位显示/隐藏（基础信息 → IPS部位显示/隐藏）</summary>
public class IpsPartViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<IpsPartRow> _rows = new();
    private string _statusMessage = string.Empty;

    public IpsPartViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<IpsPartRow> Rows
    {
        get => _rows;
        set => SetProperty(ref _rows, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var result = await _api.GetAsync<List<IpsPartDto>>("api/system/ips-parts");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "IPS 部位设置加载失败";
            return;
        }

        Rows = new ObservableCollection<IpsPartRow>(result.Data.Select(d => new IpsPartRow
        {
            Id = d.Id,
            SortNo = d.SortNo,
            Code = d.Code,
            Name = d.Name,
            IsShow = d.IsShow,
        }));

        StatusMessage = $"部位 {Rows.Count} 个";
    }

    public async Task SaveAsync()
    {
        var items = Rows.Select(r => new IpsPartDto
        {
            Id = r.Id,
            Code = r.Code,
            Name = r.Name,
            IsShow = r.IsShow,
            SortNo = r.SortNo,
        }).ToList();

        var result = await _api.PostAsync<ApiEmpty>("api/system/ips-parts", new IpsPartSaveRequest { Items = items });
        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";

        if (result.Success)
        {
            await LoadAsync();
        }
    }
}
