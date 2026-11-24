using Corrugator.Client.Wpf.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class OrderColorView : UserControl
{
    public OrderColorView()
    {
        InitializeComponent();
    }

    private void OnPickBackColor(object sender, RoutedEventArgs e) => PickColor(sender, isBack: true);

    private void OnPickFontColor(object sender, RoutedEventArgs e) => PickColor(sender, isBack: false);

    private void PickColor(object sender, bool isBack)
    {
        if ((sender as Button)?.DataContext is not OrderColorRow row)
        {
            return;
        }

        var current = isBack ? row.BackColor : row.FontColor;
        var dialog = new OrderColorPickWindow(current)
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        if (isBack)
        {
            row.BackColor = dialog.Result;
        }
        else
        {
            row.FontColor = dialog.Result;
        }
    }

    private async void OnSaveClick(object sender, RoutedEventArgs e)
    {
        if (DataContext is not OrderColorViewModel viewModel)
        {
            return;
        }

        await viewModel.SaveAsync();
        MessageBox.Show(Window.GetWindow(this), viewModel.StatusMessage, "订单颜色设置",
            MessageBoxButton.OK, MessageBoxImage.Information);
    }
}
