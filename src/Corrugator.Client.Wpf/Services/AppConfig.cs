namespace Corrugator.Client.Wpf.Services;

/// <summary>客户端连接配置</summary>
public static class AppConfig
{
    /// <summary>后端 API 地址（部署时改成现场服务器 IP）</summary>
    public static string BaseUrl { get; set; } = "http://localhost:5099";

    public static string Title => "瓦楞纸板生产线生管系统";
}
