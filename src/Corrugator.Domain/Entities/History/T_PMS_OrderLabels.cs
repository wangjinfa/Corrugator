using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 订单标签打印表
/// </summary>
[SugarTable("W_PMS_OrderLabels", TableDescription = "订单标签打印表")]
public class W_PMS_OrderLabels
{
    /// <summary>WF_Guid</summary>
    [SugarColumn(ColumnName = "WF_Guid", Length = 50, ColumnDescription = "WF_Guid")]
    public string WF_Guid { get; set; } = default!;

    /// <summary>WF_PaperCode</summary>
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 50, ColumnDescription = "WF_PaperCode")]
    public string WF_PaperCode { get; set; } = default!;

    /// <summary>WF_Wave</summary>
    [SugarColumn(ColumnName = "WF_Wave", Length = 50, ColumnDescription = "WF_Wave")]
    public string WF_Wave { get; set; } = default!;

    /// <summary>WF_Width</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "WF_Width")]
    public int WF_Width { get; set; }

    /// <summary>WF_WidthInch</summary>
    [SugarColumn(ColumnName = "WF_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_WidthInch")]
    public decimal? WF_WidthInch { get; set; }

    /// <summary>WF_ScheduleMeter</summary>
    [SugarColumn(ColumnName = "WF_ScheduleMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_ScheduleMeter")]
    public decimal? WF_ScheduleMeter { get; set; }

    /// <summary>WF_OrderNo</summary>
    [SugarColumn(ColumnName = "WF_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "WF_OrderNo")]
    public string? WF_OrderNo { get; set; }

    /// <summary>WF_CustNo</summary>
    [SugarColumn(ColumnName = "WF_CustNo", Length = 50, IsNullable = true, ColumnDescription = "WF_CustNo")]
    public string? WF_CustNo { get; set; }

    /// <summary>WF_TaskNo</summary>
    [SugarColumn(ColumnName = "WF_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "WF_TaskNo")]
    public string? WF_TaskNo { get; set; }

    /// <summary>WF_CustName</summary>
    [SugarColumn(ColumnName = "WF_CustName", Length = 50, IsNullable = true, ColumnDescription = "WF_CustName")]
    public string? WF_CustName { get; set; }

    /// <summary>WF_CustPaperCode</summary>
    [SugarColumn(ColumnName = "WF_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "WF_CustPaperCode")]
    public string? WF_CustPaperCode { get; set; }

    /// <summary>WF_CutWidth</summary>
    [SugarColumn(ColumnName = "WF_CutWidth", IsNullable = true, ColumnDescription = "WF_CutWidth")]
    public int? WF_CutWidth { get; set; }

    /// <summary>WF_CutWidthInch</summary>
    [SugarColumn(ColumnName = "WF_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_CutWidthInch")]
    public decimal? WF_CutWidthInch { get; set; }

    /// <summary>WF_CutLength</summary>
    [SugarColumn(ColumnName = "WF_CutLength", IsNullable = true, ColumnDescription = "WF_CutLength")]
    public int? WF_CutLength { get; set; }

    /// <summary>WF_CutLengthInch</summary>
    [SugarColumn(ColumnName = "WF_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_CutLengthInch")]
    public decimal? WF_CutLengthInch { get; set; }

    /// <summary>WF_CutQty</summary>
    [SugarColumn(ColumnName = "WF_CutQty", IsNullable = true, ColumnDescription = "WF_CutQty")]
    public int? WF_CutQty { get; set; }

    /// <summary>WF_OrderQty</summary>
    [SugarColumn(ColumnName = "WF_OrderQty", IsNullable = true, ColumnDescription = "WF_OrderQty")]
    public int? WF_OrderQty { get; set; }

    /// <summary>WF_OrderMeter</summary>
    [SugarColumn(ColumnName = "WF_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_OrderMeter")]
    public decimal? WF_OrderMeter { get; set; }

    /// <summary>WF_LabelQty</summary>
    [SugarColumn(ColumnName = "WF_LabelQty", IsNullable = true, ColumnDescription = "WF_LabelQty")]
    public int? WF_LabelQty { get; set; }

    /// <summary>WF_CN</summary>
    [SugarColumn(ColumnName = "WF_CN", IsNullable = true, ColumnDescription = "WF_CN")]
    public int? WF_CN { get; set; }

    /// <summary>WF_Scor</summary>
    [SugarColumn(ColumnName = "WF_Scor", Length = 50, IsNullable = true, ColumnDescription = "WF_Scor")]
    public string? WF_Scor { get; set; }

    /// <summary>WF_Remark</summary>
    [SugarColumn(ColumnName = "WF_Remark", Length = 50, IsNullable = true, ColumnDescription = "WF_Remark")]
    public string? WF_Remark { get; set; }

    /// <summary>WF_StackQty</summary>
    [SugarColumn(ColumnName = "WF_StackQty", IsNullable = true, ColumnDescription = "WF_StackQty")]
    public int? WF_StackQty { get; set; }

    /// <summary>WF_BunQty</summary>
    [SugarColumn(ColumnName = "WF_BunQty", IsNullable = true, ColumnDescription = "WF_BunQty")]
    public int? WF_BunQty { get; set; }

    /// <summary>WF_OrderDate</summary>
    [SugarColumn(ColumnName = "WF_OrderDate", IsNullable = true, ColumnDescription = "WF_OrderDate")]
    public DateTime? WF_OrderDate { get; set; }

    /// <summary>WF_DeliDate</summary>
    [SugarColumn(ColumnName = "WF_DeliDate", IsNullable = true, ColumnDescription = "WF_DeliDate")]
    public DateTime? WF_DeliDate { get; set; }

    /// <summary>WF_StockMemo</summary>
    [SugarColumn(ColumnName = "WF_StockMemo", Length = 50, IsNullable = true, ColumnDescription = "WF_StockMemo")]
    public string? WF_StockMemo { get; set; }

    /// <summary>WF_BoxMemo</summary>
    [SugarColumn(ColumnName = "WF_BoxMemo", Length = 50, IsNullable = true, ColumnDescription = "WF_BoxMemo")]
    public string? WF_BoxMemo { get; set; }

    /// <summary>WF_DeliMemo</summary>
    [SugarColumn(ColumnName = "WF_DeliMemo", Length = 50, IsNullable = true, ColumnDescription = "WF_DeliMemo")]
    public string? WF_DeliMemo { get; set; }

    /// <summary>WF_PlanMemo</summary>
    [SugarColumn(ColumnName = "WF_PlanMemo", Length = 50, IsNullable = true, ColumnDescription = "WF_PlanMemo")]
    public string? WF_PlanMemo { get; set; }

    /// <summary>WF_CutPaperMemo</summary>
    [SugarColumn(ColumnName = "WF_CutPaperMemo", Length = 50, IsNullable = true, ColumnDescription = "WF_CutPaperMemo")]
    public string? WF_CutPaperMemo { get; set; }

    /// <summary>WF_OrderNo_D</summary>
    [SugarColumn(ColumnName = "WF_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_OrderNo_D")]
    public string? WF_OrderNo_D { get; set; }

    /// <summary>WF_CustNo_D</summary>
    [SugarColumn(ColumnName = "WF_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_CustNo_D")]
    public string? WF_CustNo_D { get; set; }

    /// <summary>WF_TaskNo_D</summary>
    [SugarColumn(ColumnName = "WF_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_TaskNo_D")]
    public string? WF_TaskNo_D { get; set; }

    /// <summary>WF_CustName_D</summary>
    [SugarColumn(ColumnName = "WF_CustName_D", Length = 50, IsNullable = true, ColumnDescription = "WF_CustName_D")]
    public string? WF_CustName_D { get; set; }

    /// <summary>WF_CustPaperCode_D</summary>
    [SugarColumn(ColumnName = "WF_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "WF_CustPaperCode_D")]
    public string? WF_CustPaperCode_D { get; set; }

    /// <summary>WF_CutWidth_D</summary>
    [SugarColumn(ColumnName = "WF_CutWidth_D", IsNullable = true, ColumnDescription = "WF_CutWidth_D")]
    public int? WF_CutWidth_D { get; set; }

    /// <summary>WF_CutWidthInch_D</summary>
    [SugarColumn(ColumnName = "WF_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_CutWidthInch_D")]
    public decimal? WF_CutWidthInch_D { get; set; }

    /// <summary>WF_CutLength_D</summary>
    [SugarColumn(ColumnName = "WF_CutLength_D", IsNullable = true, ColumnDescription = "WF_CutLength_D")]
    public int? WF_CutLength_D { get; set; }

    /// <summary>WF_CutLengthInch_D</summary>
    [SugarColumn(ColumnName = "WF_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_CutLengthInch_D")]
    public decimal? WF_CutLengthInch_D { get; set; }

    /// <summary>WF_CutQty_D</summary>
    [SugarColumn(ColumnName = "WF_CutQty_D", IsNullable = true, ColumnDescription = "WF_CutQty_D")]
    public int? WF_CutQty_D { get; set; }

    /// <summary>WF_OrderQty_D</summary>
    [SugarColumn(ColumnName = "WF_OrderQty_D", IsNullable = true, ColumnDescription = "WF_OrderQty_D")]
    public int? WF_OrderQty_D { get; set; }

    /// <summary>WF_OrderMeter_D</summary>
    [SugarColumn(ColumnName = "WF_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WF_OrderMeter_D")]
    public decimal? WF_OrderMeter_D { get; set; }

    /// <summary>WF_LabelQty_D</summary>
    [SugarColumn(ColumnName = "WF_LabelQty_D", IsNullable = true, ColumnDescription = "WF_LabelQty_D")]
    public int? WF_LabelQty_D { get; set; }

    /// <summary>WF_CN_D</summary>
    [SugarColumn(ColumnName = "WF_CN_D", IsNullable = true, ColumnDescription = "WF_CN_D")]
    public int? WF_CN_D { get; set; }

    /// <summary>WF_Scor_D</summary>
    [SugarColumn(ColumnName = "WF_Scor_D", Length = 50, IsNullable = true, ColumnDescription = "WF_Scor_D")]
    public string? WF_Scor_D { get; set; }

    /// <summary>WF_Remark_D</summary>
    [SugarColumn(ColumnName = "WF_Remark_D", Length = 50, IsNullable = true, ColumnDescription = "WF_Remark_D")]
    public string? WF_Remark_D { get; set; }

    /// <summary>WF_StackQty_D</summary>
    [SugarColumn(ColumnName = "WF_StackQty_D", IsNullable = true, ColumnDescription = "WF_StackQty_D")]
    public int? WF_StackQty_D { get; set; }

    /// <summary>WF_BunQty_D</summary>
    [SugarColumn(ColumnName = "WF_BunQty_D", IsNullable = true, ColumnDescription = "WF_BunQty_D")]
    public int? WF_BunQty_D { get; set; }

    /// <summary>WF_OrderDate_D</summary>
    [SugarColumn(ColumnName = "WF_OrderDate_D", IsNullable = true, ColumnDescription = "WF_OrderDate_D")]
    public DateTime? WF_OrderDate_D { get; set; }

    /// <summary>WF_DeliDate_D</summary>
    [SugarColumn(ColumnName = "WF_DeliDate_D", IsNullable = true, ColumnDescription = "WF_DeliDate_D")]
    public DateTime? WF_DeliDate_D { get; set; }

    /// <summary>WF_StockMemo_D</summary>
    [SugarColumn(ColumnName = "WF_StockMemo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_StockMemo_D")]
    public string? WF_StockMemo_D { get; set; }

    /// <summary>WF_BoxMemo_D</summary>
    [SugarColumn(ColumnName = "WF_BoxMemo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_BoxMemo_D")]
    public string? WF_BoxMemo_D { get; set; }

    /// <summary>WF_DeliMemo_D</summary>
    [SugarColumn(ColumnName = "WF_DeliMemo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_DeliMemo_D")]
    public string? WF_DeliMemo_D { get; set; }

    /// <summary>WF_PlanMemo_D</summary>
    [SugarColumn(ColumnName = "WF_PlanMemo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_PlanMemo_D")]
    public string? WF_PlanMemo_D { get; set; }

    /// <summary>WF_CutPaperMemo_D</summary>
    [SugarColumn(ColumnName = "WF_CutPaperMemo_D", Length = 50, IsNullable = true, ColumnDescription = "WF_CutPaperMemo_D")]
    public string? WF_CutPaperMemo_D { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}