using Corrugator.Client.Wpf.ViewModels;
using Prism.Ioc;
using System.Windows;
using System.Windows.Input;

namespace Corrugator.Client.Wpf.Views;

public partial class LoginWindow : Window
{
    private readonly LoginViewModel _viewModel;
    private bool _autoLoginStarted;

    public LoginWindow(LoginViewModel viewModel)
    {
        InitializeComponent();

        _viewModel = viewModel;
        _viewModel.ApplySavedCredentials();
        _viewModel.LoginSucceeded += OnLoginSucceeded;
        DataContext = _viewModel;

        PasswordInput.Password = _viewModel.Password;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        if (_autoLoginStarted)
        {
            return;
        }

        _autoLoginStarted = true;

        // 勾了「自动登录」且本地存过密码：等界面先渲染出来再自动提交
        if (_viewModel.AutoLogin && _viewModel.HasSavedPassword)
        {
            await Task.Delay(500);
            await SubmitAsync();
        }
    }

    private void OnDragWindow(object sender, MouseButtonEventArgs e)
    {
        if (e.ButtonState == MouseButtonState.Pressed && e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    private async void OnLoginClick(object sender, RoutedEventArgs e)
    {
        await SubmitAsync();
    }

    private void OnPasswordChanged(object sender, RoutedEventArgs e)
    {
        _viewModel.Password = PasswordInput.Password;
    }

    private void OnCloseClick(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private async Task SubmitAsync()
    {
        LoginButton.IsEnabled = false;
        try
        {
            _viewModel.Password = PasswordInput.Password;
            await _viewModel.LoginAsync();
        }
        finally
        {
            LoginButton.IsEnabled = true;
        }
    }

    private void OnLoginSucceeded(object? sender, EventArgs e)
    {
        // 登录页只是入口 Shell，成功后换成主窗（MainWindow 由容器构造，构造注入 MainViewModel）
        var main = ContainerLocator.Container.Resolve<MainWindow>();
        main.Show();
        Application.Current.MainWindow = main;
        Close();
    }
}
