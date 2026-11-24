using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>系统设置（基础信息 → 系统设置）：运行参数表单</summary>
public class SystemSettingViewModel : BindableBase
{
    private readonly ApiClient _api;

    private string _updateUrl = "http://127.0.0.1:7776/BtsClientUpdate.xml";
    private string _startPage = "SF1生管";
    private bool _showTaskbar = true;
    private string _language = "zh-CN";
    private bool _showGluePosition;
    private string _statusMessage = string.Empty;
    private ObservableCollection<string> _startPageOptions = new();
    private ObservableCollection<string> _languageOptions = new();

    public SystemSettingViewModel(ApiClient api)
    {
        _api = api;
    }

    /// <summary>自动更新URL</summary>
    public string UpdateUrl
    {
        get => _updateUrl;
        set => SetProperty(ref _updateUrl, value);
    }

    /// <summary>生管控制起始页</summary>
    public string StartPage
    {
        get => _startPage;
        set => SetProperty(ref _startPage, value);
    }

    /// <summary>是否显示任务栏（界面用「是/否」）</summary>
    public string TaskbarText
    {
        get => _showTaskbar ? "是" : "否";
        set
        {
            var flag = string.Equals(value, "是", StringComparison.OrdinalIgnoreCase);
            if (SetProperty(ref _showTaskbar, flag))
            {
                RaisePropertyChanged(nameof(TaskbarText));
            }
        }
    }

    /// <summary>语言</summary>
    public string Language
    {
        get => _language;
        set => SetProperty(ref _language, value);
    }

    /// <summary>显示糊机部位选择</summary>
    public bool ShowGluePosition
    {
        get => _showGluePosition;
        set => SetProperty(ref _showGluePosition, value);
    }

    public ObservableCollection<string> StartPageOptions
    {
        get => _startPageOptions;
        set => SetProperty(ref _startPageOptions, value);
    }

    public ObservableCollection<string> LanguageOptions
    {
        get => _languageOptions;
        set => SetProperty(ref _languageOptions, value);
    }

    public ObservableCollection<string> TaskbarOptions { get; } = new() { "是", "否" };

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadAsync()
    {
        var result = await _api.GetAsync<SystemSettingsDto>("api/system/settings");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "系统设置加载失败";
            return;
        }

        var dto = result.Data;
        UpdateUrl = dto.UpdateUrl;
        StartPage = dto.StartPage;
        _showTaskbar = dto.ShowTaskbar;
        RaisePropertyChanged(nameof(TaskbarText));
        Language = dto.Language;
        ShowGluePosition = dto.ShowGluePosition;
        StartPageOptions = new ObservableCollection<string>(dto.StartPageOptions);
        LanguageOptions = new ObservableCollection<string>(dto.LanguageOptions);
        StatusMessage = string.Empty;
    }

    public async Task SaveAsync()
    {
        if (string.IsNullOrWhiteSpace(UpdateUrl))
        {
            StatusMessage = "自动更新URL不能为空";
            return;
        }

        var request = new SystemSettingsSaveRequest
        {
            UpdateUrl = UpdateUrl.Trim(),
            StartPage = StartPage,
            ShowTaskbar = _showTaskbar,
            Language = Language,
            ShowGluePosition = ShowGluePosition,
        };

        var result = await _api.PostAsync<ApiEmpty>("api/system/settings", request);
        StatusMessage = result.Success ? result.Message ?? "已保存配置" : result.Message ?? "保存失败";
    }
}
