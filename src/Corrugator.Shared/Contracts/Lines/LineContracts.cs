namespace Corrugator.Shared.Contracts.Lines;

/// <summary>一条瓦线的配置（来自 BaseDB.TB_Line）；对外不返回连接串</summary>
public class LineDto
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string? ConfigId { get; set; }
    public string? ApiUrl { get; set; }
    public string? ServerIp { get; set; }
    public int? ServerPort { get; set; }
    public int? Layer { get; set; }
    public int? DoorWidth { get; set; }
    public bool IsDefault { get; set; }
}
