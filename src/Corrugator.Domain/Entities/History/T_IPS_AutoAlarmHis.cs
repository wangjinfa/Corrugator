using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// T_IPS_AutoAlarmHis
/// </summary>
[SugarTable("T_IPS_AutoAlarmHis", TableDescription = "T_IPS_AutoAlarmHis")]
public class T_IPS_AutoAlarmHis
{
    /// <summary>预警编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 36, ColumnDescription = "预警编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>预警时间</summary>
    [SugarColumn(ColumnName = "F_Time", ColumnDescription = "预警时间")]
    public DateTime F_Time { get; set; }

    /// <summary>预警时参数Json</summary>
    [SugarColumn(ColumnName = "F_Pairs", IsNullable = true, ColumnDescription = "预警时参数Json")]
    public string? F_Pairs { get; set; }

    /// <summary>预警部位编码</summary>
    [SugarColumn(ColumnName = "F_PositionCode", Length = 100, IsNullable = true, ColumnDescription = "预警部位编码")]
    public string? F_PositionCode { get; set; }

    /// <summary>运行值</summary>
    [SugarColumn(ColumnName = "F_CurValue", Length = 50, IsNullable = true, ColumnDescription = "运行值")]
    public string? F_CurValue { get; set; }

    /// <summary>设置值</summary>
    [SugarColumn(ColumnName = "F_SetValue", Length = 50, IsNullable = true, ColumnDescription = "设置值")]
    public string? F_SetValue { get; set; }

    /// <summary>设置的偏差值</summary>
    [SugarColumn(ColumnName = "F_OffsetValue", Length = 50, IsNullable = true, ColumnDescription = "设置的偏差值")]
    public string? F_OffsetValue { get; set; }

    /// <summary>差值</summary>
    [SugarColumn(ColumnName = "F_Offset", Length = 50, IsNullable = true, ColumnDescription = "差值")]
    public string? F_Offset { get; set; }

    /// <summary>订单ID</summary>
    [SugarColumn(ColumnName = "F_OrderID", Length = 50, IsNullable = true, ColumnDescription = "订单ID")]
    public string? F_OrderID { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}