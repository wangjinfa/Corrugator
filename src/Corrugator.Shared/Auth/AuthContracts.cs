namespace Corrugator.Shared.Auth;

public class LoginRequest
{
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class LoginResponse
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Role { get; set; } = "operator";

    /// <summary>全部角色编码（S_Roles.SR_Name）</summary>
    public List<string> Roles { get; set; } = new();

    /// <summary>功能权限编码（S_Permissions.SP_Name）</summary>
    public List<string> Permissions { get; set; } = new();

    /// <summary>是否开通多瓦线切换（S_Users.SU_IsMulti）</summary>
    public bool IsMultiLine { get; set; }
}

public class CurrentUserDto
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string DisplayName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = new();
    public List<string> Permissions { get; set; } = new();
    public bool IsMultiLine { get; set; }
}
