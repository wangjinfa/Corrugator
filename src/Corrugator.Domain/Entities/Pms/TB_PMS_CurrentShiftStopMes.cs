using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// W_PMW_CurrentShiftStopMes
/// </summary>
[SugarTable("W_PMW_CurrentShiftStopMes", TableDescription = "W_PMW_CurrentShiftStopMes")]
public class W_PMW_CurrentShiftStopMes
{
    /// <summary>班组号</summary>
    [SugarColumn(ColumnName = "WF_CurrShiftNum", Length = 50, IsNullable = true, ColumnDescription = "班组号")]
    public string? WF_CurrShiftNum { get; set; }

    /// <summary>DF停次</summary>
    [SugarColumn(ColumnName = "WF_StopTimesDF", IsNullable = true, ColumnDescription = "DF停次")]
    public int? WF_StopTimesDF { get; set; }

    /// <summary>DF停时</summary>
    [SugarColumn(ColumnName = "WF_StopDateTimeDF", IsNullable = true, ColumnDescription = "DF停时")]
    public int? WF_StopDateTimeDF { get; set; }

    /// <summary>P04S中DF的ID</summary>
    [SugarColumn(ColumnName = "WF_CurrP04SIdDF", IsNullable = true, ColumnDescription = "P04S中DF的ID")]
    public int? WF_CurrP04SIdDF { get; set; }

    /// <summary>SF1停次</summary>
    [SugarColumn(ColumnName = "WF_StopTimesSF1", IsNullable = true, ColumnDescription = "SF1停次")]
    public int? WF_StopTimesSF1 { get; set; }

    /// <summary>SF1停时</summary>
    [SugarColumn(ColumnName = "WF_StopDateTimeSF1", IsNullable = true, ColumnDescription = "SF1停时")]
    public int? WF_StopDateTimeSF1 { get; set; }

    /// <summary>P04S中SF1的ID</summary>
    [SugarColumn(ColumnName = "WF_CurrP04SIdSF1", IsNullable = true, ColumnDescription = "P04S中SF1的ID")]
    public int? WF_CurrP04SIdSF1 { get; set; }

    /// <summary>SF2停次</summary>
    [SugarColumn(ColumnName = "WF_StopTimesSF2", IsNullable = true, ColumnDescription = "SF2停次")]
    public int? WF_StopTimesSF2 { get; set; }

    /// <summary>SF2停时</summary>
    [SugarColumn(ColumnName = "WF_StopDateTimeSF2", IsNullable = true, ColumnDescription = "SF2停时")]
    public int? WF_StopDateTimeSF2 { get; set; }

    /// <summary>P04S中SF2的ID</summary>
    [SugarColumn(ColumnName = "WF_CurrP04SIdSF2", IsNullable = true, ColumnDescription = "P04S中SF2的ID")]
    public int? WF_CurrP04SIdSF2 { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}