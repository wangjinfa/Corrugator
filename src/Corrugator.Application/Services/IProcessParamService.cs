using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Process;

namespace Corrugator.Application.Services;

public interface IProcessParamService
{
    /// <summary>产线楞型基础资料分页（S_ProductWaves）</summary>
    Task<PagedResult<WaveProfileDto>> GetWaveProfilesAsync(WaveQuery query);

    /// <summary>
    /// 当前运行工艺参数（TB_QDM_FormSetFactor）。
    /// 该表是 192 列的宽表，这里按“列名 + 中文说明 + 值”转成键值对返回，前端无需知道列结构。
    /// </summary>
    Task<List<ProcessFactorItemDto>> GetFactorsAsync(string? keyword = null);

    /// <summary>按列名修改单项工艺参数</summary>
    Task<bool> UpdateFactorAsync(ProcessFactorUpdateDto input);

    /// <summary>批量保存工艺参数</summary>
    Task<int> UpdateFactorsAsync(IReadOnlyList<ProcessFactorUpdateDto> inputs);
}
