using Corrugator.Application.Abstractions;
using Corrugator.Application.Exceptions;

namespace Corrugator.Api.Middleware;

/// <summary>
/// 线路路由中间件：从请求头 X-Line-Code（或查询串 ?line=）解析瓦线编码，
/// 校验后写入 ILineContext，后续所有仓储访问都会落到该线路的库。
/// 不传则使用默认线路，保持单线路部署的兼容性。
/// </summary>
public class LineContextMiddleware
{
    public const string HeaderName = "X-Line-Code";

    private readonly RequestDelegate _next;

    public LineContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(
        HttpContext context,
        ILineContext lineContext,
        ILineRegistry registry,
        ILogger<LineContextMiddleware> logger)
    {
        var code = context.Request.Headers[HeaderName].FirstOrDefault();
        if (string.IsNullOrWhiteSpace(code))
        {
            code = context.Request.Query["line"].FirstOrDefault();
        }

        if (!string.IsNullOrWhiteSpace(code))
        {
            code = code.Trim();
            if (!await registry.ExistsAsync(code))
            {
                throw new BusinessException($"线路不存在或未配置：{code}");
            }

            lineContext.Set(code);
            context.Response.Headers["X-Line-Code"] = code;
            logger.LogDebug("请求路由到瓦线 {Line}", code);
        }
        else
        {
            lineContext.Set(await registry.GetDefaultCodeAsync());
        }

        await _next(context);
    }
}
