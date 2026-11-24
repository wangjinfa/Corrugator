using System.Linq.Expressions;
using Corrugator.Application.Abstractions;
using Corrugator.Domain.Entities.Production;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Orders;

namespace Corrugator.Application.Services;

/// <summary>订单服务：未完工订单 W_Orders / 完工订单 W_OrderFinishs</summary>
public class OrderService : IOrderService
{
    private readonly IRepository<W_Orders> _orders;
    private readonly IRepository<W_OrderFinishs> _finished;
    private readonly IUnitOfWork _uow;
    private readonly IUserContext _user;

    public OrderService(
        IRepository<W_Orders> orders,
        IRepository<W_OrderFinishs> finished,
        IUnitOfWork uow,
        IUserContext user)
    {
        _orders = orders;
        _finished = finished;
        _uow = uow;
        _user = user;
    }

    public async Task<PagedResult<OrderDto>> GetPagedAsync(OrderQuery query)
    {
        var where = BuildWhere(query);
        var page = await _orders.PageAsync(where, query, "WO_SortSN DESC, WO_ID DESC");
        return new PagedResult<OrderDto>(
            page.Items.Select(ToDto).ToList(), page.Total, page.PageIndex, page.PageSize);
    }

    public async Task<OrderDto> GetAsync(int id)
    {
        var entity = await _orders.GetByIdAsync(id);
        if (entity is null || entity.WO_IsDel == true)
        {
            throw new Exceptions.NotFoundException($"订单 {id} 不存在");
        }

        return ToDto(entity);
    }

    public async Task<OrderDto> CreateAsync(OrderInput input)
    {
        if (string.IsNullOrWhiteSpace(input.WO_Wave))
        {
            throw new Exceptions.BusinessException("楞型不能为空");
        }

        var entity = new W_Orders
        {
            WEO_Guid = input.WEO_Guid,
            WO_IsUrgent = input.WO_IsUrgent,
            WO_WorkNo = input.WO_WorkNo,
            WO_ClassNo = input.WO_ClassNo,
            WO_PaperCode = input.WO_PaperCode,
            WO_Wave = input.WO_Wave,
            WO_Floor = input.WO_Floor == 0 ? 5 : input.WO_Floor,
            WO_Width = input.WO_Width,
            WO_Trim = input.WO_Trim,
            WO_Weight = input.WO_Weight,
            WO_Deep = input.WO_Deep,
            WO_Speed = input.WO_Speed,
            WO_ScheduleMeter = input.WO_ScheduleMeter,
            WO_OrderNo = input.WO_OrderNo,
            WO_CustNo = input.WO_CustNo,
            WO_CustName = input.WO_CustName,
            WO_CutWidth = input.WO_CutWidth,
            WO_CutLength = input.WO_CutLength,
            WO_CutQty = input.WO_CutQty,
            WO_CN = input.WO_CN,
            WO_ScorType = input.WO_ScorType,
            WO_Scor = input.WO_Scor,
            WO_ScorDeep = input.WO_ScorDeep,
            WO_SortSN = input.WO_SortSN,
            WO_Remark = input.WO_Remark,
            WO_OrderDate = input.WO_OrderDate ?? DateTime.Now,
            WO_DeliDate = input.WO_DeliDate,
            // 以下为数据字典中 NOT NULL 但界面不录入的列，给默认值保证可插入
            WO_Stop = false,
            WO_UGoD = false,
            WO_Stack = false,
            WO_StackQty = 0,
            WO_Bundle = false,
            WO_BundleQty = 0,
            WO_BundleNum = 0,
            WO_PrintNum = 0,
            WO_TrimCode = 0,
            WO_OperType = 0,
            WO_ERPCutQty = 0,
            WO_IsFake = false,
            WO_IsOppositeStack = false,
            WO_IsOppositeStack_D = false,
            WO_TuneInStatue = 0,
            WO_IsSmallCN_D = false,
            WO_IsDel = false,
            IndexNo = 0,
        };

        await _orders.InsertAsync(entity);
        return ToDto(entity);
    }

