using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸使用明细表
/// </summary>
[SugarTable("T_PR_HisRollInOut", TableDescription = "原纸使用明细表")]
public class T_PR_HisRollInOut
{
    /// <summary>接纸机编号</summary>
    [SugarColumn(ColumnName = "F_MachineID", Length = 50, ColumnDescription = "接纸机编号")]
    public string F_MachineID { get; set; } = default!;

    /// <summary>纸卷条码</summary>
    [SugarColumn(ColumnName = "F_BarCode", Length = 50, ColumnDescription = "纸卷条码")]
    public string F_BarCode { get; set; } = default!;

    /// <summary>原纸编码</summary>
    [SugarColumn(ColumnName = "F_PaperCode", Length = 50, ColumnDescription = "原纸编码")]
    public string F_PaperCode { get; set; } = default!;

    /// <summary>品牌厂家</summary>
    [SugarColumn(ColumnName = "F_Brand", Length = 50, ColumnDescription = "品牌厂家")]
    public string F_Brand { get; set; } = default!;

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "门幅mm")]
    public int F_Width { get; set; }

    /// <summary>门幅in</summary>
    [SugarColumn(ColumnName = "F_WidthInch", ColumnDescription = "门幅in")]
    public int F_WidthInch { get; set; }

    /// <summary>原纸克重</summary>
    [SugarColumn(ColumnName = "F_Weight", ColumnDescription = "原纸克重")]
    public int F_Weight { get; set; }

    /// <summary>纸卷重量</summary>
    [SugarColumn(ColumnName = "F_RollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "纸卷重量")]
    public decimal F_RollWeight { get; set; }

    /// <summary>直径</summary>
    [SugarColumn(ColumnName = "F_Dia", ColumnDescription = "直径")]
    public int F_Dia { get; set; }

    /// <summary>剩余直径</summary>
    [SugarColumn(ColumnName = "F_RemainDia", ColumnDescription = "剩余直径")]
    public int F_RemainDia { get; set; }

    /// <summary>Plc剩余直径</summary>
    [SugarColumn(ColumnName = "F_PlcRemainDia", ColumnDescription = "Plc剩余直径")]
    public int F_PlcRemainDia { get; set; }

    /// <summary>纸卷米数m</summary>
    [SugarColumn(ColumnName = "F_Meter", ColumnDescription = "纸卷米数m")]
    public int F_Meter { get; set; }

    /// <summary>剩余米数</summary>
    [SugarColumn(ColumnName = "F_RemainMeter", ColumnDescription = "剩余米数")]
    public int F_RemainMeter { get; set; }

    /// <summary>Plc剩余米数</summary>
    [SugarColumn(ColumnName = "F_PlcRemainMeter", ColumnDescription = "Plc剩余米数")]
    public int F_PlcRemainMeter { get; set; }

    /// <summary>残卷剩余重量</summary>
    [SugarColumn(ColumnName = "F_RemainRollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "残卷剩余重量")]
    public decimal F_RemainRollWeight { get; set; }

    /// <summary>残卷剩余重量PLC</summary>
    [SugarColumn(ColumnName = "F_PlcRemainRollWeight", Length = 18, DecimalDigits = 2, ColumnDescription = "残卷剩余重量PLC")]
    public decimal F_PlcRemainRollWeight { get; set; }

    /// <summary>上架时间</summary>
    [SugarColumn(ColumnName = "F_ShelfTime", ColumnDescription = "上架时间")]
    public DateTime F_ShelfTime { get; set; }

    /// <summary>下架时间</summary>
    [SugarColumn(ColumnName = "F_OffShelfTime", IsNullable = true, ColumnDescription = "下架时间")]
    public DateTime? F_OffShelfTime { get; set; }

    /// <summary>已走米数</summary>
    [SugarColumn(ColumnName = "F_UseMeter", ColumnDescription = "已走米数")]
    public int F_UseMeter { get; set; }

    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>使用状态</summary>
    [SugarColumn(ColumnName = "F_State", ColumnDescription = "使用状态", DefaultValue = "0")]
    public int F_State { get; set; }

    /// <summary>班组名称</summary>
    [SugarColumn(ColumnName = "F_ShiftName", Length = 50, IsNullable = true, ColumnDescription = "班组名称")]
    public string? F_ShiftName { get; set; }

    /// <summary>供应商</summary>
    [SugarColumn(ColumnName = "F_Supplier", Length = 50, IsNullable = true, ColumnDescription = "供应商")]
    public string? F_Supplier { get; set; }

}