using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// TB_PMS_EnergyMaintenance
/// </summary>
[SugarTable("TB_PMS_EnergyMaintenance", TableDescription = "TB_PMS_EnergyMaintenance")]
public class TB_PMS_EnergyMaintenance
{
    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>F_P04TID</summary>
    [SugarColumn(ColumnName = "F_P04TID", ColumnDescription = "F_P04TID")]
    public int F_P04TID { get; set; }

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "F_ShiftNum", Length = 20, IsNullable = true, ColumnDescription = "班组")]
    public string? F_ShiftNum { get; set; }

    /// <summary>开始时间</summary>
    [SugarColumn(ColumnName = "F_StartTime", IsNullable = true, ColumnDescription = "开始时间")]
    public DateTime? F_StartTime { get; set; }

    /// <summary>结束时间</summary>
    [SugarColumn(ColumnName = "F_EndTime", IsNullable = true, ColumnDescription = "结束时间")]
    public DateTime? F_EndTime { get; set; }

    /// <summary>编号</summary>
    [SugarColumn(ColumnName = "F_Number", Length = 50, IsNullable = true, ColumnDescription = "编号")]
    public string? F_Number { get; set; }

    /// <summary>点位名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 50, IsNullable = true, ColumnDescription = "点位名称")]
    public string? F_Name { get; set; }

    /// <summary>开始用量</summary>
    [SugarColumn(ColumnName = "F_StartValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "开始用量")]
    public decimal? F_StartValue { get; set; }

    /// <summary>结束用量</summary>
    [SugarColumn(ColumnName = "F_EndValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "结束用量")]
    public decimal? F_EndValue { get; set; }

    /// <summary>用量</summary>
    [SugarColumn(ColumnName = "F_DiffValue", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "用量")]
    public decimal? F_DiffValue { get; set; }

    /// <summary>单价</summary>
    [SugarColumn(ColumnName = "F_Price", Length = 10, DecimalDigits = 2, IsNullable = true, ColumnDescription = "单价")]
    public decimal? F_Price { get; set; }

    /// <summary>来源</summary>
    [SugarColumn(ColumnName = "F_Source", Length = 50, IsNullable = true, ColumnDescription = "来源")]
    public string? F_Source { get; set; }

    /// <summary>显示价格</summary>
    [SugarColumn(ColumnName = "F_ShowPrice", IsNullable = true, ColumnDescription = "显示价格")]
    public bool? F_ShowPrice { get; set; }

}