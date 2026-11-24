using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Dictionary;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>字典分类树节点：显示“中文名|英文名”</summary>
public class DictTypeNode
{
    public int Id { get; set; }
    public int? ParentId { get; set; }
    public string? Name { get; set; }
    public string? Code { get; set; }
    public bool IsRoot { get; set; }
    public List<DictTypeNode> Children { get; set; } = new();

    public string Label => IsRoot ? "根目录" : $"{Name}|{Code}";
}

/// <summary>数据字典页（Prism）：左分类树 + 右明细表</summary>
public class DictionaryViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<DictTypeNode> _nodes = new();
    private DictTypeNode? _selectedNode;
    private ObservableCollection<DictDataDto> _details = new();
    private DictDataDto? _selectedDetail;
    private string _statusMessage = string.Empty;

    public AsyncCommand LoadCommand { get; }

    public DictionaryViewModel(ApiClient api)
    {
        _api = api;
        LoadCommand = new AsyncCommand(LoadAsync);
    }

    public ObservableCollection<DictTypeNode> Nodes
    {
        get => _nodes;
        set => SetProperty(ref _nodes, value);
    }

    public DictTypeNode? SelectedNode
    {
        get => _selectedNode;
        set
        {
            if (!SetProperty(ref _selectedNode, value))
            {
                return;
            }

            RaisePropertyChanged(nameof(CanEditNode));
            RaisePropertyChanged(nameof(CurrentTypeId));
            _ = LoadDetailsAsync();
        }
    }

    public ObservableCollection<DictDataDto> Details
    {
        get => _details;
        set => SetProperty(ref _details, value);
    }

    public DictDataDto? SelectedDetail
    {
        get => _selectedDetail;
        set => SetProperty(ref _selectedDetail, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    /// <summary>根目录不能改/删</summary>
    public bool CanEditNode => SelectedNode is not null && !SelectedNode.IsRoot;

    /// <summary>当前选中分类的 Id（0 表示根目录，不加载明细）</summary>
    public int CurrentTypeId => SelectedNode is null || SelectedNode.IsRoot ? 0 : SelectedNode.Id;

    public async Task LoadAsync()
    {
        var result = await _api.GetAsync<List<DictTypeDto>>("api/dictionary/types");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "字典分类加载失败";
            return;
        }

        var flat = result.Data;
        var root = new DictTypeNode { Id = 0, IsRoot = true };

        foreach (var item in flat.Where(t => t.PD_PID is null or 0))
        {
            root.Children.Add(ToNode(item));
        }

        // 递归挂接子分类
        void Attach(DictTypeNode parent)
        {
            foreach (var child in parent.Children)
            {
                child.Children.AddRange(flat.Where(t => t.PD_PID == child.Id).Select(ToNode));
                Attach(child);
            }
        }

        Attach(root);

        Nodes = new ObservableCollection<DictTypeNode>(new[] { root });
        StatusMessage = $"共 {flat.Count} 个字典分类";

        SelectedNode = null;
        SelectedNode = root;
    }

    private static DictTypeNode ToNode(DictTypeDto dto) => new()
    {
        Id = dto.PD_ID,
        ParentId = dto.PD_PID,
        Name = dto.PD_Name,
        Code = dto.PD_Code,
    };

    public async Task LoadDetailsAsync()
    {
        if (CurrentTypeId <= 0)
        {
            Details = new ObservableCollection<DictDataDto>();
            return;
        }

        var result = await _api.GetAsync<List<DictDataDto>>($"api/dictionary/types/{CurrentTypeId}/data");
        var list = result.Success && result.Data is not null ? result.Data : new List<DictDataDto>();
        var index = 0;
        foreach (var row in list)
        {
            row.RowNo = ++index;
        }

        Details = new ObservableCollection<DictDataDto>(list);
    }

    public async Task<bool> SaveNodeAsync(int? id, DictTypeSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<DictTypeDto>("api/dictionary/types", request)
            : await _api.PutAsync<DictTypeDto>($"api/dictionary/types/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadAsync();
        return true;
    }

    public async Task<bool> DeleteNodeAsync(int id)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/dictionary/types/{id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadAsync();
        return true;
    }

    public async Task<bool> SaveDetailAsync(int? id, DictDataSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<DictDataDto>("api/dictionary/datas", request)
            : await _api.PutAsync<DictDataDto>($"api/dictionary/datas/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadDetailsAsync();
        return true;
    }

    public async Task<bool> DeleteDetailAsync(int id)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/dictionary/datas/{id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadDetailsAsync();
        return true;
    }
}
