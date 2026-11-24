using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>订单颜色设置的一行（带颜色画刷，供界面色块绑定）</summary>
public class OrderColorRow : BindableBase
{
    private string _condition = string.Empty;
    private int _priority;
    private string? _backColor;
    private string? _fontColor;
    private bool _isUse;

    public long Id { get; set; }

    public string Condition
    {
        get => _condition;
        set => SetProperty(ref _condition, value);
    }

    public int Priority
    {
        get => _priority;
        set => SetProperty(ref _priority, value);
    }

    /// <summary>背景颜色 #RRGGBB（空=无色）</summary>
    public string? BackColor
    {
        get => _backColor;
        set
        {
            if (SetProperty(ref _backColor, value))
            {
                RaisePropertyChanged(nameof(BackBrush));
                RaisePropertyChanged(nameof(HasBackColor));
            }
        }
    }

    /// <summary>字体颜色 #RRGGBB（空=不设置）</summary>
    public string? FontColor
    {
        get => _fontColor;
        set
        {
            if (SetProperty(ref _fontColor, value))
            {
                RaisePropertyChanged(nameof(FontBrush));
                RaisePropertyChanged(nameof(HasFontColor));
            }
        }
    }

    public bool IsUse
    {
        get => _isUse;
        set => SetProperty(ref _isUse, value);
    }

    public bool HasBackColor => !string.IsNullOrWhiteSpace(_backColor);

    public bool HasFontColor => !string.IsNullOrWhiteSpace(_fontColor);

    public Brush BackBrush => ToBrush(_backColor);

    public Brush FontBrush => ToBrush(_fontColor);

    private static Brush ToBrush(string? hex)
    {
        if (string.IsNullOrWhiteSpace(hex))
        {
            return Brushes.White;
        }

        try
        {
            return (Brush)new BrushConverter().ConvertFromString(hex)!;
        }
        catch
        {
            return Brushes.White;
        }
    }
}

/// <summary>订单颜色设置（基础信息 → 订单颜色设置）</summary>
public class OrderColorViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<OrderColorRow> _rows = new();
    private string _statusMessage = string.Empty;

    public OrderColorViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<OrderColorRow> Rows
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
        var result = await _api.GetAsync<List<OrderColorDto>>("api/system/order-colors");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "订单颜色设置加载失败";
            return;
        }

        Rows = new ObservableCollection<OrderColorRow>(result.Data.Select(d => new OrderColorRow
        {
            Id = d.Id,
            Condition = d.Condition,
            Priority = d.Priority,
            BackColor = d.BackColor,
            FontColor = d.FontColor,
            IsUse = d.IsUse,
        }));

        StatusMessage = $"订单颜色 {Rows.Count} 条";
    }

    public async Task SaveAsync()
    {
        var items = Rows.Select(r => new OrderColorDto
        {
            Id = r.Id,
            Condition = r.Condition,
            Priority = r.Priority,
            BackColor = r.BackColor,
            FontColor = r.FontColor,
            IsUse = r.IsUse,
        }).ToList();

        var result = await _api.PostAsync<ApiEmpty>("api/system/order-colors", new OrderColorSaveRequest { Items = items });
        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";

        if (result.Success)
        {
            await LoadAsync();
        }
    }
}
