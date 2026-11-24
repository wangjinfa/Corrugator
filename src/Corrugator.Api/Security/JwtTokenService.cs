using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Corrugator.Application.Services;
using Corrugator.Shared.Auth;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Corrugator.Api.Security;

/// <summary>签发 / 校验 JWT</summary>
public class JwtTokenService
{
    private readonly JwtOptions _options;

    public JwtTokenService(IOptions<JwtOptions> options)
    {
        _options = options.Value;
    }

    public LoginResponse Create(AuthResult user)
    {
        var expires = DateTime.Now.AddMinutes(_options.ExpireMinutes);
        var claims = new List<Claim>
        {
            new(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
            new(JwtRegisteredClaimNames.UniqueName, user.UserName),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Role, user.Role),
            new("display_name", user.DisplayName),
            new("user_id", user.UserId.ToString()),
            new("multi_line", user.IsMultiLine ? "1" : "0"),
        };

        // 多角色 / 多权限：每个角色一个标准 Role claim，每个权限一个 perm claim
        foreach (var role in user.Roles.Where(r => !string.Equals(r, user.Role, StringComparison.OrdinalIgnoreCase)))
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        foreach (var permission in user.Permissions)
        {
            claims.Add(new Claim("perm", permission));
        }

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.Secret));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _options.Issuer,
            audience: _options.Audience,
            claims: claims,
            expires: expires,
            signingCredentials: credentials);

        return new LoginResponse
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresAt = expires,
            UserId = user.UserId,
            UserName = user.UserName,
            DisplayName = user.DisplayName,
            Role = user.Role,
            Roles = user.Roles,
            Permissions = user.Permissions,
            IsMultiLine = user.IsMultiLine,
        };
    }
}

/// <summary>从 HttpContext 取当前登录用户，供仓储层审计字段使用</summary>
public class HttpUserContext : Corrugator.Application.Abstractions.IUserContext
{
    private readonly IHttpContextAccessor _accessor;

    public HttpUserContext(IHttpContextAccessor accessor)
    {
        _accessor = accessor;
    }

    public string? UserName =>
        _accessor.HttpContext?.User?.Identity?.IsAuthenticated == true
            ? _accessor.HttpContext.User.Identity!.Name
            : null;

    public string? Ip => _accessor.HttpContext?.Connection.RemoteIpAddress?.ToString();

    public bool IsAuthenticated => _accessor.HttpContext?.User?.Identity?.IsAuthenticated == true;
}
