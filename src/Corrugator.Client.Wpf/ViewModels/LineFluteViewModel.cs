using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Base;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>产线楞型一行（也是编辑弹窗的数据源）</summary>
public class LineFluteRow : BindableBase
{
    public long Id { get; set; }
    public int RowNo { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }

    private decimal _doorWidth;
    private string _fluteType = string.Empty;
    private decimal? _thickness;
    private decimal? _thickness1;
    private decimal? _thickness2;
    private decimal? _thickness3;
    private decimal? _weightThreshold1;
    private decimal? _weightThreshold2;
    private decimal? _weightThreshold3;
    private int? _maxSlit;
    private decimal? _minCutLength;
    private decimal? _maxCutLength;
    private decimal? _minTrim;
    private decimal? _maxTrim;
    private decimal? _upperStackLimit;
    private decimal? _lowerStackLimit;
    private int? _stackOpenThreshold1;
    private int? _stackOpenThreshold2;
    private int? _stackOpenThreshold3;
    private int? _upperStackCount1;
    private int? _upperStackCount2;
    private int? _upperStackCount3;
    private int? _lowerStackCount1;
    private int? _lowerStackCount2;
    private int? _lowerStackCount3;
    private decimal? _smallLine;
    private decimal? _smallLineDeepen;
    private decimal? _plainLineDepth;
    private decimal? _normalLineDepth;
    private decimal? _deepLineDepth;
    private decimal? _maxSpeed;
    private int? _rollerCount;
    private decimal? _trim;

    public decimal DoorWidth { get => _doorWidth; set => SetProperty(ref _doorWidth, value); }
    public string FluteType { get => _fluteType; set => SetProperty(ref _fluteType, value); }
    public decimal? Thickness { get => _thickness; set => SetProperty(ref _thickness, value); }
    public decimal? Thickness1 { get => _thickness1; set => SetProperty(ref _thickness1, value); }
    public decimal? Thickness2 { get => _thickness2; set => SetProperty(ref _thickness2, value); }
    public decimal? Thickness3 { get => _thickness3; set => SetProperty(ref _thickness3, value); }
    public decimal? WeightThreshold1 { get => _weightThreshold1; set => SetProperty(ref _weightThreshold1, value); }
    public decimal? WeightThreshold2 { get => _weightThreshold2; set => SetProperty(ref _weightThreshold2, value); }
    public decimal? WeightThreshold3 { get => _weightThreshold3; set => SetProperty(ref _weightThreshold3, value); }
    public int? MaxSlit { get => _maxSlit; set => SetProperty(ref _maxSlit, value); }
    public decimal? MinCutLength { get => _minCutLength; set => SetProperty(ref _minCutLength, value); }
    public decimal? MaxCutLength { get => _maxCutLength; set => SetProperty(ref _maxCutLength, value); }
    public decimal? MinTrim { get => _minTrim; set => SetProperty(ref _minTrim, value); }
    public decimal? MaxTrim { get => _maxTrim; set => SetProperty(ref _maxTrim, value); }
    public decimal? UpperStackLimit { get => _upperStackLimit; set => SetProperty(ref _upperStackLimit, value); }
    public decimal? LowerStackLimit { get => _lowerStackLimit; set => SetProperty(ref _lowerStackLimit, value); }
    public int? StackOpenThreshold1 { get => _stackOpenThreshold1; set => SetProperty(ref _stackOpenThreshold1, value); }
    public int? StackOpenThreshold2 { get => _stackOpenThreshold2; set => SetProperty(ref _stackOpenThreshold2, value); }
    public int? StackOpenThreshold3 { get => _stackOpenThreshold3; set => SetProperty(ref _stackOpenThreshold3, value); }
    public int? UpperStackCount1 { get => _upperStackCount1; set => SetProperty(ref _upperStackCount1, value); }
    public int? UpperStackCount2 { get => _upperStackCount2; set => SetProperty(ref _upperStackCount2, value); }
    public int? UpperStackCount3 { get => _upperStackCount3; set => SetProperty(ref _upperStackCount3, value); }
    public int? LowerStackCount1 { get => _lowerStackCount1; set => SetProperty(ref _lowerStackCount1, value); }
    public int? LowerStackCount2 { get => _lowerStackCount2; set => SetProperty(ref _lowerStackCount2, value); }
    public int? LowerStackCount3 { get => _lowerStackCount3; set => SetProperty(ref _lowerStackCount3, value); }
    public decimal? SmallLine { get => _smallLine; set => SetProperty(ref _smallLine, value); }
    public decimal? SmallLineDeepen { get => _smallLineDeepen; set => SetProperty(ref _smallLineDeepen, value); }
    public decimal? PlainLineDepth { get => _plainLineDepth; set => SetProperty(ref _plainLineDepth, value); }
    public decimal? NormalLineDepth { get => _normalLineDepth; set => SetProperty(ref _normalLineDepth, value); }
    public decimal? DeepLineDepth { get => _deepLineDepth; set => SetProperty(ref _deepLineDepth, value); }
    public decimal? MaxSpeed { get => _maxSpeed; set => SetProperty(ref _maxSpeed, value); }
    public int? RollerCount { get => _rollerCount; set => SetProperty(ref _rollerCount, value); }
    public decimal? Trim { get => _trim; set => SetProperty(ref _trim, value); }

