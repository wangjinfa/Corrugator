using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Base;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>班组资料一行</summary>
public class TeamRow : BindableBase
{
    public long Id { get; set; }
    public int RowNo { get; set; }
    public string ShiftNo { get; set; } = string.Empty;
    public string TeamName { get; set; } = string.Empty;
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? Leader { get; set; }
    public string? Forklift1 { get; set; }
    public string? Forklift2 { get; set; }
    public string? Creator { get; set; }
    public string? CreateTime { get; set; }
    public string? Editor { get; set; }
    public string? EditTime { get; set; }

    public static TeamRow FromDto(TeamInfoDto d) => new()
    {
        Id = d.Id,
        ShiftNo = d.ShiftNo,
        TeamName = d.TeamName,
        StartTime = d.StartTime,
        EndTime = d.EndTime,
        Leader = d.Leader,
        Forklift1 = d.Forklift1,
        Forklift2 = d.Forklift2,
        Creator = d.Creator,
        CreateTime = d.CreateTime,
        Editor = d.Editor,
        EditTime = d.EditTime,
    };

    public TeamInfoDto ToDto() => new()
    {
        Id = Id,
        ShiftNo = ShiftNo,
        TeamName = TeamName,
        StartTime = StartTime,
        EndTime = EndTime,
        Leader = Leader,
        Forklift1 = Forklift1,
        Forklift2 = Forklift2,
        Creator = Creator,
        CreateTime = CreateTime,
        Editor = Editor,
        EditTime = EditTime,
    };
}

/// <summary>班组资料（基础信息 → 班组资料）</summary>
public class TeamInfoViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<TeamRow> _rows = new();
    private string _queryName = string.Empty;
    private string _statusMessage = string.Empty;

    public TeamInfoViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<TeamRow> Rows
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

    public async Task LoadAsync() => await SearchAsync();

    public async Task SearchAsync()
    {
        var url = "api/base/teams";
        if (!string.IsNullOrWhiteSpace(QueryName))
        {
            url += $"?name={Uri.EscapeDataString(QueryName.Trim())}";
        }

        var result = await _api.GetAsync<List<TeamInfoDto>>(url);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "班组资料加载失败";
            return;
        }

        var rows = result.Data.Select(TeamRow.FromDto).ToList();
        for (var i = 0; i < rows.Count; i++)
        {
            rows[i].RowNo = i + 1;
        }

        Rows = new ObservableCollection<TeamRow>(rows);
        StatusMessage = $"共 {Rows.Count} 个班组";
    }

    public void Reset()
    {
        QueryName = string.Empty;
        _ = SearchAsync();
    }

    public async Task SaveAsync(TeamRow row, bool isNew)
    {
        var result = isNew
            ? await _api.PostAsync<TeamInfoDto>("api/base/teams", row.ToDto())
            : await _api.PutAsync<TeamInfoDto>($"api/base/teams/{row.Id}", row.ToDto());

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }

    public async Task DeleteAsync(TeamRow row)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/base/teams/{row.Id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await SearchAsync();
        }
    }
}
