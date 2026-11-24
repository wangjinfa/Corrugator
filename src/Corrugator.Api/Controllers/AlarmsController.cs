using Corrugator.Application.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Alarms;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

[ApiController]
[Route("api/alarms")]
[Authorize]
public class AlarmsController : ControllerBase
{
    private readonly IAlarmService _service;

    public AlarmsController(IAlarmService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ApiResult<PagedResult<AlarmDto>>> GetPaged([FromQuery] AlarmQuery query)
        => ApiResult<PagedResult<AlarmDto>>.Ok(await _service.GetPagedAsync(query));

    /// <summary>确认告警</summary>
    [HttpPost("{id:int}/confirm")]
    public async Task<ApiResult<AlarmDto>> Confirm(int id, [FromBody] AlarmConfirmInput input)
        => ApiResult<AlarmDto>.Ok(await _service.ConfirmAsync(id, input), "已确认");
}
