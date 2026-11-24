using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class ApiAuthView : UserControl
{
    public ApiAuthView()
    {
        InitializeComponent();
    }

    private async void OnAuthorizeClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not ApiAuthViewModel viewModel)
        {
            return;
        }

        await viewModel.AuthorizeAsync();

        MessageBox.Show(Window.GetWindow(this), viewModel.StatusMessage, "API授权",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
