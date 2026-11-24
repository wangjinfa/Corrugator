using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 未完工表
/// </summary>
[SugarTable("W_Orders", TableDescription = "未完工表")]
public class W_Orders
{
    /// <summary>ERP订单接口表Guid</summary>
    [SugarColumn(ColumnName = "WEO_Guid", Length = 50, IsNullable = true, ColumnDescription = "ERP订单接口表Guid")]
    public string? WEO_Guid { get; set; }

    /// <summary>WO_IsUrgent</summary>
    [SugarColumn(ColumnName = "WO_IsUrgent", ColumnDescription = "WO_IsUrgent")]
    public bool WO_IsUrgent { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "WO_WorkNo", ColumnDescription = "工号")]
    public int WO_WorkNo { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "WO_ClassNo", Length = 50, IsNullable = true, ColumnDescription = "班组")]
    public string? WO_ClassNo { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WO_PaperCode", Length = 50, ColumnDescription = "材质")]
    public string WO_PaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WO_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WO_Wave { get; set; } = default!;

    /// <summary>层数</summary>
    [SugarColumn(ColumnName = "WO_Floor", ColumnDescription = "层数")]
    public int WO_Floor { get; set; }

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "WO_Width", ColumnDescription = "门幅mm")]
    public int WO_Width { get; set; }

    /// <summary>修边mm</summary>
    [SugarColumn(ColumnName = "WO_Trim", ColumnDescription = "修边mm")]
    public int WO_Trim { get; set; }

    /// <summary>门幅英寸</summary>
    [SugarColumn(ColumnName = "WO_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "门幅英寸")]
    public decimal? WO_WidthInch { get; set; }

    /// <summary>材质克重</summary>
    [SugarColumn(ColumnName = "WO_Weight", IsNullable = true, ColumnDescription = "材质克重")]
    public int? WO_Weight { get; set; }

    /// <summary>材质厚度</summary>
    [SugarColumn(ColumnName = "WO_Deep", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "材质厚度")]
    public decimal? WO_Deep { get; set; }

    /// <summary>第一层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor1", Length = 10, IsNullable = true, ColumnDescription = "第一层材质")]
    public string? WO_Floor1 { get; set; }

    /// <summary>第一层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor1Deep", IsNullable = true, ColumnDescription = "第一层材质厚度mm")]
    public int? WO_Floor1Deep { get; set; }

    /// <summary>第二层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor2", Length = 10, IsNullable = true, ColumnDescription = "第二层材质")]
    public string? WO_Floor2 { get; set; }

    /// <summary>第二层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor2Deep", IsNullable = true, ColumnDescription = "第二层材质厚度mm")]
    public int? WO_Floor2Deep { get; set; }

    /// <summary>第三层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor3", Length = 10, IsNullable = true, ColumnDescription = "第三层材质")]
    public string? WO_Floor3 { get; set; }

    /// <summary>第三层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor3Deep", IsNullable = true, ColumnDescription = "第三层材质厚度mm")]
    public int? WO_Floor3Deep { get; set; }

    /// <summary>第四层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor4", Length = 10, IsNullable = true, ColumnDescription = "第四层材质")]
    public string? WO_Floor4 { get; set; }

    /// <summary>第四层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor4Deep", IsNullable = true, ColumnDescription = "第四层材质厚度mm")]
    public int? WO_Floor4Deep { get; set; }

    /// <summary>第五层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor5", Length = 10, IsNullable = true, ColumnDescription = "第五层材质")]
    public string? WO_Floor5 { get; set; }

    /// <summary>第五层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor5Deep", IsNullable = true, ColumnDescription = "第五层材质厚度mm")]
    public int? WO_Floor5Deep { get; set; }

    /// <summary>第六层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor6", Length = 10, IsNullable = true, ColumnDescription = "第六层材质")]
    public string? WO_Floor6 { get; set; }

    /// <summary>第六层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor6Deep", IsNullable = true, ColumnDescription = "第六层材质厚度mm")]
    public int? WO_Floor6Deep { get; set; }

    /// <summary>第七层材质</summary>
    [SugarColumn(ColumnName = "WO_Floor7", Length = 10, IsNullable = true, ColumnDescription = "第七层材质")]
    public string? WO_Floor7 { get; set; }

    /// <summary>第七层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WO_Floor7Deep", IsNullable = true, ColumnDescription = "第七层材质厚度mm")]
    public int? WO_Floor7Deep { get; set; }

    /// <summary>是否传单(ccc返回代码)</summary>
    [SugarColumn(ColumnName = "WO_Send", Length = 10, IsNullable = true, ColumnDescription = "是否传单(ccc返回代码)")]
    public string? WO_Send { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "WO_Speed", ColumnDescription = "限速")]
    public int WO_Speed { get; set; }

    /// <summary>订单排程米数</summary>
    [SugarColumn(ColumnName = "WO_ScheduleMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "订单排程米数")]
    public decimal? WO_ScheduleMeter { get; set; }

    /// <summary>是否停换</summary>
    [SugarColumn(ColumnName = "WO_Stop", ColumnDescription = "是否停换")]
    public bool WO_Stop { get; set; }

    /// <summary>是否上刀走下刀</summary>
    [SugarColumn(ColumnName = "WO_UGoD", ColumnDescription = "是否上刀走下刀")]
    public bool WO_UGoD { get; set; }

    /// <summary>开始生产时间</summary>
    [SugarColumn(ColumnName = "WO_StartTime", IsNullable = true, ColumnDescription = "开始生产时间")]
    public DateTime? WO_StartTime { get; set; }

    /// <summary>预计完成时间</summary>
    [SugarColumn(ColumnName = "WO_EstFinshTime", IsNullable = true, ColumnDescription = "预计完成时间")]
    public DateTime? WO_EstFinshTime { get; set; }

    /// <summary>加减刀数</summary>
    [SugarColumn(ColumnName = "WO_ModCutQty", IsNullable = true, ColumnDescription = "加减刀数")]
    public int? WO_ModCutQty { get; set; }

    /// <summary>上刀订单号</summary>
    [SugarColumn(ColumnName = "WO_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "上刀订单号")]
    public string? WO_OrderNo { get; set; }

    /// <summary>上刀客户号</summary>
    [SugarColumn(ColumnName = "WO_CustNo", Length = 50, IsNullable = true, ColumnDescription = "上刀客户号")]
    public string? WO_CustNo { get; set; }

    /// <summary>上刀任务号</summary>
    [SugarColumn(ColumnName = "WO_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "上刀任务号")]
    public string? WO_TaskNo { get; set; }

    /// <summary>上刀客户名称</summary>
    [SugarColumn(ColumnName = "WO_CustName", Length = 100, IsNullable = true, ColumnDescription = "上刀客户名称")]
    public string? WO_CustName { get; set; }

    /// <summary>上刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WO_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "上刀标签材质代号")]
    public string? WO_CustPaperCode { get; set; }

    /// <summary>上刀切宽mm</summary>
    [SugarColumn(ColumnName = "WO_CutWidth", ColumnDescription = "上刀切宽mm")]
    public int WO_CutWidth { get; set; }

    /// <summary>上刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WO_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切宽英寸")]
    public decimal? WO_CutWidthInch { get; set; }

    /// <summary>上刀切长mm</summary>
    [SugarColumn(ColumnName = "WO_CutLength", ColumnDescription = "上刀切长mm")]
    public int WO_CutLength { get; set; }

    /// <summary>上刀切长英寸</summary>
    [SugarColumn(ColumnName = "WO_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切长英寸")]
    public decimal? WO_CutLengthInch { get; set; }

    /// <summary>上刀切数</summary>
    [SugarColumn(ColumnName = "WO_CutQty", ColumnDescription = "上刀切数")]
    public int WO_CutQty { get; set; }

    /// <summary>上刀订单数</summary>
    [SugarColumn(ColumnName = "WO_OrderQty", IsNullable = true, ColumnDescription = "上刀订单数")]
    public int? WO_OrderQty { get; set; }

    /// <summary>上刀订单米数</summary>
    [SugarColumn(ColumnName = "WO_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀订单米数")]
    public decimal? WO_OrderMeter { get; set; }

    /// <summary>上刀订单未排数</summary>
    [SugarColumn(ColumnName = "WO_OrderNoQty", IsNullable = true, ColumnDescription = "上刀订单未排数")]
    public int? WO_OrderNoQty { get; set; }

    /// <summary>上刀标签打印数</summary>
    [SugarColumn(ColumnName = "WO_LabelQty", IsNullable = true, ColumnDescription = "上刀标签打印数")]
    public int? WO_LabelQty { get; set; }

    /// <summary>上刀剖数</summary>
    [SugarColumn(ColumnName = "WO_CN", ColumnDescription = "上刀剖数")]
    public int WO_CN { get; set; }

    /// <summary>上刀压线类型</summary>
    [SugarColumn(ColumnName = "WO_ScorType", Length = 10, ColumnDescription = "上刀压线类型")]
    public string WO_ScorType { get; set; } = default!;

    /// <summary>上刀压线信息</summary>
    [SugarColumn(ColumnName = "WO_Scor", Length = 100, IsNullable = true, ColumnDescription = "上刀压线信息")]
    public string? WO_Scor { get; set; }

    /// <summary>上刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WO_ScorDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "上刀压线深度mm")]
    public decimal WO_ScorDeep { get; set; }

    /// <summary>上刀生产备注</summary>
    [SugarColumn(ColumnName = "WO_Remark", Length = 500, IsNullable = true, ColumnDescription = "上刀生产备注")]
    public string? WO_Remark { get; set; }

    /// <summary>上刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WO_Stack", ColumnDescription = "上刀堆叠模式")]
    public bool WO_Stack { get; set; }

    /// <summary>上刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WO_StackQty", ColumnDescription = "上刀堆叠数量")]
    public int WO_StackQty { get; set; }

    /// <summary>上刀每捆数量</summary>
    [SugarColumn(ColumnName = "WO_BunQty", IsNullable = true, ColumnDescription = "上刀每捆数量")]
    public int? WO_BunQty { get; set; }

    /// <summary>上刀是否错位</summary>
    [SugarColumn(ColumnName = "WO_Bundle", ColumnDescription = "上刀是否错位")]
    public bool WO_Bundle { get; set; }

    /// <summary>上刀错位张数</summary>
    [SugarColumn(ColumnName = "WO_BundleQty", ColumnDescription = "上刀错位张数")]
    public int WO_BundleQty { get; set; }

    /// <summary>上刀错位数</summary>
    [SugarColumn(ColumnName = "WO_BundleNum", ColumnDescription = "上刀错位数")]
    public int WO_BundleNum { get; set; }

    /// <summary>上刀订单日期</summary>
    [SugarColumn(ColumnName = "WO_OrderDate", IsNullable = true, ColumnDescription = "上刀订单日期")]
    public DateTime? WO_OrderDate { get; set; }

    /// <summary>上刀送货日期</summary>
    [SugarColumn(ColumnName = "WO_DeliDate", IsNullable = true, ColumnDescription = "上刀送货日期")]
    public DateTime? WO_DeliDate { get; set; }

    /// <summary>上刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WO_StockMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀存货区域信息")]
    public string? WO_StockMemo { get; set; }

    /// <summary>上刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WO_BoxMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀纸箱信息")]
    public string? WO_BoxMemo { get; set; }

    /// <summary>上刀理货信息</summary>
    [SugarColumn(ColumnName = "WO_DeliMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀理货信息")]
    public string? WO_DeliMemo { get; set; }

    /// <summary>上刀排单信息</summary>
    [SugarColumn(ColumnName = "WO_PlanMemo", IsNullable = true, ColumnDescription = "上刀排单信息")]
    public string? WO_PlanMemo { get; set; }

    /// <summary>上刀分纸信息</summary>
    [SugarColumn(ColumnName = "WO_CutPaperMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀分纸信息")]
    public string? WO_CutPaperMemo { get; set; }

    /// <summary>上刀备用</summary>
    [SugarColumn(ColumnName = "WO_Memo", IsNullable = true, ColumnDescription = "上刀备用")]
    public string? WO_Memo { get; set; }

    /// <summary>下刀订单号</summary>
    [SugarColumn(ColumnName = "WO_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀订单号")]
    public string? WO_OrderNo_D { get; set; }

    /// <summary>下刀客户号</summary>
    [SugarColumn(ColumnName = "WO_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀客户号")]
    public string? WO_CustNo_D { get; set; }

    /// <summary>下刀任务号</summary>
    [SugarColumn(ColumnName = "WO_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀任务号")]
    public string? WO_TaskNo_D { get; set; }

    /// <summary>下刀客户名称</summary>
    [SugarColumn(ColumnName = "WO_CustName_D", Length = 100, IsNullable = true, ColumnDescription = "下刀客户名称")]
    public string? WO_CustName_D { get; set; }

    /// <summary>下刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WO_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "下刀标签材质代号")]
    public string? WO_CustPaperCode_D { get; set; }

    /// <summary>下刀切宽mm</summary>
    [SugarColumn(ColumnName = "WO_CutWidth_D", IsNullable = true, ColumnDescription = "下刀切宽mm")]
    public int? WO_CutWidth_D { get; set; }

    /// <summary>下刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WO_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切宽英寸")]
    public decimal? WO_CutWidthInch_D { get; set; }

    /// <summary>下刀切长mm</summary>
    [SugarColumn(ColumnName = "WO_CutLength_D", IsNullable = true, ColumnDescription = "下刀切长mm")]
    public int? WO_CutLength_D { get; set; }

    /// <summary>下刀切长英寸</summary>
    [SugarColumn(ColumnName = "WO_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切长英寸")]
    public decimal? WO_CutLengthInch_D { get; set; }

    /// <summary>下刀切数</summary>
    [SugarColumn(ColumnName = "WO_CutQty_D", IsNullable = true, ColumnDescription = "下刀切数")]
    public int? WO_CutQty_D { get; set; }

    /// <summary>下刀订单数</summary>
    [SugarColumn(ColumnName = "WO_OrderQty_D", IsNullable = true, ColumnDescription = "下刀订单数")]
    public int? WO_OrderQty_D { get; set; }

    /// <summary>下刀订单米数</summary>
    [SugarColumn(ColumnName = "WO_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀订单米数")]
    public decimal? WO_OrderMeter_D { get; set; }

    /// <summary>下刀订单未排数</summary>
    [SugarColumn(ColumnName = "WO_OrderNoQty_D", IsNullable = true, ColumnDescription = "下刀订单未排数")]
    public int? WO_OrderNoQty_D { get; set; }

    /// <summary>下刀标签数</summary>
    [SugarColumn(ColumnName = "WO_LabelQty_D", IsNullable = true, ColumnDescription = "下刀标签数")]
    public int? WO_LabelQty_D { get; set; }

    /// <summary>下刀剖数</summary>
    [SugarColumn(ColumnName = "WO_CN_D", IsNullable = true, ColumnDescription = "下刀剖数")]
    public int? WO_CN_D { get; set; }

    /// <summary>下刀压线类型</summary>
    [SugarColumn(ColumnName = "WO_ScorType_D", Length = 10, IsNullable = true, ColumnDescription = "下刀压线类型")]
    public string? WO_ScorType_D { get; set; }

    /// <summary>下刀压线信息</summary>
    [SugarColumn(ColumnName = "WO_Scor_D", Length = 100, IsNullable = true, ColumnDescription = "下刀压线信息")]
    public string? WO_Scor_D { get; set; }

    /// <summary>下刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WO_ScorDeep_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀压线深度mm")]
    public decimal? WO_ScorDeep_D { get; set; }

    /// <summary>下刀生产备注</summary>
    [SugarColumn(ColumnName = "WO_Remark_D", Length = 500, IsNullable = true, ColumnDescription = "下刀生产备注")]
    public string? WO_Remark_D { get; set; }

    /// <summary>下刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WO_Stack_D", IsNullable = true, ColumnDescription = "下刀堆叠模式")]
    public bool? WO_Stack_D { get; set; }

    /// <summary>下刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WO_StackQty_D", IsNullable = true, ColumnDescription = "下刀堆叠数量")]
    public int? WO_StackQty_D { get; set; }

    /// <summary>下刀每捆数量</summary>
    [SugarColumn(ColumnName = "WO_BunQty_D", IsNullable = true, ColumnDescription = "下刀每捆数量")]
    public int? WO_BunQty_D { get; set; }

    /// <summary>下刀是否错位</summary>
    [SugarColumn(ColumnName = "WO_Bundle_D", IsNullable = true, ColumnDescription = "下刀是否错位")]
    public bool? WO_Bundle_D { get; set; }

    /// <summary>下刀错位张数</summary>
    [SugarColumn(ColumnName = "WO_BundleQty_D", IsNullable = true, ColumnDescription = "下刀错位张数")]
    public int? WO_BundleQty_D { get; set; }

    /// <summary>下刀错位数</summary>
    [SugarColumn(ColumnName = "WO_BundleNum_D", IsNullable = true, ColumnDescription = "下刀错位数")]
    public int? WO_BundleNum_D { get; set; }

    /// <summary>下刀订单日期</summary>
    [SugarColumn(ColumnName = "WO_OrderDate_D", IsNullable = true, ColumnDescription = "下刀订单日期")]
    public DateTime? WO_OrderDate_D { get; set; }

    /// <summary>下刀送货日期</summary>
    [SugarColumn(ColumnName = "WO_DeliDate_D", IsNullable = true, ColumnDescription = "下刀送货日期")]
    public DateTime? WO_DeliDate_D { get; set; }

    /// <summary>下刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WO_StockMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀存货区域信息")]
    public string? WO_StockMemo_D { get; set; }

    /// <summary>下刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WO_BoxMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀纸箱信息")]
    public string? WO_BoxMemo_D { get; set; }

    /// <summary>下刀理货信息</summary>
    [SugarColumn(ColumnName = "WO_DeliMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀理货信息")]
    public string? WO_DeliMemo_D { get; set; }

    /// <summary>下刀排程信息</summary>
    [SugarColumn(ColumnName = "WO_PlanMemo_D", IsNullable = true, ColumnDescription = "下刀排程信息")]
    public string? WO_PlanMemo_D { get; set; }

    /// <summary>下刀分纸信息</summary>
    [SugarColumn(ColumnName = "WO_CutPaperMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀分纸信息")]
    public string? WO_CutPaperMemo_D { get; set; }

    /// <summary>下刀备用</summary>
    [SugarColumn(ColumnName = "WO_Memo_D", IsNullable = true, ColumnDescription = "下刀备用")]
    public string? WO_Memo_D { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "WO_IsDel", IsNullable = true, ColumnDescription = "是否删除")]
    public bool? WO_IsDel { get; set; }

    /// <summary>WO_IsFake</summary>
    [SugarColumn(ColumnName = "WO_IsFake", ColumnDescription = "WO_IsFake")]
    public bool WO_IsFake { get; set; }

    /// <summary>打印次数</summary>
    [SugarColumn(ColumnName = "WO_PrintNum", ColumnDescription = "打印次数")]
    public int WO_PrintNum { get; set; }

    /// <summary>WO_TrimCode</summary>
    [SugarColumn(ColumnName = "WO_TrimCode", ColumnDescription = "WO_TrimCode")]
    public int WO_TrimCode { get; set; }

    /// <summary>WO_OperType</summary>
    [SugarColumn(ColumnName = "WO_OperType", ColumnDescription = "WO_OperType")]
    public int WO_OperType { get; set; }

    /// <summary>WO_ERPCutQty</summary>
    [SugarColumn(ColumnName = "WO_ERPCutQty", ColumnDescription = "WO_ERPCutQty")]
    public int WO_ERPCutQty { get; set; }

    /// <summary>WO_ERPCutQty_D</summary>
    [SugarColumn(ColumnName = "WO_ERPCutQty_D", IsNullable = true, ColumnDescription = "WO_ERPCutQty_D")]
    public int? WO_ERPCutQty_D { get; set; }

    /// <summary>WO_IsDouble</summary>
    [SugarColumn(ColumnName = "WO_IsDouble", IsNullable = true, ColumnDescription = "WO_IsDouble")]
    public bool? WO_IsDouble { get; set; }

    /// <summary>WO_IsOppositeStack</summary>
    [SugarColumn(ColumnName = "WO_IsOppositeStack", ColumnDescription = "WO_IsOppositeStack")]
    public bool WO_IsOppositeStack { get; set; }

    /// <summary>WO_IsOppositeStack_D</summary>
    [SugarColumn(ColumnName = "WO_IsOppositeStack_D", ColumnDescription = "WO_IsOppositeStack_D")]
    public bool WO_IsOppositeStack_D { get; set; }

    /// <summary>排序值</summary>
    [SugarColumn(ColumnName = "WO_SortSN", IsNullable = true, ColumnDescription = "排序值")]
    public int? WO_SortSN { get; set; }

    /// <summary>暂停状态</summary>
    [SugarColumn(ColumnName = "WO_TuneInStatue", ColumnDescription = "暂停状态")]
    public int WO_TuneInStatue { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF2PlanUseFluteSF2", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WO_SF2PlanUseFluteSF2 { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF3PlanUseFluteSF3", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WO_SF3PlanUseFluteSF3 { get; set; }

    /// <summary>SF1实际使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF1ActUseFlute", Length = 50, IsNullable = true, ColumnDescription = "SF1实际使用楞型")]
    public string? WO_SF1ActUseFlute { get; set; }

    /// <summary>SF2实际使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF2ActUseFlute", Length = 50, IsNullable = true, ColumnDescription = "SF2实际使用楞型")]
    public string? WO_SF2ActUseFlute { get; set; }

    /// <summary>SF3实际使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF3ActUseFlute", Length = 50, IsNullable = true, ColumnDescription = "SF3实际使用楞型")]
    public string? WO_SF3ActUseFlute { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WO_SF1PlanUseFluteSF1", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WO_SF1PlanUseFluteSF1 { get; set; }

    /// <summary>WO_WavaType</summary>
    [SugarColumn(ColumnName = "WO_WavaType", Length = 50, IsNullable = true, ColumnDescription = "WO_WavaType")]
    public string? WO_WavaType { get; set; }

    /// <summary>WO_IsCalStack</summary>
    [SugarColumn(ColumnName = "WO_IsCalStack", IsNullable = true, ColumnDescription = "WO_IsCalStack")]
    public bool? WO_IsCalStack { get; set; }

    /// <summary>序号（换班后从1开始）</summary>
    [SugarColumn(ColumnName = "IndexNo", IsNullable = true, ColumnDescription = "序号（换班后从1开始）")]
    public int? IndexNo { get; set; }

    /// <summary>WO_ID</summary>
    [SugarColumn(ColumnName = "WO_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WO_ID")]
    public int WO_ID { get; set; }

    /// <summary>材质编号不带点</summary>
    [SugarColumn(ColumnName = "WO_PaperCodeExtra", Length = 50, IsNullable = true, ColumnDescription = "材质编号不带点")]
    public string? WO_PaperCodeExtra { get; set; }

    /// <summary>是否是小剖触发器时间插入更新删除截断trg_monitor_order_changeAFTER</summary>
    [SugarColumn(ColumnName = "WO_IsSmallCN_D", ColumnDescription = "是否是小剖触发器时间插入更新删除截断trg_monitor_order_changeAFTER", DefaultValue = "false")]
    public bool WO_IsSmallCN_D { get; set; }

}