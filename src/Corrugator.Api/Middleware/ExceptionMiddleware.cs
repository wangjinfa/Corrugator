using System.Text.Json;
using Corrugator.Application.Exceptions;
using Corrugator.Shared.Api;

namespace Corrugator.Api.Middleware;

/// <summary>
/// 全局异常处理：业务异常返回 200 + code≠0，未认证返回 401，
/// 其余异常记录日志并返回 500，前端统一按 ApiResult 解析。
/// </summary>
public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            if (context.Response.HasStarted)
            {
                throw;
            }

            var status = ex is UnauthorizedException ? StatusCodes.Status401Unauthorized : StatusCodes.Status200OK;
            var code = ex switch
            {
                UnauthorizedException unauthorized => unauthorized.Code,
                NotFoundException notFound => notFound.Code,
                BusinessException business => business.Code,
                _ => 5000,
            };

            if (ex is BusinessException)
            {
                _logger.LogWarning("业务异常：{Message}", ex.Message);
            }
            else
            {
                _logger.LogError(ex, "未处理异常：{Path}", context.Request.Path);
            }

            context.Response.Clear();
            context.Response.StatusCode = status;
            context.Response.ContentType = "application/json; charset=utf-8";

            var payload = ApiResult<object>.Fail(
                ex is BusinessException ? ex.Message : "服务器内部错误，请联系管理员",
                code);
            payload.TraceId = context.TraceIdentifier;

            await context.Response.WriteAsync(JsonSerializer.Serialize(payload, new JsonSerializerOptions
            {
                PropertyNamingPolicy = null,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            }));
        }
    }
}
