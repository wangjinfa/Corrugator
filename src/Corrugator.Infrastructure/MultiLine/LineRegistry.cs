using Corrugator.Application.Abstractions;
using Corrugator.Infrastructure.Options;
using Corrugator.Shared.Contracts.Lines;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;

namespace Corrugator.Infrastructure.MultiLine;

/// <summary>
/// 线路注册表：从 BaseDB 的 TB_Line 读取各瓦线配置并缓存。
/// 未配置 BaseConnectionString（单线小项目）时，退化为“只有一条默认线”，连接串取 Database.ConnectionString。
/// </summary>
public class LineRegistry : ILineRegistry
{
    private readonly DatabaseOptions _options;
    private readonly ILogger<LineRegistry> _logger;
    private readonly SemaphoreSlim _gate = new(1, 1);

    private IReadOnlyList<LineDto>? _cache;
    private IReadOnlyList<LineSpec> _specs = Array.Empty<LineSpec>();
    private string _defaultCode = string.Empty;

    public LineRegistry(IOptions<DatabaseOptions> options, ILogger<LineRegistry> logger)
    {
        _options = options.Value;
        _logger = logger;
    }

    public async Task<IReadOnlyList<LineDto>> GetLinesAsync()
    {
        if (_cache is not null)
        {
            return _cache;
        }

        await _gate.WaitAsync();
        try
        {
            if (_cache is not null)
            {
                return _cache;
            }

            _cache = await LoadAsync();
            return _cache;
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task<IReadOnlyList<LineSpec>> GetSpecsAsync()
    {
        await GetLinesAsync();
        return _specs;
    }

    public async Task<bool> ExistsAsync(string code)
    {
        var lines = await GetLinesAsync();
        return lines.Any(l => string.Equals(l.Code, code, StringComparison.OrdinalIgnoreCase));
    }

    public async Task<string> GetDefaultCodeAsync()
    {
        await GetLinesAsync();
        return _defaultCode;
    }

    public void Reload()
    {
        _cache = null;
        _specs = Array.Empty<LineSpec>();
    }

    private async Task<IReadOnlyList<LineDto>> LoadAsync()
    {
        if (!_options.EnableMultiLine)
        {
            var singleLine = BuildFallback();
            _defaultCode = singleLine[0].Code;
            _specs = BuildFallbackSpecs();
            _logger.LogInformation("已关闭多瓦线路由，单线路：{Line}", _defaultCode);
            return singleLine;
        }

        var baseConnection = string.IsNullOrWhiteSpace(_options.BaseConnectionString)
            ? _options.ConnectionString
            : _options.BaseConnectionString;

        var fallback = BuildFallback();

        if (string.IsNullOrWhiteSpace(baseConnection))
        {
            _logger.LogWarning("未配置数据库连接串，使用单线路占位配置");
            _defaultCode = fallback[0].Code;
            _specs = BuildFallbackSpecs();
            return fallback;
        }

        var db = new SqlSugarClient(new ConnectionConfig
        {
            DbType = Corrugator.Infrastructure.SqlSugar.SqlSugarServiceCollectionExtensions.ResolveDbType(_options.Provider),
            ConnectionString = baseConnection,
            IsAutoCloseConnection = true,
            InitKeyType = InitKeyType.Attribute,
        });

        try
        {
            // 直接读 BaseDB.TB_Line：该表不属于 IPS 业务实体，用 Ado 查询避免为一个基础表引入实体
            var rows = await db.Ado.SqlQueryAsync<LineRow>(
                "SELECT F_Code, F_Name, F_ConfigID, F_ConnectionString, F_ServerIP, F_ServerPort, F_WaveLineLayer, F_DoorWidth, F_ApiUrl FROM TB_Line");

            var lines = rows
                .Where(r => !string.IsNullOrWhiteSpace(r.F_Code) && !string.IsNullOrWhiteSpace(r.F_ConnectionString))
                .Select(r => new LineDto
                {
                    Code = r.F_Code!.Trim(),
                    Name = string.IsNullOrWhiteSpace(r.F_Name) ? r.F_Code!.Trim() : r.F_Name!,
                    ConfigId = r.F_ConfigID,
                    ApiUrl = r.F_ApiUrl,
                    ServerIp = r.F_ServerIP,
                    ServerPort = r.F_ServerPort,
                    Layer = r.F_WaveLineLayer,
                    DoorWidth = r.F_DoorWidth,
                })
                .ToList();

            if (lines.Count == 0)
            {
                _logger.LogWarning("TB_Line 中没有可用的线路配置（需要 F_Code 与 F_ConnectionString），回退为单线路模式");
                var single = fallback;
                _defaultCode = single[0].Code;
                _specs = BuildFallbackSpecs();
                return single;
            }

            _defaultCode = string.IsNullOrWhiteSpace(_options.DefaultLine)
                ? lines[0].Code
                : lines.FirstOrDefault(l => string.Equals(l.Code, _options.DefaultLine, StringComparison.OrdinalIgnoreCase))?.Code
                  ?? lines[0].Code;

            foreach (var line in lines)
            {
                line.IsDefault = string.Equals(line.Code, _defaultCode, StringComparison.OrdinalIgnoreCase);
            }

            _specs = rows
                .Where(r => !string.IsNullOrWhiteSpace(r.F_Code) && !string.IsNullOrWhiteSpace(r.F_ConnectionString))
                .Select(r => new LineSpec
                {
                    Code = r.F_Code!.Trim(),
                    Name = string.IsNullOrWhiteSpace(r.F_Name) ? r.F_Code!.Trim() : r.F_Name!,
                    ConfigId = r.F_ConfigID,
                    ConnectionString = r.F_ConnectionString!,
                })
                .ToList();

            _logger.LogInformation("已加载 {Count} 条瓦线配置，默认线路：{Default}", lines.Count, _defaultCode);
            return lines;
        }
        catch (Exception ex)
        {
            // 现场常见：BaseDB 还没建表 / 连接串写错。不能因此让整个服务起不来，退化成单线
            _logger.LogWarning(ex, "读取 BaseDB.TB_Line 失败，回退为单线路模式（连接串取 Database.ConnectionString）");
            var single = fallback;
            _defaultCode = single[0].Code;
            _specs = BuildFallbackSpecs();
            return single;
        }
        finally
        {
            try
            {
                db.Ado.Close();
            }
            catch
            {
                // 连接串本身有问题时 Close 也会抛，忽略：上面已回退到单线路模式
            }
        }
    }

    private List<LineSpec> BuildFallbackSpecs()
    {
        var code = string.IsNullOrWhiteSpace(_options.DefaultLine) ? "Line1" : _options.DefaultLine!;
        return new List<LineSpec>
        {
            new() { Code = code, Name = code, ConnectionString = _options.ConnectionString },
        };
    }

    private List<LineDto> BuildFallback()
    {
        var code = string.IsNullOrWhiteSpace(_options.DefaultLine) ? "Line1" : _options.DefaultLine!;
        return new List<LineDto>
        {
            new()
            {
                Code = code,
                Name = code,
                IsDefault = true,
                ApiUrl = null,
            },
        };
    }

    /// <summary>TB_Line 映射（列名与 BaseDB 字典一致）</summary>
    private class LineRow
    {
        public string? F_Code { get; set; }
        public string? F_Name { get; set; }
        public string? F_ConfigID { get; set; }
        public string? F_ConnectionString { get; set; }
        public string? F_ServerIP { get; set; }
        public int? F_ServerPort { get; set; }
        public int? F_WaveLineLayer { get; set; }
        public int? F_DoorWidth { get; set; }
        public string? F_ApiUrl { get; set; }
    }
}
