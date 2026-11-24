using SqlSugar;

namespace Corrugator.Application.Abstractions;

/// <summary>
/// 当前请求要访问哪一个瓦线库。
/// 由 API 层从请求头 X-Line-Code（或 ?line=）解析并写入，仓储/工作单元据此取连接。
/// </summary>
public interface ILineContext
{
    /// <summary>当前线路编码（TB_Line.F_Code），未指定时为空</summary>
    string? LineCode { get; }

    void Set(string? lineCode);
}

/// <summary>基础设施层的线路库访问入口：按当前线路返回对应的 SqlSugar 客户端</summary>
public interface ILineDbAccess
{
    /// <summary>当前实际使用的线路编码（已回退到默认线）</summary>
    string LineCode { get; }

    ISqlSugarClient Db { get; }
}

/// <summary>一条线路的完整配置（含连接串，只在服务端流转，绝不返回给客户端）</summary>
public class LineSpec
{
    public string Code { get; init; } = string.Empty;
    public string Name { get; init; } = string.Empty;
    public string? ConfigId { get; init; }
    public string ConnectionString { get; init; } = string.Empty;
}

/// <summary>线路注册表：读取 BaseDB.TB_Line，供 API、中间件与客户端下拉使用</summary>
public interface ILineRegistry
{
    Task<IReadOnlyList<Corrugator.Shared.Contracts.Lines.LineDto>> GetLinesAsync();

    /// <summary>含连接串的完整配置，仅供多库连接提供者使用</summary>
    Task<IReadOnlyList<LineSpec>> GetSpecsAsync();

    Task<bool> ExistsAsync(string code);

    Task<string> GetDefaultCodeAsync();

    /// <summary>清缓存，下次访问重新读 TB_Line（改完线路配置不用重启服务）</summary>
    void Reload();
}

/// <summary>公共库（账号/权限/瓦线配置）访问入口：始终走 BaseDB，与请求线路无关</summary>
public interface IBaseDbAccess
{
    ISqlSugarClient Db { get; }
}

/// <summary>未接入 Web 时的默认线路上下文（后台任务/单测用）</summary>
public class NullLineContext : ILineContext
{
    public string? LineCode => null;

    public void Set(string? lineCode)
    {
    }
}
