using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class SystemSettingView : UserControl
{
    public SystemSettingView()
    {
        InitializeComponent();
    }

    private async void OnSaveClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not SystemSettingViewModel viewModel)
        {
            return;
        }

        await viewModel.SaveAsync();

        var icon = viewModel.StatusMessage.Contains("失败") || viewModel.StatusMessage.Contains("仅管理员") || viewModel.StatusMessage.Contains("不能为空")
            ? MessageBoxImage.Warning
            : MessageBoxImage.Information;

        MessageBox.Show(Window.GetWindow(this), viewModel.StatusMessage, "系统设置", MessageBoxButton.OK, icon);
    }
}
