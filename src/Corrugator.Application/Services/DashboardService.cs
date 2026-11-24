using Corrugator.Application.Abstractions;
using Corrugator.Domain.Entities.Dictionary;
using Corrugator.Domain.Entities.Production;
using Corrugator.Shared.Contracts.Dashboard;
using Corrugator.Shared.Contracts.Dictionary;

namespace Corrugator.Application.Services;

/// <summary>生管看板：跨表聚合在应用层完成，避免在仓储层写死复杂 SQL</summary>
public class DashboardService : IDashboardService
{
    private readonly IRepository<W_Orders> _orders;
    private readonly IRepository<W_OrderFinishs> _finished;
    private readonly IRepository<W_Alarms> _alarms;

    public DashboardService(
        IRepository<W_Orders> orders,
        IRepository<W_OrderFinishs> finished,
        IRepository<W_Alarms> alarms)
    {
        _orders = orders;
        _finished = finished;
        _alarms = alarms;
    }

    public async Task<DashboardOverviewDto> GetOverviewAsync()
    {
        var today = DateTime.Today;
        var tomorrow = today.AddDays(1);

        var active = await _orders.CountAsync(it => it.WO_IsDel == null || it.WO_IsDel == false);
        var urgent = await _orders.CountAsync(it =>
            (it.WO_IsDel == null || it.WO_IsDel == false) && it.WO_IsUrgent);

        var finishedToday = await _finished.ListAsync(
            it => it.WOF_FinishTime != null && it.WOF_FinishTime >= today && it.WOF_FinishTime < tomorrow,
            "WOF_FinishTime DESC");

        var unconfirmed = await _alarms.CountAsync(it => it.WA_IsConfirm != true);

        var recent = await _orders.ListAsync(
            it => it.WO_IsDel == null || it.WO_IsDel == false,
            "WO_SortSN ASC, WO_ID ASC", 10);

        var meters = finishedToday.Sum(x => x.WOF_OrderMeter ?? 0m);
        var avgSpeedList = finishedToday.Where(x => x.WOF_AvgSpeed is > 0).Select(x => x.WOF_AvgSpeed!.Value).ToList();
        var avgSpeed = avgSpeedList.Count == 0 ? 0 : avgSpeedList.Average();

        return new DashboardOverviewDto
        {
            ActiveOrders = active,
            UrgentOrders = urgent,
            FinishedToday = finishedToday.Count,
            FinishedMeterToday = meters,
            AvgSpeedToday = Math.Round(avgSpeed, 2),
            UnconfirmedAlarms = unconfirmed,
            RecentOrders = recent.Select(o => new DashboardOrderRow
            {
                WO_ID = o.WO_ID,
                WO_WorkNo = o.WO_WorkNo,
                WO_PaperCode = o.WO_PaperCode,
                WO_Wave = o.WO_Wave,
                WO_Width = o.WO_Width,
                WO_CutLength = o.WO_CutLength,
                WO_CutQty = o.WO_CutQty,
                WO_IsUrgent = o.WO_IsUrgent,
                WO_CustName = o.WO_CustName,
                WO_EstFinshTime = o.WO_EstFinshTime,
            }).ToList(),
        };
    }
}

/// <summary>数据字典服务：P_DictTypes / P_DictDatas</summary>
public class DictionaryService : IDictionaryService
{
    private readonly IRepository<P_DictTypes> _types;
    private readonly IRepository<P_DictDatas> _datas;

    public DictionaryService(IRepository<P_DictTypes> types, IRepository<P_DictDatas> datas)
    {
        _types = types;
        _datas = datas;
    }

    public async Task<List<DictTypeDto>> GetTypesAsync()
    {
        var list = await _types.ListAsync(null, "PD_ID ASC");
        return list.Select(t => new DictTypeDto
        {
            PD_ID = t.PD_ID,
            PD_PID = t.PD_PID,
            PD_Name = t.PD_Name,
            PD_Code = t.PD_Code,
            PD_Creator = t.PD_Creator,
            PD_CreateTime = t.PD_CreateTime,
            PD_Editor = t.PD_Editor,
            PD_EditTime = t.PD_EditTime,
        }).ToList();
    }

    public async Task<List<DictDataDto>> GetDatasAsync(int typeId)
    {
        var list = await _datas.ListAsync(it => it.PD_TypeID == typeId, "PD_SortNo ASC, PD_ID ASC");
        return list.Select(d => new DictDataDto
        {
            PD_ID = d.PD_ID,
            PD_TypeID = d.PD_TypeID,
            PD_Property = d.PD_Property,
            PD_EnglishName = d.PD_EnglishName,
            PD_Value = d.PD_Value,
            PD_ChineseName = d.PD_ChineseName,
            PD_SortNo = d.PD_SortNo,
            PD_Creator = d.PD_Ctreator,
            PD_CreateTime = d.PD_CreateTime,
            PD_Editor = d.PD_Editor,
            PD_EditTime = d.PD_EditTime,
        }).ToList();
    }

