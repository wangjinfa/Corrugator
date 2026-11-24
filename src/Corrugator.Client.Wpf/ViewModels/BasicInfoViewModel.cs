using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>基础信息页左侧菜单项</summary>
public class BasicInfoMenu
{
    public BasicInfoMenu(string key, string text, bool isGroup = false)
    {
        Key = key;
        Text = text;
        IsGroup = isGroup;
    }

    public string Key { get; }
    public string Text { get; }

    /// <summary>分组标题（只显示不可选）</summary>
    public bool IsGroup { get; }
}

/// <summary>
/// 基础信息页（Prism）：左侧系统设置菜单，右侧按选中项切换内容。
/// 功能/角色/用户/权限数据来自 BaseDB 公共表（已并入 IPS 库）。
/// </summary>
public class BasicInfoViewModel : BindableBase
{
    private readonly ApiClient _api;
    private readonly AppSession _session;

    private BasicInfoMenu? _selectedMenu;
    private ObservableCollection<SystemUserDto> _users = new();
    private ObservableCollection<SystemRoleDto> _roles = new();
    private ObservableCollection<SystemPermissionDto> _permissions = new();
    private PermissionNodeDto? _selectedNode;
    private string _queryName = string.Empty;
    private bool _showAll;
    private string _roleQueryName = string.Empty;
    private string _userQueryName = string.Empty;
    private bool _showAllUsers;
    private string _statusMessage = string.Empty;
    private string _placeholderText = string.Empty;

    private int _currentParentId;

    /// <summary>true=独立系统设置窗口（只列系统设置 12 项）；false=基础信息页（只列基础信息 11 项）</summary>
    private readonly bool _settingsOnly;

    public BasicInfoViewModel(ApiClient api, AppSession session, bool settingsOnly = false)
    {
        _api = api;
        _session = session;
        _settingsOnly = settingsOnly;
        _menu = new ObservableCollection<BasicInfoMenu>(
            (_settingsOnly ? SystemMenus : BaseMenus).ToList());

        // 默认选中当前模式下第一项，避免进页面是空白占位
        _selectedMenu = _menu.FirstOrDefault(m => !m.IsGroup);
    }

    /// <summary>进入页面：按默认/当前菜单加载对应子页数据</summary>
    public async Task InitializeAsync()
    {
        await LoadForAsync(SelectedMenu?.Key);
    }

    // 基础信息组菜单
    private static readonly BasicInfoMenu[] BaseMenus =
    {
        new("group.base", "基础信息", isGroup: true),
        new("lineFlute", "产线楞型"),
        new("rawPaper", "原纸资料"),
        new("team", "班组资料"),
        new("fluteOffset", "楞型错位资料"),
        new("baseFlute", "基础楞型资料"),
        new("corrFlute", "瓦线楞型配置"),
        new("prodRoute", "生产路线"),
        new("stopReason", "停机原因维护"),
        new("knife", "刀头作业管理"),
        new("energy", "能耗粉耗配置"),
        new("prodTarget", "生产目标值设置"),
    };

    // 系统设置组菜单（独立窗口使用）
    private static readonly BasicInfoMenu[] SystemMenus =
    {
        new("group.system", "系统设置", isGroup: true),
        new("function", "功能管理"),
        new("role", "角色管理"),
        new("user", "用户管理"),
        new("dict", "数据字典"),
        new("comm", "通讯设置"),
        new("system", "系统设置"),
        new("api", "API授权"),
        new("profile", "个人信息"),
        new("orderColor", "订单颜色设置"),
        new("ipsPart", "IPS部位显示/隐藏"),
        new("orderExt", "订单扩展字段设置"),
        new("printLabel", "打印标签设置"),
    };

    private readonly ObservableCollection<BasicInfoMenu> _menu;

    public ObservableCollection<BasicInfoMenu> Menu => _menu;

