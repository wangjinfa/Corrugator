using SqlSugar;

namespace Corrugator.Domain.Entities.BaseLine;

/// <summary>
/// 产线楞型页底部的规则设置（自动修边规则、出垛判定依据、排垛方向、厚度计算模式）。
/// </summary>
[SugarTable("TB_Line_FluteRule", TableDescription = "产线楞型规则设置")]
public class TB_Line_FluteRule
{
    [SugarColumn(ColumnName = "F_AutoTrimEnabled", IsNullable = true, ColumnDescription = "自动修边规则启用")]
    public bool? F_AutoTrimEnabled { get; set; }

    [SugarColumn(ColumnName = "F_AutoTrimThreshold", IsNullable = true, ColumnDescription = "当订单修边小于等于(mm)")]
    public decimal? F_AutoTrimThreshold { get; set; }

    [SugarColumn(ColumnName = "F_AutoTrimType", Length = 40, IsNullable = true, ColumnDescription = "修边类型自动设置为")]
    public string? F_AutoTrimType { get; set; }

    [SugarColumn(ColumnName = "F_ThicknessCompressRate", IsNullable = true, ColumnDescription = "纸板厚度计算压缩率")]
    public decimal? F_ThicknessCompressRate { get; set; }

    [SugarColumn(ColumnName = "F_StackCountBasis", Length = 40, IsNullable = true, ColumnDescription = "出垛数设置判定依据")]
    public string? F_StackCountBasis { get; set; }

    [SugarColumn(ColumnName = "F_StackDirection", Length = 40, IsNullable = true, ColumnDescription = "堆码排垛默认排出方向")]
    public string? F_StackDirection { get; set; }

    [SugarColumn(ColumnName = "F_ThicknessCalcMode", Length = 40, IsNullable = true, ColumnDescription = "纸板厚度计算模式")]
    public string? F_ThicknessCalcMode { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
