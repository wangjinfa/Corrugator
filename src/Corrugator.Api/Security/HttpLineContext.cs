using Corrugator.Application.Abstractions;

namespace Corrugator.Api.Security;

/// <summary>
/// 请求级线路上下文：中间件写入后，仓储/工作单元据此决定访问哪个瓦线库。
/// 启动初始化（建表、种子账号）时也用它按线路切换。
/// </summary>
public class HttpLineContext : ILineContext
{
    private string? _code;

    public string? LineCode => _code;

    public void Set(string? lineCode) => _code = lineCode;
}
