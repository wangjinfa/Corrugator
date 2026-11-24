using Corrugator.Client.Wpf.Services;
using Corrugator.Client.Wpf.ViewModels;
using Corrugator.Client.Wpf.Views;
using Prism.Ioc;
using Prism.Unity;
using System.Windows;

namespace Corrugator.Client.Wpf;

/// <summary>
/// Prism（Unity 容器）启动入口：
/// 1) 容器注册服务与 ViewModel；2) 登录页作为 Shell；3) 登录成功后由登录页换成 MainWindow。
/// </summary>
public partial class App : PrismApplication
{
    protected override Window CreateShell() => Container.Resolve<LoginWindow>();

    protected override void RegisterTypes(IContainerRegistry containerRegistry)
    {
        // 会话与 HTTP 客户端全局单例（切瓦线靠它带 X-Line-Code 头）
        containerRegistry.RegisterSingleton<ApiClient>();
        containerRegistry.RegisterSingleton<AppSession>();

        // 主窗只有一个，其余页面 VM 每次进入按需创建
        containerRegistry.RegisterSingleton<MainViewModel>();
        containerRegistry.Register<LoginViewModel>();

        containerRegistry.Register<DashboardViewModel>();
        containerRegistry.Register<GraphicControlViewModel>();
        containerRegistry.Register<OrdersViewModel>();
        containerRegistry.Register<AlarmsViewModel>();
        containerRegistry.Register<ReportViewModel>();
        containerRegistry.Register<DictionaryViewModel>();
        containerRegistry.Register<CommViewModel>();
        containerRegistry.Register<SystemSettingViewModel>();
        containerRegistry.Register<ApiAuthViewModel>();
        containerRegistry.Register<OrderColorViewModel>();
        containerRegistry.Register<IpsPartViewModel>();
        containerRegistry.Register<OrderExtFieldViewModel>();
        containerRegistry.Register<LineFluteViewModel>();
        containerRegistry.Register<PaperInfoViewModel>();
        containerRegistry.Register<TeamInfoViewModel>();
        containerRegistry.Register<BasicInfoViewModel>();
        containerRegistry.Register<ProcessParamsViewModel>();

        // 由容器负责构造，便于构造函数注入 ViewModel
        containerRegistry.Register<LoginWindow>();
        containerRegistry.Register<MainWindow>();
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();

        // 正常 Shell 由 Prism 显示；这里兜底防止某些环境未显示
        if (MainWindow is { IsVisible: false })
        {
            MainWindow.Show();
        }
    }
}