    public static LineFluteRow FromDto(LineFluteDto d)
    {
        var r = new LineFluteRow
        {
            Id = d.Id,
            DoorWidth = d.DoorWidth,
            FluteType = d.FluteType,
            Thickness = d.Thickness,
            Thickness1 = d.Thickness1,
            Thickness2 = d.Thickness2,
            Thickness3 = d.Thickness3,
            WeightThreshold1 = d.WeightThreshold1,
            WeightThreshold2 = d.WeightThreshold2,
            WeightThreshold3 = d.WeightThreshold3,
            MaxSlit = d.MaxSlit,
            MinCutLength = d.MinCutLength,
            MaxCutLength = d.MaxCutLength,
            MinTrim = d.MinTrim,
            MaxTrim = d.MaxTrim,
            UpperStackLimit = d.UpperStackLimit,
            LowerStackLimit = d.LowerStackLimit,
            StackOpenThreshold1 = d.StackOpenThreshold1,
            StackOpenThreshold2 = d.StackOpenThreshold2,
            StackOpenThreshold3 = d.StackOpenThreshold3,
            UpperStackCount1 = d.UpperStackCount1,
            UpperStackCount2 = d.UpperStackCount2,
            UpperStackCount3 = d.UpperStackCount3,
            LowerStackCount1 = d.LowerStackCount1,
            LowerStackCount2 = d.LowerStackCount2,
            LowerStackCount3 = d.LowerStackCount3,
            SmallLine = d.SmallLine,
            SmallLineDeepen = d.SmallLineDeepen,
            PlainLineDepth = d.PlainLineDepth,
            NormalLineDepth = d.NormalLineDepth,
            DeepLineDepth = d.DeepLineDepth,
            MaxSpeed = d.MaxSpeed,
            RollerCount = d.RollerCount,
            Trim = d.Trim,
            Creator = d.Creator,
            CreateTime = d.CreateTime,
            Editor = d.Editor,
            EditTime = d.EditTime,
        };
        return r;
    }

    public LineFluteDto ToDto()
    {
        return new LineFluteDto
        {
            Id = Id,
            DoorWidth = DoorWidth,
            FluteType = FluteType,
            Thickness = Thickness,
            Thickness1 = Thickness1,
            Thickness2 = Thickness2,
            Thickness3 = Thickness3,
            WeightThreshold1 = WeightThreshold1,
            WeightThreshold2 = WeightThreshold2,
            WeightThreshold3 = WeightThreshold3,
            MaxSlit = MaxSlit,
            MinCutLength = MinCutLength,
            MaxCutLength = MaxCutLength,
            MinTrim = MinTrim,
            MaxTrim = MaxTrim,
            UpperStackLimit = UpperStackLimit,
            LowerStackLimit = LowerStackLimit,
            StackOpenThreshold1 = StackOpenThreshold1,
            StackOpenThreshold2 = StackOpenThreshold2,
            StackOpenThreshold3 = StackOpenThreshold3,
            UpperStackCount1 = UpperStackCount1,
            UpperStackCount2 = UpperStackCount2,
            UpperStackCount3 = UpperStackCount3,
            LowerStackCount1 = LowerStackCount1,
            LowerStackCount2 = LowerStackCount2,
            LowerStackCount3 = LowerStackCount3,
            SmallLine = SmallLine,
            SmallLineDeepen = SmallLineDeepen,
            PlainLineDepth = PlainLineDepth,
            NormalLineDepth = NormalLineDepth,
            DeepLineDepth = DeepLineDepth,
            MaxSpeed = MaxSpeed,
            RollerCount = RollerCount,
            Trim = Trim,
        };
    }
}

