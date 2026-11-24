using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 订单标签打印表
/// </summary>
[SugarTable("T_PMS_OrderLabels", TableDescription = "订单标签打印表")]
public class T_PMS_OrderLabels
{
    /// <summary>F_Guid</summary>
    [SugarColumn(ColumnName = "F_Guid", Length = 50, ColumnDescription = "F_Guid")]
    public string F_Guid { get; set; } = default!;

    /// <summary>F_PaperCode</summary>
    [SugarColumn(ColumnName = "F_PaperCode", Length = 50, ColumnDescription = "F_PaperCode")]
    public string F_PaperCode { get; set; } = default!;

    /// <summary>F_Wave</summary>
    [SugarColumn(ColumnName = "F_Wave", Length = 50, ColumnDescription = "F_Wave")]
    public string F_Wave { get; set; } = default!;

    /// <summary>F_Width</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "F_Width")]
    public int F_Width { get; set; }

    /// <summary>F_WidthInch</summary>
    [SugarColumn(ColumnName = "F_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_WidthInch")]
    public decimal? F_WidthInch { get; set; }

    /// <summary>F_ScheduleMeter</summary>
    [SugarColumn(ColumnName = "F_ScheduleMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_ScheduleMeter")]
    public decimal? F_ScheduleMeter { get; set; }

