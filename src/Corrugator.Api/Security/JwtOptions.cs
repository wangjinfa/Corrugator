namespace Corrugator.Api.Security;

/// <summary>JWT 配置（appsettings.json → Jwt 节点）</summary>
public class JwtOptions
{
    public string Secret { get; set; } = "Corrugator-IPS-Production-Line-2026-Secret-Key-At-Least-32-Bytes";
    public string Issuer { get; set; } = "Corrugator.Api";
    public string Audience { get; set; } = "Corrugator.Client";
    public int ExpireMinutes { get; set; } = 480;
}
