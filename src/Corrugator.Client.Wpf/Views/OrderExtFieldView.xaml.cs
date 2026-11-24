using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Corrugator.Client.Wpf.Views;

public partial class OrderExtFieldView : UserControl
{
    public OrderExtFieldView()
    {
        InitializeComponent();
    }

    private async Task SaveAsync()
    {
        if (DataContext is OrderExtFieldViewModel viewModel)
        {
            await viewModel.SaveAsync();
        }
    }

    private async void OnRefreshClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is OrderExtFieldViewModel viewModel)
        {
            await viewModel.LoadAsync();
        }
    }

    private void OnCellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
    {
        // 等编辑值落盘（绑定为 LostFocus）后再自动保存
        Dispatcher.BeginInvoke(new Action(async () => await SaveAsync()), DispatcherPriority.Background);
    }

    private async void OnTypeChanged(object sender, SelectionChangedEventArgs e)
    {
        // 绑定刚落盘时的首次选中不算改动
        if (e.AddedItems.Count == 0 || e.RemovedItems.Count == 0)
        {
            return;
        }

        await SaveAsync();
    }

    private async void OnCheckChanged(object sender, RoutedEventArgs e) => await SaveAsync();
}
