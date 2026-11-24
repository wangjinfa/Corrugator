using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Orders;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>工单管理：查询分页 / 新增 / 删除（Prism BindableBase + AsyncCommand）</summary>
public class OrdersViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<OrderDto> _items = new();
    private OrderDto? _selectedOrder;
    private string? _keyword;
    private string? _waveFilter;
    private int _pageIndex = 1;
    private int _pageSize = 20;
    private int _total;
    private string _statusMessage = string.Empty;
    private bool _isBusy;

    // ---- 新增订单表单 ----
    private int _newWorkNo = 1;
    private string _newPaperCode = string.Empty;
    private string _newWave = "BC";
    private int _newWidth = 1600;
    private int _newCutLength = 1000;
    private int _newCutQty;
    private string? _newCustName;
    private int _newSpeed = 120;
    private bool _newIsUrgent;

    public AsyncCommand LoadCommand { get; }
    public AsyncCommand SearchCommand { get; }
    public AsyncCommand NextPageCommand { get; }
    public AsyncCommand PrevPageCommand { get; }
    public AsyncCommand CreateCommand { get; }
    public AsyncCommand DeleteCommand { get; }

    public OrdersViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
        SearchCommand = new AsyncCommand(SearchAsync);
        NextPageCommand = new AsyncCommand(NextPageAsync);
        PrevPageCommand = new AsyncCommand(PrevPageAsync);
        CreateCommand = new AsyncCommand(CreateAsync);
        DeleteCommand = new AsyncCommand(DeleteAsync);
    }

    public ObservableCollection<OrderDto> Items
    {
        get => _items;
        set => SetProperty(ref _items, value);
    }

    public OrderDto? SelectedOrder
    {
        get => _selectedOrder;
        set => SetProperty(ref _selectedOrder, value);
    }

    public string? Keyword
    {
        get => _keyword;
        set => SetProperty(ref _keyword, value);
    }

    public string? WaveFilter
    {
        get => _waveFilter;
        set => SetProperty(ref _waveFilter, value);
    }

    public int PageIndex
    {
        get => _pageIndex;
        set => SetProperty(ref _pageIndex, value);
    }

    public int PageSize
    {
        get => _pageSize;
        set
        {
            if (SetProperty(ref _pageSize, value))
            {
                RaisePropertyChanged(nameof(TotalPages));
            }
        }
    }

    public int Total
    {
        get => _total;
        set
        {
            if (SetProperty(ref _total, value))
            {
                RaisePropertyChanged(nameof(TotalPages));
            }
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    public int NewWorkNo
    {
        get => _newWorkNo;
        set => SetProperty(ref _newWorkNo, value);
    }

    public string NewPaperCode
    {
        get => _newPaperCode;
        set => SetProperty(ref _newPaperCode, value);
    }

    public string NewWave
    {
        get => _newWave;
        set => SetProperty(ref _newWave, value);
    }

    public int NewWidth
    {
        get => _newWidth;
        set => SetProperty(ref _newWidth, value);
    }

    public int NewCutLength
    {
        get => _newCutLength;
        set => SetProperty(ref _newCutLength, value);
    }

    public int NewCutQty
    {
        get => _newCutQty;
        set => SetProperty(ref _newCutQty, value);
    }

    public string? NewCustName
    {
        get => _newCustName;
        set => SetProperty(ref _newCustName, value);
    }

    public int NewSpeed
    {
        get => _newSpeed;
        set => SetProperty(ref _newSpeed, value);
    }

    public bool NewIsUrgent
    {
        get => _newIsUrgent;
        set => SetProperty(ref _newIsUrgent, value);
    }

    public int TotalPages => PageSize <= 0 ? 1 : Math.Max(1, (Total + PageSize - 1) / PageSize);

    public async Task LoadAsync()
    {
        if (IsBusy)
        {
            return;
        }

        IsBusy = true;
        try
        {
            var query = new Dictionary<string, string?>
            {
                ["PageIndex"] = PageIndex.ToString(),
                ["PageSize"] = PageSize.ToString(),
                ["Keyword"] = Keyword,
                ["Wave"] = WaveFilter,
            };

            var result = await _api.GetAsync<PagedResult<OrderDto>>("api/orders", query);
            if (!result.Success || result.Data is null)
            {
                StatusMessage = result.Message ?? "订单加载失败";
                return;
            }

            Items = new ObservableCollection<OrderDto>(result.Data.Items);
            Total = result.Data.Total;
            StatusMessage = $"共 {Total} 条，第 {PageIndex}/{TotalPages} 页";
        }
        finally
        {
            IsBusy = false;
        }
    }

    private async Task SearchAsync()
    {
        PageIndex = 1;
        await LoadAsync();
    }

    private async Task NextPageAsync()
    {
        if (PageIndex >= TotalPages)
        {
            return;
        }

        PageIndex++;
        await LoadAsync();
    }

    private async Task PrevPageAsync()
    {
        if (PageIndex <= 1)
        {
            return;
        }

        PageIndex--;
        await LoadAsync();
    }

    private async Task CreateAsync()
    {
        var input = new OrderInput
        {
            WO_WorkNo = NewWorkNo,
            WO_PaperCode = NewPaperCode,
            WO_Wave = NewWave,
            WO_Width = NewWidth,
            WO_CutLength = NewCutLength,
            WO_CutQty = NewCutQty,
            WO_CustName = NewCustName,
            WO_Speed = NewSpeed,
            WO_IsUrgent = NewIsUrgent,
            WO_Trim = 20,
            WO_ScorDeep = 2,
            WO_OrderDate = DateTime.Now,
        };

        var result = await _api.PostAsync<OrderDto>("api/orders", input);
        StatusMessage = result.Success ? "新增成功" : (result.Message ?? "新增失败");

        if (result.Success)
        {
            await LoadAsync();
        }
    }

    private async Task DeleteAsync()
    {
        if (SelectedOrder is null)
        {
            StatusMessage = "请先选中一行订单";
            return;
        }

        var result = await _api.DeleteAsync<bool>($"api/orders/{SelectedOrder.WO_ID}");
        StatusMessage = result.Success ? "删除成功" : (result.Message ?? "删除失败");

        if (result.Success)
        {
            await LoadAsync();
        }
    }
}
