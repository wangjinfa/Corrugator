using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// TB_PMS_Report_Class
/// </summary>
[SugarTable("TB_PMS_Report_Class", TableDescription = "TB_PMS_Report_Class")]
public class TB_PMS_Report_Class
{
    /// <summary>P04TID</summary>
    [SugarColumn(ColumnName = "P04T_ID", IsNullable = true, ColumnDescription = "P04TID")]
    public int? P04T_ID { get; set; }

    /// <summary>班组序号</summary>
    [SugarColumn(ColumnName = "P04T_ShiftNumber", Length = 20, IsNullable = true, ColumnDescription = "班组序号")]
    public string? P04T_ShiftNumber { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "P04T_GroupNameShift", Length = 20, IsNullable = true, ColumnDescription = "班组")]
    public string? P04T_GroupNameShift { get; set; }

    /// <summary>年</summary>
    [SugarColumn(ColumnName = "P04T_Year", IsNullable = true, ColumnDescription = "年")]
    public int? P04T_Year { get; set; }

    /// <summary>月</summary>
    [SugarColumn(ColumnName = "P04T_Month", IsNullable = true, ColumnDescription = "月")]
    public int? P04T_Month { get; set; }

    /// <summary>日</summary>
    [SugarColumn(ColumnName = "P04T_Day", IsNullable = true, ColumnDescription = "日")]
    public int? P04T_Day { get; set; }

    /// <summary>星期几</summary>
    [SugarColumn(ColumnName = "P04T_WeekDay", Length = 30, IsNullable = true, ColumnDescription = "星期几")]
    public string? P04T_WeekDay { get; set; }

    /// <summary>周数</summary>
    [SugarColumn(ColumnName = "P04T_Week", IsNullable = true, ColumnDescription = "周数")]
    public int? P04T_Week { get; set; }

    /// <summary>班开始时间</summary>
    [SugarColumn(ColumnName = "P04T_StartTime", IsNullable = true, ColumnDescription = "班开始时间")]
    public DateTime? P04T_StartTime { get; set; }

    /// <summary>班结束时间</summary>
    [SugarColumn(ColumnName = "P04T_EndTime", IsNullable = true, ColumnDescription = "班结束时间")]
    public DateTime? P04T_EndTime { get; set; }

    /// <summary>班开始年月日</summary>
    [SugarColumn(ColumnName = "P04T_StartYearMontDay", IsNullable = true, ColumnDescription = "班开始年月日")]
    public DateTime? P04T_StartYearMontDay { get; set; }

    /// <summary>订单开始时间</summary>
    [SugarColumn(ColumnName = "P04P_StartTime", IsNullable = true, ColumnDescription = "订单开始时间")]
    public DateTime? P04P_StartTime { get; set; }

    /// <summary>订单结束时间</summary>
    [SugarColumn(ColumnName = "P04P_EndTime", IsNullable = true, ColumnDescription = "订单结束时间")]
    public DateTime? P04P_EndTime { get; set; }

    /// <summary>产时</summary>
    [SugarColumn(ColumnName = "P04T_ProduceTime", Length = 28, DecimalDigits = 2, IsNullable = true, ColumnDescription = "产时")]
    public decimal? P04T_ProduceTime { get; set; }

    /// <summary>停时</summary>
    [SugarColumn(ColumnName = "P04T_OrderStopTime", IsNullable = true, ColumnDescription = "停时")]
    public int? P04T_OrderStopTime { get; set; }

    /// <summary>停次</summary>
    [SugarColumn(ColumnName = "P04T_OrderStopNum", IsNullable = true, ColumnDescription = "停次")]
    public int? P04T_OrderStopNum { get; set; }

    /// <summary>订单米数</summary>
    [SugarColumn(ColumnName = "P04T_ScheduleMeter", IsNullable = true, ColumnDescription = "订单米数")]
    public double? P04T_ScheduleMeter { get; set; }

    /// <summary>生产米数</summary>
    [SugarColumn(ColumnName = "P04T_ProduceMeter", IsNullable = true, ColumnDescription = "生产米数")]
    public double? P04T_ProduceMeter { get; set; }

    /// <summary>不良米数</summary>
    [SugarColumn(ColumnName = "P04T_BadMeter", IsNullable = true, ColumnDescription = "不良米数")]
    public double? P04T_BadMeter { get; set; }

    /// <summary>良米数</summary>
    [SugarColumn(ColumnName = "P04T_GoodMeter", IsNullable = true, ColumnDescription = "良米数")]
    public double? P04T_GoodMeter { get; set; }

    /// <summary>订单平米</summary>
    [SugarColumn(ColumnName = "P04T_ScheduleArea", IsNullable = true, ColumnDescription = "订单平米")]
    public double? P04T_ScheduleArea { get; set; }

    /// <summary>生产平米</summary>
    [SugarColumn(ColumnName = "P04T_ProduceArea", IsNullable = true, ColumnDescription = "生产平米")]
    public double? P04T_ProduceArea { get; set; }

    /// <summary>不良平米</summary>
    [SugarColumn(ColumnName = "P04T_BadArea", IsNullable = true, ColumnDescription = "不良平米")]
    public double? P04T_BadArea { get; set; }

    /// <summary>良平米</summary>
    [SugarColumn(ColumnName = "P04T_GoodArea", IsNullable = true, ColumnDescription = "良平米")]
    public double? P04T_GoodArea { get; set; }

    /// <summary>订单张数</summary>
    [SugarColumn(ColumnName = "P04T_ScheduleSheet", IsNullable = true, ColumnDescription = "订单张数")]
    public long? P04T_ScheduleSheet { get; set; }

    /// <summary>生产张数</summary>
    [SugarColumn(ColumnName = "P04T_ProduceSheet", IsNullable = true, ColumnDescription = "生产张数")]
    public long? P04T_ProduceSheet { get; set; }

    /// <summary>不良张数</summary>
    [SugarColumn(ColumnName = "P04T_BadSheet", IsNullable = true, ColumnDescription = "不良张数")]
    public long? P04T_BadSheet { get; set; }

    /// <summary>良品张数</summary>
    [SugarColumn(ColumnName = "P04T_GoodSheet", IsNullable = true, ColumnDescription = "良品张数")]
    public long? P04T_GoodSheet { get; set; }

    /// <summary>平局车速</summary>
    [SugarColumn(ColumnName = "P04T_AvgSpeed", Length = 28, DecimalDigits = 2, IsNullable = true, ColumnDescription = "平局车速")]
    public decimal? P04T_AvgSpeed { get; set; }

    /// <summary>不良率</summary>
    [SugarColumn(ColumnName = "P04T_BadPercent", Length = 18, DecimalDigits = 6, IsNullable = true, ColumnDescription = "不良率")]
    public decimal? P04T_BadPercent { get; set; }

    /// <summary>修边平米</summary>
    [SugarColumn(ColumnName = "P04T_TrimArea", IsNullable = true, ColumnDescription = "修边平米")]
    public double? P04T_TrimArea { get; set; }

    /// <summary>修边率</summary>
    [SugarColumn(ColumnName = "P04T_TrimPecent", Length = 18, DecimalDigits = 6, IsNullable = true, ColumnDescription = "修边率")]
    public decimal? P04T_TrimPecent { get; set; }

    /// <summary>订单数</summary>
    [SugarColumn(ColumnName = "P04T_OrderNum", IsNullable = true, ColumnDescription = "订单数")]
    public long? P04T_OrderNum { get; set; }

    /// <summary>平均门幅</summary>
    [SugarColumn(ColumnName = "P04T_AvgWidth", IsNullable = true, ColumnDescription = "平均门幅")]
    public int? P04T_AvgWidth { get; set; }

    /// <summary>平均米数</summary>
    [SugarColumn(ColumnName = "P04T_AvgMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "平均米数")]
    public decimal? P04T_AvgMeter { get; set; }

    /// <summary>材质数</summary>
    [SugarColumn(ColumnName = "P04T_PaperCodeNum", IsNullable = true, ColumnDescription = "材质数")]
    public int? P04T_PaperCodeNum { get; set; }

    /// <summary>材质平均米数</summary>
    [SugarColumn(ColumnName = "P04T_PaperCodeAvgMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "材质平均米数")]
    public decimal? P04T_PaperCodeAvgMeter { get; set; }

    /// <summary>未回收</summary>
    [SugarColumn(ColumnName = "P04T_BadOrderNum", IsNullable = true, ColumnDescription = "未回收")]
    public int? P04T_BadOrderNum { get; set; }

    /// <summary>多回收</summary>
    [SugarColumn(ColumnName = "P04T_BadMuchNum", IsNullable = true, ColumnDescription = "多回收")]
    public int? P04T_BadMuchNum { get; set; }

    /// <summary>上刀订单数</summary>
    [SugarColumn(ColumnName = "P04T_OrderNumUp", IsNullable = true, ColumnDescription = "上刀订单数")]
    public long? P04T_OrderNumUp { get; set; }

    /// <summary>P04T_OrderNumUp_All</summary>
    [SugarColumn(ColumnName = "P04T_OrderNumUp_All", IsNullable = true, ColumnDescription = "P04T_OrderNumUp_All")]
    public long? P04T_OrderNumUp_All { get; set; }

    /// <summary>下刀订单数</summary>
    [SugarColumn(ColumnName = "P04T_OrderNumDown", IsNullable = true, ColumnDescription = "下刀订单数")]
    public long? P04T_OrderNumDown { get; set; }

    /// <summary>门幅合计</summary>
    [SugarColumn(ColumnName = "P04T_CountWidth", IsNullable = true, ColumnDescription = "门幅合计")]
    public double? P04T_CountWidth { get; set; }

    /// <summary>P04T_IsEnd</summary>
    [SugarColumn(ColumnName = "P04T_IsEnd", IsNullable = true, ColumnDescription = "P04T_IsEnd")]
    public bool? P04T_IsEnd { get; set; }

    /// <summary>P04T_AccumulatedSteamFlow</summary>
    [SugarColumn(ColumnName = "P04T_AccumulatedSteamFlow", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "P04T_AccumulatedSteamFlow")]
    public decimal? P04T_AccumulatedSteamFlow { get; set; }

    /// <summary>P04T_AccumulatedElectricity</summary>
    [SugarColumn(ColumnName = "P04T_AccumulatedElectricity", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "P04T_AccumulatedElectricity")]
    public decimal? P04T_AccumulatedElectricity { get; set; }

    /// <summary>P04T_TheoryWeight</summary>
    [SugarColumn(ColumnName = "P04T_TheoryWeight", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "P04T_TheoryWeight")]
    public decimal? P04T_TheoryWeight { get; set; }

    /// <summary>P04T_SteamRate</summary>
    [SugarColumn(ColumnName = "P04T_SteamRate", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "P04T_SteamRate")]
    public decimal? P04T_SteamRate { get; set; }

    /// <summary>P04T_ElectricityRate</summary>
    [SugarColumn(ColumnName = "P04T_ElectricityRate", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "P04T_ElectricityRate")]
    public decimal? P04T_ElectricityRate { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}