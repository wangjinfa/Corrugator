using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 领料表
/// </summary>
[SugarTable("W_PaperGets", TableDescription = "领料表")]
public class W_PaperGets
{
    /// <summary>WO_ID</summary>
    [SugarColumn(ColumnName = "WO_ID", IsNullable = true, ColumnDescription = "WO_ID")]
    public int? WO_ID { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "WPG_WorkNo", ColumnDescription = "工号")]
    public int WPG_WorkNo { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WPG_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WPG_Wave { get; set; } = default!;

    /// <summary>材质代码</summary>
    [SugarColumn(ColumnName = "WPG_PaperCode", Length = 50, ColumnDescription = "材质代码")]
    public string WPG_PaperCode { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WPG_Width", ColumnDescription = "门幅")]
    public int WPG_Width { get; set; }

    /// <summary>WPG_WidthInch</summary>
    [SugarColumn(ColumnName = "WPG_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WPG_WidthInch")]
    public decimal? WPG_WidthInch { get; set; }

    /// <summary>订单数</summary>
    [SugarColumn(ColumnName = "WPG_OrderNum", ColumnDescription = "订单数")]
    public int WPG_OrderNum { get; set; }

    /// <summary>订单米数</summary>
    [SugarColumn(ColumnName = "WPG_OrderMeter", Length = 18, DecimalDigits = 4, ColumnDescription = "订单米数")]
    public decimal WPG_OrderMeter { get; set; }

    /// <summary>DF面材质</summary>
    [SugarColumn(ColumnName = "WPG_DFOuter", Length = 10, IsNullable = true, ColumnDescription = "DF面材质")]
    public string? WPG_DFOuter { get; set; }

    /// <summary>DF面米数</summary>
    [SugarColumn(ColumnName = "WPG_DFOuterMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "DF面米数")]
    public decimal? WPG_DFOuterMeter { get; set; }

    /// <summary>SF1芯材质</summary>
    [SugarColumn(ColumnName = "WPG_SF1Medium", Length = 10, IsNullable = true, ColumnDescription = "SF1芯材质")]
    public string? WPG_SF1Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPG_SF1MediumMeterSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPG_SF1MediumMeterSF1 { get; set; }

    /// <summary>SF1里材质</summary>
    [SugarColumn(ColumnName = "WPG_SF1Inside", Length = 10, IsNullable = true, ColumnDescription = "SF1里材质")]
    public string? WPG_SF1Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPG_SF1InsideMeterSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPG_SF1InsideMeterSF1 { get; set; }

    /// <summary>SF2芯材质</summary>
    [SugarColumn(ColumnName = "WPG_SF2Medium", Length = 10, IsNullable = true, ColumnDescription = "SF2芯材质")]
    public string? WPG_SF2Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPG_SF2MediumMeterSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPG_SF2MediumMeterSF2 { get; set; }

    /// <summary>SF2里材质</summary>
    [SugarColumn(ColumnName = "WPG_SF2Inside", Length = 10, IsNullable = true, ColumnDescription = "SF2里材质")]
    public string? WPG_SF2Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPG_SF2InsideMeterSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPG_SF2InsideMeterSF2 { get; set; }

    /// <summary>SF3芯材质</summary>
    [SugarColumn(ColumnName = "WPG_SF3Medium", Length = 10, IsNullable = true, ColumnDescription = "SF3芯材质")]
    public string? WPG_SF3Medium { get; set; }

    /// <summary>芯米数</summary>
    [SugarColumn(ColumnName = "WPG_SF3MediumMeterSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "芯米数")]
    public decimal? WPG_SF3MediumMeterSF3 { get; set; }

    /// <summary>SF3里材质</summary>
    [SugarColumn(ColumnName = "WPG_SF3Inside", Length = 10, IsNullable = true, ColumnDescription = "SF3里材质")]
    public string? WPG_SF3Inside { get; set; }

    /// <summary>里米数</summary>
    [SugarColumn(ColumnName = "WPG_SF3InsideMeterSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "里米数")]
    public decimal? WPG_SF3InsideMeterSF3 { get; set; }

    /// <summary>WPG_ID</summary>
    [SugarColumn(ColumnName = "WPG_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WPG_ID")]
    public int WPG_ID { get; set; }

}