    public BasicInfoMenu? SelectedMenu
    {
        get => _selectedMenu;
        set
        {
            if (value?.IsGroup == true)
            {
                return;
            }

            if (!SetProperty(ref _selectedMenu, value))
            {
                return;
            }

            RaisePropertyChanged(nameof(UsersVisibility));
            RaisePropertyChanged(nameof(RolesVisibility));
            RaisePropertyChanged(nameof(PermissionsVisibility));
            RaisePropertyChanged(nameof(DictionaryVisibility));
            RaisePropertyChanged(nameof(ProfileVisibility));
            RaisePropertyChanged(nameof(CommVisibility));
            RaisePropertyChanged(nameof(SystemVisibility));
            RaisePropertyChanged(nameof(ApiAuthVisibility));
            RaisePropertyChanged(nameof(OrderColorVisibility));
            RaisePropertyChanged(nameof(IpsPartVisibility));
            RaisePropertyChanged(nameof(OrderExtVisibility));
            RaisePropertyChanged(nameof(LineFluteVisibility));
            RaisePropertyChanged(nameof(PaperVisibility));
            RaisePropertyChanged(nameof(TeamVisibility));
            RaisePropertyChanged(nameof(PlaceholderVisibility));

            PlaceholderText = value?.Key switch
            {
                "team" => "班组资料：班组编号、班次与人员（按现场截图复刻，待图片）",
                "fluteOffset" => "楞型错位资料：各楞型错位量基础表（按现场截图复刻，待图片）",
                "baseFlute" => "基础楞型资料：楞型基础参数（按现场截图复刻，待图片）",
                "corrFlute" => "瓦线楞型配置：瓦线—楞型—机台对应关系（按现场截图复刻，待图片）",
                "prodRoute" => "生产路线：工单按机台/瓦线的走线规则（按现场截图复刻，待图片）",
                "stopReason" => "停机原因维护：停机代码、原因分类与统计口径（按现场截图复刻，待图片）",
                "knife" => "刀头作业管理：纵切/横切刀头排刀与作业记录（按现场截图复刻，待图片）",
                "energy" => "能耗粉耗配置：电/汽/淀粉单耗基准与统计口径（按现场截图复刻，待图片）",
                "prodTarget" => "生产目标值设置：产量、车速、损耗目标值（按现场截图复刻，待图片）",
                "comm" => "通讯设置：PLC / OPC UA 网关地址、采集周期与心跳（待接入设备后开放）",
                "orderExt" => "订单扩展字段设置：订单表自定义字段的增删与显示顺序",
                "printLabel" => "打印标签设置：成品标签模板、打印端口与扫码规则",
                _ => string.Empty,
            };

            _ = LoadForAsync(value?.Key);
        }
    }

    public ObservableCollection<SystemUserDto> Users
    {
        get => _users;
        set => SetProperty(ref _users, value);
    }

    public ObservableCollection<SystemRoleDto> Roles
    {
        get => _roles;
        set => SetProperty(ref _roles, value);
    }

    public ObservableCollection<SystemPermissionDto> Permissions
    {
        get => _permissions;
        set => SetProperty(ref _permissions, value);
    }

    /// <summary>功能管理左侧菜单树</summary>
    public ObservableCollection<PermissionNodeDto> MenuTree { get; } = new();

    public PermissionNodeDto? SelectedNode
    {
        get => _selectedNode;
        set => SetProperty(ref _selectedNode, value);
    }

    /// <summary>查询条件：菜单名称</summary>
    public string QueryName
    {
        get => _queryName;
        set => SetProperty(ref _queryName, value);
    }

    /// <summary>查询条件：显示全部（含已删除）</summary>
    public bool ShowAll
    {
        get => _showAll;
        set => SetProperty(ref _showAll, value);
    }

    /// <summary>角色管理查询条件：角色名称</summary>
    public string RoleQueryName
    {
        get => _roleQueryName;
        set => SetProperty(ref _roleQueryName, value);
    }

    /// <summary>用户管理查询条件：用户姓名</summary>
    public string UserQueryName
    {
        get => _userQueryName;
        set => SetProperty(ref _userQueryName, value);
    }

    /// <summary>用户管理：显示全部（含已删除）</summary>
    public bool ShowAllUsers
    {
        get => _showAllUsers;
        set => SetProperty(ref _showAllUsers, value);
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set => SetProperty(ref _statusMessage, value);
    }

    public string PlaceholderText
    {
        get => _placeholderText;
        set => SetProperty(ref _placeholderText, value);
    }

