using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 备料表
/// </summary>
[SugarTable("W_PaperReadys", TableDescription = "备料表")]
public class W_PaperReadys
{
    /// <summary>WO_ID</summary>
    [SugarColumn(ColumnName = "WO_ID", IsNullable = true, ColumnDescription = "WO_ID")]
    public int? WO_ID { get; set; }

    /// <summary>WO_IDS</summary>
    [SugarColumn(ColumnName = "WO_IDS", Length = 2000, IsNullable = true, ColumnDescription = "WO_IDS")]
    public string? WO_IDS { get; set; }

    /// <summary>WP_P04TID</summary>
    [SugarColumn(ColumnName = "WP_P04TID", IsNullable = true, ColumnDescription = "WP_P04TID")]
    public int? WP_P04TID { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "WPR_WorkNo", ColumnDescription = "工号")]
    public int WPR_WorkNo { get; set; }

    /// <summary>WPro_PaperCode</summary>
    [SugarColumn(ColumnName = "WPro_PaperCode", IsNullable = true, ColumnDescription = "WPro_PaperCode")]
    public int? WPro_PaperCode { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WPR_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WPR_Wave { get; set; } = default!;

    /// <summary>材质代码</summary>
    [SugarColumn(ColumnName = "WPR_PaperCode", Length = 50, ColumnDescription = "材质代码")]
    public string WPR_PaperCode { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WPR_Width", ColumnDescription = "门幅")]
    public int WPR_Width { get; set; }

    /// <summary>WPR_WidthInch</summary>
    [SugarColumn(ColumnName = "WPR_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WPR_WidthInch")]
    public decimal? WPR_WidthInch { get; set; }

    /// <summary>订单数</summary>
    [SugarColumn(ColumnName = "WPR_OrderNum", ColumnDescription = "订单数")]
    public int WPR_OrderNum { get; set; }

    /// <summary>订单米数</summary>
    [SugarColumn(ColumnName = "WPR_OrderMeter", Length = 18, DecimalDigits = 4, ColumnDescription = "订单米数")]
    public decimal WPR_OrderMeter { get; set; }

    /// <summary>DF面材质</summary>
    [SugarColumn(ColumnName = "WPR_DFOuter", Length = 10, IsNullable = true, ColumnDescription = "DF面材质")]
    public string? WPR_DFOuter { get; set; }

    /// <summary>DF面米数</summary>
    [SugarColumn(ColumnName = "WPR_DFOuterMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "DF面米数")]
    public decimal? WPR_DFOuterMeter { get; set; }

    /// <summary>SF1芯材质</summary>
    [SugarColumn(ColumnName = "WPR_SF1Medium", Length = 10, IsNullable = true, ColumnDescription = "SF1芯材质")]
    public string? WPR_SF1Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPR_SF1MediumMeterSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPR_SF1MediumMeterSF1 { get; set; }

    /// <summary>SF1里材质</summary>
    [SugarColumn(ColumnName = "WPR_SF1Inside", Length = 10, IsNullable = true, ColumnDescription = "SF1里材质")]
    public string? WPR_SF1Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPR_SF1InsideMeterSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPR_SF1InsideMeterSF1 { get; set; }

    /// <summary>SF2芯材质</summary>
    [SugarColumn(ColumnName = "WPR_SF2Medium", Length = 10, IsNullable = true, ColumnDescription = "SF2芯材质")]
    public string? WPR_SF2Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPR_SF2MediumMeterSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPR_SF2MediumMeterSF2 { get; set; }

    /// <summary>SF2里材质</summary>
    [SugarColumn(ColumnName = "WPR_SF2Inside", Length = 10, IsNullable = true, ColumnDescription = "SF2里材质")]
    public string? WPR_SF2Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPR_SF2InsideMeterSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPR_SF2InsideMeterSF2 { get; set; }

    /// <summary>SF3芯材质</summary>
    [SugarColumn(ColumnName = "WPR_SF3Medium", Length = 10, IsNullable = true, ColumnDescription = "SF3芯材质")]
    public string? WPR_SF3Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPR_SF3MediumMeterSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPR_SF3MediumMeterSF3 { get; set; }

    /// <summary>SF3里材质</summary>
    [SugarColumn(ColumnName = "WPR_SF3Inside", Length = 10, IsNullable = true, ColumnDescription = "SF3里材质")]
    public string? WPR_SF3Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPR_SF3InsideMeterSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPR_SF3InsideMeterSF3 { get; set; }

    /// <summary>WPR_ID</summary>
    [SugarColumn(ColumnName = "WPR_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WPR_ID")]
    public int WPR_ID { get; set; }

}