    /// <summary>F_OrderNo</summary>
    [SugarColumn(ColumnName = "F_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "F_OrderNo")]
    public string? F_OrderNo { get; set; }

    /// <summary>F_CustNo</summary>
    [SugarColumn(ColumnName = "F_CustNo", Length = 50, IsNullable = true, ColumnDescription = "F_CustNo")]
    public string? F_CustNo { get; set; }

    /// <summary>F_TaskNo</summary>
    [SugarColumn(ColumnName = "F_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "F_TaskNo")]
    public string? F_TaskNo { get; set; }

    /// <summary>F_CustName</summary>
    [SugarColumn(ColumnName = "F_CustName", Length = 50, IsNullable = true, ColumnDescription = "F_CustName")]
    public string? F_CustName { get; set; }

    /// <summary>F_CustPaperCode</summary>
    [SugarColumn(ColumnName = "F_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "F_CustPaperCode")]
    public string? F_CustPaperCode { get; set; }

    /// <summary>F_CutWidth</summary>
    [SugarColumn(ColumnName = "F_CutWidth", IsNullable = true, ColumnDescription = "F_CutWidth")]
    public int? F_CutWidth { get; set; }

    /// <summary>F_CutWidthInch</summary>
    [SugarColumn(ColumnName = "F_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_CutWidthInch")]
    public decimal? F_CutWidthInch { get; set; }

    /// <summary>F_CutLength</summary>
    [SugarColumn(ColumnName = "F_CutLength", IsNullable = true, ColumnDescription = "F_CutLength")]
    public int? F_CutLength { get; set; }

    /// <summary>F_CutLengthInch</summary>
    [SugarColumn(ColumnName = "F_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_CutLengthInch")]
    public decimal? F_CutLengthInch { get; set; }

    /// <summary>F_CutQty</summary>
    [SugarColumn(ColumnName = "F_CutQty", IsNullable = true, ColumnDescription = "F_CutQty")]
    public int? F_CutQty { get; set; }

    /// <summary>F_OrderQty</summary>
    [SugarColumn(ColumnName = "F_OrderQty", IsNullable = true, ColumnDescription = "F_OrderQty")]
    public int? F_OrderQty { get; set; }

    /// <summary>F_OrderMeter</summary>
    [SugarColumn(ColumnName = "F_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_OrderMeter")]
    public decimal? F_OrderMeter { get; set; }

    /// <summary>F_LabelQty</summary>
    [SugarColumn(ColumnName = "F_LabelQty", IsNullable = true, ColumnDescription = "F_LabelQty")]
    public int? F_LabelQty { get; set; }

    /// <summary>F_CN</summary>
    [SugarColumn(ColumnName = "F_CN", IsNullable = true, ColumnDescription = "F_CN")]
    public int? F_CN { get; set; }

    /// <summary>F_Scor</summary>
    [SugarColumn(ColumnName = "F_Scor", Length = 50, IsNullable = true, ColumnDescription = "F_Scor")]
    public string? F_Scor { get; set; }

    /// <summary>F_Remark</summary>
    [SugarColumn(ColumnName = "F_Remark", Length = 50, IsNullable = true, ColumnDescription = "F_Remark")]
    public string? F_Remark { get; set; }

    /// <summary>F_StackQty</summary>
    [SugarColumn(ColumnName = "F_StackQty", IsNullable = true, ColumnDescription = "F_StackQty")]
    public int? F_StackQty { get; set; }

    /// <summary>F_BunQty</summary>
    [SugarColumn(ColumnName = "F_BunQty", IsNullable = true, ColumnDescription = "F_BunQty")]
    public int? F_BunQty { get; set; }

    /// <summary>F_OrderDate</summary>
    [SugarColumn(ColumnName = "F_OrderDate", IsNullable = true, ColumnDescription = "F_OrderDate")]
    public DateTime? F_OrderDate { get; set; }

    /// <summary>F_DeliDate</summary>
    [SugarColumn(ColumnName = "F_DeliDate", IsNullable = true, ColumnDescription = "F_DeliDate")]
    public DateTime? F_DeliDate { get; set; }

    /// <summary>F_StockMemo</summary>
    [SugarColumn(ColumnName = "F_StockMemo", Length = 50, IsNullable = true, ColumnDescription = "F_StockMemo")]
    public string? F_StockMemo { get; set; }

    /// <summary>F_BoxMemo</summary>
    [SugarColumn(ColumnName = "F_BoxMemo", Length = 50, IsNullable = true, ColumnDescription = "F_BoxMemo")]
    public string? F_BoxMemo { get; set; }

    /// <summary>F_DeliMemo</summary>
    [SugarColumn(ColumnName = "F_DeliMemo", Length = 50, IsNullable = true, ColumnDescription = "F_DeliMemo")]
    public string? F_DeliMemo { get; set; }

    /// <summary>F_PlanMemo</summary>
    [SugarColumn(ColumnName = "F_PlanMemo", Length = 50, IsNullable = true, ColumnDescription = "F_PlanMemo")]
    public string? F_PlanMemo { get; set; }

    /// <summary>F_CutPaperMemo</summary>
    [SugarColumn(ColumnName = "F_CutPaperMemo", Length = 50, IsNullable = true, ColumnDescription = "F_CutPaperMemo")]
    public string? F_CutPaperMemo { get; set; }

    /// <summary>F_OrderNo_D</summary>
    [SugarColumn(ColumnName = "F_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "F_OrderNo_D")]
    public string? F_OrderNo_D { get; set; }

    /// <summary>F_CustNo_D</summary>
    [SugarColumn(ColumnName = "F_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "F_CustNo_D")]
    public string? F_CustNo_D { get; set; }

    /// <summary>F_TaskNo_D</summary>
    [SugarColumn(ColumnName = "F_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "F_TaskNo_D")]
    public string? F_TaskNo_D { get; set; }

    /// <summary>F_CustName_D</summary>
    [SugarColumn(ColumnName = "F_CustName_D", Length = 50, IsNullable = true, ColumnDescription = "F_CustName_D")]
    public string? F_CustName_D { get; set; }

    /// <summary>F_CustPaperCode_D</summary>
    [SugarColumn(ColumnName = "F_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "F_CustPaperCode_D")]
    public string? F_CustPaperCode_D { get; set; }

    /// <summary>F_CutWidth_D</summary>
    [SugarColumn(ColumnName = "F_CutWidth_D", IsNullable = true, ColumnDescription = "F_CutWidth_D")]
    public int? F_CutWidth_D { get; set; }

    /// <summary>F_CutWidthInch_D</summary>
    [SugarColumn(ColumnName = "F_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_CutWidthInch_D")]
    public decimal? F_CutWidthInch_D { get; set; }

    /// <summary>F_CutLength_D</summary>
    [SugarColumn(ColumnName = "F_CutLength_D", IsNullable = true, ColumnDescription = "F_CutLength_D")]
    public int? F_CutLength_D { get; set; }

    /// <summary>F_CutLengthInch_D</summary>
    [SugarColumn(ColumnName = "F_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_CutLengthInch_D")]
    public decimal? F_CutLengthInch_D { get; set; }

    /// <summary>F_CutQty_D</summary>
    [SugarColumn(ColumnName = "F_CutQty_D", IsNullable = true, ColumnDescription = "F_CutQty_D")]
    public int? F_CutQty_D { get; set; }

    /// <summary>F_OrderQty_D</summary>
    [SugarColumn(ColumnName = "F_OrderQty_D", IsNullable = true, ColumnDescription = "F_OrderQty_D")]
    public int? F_OrderQty_D { get; set; }

    /// <summary>F_OrderMeter_D</summary>
    [SugarColumn(ColumnName = "F_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "F_OrderMeter_D")]
    public decimal? F_OrderMeter_D { get; set; }

    /// <summary>F_LabelQty_D</summary>
    [SugarColumn(ColumnName = "F_LabelQty_D", IsNullable = true, ColumnDescription = "F_LabelQty_D")]
    public int? F_LabelQty_D { get; set; }

    /// <summary>F_CN_D</summary>
    [SugarColumn(ColumnName = "F_CN_D", IsNullable = true, ColumnDescription = "F_CN_D")]
    public int? F_CN_D { get; set; }

    /// <summary>F_Scor_D</summary>
    [SugarColumn(ColumnName = "F_Scor_D", Length = 50, IsNullable = true, ColumnDescription = "F_Scor_D")]
    public string? F_Scor_D { get; set; }

    /// <summary>F_Remark_D</summary>
    [SugarColumn(ColumnName = "F_Remark_D", Length = 50, IsNullable = true, ColumnDescription = "F_Remark_D")]
    public string? F_Remark_D { get; set; }

    /// <summary>F_StackQty_D</summary>
    [SugarColumn(ColumnName = "F_StackQty_D", IsNullable = true, ColumnDescription = "F_StackQty_D")]
    public int? F_StackQty_D { get; set; }

    /// <summary>F_BunQty_D</summary>
    [SugarColumn(ColumnName = "F_BunQty_D", IsNullable = true, ColumnDescription = "F_BunQty_D")]
    public int? F_BunQty_D { get; set; }

    /// <summary>F_OrderDate_D</summary>
    [SugarColumn(ColumnName = "F_OrderDate_D", IsNullable = true, ColumnDescription = "F_OrderDate_D")]
    public DateTime? F_OrderDate_D { get; set; }

    /// <summary>F_DeliDate_D</summary>
    [SugarColumn(ColumnName = "F_DeliDate_D", IsNullable = true, ColumnDescription = "F_DeliDate_D")]
    public DateTime? F_DeliDate_D { get; set; }

    /// <summary>F_StockMemo_D</summary>
    [SugarColumn(ColumnName = "F_StockMemo_D", Length = 50, IsNullable = true, ColumnDescription = "F_StockMemo_D")]
    public string? F_StockMemo_D { get; set; }

    /// <summary>F_BoxMemo_D</summary>
    [SugarColumn(ColumnName = "F_BoxMemo_D", Length = 50, IsNullable = true, ColumnDescription = "F_BoxMemo_D")]
    public string? F_BoxMemo_D { get; set; }

    /// <summary>F_DeliMemo_D</summary>
    [SugarColumn(ColumnName = "F_DeliMemo_D", Length = 50, IsNullable = true, ColumnDescription = "F_DeliMemo_D")]
    public string? F_DeliMemo_D { get; set; }

    /// <summary>F_PlanMemo_D</summary>
    [SugarColumn(ColumnName = "F_PlanMemo_D", Length = 50, IsNullable = true, ColumnDescription = "F_PlanMemo_D")]
    public string? F_PlanMemo_D { get; set; }

    /// <summary>F_CutPaperMemo_D</summary>
    [SugarColumn(ColumnName = "F_CutPaperMemo_D", Length = 50, IsNullable = true, ColumnDescription = "F_CutPaperMemo_D")]
    public string? F_CutPaperMemo_D { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}