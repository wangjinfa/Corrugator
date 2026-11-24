using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.System;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

/// <summary>
/// 角色管理-编辑：一个窗口同时维护「角色名称 + 权限绑定」（同现场 IPS）。
/// 确定后由调用方落库：先保存角色本身，再整组替换 S_Role_Permissions。
/// </summary>
public partial class RoleEditWindow : Window
{
    private readonly List<CheckNode> _roots = new();

    public RoleEditWindow(BasicInfoViewModel viewModel, SystemRoleDto? editing, List<int> grantedIds)
    {
        InitializeComponent();

        TitleText.Text = editing is null ? "角色管理-新增" : "角色管理-编辑";
        NameInput.Text = editing?.Name ?? string.Empty;

        foreach (var node in viewModel.MenuTree)
        {
            _roots.Add(Build(node, grantedIds));
        }

        PermissionTree.ItemsSource = _roots;
        UpdateSummary();
    }

    /// <summary>确定后的结果：角色名称 + 勾选的权限 ID</summary>
    public RoleEditResult? Result { get; private set; }

    private static CheckNode Build(PermissionNodeDto node, List<int> grantedIds)
    {
        var item = new CheckNode
        {
            Id = node.Id,
            Name = node.Name,
            Type = node.Type,
            IsChecked = grantedIds.Contains(node.Id),
        };

        foreach (var child in node.Children)
        {
            item.Children.Add(Build(child, grantedIds));
        }

        return item;
    }

    private static void Collect(IEnumerable<CheckNode> nodes, List<int> target)
    {
        foreach (var node in nodes)
        {
            if (node.IsChecked)
            {
                target.Add(node.Id);
            }

            Collect(node.Children, target);
        }
    }

    private void UpdateSummary()
    {
        var ids = new List<int>();
        Collect(_roots, ids);
        SummaryText.Text = $"已勾选 {ids.Count} 项";
    }

    private void OnConfirmClick(object sender, RoutedEventArgs e)
    {
        var name = NameInput.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
        {
            MessageBox.Show(this, "角色名称不能为空", "提示", MessageBoxButton.OK, MessageBoxImage.Warning);
            NameInput.Focus();
            return;
        }

        var ids = new List<int>();
        Collect(_roots, ids);

        Result = new RoleEditResult(name, ids);
        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    /// <summary>授权树节点：勾父不强制勾子，保存的就是实际勾选项</summary>
    public class CheckNode
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Type { get; set; } = "菜单";
        public bool IsChecked { get; set; }
        public List<CheckNode> Children { get; } = new();
    }
}

/// <summary>角色编辑结果</summary>
public class RoleEditResult
{
    public RoleEditResult(string name, List<int> permissionIds)
    {
        Name = name;
        PermissionIds = permissionIds;
    }

    public string Name { get; }

    public List<int> PermissionIds { get; }
}
