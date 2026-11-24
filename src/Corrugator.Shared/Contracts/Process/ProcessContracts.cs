using Corrugator.Shared.Api;

namespace Corrugator.Shared.Contracts.Process;

/// <summary>产线楞型基础资料（W_ProductWaves）</summary>
public class WaveProfileDto
{
    public int WSPW_ID { get; set; }
    public int WSPW_Width { get; set; }
    public string WSPW_Wave { get; set; } = string.Empty;
    public decimal? WSPW_WDeepSF1 { get; set; }
    public decimal? WSPW_WRateSF1 { get; set; }
    public decimal? WSPW_WDeepSF2 { get; set; }
    public decimal? WSPW_WRateSF2 { get; set; }
    public decimal? WSPW_WDeepSF3 { get; set; }
    public decimal? WSPW_WRateSF3 { get; set; }
    public decimal? WSPW_PaperDeep { get; set; }
    public int? WSPW_MaxCN { get; set; }
    public int? WSPW_MinCutLength { get; set; }
    public int? WSPW_MaxCutLength { get; set; }
    public int? WSPW_MinEdge { get; set; }
    public int? WSPW_MaxEdge { get; set; }
    public int? WSPW_SmallScor { get; set; }
    public int? WSPW_SmallScorDepth { get; set; }
    public int? WSPW_FlatScorDepth { get; set; }
    public int? WSPW_ComScorDepth { get; set; }
}

/// <summary>工艺参数总表（W_QDM_FormSetFactor）中一组系数</summary>
public class ProcessFactorItemDto
{
    public string Key { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public decimal? Value { get; set; }
    public bool? IsOpen { get; set; }
}

/// <summary>工艺参数修改请求</summary>
public class ProcessFactorUpdateDto
{
    public string Key { get; set; } = string.Empty;
    public decimal? Value { get; set; }
    public bool? IsOpen { get; set; }
}

/// <summary>基础资料分页查询</summary>
public class WaveQuery : PageQuery
{
    public string? Wave { get; set; }
    public int? Width { get; set; }
}