    public async Task<DictTypeDto> CreateTypeAsync(DictTypeSaveRequest request, string? user)
    {
        var entity = new P_DictTypes
        {
            PD_PID = request.PD_PID,
            PD_Name = request.PD_Name?.Trim(),
            PD_Code = request.PD_Code?.Trim(),
            PD_Creator = string.IsNullOrWhiteSpace(user) ? "system" : user,
            PD_CreateTime = DateTime.Now,
        };

        await _types.InsertAsync(entity);
        return ToTypeDto(entity);
    }

    public async Task<DictTypeDto?> UpdateTypeAsync(int id, DictTypeSaveRequest request, string? user)
    {
        var entity = await _types.GetByIdAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.PD_PID = request.PD_PID;
        entity.PD_Name = request.PD_Name?.Trim();
        entity.PD_Code = request.PD_Code?.Trim();
        entity.PD_Editor = user;
        entity.PD_EditTime = DateTime.Now;

        await _types.UpdateAsync(entity);
        return ToTypeDto(entity);
    }

    public async Task<string?> DeleteTypeAsync(int id)
    {
        var children = await _types.CountAsync(t => t.PD_PID == id);
        if (children > 0)
        {
            return "该分类下还有子分类，请先删除子分类";
        }

        var datas = await _datas.CountAsync(d => d.PD_TypeID == id);
        if (datas > 0)
        {
            return "该分类下还有字典明细，请先删除明细";
        }

        await _types.DeleteAsync(id);
        return null;
    }

    public async Task<DictDataDto> CreateDataAsync(DictDataSaveRequest request, string? user)
    {
        var entity = new P_DictDatas
        {
            PD_TypeID = request.PD_TypeID,
            PD_Value = request.PD_Value,
            PD_EnglishName = request.PD_EnglishName,
            PD_ChineseName = request.PD_ChineseName,
            PD_Property = request.PD_Property,
            PD_SortNo = request.PD_SortNo ?? 0,
            PD_Ctreator = string.IsNullOrWhiteSpace(user) ? "system" : user,
            PD_CreateTime = DateTime.Now,
        };

        await _datas.InsertAsync(entity);
        return ToDataDto(entity);
    }

    public async Task<DictDataDto?> UpdateDataAsync(int id, DictDataSaveRequest request, string? user)
    {
        var entity = await _datas.GetByIdAsync(id);
        if (entity is null)
        {
            return null;
        }

        entity.PD_Value = request.PD_Value;
        entity.PD_EnglishName = request.PD_EnglishName;
        entity.PD_ChineseName = request.PD_ChineseName;
        entity.PD_Property = request.PD_Property;
        entity.PD_SortNo = request.PD_SortNo;
        entity.PD_Editor = user;
        entity.PD_EditTime = DateTime.Now;

        await _datas.UpdateAsync(entity);
        return ToDataDto(entity);
    }

    public async Task<bool> DeleteDataAsync(int id)
    {
        var entity = await _datas.GetByIdAsync(id);
        if (entity is null)
        {
            return false;
        }

        await _datas.DeleteAsync(id);
        return true;
    }

    private static DictTypeDto ToTypeDto(P_DictTypes t) => new()
    {
        PD_ID = t.PD_ID,
        PD_PID = t.PD_PID,
        PD_Name = t.PD_Name,
        PD_Code = t.PD_Code,
        PD_Creator = t.PD_Creator,
        PD_CreateTime = t.PD_CreateTime,
        PD_Editor = t.PD_Editor,
        PD_EditTime = t.PD_EditTime,
    };

    private static DictDataDto ToDataDto(P_DictDatas d) => new()
    {
        PD_ID = d.PD_ID,
        PD_TypeID = d.PD_TypeID,
        PD_Property = d.PD_Property,
        PD_EnglishName = d.PD_EnglishName,
        PD_Value = d.PD_Value,
        PD_ChineseName = d.PD_ChineseName,
        PD_SortNo = d.PD_SortNo,
        PD_Creator = d.PD_Ctreator,
        PD_CreateTime = d.PD_CreateTime,
        PD_Editor = d.PD_Editor,
        PD_EditTime = d.PD_EditTime,
    };
}
