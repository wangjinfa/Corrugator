using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.Dictionary;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class DictionaryView : UserControl
{
    public DictionaryView()
    {
        InitializeComponent();
    }

    private DictionaryViewModel? ViewModel => DataContext as DictionaryViewModel;

    private void OnTypeSelected(object sender, RoutedPropertyChangedEventArgs<object> e)
    {
        if (ViewModel is not null)
        {
            ViewModel.SelectedNode = e.NewValue as DictTypeNode;
        }
    }

    private async void OnTypeAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var parent = ViewModel.SelectedNode;
        var parentId = parent is null || parent.IsRoot ? (int?)null : parent.Id;
        var parentLabel = parent is null || parent.IsRoot ? "根目录" : parent.Label;

        var dialog = new DictTypeEditWindow(parentLabel, parentId, null, null)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveNodeAsync(null, new DictTypeSaveRequest
            {
                WPD_PID = parentId,
                WPD_Name = dialog.ResultName,
                WPD_Code = dialog.ResultCode,
            });
        }
    }

    private async void OnTypeEdit(object sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedNode is null || ViewModel.SelectedNode.IsRoot)
        {
            return;
        }

        var node = ViewModel.SelectedNode;
        var dialog = new DictTypeEditWindow(node.ParentId is null or 0 ? "根目录" : "上级分类", node.ParentId, node.Name, node.Code)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveNodeAsync(node.Id, new DictTypeSaveRequest
            {
                WPD_PID = node.ParentId is null or 0 ? null : node.ParentId,
                WPD_Name = dialog.ResultName,
                WPD_Code = dialog.ResultCode,
            });
        }
    }

    private async void OnTypeDelete(object sender, RoutedEventArgs e)
    {
        if (ViewModel?.SelectedNode is null || ViewModel.SelectedNode.IsRoot)
        {
            return;
        }

        var node = ViewModel.SelectedNode;
        var confirm = MessageBox.Show($"确定删除分类「{node.Label}」？", "删除确认",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteNodeAsync(node.Id);
        }
    }

    private async void OnDataAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        if (ViewModel.CurrentTypeId <= 0)
        {
            MessageBox.Show(Window.GetWindow(this), "请先在左侧选择一个字典分类", "提示",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var dialog = new DictDataEditWindow(ViewModel.CurrentTypeId, ViewModel.SelectedNode?.Label ?? string.Empty, null)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveDetailAsync(null, dialog.Result);
        }
    }

    private async void OnDataEdit(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not DictDataDto row)
        {
            return;
        }

        if (ViewModel.CurrentTypeId <= 0)
        {
            return;
        }

        var dialog = new DictDataEditWindow(ViewModel.CurrentTypeId, ViewModel.SelectedNode?.Label ?? string.Empty, row)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveDetailAsync(row.WPD_ID, dialog.Result);
        }
    }

    private async void OnDataDelete(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not DictDataDto row)
        {
            return;
        }

        var confirm = MessageBox.Show($"确定删除字典明细「{row.WPD_ChineseName ?? row.WPD_Value}」？", "删除确认",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);
        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteDetailAsync(row.WPD_ID);
        }
    }
}
