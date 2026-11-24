using SqlSugar;

namespace Corrugator.Domain.Entities.Erp;

/// <summary>
/// ERP订单中间表
/// </summary>
[SugarTable("W_E_Orders", TableDescription = "ERP订单中间表")]
public class W_E_Orders
{
    /// <summary>ERP订单接口表Guid</summary>
    [SugarColumn(ColumnName = "WEO_Guid", Length = 50, IsNullable = true, ColumnDescription = "ERP订单接口表Guid")]
    public string? WEO_Guid { get; set; }

    /// <summary>是否插单</summary>
    [SugarColumn(ColumnName = "WEO_IsUrgent", ColumnDescription = "是否插单")]
    public bool WEO_IsUrgent { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "WEO_WorkNo", ColumnDescription = "工号")]
    public int WEO_WorkNo { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "WEO_ClassNo", Length = 50, IsNullable = true, ColumnDescription = "班组")]
    public string? WEO_ClassNo { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WEO_PaperCode", Length = 50, ColumnDescription = "材质")]
    public string WEO_PaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WEO_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WEO_Wave { get; set; } = default!;

    /// <summary>层数</summary>
    [SugarColumn(ColumnName = "WEO_Floor", ColumnDescription = "层数")]
    public int WEO_Floor { get; set; }

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "WEO_Width", ColumnDescription = "门幅mm")]
    public int WEO_Width { get; set; }

    /// <summary>修边mm</summary>
    [SugarColumn(ColumnName = "WEO_Trim", IsNullable = true, ColumnDescription = "修边mm")]
    public int? WEO_Trim { get; set; }

    /// <summary>门幅英寸</summary>
    [SugarColumn(ColumnName = "WEO_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "门幅英寸")]
    public decimal? WEO_WidthInch { get; set; }

    /// <summary>材质克重</summary>
    [SugarColumn(ColumnName = "WEO_Weight", IsNullable = true, ColumnDescription = "材质克重")]
    public int? WEO_Weight { get; set; }

    /// <summary>材质厚度</summary>
    [SugarColumn(ColumnName = "WEO_Deep", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "材质厚度")]
    public decimal? WEO_Deep { get; set; }

    /// <summary>第一层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor1", Length = 10, IsNullable = true, ColumnDescription = "第一层材质")]
    public string? WEO_Floor1 { get; set; }

    /// <summary>第一层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor1Deep", IsNullable = true, ColumnDescription = "第一层材质厚度mm")]
    public int? WEO_Floor1Deep { get; set; }

    /// <summary>第二层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor2", Length = 10, IsNullable = true, ColumnDescription = "第二层材质")]
    public string? WEO_Floor2 { get; set; }

    /// <summary>第二层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor2Deep", IsNullable = true, ColumnDescription = "第二层材质厚度mm")]
    public int? WEO_Floor2Deep { get; set; }

    /// <summary>第三层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor3", Length = 10, IsNullable = true, ColumnDescription = "第三层材质")]
    public string? WEO_Floor3 { get; set; }

    /// <summary>第三层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor3Deep", IsNullable = true, ColumnDescription = "第三层材质厚度mm")]
    public int? WEO_Floor3Deep { get; set; }

    /// <summary>第四层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor4", Length = 10, IsNullable = true, ColumnDescription = "第四层材质")]
    public string? WEO_Floor4 { get; set; }

    /// <summary>第四层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor4Deep", IsNullable = true, ColumnDescription = "第四层材质厚度mm")]
    public int? WEO_Floor4Deep { get; set; }

    /// <summary>第五层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor5", Length = 10, IsNullable = true, ColumnDescription = "第五层材质")]
    public string? WEO_Floor5 { get; set; }

    /// <summary>第五层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor5Deep", IsNullable = true, ColumnDescription = "第五层材质厚度mm")]
    public int? WEO_Floor5Deep { get; set; }

    /// <summary>第六层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor6", Length = 10, IsNullable = true, ColumnDescription = "第六层材质")]
    public string? WEO_Floor6 { get; set; }

    /// <summary>第六层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor6Deep", IsNullable = true, ColumnDescription = "第六层材质厚度mm")]
    public int? WEO_Floor6Deep { get; set; }

    /// <summary>第七层材质</summary>
    [SugarColumn(ColumnName = "WEO_Floor7", Length = 10, IsNullable = true, ColumnDescription = "第七层材质")]
    public string? WEO_Floor7 { get; set; }

    /// <summary>第七层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WEO_Floor7Deep", IsNullable = true, ColumnDescription = "第七层材质厚度mm")]
    public int? WEO_Floor7Deep { get; set; }

    /// <summary>是否传单(ccc返回代码)</summary>
    [SugarColumn(ColumnName = "WEO_Send", Length = 10, IsNullable = true, ColumnDescription = "是否传单(ccc返回代码)")]
    public string? WEO_Send { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "WEO_Speed", IsNullable = true, ColumnDescription = "限速")]
    public int? WEO_Speed { get; set; }

    /// <summary>订单排程米数</summary>
    [SugarColumn(ColumnName = "WEO_ScheduleMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "订单排程米数")]
    public decimal? WEO_ScheduleMeter { get; set; }

    /// <summary>是否停换</summary>
    [SugarColumn(ColumnName = "WEO_Stop", ColumnDescription = "是否停换")]
    public bool WEO_Stop { get; set; }

    /// <summary>是否上刀走下刀</summary>
    [SugarColumn(ColumnName = "WEO_UGoD", ColumnDescription = "是否上刀走下刀")]
    public bool WEO_UGoD { get; set; }

    /// <summary>开始生产时间</summary>
    [SugarColumn(ColumnName = "WEO_StartTime", IsNullable = true, ColumnDescription = "开始生产时间")]
    public DateTime? WEO_StartTime { get; set; }

    /// <summary>预计完成时间</summary>
    [SugarColumn(ColumnName = "WEO_EstFinshTime", IsNullable = true, ColumnDescription = "预计完成时间")]
    public DateTime? WEO_EstFinshTime { get; set; }

    /// <summary>加减刀数</summary>
    [SugarColumn(ColumnName = "WEO_ModCutQty", IsNullable = true, ColumnDescription = "加减刀数")]
    public int? WEO_ModCutQty { get; set; }

    /// <summary>上刀订单号</summary>
    [SugarColumn(ColumnName = "WEO_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "上刀订单号")]
    public string? WEO_OrderNo { get; set; }

    /// <summary>上刀客户号</summary>
    [SugarColumn(ColumnName = "WEO_CustNo", Length = 50, IsNullable = true, ColumnDescription = "上刀客户号")]
    public string? WEO_CustNo { get; set; }

    /// <summary>上刀任务号</summary>
    [SugarColumn(ColumnName = "WEO_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "上刀任务号")]
    public string? WEO_TaskNo { get; set; }

    /// <summary>上刀客户名称</summary>
    [SugarColumn(ColumnName = "WEO_CustName", Length = 100, IsNullable = true, ColumnDescription = "上刀客户名称")]
    public string? WEO_CustName { get; set; }

    /// <summary>上刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WEO_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "上刀标签材质代号")]
    public string? WEO_CustPaperCode { get; set; }

    /// <summary>上刀切宽mm</summary>
    [SugarColumn(ColumnName = "WEO_CutWidth", ColumnDescription = "上刀切宽mm")]
    public int WEO_CutWidth { get; set; }

    /// <summary>上刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WEO_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切宽英寸")]
    public decimal? WEO_CutWidthInch { get; set; }

    /// <summary>上刀切长mm</summary>
    [SugarColumn(ColumnName = "WEO_CutLength", ColumnDescription = "上刀切长mm")]
    public int WEO_CutLength { get; set; }

    /// <summary>上刀切长英寸</summary>
    [SugarColumn(ColumnName = "WEO_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切长英寸")]
    public decimal? WEO_CutLengthInch { get; set; }

    /// <summary>上刀切数</summary>
    [SugarColumn(ColumnName = "WEO_CutQty", ColumnDescription = "上刀切数")]
    public int WEO_CutQty { get; set; }

    /// <summary>上刀订单数</summary>
    [SugarColumn(ColumnName = "WEO_OrderQty", IsNullable = true, ColumnDescription = "上刀订单数")]
    public int? WEO_OrderQty { get; set; }

    /// <summary>上刀订单米数</summary>
    [SugarColumn(ColumnName = "WEO_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀订单米数")]
    public decimal? WEO_OrderMeter { get; set; }

    /// <summary>上刀订单未排数</summary>
    [SugarColumn(ColumnName = "WEO_OrderNoQty", IsNullable = true, ColumnDescription = "上刀订单未排数")]
    public int? WEO_OrderNoQty { get; set; }

    /// <summary>上刀标签打印数</summary>
    [SugarColumn(ColumnName = "WEO_LabelQty", IsNullable = true, ColumnDescription = "上刀标签打印数")]
    public int? WEO_LabelQty { get; set; }

    /// <summary>上刀剖数</summary>
    [SugarColumn(ColumnName = "WEO_CN", ColumnDescription = "上刀剖数")]
    public int WEO_CN { get; set; }

    /// <summary>上刀压线类型</summary>
    [SugarColumn(ColumnName = "WEO_ScorType", Length = 10, ColumnDescription = "上刀压线类型")]
    public string WEO_ScorType { get; set; } = default!;

    /// <summary>上刀压线信息</summary>
    [SugarColumn(ColumnName = "WEO_Scor", Length = 100, IsNullable = true, ColumnDescription = "上刀压线信息")]
    public string? WEO_Scor { get; set; }

    /// <summary>上刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WEO_ScorDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "上刀压线深度mm")]
    public decimal WEO_ScorDeep { get; set; }

    /// <summary>上刀生产备注</summary>
    [SugarColumn(ColumnName = "WEO_Remark", Length = 500, IsNullable = true, ColumnDescription = "上刀生产备注")]
    public string? WEO_Remark { get; set; }

    /// <summary>上刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WEO_Stack", ColumnDescription = "上刀堆叠模式")]
    public bool WEO_Stack { get; set; }

    /// <summary>上刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WEO_StackQty", IsNullable = true, ColumnDescription = "上刀堆叠数量")]
    public int? WEO_StackQty { get; set; }

    /// <summary>上刀每捆数量</summary>
    [SugarColumn(ColumnName = "WEO_BunQty", IsNullable = true, ColumnDescription = "上刀每捆数量")]
    public int? WEO_BunQty { get; set; }

    /// <summary>上刀是否错位</summary>
    [SugarColumn(ColumnName = "WEO_Bundle", ColumnDescription = "上刀是否错位")]
    public bool WEO_Bundle { get; set; }

    /// <summary>上刀错位张数</summary>
    [SugarColumn(ColumnName = "WEO_BundleQty", IsNullable = true, ColumnDescription = "上刀错位张数")]
    public int? WEO_BundleQty { get; set; }

    /// <summary>上刀错位数</summary>
    [SugarColumn(ColumnName = "WEO_BundleNum", IsNullable = true, ColumnDescription = "上刀错位数")]
    public int? WEO_BundleNum { get; set; }

    /// <summary>上刀订单日期</summary>
    [SugarColumn(ColumnName = "WEO_OrderDate", IsNullable = true, ColumnDescription = "上刀订单日期")]
    public DateTime? WEO_OrderDate { get; set; }

    /// <summary>上刀送货日期</summary>
    [SugarColumn(ColumnName = "WEO_DeliDate", IsNullable = true, ColumnDescription = "上刀送货日期")]
    public DateTime? WEO_DeliDate { get; set; }

    /// <summary>上刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WEO_StockMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀存货区域信息")]
    public string? WEO_StockMemo { get; set; }

    /// <summary>上刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WEO_BoxMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀纸箱信息")]
    public string? WEO_BoxMemo { get; set; }

    /// <summary>上刀理货信息</summary>
    [SugarColumn(ColumnName = "WEO_DeliMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀理货信息")]
    public string? WEO_DeliMemo { get; set; }

    /// <summary>上刀排单信息</summary>
    [SugarColumn(ColumnName = "WEO_PlanMemo", IsNullable = true, ColumnDescription = "上刀排单信息")]
    public string? WEO_PlanMemo { get; set; }

    /// <summary>上刀分纸信息</summary>
    [SugarColumn(ColumnName = "WEO_CutPaperMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀分纸信息")]
    public string? WEO_CutPaperMemo { get; set; }

    /// <summary>上刀备用</summary>
    [SugarColumn(ColumnName = "WEO_Memo", IsNullable = true, ColumnDescription = "上刀备用")]
    public string? WEO_Memo { get; set; }

    /// <summary>下刀订单号</summary>
    [SugarColumn(ColumnName = "WEO_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀订单号")]
    public string? WEO_OrderNo_D { get; set; }

    /// <summary>下刀客户号</summary>
    [SugarColumn(ColumnName = "WEO_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀客户号")]
    public string? WEO_CustNo_D { get; set; }

    /// <summary>下刀任务号</summary>
    [SugarColumn(ColumnName = "WEO_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀任务号")]
    public string? WEO_TaskNo_D { get; set; }

    /// <summary>下刀客户名称</summary>
    [SugarColumn(ColumnName = "WEO_CustName_D", Length = 100, IsNullable = true, ColumnDescription = "下刀客户名称")]
    public string? WEO_CustName_D { get; set; }

    /// <summary>下刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WEO_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "下刀标签材质代号")]
    public string? WEO_CustPaperCode_D { get; set; }

    /// <summary>下刀切宽mm</summary>
    [SugarColumn(ColumnName = "WEO_CutWidth_D", IsNullable = true, ColumnDescription = "下刀切宽mm")]
    public int? WEO_CutWidth_D { get; set; }

    /// <summary>下刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WEO_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切宽英寸")]
    public decimal? WEO_CutWidthInch_D { get; set; }

    /// <summary>下刀切长mm</summary>
    [SugarColumn(ColumnName = "WEO_CutLength_D", IsNullable = true, ColumnDescription = "下刀切长mm")]
    public int? WEO_CutLength_D { get; set; }

    /// <summary>下刀切长英寸</summary>
    [SugarColumn(ColumnName = "WEO_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切长英寸")]
    public decimal? WEO_CutLengthInch_D { get; set; }

    /// <summary>下刀切数</summary>
    [SugarColumn(ColumnName = "WEO_CutQty_D", IsNullable = true, ColumnDescription = "下刀切数")]
    public int? WEO_CutQty_D { get; set; }

    /// <summary>下刀订单数</summary>
    [SugarColumn(ColumnName = "WEO_OrderQty_D", IsNullable = true, ColumnDescription = "下刀订单数")]
    public int? WEO_OrderQty_D { get; set; }

    /// <summary>下刀订单米数</summary>
    [SugarColumn(ColumnName = "WEO_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀订单米数")]
    public decimal? WEO_OrderMeter_D { get; set; }

    /// <summary>下刀订单未排数</summary>
    [SugarColumn(ColumnName = "WEO_OrderNoQty_D", IsNullable = true, ColumnDescription = "下刀订单未排数")]
    public int? WEO_OrderNoQty_D { get; set; }

    /// <summary>下刀标签数</summary>
    [SugarColumn(ColumnName = "WEO_LabelQty_D", IsNullable = true, ColumnDescription = "下刀标签数")]
    public int? WEO_LabelQty_D { get; set; }

    /// <summary>下刀剖数</summary>
    [SugarColumn(ColumnName = "WEO_CN_D", IsNullable = true, ColumnDescription = "下刀剖数")]
    public int? WEO_CN_D { get; set; }

    /// <summary>下刀压线类型</summary>
    [SugarColumn(ColumnName = "WEO_ScorType_D", Length = 10, IsNullable = true, ColumnDescription = "下刀压线类型")]
    public string? WEO_ScorType_D { get; set; }

    /// <summary>下刀压线信息</summary>
    [SugarColumn(ColumnName = "WEO_Scor_D", Length = 100, IsNullable = true, ColumnDescription = "下刀压线信息")]
    public string? WEO_Scor_D { get; set; }

    /// <summary>下刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WEO_ScorDeep_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀压线深度mm")]
    public decimal? WEO_ScorDeep_D { get; set; }

    /// <summary>下刀生产备注</summary>
    [SugarColumn(ColumnName = "WEO_Remark_D", Length = 500, IsNullable = true, ColumnDescription = "下刀生产备注")]
    public string? WEO_Remark_D { get; set; }

    /// <summary>下刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WEO_Stack_D", IsNullable = true, ColumnDescription = "下刀堆叠模式")]
    public bool? WEO_Stack_D { get; set; }

    /// <summary>下刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WEO_StackQty_D", IsNullable = true, ColumnDescription = "下刀堆叠数量")]
    public int? WEO_StackQty_D { get; set; }

    /// <summary>下刀每捆数量</summary>
    [SugarColumn(ColumnName = "WEO_BunQty_D", IsNullable = true, ColumnDescription = "下刀每捆数量")]
    public int? WEO_BunQty_D { get; set; }

    /// <summary>下刀是否错位</summary>
    [SugarColumn(ColumnName = "WEO_Bundle_D", IsNullable = true, ColumnDescription = "下刀是否错位")]
    public bool? WEO_Bundle_D { get; set; }

    /// <summary>下刀错位张数</summary>
    [SugarColumn(ColumnName = "WEO_BundleQty_D", IsNullable = true, ColumnDescription = "下刀错位张数")]
    public int? WEO_BundleQty_D { get; set; }

    /// <summary>下刀错位数</summary>
    [SugarColumn(ColumnName = "WEO_BundleNum_D", IsNullable = true, ColumnDescription = "下刀错位数")]
    public int? WEO_BundleNum_D { get; set; }

    /// <summary>下刀订单日期</summary>
    [SugarColumn(ColumnName = "WEO_OrderDate_D", IsNullable = true, ColumnDescription = "下刀订单日期")]
    public DateTime? WEO_OrderDate_D { get; set; }

    /// <summary>下刀送货日期</summary>
    [SugarColumn(ColumnName = "WEO_DeliDate_D", IsNullable = true, ColumnDescription = "下刀送货日期")]
    public DateTime? WEO_DeliDate_D { get; set; }

    /// <summary>下刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WEO_StockMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀存货区域信息")]
    public string? WEO_StockMemo_D { get; set; }

    /// <summary>下刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WEO_BoxMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀纸箱信息")]
    public string? WEO_BoxMemo_D { get; set; }

    /// <summary>下刀理货信息</summary>
    [SugarColumn(ColumnName = "WEO_DeliMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀理货信息")]
    public string? WEO_DeliMemo_D { get; set; }

    /// <summary>下刀排程信息</summary>
    [SugarColumn(ColumnName = "WEO_PlanMemo_D", IsNullable = true, ColumnDescription = "下刀排程信息")]
    public string? WEO_PlanMemo_D { get; set; }

    /// <summary>下刀分纸信息</summary>
    [SugarColumn(ColumnName = "WEO_CutPaperMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀分纸信息")]
    public string? WEO_CutPaperMemo_D { get; set; }

    /// <summary>下刀备用</summary>
    [SugarColumn(ColumnName = "WEO_Memo_D", IsNullable = true, ColumnDescription = "下刀备用")]
    public string? WEO_Memo_D { get; set; }

    /// <summary>状态0未使用1成功2失败</summary>
    [SugarColumn(ColumnName = "WEO_Status", IsNullable = true, ColumnDescription = "状态0未使用1成功2失败")]
    public int? WEO_Status { get; set; }

    /// <summary>错误信息</summary>
    [SugarColumn(ColumnName = "WEO_ErrorMsg", IsNullable = true, ColumnDescription = "错误信息")]
    public string? WEO_ErrorMsg { get; set; }

    /// <summary>传单时间</summary>
    [SugarColumn(ColumnName = "WEO_OperDate", IsNullable = true, ColumnDescription = "传单时间")]
    public DateTime? WEO_OperDate { get; set; }

    /// <summary>WEO_TrimCode</summary>
    [SugarColumn(ColumnName = "WEO_TrimCode", ColumnDescription = "WEO_TrimCode")]
    public int WEO_TrimCode { get; set; }

    /// <summary>WEO_TOrderNo</summary>
    [SugarColumn(ColumnName = "WEO_TOrderNo", Length = 50, IsNullable = true, ColumnDescription = "WEO_TOrderNo")]
    public string? WEO_TOrderNo { get; set; }

    /// <summary>WEO_IsDouble</summary>
    [SugarColumn(ColumnName = "WEO_IsDouble", IsNullable = true, ColumnDescription = "WEO_IsDouble")]
    public bool? WEO_IsDouble { get; set; }

    /// <summary>WEO_SortSN</summary>
    [SugarColumn(ColumnName = "WEO_SortSN", IsNullable = true, ColumnDescription = "WEO_SortSN")]
    public int? WEO_SortSN { get; set; }

    /// <summary>WEO_ID</summary>
    [SugarColumn(ColumnName = "WEO_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WEO_ID")]
    public int WEO_ID { get; set; }

}