using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class IpsPartView : UserControl
{
    public IpsPartView()
    {
        InitializeComponent();
    }

    private async void OnSaveClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not IpsPartViewModel viewModel)
        {
            return;
        }

        await viewModel.SaveAsync();
        MessageBox.Show(Window.GetWindow(this), viewModel.StatusMessage, "IPS部位显示/隐藏",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
