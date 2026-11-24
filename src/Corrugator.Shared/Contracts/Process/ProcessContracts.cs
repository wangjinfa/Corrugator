using Corrugator.Shared.Api;

namespace Corrugator.Shared.Contracts.Process;

/// <summary>产线楞型基础资料（S_ProductWaves）</summary>
public class WaveProfileDto
{
    public int SPW_ID { get; set; }
    public int SPW_Width { get; set; }
    public string SPW_Wave { get; set; } = string.Empty;
    public decimal? SPW_WDeepSF1 { get; set; }
    public decimal? SPW_WRateSF1 { get; set; }
    public decimal? SPW_WDeepSF2 { get; set; }
    public decimal? SPW_WRateSF2 { get; set; }
    public decimal? SPW_WDeepSF3 { get; set; }
    public decimal? SPW_WRateSF3 { get; set; }
    public decimal? SPW_PaperDeep { get; set; }
    public int? SPW_MaxCN { get; set; }
    public int? SPW_MinCutLength { get; set; }
    public int? SPW_MaxCutLength { get; set; }
    public int? SPW_MinEdge { get; set; }
    public int? SPW_MaxEdge { get; set; }
    public int? SPW_SmallScor { get; set; }
    public int? SPW_SmallScorDepth { get; set; }
    public int? SPW_FlatScorDepth { get; set; }
    public int? SPW_ComScorDepth { get; set; }
}

/// <summary>工艺参数总表（TB_QDM_FormSetFactor）中一组系数</summary>
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
