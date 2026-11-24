using Corrugator.Client.Wpf.Services;
using Corrugator.Client.Wpf.ViewModels;
using Prism.Ioc;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Corrugator.Client.Wpf.Views;

public partial class MainWindow : Window
{
    private readonly MainViewModel _viewModel;
    private readonly DispatcherTimer _clock;
    private readonly BasicInfoViewModel _settingsViewModel;
    private ContentControl? _settingsHost;
    private BasicInfoView? _settingsView;
    private bool _settingsOpen;

    /// <summary>模板内的系统设置宿主（位于 MainTabs 模板中，从其模板按名查找）</summary>
    private ContentControl SettingsHost
    {
        get
        {
            if (_settingsHost is null)
            {
                MainTabs.ApplyTemplate();
                _settingsHost = (ContentControl)MainTabs.Template.FindName("SettingsHost", MainTabs);
            }

            return _settingsHost!;
        }
    }

    /// <summary>首次进入时惰性构建系统设置视图（模板此时已应用）</summary>
    private void EnsureSettingsView()
    {
        if (_settingsView is not null)
        {
            return;
        }

        _settingsView = new BasicInfoView { DataContext = _settingsViewModel };
        SettingsHost.Content = _settingsView;
    }

    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        DataContext = _viewModel;
        Loaded += async (_, _) => await _viewModel.InitializeAsync();

        // 系统设置：内嵌在主界面内容区，左上角圆环进入，不弹独立窗口
        var api = ContainerLocator.Container.Resolve<ApiClient>();
        var session = ContainerLocator.Container.Resolve<AppSession>();
        _settingsViewModel = new BasicInfoViewModel(api, session, settingsOnly: true);

        // 顶栏时间每秒刷新
        _clock = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
        _clock.Tick += (_, _) => _viewModel.NowText = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        _clock.Start();
    }

    /// <summary>切到哪个模块就刷新对应数据，避免登录后一次性拉全部表</summary>
    private async void OnTabChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.OriginalSource != MainTabs || MainTabs.SelectedIndex < 0)
        {
            return;
        }

        // 从系统设置切回某个页签时，关闭设置内嵌页
        CloseSettings();

        switch (MainTabs.SelectedIndex)
        {
            case 0:
                await _viewModel.Dashboard.LoadAsync();
                break;
            case 1:
                await _viewModel.GraphicControl.LoadAsync();
                break;
            case 2:
                await _viewModel.Orders.LoadAsync();
                break;
            case 3:
                await _viewModel.Alarms.LoadAsync();
                break;
            case 4:
                await _viewModel.Report.LoadAsync();
                break;
            case 5:
                await _viewModel.BasicInfo.InitializeAsync();
                break;
            case 6:
                await _viewModel.ProcessParams.LoadAsync();
                break;
        }
    }

    /// <summary>左上角圆环图标：在主界面内嵌打开 / 收回系统设置</summary>
    private async void OnOpenSettings(object sender, RoutedEventArgs e)
    {
        if (_settingsOpen)
        {
            CloseSettings();
            return;
        }

        EnsureSettingsView();
        SettingsHost.Visibility = Visibility.Visible;
        _settingsOpen = true;
        await _settingsViewModel.InitializeAsync();
    }

    private void CloseSettings()
    {
        if (!_settingsOpen)
        {
            return;
        }

        SettingsHost.Visibility = Visibility.Collapsed;
        _settingsOpen = false;
    }
}
