using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸分摊基础表
/// </summary>
[SugarTable("W_IPS_PaperShare", TableDescription = "原纸分摊基础表")]
public class W_IPS_PaperShare
{
    /// <summary>接纸机编号</summary>
    [SugarColumn(ColumnName = "WF_MachineID", Length = 50, ColumnDescription = "接纸机编号")]
    public string WF_MachineID { get; set; } = default!;

    /// <summary>WF_OrderID</summary>
    [SugarColumn(ColumnName = "WF_OrderID", ColumnDescription = "WF_OrderID")]
    public int WF_OrderID { get; set; }

    /// <summary>纸卷条码</summary>
    [SugarColumn(ColumnName = "WF_BarCode", Length = 50, ColumnDescription = "纸卷条码")]
    public string WF_BarCode { get; set; } = default!;

    /// <summary>原纸编码</summary>
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 50, ColumnDescription = "原纸编码")]
    public string WF_PaperCode { get; set; } = default!;

    /// <summary>品牌厂家</summary>
    [SugarColumn(ColumnName = "WF_Brand", Length = 50, ColumnDescription = "品牌厂家")]
    public string WF_Brand { get; set; } = default!;

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "门幅mm")]
    public int WF_Width { get; set; }

    /// <summary>门幅in</summary>
    [SugarColumn(ColumnName = "WF_WidthInch", ColumnDescription = "门幅in")]
    public int WF_WidthInch { get; set; }

    /// <summary>原纸克重</summary>
    [SugarColumn(ColumnName = "WF_Weight", ColumnDescription = "原纸克重")]
    public int WF_Weight { get; set; }

    /// <summary>WF_RollWeight</summary>
    [SugarColumn(ColumnName = "WF_RollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_RollWeight")]
    public decimal WF_RollWeight { get; set; }

    /// <summary>直径</summary>
    [SugarColumn(ColumnName = "WF_Dia", ColumnDescription = "直径")]
    public int WF_Dia { get; set; }

    /// <summary>剩余直径</summary>
    [SugarColumn(ColumnName = "WF_RemainDia", ColumnDescription = "剩余直径")]
    public int WF_RemainDia { get; set; }

    /// <summary>Plc剩余直径</summary>
    [SugarColumn(ColumnName = "WF_PlcRemainDia", ColumnDescription = "Plc剩余直径")]
    public int WF_PlcRemainDia { get; set; }

    /// <summary>纸卷米数m</summary>
    [SugarColumn(ColumnName = "WF_Meter", ColumnDescription = "纸卷米数m")]
    public int WF_Meter { get; set; }

    /// <summary>剩余米数</summary>
    [SugarColumn(ColumnName = "WF_RemainMeter", ColumnDescription = "剩余米数")]
    public int WF_RemainMeter { get; set; }

    /// <summary>Plc剩余米数</summary>
    [SugarColumn(ColumnName = "WF_PlcRemainMeter", ColumnDescription = "Plc剩余米数")]
    public int WF_PlcRemainMeter { get; set; }

    /// <summary>WF_RemainRollWeight</summary>
    [SugarColumn(ColumnName = "WF_RemainRollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_RemainRollWeight")]
    public decimal WF_RemainRollWeight { get; set; }

    /// <summary>WF_PlcRemainRollWeight</summary>
    [SugarColumn(ColumnName = "WF_PlcRemainRollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PlcRemainRollWeight")]
    public decimal WF_PlcRemainRollWeight { get; set; }

    /// <summary>上架时间</summary>
    [SugarColumn(ColumnName = "WF_ShelfTime", ColumnDescription = "上架时间")]
    public DateTime WF_ShelfTime { get; set; }

    /// <summary>下架时间</summary>
    [SugarColumn(ColumnName = "WF_OffShelfTime", ColumnDescription = "下架时间")]
    public DateTime WF_OffShelfTime { get; set; }

    /// <summary>已走米数</summary>
    [SugarColumn(ColumnName = "WF_UseMeter", ColumnDescription = "已走米数")]
    public int WF_UseMeter { get; set; }

    /// <summary>WF_Percent</summary>
    [SugarColumn(ColumnName = "WF_Percent", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Percent")]
    public decimal WF_Percent { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}