/// <summary>产线楞型（基础信息 → 产线楞型）</summary>
public class LineFluteViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<LineFluteRow> _rows = new();
    private string _queryName = string.Empty;
    private string _statusMessage = string.Empty;
    private LineFluteRuleDto _rule = new();
    private bool _loading;

    public LineFluteViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<LineFluteRow> Rows
    {
        get => _rows;
        set => SetProperty(ref _rows, value);
    }

    public string QueryName
    {
        get => _queryName;
        set => SetProperty(ref _queryName, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public LineFluteRuleDto Rule
    {
        get => _rule;
        set => SetProperty(ref _rule, value);
    }

    /// <summary>修边类型可选值</summary>
    public IReadOnlyList<string> TrimTypes { get; } = new[] { "不修边", "修边", "自动修边" };

    /// <summary>出垛数判定依据</summary>
    public IReadOnlyList<string> StackCountBases { get; } = new[] { "剁数", "开数", "高度" };

    /// <summary>堆码排垛默认排出方向</summary>
    public IReadOnlyList<string> StackDirections { get; } = new[] { "操作侧", "非操作侧" };

    /// <summary>纸板厚度计算模式</summary>
    public IReadOnlyList<string> ThicknessCalcModes { get; } = new[] { "克重区间模式", "楞型模式", "实测厚度模式" };

    public async Task LoadAsync()
    {
        await SearchAsync();
        await LoadRuleAsync();
    }

    public async Task SearchAsync()
    {
        var url = "api/base/line-flutes";
        if (!string.IsNullOrWhiteSpace(QueryName))
        {
            url += $"?fluteType={Uri.EscapeDataString(QueryName.Trim())}";
        }

        var result = await _api.GetAsync<List<LineFluteDto>>(url);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "产线楞型加载失败";
            return;
        }

        var rows = result.Data.Select(LineFluteRow.FromDto).ToList();
        for (var i = 0; i < rows.Count; i++)
        {
            rows[i].RowNo = i + 1;
        }

        Rows = new ObservableCollection<LineFluteRow>(rows);
        StatusMessage = $"共 {Rows.Count} 条产线楞型";
    }

    public void Reset()
    {
        QueryName = string.Empty;
        _ = SearchAsync();
    }

    public async Task SaveAsync(LineFluteRow row, bool isNew)
    {
        var result = isNew
            ? await _api.PostAsync<LineFluteDto>("api/base/line-flutes", row.ToDto())
            : await _api.PutAsync<LineFluteDto>($"api/base/line-flutes/{row.Id}", row.ToDto());

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }

    public async Task DeleteAsync(LineFluteRow row)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/base/line-flutes/{row.Id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }

    public async Task RefreshOrdersAsync()
    {
        var result = await _api.PostAsync<ApiEmpty>("api/base/line-flutes/refresh-orders", new { });
        StatusMessage = result.Success ? result.Message ?? "已更新" : result.Message ?? "更新失败";
    }

    private async Task LoadRuleAsync()
    {
        var result = await _api.GetAsync<LineFluteRuleDto>("api/base/line-flute-rules");
        if (result.Success && result.Data is not null)
        {
            Rule = result.Data;
        }
    }

    /// <summary>底部规则改动后自动保存</summary>
    public async Task SaveRuleAsync()
    {
        if (_loading)
        {
            return;
        }

        var result = await _api.PostAsync<ApiEmpty>("api/base/line-flute-rules", Rule);
        StatusMessage = result.Success ? result.Message ?? "已保存规则设置" : result.Message ?? "规则设置保存失败";
    }

    public void BeginRuleEdit() => _loading = true;

    public void EndRuleEdit() => _loading = false;
}