    // 右侧各面板的显示开关
    public Visibility UsersVisibility => SelectedMenu?.Key == "user" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility RolesVisibility => SelectedMenu?.Key == "role" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility PermissionsVisibility => SelectedMenu?.Key == "function" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility DictionaryVisibility => SelectedMenu?.Key == "dict" ? Visibility.Visible : Visibility.Collapsed;
    public Visibility ProfileVisibility => SelectedMenu?.Key == "profile" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility CommVisibility => SelectedMenu?.Key == "comm" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility SystemVisibility => SelectedMenu?.Key == "system" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility ApiAuthVisibility => SelectedMenu?.Key == "api" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility OrderColorVisibility => SelectedMenu?.Key == "orderColor" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility IpsPartVisibility => SelectedMenu?.Key == "ipsPart" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility OrderExtVisibility => SelectedMenu?.Key == "orderExt" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility LineFluteVisibility => SelectedMenu?.Key == "lineFlute" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility PaperVisibility => SelectedMenu?.Key == "rawPaper" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility TeamVisibility => SelectedMenu?.Key == "team" ? Visibility.Visible : Visibility.Collapsed;

    public Visibility PlaceholderVisibility
    {
        get
        {
            var key = SelectedMenu?.Key;
            var known = key is "user" or "role" or "function" or "dict" or "profile" or "comm" or "system" or "api" or "orderColor" or "ipsPart" or "orderExt" or "lineFlute" or "rawPaper" or "team";
            return key is null || known ? Visibility.Collapsed : Visibility.Visible;
        }
    }

    public string UserAccount => _session.User?.UserName ?? "-";
    public string UserDisplayName => _session.User?.DisplayName ?? "-";

    public string UserRoleText => _session.User is null
        ? "-"
        : string.Join(" / ", _session.User.Roles.Count > 0 ? _session.User.Roles : new List<string> { _session.User.Role });

    public string UserPermissionText => _session.User is null ? "-" : string.Join("  ·  ", _session.User.Permissions);
    public string UserMultiLineText => _session.User?.IsMultiLine == true ? "已开通（可切换多瓦线）" : "未开通（仅默认瓦线）";
    public string ServerText => AppConfig.BaseUrl;

    private async Task LoadForAsync(string? key)
    {
        try
        {
            switch (key)
            {
                case "user":
                    await LoadUsersAsync();
                    break;
                case "role":
                    // 角色编辑窗口需要功能树，进页面就先备好
                    if (MenuTree.Count == 0)
                    {
                        await LoadPermissionTreeAsync();
                    }

                    await LoadRolesAsync();
                    break;
                case "function":
                    await LoadPermissionPageAsync();
                    break;
                case "profile":
                    RefreshProfile();
                    break;
                default:
                    break;
            }
        }
        catch (Exception ex)
        {
            StatusMessage = $"加载失败：{ex.Message}";
        }
    }

