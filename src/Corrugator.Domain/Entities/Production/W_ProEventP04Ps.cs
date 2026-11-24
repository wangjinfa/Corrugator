using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 完工数据表
/// </summary>
[SugarTable("W_ProEventP04Ps", TableDescription = "完工数据表")]
public class W_ProEventP04Ps
{
    /// <summary>P04T主键</summary>
    [SugarColumn(ColumnName = "WP_P04TID", IsPrimaryKey = true, IsIdentity = true, IsNullable = true, ColumnDescription = "P04T主键")]
    public int? WP_P04TID { get; set; }

    /// <summary>订单ID索引:IX_W_ProEventP04Ps_Order...</summary>
    [SugarColumn(ColumnName = "WP_SetupID", ColumnDescription = "订单ID索引:IX_W_ProEventP04Ps_Order...")]
    public int WP_SetupID { get; set; }

    /// <summary>开始时间索引: IX_P04P_StartTime</summary>
    [SugarColumn(ColumnName = "WP_StartTime", IsNullable = true, ColumnDescription = "开始时间索引: IX_P04P_StartTime")]
    public DateTime? WP_StartTime { get; set; }

    /// <summary>结束时间索引: IX_P04P_EndTime</summary>
    [SugarColumn(ColumnName = "WP_EndTime", IsNullable = true, ColumnDescription = "结束时间索引: IX_P04P_EndTime")]
    public DateTime? WP_EndTime { get; set; }

    /// <summary>长米数(m)</summary>
    [SugarColumn(ColumnName = "WP_LineMeters", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "长米数(m)")]
    public decimal? WP_LineMeters { get; set; }

    /// <summary>平均车速(m/min)</summary>
    [SugarColumn(ColumnName = "WP_AvgSpeed", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "平均车速(m/min)")]
    public decimal? WP_AvgSpeed { get; set; }

    /// <summary>总额定米数(m)</summary>
    [SugarColumn(ColumnName = "WP_TotalNominalMeters", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "总额定米数(m)")]
    public decimal? WP_TotalNominalMeters { get; set; }

    /// <summary>总的生产平米数(m2)</summary>
    [SugarColumn(ColumnName = "WP_TotalProQty", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "总的生产平米数(m2)")]
    public decimal? WP_TotalProQty { get; set; }

    /// <summary>生产的修边平米数-绝对值(m2)</summary>
    [SugarColumn(ColumnName = "WP_ProQtyEdgeAbsolute", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "生产的修边平米数-绝对值(m2)")]
    public decimal? WP_ProQtyEdgeAbsolute { get; set; }

    /// <summary>生产的修边平米数-百分比 %</summary>
    [SugarColumn(ColumnName = "WP_ProQtyEdgeInPersent", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "生产的修边平米数-百分比 %")]
    public decimal? WP_ProQtyEdgeInPersent { get; set; }

    /// <summary>更改代码 O S C</summary>
    [SugarColumn(ColumnName = "WP_ChangeCodeOSC", Length = 10, IsNullable = true, ColumnDescription = "更改代码 O S C")]
    public string? WP_ChangeCodeOSC { get; set; }

    /// <summary>该订单停机时间</summary>
    [SugarColumn(ColumnName = "WP_OrderStopTime", IsNullable = true, ColumnDescription = "该订单停机时间")]
    public int? WP_OrderStopTime { get; set; }

