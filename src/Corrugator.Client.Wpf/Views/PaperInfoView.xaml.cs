using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class PaperInfoView : UserControl
{
    public PaperInfoView()
    {
        InitializeComponent();
    }

    private PaperInfoViewModel? ViewModel => DataContext as PaperInfoViewModel;

    private async void OnSearchClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.SearchAsync();
        }
    }

    private void OnResetClick(object sender, RoutedEventArgs e) => ViewModel?.Reset();

    private async void OnAddClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var dialog = new PaperEditWindow(new PaperRow(), isNew: true) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveAsync(dialog.Row, isNew: true);
        }
    }

    private async void OnEditRowClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not PaperRow source)
        {
            return;
        }

        var dialog = new PaperEditWindow(PaperRow.FromDto(source.ToDto()), isNew: false)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveAsync(dialog.Row, isNew: false);
        }
    }

    private async void OnDeleteRowClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not PaperRow row)
        {
            return;
        }

        var confirm = MessageBox.Show(Window.GetWindow(this), $"确定删除原纸 {row.Code} 吗？", "删除确认",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (confirm == MessageBoxResult.Yes)
        {
            await ViewModel.DeleteAsync(row);
        }
    }

    private async void OnDetailClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not PaperRow row)
        {
            return;
        }

        var info = await ViewModel.LoadBrandInfoAsync(row.Code);
        if (info is null)
        {
            MessageBox.Show(Window.GetWindow(this), ViewModel.StatusMessage, "原纸品牌信息",
                MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var dialog = new PaperBrandWindow(row.Code, info, ViewModel) { Owner = Window.GetWindow(this) };
        dialog.ShowDialog();
    }
}
