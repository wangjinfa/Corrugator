using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 完工表
/// </summary>
[SugarTable("W_OrderFinishs", TableDescription = "完工表")]
public class W_OrderFinishs
{
    /// <summary>未完表ID索引:IX_W_OrderFinishs_OrderID...</summary>
    [SugarColumn(ColumnName = "WO_ID", ColumnDescription = "未完表ID索引:IX_W_OrderFinishs_OrderID...")]
    public int WO_ID { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "WOF_WorkNo", ColumnDescription = "工号")]
    public int WOF_WorkNo { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "WOF_ClassNo", Length = 50, IsNullable = true, ColumnDescription = "班组")]
    public string? WOF_ClassNo { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WOF_PaperCode", Length = 50, ColumnDescription = "材质")]
    public string WOF_PaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WOF_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WOF_Wave { get; set; } = default!;

    /// <summary>层数</summary>
    [SugarColumn(ColumnName = "WOF_Floor", ColumnDescription = "层数")]
    public int WOF_Floor { get; set; }

    /// <summary>修边mm</summary>
    [SugarColumn(ColumnName = "WOF_Trim", ColumnDescription = "修边mm")]
    public int WOF_Trim { get; set; }

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WOF_Width", ColumnDescription = "门幅")]
    public int WOF_Width { get; set; }

    /// <summary>门幅英寸</summary>
    [SugarColumn(ColumnName = "WOF_WidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "门幅英寸")]
    public decimal? WOF_WidthInch { get; set; }

    /// <summary>材质克重</summary>
    [SugarColumn(ColumnName = "WOF_Weight", IsNullable = true, ColumnDescription = "材质克重")]
    public int? WOF_Weight { get; set; }

    /// <summary>材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Deep", Length = 18, DecimalDigits = 4, ColumnDescription = "材质厚度mm")]
    public decimal WOF_Deep { get; set; }

    /// <summary>第一层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor1", Length = 10, IsNullable = true, ColumnDescription = "第一层材质")]
    public string? WOF_Floor1 { get; set; }

    /// <summary>第一层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor1Deep", IsNullable = true, ColumnDescription = "第一层材质厚度mm")]
    public int? WOF_Floor1Deep { get; set; }

    /// <summary>第二层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor2", Length = 10, IsNullable = true, ColumnDescription = "第二层材质")]
    public string? WOF_Floor2 { get; set; }

    /// <summary>第二层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor2Deep", IsNullable = true, ColumnDescription = "第二层材质厚度mm")]
    public int? WOF_Floor2Deep { get; set; }

    /// <summary>第三层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor3", Length = 10, IsNullable = true, ColumnDescription = "第三层材质")]
    public string? WOF_Floor3 { get; set; }

    /// <summary>第三层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor3Deep", IsNullable = true, ColumnDescription = "第三层材质厚度mm")]
    public int? WOF_Floor3Deep { get; set; }

    /// <summary>第四层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor4", Length = 10, IsNullable = true, ColumnDescription = "第四层材质")]
    public string? WOF_Floor4 { get; set; }

    /// <summary>第四层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor4Deep", IsNullable = true, ColumnDescription = "第四层材质厚度mm")]
    public int? WOF_Floor4Deep { get; set; }

    /// <summary>第五层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor5", Length = 10, IsNullable = true, ColumnDescription = "第五层材质")]
    public string? WOF_Floor5 { get; set; }

    /// <summary>第五层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor5Deep", IsNullable = true, ColumnDescription = "第五层材质厚度mm")]
    public int? WOF_Floor5Deep { get; set; }

    /// <summary>第六层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor6", Length = 10, IsNullable = true, ColumnDescription = "第六层材质")]
    public string? WOF_Floor6 { get; set; }

    /// <summary>第六层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor6Deep", IsNullable = true, ColumnDescription = "第六层材质厚度mm")]
    public int? WOF_Floor6Deep { get; set; }

    /// <summary>第七层材质</summary>
    [SugarColumn(ColumnName = "WOF_Floor7", Length = 10, IsNullable = true, ColumnDescription = "第七层材质")]
    public string? WOF_Floor7 { get; set; }

    /// <summary>第七层材质厚度mm</summary>
    [SugarColumn(ColumnName = "WOF_Floor7Deep", IsNullable = true, ColumnDescription = "第七层材质厚度mm")]
    public int? WOF_Floor7Deep { get; set; }

    /// <summary>是否传单</summary>
    [SugarColumn(ColumnName = "WOF_Send", Length = 10, IsNullable = true, ColumnDescription = "是否传单")]
    public string? WOF_Send { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "WOF_Speed", ColumnDescription = "限速")]
    public int WOF_Speed { get; set; }

    /// <summary>WOF_ScheduleMeter</summary>
    [SugarColumn(ColumnName = "WOF_ScheduleMeter", Length = 18, DecimalDigits = 4, ColumnDescription = "WOF_ScheduleMeter")]
    public decimal WOF_ScheduleMeter { get; set; }

    /// <summary>是否停换</summary>
    [SugarColumn(ColumnName = "WOF_Stop", ColumnDescription = "是否停换")]
    public bool WOF_Stop { get; set; }

    /// <summary>是否上刀走下刀</summary>
    [SugarColumn(ColumnName = "WOF_UGoD", ColumnDescription = "是否上刀走下刀")]
    public bool WOF_UGoD { get; set; }

    /// <summary>开始生产时间</summary>
    [SugarColumn(ColumnName = "WOF_StartTime", IsNullable = true, ColumnDescription = "开始生产时间")]
    public DateTime? WOF_StartTime { get; set; }

    /// <summary>完工时间</summary>
    [SugarColumn(ColumnName = "WOF_FinishTime", IsNullable = true, ColumnDescription = "完工时间")]
    public DateTime? WOF_FinishTime { get; set; }

    /// <summary>预计完工时间</summary>
    [SugarColumn(ColumnName = "WOF_EstFinshTime", IsNullable = true, ColumnDescription = "预计完工时间")]
    public DateTime? WOF_EstFinshTime { get; set; }

    /// <summary>加减刀数</summary>
    [SugarColumn(ColumnName = "WOF_ModCutQty", IsNullable = true, ColumnDescription = "加减刀数")]
    public int? WOF_ModCutQty { get; set; }

    /// <summary>平均车速</summary>
    [SugarColumn(ColumnName = "WOF_AvgSpeed", IsNullable = true, ColumnDescription = "平均车速")]
    public int? WOF_AvgSpeed { get; set; }

    /// <summary>停机次数</summary>
    [SugarColumn(ColumnName = "WOF_StopNum", IsNullable = true, ColumnDescription = "停机次数")]
    public int? WOF_StopNum { get; set; }

    /// <summary>停机时间Sec</summary>
    [SugarColumn(ColumnName = "WOF_StopTime", IsNullable = true, ColumnDescription = "停机时间Sec")]
    public int? WOF_StopTime { get; set; }

    /// <summary>上刀订单号</summary>
    [SugarColumn(ColumnName = "WOF_OrderNo", Length = 50, IsNullable = true, ColumnDescription = "上刀订单号")]
    public string? WOF_OrderNo { get; set; }

    /// <summary>上刀客户号</summary>
    [SugarColumn(ColumnName = "WOF_CustNo", Length = 50, IsNullable = true, ColumnDescription = "上刀客户号")]
    public string? WOF_CustNo { get; set; }

    /// <summary>上刀任务号</summary>
    [SugarColumn(ColumnName = "WOF_TaskNo", Length = 50, IsNullable = true, ColumnDescription = "上刀任务号")]
    public string? WOF_TaskNo { get; set; }

    /// <summary>上刀客户名称</summary>
    [SugarColumn(ColumnName = "WOF_CustName", Length = 100, IsNullable = true, ColumnDescription = "上刀客户名称")]
    public string? WOF_CustName { get; set; }

    /// <summary>上刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WOF_CustPaperCode", Length = 50, IsNullable = true, ColumnDescription = "上刀标签材质代号")]
    public string? WOF_CustPaperCode { get; set; }

    /// <summary>上刀切宽mm</summary>
    [SugarColumn(ColumnName = "WOF_CutWidth", ColumnDescription = "上刀切宽mm")]
    public int WOF_CutWidth { get; set; }

    /// <summary>上刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WOF_CutWidthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切宽英寸")]
    public decimal? WOF_CutWidthInch { get; set; }

    /// <summary>上刀切长mm</summary>
    [SugarColumn(ColumnName = "WOF_CutLength", ColumnDescription = "上刀切长mm")]
    public int WOF_CutLength { get; set; }

    /// <summary>上刀切长英寸</summary>
    [SugarColumn(ColumnName = "WOF_CutLengthInch", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀切长英寸")]
    public decimal? WOF_CutLengthInch { get; set; }

    /// <summary>上刀切数</summary>
    [SugarColumn(ColumnName = "WOF_CutQty", ColumnDescription = "上刀切数")]
    public int WOF_CutQty { get; set; }

    /// <summary>上刀订单米数</summary>
    [SugarColumn(ColumnName = "WOF_OrderMeter", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "上刀订单米数")]
    public decimal? WOF_OrderMeter { get; set; }

    /// <summary>上刀订单数</summary>
    [SugarColumn(ColumnName = "WOF_OrderQty", IsNullable = true, ColumnDescription = "上刀订单数")]
    public int? WOF_OrderQty { get; set; }

    /// <summary>上刀订单未排数</summary>
    [SugarColumn(ColumnName = "WOF_OrderNoQty", IsNullable = true, ColumnDescription = "上刀订单未排数")]
    public int? WOF_OrderNoQty { get; set; }

    /// <summary>上刀标签打印数</summary>
    [SugarColumn(ColumnName = "WOF_LabelQty", IsNullable = true, ColumnDescription = "上刀标签打印数")]
    public int? WOF_LabelQty { get; set; }

    /// <summary>上刀剖数</summary>
    [SugarColumn(ColumnName = "WOF_CN", ColumnDescription = "上刀剖数")]
    public int WOF_CN { get; set; }

    /// <summary>上刀压线类型</summary>
    [SugarColumn(ColumnName = "WOF_ScorType", Length = 10, ColumnDescription = "上刀压线类型")]
    public string WOF_ScorType { get; set; } = default!;

    /// <summary>上刀压线信息</summary>
    [SugarColumn(ColumnName = "WOF_Scor", Length = 100, IsNullable = true, ColumnDescription = "上刀压线信息")]
    public string? WOF_Scor { get; set; }

    /// <summary>上刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WOF_ScorDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "上刀压线深度mm")]
    public decimal WOF_ScorDeep { get; set; }

    /// <summary>上刀生产备注</summary>
    [SugarColumn(ColumnName = "WOF_Remark", Length = 500, IsNullable = true, ColumnDescription = "上刀生产备注")]
    public string? WOF_Remark { get; set; }

    /// <summary>上刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WOF_Stack", ColumnDescription = "上刀堆叠模式")]
    public bool WOF_Stack { get; set; }

    /// <summary>上刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WOF_StackQty", ColumnDescription = "上刀堆叠数量")]
    public int WOF_StackQty { get; set; }

    /// <summary>上刀每捆数量</summary>
    [SugarColumn(ColumnName = "WOF_BunQty", IsNullable = true, ColumnDescription = "上刀每捆数量")]
    public int? WOF_BunQty { get; set; }

    /// <summary>上刀错位</summary>
    [SugarColumn(ColumnName = "WOF_Bundle", ColumnDescription = "上刀错位")]
    public bool WOF_Bundle { get; set; }

    /// <summary>上刀错位张数</summary>
    [SugarColumn(ColumnName = "WOF_BundleQty", ColumnDescription = "上刀错位张数")]
    public int WOF_BundleQty { get; set; }

    /// <summary>上刀错位数</summary>
    [SugarColumn(ColumnName = "WOF_BundleNum", ColumnDescription = "上刀错位数")]
    public int WOF_BundleNum { get; set; }

    /// <summary>上刀订单日期</summary>
    [SugarColumn(ColumnName = "WOF_OrderDate", IsNullable = true, ColumnDescription = "上刀订单日期")]
    public DateTime? WOF_OrderDate { get; set; }

    /// <summary>上刀送货日期</summary>
    [SugarColumn(ColumnName = "WOF_DeliDate", IsNullable = true, ColumnDescription = "上刀送货日期")]
    public DateTime? WOF_DeliDate { get; set; }

    /// <summary>上刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WOF_StockMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀存货区域信息")]
    public string? WOF_StockMemo { get; set; }

    /// <summary>上刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WOF_BoxMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀纸箱信息")]
    public string? WOF_BoxMemo { get; set; }

    /// <summary>上刀理货信息</summary>
    [SugarColumn(ColumnName = "WOF_DeliMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀理货信息")]
    public string? WOF_DeliMemo { get; set; }

    /// <summary>上刀排单信息</summary>
    [SugarColumn(ColumnName = "WOF_PlanMemo", IsNullable = true, ColumnDescription = "上刀排单信息")]
    public string? WOF_PlanMemo { get; set; }

    /// <summary>上刀分纸信息</summary>
    [SugarColumn(ColumnName = "WOF_CutPaperMemo", Length = 200, IsNullable = true, ColumnDescription = "上刀分纸信息")]
    public string? WOF_CutPaperMemo { get; set; }

    /// <summary>上刀备用</summary>
    [SugarColumn(ColumnName = "WOF_Memo", IsNullable = true, ColumnDescription = "上刀备用")]
    public string? WOF_Memo { get; set; }

    /// <summary>上刀完工刀数</summary>
    [SugarColumn(ColumnName = "WOF_FinishCutQty", IsNullable = true, ColumnDescription = "上刀完工刀数")]
    public int? WOF_FinishCutQty { get; set; }

    /// <summary>上刀堆码完工刀数</summary>
    [SugarColumn(ColumnName = "WOF_FinishStackCutQty", IsNullable = true, ColumnDescription = "上刀堆码完工刀数")]
    public int? WOF_FinishStackCutQty { get; set; }

    /// <summary>上刀标签打印张数</summary>
    [SugarColumn(ColumnName = "WOF_LabelPrintNum", IsNullable = true, ColumnDescription = "上刀标签打印张数")]
    public int? WOF_LabelPrintNum { get; set; }

    /// <summary>下刀订单号</summary>
    [SugarColumn(ColumnName = "WOF_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀订单号")]
    public string? WOF_OrderNo_D { get; set; }

    /// <summary>下刀客户号</summary>
    [SugarColumn(ColumnName = "WOF_CustNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀客户号")]
    public string? WOF_CustNo_D { get; set; }

    /// <summary>下刀任务号</summary>
    [SugarColumn(ColumnName = "WOF_TaskNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀任务号")]
    public string? WOF_TaskNo_D { get; set; }

    /// <summary>下刀客户名称</summary>
    [SugarColumn(ColumnName = "WOF_CustName_D", Length = 100, IsNullable = true, ColumnDescription = "下刀客户名称")]
    public string? WOF_CustName_D { get; set; }

    /// <summary>下刀标签材质代号</summary>
    [SugarColumn(ColumnName = "WOF_CustPaperCode_D", Length = 50, IsNullable = true, ColumnDescription = "下刀标签材质代号")]
    public string? WOF_CustPaperCode_D { get; set; }

    /// <summary>下刀切宽mm</summary>
    [SugarColumn(ColumnName = "WOF_CutWidth_D", ColumnDescription = "下刀切宽mm")]
    public int WOF_CutWidth_D { get; set; }

    /// <summary>下刀切宽英寸</summary>
    [SugarColumn(ColumnName = "WOF_CutWidthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切宽英寸")]
    public decimal? WOF_CutWidthInch_D { get; set; }

    /// <summary>下刀切长mm</summary>
    [SugarColumn(ColumnName = "WOF_CutLength_D", ColumnDescription = "下刀切长mm")]
    public int WOF_CutLength_D { get; set; }

    /// <summary>下刀切长英寸</summary>
    [SugarColumn(ColumnName = "WOF_CutLengthInch_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀切长英寸")]
    public decimal? WOF_CutLengthInch_D { get; set; }

    /// <summary>下刀切数</summary>
    [SugarColumn(ColumnName = "WOF_CutQty_D", ColumnDescription = "下刀切数")]
    public int WOF_CutQty_D { get; set; }

    /// <summary>下刀订单米数</summary>
    [SugarColumn(ColumnName = "WOF_OrderMeter_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀订单米数")]
    public decimal? WOF_OrderMeter_D { get; set; }

    /// <summary>下刀订单数</summary>
    [SugarColumn(ColumnName = "WOF_OrderQty_D", IsNullable = true, ColumnDescription = "下刀订单数")]
    public int? WOF_OrderQty_D { get; set; }

    /// <summary>下刀订单未排数</summary>
    [SugarColumn(ColumnName = "WOF_OrderNoQty_D", IsNullable = true, ColumnDescription = "下刀订单未排数")]
    public int? WOF_OrderNoQty_D { get; set; }

    /// <summary>下刀标签数</summary>
    [SugarColumn(ColumnName = "WOF_LabelQty_D", IsNullable = true, ColumnDescription = "下刀标签数")]
    public int? WOF_LabelQty_D { get; set; }

    /// <summary>下刀剖数</summary>
    [SugarColumn(ColumnName = "WOF_CN_D", ColumnDescription = "下刀剖数")]
    public int WOF_CN_D { get; set; }

    /// <summary>下刀压线类型</summary>
    [SugarColumn(ColumnName = "WOF_ScorType_D", Length = 10, IsNullable = true, ColumnDescription = "下刀压线类型")]
    public string? WOF_ScorType_D { get; set; }

    /// <summary>下刀压线信息</summary>
    [SugarColumn(ColumnName = "WOF_Scor_D", Length = 100, IsNullable = true, ColumnDescription = "下刀压线信息")]
    public string? WOF_Scor_D { get; set; }

    /// <summary>下刀压线深度mm</summary>
    [SugarColumn(ColumnName = "WOF_ScorDeep_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀压线深度mm")]
    public decimal? WOF_ScorDeep_D { get; set; }

    /// <summary>下刀生产备注</summary>
    [SugarColumn(ColumnName = "WOF_Remark_D", Length = 500, IsNullable = true, ColumnDescription = "下刀生产备注")]
    public string? WOF_Remark_D { get; set; }

    /// <summary>下刀堆叠模式</summary>
    [SugarColumn(ColumnName = "WOF_Stack_D", IsNullable = true, ColumnDescription = "下刀堆叠模式")]
    public bool? WOF_Stack_D { get; set; }

    /// <summary>下刀堆叠数量</summary>
    [SugarColumn(ColumnName = "WOF_StackQty_D", IsNullable = true, ColumnDescription = "下刀堆叠数量")]
    public int? WOF_StackQty_D { get; set; }

    /// <summary>下刀每捆数量</summary>
    [SugarColumn(ColumnName = "WOF_BunQty_D", IsNullable = true, ColumnDescription = "下刀每捆数量")]
    public int? WOF_BunQty_D { get; set; }

    /// <summary>下刀错位</summary>
    [SugarColumn(ColumnName = "WOF_Bundle_D", IsNullable = true, ColumnDescription = "下刀错位")]
    public bool? WOF_Bundle_D { get; set; }

    /// <summary>下刀错位张数</summary>
    [SugarColumn(ColumnName = "WOF_BundleQty_D", IsNullable = true, ColumnDescription = "下刀错位张数")]
    public int? WOF_BundleQty_D { get; set; }

    /// <summary>下刀错位数</summary>
    [SugarColumn(ColumnName = "WOF_BundleNum_D", IsNullable = true, ColumnDescription = "下刀错位数")]
    public int? WOF_BundleNum_D { get; set; }

    /// <summary>下刀订单日期</summary>
    [SugarColumn(ColumnName = "WOF_OrderDate_D", IsNullable = true, ColumnDescription = "下刀订单日期")]
    public DateTime? WOF_OrderDate_D { get; set; }

    /// <summary>下刀送货日期</summary>
    [SugarColumn(ColumnName = "WOF_DeliDate_D", IsNullable = true, ColumnDescription = "下刀送货日期")]
    public DateTime? WOF_DeliDate_D { get; set; }

    /// <summary>下刀存货区域信息</summary>
    [SugarColumn(ColumnName = "WOF_StockMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀存货区域信息")]
    public string? WOF_StockMemo_D { get; set; }

    /// <summary>下刀纸箱信息</summary>
    [SugarColumn(ColumnName = "WOF_BoxMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀纸箱信息")]
    public string? WOF_BoxMemo_D { get; set; }

    /// <summary>下刀理货信息</summary>
    [SugarColumn(ColumnName = "WOF_DeliMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀理货信息")]
    public string? WOF_DeliMemo_D { get; set; }

    /// <summary>下刀排程信息</summary>
    [SugarColumn(ColumnName = "WOF_PlanMemo_D", IsNullable = true, ColumnDescription = "下刀排程信息")]
    public string? WOF_PlanMemo_D { get; set; }

    /// <summary>下刀分纸信息</summary>
    [SugarColumn(ColumnName = "WOF_CutPaperMemo_D", Length = 200, IsNullable = true, ColumnDescription = "下刀分纸信息")]
    public string? WOF_CutPaperMemo_D { get; set; }

    /// <summary>下刀备用</summary>
    [SugarColumn(ColumnName = "WOF_Memo_D", IsNullable = true, ColumnDescription = "下刀备用")]
    public string? WOF_Memo_D { get; set; }

    /// <summary>下刀完工刀数</summary>
    [SugarColumn(ColumnName = "WOF_FinishCutQty_D", IsNullable = true, ColumnDescription = "下刀完工刀数")]
    public int? WOF_FinishCutQty_D { get; set; }

    /// <summary>下刀堆码完工刀数</summary>
    [SugarColumn(ColumnName = "WOF_FinishStackCutQty_D", IsNullable = true, ColumnDescription = "下刀堆码完工刀数")]
    public int? WOF_FinishStackCutQty_D { get; set; }

    /// <summary>下刀标签打印张数</summary>
    [SugarColumn(ColumnName = "WOF_LabelPrintNum_D", IsNullable = true, ColumnDescription = "下刀标签打印张数")]
    public int? WOF_LabelPrintNum_D { get; set; }

    /// <summary>ERP订单接口表Guid索引:IX_W_OrderFinishs_GUID</summary>
    [SugarColumn(ColumnName = "WEO_Guid", Length = 50, IsNullable = true, ColumnDescription = "ERP订单接口表Guid索引:IX_W_OrderFinishs_GUID")]
    public string? WEO_Guid { get; set; }

    /// <summary>WOF_IsUrgent</summary>
    [SugarColumn(ColumnName = "WOF_IsUrgent", ColumnDescription = "WOF_IsUrgent")]
    public bool WOF_IsUrgent { get; set; }

    /// <summary>WOF_OperType</summary>
    [SugarColumn(ColumnName = "WOF_OperType", ColumnDescription = "WOF_OperType")]
    public int WOF_OperType { get; set; }

    /// <summary>WOF_TrimCode</summary>
    [SugarColumn(ColumnName = "WOF_TrimCode", ColumnDescription = "WOF_TrimCode")]
    public int WOF_TrimCode { get; set; }

    /// <summary>WOF_ERPCutQty</summary>
    [SugarColumn(ColumnName = "WOF_ERPCutQty", ColumnDescription = "WOF_ERPCutQty")]
    public int WOF_ERPCutQty { get; set; }

    /// <summary>WOF_ERPCutQty_D</summary>
    [SugarColumn(ColumnName = "WOF_ERPCutQty_D", IsNullable = true, ColumnDescription = "WOF_ERPCutQty_D")]
    public int? WOF_ERPCutQty_D { get; set; }

    /// <summary>WOF_IsDouble</summary>
    [SugarColumn(ColumnName = "WOF_IsDouble", IsNullable = true, ColumnDescription = "WOF_IsDouble")]
    public bool? WOF_IsDouble { get; set; }

    /// <summary>WOF_IsOppositeStack</summary>
    [SugarColumn(ColumnName = "WOF_IsOppositeStack", ColumnDescription = "WOF_IsOppositeStack")]
    public bool WOF_IsOppositeStack { get; set; }

    /// <summary>WOF_IsOppositeStack_D</summary>
    [SugarColumn(ColumnName = "WOF_IsOppositeStack_D", ColumnDescription = "WOF_IsOppositeStack_D")]
    public bool WOF_IsOppositeStack_D { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF2PlanUseFluteSF2", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WOF_SF2PlanUseFluteSF2 { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF3PlanUseFluteSF3", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WOF_SF3PlanUseFluteSF3 { get; set; }

    /// <summary>实际使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF1ActUseFluteSF1", Length = 50, IsNullable = true, ColumnDescription = "实际使用楞型")]
    public string? WOF_SF1ActUseFluteSF1 { get; set; }

    /// <summary>实际使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF2ActUseFluteSF2", Length = 50, IsNullable = true, ColumnDescription = "实际使用楞型")]
    public string? WOF_SF2ActUseFluteSF2 { get; set; }

    /// <summary>实际使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF3ActUseFluteSF3", Length = 50, IsNullable = true, ColumnDescription = "实际使用楞型")]
    public string? WOF_SF3ActUseFluteSF3 { get; set; }

    /// <summary>计划使用楞型</summary>
    [SugarColumn(ColumnName = "WOF_SF1PlanUseFluteSF1", Length = 50, IsNullable = true, ColumnDescription = "计划使用楞型")]
    public string? WOF_SF1PlanUseFluteSF1 { get; set; }

    /// <summary>WOF_WavaType</summary>
    [SugarColumn(ColumnName = "WOF_WavaType", Length = 50, IsNullable = true, ColumnDescription = "WOF_WavaType")]
    public string? WOF_WavaType { get; set; }

    /// <summary>WOF_ID</summary>
    [SugarColumn(ColumnName = "WOF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WOF_ID")]
    public int WOF_ID { get; set; }

    /// <summary>材质编号不带点</summary>
    [SugarColumn(ColumnName = "WOF_PaperCodeExtra", Length = 50, IsNullable = true, ColumnDescription = "材质编号不带点")]
    public string? WOF_PaperCodeExtra { get; set; }

    /// <summary>是否是小剖索引方法IX_W_OrderFinishs_GUIDbtreeWEO_GuidIX_W_OrderFinishs_OrderIDbtreeWO_ID</summary>
    [SugarColumn(ColumnName = "WOF_IsSmallCN_D", ColumnDescription = "是否是小剖索引方法IX_W_OrderFinishs_GUIDbtreeWEO_GuidIX_W_OrderFinishs_OrderIDbtreeWO_ID", DefaultValue = "false")]
    public bool WOF_IsSmallCN_D { get; set; }

}