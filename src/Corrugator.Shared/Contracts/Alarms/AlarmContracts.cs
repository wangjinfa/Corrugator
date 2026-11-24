using Corrugator.Shared.Api;

namespace Corrugator.Shared.Contracts.Alarms;

/// <summary>预警历史记录（W_Alarms）</summary>
public class AlarmDto
{
    public int WA_ID { get; set; }
    public string WA_PartCode { get; set; } = string.Empty;
    public string WA_ReasonCode { get; set; } = string.Empty;
    public DateTime? WA_FirstSendTime { get; set; }
    public DateTime? WA_LastSendTime { get; set; }
    public int? WA_SendNum { get; set; }
    public bool? WA_IsConfirm { get; set; }
    public string? WA_ConfirmBy { get; set; }
    public DateTime? WA_ConfirmTime { get; set; }
    public bool? WA_IsReview { get; set; }
    public string? WA_Reviewer { get; set; }
    public string? WA_ReviewNote { get; set; }
    public string? WA_ReasonText { get; set; }
    public bool IsHandled => WA_IsConfirm == true;
}

public class AlarmQuery : PageQuery
{
    public string? PartCode { get; set; }
    public string? ReasonCode { get; set; }
    public bool? IsConfirm { get; set; }
    public DateTime? DateFrom { get; set; }
    public DateTime? DateTo { get; set; }
}

public class AlarmConfirmInput
{
    public string? ConfirmBy { get; set; }
    public string? ReviewNote { get; set; }
}
