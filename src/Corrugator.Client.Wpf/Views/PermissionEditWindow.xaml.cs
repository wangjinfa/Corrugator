using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.System;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

/// <summary>功能管理：新增/编辑菜单功能</summary>
public partial class PermissionEditWindow : Window
{
    private readonly BasicInfoViewModel _viewModel;
    private readonly SystemPermissionDto? _editing;

    /// <summary>父节点下拉用的是扁平化后的菜单列表</summary>
    private readonly List<PermissionNodeDto> _parents = new();

    public PermissionEditWindow(BasicInfoViewModel viewModel, SystemPermissionDto? editing, int defaultParentId)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _editing = editing;

        _parents.Add(new PermissionNodeDto { Id = 0, Name = "根节点" });
        Flatten(viewModel.MenuTree, _parents);

        ParentCombo.ItemsSource = _parents;
        ParentCombo.SelectedItem = _parents.FirstOrDefault(p => p.Id == (editing?.ParentId ?? defaultParentId)) ?? _parents[0];

        if (editing is null)
        {
            TitleText.Text = "新增菜单功能";
            SortInput.Text = "0";
        }
        else
        {
            TitleText.Text = "编辑菜单功能";
            NameInput.Text = editing.Name;
            NameSpaceInput.Text = editing.NameSpace ?? string.Empty;
            SortInput.Text = (editing.SortNo ?? 0).ToString();
            RemarkInput.Text = editing.Remark ?? string.Empty;

            foreach (var item in TypeCombo.Items.OfType<ComboBoxItem>())
            {
                if (string.Equals(item.Content?.ToString(), editing.Type, StringComparison.Ordinal))
                {
                    item.IsSelected = true;
                    break;
                }
            }
        }
    }

    private static void Flatten(IEnumerable<PermissionNodeDto> nodes, List<PermissionNodeDto> target, int depth = 0)
    {
        foreach (var node in nodes)
        {
            target.Add(new PermissionNodeDto { Id = node.Id, Name = new string(' ', 0) + node.Name, ParentId = depth });
            Flatten(node.Children, target, depth + 1);
        }
    }

    public PermissionSaveRequest? Result { get; private set; }

    private void OnSaveClick(object sender, RoutedEventArgs e)
    {
        var name = NameInput.Text?.Trim() ?? string.Empty;
        if (string.IsNullOrWhiteSpace(name))
        {
            ErrorText.Text = "名称不能为空";
            return;
        }

        var parent = (ParentCombo.SelectedItem as PermissionNodeDto)?.Id ?? 0;
        var type = (TypeCombo.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "功能";

        int.TryParse(SortInput.Text?.Trim(), out var sortNo);

        Result = new PermissionSaveRequest
        {
            Name = name,
            ParentId = parent,
            Type = type,
            NameSpace = string.IsNullOrWhiteSpace(NameSpaceInput.Text) ? null : NameSpaceInput.Text.Trim(),
            SortNo = sortNo,
            Remark = string.IsNullOrWhiteSpace(RemarkInput.Text) ? null : RemarkInput.Text.Trim(),
        };

        DialogResult = true;
        Close();
    }

    private void OnCancelClick(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
