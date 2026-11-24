using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 班组记录表
/// </summary>
[SugarTable("W_ProEventP04Ts", TableDescription = "班组记录表")]
public class W_ProEventP04Ts
{
    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "WP_ShiftNumber", Length = 10, IsNullable = true, ColumnDescription = "班次号")]
    public string? WP_ShiftNumber { get; set; }

    /// <summary>班组号</summary>
    [SugarColumn(ColumnName = "WP_GroupNameShift", Length = 10, IsNullable = true, ColumnDescription = "班组号")]
    public string? WP_GroupNameShift { get; set; }

    /// <summary>开始时间</summary>
    [SugarColumn(ColumnName = "WP_StartTime", IsNullable = true, ColumnDescription = "开始时间")]
    public DateTime? WP_StartTime { get; set; }

    /// <summary>结束时间</summary>
    [SugarColumn(ColumnName = "WP_EndTime", IsNullable = true, ColumnDescription = "结束时间")]
    public DateTime? WP_EndTime { get; set; }

    /// <summary>周期</summary>
    [SugarColumn(ColumnName = "WP_Duration", Length = 20, IsNullable = true, ColumnDescription = "周期")]
    public string? WP_Duration { get; set; }

    /// <summary>总的长米数（m）</summary>
    [SugarColumn(ColumnName = "WP_TotalLinealMeters", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "总的长米数（m）")]
    public decimal? WP_TotalLinealMeters { get; set; }

    /// <summary>总的生产平米（m2）</summary>
    [SugarColumn(ColumnName = "WP_TotalProduced", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "总的生产平米（m2）")]
    public decimal? WP_TotalProduced { get; set; }

    /// <summary>修边平米数（m2）</summary>
    [SugarColumn(ColumnName = "WP_SideTrim", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "修边平米数（m2）")]
    public decimal? WP_SideTrim { get; set; }

    /// <summary>最大车速(m/min)</summary>
    [SugarColumn(ColumnName = "WP_MaxSpeed", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "最大车速(m/min)")]
    public decimal? WP_MaxSpeed { get; set; }

    /// <summary>平均车速(m/min)</summary>
    [SugarColumn(ColumnName = "WP_AvgSpeed", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "平均车速(m/min)")]
    public decimal? WP_AvgSpeed { get; set; }

    /// <summary>是否在做</summary>
    [SugarColumn(ColumnName = "WP_IsEnd", IsNullable = true, ColumnDescription = "是否在做")]
    public bool? WP_IsEnd { get; set; }

    /// <summary>WP_StartSteam</summary>
    [SugarColumn(ColumnName = "WP_StartSteam", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WP_StartSteam")]
    public decimal? WP_StartSteam { get; set; }

    /// <summary>WP_EndSteam</summary>
    [SugarColumn(ColumnName = "WP_EndSteam", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WP_EndSteam")]
    public decimal? WP_EndSteam { get; set; }

    /// <summary>WP_StartELEC</summary>
    [SugarColumn(ColumnName = "WP_StartELEC", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WP_StartELEC")]
    public decimal? WP_StartELEC { get; set; }

    /// <summary>WP_EndELEC</summary>
    [SugarColumn(ColumnName = "WP_EndELEC", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WP_EndELEC")]
    public decimal? WP_EndELEC { get; set; }

    /// <summary>WP_ID</summary>
    [SugarColumn(ColumnName = "WP_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WP_ID")]
    public int WP_ID { get; set; }

    /// <summary>WP_StartGlue</summary>
    [SugarColumn(ColumnName = "WP_StartGlue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "WP_StartGlue")]
    public decimal? WP_StartGlue { get; set; }

    /// <summary>2.1.1.2. 视图2.1.1.2.1. 视图: VW_Plc_PointDataNullF_IdF_TypeF_PositionF_EncodedF_CreatorF_CreateTimeF_EditorF_EditTimeF_CodeF_NameF_DriverCodeV_DriverNameF_VarAddressF_DataTypeF_RWF_IntervalF_CommunicationTypeV_IpAddressV_PortF_SortNoF_ParameterF_Parameter2F_ParameterRWF_PointNameF_PositionTable2.1.1.2.2. 视图: VW_Plc_PointDataBaseNullF_CodeF_NameF_DriverCodeV_DriverNameF_VarAddressF_DataTypeF_RWF_IntervalF_CommunicationTypeV_IpAddressV_Port2.1.1.2.3. 视图: V_FinishOrdersNullIDStartTimeEndTimeLineMetersAvgSpeedTotalNominalMetersTotalProQtyProQtyEdgeAbsoluteProQtyEdgeInPersentOrderStopNumOrderStopTimeActualCuts1AddCut1FinishQtySchQtyActualCuts2AddCut2FinishQtyDSchQtyDOrderIDWorkNoPaperCodeWaveWidthTrimScheduleMeterCustNameOrderNoCustNoCutLengthCutWidthCutQtyCNOrderQtyScorCustNameDOrderNoDCustNoDCutLengthDCutWidthDCutQtyDCNDOrderQtyDScorDRemarkRemarkD2.1.1.2.4. 视图: V_OrdersNullOrderIDWorkNoPaperCodeWaveEstFinshTimeCustNameOrderNoCustNoCutLengthCutWidthCutQtyCNSchQtyOrderQtyScorCustNameDOrderNoDCustNoDCutLengthDCutWidthDCutQtyDCNDSchQtyDOrderQtyDScorDWidthTrimScheduleMeterRemarkRemarkD2.1.1.3. 函数2.1.1.3.1. 函数: P_ClearOrderCacheFunction Type: 函数返回类型: void参数模式数据类型(No Parameters)2.1.1.3.2. 函数: P_GetDetailForReportFunction Type: 函数返回类型: TABLE("OperType" text, "ChangeCodeOSC" varchar, "ID" int4, "OID" int4, "FID" int4, "ShiftNum" varchar, "WorkNo" int参数模式数据类型INstart_timeINend_timeINwave_paramINcust_name_paramINpaper_code_paramINorder_no_paramINtask_no_paramINspecifications_param2.1.1.3.3. 函数: P_GetFinshOrdersNewFunction Type: 函数返回类型: TABLE("WaveType" varchar, "PlanFluteSF1" varchar, "PlanFluteSF2" varchar, "PlanFluteSF3" varchar, "ActFluteSF1" va参数模式数据类型INstart_timeINend_timeINwave_paramINcust_name_paramINpaper_code_paramINorder_no_paramINtask_no_paramINspecifications_paramINwidth_param2.1.1.3.4. 函数: P_UpdateOrderEstFinshTimeFunction Type: 函数返回类型: void参数模式数据类型INspeed_min2.1.1.3.5. 函数: fn_insert_erp_paperFunction Type: 函数返回类型: trigger参数模式数据类型(No Parameters)2.1.1.3.6. 函数: fn_monitor_order_changeFunction Type: 函数返回类型: trigger参数模式数据类型(No Parameters)</summary>
    [SugarColumn(ColumnName = "WP_EndGlue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "2.1.1.2. 视图2.1.1.2.1. 视图: VW_Plc_PointDataNullF_IdF_TypeF_PositionF_EncodedF_CreatorF_CreateTimeF_EditorF_EditTimeF_CodeF_NameF_DriverCodeV_DriverNameF_VarAddressF_DataTypeF_RWF_IntervalF_CommunicationTypeV_IpAddressV_PortF_SortNoF_ParameterF_Parameter2F_ParameterRWF_PointNameF_PositionTable2.1.1.2.2. 视图: VW_Plc_PointDataBaseNullF_CodeF_NameF_DriverCodeV_DriverNameF_VarAddressF_DataTypeF_RWF_IntervalF_CommunicationTypeV_IpAddressV_Port2.1.1.2.3. 视图: V_FinishOrdersNullIDStartTimeEndTimeLineMetersAvgSpeedTotalNominalMetersTotalProQtyProQtyEdgeAbsoluteProQtyEdgeInPersentOrderStopNumOrderStopTimeActualCuts1AddCut1FinishQtySchQtyActualCuts2AddCut2FinishQtyDSchQtyDOrderIDWorkNoPaperCodeWaveWidthTrimScheduleMeterCustNameOrderNoCustNoCutLengthCutWidthCutQtyCNOrderQtyScorCustNameDOrderNoDCustNoDCutLengthDCutWidthDCutQtyDCNDOrderQtyDScorDRemarkRemarkD2.1.1.2.4. 视图: V_OrdersNullOrderIDWorkNoPaperCodeWaveEstFinshTimeCustNameOrderNoCustNoCutLengthCutWidthCutQtyCNSchQtyOrderQtyScorCustNameDOrderNoDCustNoDCutLengthDCutWidthDCutQtyDCNDSchQtyDOrderQtyDScorDWidthTrimScheduleMeterRemarkRemarkD2.1.1.3. 函数2.1.1.3.1. 函数: P_ClearOrderCacheFunction Type: 函数返回类型: void参数模式数据类型(No Parameters)2.1.1.3.2. 函数: P_GetDetailForReportFunction Type: 函数返回类型: TABLE(\"OperType\" text, \"ChangeCodeOSC\" varchar, \"ID\" int4, \"OID\" int4, \"FID\" int4, \"ShiftNum\" varchar, \"WorkNo\" int参数模式数据类型INstart_timeINend_timeINwave_paramINcust_name_paramINpaper_code_paramINorder_no_paramINtask_no_paramINspecifications_param2.1.1.3.3. 函数: P_GetFinshOrdersNewFunction Type: 函数返回类型: TABLE(\"WaveType\" varchar, \"PlanFluteSF1\" varchar, \"PlanFluteSF2\" varchar, \"PlanFluteSF3\" varchar, \"ActFluteSF1\" va参数模式数据类型INstart_timeINend_timeINwave_paramINcust_name_paramINpaper_code_paramINorder_no_paramINtask_no_paramINspecifications_paramINwidth_param2.1.1.3.4. 函数: P_UpdateOrderEstFinshTimeFunction Type: 函数返回类型: void参数模式数据类型INspeed_min2.1.1.3.5. 函数: fn_insert_erp_paperFunction Type: 函数返回类型: trigger参数模式数据类型(No Parameters)2.1.1.3.6. 函数: fn_monitor_order_changeFunction Type: 函数返回类型: trigger参数模式数据类型(No Parameters)")]
    public decimal? WP_EndGlue { get; set; }

}