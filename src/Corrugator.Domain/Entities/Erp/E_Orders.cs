using SqlSugar;

namespace Corrugator.Domain.Entities.Erp;

/// <summary>
/// ERP订单中间表
/// </summary>
[SugarTable("E_Orders", TableDescription = "ERP订单中间表")]
public class E_Orders
{
    /// <summary>ERP订单接口表Guid</summary>
    [SugarColumn(ColumnName = "WEO_Guid", Length = 50, IsNullable = true, ColumnDescription = "ERP订单接口表Guid")]
    public string? WEO_Guid { get; set; }

    /// <summary>是否插单</summary>
    [SugarColumn(ColumnName = "EO_IsUrgent", ColumnDescription = "是否插单")]
    public bool EO_IsUrgent { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "EO_WorkNo", ColumnDescription = "工号")]
    public int EO_WorkNo { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "EO_ClassNo", Length = 50, IsNullable = true, ColumnDescription = "班组")]
    public string? EO_ClassNo { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "EO_PaperCode", Length = 50, ColumnDescription = "材质")]
    public string EO_PaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "EO_Wave", Length = 50, ColumnDescription = "楞型")]
    public string EO_Wave { get; set; } = default!;

    /// <summary>层数</summary>
    [SugarColumn(ColumnName = "EO_Floor", ColumnDescription = "层数")]
    public int EO_Floor { get; set; }

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "EO_Width", ColumnDescription = "门幅mm")]
    public int EO_Width { get; set; }

    /// <summary>修边mm</summary>
    [SugarColumn(ColumnName = "EO_Trim", IsNullable = true, ColumnDescription = "修边mm")]
    public int? EO_Trim { get; set; }

    /// <summary>门幅英寸</summary>
    [SugarColumn(ColumnName = "EO_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "门幅英寸")]
    public decimal? EO_WidthInch { get; set; }

    /// <summary>材质克重</summary>
    [SugarColumn(ColumnName = "EO_Weight", IsNullable = true, ColumnDescription = "材质克重")]
    public int? EO_Weight { get; set; }

    /// <summary>材质厚度</summary>
    [SugarColumn(ColumnName = "EO_Deep", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "材质厚度")]
    public decimal? EO_Deep { get; set; }

    /// <summary>第一层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor1", Length = 10, IsNullable = true, ColumnDescription = "第一层材质")]
    public string? EO_Floor1 { get; set; }

    /// <summary>第一层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor1Deep", IsNullable = true, ColumnDescription = "第一层材质厚度mm")]
    public int? EO_Floor1Deep { get; set; }

    /// <summary>第二层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor2", Length = 10, IsNullable = true, ColumnDescription = "第二层材质")]
    public string? EO_Floor2 { get; set; }

    /// <summary>第二层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor2Deep", IsNullable = true, ColumnDescription = "第二层材质厚度mm")]
    public int? EO_Floor2Deep { get; set; }

    /// <summary>第三层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor3", Length = 10, IsNullable = true, ColumnDescription = "第三层材质")]
    public string? EO_Floor3 { get; set; }

    /// <summary>第三层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor3Deep", IsNullable = true, ColumnDescription = "第三层材质厚度mm")]
    public int? EO_Floor3Deep { get; set; }

    /// <summary>第四层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor4", Length = 10, IsNullable = true, ColumnDescription = "第四层材质")]
    public string? EO_Floor4 { get; set; }

    /// <summary>第四层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor4Deep", IsNullable = true, ColumnDescription = "第四层材质厚度mm")]
    public int? EO_Floor4Deep { get; set; }

    /// <summary>第五层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor5", Length = 10, IsNullable = true, ColumnDescription = "第五层材质")]
    public string? EO_Floor5 { get; set; }

    /// <summary>第五层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor5Deep", IsNullable = true, ColumnDescription = "第五层材质厚度mm")]
    public int? EO_Floor5Deep { get; set; }

    /// <summary>第六层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor6", Length = 10, IsNullable = true, ColumnDescription = "第六层材质")]
    public string? EO_Floor6 { get; set; }

    /// <summary>第六层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor6Deep", IsNullable = true, ColumnDescription = "第六层材质厚度mm")]
    public int? EO_Floor6Deep { get; set; }

    /// <summary>第七层材质</summary>
    [SugarColumn(ColumnName = "EO_Floor7", Length = 10, IsNullable = true, ColumnDescription = "第七层材质")]
    public string? EO_Floor7 { get; set; }

    /// <summary>第七层材质厚度mm</summary>
    [SugarColumn(ColumnName = "EO_Floor7Deep", IsNullable = true, ColumnDescription = "第七层材质厚度mm")]
    public int? EO_Floor7Deep { get; set; }

    /// <summary>是否传单(ccc返回代码)</summary>
    [SugarColumn(ColumnName = "EO_Send", Length = 10, IsNullable = true, ColumnDescription = "是否传单(ccc返回代码)")]
    public string? EO_Send { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "EO_Speed", IsNullable = true, ColumnDescription = "限速")]
    public int? EO_Speed { get; set; }

    /// <summary>订单排程米数</summary>
    [SugarColumn(ColumnName = "EO_ScheduleMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "订单排程米数")]
    public decimal? EO_ScheduleMeter { get; set; }

    /// <summary>是否停换</summary>
    [SugarColumn(ColumnName = "EO_Stop", ColumnDescription = "是否停换")]
    public bool EO_Stop { get; set; }

    /// <summary>是否上刀走下刀</summary>
    [SugarColumn(ColumnName = "EO_UGoD", ColumnDescription = "是否上刀走下刀")]
    public bool EO_UGoD { get; set; }

    /// <summary>开始生产时间</summary>
    [SugarColumn(ColumnName = "EO_StartTime", IsNullable = true, ColumnDescription = "开始生产时间")]
    public DateTime? EO_StartTime { get; set; }

    /// <summary>预计完成时间</summary>
    [SugarColumn(ColumnName = "EO_EstFinshTime", IsNullable = true, ColumnDescription = "预计完成时间")]
    public DateTime? EO_EstFinshTime { get; set; }

    /// <summary>加减刀数</summary>
    [SugarColumn(ColumnName = "EO_ModCutQty", IsNullable = true, ColumnDescription = "加减刀数")]
    public int? EO_ModCutQty { get; set; }

    /// <summary>上刀订单号</summary>
    [SugarColumn(ColumnName = "EO_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "上刀订单号")]
    public string? EO_OrderNo { get; set; }

    /// <summary>上刀客户号</summary>
    [SugarColumn(ColumnName = "EO_CustNo", Length = 50, IsNullable = true, ColumnDescription = "上刀客户号")]
    public string? EO_CustNo { get; set; }

    /// <summary>上刀任务号</summary>
    [SugarColumn(ColumnName = "EO_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "上刀任务号")]
    public string? EO_TaskNo { get; set; }

    /// <summary>上刀客户名称</summary>
    [SugarColumn(ColumnName = "EO_CustName", Length = 100, IsNullable = true, ColumnDescription = "上刀客户名称")]
    public string? EO_CustName { get; set; }

    /// <summary>上刀标签材质代号</summary>
    [SugarColumn(ColumnName = "EO_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "上刀标签材质代号")]
    public string? EO_CustPaperCode { get; set; }

    /// <summary>上刀切宽mm</summary>
    [SugarColumn(ColumnName = "EO_CutWidth", ColumnDescription = "上刀切宽mm")]
    public int EO_CutWidth { get; set; }

    /// <summary>上刀切宽英寸</summary>
    [SugarColumn(ColumnName = "EO_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切宽英寸")]
    public decimal? EO_CutWidthInch { get; set; }

    /// <summary>上刀切长mm</summary>
    [SugarColumn(ColumnName = "EO_CutLength", ColumnDescription = "上刀切长mm")]
    public int EO_CutLength { get; set; }

    /// <summary>上刀切长英寸</summary>
    [SugarColumn(ColumnName = "EO_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切长英寸")]
    public decimal? EO_CutLengthInch { get; set; }

    /// <summary>上刀切数</summary>
    [SugarColumn(ColumnName = "EO_CutQty", ColumnDescription = "上刀切数")]
    public int EO_CutQty { get; set; }

    /// <summary>上刀订单数</summary>
    [SugarColumn(ColumnName = "EO_OrderQty", IsNullable = true, ColumnDescription = "上刀订单数")]
    public int? EO_OrderQty { get; set; }

    /// <summary>上刀订单米数</summary>
    [SugarColumn(ColumnName = "EO_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀订单米数")]
    public decimal? EO_OrderMeter { get; set; }

    /// <summary>上刀订单未排数</summary>
    [SugarColumn(ColumnName = "EO_OrderNoQty", IsNullable = true, ColumnDescription = "上刀订单未排数")]
    public int? EO_OrderNoQty { get; set; }

    /// <summary>上刀标签打印数</summary>
    [SugarColumn(ColumnName = "EO_LabelQty", IsNullable = true, ColumnDescription = "上刀标签打印数")]
    public int? EO_LabelQty { get; set; }

    /// <summary>上刀剖数</summary>
    [SugarColumn(ColumnName = "EO_CN", ColumnDescription = "上刀剖数")]
    public int EO_CN { get; set; }

    /// <summary>上刀压线类型</summary>
    [SugarColumn(ColumnName = "EO_ScorType", Length = 10, ColumnDescription = "上刀压线类型")]
    public string EO_ScorType { get; set; } = default!;

    /// <summary>上刀压线信息</summary>
    [SugarColumn(ColumnName = "EO_Scor", Length = 100, IsNullable = true, ColumnDescription = "上刀压线信息")]
    public string? EO_Scor { get; set; }

    /// <summary>上刀压线深度mm</summary>
    [SugarColumn(ColumnName = "EO_ScorDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "上刀压线深度mm")]
    public decimal EO_ScorDeep { get; set; }

    /// <summary>上刀生产备注</summary>
    [SugarColumn(ColumnName = "EO_Remark", Length = 500, IsNullable = true, ColumnDescription = "上刀生产备注")]
    public string? EO_Remark { get; set; }

    /// <summary>上刀堆叠模式</summary>
    [SugarColumn(ColumnName = "EO_Stack", ColumnDescription = "上刀堆叠模式")]
    public bool EO_Stack { get; set; }

    /// <summary>上刀堆叠数量</summary>
    [SugarColumn(ColumnName = "EO_StackQty", IsNullable = true, ColumnDescription = "上刀堆叠数量")]
    public int? EO_StackQty { get; set; }

    /// <summary>上刀每捆数量</summary>
    [SugarColumn(ColumnName = "EO_BunQty", IsNullable = true, ColumnDescription = "上刀每捆数量")]
    public int? EO_BunQty { get; set; }

    /// <summary>上刀是否错位</summary>
    [SugarColumn(ColumnName = "EO_Bundle", ColumnDescription = "上刀是否错位")]
    public bool EO_Bundle { get; set; }

    /// <summary>上刀错位张数</summary>
    [SugarColumn(ColumnName = "EO_BundleQty", IsNullable = true, ColumnDescription = "上刀错位张数")]
    public int? EO_BundleQty { get; set; }

    /// <summary>上刀错位数</summary>
    [SugarColumn(ColumnName = "EO_BundleNum", IsNullable = true, ColumnDescription = "上刀错位数")]
    public int? EO_BundleNum { get; set; }

    /// <summary>上刀订单日期</summary>
    [SugarColumn(ColumnName = "EO_OrderDate", IsNullable = true, ColumnDescription = "上刀订单日期")]
    public DateTime? EO_OrderDate { get; set; }

    /// <summary>上刀送货日期</summary>
    [SugarColumn(ColumnName = "EO_DeliDate", IsNullable = true, ColumnDescription = "上刀送货日期")]
    public DateTime? EO_DeliDate { get; set; }

    /// <summary>上刀存货区域信息</summary>
    [SugarColumn(ColumnName = "EO_StockMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀存货区域信息")]
    public string? EO_StockMemo { get; set; }

    /// <summary>上刀纸箱信息</summary>
    [SugarColumn(ColumnName = "EO_BoxMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀纸箱信息")]
    public string? EO_BoxMemo { get; set; }

    /// <summary>上刀理货信息</summary>
    [SugarColumn(ColumnName = "EO_DeliMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀理货信息")]
    public string? EO_DeliMemo { get; set; }

    /// <summary>上刀排单信息</summary>
    [SugarColumn(ColumnName = "EO_PlanMemo", IsNullable = true, ColumnDescription = "上刀排单信息")]
    public string? EO_PlanMemo { get; set; }

    /// <summary>上刀分纸信息</summary>
    [SugarColumn(ColumnName = "EO_CutPaperMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀分纸信息")]
    public string? EO_CutPaperMemo { get; set; }

    /// <summary>上刀备用</summary>
    [SugarColumn(ColumnName = "EO_Memo", IsNullable = true, ColumnDescription = "上刀备用")]
    public string? EO_Memo { get; set; }

    /// <summary>下刀订单号</summary>
    [SugarColumn(ColumnName = "EO_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀订单号")]
    public string? EO_OrderNo_D { get; set; }

    /// <summary>下刀客户号</summary>
    [SugarColumn(ColumnName = "EO_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀客户号")]
    public string? EO_CustNo_D { get; set; }

    /// <summary>下刀任务号</summary>
    [SugarColumn(ColumnName = "EO_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀任务号")]
    public string? EO_TaskNo_D { get; set; }

    /// <summary>下刀客户名称</summary>
    [SugarColumn(ColumnName = "EO_CustName_D", Length = 100, IsNullable = true, ColumnDescription = "下刀客户名称")]
    public string? EO_CustName_D { get; set; }

    /// <summary>下刀标签材质代号</summary>
    [SugarColumn(ColumnName = "EO_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "下刀标签材质代号")]
    public string? EO_CustPaperCode_D { get; set; }

    /// <summary>下刀切宽mm</summary>
    [SugarColumn(ColumnName = "EO_CutWidth_D", IsNullable = true, ColumnDescription = "下刀切宽mm")]
    public int? EO_CutWidth_D { get; set; }

    /// <summary>下刀切宽英寸</summary>
    [SugarColumn(ColumnName = "EO_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切宽英寸")]
    public decimal? EO_CutWidthInch_D { get; set; }

    /// <summary>下刀切长mm</summary>
    [SugarColumn(ColumnName = "EO_CutLength_D", IsNullable = true, ColumnDescription = "下刀切长mm")]
    public int? EO_CutLength_D { get; set; }

    /// <summary>下刀切长英寸</summary>
    [SugarColumn(ColumnName = "EO_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切长英寸")]
    public decimal? EO_CutLengthInch_D { get; set; }

    /// <summary>下刀切数</summary>
    [SugarColumn(ColumnName = "EO_CutQty_D", IsNullable = true, ColumnDescription = "下刀切数")]
    public int? EO_CutQty_D { get; set; }

    /// <summary>下刀订单数</summary>
    [SugarColumn(ColumnName = "EO_OrderQty_D", IsNullable = true, ColumnDescription = "下刀订单数")]
    public int? EO_OrderQty_D { get; set; }

    /// <summary>下刀订单米数</summary>
    [SugarColumn(ColumnName = "EO_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀订单米数")]
    public decimal? EO_OrderMeter_D { get; set; }

    /// <summary>下刀订单未排数</summary>
    [SugarColumn(ColumnName = "EO_OrderNoQty_D", IsNullable = true, ColumnDescription = "下刀订单未排数")]
    public int? EO_OrderNoQty_D { get; set; }

    /// <summary>下刀标签数</summary>
    [SugarColumn(ColumnName = "EO_LabelQty_D", IsNullable = true, ColumnDescription = "下刀标签数")]
    public int? EO_LabelQty_D { get; set; }

    /// <summary>下刀剖数</summary>
    [SugarColumn(ColumnName = "EO_CN_D", IsNullable = true, ColumnDescription = "下刀剖数")]
    public int? EO_CN_D { get; set; }

    /// <summary>下刀压线类型</summary>
    [SugarColumn(ColumnName = "EO_ScorType_D", Length = 10, IsNullable = true, ColumnDescription = "下刀压线类型")]
    public string? EO_ScorType_D { get; set; }

    /// <summary>下刀压线信息</summary>
    [SugarColumn(ColumnName = "EO_Scor_D", Length = 100, IsNullable = true, ColumnDescription = "下刀压线信息")]
    public string? EO_Scor_D { get; set; }

    /// <summary>下刀压线深度mm</summary>
    [SugarColumn(ColumnName = "EO_ScorDeep_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀压线深度mm")]
    public decimal? EO_ScorDeep_D { get; set; }

    /// <summary>下刀生产备注</summary>
    [SugarColumn(ColumnName = "EO_Remark_D", Length = 500, IsNullable = true, ColumnDescription = "下刀生产备注")]
    public string? EO_Remark_D { get; set; }

    /// <summary>下刀堆叠模式</summary>
    [SugarColumn(ColumnName = "EO_Stack_D", IsNullable = true, ColumnDescription = "下刀堆叠模式")]
    public bool? EO_Stack_D { get; set; }

    /// <summary>下刀堆叠数量</summary>
    [SugarColumn(ColumnName = "EO_StackQty_D", IsNullable = true, ColumnDescription = "下刀堆叠数量")]
    public int? EO_StackQty_D { get; set; }

    /// <summary>下刀每捆数量</summary>
    [SugarColumn(ColumnName = "EO_BunQty_D", IsNullable = true, ColumnDescription = "下刀每捆数量")]
    public int? EO_BunQty_D { get; set; }

    /// <summary>下刀是否错位</summary>
    [SugarColumn(ColumnName = "EO_Bundle_D", IsNullable = true, ColumnDescription = "下刀是否错位")]
    public bool? EO_Bundle_D { get; set; }

    /// <summary>下刀错位张数</summary>
    [SugarColumn(ColumnName = "EO_BundleQty_D", IsNullable = true, ColumnDescription = "下刀错位张数")]
    public int? EO_BundleQty_D { get; set; }

    /// <summary>下刀错位数</summary>
    [SugarColumn(ColumnName = "EO_BundleNum_D", IsNullable = true, ColumnDescription = "下刀错位数")]
    public int? EO_BundleNum_D { get; set; }

    /// <summary>下刀订单日期</summary>
    [SugarColumn(ColumnName = "EO_OrderDate_D", IsNullable = true, ColumnDescription = "下刀订单日期")]
    public DateTime? EO_OrderDate_D { get; set; }

    /// <summary>下刀送货日期</summary>
    [SugarColumn(ColumnName = "EO_DeliDate_D", IsNullable = true, ColumnDescription = "下刀送货日期")]
    public DateTime? EO_DeliDate_D { get; set; }

    /// <summary>下刀存货区域信息</summary>
    [SugarColumn(ColumnName = "EO_StockMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀存货区域信息")]
    public string? EO_StockMemo_D { get; set; }

    /// <summary>下刀纸箱信息</summary>
    [SugarColumn(ColumnName = "EO_BoxMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀纸箱信息")]
    public string? EO_BoxMemo_D { get; set; }

    /// <summary>下刀理货信息</summary>
    [SugarColumn(ColumnName = "EO_DeliMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀理货信息")]
    public string? EO_DeliMemo_D { get; set; }

    /// <summary>下刀排程信息</summary>
    [SugarColumn(ColumnName = "EO_PlanMemo_D", IsNullable = true, ColumnDescription = "下刀排程信息")]
    public string? EO_PlanMemo_D { get; set; }

    /// <summary>下刀分纸信息</summary>
    [SugarColumn(ColumnName = "EO_CutPaperMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀分纸信息")]
    public string? EO_CutPaperMemo_D { get; set; }

    /// <summary>下刀备用</summary>
    [SugarColumn(ColumnName = "EO_Memo_D", IsNullable = true, ColumnDescription = "下刀备用")]
    public string? EO_Memo_D { get; set; }

    /// <summary>状态0未使用1成功2失败</summary>
    [SugarColumn(ColumnName = "EO_Status", IsNullable = true, ColumnDescription = "状态0未使用1成功2失败")]
    public int? EO_Status { get; set; }

    /// <summary>错误信息</summary>
    [SugarColumn(ColumnName = "EO_ErrorMsg", IsNullable = true, ColumnDescription = "错误信息")]
    public string? EO_ErrorMsg { get; set; }

    /// <summary>传单时间</summary>
    [SugarColumn(ColumnName = "EO_OperDate", IsNullable = true, ColumnDescription = "传单时间")]
    public DateTime? EO_OperDate { get; set; }

    /// <summary>EO_TrimCode</summary>
    [SugarColumn(ColumnName = "EO_TrimCode", ColumnDescription = "EO_TrimCode")]
    public int EO_TrimCode { get; set; }

    /// <summary>EO_TOrderNo</summary>
    [SugarColumn(ColumnName = "EO_TOrderNo", Length = 50, IsNullable = true, ColumnDescription = "EO_TOrderNo")]
    public string? EO_TOrderNo { get; set; }

    /// <summary>EO_IsDouble</summary>
    [SugarColumn(ColumnName = "EO_IsDouble", IsNullable = true, ColumnDescription = "EO_IsDouble")]
    public bool? EO_IsDouble { get; set; }

    /// <summary>EO_SortSN</summary>
    [SugarColumn(ColumnName = "EO_SortSN", IsNullable = true, ColumnDescription = "EO_SortSN")]
    public int? EO_SortSN { get; set; }

    /// <summary>EO_ID</summary>
    [SugarColumn(ColumnName = "EO_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "EO_ID")]
    public int EO_ID { get; set; }

}