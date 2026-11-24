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

/// <summary>数据字典服务：W_DictTypes / W_DictDatas</summary>
public class DictionaryService : IDictionaryService
{
    private readonly IRepository<W_DictTypes> _types;
    private readonly IRepository<W_DictDatas> _datas;

    public DictionaryService(IRepository<W_DictTypes> types, IRepository<W_DictDatas> datas)
    {
        _types = types;
        _datas = datas;
    }

    public async Task<List<DictTypeDto>> GetTypesAsync()
    {
        var list = await _types.ListAsync(null, "WPD_ID ASC");
        return list.Select(t => new DictTypeDto
        {
            WPD_ID = t.WPD_ID,
            WPD_PID = t.WPD_PID,
            WPD_Name = t.WPD_Name,
            WPD_Code = t.WPD_Code,
            WPD_Creator = t.WPD_Creator,
            WPD_CreateTime = t.WPD_CreateTime,
            WPD_Editor = t.WPD_Editor,
            WPD_EditTime = t.WPD_EditTime,
        }).ToList();
    }

    public async Task<List<DictDataDto>> GetDatasAsync(int typeId)
    {
        var list = await _datas.ListAsync(it => it.WPD_TypeID == typeId, "WPD_SortNo ASC, WPD_ID ASC");
        return list.Select(d => new DictDataDto
        {
            WPD_ID = d.WPD_ID,
            WPD_TypeID = d.WPD_TypeID,
            WPD_Property = d.WPD_Property,
            WPD_EnglishName = d.WPD_EnglishName,
            WPD_Value = d.WPD_Value,
            WPD_ChineseName = d.WPD_ChineseName,
            WPD_SortNo = d.WPD_SortNo,
            WPD_Creator = d.WPD_Ctreator,
            WPD_CreateTime = d.WPD_CreateTime,
            WPD_Editor = d.WPD_Editor,
            WPD_EditTime = d.WPD_EditTime,
        }).ToList();
    }

    public async Task<DictTypeDto> CreateTypeAsync(DictTypeSaveRequest request, string? user)
    {
        var entity = new W_DictTypes
        {
            WPD_PID = request.WPD_PID,
            WPD_Name = request.WPD_Name?.Trim(),
            WPD_Code = request.WPD_Code?.Trim(),
            WPD_Creator = string.IsNullOrWhiteSpace(user) ? "system" : user,
            WPD_CreateTime = DateTime.Now,
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

        entity.WPD_PID = request.WPD_PID;
        entity.WPD_Name = request.WPD_Name?.Trim();
        entity.WPD_Code = request.WPD_Code?.Trim();
        entity.WPD_Editor = user;
        entity.WPD_EditTime = DateTime.Now;

        await _types.UpdateAsync(entity);
        return ToTypeDto(entity);
    }

    public async Task<string?> DeleteTypeAsync(int id)
    {
        var children = await _types.CountAsync(t => t.WPD_PID == id);
        if (children > 0)
        {
            return "该分类下还有子分类，请先删除子分类";
        }

        var datas = await _datas.CountAsync(d => d.WPD_TypeID == id);
        if (datas > 0)
        {
            return "该分类下还有字典明细，请先删除明细";
        }

        await _types.DeleteAsync(id);
        return null;
    }

    public async Task<DictDataDto> CreateDataAsync(DictDataSaveRequest request, string? user)
    {
        var entity = new W_DictDatas
        {
            WPD_TypeID = request.WPD_TypeID,
            WPD_Value = request.WPD_Value,
            WPD_EnglishName = request.WPD_EnglishName,
            WPD_ChineseName = request.WPD_ChineseName,
            WPD_Property = request.WPD_Property,
            WPD_SortNo = request.WPD_SortNo ?? 0,
            WPD_Ctreator = string.IsNullOrWhiteSpace(user) ? "system" : user,
            WPD_CreateTime = DateTime.Now,
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

        entity.WPD_Value = request.WPD_Value;
        entity.WPD_EnglishName = request.WPD_EnglishName;
        entity.WPD_ChineseName = request.WPD_ChineseName;
        entity.WPD_Property = request.WPD_Property;
        entity.WPD_SortNo = request.WPD_SortNo;
        entity.WPD_Editor = user;
        entity.WPD_EditTime = DateTime.Now;

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

    private static DictTypeDto ToTypeDto(W_DictTypes t) => new()
    {
        WPD_ID = t.WPD_ID,
        WPD_PID = t.WPD_PID,
        WPD_Name = t.WPD_Name,
        WPD_Code = t.WPD_Code,
        WPD_Creator = t.WPD_Creator,
        WPD_CreateTime = t.WPD_CreateTime,
        WPD_Editor = t.WPD_Editor,
        WPD_EditTime = t.WPD_EditTime,
    };

    private static DictDataDto ToDataDto(W_DictDatas d) => new()
    {
        WPD_ID = d.WPD_ID,
        WPD_TypeID = d.WPD_TypeID,
        WPD_Property = d.WPD_Property,
        WPD_EnglishName = d.WPD_EnglishName,
        WPD_Value = d.WPD_Value,
        WPD_ChineseName = d.WPD_ChineseName,
        WPD_SortNo = d.WPD_SortNo,
        WPD_Creator = d.WPD_Ctreator,
        WPD_CreateTime = d.WPD_CreateTime,
        WPD_Editor = d.WPD_Editor,
        WPD_EditTime = d.WPD_EditTime,
    };
}
