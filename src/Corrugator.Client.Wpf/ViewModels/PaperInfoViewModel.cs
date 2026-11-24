using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Base;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>原纸资料一行</summary>
public class PaperRow : BindableBase
{
    private string _code = string.Empty;
    private decimal? _gramWeight;
    private decimal? _paperWidth;
    private string? _brand;
    private decimal? _remainLS2;
    private decimal? _remainMS3;
    private decimal? _remainLS3;

    public long Id { get; set; }
    public int RowNo { get; set; }

    public string Code { get => _code; set => SetProperty(ref _code, value); }
    public decimal? GramWeight { get => _gramWeight; set => SetProperty(ref _gramWeight, value); }
    public decimal? PaperWidth { get => _paperWidth; set => SetProperty(ref _paperWidth, value); }
    public string? Brand { get => _brand; set => SetProperty(ref _brand, value); }
    public decimal? RemainLS2 { get => _remainLS2; set => SetProperty(ref _remainLS2, value); }
    public decimal? RemainMS3 { get => _remainMS3; set => SetProperty(ref _remainMS3, value); }
    public decimal? RemainLS3 { get => _remainLS3; set => SetProperty(ref _remainLS3, value); }

    public static PaperRow FromDto(PaperInfoDto d) => new()
    {
        Id = d.Id,
        Code = d.Code,
        GramWeight = d.GramWeight,
        PaperWidth = d.PaperWidth,
        Brand = d.Brand,
        RemainLS2 = d.RemainLS2,
        RemainMS3 = d.RemainMS3,
        RemainLS3 = d.RemainLS3,
    };

    public PaperInfoDto ToDto() => new()
    {
        Id = Id,
        Code = Code,
        GramWeight = GramWeight,
        PaperWidth = PaperWidth,
        Brand = Brand,
        RemainLS2 = RemainLS2,
        RemainMS3 = RemainMS3,
        RemainLS3 = RemainLS3,
    };
}

/// <summary>品牌信息里的供应商行</summary>
public class PaperSupplierRow : BindableBase
{
    public long Id { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public decimal? RatedTension { get; set; }
    public decimal? SteamGsm { get; set; }
    public decimal? GlueGsm { get; set; }
    public decimal? WrapGsm { get; set; }
    public decimal? TensionLS0 { get; set; }
    public decimal? TensionMS1 { get; set; }
    public decimal? TensionLS1 { get; set; }
    public decimal? TensionMS2 { get; set; }
    public decimal? TensionLS2 { get; set; }
    public decimal? TensionMS3 { get; set; }
    public decimal? TensionLS3 { get; set; }

    public PaperBrandParamDto ToDto() => new()
    {
        Id = Id,
        Supplier = Supplier,
        RatedTension = RatedTension,
        SteamGsm = SteamGsm,
        GlueGsm = GlueGsm,
        WrapGsm = WrapGsm,
        TensionLS0 = TensionLS0,
        TensionMS1 = TensionMS1,
        TensionLS1 = TensionLS1,
        TensionMS2 = TensionMS2,
        TensionLS2 = TensionLS2,
        TensionMS3 = TensionMS3,
        TensionLS3 = TensionLS3,
    };
}

/// <summary>品牌信息里的胶水值行</summary>
public class PaperGlueRow : BindableBase
{
    private decimal? _glueValue;

    public long Id { get; set; }
    public string MachineType { get; set; } = string.Empty;
    public string FluteType { get; set; } = string.Empty;
    public string? Layer { get; set; }

    public decimal? GlueValue
    {
        get => _glueValue;
        set => SetProperty(ref _glueValue, value);
    }

    public PaperGlueValueDto ToDto() => new()
    {
        Id = Id,
        MachineType = MachineType,
        FluteType = FluteType,
        Layer = Layer,
        GlueValue = GlueValue,
    };
}

/// <summary>原纸资料（基础信息 → 原纸资料）</summary>
public class PaperInfoViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<PaperRow> _rows = new();
    private string _queryCode = string.Empty;
    private string _statusMessage = string.Empty;

    public PaperInfoViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<PaperRow> Rows
    {
        get => _rows;
        set => SetProperty(ref _rows, value);
    }

    public string QueryCode
    {
        get => _queryCode;
        set => SetProperty(ref _queryCode, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync() => await SearchAsync();

    public async Task SearchAsync()
    {
        var url = "api/base/papers";
        if (!string.IsNullOrWhiteSpace(QueryCode))
        {
            url += $"?code={Uri.EscapeDataString(QueryCode.Trim())}";
        }

        var result = await _api.GetAsync<List<PaperInfoDto>>(url);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "原纸资料加载失败";
            return;
        }

        var rows = result.Data.Select(PaperRow.FromDto).ToList();
        for (var i = 0; i < rows.Count; i++)
        {
            rows[i].RowNo = i + 1;
        }

        Rows = new ObservableCollection<PaperRow>(rows);
        StatusMessage = $"共 {Rows.Count} 条原纸";
    }

    public void Reset()
    {
        QueryCode = string.Empty;
        _ = SearchAsync();
    }

    public async Task SaveAsync(PaperRow row, bool isNew)
    {
        var result = isNew
            ? await _api.PostAsync<PaperInfoDto>("api/base/papers", row.ToDto())
            : await _api.PutAsync<PaperInfoDto>($"api/base/papers/{row.Id}", row.ToDto());

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }

    public async Task DeleteAsync(PaperRow row)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/base/papers/{row.Id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }

    /// <summary>读原纸品牌信息（供应商 + 胶水值）</summary>
    public async Task<PaperBrandSaveRequest?> LoadBrandInfoAsync(string code)
    {
        var result = await _api.GetAsync<PaperBrandSaveRequest>($"api/base/papers/{Uri.EscapeDataString(code)}/brand-info");
        if (!result.Success)
        {
            StatusMessage = result.Message ?? "品牌信息加载失败";
            return null;
        }

        return result.Data;
    }

    /// <summary>保存原纸品牌信息</summary>
    public async Task<bool> SaveBrandInfoAsync(string code, PaperBrandSaveRequest request)
    {
        var result = await _api.PostAsync<ApiEmpty>(
            $"api/base/papers/{Uri.EscapeDataString(code)}/brand-info", request);

        StatusMessage = result.Success ? result.Message ?? "已保存品牌信息" : result.Message ?? "品牌信息保存失败";
        return result.Success;
    }
}
