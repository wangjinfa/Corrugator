using System.Linq.Expressions;
using Corrugator.Application.Abstractions;
using Corrugator.Application.Exceptions;
using Corrugator.Domain.Entities.Production;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Alarms;

namespace Corrugator.Application.Services;

/// <summary>告警服务：W_Alarms 预警历史记录</summary>
public class AlarmService : IAlarmService
{
    private readonly IRepository<W_Alarms> _alarms;
    private readonly IUserContext _user;

    public AlarmService(IRepository<W_Alarms> alarms, IUserContext user)
    {
        _alarms = alarms;
        _user = user;
    }

    public async Task<PagedResult<AlarmDto>> GetPagedAsync(AlarmQuery query)
    {
        var part = query.PartCode;
        var reason = query.ReasonCode;
        var confirm = query.IsConfirm;
        var from = query.DateFrom;
        var to = query.DateTo;

        Expression<Func<W_Alarms, bool>> where = it =>
            (part == null || it.WA_PartCode == part)
            && (reason == null || it.WA_ReasonCode == reason)
            && (confirm == null || it.WA_IsConfirm == confirm)
            && (from == null || (it.WA_FirstSendTime != null && it.WA_FirstSendTime >= from))
            && (to == null || (it.WA_FirstSendTime != null && it.WA_FirstSendTime <= to));

        var page = await _alarms.PageAsync(where, query, "WA_LastSendTime DESC, WA_ID DESC");
        var items = page.Items.Select(ToDto).ToList();
        return new PagedResult<AlarmDto>(items, page.Total, page.PageIndex, page.PageSize);
    }

    public async Task<AlarmDto> ConfirmAsync(int id, AlarmConfirmInput input)
    {
        var entity = await _alarms.GetByIdAsync(id)
                     ?? throw new NotFoundException($"告警 {id} 不存在");

        entity.WA_IsConfirm = true;
        entity.WA_ConfirmBy = string.IsNullOrWhiteSpace(input.ConfirmBy) ? _user.UserName : input.ConfirmBy;
        entity.WA_ConfirmTime = DateTime.Now;
        if (!string.IsNullOrWhiteSpace(input.ReviewNote))
        {
            entity.WA_ReviewNote = input.ReviewNote;
        }

        await _alarms.UpdateAsync(entity);
        return ToDto(entity);
    }

    private static AlarmDto ToDto(W_Alarms e) => new()
    {
        WA_ID = e.WA_ID,
        WA_PartCode = e.WA_PartCode,
        WA_ReasonCode = e.WA_ReasonCode,
        WA_FirstSendTime = e.WA_FirstSendTime,
        WA_LastSendTime = e.WA_LastSendTime,
        WA_SendNum = e.WA_SendNum,
        WA_IsConfirm = e.WA_IsConfirm,
        WA_ConfirmBy = e.WA_ConfirmBy,
        WA_ConfirmTime = e.WA_ConfirmTime,
        WA_IsReview = e.WA_IsReview,
        WA_Reviewer = e.WA_Reviewer,
        WA_ReviewNote = e.WA_ReviewNote,
        WA_ReasonText = e.WA_ReasonText,
    };
}