    /// <summary>该订单停机次数</summary>
    [SugarColumn(ColumnName = "WP_OrderStopNum", IsNullable = true, ColumnDescription = "该订单停机次数")]
    public int? WP_OrderStopNum { get; set; }

    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "WP_ShiftNum", Length = 10, IsNullable = true, ColumnDescription = "班次号")]
    public string? WP_ShiftNum { get; set; }

    /// <summary>废品数 KQM</summary>
    [SugarColumn(ColumnName = "WP_KQMQty", IsNullable = true, ColumnDescription = "废品数 KQM")]
    public int? WP_KQMQty { get; set; }

    /// <summary>废品数 KQF</summary>
    [SugarColumn(ColumnName = "WP_KQFQty", IsNullable = true, ColumnDescription = "废品数 KQF")]
    public int? WP_KQFQty { get; set; }

    /// <summary>客户1 实际切数</summary>
    [SugarColumn(ColumnName = "WP_ActualCuts1", IsNullable = true, ColumnDescription = "客户1 实际切数")]
    public int? WP_ActualCuts1 { get; set; }

    /// <summary>客户1 额定切数</summary>
    [SugarColumn(ColumnName = "WP_NominalCuts1", IsNullable = true, ColumnDescription = "客户1 额定切数")]
    public int? WP_NominalCuts1 { get; set; }

    /// <summary>客户1订单刀数(同订单多班组适用)</summary>
    [SugarColumn(ColumnName = "WP_OrderCut1", IsNullable = true, ColumnDescription = "客户1订单刀数(同订单多班组适用)")]
    public int? WP_OrderCut1 { get; set; }

    /// <summary>客户1加刀数</summary>
    [SugarColumn(ColumnName = "WP_AddCut1", IsNullable = true, ColumnDescription = "客户1加刀数")]
    public int? WP_AddCut1 { get; set; }

    /// <summary>客户2 实际切数</summary>
    [SugarColumn(ColumnName = "WP_ActualCuts2", IsNullable = true, ColumnDescription = "客户2 实际切数")]
    public int? WP_ActualCuts2 { get; set; }

    /// <summary>客户2 额定切数</summary>
    [SugarColumn(ColumnName = "WP_NominalCuts2", IsNullable = true, ColumnDescription = "客户2 额定切数")]
    public int? WP_NominalCuts2 { get; set; }

    /// <summary>客户2订单刀数(同订单多班组适用)</summary>
    [SugarColumn(ColumnName = "WP_OrderCut2", IsNullable = true, ColumnDescription = "客户2订单刀数(同订单多班组适用)")]
    public int? WP_OrderCut2 { get; set; }

    /// <summary>客户2加刀数</summary>
    [SugarColumn(ColumnName = "WP_AddCut2", IsNullable = true, ColumnDescription = "客户2加刀数")]
    public int? WP_AddCut2 { get; set; }

    /// <summary>客户3 实际切数</summary>
    [SugarColumn(ColumnName = "WP_ActualCuts3", IsNullable = true, ColumnDescription = "客户3 实际切数")]
    public int? WP_ActualCuts3 { get; set; }

    /// <summary>客户3 额定切数</summary>
    [SugarColumn(ColumnName = "WP_NominalCuts3", IsNullable = true, ColumnDescription = "客户3 额定切数")]
    public int? WP_NominalCuts3 { get; set; }

    /// <summary>客户3订单刀数(同订单多班组适用)</summary>
    [SugarColumn(ColumnName = "WP_OrderCut3", IsNullable = true, ColumnDescription = "客户3订单刀数(同订单多班组适用)")]
    public int? WP_OrderCut3 { get; set; }

    /// <summary>客户3加刀数</summary>
    [SugarColumn(ColumnName = "WP_AddCut3", IsNullable = true, ColumnDescription = "客户3加刀数")]
    public int? WP_AddCut3 { get; set; }

    /// <summary>ERP是否已回收</summary>
    [SugarColumn(ColumnName = "WP_IsRec", IsNullable = true, ColumnDescription = "ERP是否已回收")]
    public bool? WP_IsRec { get; set; }

    /// <summary>GUID</summary>
    [SugarColumn(ColumnName = "WP_GUID", Length = 50, IsNullable = true, ColumnDescription = "GUID")]
    public string? WP_GUID { get; set; }

    /// <summary>索引方法IX_P04P_EndTimebtreeWP_EndTimeIX_P04P_StartTimebtreeWP_StartTimeIX_W_ProEventP04Ps_OrderIDbtreeWP_SetupID</summary>
    [SugarColumn(ColumnName = "WP_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "索引方法IX_P04P_EndTimebtreeWP_EndTimeIX_P04P_StartTimebtreeWP_StartTimeIX_W_ProEventP04Ps_OrderIDbtreeWP_SetupID")]
    public int WP_ID { get; set; }

}