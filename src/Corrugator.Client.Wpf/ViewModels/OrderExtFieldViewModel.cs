using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>订单扩展字段一格（Define1..18）</summary>
public class OrderExtFieldRow : BindableBase
{
    private int _seq;
    private string _code = string.Empty;
    private string? _jsonCode;
    private string? _name;
    private string? _dataType;
    private bool _isShowInList;

    public long Id { get; set; }

    public int Seq
    {
        get => _seq;
        set => SetProperty(ref _seq, value);
    }

    public string Code
    {
        get => _code;
        set => SetProperty(ref _code, value);
    }

    public string? JsonCode
    {
        get => _jsonCode;
        set => SetProperty(ref _jsonCode, value);
    }

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public string? DataType
    {
        get => _dataType;
        set => SetProperty(ref _dataType, value);
    }

    public bool IsShowInList
    {
        get => _isShowInList;
        set => SetProperty(ref _isShowInList, value);
    }
}

/// <summary>订单扩展字段设置（基础信息 → 订单扩展字段设置）。改动即自动保存。</summary>
public class OrderExtFieldViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<OrderExtFieldRow> _rows = new();
    private string _statusMessage = string.Empty;
    private bool _saving;

    public OrderExtFieldViewModel(ApiClient api)
    {
        _api = api;
    }

    /// <summary>可选的扩展字段数据类型</summary>
    public IReadOnlyList<string> DataTypes { get; } = new[] { "string", "int", "bool", "decimal", "datetime" };

    public ObservableCollection<OrderExtFieldRow> Rows
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
        var result = await _api.GetAsync<List<OrderExtFieldDto>>("api/system/order-ext-fields");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "订单扩展字段加载失败";
            return;
        }

        Rows = new ObservableCollection<OrderExtFieldRow>(result.Data.Select(d => new OrderExtFieldRow
        {
            Id = d.Id,
            Seq = d.Seq,
            Code = d.Code,
            JsonCode = d.JsonCode,
            Name = d.Name,
            DataType = d.DataType,
            IsShowInList = d.IsShowInList,
        }));

        StatusMessage = $"共 {Rows.Count} 个扩展字段槽位，改动后自动保存";
    }

    /// <summary>整表保存（页面无保存按钮，编辑提交即调用）</summary>
    public async Task SaveAsync()
    {
        if (_saving || Rows.Count == 0)
        {
            return;
        }

        _saving = true;
        try
        {
            var items = Rows.Select(r => new OrderExtFieldDto
            {
                Id = r.Id,
                Seq = r.Seq,
                Code = r.Code,
                JsonCode = r.JsonCode,
                Name = r.Name,
                DataType = r.DataType,
                IsShowInList = r.IsShowInList,
            }).ToList();

            var result = await _api.PostAsync<ApiEmpty>("api/system/order-ext-fields",
                new OrderExtFieldSaveRequest { Items = items });

            StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
            if (result.Success)
            {
                var refreshed = await _api.GetAsync<List<OrderExtFieldDto>>("api/system/order-ext-fields");
                if (refreshed.Success && refreshed.Data is not null)
                {
                    foreach (var dto in refreshed.Data)
                    {
                        var row = Rows.FirstOrDefault(r => r.Id == dto.Id || r.Code == dto.Code);
                        if (row is not null)
                        {
                            row.Id = dto.Id;
                        }
                    }
                }
            }
        }
        finally
        {
            _saving = false;
        }
    }
}
