using Corrugator.Application.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Process;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

[ApiController]
[Route("api/process-params")]
[Authorize]
public class ProcessParamsController : ControllerBase
{
    private readonly IProcessParamService _service;

    public ProcessParamsController(IProcessParamService service)
    {
        _service = service;
    }

    /// <summary>产线楞型基础资料（W_ProductWaves）</summary>
    [HttpGet("waves")]
    public async Task<ApiResult<PagedResult<WaveProfileDto>>> GetWaves([FromQuery] WaveQuery query)
        => ApiResult<PagedResult<WaveProfileDto>>.Ok(await _service.GetWaveProfilesAsync(query));

    /// <summary>当前工艺系数（W_QDM_FormSetFactor），返回键值对</summary>
    [HttpGet("factors")]
    public async Task<ApiResult<List<ProcessFactorItemDto>>> GetFactors([FromQuery] string? keyword = null)
        => ApiResult<List<ProcessFactorItemDto>>.Ok(await _service.GetFactorsAsync(keyword));

    /// <summary>修改单项工艺参数</summary>
    [HttpPut("factors")]
    public async Task<ApiResult<bool>> UpdateFactor([FromBody] ProcessFactorUpdateDto input)
        => ApiResult<bool>.Ok(await _service.UpdateFactorAsync(input), "已保存");

    /// <summary>批量修改工艺参数（一次事务提交）</summary>
    [HttpPut("factors/batch")]
    public async Task<ApiResult<int>> UpdateFactors([FromBody] List<ProcessFactorUpdateDto> inputs)
        => ApiResult<int>.Ok(await _service.UpdateFactorsAsync(inputs), "已保存");
}
