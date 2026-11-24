using SqlSugar;

namespace Corrugator.Domain.Entities.BaseLine;

/// <summary>
/// 产线楞型页底部的规则设置（自动修边规则、出垛判定依据、排垛方向、厚度计算模式）。
/// </summary>
[SugarTable("W_Line_FluteRule", TableDescription = "产线楞型规则设置")]
public class W_Line_FluteRule
{
    [SugarColumn(ColumnName = "WF_AutoTrimEnabled", IsNullable = true, ColumnDescription = "自动修边规则启用")]
    public bool? WF_AutoTrimEnabled { get; set; }

    [SugarColumn(ColumnName = "WF_AutoTrimThreshold", IsNullable = true, ColumnDescription = "当订单修边小于等于(mm)")]
    public decimal? WF_AutoTrimThreshold { get; set; }

    [SugarColumn(ColumnName = "WF_AutoTrimType", Length = 40, IsNullable = true, ColumnDescription = "修边类型自动设置为")]
    public string? WF_AutoTrimType { get; set; }

    [SugarColumn(ColumnName = "WF_ThicknessCompressRate", IsNullable = true, ColumnDescription = "纸板厚度计算压缩率")]
    public decimal? WF_ThicknessCompressRate { get; set; }

    [SugarColumn(ColumnName = "WF_StackCountBasis", Length = 40, IsNullable = true, ColumnDescription = "出垛数设置判定依据")]
    public string? WF_StackCountBasis { get; set; }

    [SugarColumn(ColumnName = "WF_StackDirection", Length = 40, IsNullable = true, ColumnDescription = "堆码排垛默认排出方向")]
    public string? WF_StackDirection { get; set; }

    [SugarColumn(ColumnName = "WF_ThicknessCalcMode", Length = 40, IsNullable = true, ColumnDescription = "纸板厚度计算模式")]
    public string? WF_ThicknessCalcMode { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
