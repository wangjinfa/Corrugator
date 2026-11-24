using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Shared.Contracts.Comm;
using System.Windows;
using System.Windows.Controls;

namespace Corrugator.Client.Wpf.Views;

public partial class CommView : UserControl
{
    public CommView()
    {
        InitializeComponent();
    }

    private CommViewModel? ViewModel => DataContext as CommViewModel;

    private void OnTabConfig(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            ViewModel.SelectedTab = 0;
        }
    }

    private void OnTabDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            ViewModel.SelectedTab = 1;
        }
    }

    private void OnTabPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            ViewModel.SelectedTab = 2;
        }
    }

    private async void OnSearch(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadConfigsAsync();
        }
    }

    private async void OnReset(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetQuery();
        await ViewModel.LoadConfigsAsync();
    }

    private async void OnAdd(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var dialog = new CommConfigEditWindow(null, ViewModel.ParCodes.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveConfigAsync(null, dialog.Result);
        }
    }

    private async void OnEdit(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not CommConfigDto row)
        {
            return;
        }

        var dialog = new CommConfigEditWindow(row, ViewModel.ParCodes.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveConfigAsync(row.Id, dialog.Result);
        }
    }

    private async void OnDeleteChecked(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var ids = ViewModel.Configs.Where(c => c.IsChecked).Select(c => c.Id).ToList();
        if (ids.Count == 0)
        {
            MessageBox.Show(Window.GetWindow(this), "请先勾选要删除的记录", "提示",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var confirm = MessageBox.Show($"确定删除勾选的 {ids.Count} 条通讯配置？", "删除确认",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteConfigsAsync(ids);
        }
    }

    private async void OnRefresh(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadConfigsAsync();
        }
    }

    private async void OnReload(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.ReloadAsync();
        }
    }

    private async void OnRefreshDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadDevicesAsync();
        }
    }

    private async void OnSearchDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadDevicesAsync();
        }
    }

    private async void OnResetDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetDeviceQuery();
        await ViewModel.LoadDevicesAsync();
    }

    private async void OnAddDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        await ViewModel.LoadDeviceOptionsAsync();
        var dialog = new CommDeviceEditWindow(null, ViewModel.DeviceTypes.ToList(), ViewModel.ConfigOptions.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveDeviceAsync(null, dialog.Result);
        }
    }

    private async void OnEditDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not CommDeviceDto row)
        {
            return;
        }

        await ViewModel.LoadDeviceOptionsAsync();
        var dialog = new CommDeviceEditWindow(row, ViewModel.DeviceTypes.ToList(), ViewModel.ConfigOptions.ToList())
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SaveDeviceAsync(row.Id, dialog.Result);
        }
    }

    private async void OnDeleteCheckedDevice(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var ids = ViewModel.Devices.Where(d => d.IsChecked).Select(d => d.Id).ToList();
        if (ids.Count == 0)
        {
            MessageBox.Show(Window.GetWindow(this), "请先勾选要删除的记录", "提示",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var confirm = MessageBox.Show($"确定删除勾选的 {ids.Count} 个通讯设备？", "删除确认",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeleteDevicesAsync(ids);
        }
    }

    private async void OnRefreshPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadPointsAsync();
        }
    }

    private async void OnSearchPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is not null)
        {
            await ViewModel.LoadPointsAsync();
        }
    }

    private async void OnResetPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        ViewModel.ResetPointQuery();
        await ViewModel.LoadPointsAsync();
    }

    private async void OnAddPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        await ViewModel.LoadPointOptionsAsync();
        var dialog = new CommPointEditWindow(null, ViewModel.PointOptions, ViewModel.Points.Select(p => p.Code))
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SavePointAsync(null, dialog.Result);
        }
    }

    private async void OnEditPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null || (sender as Button)?.DataContext is not CommPointDto row)
        {
            return;
        }

        await ViewModel.LoadPointOptionsAsync();
        var dialog = new CommPointEditWindow(row, ViewModel.PointOptions, ViewModel.Points.Select(p => p.Code))
        {
            Owner = Window.GetWindow(this),
        };

        if (dialog.ShowDialog() == true && dialog.Result is not null)
        {
            await ViewModel.SavePointAsync(row.Id, dialog.Result);
        }
    }

    private async void OnDeleteCheckedPoint(object sender, RoutedEventArgs e)
    {
        if (ViewModel is null)
        {
            return;
        }

        var ids = ViewModel.Points.Where(p => p.IsChecked).Select(p => p.Id).ToList();
        if (ids.Count == 0)
        {
            MessageBox.Show(Window.GetWindow(this), "请先勾选要删除的记录", "提示",
                MessageBoxButton.OK, MessageBoxImage.Information);
            return;
        }

        var confirm = MessageBox.Show($"确定删除勾选的 {ids.Count} 个点位变量？", "删除确认",
            MessageBoxButton.OKCancel, MessageBoxImage.Warning);

        if (confirm == MessageBoxResult.OK)
        {
            await ViewModel.DeletePointsAsync(ids);
        }
    }
}