    public async Task<OrderDto> UpdateAsync(OrderInput input)
    {
        if (input.WO_ID is null)
        {
            throw new Exceptions.BusinessException("修改订单必须传 WO_ID");
        }

        var entity = await _orders.GetByIdAsync(input.WO_ID.Value);
        if (entity is null || entity.WO_IsDel == true)
        {
            throw new Exceptions.NotFoundException($"订单 {input.WO_ID} 不存在");
        }

        entity.WO_IsUrgent = input.WO_IsUrgent;
        entity.WO_WorkNo = input.WO_WorkNo;
        entity.WO_ClassNo = input.WO_ClassNo;
        entity.WO_PaperCode = input.WO_PaperCode;
        entity.WO_Wave = input.WO_Wave;
        entity.WO_Floor = input.WO_Floor;
        entity.WO_Width = input.WO_Width;
        entity.WO_Trim = input.WO_Trim;
        entity.WO_Weight = input.WO_Weight;
        entity.WO_Deep = input.WO_Deep;
        entity.WO_Speed = input.WO_Speed;
        entity.WO_ScheduleMeter = input.WO_ScheduleMeter;
        entity.WO_OrderNo = input.WO_OrderNo;
        entity.WO_CustNo = input.WO_CustNo;
        entity.WO_CustName = input.WO_CustName;
        entity.WO_CutWidth = input.WO_CutWidth;
        entity.WO_CutLength = input.WO_CutLength;
        entity.WO_CutQty = input.WO_CutQty;
        entity.WO_CN = input.WO_CN;
        entity.WO_ScorType = input.WO_ScorType;
        entity.WO_Scor = input.WO_Scor;
        entity.WO_ScorDeep = input.WO_ScorDeep;
        entity.WO_SortSN = input.WO_SortSN;
        entity.WO_Remark = input.WO_Remark;
        entity.WO_OrderDate = input.WO_OrderDate ?? entity.WO_OrderDate;
        entity.WO_DeliDate = input.WO_DeliDate ?? entity.WO_DeliDate;

        await _orders.UpdateAsync(entity);
        return ToDto(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _orders.GetByIdAsync(id)
                     ?? throw new Exceptions.NotFoundException($"订单 {id} 不存在");

        // IPS 的 W_Orders 用 WO_IsDel 表示删除，属于业务软删除，这里显式维护
        entity.WO_IsDel = true;
        await _uow.ExecuteAsync(async () => await _orders.UpdateAsync(entity));
    }

    public async Task<PagedResult<FinishedOrderDto>> GetFinishedPagedAsync(OrderQuery query)
    {
        var kw = query.Keyword;
        var wave = query.Wave;
        var paper = query.PaperCode;
        var workNo = query.WorkNo;
        var from = query.DateFrom;
        var to = query.DateTo;

        Expression<Func<W_OrderFinishs, bool>> where = it =>
            (kw == null || (it.WOF_OrderNo != null && it.WOF_OrderNo.Contains(kw))
                        || (it.WOF_CustName != null && it.WOF_CustName.Contains(kw)))
            && (wave == null || it.WOF_Wave == wave)
            && (paper == null || (it.WOF_PaperCode != null && it.WOF_PaperCode.Contains(paper)))
            && (workNo == null || it.WOF_WorkNo == workNo)
            && (from == null || (it.WOF_FinishTime != null && it.WOF_FinishTime >= from))
            && (to == null || (it.WOF_FinishTime != null && it.WOF_FinishTime <= to));

        var page = await _finished.PageAsync(where, query, "WOF_FinishTime DESC, WOF_ID DESC");
        var items = page.Items.Select(ToFinishedDto).ToList();
        return new PagedResult<FinishedOrderDto>(items, page.Total, page.PageIndex, page.PageSize);
    }

    private static Expression<Func<W_Orders, bool>> BuildWhere(OrderQuery q)
    {
        var kw = q.Keyword;
        var wave = q.Wave;
        var paper = q.PaperCode;
        var workNo = q.WorkNo;
        var classNo = q.ClassNo;
        var urgent = q.IsUrgent;
        var from = q.DateFrom;
        var to = q.DateTo;

        return it =>
            (it.WO_IsDel == null || it.WO_IsDel == false)
            && (kw == null
                || (it.WO_OrderNo != null && it.WO_OrderNo.Contains(kw))
                || (it.WO_CustName != null && it.WO_CustName.Contains(kw))
                || (it.WO_CustNo != null && it.WO_CustNo.Contains(kw)))
            && (wave == null || it.WO_Wave == wave)
            && (paper == null || it.WO_PaperCode.Contains(paper))
            && (workNo == null || it.WO_WorkNo == workNo)
            && (classNo == null || it.WO_ClassNo == classNo)
            && (urgent == null || it.WO_IsUrgent == urgent)
            && (from == null || (it.WO_OrderDate != null && it.WO_OrderDate >= from))
            && (to == null || (it.WO_OrderDate != null && it.WO_OrderDate <= to));
    }

    private static OrderDto ToDto(W_Orders e) => new()
    {
        WO_ID = e.WO_ID,
        WEO_Guid = e.WEO_Guid,
        WO_IsUrgent = e.WO_IsUrgent,
        WO_WorkNo = e.WO_WorkNo,
        WO_ClassNo = e.WO_ClassNo,
        WO_PaperCode = e.WO_PaperCode,
        WO_Wave = e.WO_Wave,
        WO_Floor = e.WO_Floor,
        WO_Width = e.WO_Width,
        WO_Trim = e.WO_Trim,
        WO_Weight = e.WO_Weight,
        WO_Deep = e.WO_Deep,
        WO_Speed = e.WO_Speed,
        WO_ScheduleMeter = e.WO_ScheduleMeter,
        WO_Stop = e.WO_Stop,
        WO_UGoD = e.WO_UGoD,
        WO_StartTime = e.WO_StartTime,
        WO_EstFinshTime = e.WO_EstFinshTime,
        WO_OrderNo = e.WO_OrderNo,
        WO_CustNo = e.WO_CustNo,
        WO_CustName = e.WO_CustName,
        WO_CutWidth = e.WO_CutWidth,
        WO_CutLength = e.WO_CutLength,
        WO_CutQty = e.WO_CutQty,
        WO_OrderQty = e.WO_OrderQty,
        WO_OrderMeter = e.WO_OrderMeter,
        WO_CN = e.WO_CN,
        WO_ScorType = e.WO_ScorType,
        WO_Scor = e.WO_Scor,
        WO_ScorDeep = e.WO_ScorDeep,
        WO_OrderNo_D = e.WO_OrderNo_D,
        WO_CustName_D = e.WO_CustName_D,
        WO_CutWidth_D = e.WO_CutWidth_D,
        WO_CutLength_D = e.WO_CutLength_D,
        WO_CutQty_D = e.WO_CutQty_D,
        WO_SortSN = e.WO_SortSN ?? 0,
        IndexNo = e.IndexNo ?? 0,
        WO_Remark = e.WO_Remark,
        Status = e.WO_StartTime is null ? "待生产" : (e.WO_Stop ? "暂停" : "生产中"),
    };

    private static FinishedOrderDto ToFinishedDto(W_OrderFinishs e) => new()
    {
        WOF_ID = e.WOF_ID,
        WO_ID = e.WO_ID,
        WOF_WorkNo = e.WOF_WorkNo,
        WOF_ClassNo = e.WOF_ClassNo,
        WOF_PaperCode = e.WOF_PaperCode,
        WOF_Wave = e.WOF_Wave,
        WOF_Floor = e.WOF_Floor,
        WOF_Width = e.WOF_Width,
        WOF_Speed = e.WOF_Speed,
        WOF_AvgSpeed = e.WOF_AvgSpeed,
        WOF_StopNum = e.WOF_StopNum,
        WOF_StopTime = e.WOF_StopTime,
        WOF_StartTime = e.WOF_StartTime,
        WOF_FinishTime = e.WOF_FinishTime,
        WOF_OrderNo = e.WOF_OrderNo,
        WOF_CustName = e.WOF_CustName,
        WOF_CutQty = e.WOF_CutQty,
        WOF_OrderMeter = e.WOF_OrderMeter,
    };
}
