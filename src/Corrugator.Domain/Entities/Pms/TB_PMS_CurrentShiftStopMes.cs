using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// TB_PMS_CurrentShiftStopMes
/// </summary>
[SugarTable("TB_PMS_CurrentShiftStopMes", TableDescription = "TB_PMS_CurrentShiftStopMes")]
public class TB_PMS_CurrentShiftStopMes
{
    /// <summary>班组号</summary>
    [SugarColumn(ColumnName = "F_CurrShiftNum", Length = 50, IsNullable = true, ColumnDescription = "班组号")]
    public string? F_CurrShiftNum { get; set; }

    /// <summary>DF停次</summary>
    [SugarColumn(ColumnName = "F_StopTimesDF", IsNullable = true, ColumnDescription = "DF停次")]
    public int? F_StopTimesDF { get; set; }

    /// <summary>DF停时</summary>
    [SugarColumn(ColumnName = "F_StopDateTimeDF", IsNullable = true, ColumnDescription = "DF停时")]
    public int? F_StopDateTimeDF { get; set; }

    /// <summary>P04S中DF的ID</summary>
    [SugarColumn(ColumnName = "F_CurrP04SIdDF", IsNullable = true, ColumnDescription = "P04S中DF的ID")]
    public int? F_CurrP04SIdDF { get; set; }

    /// <summary>SF1停次</summary>
    [SugarColumn(ColumnName = "F_StopTimesSF1", IsNullable = true, ColumnDescription = "SF1停次")]
    public int? F_StopTimesSF1 { get; set; }

    /// <summary>SF1停时</summary>
    [SugarColumn(ColumnName = "F_StopDateTimeSF1", IsNullable = true, ColumnDescription = "SF1停时")]
    public int? F_StopDateTimeSF1 { get; set; }

    /// <summary>P04S中SF1的ID</summary>
    [SugarColumn(ColumnName = "F_CurrP04SIdSF1", IsNullable = true, ColumnDescription = "P04S中SF1的ID")]
    public int? F_CurrP04SIdSF1 { get; set; }

    /// <summary>SF2停次</summary>
    [SugarColumn(ColumnName = "F_StopTimesSF2", IsNullable = true, ColumnDescription = "SF2停次")]
    public int? F_StopTimesSF2 { get; set; }

    /// <summary>SF2停时</summary>
    [SugarColumn(ColumnName = "F_StopDateTimeSF2", IsNullable = true, ColumnDescription = "SF2停时")]
    public int? F_StopDateTimeSF2 { get; set; }

    /// <summary>P04S中SF2的ID</summary>
    [SugarColumn(ColumnName = "F_CurrP04SIdSF2", IsNullable = true, ColumnDescription = "P04S中SF2的ID")]
    public int? F_CurrP04SIdSF2 { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}