    public async Task LoadUsersAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["name"] = string.IsNullOrWhiteSpace(UserQueryName) ? null : UserQueryName.Trim(),
            ["showAll"] = ShowAllUsers ? "true" : "false",
        };

        var result = await _api.GetAsync<List<SystemUserDto>>("api/system/users", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "用户列表加载失败";
            return;
        }

        var index = 0;
        foreach (var user in result.Data)
        {
            user.RowNo = ++index;
        }

        Users = new ObservableCollection<SystemUserDto>(result.Data);
        StatusMessage = $"用户 {Users.Count} 个";
    }

    public void ResetUserQuery()
    {
        UserQueryName = string.Empty;
        ShowAllUsers = false;
    }

    /// <summary>新增或修改用户；成功返回用户数据</summary>
    public async Task<SystemUserDto?> SaveUserAsync(int? id, UserSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<SystemUserDto>("api/system/users", request)
            : await _api.PutAsync<SystemUserDto>($"api/system/users/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return null;
        }

        await LoadUsersAsync();
        return result.Data;
    }

    public async Task<bool> DeleteUserAsync(int id)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/system/users/{id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadUsersAsync();
        return true;
    }

    public async Task ClearLoginCacheAsync(int id)
    {
        var result = await _api.PostAsync<ApiEmpty>($"api/system/users/{id}/clear-login-cache", null);
        StatusMessage = result.Success ? result.Message ?? "已清理" : result.Message ?? "清理失败";
    }

    public async Task LoadRolesAsync()
    {
        var query = new Dictionary<string, string?>
        {
            ["name"] = string.IsNullOrWhiteSpace(RoleQueryName) ? null : RoleQueryName.Trim(),
        };

        var result = await _api.GetAsync<List<SystemRoleDto>>("api/system/roles", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "角色列表加载失败";
            return;
        }

        Roles = new ObservableCollection<SystemRoleDto>(result.Data);
        StatusMessage = $"角色 {Roles.Count} 个";
    }

    /// <summary>功能管理整页：先加载菜单树，再按当前查询条件加载列表</summary>
    public async Task LoadPermissionPageAsync()
    {
        await LoadPermissionTreeAsync();
        await LoadPermissionsAsync(_currentParentId);
    }

    public async Task LoadPermissionTreeAsync()
    {
        var result = await _api.GetAsync<List<PermissionNodeDto>>("api/system/permissions/tree");
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "菜单树加载失败";
            return;
        }

        MenuTree.Clear();
        foreach (var node in result.Data)
        {
            MenuTree.Add(node);
        }
    }

    public async Task LoadPermissionsAsync(int parentId)
    {
        _currentParentId = parentId;

        var query = new Dictionary<string, string?>
        {
            ["name"] = string.IsNullOrWhiteSpace(QueryName) ? null : QueryName.Trim(),
            ["showAll"] = ShowAll ? "true" : "false",
            ["parentId"] = parentId.ToString(),
        };

        var result = await _api.GetAsync<List<SystemPermissionDto>>("api/system/permissions", query);
        if (!result.Success || result.Data is null)
        {
            StatusMessage = result.Message ?? "功能列表加载失败";
            return;
        }

        Permissions = new ObservableCollection<SystemPermissionDto>(result.Data);
        StatusMessage = $"功能权限 {Permissions.Count} 条";
    }

    public void ResetQuery()
    {
        QueryName = string.Empty;
        ShowAll = false;
    }

    public void ResetRoleQuery()
    {
        RoleQueryName = string.Empty;
    }

    /// <summary>新增或修改角色；成功返回角色数据（新增时带回自增 ID）</summary>
    public async Task<SystemRoleDto?> SaveRoleAsync(int? id, RoleSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<SystemRoleDto>("api/system/roles", request)
            : await _api.PutAsync<SystemRoleDto>($"api/system/roles/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return null;
        }

        await LoadRolesAsync();
        return result.Data;
    }

    public async Task<bool> DeleteRoleAsync(int id)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/system/roles/{id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadRolesAsync();
        return true;
    }

    public async Task<List<int>> LoadRolePermissionsAsync(int roleId)
    {
        var result = await _api.GetAsync<RolePermissionsDto>($"api/system/roles/{roleId}/permissions");
        return result.Success && result.Data is not null
            ? result.Data.PermissionIds
            : new List<int>();
    }

    public async Task<bool> SaveRolePermissionsAsync(int roleId, List<int> permissionIds)
    {
        var result = await _api.PutAsync<ApiEmpty>(
            $"api/system/roles/{roleId}/permissions",
            new RolePermissionSaveRequest { PermissionIds = permissionIds });

        StatusMessage = result.Success ? result.Message ?? "已保存授权" : result.Message ?? "授权保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadRolesAsync();
        return true;
    }

    /// <summary>新增或修改一条菜单/功能；id 为空是新增</summary>
    public async Task<bool> SavePermissionAsync(int? id, PermissionSaveRequest request)
    {
        var result = id is null
            ? await _api.PostAsync<SystemPermissionDto>("api/system/permissions", request)
            : await _api.PutAsync<SystemPermissionDto>($"api/system/permissions/{id}", request);

        StatusMessage = result.Success ? result.Message ?? "已保存" : result.Message ?? "保存失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadPermissionPageAsync();
        return true;
    }

    public async Task<bool> DeletePermissionAsync(int id)
    {
        var result = await _api.DeleteAsync<ApiEmpty>($"api/system/permissions/{id}");
        StatusMessage = result.Success ? result.Message ?? "已删除" : result.Message ?? "删除失败";
        if (!result.Success)
        {
            return false;
        }

        await LoadPermissionPageAsync();
        return true;
    }

    private void RefreshProfile()
    {
        RaisePropertyChanged(nameof(UserAccount));
        RaisePropertyChanged(nameof(UserDisplayName));
        RaisePropertyChanged(nameof(UserRoleText));
        RaisePropertyChanged(nameof(UserPermissionText));
        RaisePropertyChanged(nameof(UserMultiLineText));
        RaisePropertyChanged(nameof(ServerText));
        StatusMessage = "个人信息已刷新";
    }
}
