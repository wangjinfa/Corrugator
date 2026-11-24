using Corrugator.Client.Wpf.Services;
using Corrugator.Shared.Auth;
using Prism.Mvvm;

namespace Corrugator.Client.Wpf.ViewModels;

/// <summary>登录页（Prism BindableBase）：账号密码、保存密码、自动登录</summary>
public class LoginViewModel : BindableBase
{
    private readonly ApiClient _api;
    private readonly AppSession _session;

    private string _userName = "admin";
    private string _password = "123456";
    private string? _errorMessage;
    private bool _isBusy;
    private bool _savePassword;
    private bool _autoLogin;

    public LoginViewModel(ApiClient api, AppSession session)
    {
        _api = api;
        _session = session;
    }

    public string UserName
    {
        get => _userName;
        set => SetProperty(ref _userName, value);
    }

    public string Password
    {
        get => _password;
        set => SetProperty(ref _password, value);
    }

    public string? ErrorMessage
    {
        get => _errorMessage;
        set => SetProperty(ref _errorMessage, value);
    }

    public bool IsBusy
    {
        get => _isBusy;
        set => SetProperty(ref _isBusy, value);
    }

    /// <summary>是否记住密码（密码用 DPAPI 加密落盘，不写明文）</summary>
    public bool SavePassword
    {
        get => _savePassword;
        set => SetProperty(ref _savePassword, value);
    }

    /// <summary>启动后自动登录</summary>
    public bool AutoLogin
    {
        get => _autoLogin;
        set => SetProperty(ref _autoLogin, value);
    }

    public event EventHandler? LoginSucceeded;

    /// <summary>登录页右下角显示的服务端地址，便于现场确认连的是哪台服务器</summary>
    public string ApiDisplay => AppConfig.BaseUrl;

    /// <summary>把上次保存的账号/密码填进来</summary>
    public void ApplySavedCredentials()
    {
        var saved = LoginPreferences.Load();
        if (!string.IsNullOrWhiteSpace(saved.Account))
        {
            UserName = saved.Account;
        }

        SavePassword = saved.SavePassword;
        AutoLogin = saved.AutoLogin;

        var password = LoginPreferences.ReadPassword(saved);
        if (!string.IsNullOrEmpty(password))
        {
            Password = password;
        }
    }

    public bool HasSavedPassword => !string.IsNullOrEmpty(LoginPreferences.ReadPassword(LoginPreferences.Load()));

    public async Task<bool> LoginAsync()
    {
        if (IsBusy)
        {
            return false;
        }

        IsBusy = true;
        ErrorMessage = null;
        try
        {
            var result = await _api.PostAsync<LoginResponse>("api/auth/login", new LoginRequest
            {
                UserName = UserName?.Trim() ?? string.Empty,
                Password = Password,
            });

            if (!result.Success || result.Data is null)
            {
                ErrorMessage = result.Code == 401 ? "账号或密码错误，请重新输入" : result.Message;
                return false;
            }

            _session.SignIn(result.Data);
            _api.SetToken(result.Data.Token);
            PersistPreferences();
            LoginSucceeded?.Invoke(this, EventArgs.Empty);
            return true;
        }
        catch (Exception ex)
        {
            ErrorMessage = $"登录失败：{ex.Message}";
            return false;
        }
        finally
        {
            IsBusy = false;
        }
    }

    private void PersistPreferences()
    {
        var data = new LoginPreferences.Data
        {
            Account = UserName?.Trim() ?? string.Empty,
            SavePassword = SavePassword,
            AutoLogin = AutoLogin,
        };

        if (SavePassword)
        {
            LoginPreferences.WritePassword(data, Password);
        }

        LoginPreferences.Save(data);
    }
}
