using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Comm;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>通讯设置页（Prism）：配置设置 / 通讯设备 / 点位变量 三个页签</summary>
public class CommViewModel : BindableBase
{
    private readonly ApiClient _api;

    private int _selectedTab;
    private ObservableCollection<CommConfigDto> _configs = new();
    private CommConfigDto? _selectedConfig;
    private ObservableCollection<CommDeviceDto> _devices = new();
    private ObservableCollection<string> _deviceTypes = new();
    private ObservableCollection<CommConfigOption> _configOptions = new();
    private string _deviceQueryName = string.Empty;
    private string _deviceTypeFilter = string.Empty;
    private string _deviceConfigFilter = string.Empty;
    private string _pointPositionFilter = string.Empty;
    private string _pointDeviceFilter = string.Empty;
    private CommPointOptions _pointOptions = new();
    private ObservableCollection<CommPointDto> _points = new();
    private ObservableCollection<string> _parCodes = new();
    private string _configQueryName = string.Empty;
    private string _parCodeFilter = string.Empty;
    private bool _showAll;
    private string _statusMessage = string.Empty;

    public CommViewModel(ApiClient api)
    {
        _api = api;
    }

    /// <summary>0 配置设置 / 1 通讯设备 / 2 点位变量</summary>
    public int SelectedTab
    {
        get => _selectedTab;
        set
        {
            if (!SetProperty(ref _selectedTab, value))
            {
                return;
            }

            RaisePropertyChanged(nameof(ConfigTabVisibility));
            RaisePropertyChanged(nameof(DeviceTabVisibility));
            RaisePropertyChanged(nameof(PointTabVisibility));
            _ = LoadCurrentTabAsync();
        }
    }

    public System.Windows.Visibility ConfigTabVisibility
        => SelectedTab == 0 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

    public System.Windows.Visibility DeviceTabVisibility
        => SelectedTab == 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

    public System.Windows.Visibility PointTabVisibility
        => SelectedTab == 2 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;

    public ObservableCollection<CommConfigDto> Configs
    {
        get => _configs;
        set => SetProperty(ref _configs, value);
    }

    public CommConfigDto? SelectedConfig
    {
        get => _selectedConfig;
        set => SetProperty(ref _selectedConfig, value);
    }

    public ObservableCollection<CommDeviceDto> Devices
    {
        get => _devices;
        set => SetProperty(ref _devices, value);
    }

    /// <summary>通讯设备查询：设备/配置名称</summary>
    public string DeviceQueryName
    {
        get => _deviceQueryName;
        set => SetProperty(ref _deviceQueryName, value);
    }

    /// <summary>通讯设备查询：通讯类型</summary>
    public string DeviceTypeFilter
    {
        get => _deviceTypeFilter;
        set => SetProperty(ref _deviceTypeFilter, value);
    }

    /// <summary>通讯设备查询：通讯配置</summary>
    public string DeviceConfigFilter
    {
        get => _deviceConfigFilter;
        set => SetProperty(ref _deviceConfigFilter, value);
    }

    /// <summary>通讯类型下拉（协议驱动）</summary>
    public ObservableCollection<string> DeviceTypes
    {
        get => _deviceTypes;
        set => SetProperty(ref _deviceTypes, value);
    }

    /// <summary>通讯配置下拉（配置表去重）</summary>
    public ObservableCollection<CommConfigOption> ConfigOptions
    {
        get => _configOptions;
        set => SetProperty(ref _configOptions, value);
    }

    /// <summary>点位查询：部位</summary>
    public string PointPositionFilter
    {
        get => _pointPositionFilter;
        set => SetProperty(ref _pointPositionFilter, value);
    }

    /// <summary>点位查询：所属设备</summary>
    public string PointDeviceFilter
    {
        get => _pointDeviceFilter;
        set => SetProperty(ref _pointDeviceFilter, value);
    }

    /// <summary>点位页下拉集合</summary>
    public CommPointOptions PointOptions
    {
        get => _pointOptions;
        set => SetProperty(ref _pointOptions, value);
    }

    public ObservableCollection<CommPointDto> Points
    {
        get => _points;
        set => SetProperty(ref _points, value);
    }

    public ObservableCollection<string> ParCodes
    {
        get => _parCodes;
        set => SetProperty(ref _parCodes, value);
    }

    /// <summary>查询条件：配置名称</summary>
    public string ConfigQueryName
    {
        get => _configQueryName;
        set => SetProperty(ref _configQueryName, value);
    }

    /// <summary>查询条件：参数编码</summary>
    public string ParCodeFilter
    {
        get => _parCodeFilter;
        set => SetProperty(ref _parCodeFilter, value);
    }

    public bool ShowAll
    {
        get => _showAll;
        set => SetProperty(ref _showAll, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public async Task LoadCurrentTabAsync()
    {
        switch (SelectedTab)
        {
            case 1:
                await LoadDevicesAsync();
                break;
            case 2:
                await LoadPointsAsync();
                break;
            default:
                await LoadConfigsAsync();
                break;
        }
    }

    public async Task LoadConfigsAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["name"] = string.IsNullOrWhiteSpace(ConfigQueryName) ? null : ConfigQueryName.Trim(),
            ["parCode"] = string.IsNullOrWhiteSpace(ParCodeFilter) ? null : ParCodeFilter.Trim(),
            ["showAll"] = ShowAll ? "true" : "false",
        };

        var result = await _api.GetAsync<List<CommConfigDto>>("api/comm/configs", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "通讯配置加载失败";
            return;
        }

        Configs = new ObservableCollection<CommConfigDto>(result.Data);
        StatusMessage = $"通讯配置 {Configs.Count} 条";
        await LoadParCodesAsync();
    }

