using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class LineFluteView : UserControl
{
    public LineFluteView()
    {
        InitializeComponent();
    }

    private LineFluteViewModel? ViewModel => DataContext as LineFluteViewModel;

    private async void OnSearchClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.SearchAsync();
        }
    }

    private void OnResetClick(object sender, RoutedEventArgs e) => ViewModel?.Reset();

    private async void OnRefreshOrdersClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.RefreshOrdersAsync();
        }
    }

    private async void OnAddClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var row = new LineFluteRow { RowNo = ViewModel.Rows.Count + 1 };
        var dialog = new LineFluteEditWindow(row, isNew: true) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveAsync(dialog.Row, isNew: true);
        }
    }

    private async void OnEditRowClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not LineFluteRow source)
        {
            return;
        }

        var copy = LineFluteRow.FromDto(source.ToDto());
        copy.Id = source.Id;
        copy.RowNo = source.RowNo;

        var dialog = new LineFluteEditWindow(copy, isNew: false) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveAsync(dialog.Row, isNew: false);
        }
    }

    private async void OnDeleteRowClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not LineFluteRow row)
        {
            return;
        }

        var confirm = MessageBox.Show(Window.GetWindow(this),
            $"确定删除 门幅 {row.DoorWidth} / 楞型 {row.FluteType} 这条产线楞型吗？", "删除确认",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (confirm == MessageBoxResult.Yes)
        {
            await ViewModel.DeleteAsync(row);
        }
    }

    // 底部规则：改动即保存
    private async void OnRuleChanged(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.SaveRuleAsync();
        }
    }

    private async void OnRuleSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (ViewModel is null || e.AddedItems.Count == 0 || e.RemovedItems.Count == 0)
        {
            return;
        }

        await ViewModel.SaveRuleAsync();
    }
}
