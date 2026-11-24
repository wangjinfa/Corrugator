using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.System;
using Prism.Mvvm;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

/// <summary>
/// 用户管理-编辑：三栏（用户详情 / 所属角色 / 可用功能）。
/// 可用功能由所选角色的权限合并得到，只读展示，避免和角色授权重叠维护。
/// </summary>
public partial class UserEditWindow : Window
{
    private readonly BasicInfoViewModel _viewModel;
    private readonly List<PermissionNodeDto> _permissionTree;
    private readonly SystemUserDto? _editing;

    private readonly ObservableCollection<RoleCheck> _roles = new();
    private bool _suppressRoleEvent;

    public UserEditWindow(BasicInfoViewModel viewModel, SystemUserDto? editing, List<SystemRoleDto> roles, List<PermissionNodeDto> permissionTree)
    {
        InitializeComponent();

        _viewModel = viewModel;
        _editing = editing;
        _permissionTree = permissionTree;

        TitleText.Text = editing is null ? "用户管理-新增" : "用户管理-编辑";

        _suppressRoleEvent = true;
        foreach (var role in roles)
        {
            _roles.Add(new RoleCheck
            {
                RoleId = role.RoleId,
                Name = role.Name,
                IsChecked = editing?.RoleIds.Contains(role.RoleId) ?? false,
            });
        }
        _suppressRoleEvent = false;
        RoleList.ItemsSource = _roles;

        if (editing is not null)
        {
            AccountInput.Text = editing.Account;
            UserNameInput.Text = editing.UserName;
            PhoneInput.Text = editing.PhoneNo ?? string.Empty;
            MultiLoginCheck.IsChecked = editing.IsMultiLine;
            DeletedCheck.IsChecked = editing.IsDeleted;
            CreatorInput.Text = editing.Creator ?? string.Empty;
            CreateTimeInput.Text = editing.CreateTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;
            EditorInput.Text = editing.Editor ?? string.Empty;
            EditTimeInput.Text = editing.EditTime?.ToString("yyyy-MM-dd HH:mm:ss") ?? string.Empty;

            foreach (var item in GenderInput.Items.OfType<ComboBoxItem>())
            {
                if (string.Equals(item.Content?.ToString(), editing.Gender, StringComparison.Ordinal))
                {
                    item.IsSelected = true;
                }
            }

            foreach (var item in StopPositionInput.Items.OfType<ComboBoxItem>())
            {
                if (string.Equals(item.Content?.ToString(), editing.StopPosition, StringComparison.Ordinal))
                {
                    item.IsSelected = true;
                }
            }

            HintText.Text = "密码留空表示不修改";
        }
        else
        {
            HintText.Text = "新增用户必须设置密码";
        }

        _ = RefreshFunctionsAsync();
    }

    /// <summary>确定后的结果</summary>
    public UserSaveRequest? Result { get; private set; }

    private List<int> SelectedRoleIds()
        => _roles.Where(r => r.IsChecked).Select(r => r.RoleId).ToList();

    /// <summary>勾角色后刷新「可用功能」（取并集）</summary>
    private async void OnRoleCheckChanged(object sender, RoutedEventArgs e)
    {
        if (_suppressRoleEvent)
        {
            return;
        }

        await RefreshFunctionsAsync();
    }

    private async Task RefreshFunctionsAsync()
    {
        var granted = new HashSet<int>();
        foreach (var role in SelectedRoleIds())
        {
            var ids = await _viewModel.LoadRolePermissionsAsync(role);
            foreach (var id in ids)
            {
                granted.Add(id);
            }
        }

        FunctionTree.ItemsSource = BuildTree(_permissionTree, granted);
    }

    private static List<FunctionNode> BuildTree(IEnumerable<PermissionNodeDto> nodes, HashSet<int> granted)
    {
        var list = new List<FunctionNode>();
        foreach (var node in nodes)
        {
            list.Add(new FunctionNode
            {
                Name = node.Name,
                Type = node.Type,
                IsChecked = granted.Contains(node.Id),
                Children = BuildTree(node.Children, granted),
            });
        }

        return list;
    }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var account = AccountInput.Text?.Trim() ?? string.Empty;
        var userName = UserNameInput.Text?.Trim() ?? string.Empty;

        if (string.IsNullOrWhiteSpace(account))
        {
            MessageBox.Show(this, "账号不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            AccountInput.Focus();
            return;
        }

        if (string.IsNullOrWhiteSpace(userName))
        {
            MessageBox.Show(this, "用户名不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            UserNameInput.Focus();
            return;
        }

        if (_editing is null && string.IsNullOrWhiteSpace(PasswordInput.Password))
        {
            MessageBox.Show(this, "新增用户必须设置密码", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            PasswordInput.Focus();
            return;
        }

        Result = new UserSaveRequest
        {
            Account = account,
            UserName = userName,
            Password = string.IsNullOrWhiteSpace(PasswordInput.Password) ? null : PasswordInput.Password,
            Gender = ReadComboText(GenderInput),
            PhoneNo = string.IsNullOrWhiteSpace(PhoneInput.Text) ? null : PhoneInput.Text.Trim(),
            StopPosition = ReadComboText(StopPositionInput),
            IsMultiLine = MultiLoginCheck.IsChecked == true,
            IsDeleted = DeletedCheck.IsChecked == true,
            RoleIds = SelectedRoleIds(),
        };

        DialogResult = true;
        Close();
    }

    private static string? ReadComboText(ComboBox combo)
    {
        var text = combo.Text?.Trim();
        if (!string.IsNullOrEmpty(text))
        {
            return text;
        }

        return combo.SelectedItem is ComboBoxItem item ? item.Content?.ToString() : null;
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    /// <summary>角色勾选项</summary>
    public class RoleCheck : BindableBase
    {
        private bool _isChecked;
        public int RoleId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsChecked
        {
            get => _isChecked;
            set => SetProperty(ref _isChecked, value);
        }
    }

    /// <summary>可用功能树节点（只读）</summary>
    public class FunctionNode
    {
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "菜单";
        public bool IsChecked { get; set; }
        public List<FunctionNode> Children { get; set; } = new();
    }
}
