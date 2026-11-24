using Corrugator.Api.Security;
using Corrugator.Application.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;

namespace Corrugator.Api.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _auth;
    private readonly JwtTokenService _tokenService;

    public AuthController(IAuthService auth, JwtTokenService tokenService)
    {
        _auth = auth;
        _tokenService = tokenService;
    }

    /// <summary>登录，返回 JWT</summary>
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<ApiResult<LoginResponse>> Login([FromBody] LoginRequest request)
    {
        var user = await _auth.LoginAsync(request);
        return ApiResult<LoginResponse>.Ok(_tokenService.Create(user));
    }

    /// <summary>当前登录用户</summary>
    [HttpGet("me")]
    [Authorize]
    public ApiResult<CurrentUserDto> Me()
    {
        var identity = User.Identity;
        if (identity?.IsAuthenticated != true)
        {
            return ApiResult<CurrentUserDto>.Unauthorized();
        }

        return ApiResult<CurrentUserDto>.Ok(new CurrentUserDto
        {
            UserId = int.TryParse(User.FindFirst("user_id")?.Value, out var id) ? id
                : int.TryParse(User.FindFirst(ClaimTypes.NameIdentifier)?.Value, out var fallback) ? fallback : 0,
            UserName = identity.Name ?? string.Empty,
            DisplayName = User.FindFirst("display_name")?.Value ?? string.Empty,
            Role = User.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty,
            Roles = User.FindAll(ClaimTypes.Role).Select(c => c.Value).ToList(),
            Permissions = User.FindAll("perm").Select(c => c.Value).ToList(),
            IsMultiLine = User.FindFirst("multi_line")?.Value == "1",
        });
    }
}
