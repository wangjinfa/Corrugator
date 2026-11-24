using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class TeamInfoView : UserControl
{
    public TeamInfoView()
    {
        InitializeComponent();
    }

    private TeamInfoViewModel? ViewModel => DataContext as TeamInfoViewModel;

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

        var dialog = new TeamEditWindow(new TeamRow(), isNew: true) { Owner = Window.GetWindow(this) };
        if (dialog.ShowDialog() == true)
        {
            await ViewModel.SaveAsync(dialog.Row, isNew: true);
        }
    }

    private async void OnEditRowClick(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not TeamRow source)
        {
            return;
        }

        var dialog = new TeamEditWindow(TeamRow.FromDto(source.ToDto()), isNew: false)
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
        if (ViewModel is null || (sender as Button)?.DataContext is not TeamRow row)
        {
            return;
        }

        var confirm = MessageBox.Show(Window.GetWindow(this), $"确定删除班组 {row.ShiftNo} / {row.TeamName} 吗？", "删除确认",
            MessageBoxButton.YesNo, MessageBoxImage.Question);

        if (confirm == MessageBoxResult.Yes)
        {
            await ViewModel.DeleteAsync(row);
        }
    }
}
