namespace Corrugator.Shared.Contracts.Base;

/// <summary>产线楞型一行（字段与 W_Line_Flute 一一对应）</summary>
public class LineFluteDto
{
    public long Id { get; set; }
    public decimal DoorWidth { get; set; }
    public string FluteType { get; set; } = string.Empty;
    public decimal? Thickness { get; set; }
    public decimal? Thickness1 { get; set; }
    public decimal? Thickness2 { get; set; }
    public decimal? Thickness3 { get; set; }
    public decimal? WeightThreshold1 { get; set; }
    public decimal? WeightThreshold2 { get; set; }
    public decimal? WeightThreshold3 { get; set; }
    public int? MaxSlit { get; set; }
    public decimal? MinCutLength { get; set; }
    public decimal? MaxCutLength { get; set; }
    public decimal? MinTrim { get; set; }
    public decimal? MaxTrim { get; set; }
    public decimal? UpperStackLimit { get; set; }
    public decimal? LowerStackLimit { get; set; }
    public int? StackOpenThreshold1 { get; set; }
    public int? StackOpenThreshold2 { get; set; }
    public int? StackOpenThreshold3 { get; set; }
    public int? UpperStackCount1 { get; set; }
    public int? UpperStackCount2 { get; set; }
    public int? UpperStackCount3 { get; set; }
    public int? LowerStackCount1 { get; set; }
    public int? LowerStackCount2 { get; set; }
    public int? LowerStackCount3 { get; set; }
    public decimal? SmallLine { get; set; }
    public decimal? SmallLineDeepen { get; set; }
    public decimal? PlainLineDepth { get; set; }
    public decimal? NormalLineDepth { get; set; }
    public decimal? DeepLineDepth { get; set; }
    public decimal? MaxSpeed { get; set; }
    public int? RollerCount { get; set; }
    public decimal? Trim { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
}

/// <summary>产线楞型规则设置</summary>
public class LineFluteRuleDto
{
    public bool AutoTrimEnabled { get; set; }
    public decimal? AutoTrimThreshold { get; set; }
    public string? AutoTrimType { get; set; }
    public decimal? ThicknessCompressRate { get; set; }
    public string? StackCountBasis { get; set; }
    public string? StackDirection { get; set; }
    public string? ThicknessCalcMode { get; set; }
}

/// <summary>原纸资料行</summary>
public class PaperInfoDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal? GramWeight { get; set; }
    public decimal? PaperWidth { get; set; }
    public string? Brand { get; set; }
    public decimal? RemainLS2 { get; set; }
    public decimal? RemainMS3 { get; set; }
    public decimal? RemainLS3 { get; set; }
}

/// <summary>原纸品牌信息（供应商行）</summary>
public class PaperBrandParamDto
{
    public long Id { get; set; }
    public string Supplier { get; set; } = string.Empty;
    public decimal? RatedTension { get; set; }
    public decimal? SteamGsm { get; set; }
    public decimal? GlueGsm { get; set; }
    public decimal? WrapGsm { get; set; }
    public decimal? TensionLS0 { get; set; }
    public decimal? TensionMS1 { get; set; }
    public decimal? TensionLS1 { get; set; }
    public decimal? TensionMS2 { get; set; }
    public decimal? TensionLS2 { get; set; }
    public decimal? TensionMS3 { get; set; }
    public decimal? TensionLS3 { get; set; }
}

/// <summary>原纸胶水值行</summary>
public class PaperGlueValueDto
{
    public long Id { get; set; }
    public string MachineType { get; set; } = string.Empty;
    public string FluteType { get; set; } = string.Empty;
    public string? Layer { get; set; }
    public decimal? GlueValue { get; set; }
}

/// <summary>整组保存原纸品牌信息（供应商表 + 胶水值表）</summary>
public class PaperBrandSaveRequest
{
    public List<PaperBrandParamDto> Suppliers { get; set; } = new();
    public List<PaperGlueValueDto> GlueValues { get; set; } = new();
}

/// <summary>班组资料行</summary>
public class TeamInfoDto
{
    public long Id { get; set; }
    public string ShiftNo { get; set; } = string.Empty;
    public string TeamName { get; set; } = string.Empty;
    public string? StartTime { get; set; }
    public string? EndTime { get; set; }
    public string? Leader { get; set; }
    public string? Forklift1 { get; set; }
    public string? Forklift2 { get; set; }
    public string? Creator { get; set; }
    public string? CreateTime { get; set; }
    public string? Editor { get; set; }
    public string? EditTime { get; set; }
}