    private async Task LoadParCodesAsync()
    {
        var result = await _api.GetAsync<List<string>>("api/comm/par-codes");
        if (result.Success && result.Data is not null)
        {
            ParCodes = new ObservableCollection<string>(result.Data);
        }
    }

    public async Task LoadDevicesAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["name"] = string.IsNullOrWhiteSpace(DeviceQueryName) ? null : DeviceQueryName.Trim(),
            ["commType"] = string.IsNullOrWhiteSpace(DeviceTypeFilter) ? null : DeviceTypeFilter.Trim(),
            ["config"] = string.IsNullOrWhiteSpace(DeviceConfigFilter) ? null : DeviceConfigFilter.Trim(),
            ["showAll"] = ShowAll ? "true" : "false",
        };

        var result = await _api.GetAsync<List<CommDeviceDto>>("api/comm/devices", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "通讯设备加载失败";
            return;
        }

        Devices = new ObservableCollection<CommDeviceDto>(result.Data);
        StatusMessage = $"通讯设备 {Devices.Count} 个";

        await LoadDeviceOptionsAsync();
    }

    /// <summary>通讯类型 + 通讯配置下拉</summary>
    public async Task LoadDeviceOptionsAsync()
    {
        if (DeviceTypes.Count == 0)
        {
            var types = await _api.GetAsync<List<string>>("api/comm/device-types");
            if (types.Success && types.Data is not null)
            {
                DeviceTypes = new ObservableCollection<string>(types.Data);
            }
        }

        if (ConfigOptions.Count == 0)
        {
            var options = await _api.GetAsync<List<CommConfigOption>>("api/comm/config-options");
            if (options.Success && options.Data is not null)
            {
                ConfigOptions = new ObservableCollection<CommConfigOption>(options.Data);
            }
        }
    }

    public void ResetDeviceQuery()
    {
        DeviceQueryName = string.Empty;
        DeviceTypeFilter = string.Empty;
        DeviceConfigFilter = string.Empty;
    }

    public async Task<bool> SaveDeviceAsync(long? id, CommDeviceSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<CommDeviceDto>("api/comm/devices", request)
            : await _api.PutAsync<CommDeviceDto>($"api/comm/devices/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadDevicesAsync();
        return true;
    }

    public async Task DeleteDevicesAsync(IEnumerable<long> ids)
    {
        var list = ids.ToList();
        if (list.Count == 0)
        {
            StatusMessage = "请先勾选要删除的记录";
            return;
        }

        var request = new BatchDeleteRequest { Ids = list };
        var result = await _api.PostAsync<ApiEmpty>("api/comm/devices/batch-delete", request);
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await LoadDevicesAsync();
        }
    }

    public async Task LoadPointsAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["position"] = string.IsNullOrWhiteSpace(PointPositionFilter) ? null : PointPositionFilter.Trim(),
            ["device"] = string.IsNullOrWhiteSpace(PointDeviceFilter) ? null : PointDeviceFilter.Trim(),
            ["showAll"] = ShowAll ? "true" : "false",
        };

        var result = await _api.GetAsync<List<CommPointDto>>("api/comm/points", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "点位变量加载失败";
            return;
        }

        Points = new ObservableCollection<CommPointDto>(result.Data);
        StatusMessage = $"点位变量 {Points.Count} 个";

        await LoadPointOptionsAsync();
    }

    /// <summary>部位 / 所属设备 / 数据类型 / 可读可写下拉</summary>
    public async Task LoadPointOptionsAsync()
    {
        var options = await _api.GetAsync<CommPointOptions>("api/comm/point-options");
        if (options.Success && options.Data is not null)
        {
            PointOptions = options.Data;
        }
    }

    public void ResetPointQuery()
    {
        PointPositionFilter = string.Empty;
        PointDeviceFilter = string.Empty;
    }

    public async Task<bool> SavePointAsync(long? id, CommPointSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<CommPointDto>("api/comm/points", request)
            : await _api.PutAsync<CommPointDto>($"api/comm/points/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadPointsAsync();
        return true;
    }

    public async Task DeletePointsAsync(IEnumerable<long> ids)
    {
        var list = ids.ToList();
        if (list.Count == 0)
        {
            StatusMessage = "请先勾选要删除的记录";
            return;
        }

        var result = await _api.PostAsync<ApiEmpty>("api/comm/points/batch-delete", new BatchDeleteRequest { Ids = list });
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await LoadPointsAsync();
        }
    }

    public void ResetQuery()
    {
        ConfigQueryName = string.Empty;
        ParCodeFilter = string.Empty;
        ShowAll = false;
    }

    public async Task<bool> SaveConfigAsync(long? id, CommConfigSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<CommConfigDto>("api/comm/configs", request)
            : await _api.PutAsync<CommConfigDto>($"api/comm/configs/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadConfigsAsync();
        return true;
    }

    public async Task DeleteConfigsAsync(IEnumerable<long> ids)
    {
        var list = ids.ToList();
        if (list.Count == 0)
        {
            StatusMessage = "请先勾选要删除的记录";
            return;
        }

        var request = new BatchDeleteRequest { Ids = list };
        var result = await _api.PostAsync<ApiEmpty>("api/comm/configs/batch-delete", request);
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (result.Success)
        {
            await LoadConfigsAsync();
        }
    }

    public async Task ReloadAsync()
    {
        var result = await _api.PostAsync<ApiEmpty>("api/comm/reload", null);
        StatusMessage = result.Success ? result.Message ?? "已生效" : result.Message ?? "生效失败";
    }
}
