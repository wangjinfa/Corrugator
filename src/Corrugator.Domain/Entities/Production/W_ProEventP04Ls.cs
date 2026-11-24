using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 低速运行表
/// </summary>
[SugarTable("W_ProEventP04Ls", TableDescription = "低速运行表")]
public class W_ProEventP04Ls
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

    /// <summary>低速类型</summary>
    [SugarColumn(ColumnName = "WP_SlowKind", IsNullable = true, ColumnDescription = "低速类型")]
    public int? WP_SlowKind { get; set; }

    /// <summary>低速原因</summary>
    [SugarColumn(ColumnName = "WP_SlowReason", Length = 20, IsNullable = true, ColumnDescription = "低速原因")]
    public string? WP_SlowReason { get; set; }

    /// <summary>低速文本</summary>
    [SugarColumn(ColumnName = "WP_SlowText", Length = 100, IsNullable = true, ColumnDescription = "低速文本")]
    public string? WP_SlowText { get; set; }

    /// <summary>用户信息</summary>
    [SugarColumn(ColumnName = "WP_UserInfo", Length = 200, IsNullable = true, ColumnDescription = "用户信息")]
    public string? WP_UserInfo { get; set; }

    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "WP_ShiftNum", Length = 20, IsNullable = true, ColumnDescription = "班次号")]
    public string? WP_ShiftNum { get; set; }

    /// <summary>WP_Id</summary>
    [SugarColumn(ColumnName = "WP_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WP_Id")]
    public int WP_Id { get; set; }

}