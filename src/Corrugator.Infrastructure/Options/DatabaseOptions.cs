namespace Corrugator.Infrastructure.Options;

/// <summary>数据库连接配置（appsettings.json → Database 节点）</summary>
public class DatabaseOptions
{
    public string ConnectionString { get; set; } = string.Empty;

    /// <summary>数据库类型：SqlServer（默认）/ Sqlite / MySql / PostgreSQL，便于本地自测或后续换库</summary>
    public string Provider { get; set; } = "SqlServer";

    /// <summary>是否在启动时按实体自动建表（开发环境用，生产请用 db/sqlserver_schema.sql）</summary>
    public bool AutoCreateTables { get; set; }

    /// <summary>是否初始化内置账号</summary>
    public bool SeedData { get; set; } = true;

    /// <summary>慢 SQL 阈值（毫秒），超过该值会打警告日志</summary>
    public int SlowSqlThresholdMs { get; set; } = 1000;

    /// <summary>
    /// BaseDB 连接串（存放 TB_Line 等线路配置）。留空表示线路配置就在当前库里，即单线路部署。
    /// </summary>
    public string BaseConnectionString { get; set; } = string.Empty;

    /// <summary>默认线路编码（TB_Line.F_Code）；留空取第一条</summary>
    public string DefaultLine { get; set; } = string.Empty;

    /// <summary>是否启用多瓦线多库路由；关闭时全部请求都走 ConnectionString</summary>
    public bool EnableMultiLine { get; set; } = true;
}
