using Corrugator.Application.Abstractions;
using Corrugator.Infrastructure.MultiLine;
using Corrugator.Infrastructure.Options;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SqlSugar;
using System.Diagnostics;

namespace Corrugator.Infrastructure.SqlSugar;

public static class SqlSugarServiceCollectionExtensions
{
    /// <summary>
    /// 注册 SqlSugar：
    /// ISqlSugarClient 以 SqlSugarScope 单例注入（线程安全、内部按异步上下文隔离连接，天然支持事务）；
    /// 仓储与工作单元按请求（Scoped）注入。
    /// </summary>
    public static IServiceCollection AddCorrugatorData(this IServiceCollection services)
    {
        // 多瓦线多库：注册表 + 连接提供者（单例），请求级通过 ScopedLineDbAccess 拿当前线路的库
        services.TryAddSingleton<ILineRegistry, LineRegistry>();
        services.TryAddSingleton<LineDbProvider>();
        services.TryAddScoped<ILineContext, NullLineContext>();
        services.TryAddScoped<ILineDbAccess, ScopedLineDbAccess>();
        services.TryAddScoped<IBaseDbAccess, ScopedBaseDbAccess>();

        // 兼容旧写法：直接注入 ISqlSugarClient 时拿到“当前线路”的库
        services.TryAddScoped<ISqlSugarClient>(sp => sp.GetRequiredService<ILineDbAccess>().Db);

        services.TryAddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        services.TryAddScoped<IUnitOfWork, UnitOfWork>();
        services.TryAddScoped<IUserContext, NullUserContext>();

        return services;
    }

    public static DbType ResolveDbType(string? provider) => provider?.ToLowerInvariant() switch
    {
        "sqlite" => DbType.Sqlite,
        "mysql" => DbType.MySql,
        "postgresql" or "postgres" => DbType.PostgreSQL,
        _ => DbType.SqlServer,
    };

    /// <summary>
    /// 按实体自动建表（仅开发环境使用；生产执行 db/sqlserver_schema.sql）。
    /// 逐张表建、单张失败不影响其余表：现场经常出现某张表建不动（权限、类型差异），
    /// 一张表报错就把 155 张全回滚是最难排查的坑。
    /// </summary>
    /// <summary>对每条线路的库各跑一遍建表（多瓦线首次部署时用）</summary>
    public static void InitTablesForAllLines(LineDbProvider provider, ILogger logger, DatabaseOptions options)
    {
        if (!options.EnableMultiLine)
        {
            InitTables(provider.Get(null), logger);
            return;
        }

        var specs = provider.GetSpecsAsync().GetAwaiter().GetResult();
        foreach (var spec in specs)
        {
            logger.LogInformation("按实体初始化线路 {Line} 的表结构 ...", spec.Code);
            try
            {
                InitTables(provider.Get(spec.Code), logger);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "线路 {Line} 建表失败，请改用 db/sqlserver_schema.sql 手工初始化", spec.Code);
            }
        }
    }

    /// <summary>公共库（BaseDB）建表：账号/角色/权限，只在公共库建一次</summary>
    public static void InitBaseTables(ISqlSugarClient db, ILogger logger)
        => InitTablesCore(db, logger, Corrugator.Domain.Entities.EntityRegistry.BaseAuth.ToArray(), "公共库");

    public static void InitTables(ISqlSugarClient db, ILogger logger)
        => InitTablesCore(db, logger, Corrugator.Domain.Entities.EntityRegistry.All.ToArray(), "业务库");

    private static void InitTablesCore(ISqlSugarClient db, ILogger logger, Type[] types, string scope)
    {
        var stopwatch = Stopwatch.StartNew();
        var failed = new List<string>();

        foreach (var type in types)
        {
            try
            {
                db.CodeFirst.InitTables(type);
            }
            catch (Exception ex)
            {
                failed.Add(type.Name);
                logger.LogWarning(ex, "表 {Table} 自动创建失败，已跳过", type.Name);
            }
        }

        stopwatch.Stop();
        logger.LogInformation(
            scope + "：已按实体初始化 {Success}/{Total} 张表，耗时 {Elapsed} ms",
            types.Length - failed.Count, types.Length, stopwatch.ElapsedMilliseconds);

        if (failed.Count > 0)
        {
            logger.LogWarning("以下表未能自动创建，请用 db/sqlserver_schema.sql 手工建：{Tables}", string.Join(", ", failed));
        }
    }
}
