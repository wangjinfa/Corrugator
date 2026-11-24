using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// W_PMS_EnergyMaintenance
/// </summary>
[SugarTable("W_PMS_EnergyMaintenance", TableDescription = "W_PMS_EnergyMaintenance")]
public class W_PMS_EnergyMaintenance
{
    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>WF_P04TID</summary>
    [SugarColumn(ColumnName = "WF_P04TID", ColumnDescription = "WF_P04TID")]
    public int WF_P04TID { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "WF_ShiftNum", Length = 20, IsNullable = true, ColumnDescription = "班组")]
    public string? WF_ShiftNum { get; set; }

    /// <summary>开始时间</summary>
    [SugarColumn(ColumnName = "WF_StartTime", IsNullable = true, ColumnDescription = "开始时间")]
    public DateTime? WF_StartTime { get; set; }

    /// <summary>结束时间</summary>
    [SugarColumn(ColumnName = "WF_EndTime", IsNullable = true, ColumnDescription = "结束时间")]
    public DateTime? WF_EndTime { get; set; }

    /// <summary>编号</summary>
    [SugarColumn(ColumnName = "WF_Number", Length = 50, IsNullable = true, ColumnDescription = "编号")]
    public string? WF_Number { get; set; }

    /// <summary>点位名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 50, IsNullable = true, ColumnDescription = "点位名称")]
    public string? WF_Name { get; set; }

    /// <summary>开始用量</summary>
    [SugarColumn(ColumnName = "WF_StartValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "开始用量")]
    public decimal? WF_StartValue { get; set; }

    /// <summary>结束用量</summary>
    [SugarColumn(ColumnName = "WF_EndValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "结束用量")]
    public decimal? WF_EndValue { get; set; }

    /// <summary>用量</summary>
    [SugarColumn(ColumnName = "WF_DiffValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "用量")]
    public decimal? WF_DiffValue { get; set; }

    /// <summary>单价</summary>
    [SugarColumn(ColumnName = "WF_Price", Length = 10, DecimalDigits = 2, IsNullable = true, ColumnDescription = "单价")]
    public decimal? WF_Price { get; set; }

    /// <summary>来源</summary>
    [SugarColumn(ColumnName = "WF_Source", Length = 50, IsNullable = true, ColumnDescription = "来源")]
    public string? WF_Source { get; set; }

    /// <summary>显示价格</summary>
    [SugarColumn(ColumnName = "WF_ShowPrice", IsNullable = true, ColumnDescription = "显示价格")]
    public bool? WF_ShowPrice { get; set; }

}