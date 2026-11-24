using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Orders;

namespace Corrugator.Application.Services;

public interface IOrderService
{
    /// <summary>未完工订单分页查询（W_Orders）</summary>
    Task<PagedResult<OrderDto>> GetPagedAsync(OrderQuery query);

    Task<OrderDto> GetAsync(int id);

    Task<OrderDto> CreateAsync(OrderInput input);

    Task<OrderDto> UpdateAsync(OrderInput input);

    /// <summary>删除订单（写 W_Orders.WO_IsDel 逻辑删除标记）</summary>
    Task DeleteAsync(int id);

    /// <summary>完工订单分页查询（W_OrderFinishs）</summary>
    Task<PagedResult<FinishedOrderDto>> GetFinishedPagedAsync(OrderQuery query);
}
