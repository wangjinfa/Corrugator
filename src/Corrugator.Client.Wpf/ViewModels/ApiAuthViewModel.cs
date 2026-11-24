using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>API 授权（基础信息 → API授权）：左账号、右接口、底部保存授权</summary>
public class ApiAuthViewModel : BindableBase
{
    private readonly ApiClient _api;

    private ObservableCollection<ApiAccountDto> _accounts = new();
    private ObservableCollection<ApiItemDto> _apis = new();
    private ApiAccountDto? _selectedAccount;
    private string _statusMessage = string.Empty;
    private bool _isLoading;

    public ApiAuthViewModel(ApiClient api)
    {
        _api = api;
    }

    public ObservableCollection<ApiAccountDto> Accounts
    {
        get => _accounts;
        set => SetProperty(ref _accounts, value);
    }

    public ObservableCollection<ApiItemDto> Apis
    {
        get => _apis;
        set => SetProperty(ref _apis, value);
    }

    public ApiAccountDto? SelectedAccount
    {
        get => _selectedAccount;
        set
        {
            if (!SetProperty(ref _selectedAccount, value))
            {
                return;
            }

            _ = LoadApisAsync();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public async Task LoadAsync()
    {
        IsLoading = true;
        try
        {
            var result = await _api.GetAsync<List<ApiAccountDto>>("api/system/api-users");
            if (!result.Success || result.Data is null)
            {
                StatusMessage = result.Message ?? "API 账号加载失败";
                return;
            }

            var current = SelectedAccount?.Id;
            Accounts = new ObservableCollection<ApiAccountDto>(result.Data);

            var match = Accounts.FirstOrDefault(a => a.Id == current) ?? Accounts.FirstOrDefault();
            if (match is not null)
            {
                // 触发 LoadApisAsync
                SelectedAccount = match;
            }
            else
            {
                Apis = new ObservableCollection<ApiItemDto>();
            }
        }
        finally
        {
            IsLoading = false;
        }
    }

    public async Task LoadApisAsync()
    {
        var query = new Dictionary<string, string?>();
        if (SelectedAccount is not null)
        {
            query["userId"] = SelectedAccount.Id.ToString();
        }

        var result = await _api.GetAsync<List<ApiItemDto>>("api/system/apis", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "接口清单加载失败";
            return;
        }

        Apis = new ObservableCollection<ApiItemDto>(result.Data);
        StatusMessage = SelectedAccount is null
            ? $"接口 {Apis.Count} 个"
            : $"{SelectedAccount.Account} / 接口 {Apis.Count} 个，已授权 {Apis.Count(a => a.Authorized)} 个";
    }

    public async Task AuthorizeAsync()
    {
        if (SelectedAccount is null)
        {
            StatusMessage = "请先在左侧选择账号";
            return;
        }

        var ids = Apis.Where(a => a.Authorized).Select(a => a.Id).ToList();
        var request = new ApiAuthorizeRequest { UserId = SelectedAccount.Id, ApiIds = ids };
        var result = await _api.PostAsync<ApiEmpty>("api/system/apis/authorize", request);
        StatusMessage = result.Success ? result.Message ?? "已保存授权" : result.Message ?? "授权失败";

        if (result.Success)
        {
            await LoadApisAsync();
        }
    }
}
