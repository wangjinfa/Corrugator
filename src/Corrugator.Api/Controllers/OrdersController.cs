using Corrugator.Application.Services;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Orders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Corrugator.Api.Controllers;

[ApiController]
[Route("api/orders")]
[Authorize]
public class OrdersController : ControllerBase
{
    private readonly IOrderService _service;

    public OrdersController(IOrderService service)
    {
        _service = service;
    }

    /// <summary>未完工订单分页查询</summary>
    [HttpGet]
    public async Task<ApiResult<PagedResult<OrderDto>>> GetPaged([FromQuery] OrderQuery query)
        => ApiResult<PagedResult<OrderDto>>.Ok(await _service.GetPagedAsync(query));

    /// <summary>完工订单分页查询</summary>
    [HttpGet("finished")]
    public async Task<ApiResult<PagedResult<FinishedOrderDto>>> GetFinished([FromQuery] OrderQuery query)
        => ApiResult<PagedResult<FinishedOrderDto>>.Ok(await _service.GetFinishedPagedAsync(query));

    [HttpGet("{id:int}")]
    public async Task<ApiResult<OrderDto>> Get(int id)
        => ApiResult<OrderDto>.Ok(await _service.GetAsync(id));

    [HttpPost]
    public async Task<ApiResult<OrderDto>> Create([FromBody] OrderInput input)
        => ApiResult<OrderDto>.Ok(await _service.CreateAsync(input), "新增成功");

    [HttpPut("{id:int}")]
    public async Task<ApiResult<OrderDto>> Update(int id, [FromBody] OrderInput input)
    {
        input.WO_ID = id;
        return ApiResult<OrderDto>.Ok(await _service.UpdateAsync(input), "修改成功");
    }

    [HttpDelete("{id:int}")]
    public async Task<ApiResult<bool>> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return ApiResult<bool>.Ok(true, "删除成功");
    }
}
