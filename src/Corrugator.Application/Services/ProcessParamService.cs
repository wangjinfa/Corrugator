using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;
using Corrugator.Application.Abstractions;
using Corrugator.Application.Exceptions;
using Corrugator.Domain.Entities.MasterData;
using Corrugator.Domain.Entities.Process.Dry;
using Corrugator.Shared.Api;
using Corrugator.Shared.Contracts.Process;
using SqlSugar;

namespace Corrugator.Application.Services;

/// <summary>
/// 工艺参数服务。
/// W_QDM_FormSetFactor 是 192 列的宽表（糊机胶水/烘缸包角/预热缸/压力辊/喷雾/张力…系数），
/// 这里用“实体元数据 + 中文列说明”把宽表转成键值对，前端工艺参数界面只按 Key 读写，
/// 后续 IPS 增加系数列时前端无需改代码。
/// </summary>
public class ProcessParamService : IProcessParamService
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    private readonly IRepository<W_ProductWaves> _waves;
    private readonly IRepository<W_QDM_FormSetFactor> _factors;

    public ProcessParamService(IRepository<W_ProductWaves> waves, IRepository<W_QDM_FormSetFactor> factors)
    {
        _waves = waves;
        _factors = factors;
    }

    public async Task<PagedResult<WaveProfileDto>> GetWaveProfilesAsync(WaveQuery query)
    {
        var wave = query.Wave;
        var width = query.Width;
        var kw = query.Keyword;

        Expression<Func<W_ProductWaves, bool>> where = it =>
            (kw == null || (it.WSPW_Wave != null && it.WSPW_Wave.Contains(kw)))
            && (wave == null || it.WSPW_Wave == wave)
            && (width == null || it.WSPW_Width == width);

        var page = await _waves.PageAsync(where, query, "WSPW_Width ASC, WSPW_Wave ASC");
        var items = page.Items.Select(e => new WaveProfileDto
        {
            WSPW_ID = e.WSPW_ID,
            WSPW_Width = e.WSPW_Width,
            WSPW_Wave = e.WSPW_Wave ?? string.Empty,
            WSPW_WDeepSF1 = e.WSPW_WDeepSF1,
            WSPW_WRateSF1 = e.WSPW_WRateSF1,
            WSPW_WDeepSF2 = e.WSPW_WDeepSF2,
            WSPW_WRateSF2 = e.WSPW_WRateSF2,
            WSPW_WDeepSF3 = e.WSPW_WDeepSF3,
            WSPW_WRateSF3 = e.WSPW_WRateSF3,
            WSPW_PaperDeep = e.WSPW_PaperDeep,
            WSPW_MaxCN = e.WSPW_MaxCN,
            WSPW_MinCutLength = e.WSPW_MinCutLength,
            WSPW_MaxCutLength = e.WSPW_MaxCutLength,
            WSPW_MinEdge = e.WSPW_MinEdge,
            WSPW_MaxEdge = e.WSPW_MaxEdge,
            WSPW_SmallScor = e.WSPW_SmallScor,
            WSPW_SmallScorDepth = e.WSPW_SmallScorDepth,
            WSPW_FlatScorDepth = e.WSPW_FlatScorDepth,
            WSPW_ComScorDepth = e.WSPW_ComScorDepth,
        }).ToList();

        return new PagedResult<WaveProfileDto>(items, page.Total, page.PageIndex, page.PageSize);
    }

    public async Task<List<ProcessFactorItemDto>> GetFactorsAsync(string? keyword = null)
    {
        var row = await GetFactorRowAsync(createIfMissing: false);

        var list = new List<ProcessFactorItemDto>();
        foreach (var prop in Props())
        {
            var desc = ColumnDescription(prop);
            if (string.IsNullOrEmpty(desc))
            {
                // 没有中文说明的列（多为历史遗留）给出可读名称但仍可查询
                desc = prop.Name;
            }

            if (!string.IsNullOrEmpty(keyword)
                && !prop.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                && !desc.Contains(keyword, StringComparison.OrdinalIgnoreCase))
            {
                continue;
            }

            var value = row is null ? null : prop.GetValue(row);
            list.Add(new ProcessFactorItemDto
            {
                Key = prop.Name,
                Name = desc,
                Value = value is decimal d ? d : null,
                IsOpen = value is bool b ? b : null,
            });
        }

        return list;
    }

    public async Task<bool> UpdateFactorAsync(ProcessFactorUpdateDto input)
    {
        var row = await GetFactorRowAsync(createIfMissing: true);
        Apply(row!, input);
        await _factors.UpdateAsync(row!);
        return true;
    }

    public async Task<int> UpdateFactorsAsync(IReadOnlyList<ProcessFactorUpdateDto> inputs)
    {
        var row = await GetFactorRowAsync(createIfMissing: true);
        foreach (var item in inputs)
        {
            Apply(row!, item);
        }

        await _factors.UpdateAsync(row!);
        return inputs.Count;
    }

    private async Task<W_QDM_FormSetFactor?> GetFactorRowAsync(bool createIfMissing)
    {
        var list = await _factors.ListAsync(null, null, 1);
        if (list.Count > 0)
        {
            return list[0];
        }

        if (!createIfMissing)
        {
            return null;
        }

        var blank = new W_QDM_FormSetFactor();
        await _factors.InsertAsync(blank);
        return blank;
    }

    private static void Apply(W_QDM_FormSetFactor row, ProcessFactorUpdateDto input)
    {
        var prop = Props().FirstOrDefault(p => string.Equals(p.Name, input.Key, StringComparison.OrdinalIgnoreCase))
                   ?? throw new BusinessException($"工艺参数列 {input.Key} 不存在");

        if (input.Value is not null)
        {
            if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
            {
                prop.SetValue(row, input.Value);
            }
            else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
            {
                prop.SetValue(row, (int)Math.Round(input.Value.Value));
            }
            else if (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?))
            {
                prop.SetValue(row, input.Value != 0);
            }
            else
            {
                throw new BusinessException($"工艺参数列 {input.Key} 不支持数值赋值");
            }

            return;
        }

        if (input.IsOpen is not null && (prop.PropertyType == typeof(bool) || prop.PropertyType == typeof(bool?)))
        {
            prop.SetValue(row, input.IsOpen);
        }
    }

    private static PropertyInfo[] Props()
    {
        return PropertyCache.GetOrAdd(typeof(W_QDM_FormSetFactor), t =>
            t.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.GetCustomAttribute<SugarColumn>() is not null)
                .ToArray());
    }

    private static string? ColumnDescription(PropertyInfo prop)
    {
        var attr = prop.GetCustomAttribute<SugarColumn>();
        return attr?.ColumnDescription;
    }
}
