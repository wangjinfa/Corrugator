using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// W_IPS_AutoAlarmHis
/// </summary>
[SugarTable("W_IPS_AutoAlarmHis", TableDescription = "W_IPS_AutoAlarmHis")]
public class W_IPS_AutoAlarmHis
{
    /// <summary>预警编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 36, ColumnDescription = "预警编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>预警时间</summary>
    [SugarColumn(ColumnName = "WF_Time", ColumnDescription = "预警时间")]
    public DateTime WF_Time { get; set; }

    /// <summary>预警时参数Json</summary>
    [SugarColumn(ColumnName = "WF_Pairs", IsNullable = true, ColumnDescription = "预警时参数Json")]
    public string? WF_Pairs { get; set; }

    /// <summary>预警部位编码</summary>
    [SugarColumn(ColumnName = "WF_PositionCode", Length = 100, IsNullable = true, ColumnDescription = "预警部位编码")]
    public string? WF_PositionCode { get; set; }

    /// <summary>运行值</summary>
    [SugarColumn(ColumnName = "WF_CurValue", Length = 50, IsNullable = true, ColumnDescription = "运行值")]
    public string? WF_CurValue { get; set; }

    /// <summary>设置值</summary>
    [SugarColumn(ColumnName = "WF_SetValue", Length = 50, IsNullable = true, ColumnDescription = "设置值")]
    public string? WF_SetValue { get; set; }

    /// <summary>设置的偏差值</summary>
    [SugarColumn(ColumnName = "WF_OffsetValue", Length = 50, IsNullable = true, ColumnDescription = "设置的偏差值")]
    public string? WF_OffsetValue { get; set; }

    /// <summary>差值</summary>
    [SugarColumn(ColumnName = "WF_Offset", Length = 50, IsNullable = true, ColumnDescription = "差值")]
    public string? WF_Offset { get; set; }

    /// <summary>订单ID</summary>
    [SugarColumn(ColumnName = "WF_OrderID", Length = 50, IsNullable = true, ColumnDescription = "订单ID")]
    public string? WF_OrderID { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}