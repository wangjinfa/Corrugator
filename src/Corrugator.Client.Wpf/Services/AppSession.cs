using Corrugator.Shared.Auth;

namespace Corrugator.Client.Wpf.Services;

/// <summary>登录会话，保存 Token 与当前用户</summary>
public class AppSession
{
    public string? Token { get; private set; }

    /// <summary>当前瓦线编码（对应 BaseDB.TB_Line.F_Code），请求头 X-Line-Code 用</summary>
    public string? LineCode { get; set; }
    public LoginResponse? User { get; private set; }

    public bool IsAuthenticated => Token is not null;

    public void SignIn(LoginResponse response)
    {
        Token = response.Token;
        User = response;
    }

    public void SignOut()
    {
        Token = null;
        User = null;
    }
}
