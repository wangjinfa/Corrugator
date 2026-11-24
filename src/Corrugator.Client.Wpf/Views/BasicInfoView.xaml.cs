using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.System;
using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class BasicInfoView : UserControl
{
    public BasicInfoView()
    {
        InitializeComponent();

        // 数据字典子面板直接复用现有视图
        var dictionary = ContainerLocator.Container.Resolve<DictionaryViewModel>();
        _dictionary = dictionary;
        DictionaryHost.Content = new DictionaryView { DataContext = dictionary };

        var comm = ContainerLocator.Container.Resolve<CommViewModel>();
        _comm = comm;
        CommHost.Content = new CommView { DataContext = comm };

        var system = ContainerLocator.Container.Resolve<SystemSettingViewModel>();
        _system = system;
        SystemHost.Content = new SystemSettingView { DataContext = system };

        var apiAuth = ContainerLocator.Container.Resolve<ApiAuthViewModel>();
        _apiAuth = apiAuth;
        ApiAuthHost.Content = new ApiAuthView { DataContext = apiAuth };

        var orderColor = ContainerLocator.Container.Resolve<OrderColorViewModel>();
        _orderColor = orderColor;
        OrderColorHost.Content = new OrderColorView { DataContext = orderColor };

        var ipsPart = ContainerLocator.Container.Resolve<IpsPartViewModel>();
        _ipsPart = ipsPart;
        IpsPartHost.Content = new IpsPartView { DataContext = ipsPart };

        var lineFlute = ContainerLocator.Container.Resolve<LineFluteViewModel>();
        _lineFlute = lineFlute;
        LineFluteHost.Content = new LineFluteView { DataContext = lineFlute };

        var paper = ContainerLocator.Container.Resolve<PaperInfoViewModel>();
        _paper = paper;
        PaperHost.Content = new PaperInfoView { DataContext = paper };

        var team = ContainerLocator.Container.Resolve<TeamInfoViewModel>();
        _team = team;
        TeamHost.Content = new TeamInfoView { DataContext = team };

        var orderExt = ContainerLocator.Container.Resolve<OrderExtFieldViewModel>();
        _orderExt = orderExt;
        OrderExtHost.Content = new OrderExtFieldView { DataContext = orderExt };

        Loaded += async (_, _) => await LoadCurrentPanelAsync();
    }

    private BasicInfoViewModel? ViewModel => DataContext as BasicInfoViewModel;

    private DictionaryViewModel? _dictionary;

    private CommViewModel? _comm;

    private SystemSettingViewModel? _system;

    private ApiAuthViewModel? _apiAuth;

    private OrderColorViewModel? _orderColor;

    private IpsPartViewModel? _ipsPart;

    private OrderExtFieldViewModel? _orderExt;

    private LineFluteViewModel? _lineFlute;

    private PaperInfoViewModel? _paper;

    private TeamInfoViewModel? _team;

    private BasicInfoMenu? _lastMenu;

    /// <summary>点在分组标题上时回到上一个可选菜单，否则加载对应子页</summary>
    private async void OnMenuSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.AddedItems.Count == 0)
        {
            return;
        }

        if (e.AddedItems[0] is BasicInfoMenu menu && menu.IsGroup)
        {
            MenuList.SelectedItem = _lastMenu;
            return;
        }

        _lastMenu = ViewModel?.SelectedMenu;
        await LoadCurrentPanelAsync();
    }

    /// <summary>切换左侧菜单时把对应子页面数据加载起来</summary>
    private async Task LoadCurrentPanelAsync()
    {
        switch (ViewModel?.SelectedMenu?.Key)
        {
            case "lineFlute":
                if (_lineFlute is not null) await _lineFlute.LoadAsync();
                break;
            case "rawPaper":
                if (_paper is not null) await _paper.LoadAsync();
                break;
            case "team":
                if (_team is not null) await _team.LoadAsync();
                break;
            case "orderColor":
                if (_orderColor is not null) await _orderColor.LoadAsync();
                break;
            case "ipsPart":
                if (_ipsPart is not null) await _ipsPart.LoadAsync();
                break;
            case "orderExt":
                if (_orderExt is not null) await _orderExt.LoadAsync();
                break;
            case "api":
                if (_apiAuth is not null) await _apiAuth.LoadAsync();
                break;
            case "system":
                if (_system is not null) await _system.LoadAsync();
                break;
            case "comm":
                if (_comm is not null) await _comm.LoadCurrentTabAsync();
                break;
            default:
                break;
        }
    }

    private int SelectedNodeId
        => PermissionTree.SelectedItem is PermissionNodeDto node ? node.Id : 0;

    /// <summary>按当前左侧菜单刷新对应数据（角色/用户）</summary>
    private async void OnRefreshClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        switch (ViewModel.SelectedMenu?.Key)
        {
            case "user":
                await ViewModel.LoadUsersAsync();
                break;
            case "role":
                await ViewModel.LoadRolesAsync();
                break;
            default:
                break;
        }
    }

    // ===================== 用户管理 =====================

    private async void OnUserSearch(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadUsersAsync();
        }
    }

    private async void OnUserReset(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetUserQuery();
        await ViewModel.LoadUsersAsync();
    }

    private async void OnUserAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        await EnsureRoleAndTreeAsync();
        var dialog = new UserEditWindow(ViewModel, null, ViewModel.Roles.ToList(), ViewModel.MenuTree.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveUserAsync(null, dialog.Result);
        }
    }

    private async void OnUserEdit(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemUserDto row)
        {
            return;
        }

        await EnsureRoleAndTreeAsync();
        var dialog = new UserEditWindow(ViewModel, row, ViewModel.Roles.ToList(), ViewModel.MenuTree.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveUserAsync(row.SuId, dialog.Result);
        }
    }

    private async void OnUserDelete(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemUserDto row)
        {
            return;
        }

        var confirm = MessageBox.Show(
            $"确定删除用户「{row.UserName}（{row.Account}）」？删除后该账号将无法登录。",
            "删除确认",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteUserAsync(row.SuId);
        }
    }

    private async void OnUserClearCache(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemUserDto row)
        {
            return;
        }

        await ViewModel.ClearLoginCacheAsync(row.SuId);
    }

    /// <summary>用户编辑窗口需要角色列表与功能树，缺什么补什么</summary>
    private async Task EnsureRoleAndTreeAsync()
    {
        if (ViewModel is null)
        {
            return;
        }

        if (ViewModel.Roles.Count == 0)
        {
            await ViewModel.LoadRolesAsync();
        }

        if (ViewModel.MenuTree.Count == 0)
        {
            await ViewModel.LoadPermissionTreeAsync();
        }
    }

    // ===================== 角色管理 =====================

    /// <summary>新增角色 = 角色名称 + 权限绑定 一起维护</summary>
    private async void OnRoleAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        if (ViewModel.MenuTree.Count == 0)
        {
            await ViewModel.LoadPermissionTreeAsync();
        }

        var dialog = new RoleEditWindow(ViewModel, null, new List<int>()) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() != true || dialog.Result is null)
        {
            return;
        }

        var created = await ViewModel.SaveRoleAsync(null, new RoleSaveRequest { Name = dialog.Result.Name });
        if (created is not null)
        {
            await ViewModel.SaveRolePermissionsAsync(created.RoleId, dialog.Result.PermissionIds);
        }
    }

    /// <summary>权限绑定 / 修改：同一个弹窗，名称与树都可改</summary>
    private async void OnRoleGrant(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemRoleDto row)
        {
            return;
        }

        if (ViewModel.MenuTree.Count == 0)
        {
            await ViewModel.LoadPermissionTreeAsync();
        }

        var granted = await ViewModel.LoadRolePermissionsAsync(row.RoleId);
        var dialog = new RoleEditWindow(ViewModel, row, granted) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() != true || dialog.Result is null)
        {
            return;
        }

        var saved = await ViewModel.SaveRoleAsync(row.RoleId, new RoleSaveRequest { Name = dialog.Result.Name });
        if (saved is not null)
        {
            await ViewModel.SaveRolePermissionsAsync(row.RoleId, dialog.Result.PermissionIds);
        }
    }

    private async void OnRoleDelete(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemRoleDto row)
        {
            return;
        }

        var confirm = MessageBox.Show(
            $"确定删除角色「{row.Name}」？删除后该角色下用户将失去这些功能权限。",
            "删除确认",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteRoleAsync(row.RoleId);
        }
    }

    private async void OnRoleSearch(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadRolesAsync();
        }
    }

    private async void OnRoleReset(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetRoleQuery();
        await ViewModel.LoadRolesAsync();
    }

    // ===================== 功能管理 =====================

    private async void OnPermissionSearch(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadPermissionsAsync(SelectedNodeId);
        }
    }

    private async void OnPermissionReset(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetQuery();
        await ViewModel.LoadPermissionsAsync(0);
    }

    private async void OnPermissionNodeChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (ViewModel is null || e.NewValue is not PermissionNodeDto node)
        {
            return;
        }

        if (string.Equals(node.Type, "功能", StringComparison.Ordinal))
        {
            // 功能是叶子：直接按名称定位它自己
            ViewModel.QueryName = node.Name;
            ViewModel.ShowAll = false;
            await ViewModel.LoadPermissionsAsync(node.ParentId);
            return;
        }

        await ViewModel.LoadPermissionsAsync(node.Id);
    }

    private async void OnPermissionAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var dialog = new PermissionEditWindow(ViewModel, null, SelectedNodeId)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SavePermissionAsync(null, dialog.Result);
        }
    }

    private async void OnPermissionEdit(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemPermissionDto row)
        {
            return;
        }

        var dialog = new PermissionEditWindow(ViewModel, row, row.ParentId)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SavePermissionAsync(row.PermissionId, dialog.Result);
        }
    }

    private async void OnPermissionDelete(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not SystemPermissionDto row)
        {
            return;
        }

        var confirm = MessageBox.Show(
            $"确定删除「{row.Name}」？删除后同级菜单下的功能将不可用。",
            "删除确认",
            MessageBoxButton.OKCancel,
            MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeletePermissionAsync(row.PermissionId);
        }
    }
}
