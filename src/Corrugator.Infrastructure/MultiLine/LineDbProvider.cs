using Corrugator.Application.Abstractions;
using Corrugator.Infrastructure.Options;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Corrugator.Infrastructure.MultiLine;

/// <summary>
/// 多库连接提供者：把 BaseDB 与每条瓦线的库注册进同一个 SqlSugarScope（ConfigId = 线路编码），
/// 请求进来后按 ILineContext 取对应库，仓储与事务都落在该库上。
/// Scope 单例、线程安全；线路配置变更（/api/lines/reload）后重建。
/// </summary>
public class LineDbProvider : IDisposable
{
    public const string BaseConfigId = "__base__";

    private readonly DatabaseOptions _options;
    private readonly ILineRegistry _registry;
    private readonly ILogger<LineDbProvider> _logger;
    private readonly object _gate = new();

    private SqlSugarScope? _scope;
    private Dictionary<string, string> _codeToConfigId = new(StringComparer.OrdinalIgnoreCase);

    public LineDbProvider(IOptions<DatabaseOptions> options, ILineRegistry registry, ILogger<LineDbProvider> logger)
    {
        _options = options.Value;
        _registry = registry;
        _logger = logger;
    }

    /// <summary>当前所有线路（已带连接串，只在服务端使用）</summary>
    public async Task<IReadOnlyList<LineSpec>> GetSpecsAsync()
    {
        await EnsureBuiltAsync();
        return _specs;
    }

    private IReadOnlyList<LineSpec> _specs = Array.Empty<LineSpec>();

    /// <summary>按线路编码取客户端；编码为空或未知时回落到默认线</summary>
    public async Task<ISqlSugarClient> GetAsync(string? lineCode)
    {
        await EnsureBuiltAsync();

        var code = string.IsNullOrWhiteSpace(lineCode) ? _specs[0].Code : lineCode!;
        var configId = _codeToConfigId.TryGetValue(code, out var id) ? id : _codeToConfigId[_specs[0].Code];
        return _scope!.GetConnection(configId);
    }

    /// <summary>同步版：仓储在构造函数/属性里取值时用（Scope 已在启动阶段建好）</summary>
    public ISqlSugarClient Get(string? lineCode)
    {
        if (_scope is null)
        {
            // 启动初始化之外第一次使用（例如后台任务），同步建一次
            EnsureBuiltAsync().GetAwaiter().GetResult();
        }

        var code = string.IsNullOrWhiteSpace(lineCode) ? _specs[0].Code : lineCode!;
        var configId = _codeToConfigId.TryGetValue(code, out var id) ? id : _codeToConfigId[_specs[0].Code];
        return _scope!.GetConnection(configId);
    }

    /// <summary>公共库连接：配置了 BaseConnectionString 时用它，否则与默认线路同一个库（BaseDB 已并入 IPS 的场景）</summary>
    public ISqlSugarClient GetBase()
    {
        if (_scope is null)
        {
            EnsureBuiltAsync().GetAwaiter().GetResult();
        }

        var hasBase = _options is not null && !string.IsNullOrWhiteSpace(_options.BaseConnectionString);
        if (hasBase)
        {
            return _scope!.GetConnection(BaseConfigId);
        }

        var code = DefaultCode;
        var configId = _codeToConfigId.TryGetValue(code, out var id) ? id : _codeToConfigId.Values.First();
        return _scope!.GetConnection(configId);
    }

    public string DefaultCode => _specs.Count == 0 ? "Line1" : _specs[0].Code;

    public async Task ReloadAsync()
    {
        _registry.Reload();
        await RebuildAsync();
    }

    private async Task EnsureBuiltAsync()
    {
        if (_scope is not null)
        {
            return;
        }

        await RebuildAsync();
    }

    private async Task RebuildAsync()
    {
        var lines = await _registry.GetLinesAsync();
        var defaultCode = await _registry.GetDefaultCodeAsync();

        // 线路连接串不在 LineDto 上（对外接口不能暴露连接串），这里从注册表重新取一次完整配置
        var fullSpecs = await _registry.GetSpecsAsync();

        lock (_gate)
        {
            var configs = new List<ConnectionConfig>();
            var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            var baseConnection = string.IsNullOrWhiteSpace(_options.BaseConnectionString)
                ? _options.ConnectionString
                : _options.BaseConnectionString;

            if (!string.IsNullOrWhiteSpace(baseConnection))
            {
                configs.Add(BuildConfig(BaseConfigId, baseConnection));
            }

            foreach (var spec in fullSpecs)
            {
                var configId = string.IsNullOrWhiteSpace(spec.ConfigId) ? spec.Code : spec.ConfigId!;
                configs.Add(BuildConfig(configId, spec.ConnectionString));
                map[spec.Code] = configId;
            }

            var newScope = new SqlSugarScope(configs, client =>
            {
                client.Aop.OnError = ex => _logger.LogError(ex, "SQL 执行失败: {Sql}", ex.Sql);
                client.Aop.OnLogExecuted = (sql, pars) =>
                {
                    var elapsed = client.Ado.SqlExecutionTime;
                    if (elapsed.TotalMilliseconds >= _options.SlowSqlThresholdMs)
                    {
                        _logger.LogWarning("慢 SQL {Elapsed}ms: {Sql}", (int)elapsed.TotalMilliseconds, sql);
                    }
                };
            });

            var old = _scope;
            _scope = newScope;
            _codeToConfigId = map;
            _specs = fullSpecs;
            old?.Dispose();

            _logger.LogInformation("多库路由已就绪：{Lines} 条线路（默认 {Default}）",
                fullSpecs.Count, string.IsNullOrWhiteSpace(defaultCode) ? fullSpecs[0].Code : defaultCode);
        }
    }

    private ConnectionConfig BuildConfig(string configId, string connectionString) => new()
    {
        ConfigId = configId,
        DbType = Corrugator.Infrastructure.SqlSugar.SqlSugarServiceCollectionExtensions.ResolveDbType(_options.Provider),
        ConnectionString = connectionString,
        IsAutoCloseConnection = true,
        InitKeyType = InitKeyType.Attribute,
        MoreSettings = new ConnMoreSettings { IsAutoRemoveDataCache = true },
        ConfigureExternalServices = new ConfigureExternalServices
        {
            EntityService = (property, column) =>
            {
                if (column.PropertyName.StartsWith("_"))
                {
                    column.IsIgnore = true;
                }
            },
        },
    };

    public void Dispose() => _scope?.Dispose();
}

/// <summary>公共库访问实现</summary>
public class ScopedBaseDbAccess : IBaseDbAccess
{
    private readonly LineDbProvider _provider;

    public ScopedBaseDbAccess(LineDbProvider provider)
    {
        _provider = provider;
    }

    public ISqlSugarClient Db => _provider.GetBase();
}

/// <summary>请求级的数据访问入口：按 ILineContext 决定用哪个库</summary>
public class ScopedLineDbAccess : ILineDbAccess
{
    private readonly ILineContext _context;
    private readonly LineDbProvider _provider;

    public ScopedLineDbAccess(ILineContext context, LineDbProvider provider)
    {
        _context = context;
        _provider = provider;
    }

    public string LineCode => string.IsNullOrWhiteSpace(_context.LineCode) ? _provider.DefaultCode : _context.LineCode!;

    public ISqlSugarClient Db => _provider.Get(LineCode);
}
