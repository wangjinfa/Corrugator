using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 停机数据表
/// </summary>
[SugarTable("W_ProEventP04Ss", TableDescription = "停机数据表")]
public class W_ProEventP04Ss
{
    /// <summary>开始时间</summary>
    [SugarColumn(ColumnName = "WP_StartTime", IsNullable = true, ColumnDescription = "开始时间")]
    public DateTime? WP_StartTime { get; set; }

    /// <summary>结束时间</summary>
    [SugarColumn(ColumnName = "WP_EndTime", IsNullable = true, ColumnDescription = "结束时间")]
    public DateTime? WP_EndTime { get; set; }

    /// <summary>机器组号</summary>
    [SugarColumn(ColumnName = "WP_MachineGroupNum", Length = 20, IsNullable = true, ColumnDescription = "机器组号")]
    public string? WP_MachineGroupNum { get; set; }

    /// <summary>机器号</summary>
    [SugarColumn(ColumnName = "WP_MachineNum", Length = 20, IsNullable = true, ColumnDescription = "机器号")]
    public string? WP_MachineNum { get; set; }

    /// <summary>故障类型</summary>
    [SugarColumn(ColumnName = "WP_FaultKind", IsNullable = true, ColumnDescription = "故障类型")]
    public int? WP_FaultKind { get; set; }

    /// <summary>故障代码</summary>
    [SugarColumn(ColumnName = "WP_FaultNum", Length = 20, IsNullable = true, ColumnDescription = "故障代码")]
    public string? WP_FaultNum { get; set; }

    /// <summary>故障文本</summary>
    [SugarColumn(ColumnName = "WP_FaltText", Length = 100, IsNullable = true, ColumnDescription = "故障文本")]
    public string? WP_FaltText { get; set; }

    /// <summary>用户信息</summary>
    [SugarColumn(ColumnName = "WP_UserInfo", Length = 200, IsNullable = true, ColumnDescription = "用户信息")]
    public string? WP_UserInfo { get; set; }

    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "WP_ShiftNum", Length = 20, IsNullable = true, ColumnDescription = "班次号")]
    public string? WP_ShiftNum { get; set; }

    /// <summary>WP_P04TID</summary>
    [SugarColumn(ColumnName = "WP_P04TID", IsNullable = true, ColumnDescription = "WP_P04TID")]
    public int? WP_P04TID { get; set; }

    /// <summary>WP_OrderID</summary>
    [SugarColumn(ColumnName = "WP_OrderID", IsNullable = true, ColumnDescription = "WP_OrderID")]
    public int? WP_OrderID { get; set; }

    /// <summary>WP_Id</summary>
    [SugarColumn(ColumnName = "WP_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WP_Id")]
    public int WP_Id { get; set; }

}