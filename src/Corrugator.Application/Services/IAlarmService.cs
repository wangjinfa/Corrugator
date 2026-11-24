using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Alarms;
using Corrugator.Shared.Contracts.Dashboard;

namespace Corrugator.Application.Services;

public interface IAlarmService
{
    Task<PagedResult<AlarmDto>> GetPagedAsync(AlarmQuery query);

    /// <summary>确认告警</summary>
    Task<AlarmDto> ConfirmAsync(int id, AlarmConfirmInput input);
}

public interface IDashboardService
{
    Task<DashboardOverviewDto> GetOverviewAsync();
}

public interface IDictionaryService
{
    Task<List<Corrugator.Shared.Contracts.Dictionary.DictTypeDto>> GetTypesAsync();

    Task<List<Corrugator.Shared.Contracts.Dictionary.DictDataDto>> GetDatasAsync(int typeId);

    Task<Corrugator.Shared.Contracts.Dictionary.DictTypeDto> CreateTypeAsync(
        Corrugator.Shared.Contracts.Dictionary.DictTypeSaveRequest request, string? user);

    Task<Corrugator.Shared.Contracts.Dictionary.DictTypeDto?> UpdateTypeAsync(
        int id, Corrugator.Shared.Contracts.Dictionary.DictTypeSaveRequest request, string? user);

    /// <summary>删除分类；有子节点或有明细时返回拒绝原因</summary>
    Task<string?> DeleteTypeAsync(int id);

    Task<Corrugator.Shared.Contracts.Dictionary.DictDataDto> CreateDataAsync(
        Corrugator.Shared.Contracts.Dictionary.DictDataSaveRequest request, string? user);

    Task<Corrugator.Shared.Contracts.Dictionary.DictDataDto?> UpdateDataAsync(
        int id, Corrugator.Shared.Contracts.Dictionary.DictDataSaveRequest request, string? user);

    Task<bool> DeleteDataAsync(int id);
}
