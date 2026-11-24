using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 预警历史记录表
/// </summary>
[SugarTable("W_Alarms", TableDescription = "预警历史记录表")]
public class W_Alarms
{
    /// <summary>部位代码</summary>
    [SugarColumn(ColumnName = "WA_PartCode", Length = 20, ColumnDescription = "部位代码")]
    public string WA_PartCode { get; set; } = default!;

    /// <summary>原因代码</summary>
    [SugarColumn(ColumnName = "WA_ReasonCode", Length = 20, ColumnDescription = "原因代码")]
    public string WA_ReasonCode { get; set; } = default!;

    /// <summary>首次发送时间</summary>
    [SugarColumn(ColumnName = "WA_FirstSendTime", IsNullable = true, ColumnDescription = "首次发送时间")]
    public DateTime? WA_FirstSendTime { get; set; }

    /// <summary>最后一次发送时间</summary>
    [SugarColumn(ColumnName = "WA_LastSendTime", IsNullable = true, ColumnDescription = "最后一次发送时间")]
    public DateTime? WA_LastSendTime { get; set; }

    /// <summary>发送次数</summary>
    [SugarColumn(ColumnName = "WA_SendNum", IsNullable = true, ColumnDescription = "发送次数")]
    public int? WA_SendNum { get; set; }

    /// <summary>是否确认</summary>
    [SugarColumn(ColumnName = "WA_IsConfirm", IsNullable = true, ColumnDescription = "是否确认")]
    public bool? WA_IsConfirm { get; set; }

    /// <summary>确认人</summary>
    [SugarColumn(ColumnName = "WA_ConfirmBy", Length = 20, IsNullable = true, ColumnDescription = "确认人")]
    public string? WA_ConfirmBy { get; set; }

    /// <summary>确认时间</summary>
    [SugarColumn(ColumnName = "WA_ConfirmTime", IsNullable = true, ColumnDescription = "确认时间")]
    public DateTime? WA_ConfirmTime { get; set; }

    /// <summary>是否复核</summary>
    [SugarColumn(ColumnName = "WA_IsReview", IsNullable = true, ColumnDescription = "是否复核")]
    public bool? WA_IsReview { get; set; }

    /// <summary>复核人</summary>
    [SugarColumn(ColumnName = "WA_Reviewer", Length = 20, IsNullable = true, ColumnDescription = "复核人")]
    public string? WA_Reviewer { get; set; }

    /// <summary>复核说明</summary>
    [SugarColumn(ColumnName = "WA_ReviewNote", Length = 200, IsNullable = true, ColumnDescription = "复核说明")]
    public string? WA_ReviewNote { get; set; }

    /// <summary>其他原因</summary>
    [SugarColumn(ColumnName = "WA_ReasonText", IsNullable = true, ColumnDescription = "其他原因")]
    public string? WA_ReasonText { get; set; }

    /// <summary>WA_ID</summary>
    [SugarColumn(ColumnName = "WA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WA_ID")]
    public int WA_ID { get; set; }

}