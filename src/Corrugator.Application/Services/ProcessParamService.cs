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
/// TB_QDM_FormSetFactor 是 192 列的宽表（糊机胶水/烘缸包角/预热缸/压力辊/喷雾/张力…系数），
/// 这里用“实体元数据 + 中文列说明”把宽表转成键值对，前端工艺参数界面只按 Key 读写，
/// 后续 IPS 增加系数列时前端无需改代码。
/// </summary>
public class ProcessParamService : IProcessParamService
{
    private static readonly ConcurrentDictionary<Type, PropertyInfo[]> PropertyCache = new();

    private readonly IRepository<S_ProductWaves> _waves;
    private readonly IRepository<TB_QDM_FormSetFactor> _factors;

    public ProcessParamService(IRepository<S_ProductWaves> waves, IRepository<TB_QDM_FormSetFactor> factors)
    {
        _waves = waves;
        _factors = factors;
    }

    public async Task<PagedResult<WaveProfileDto>> GetWaveProfilesAsync(WaveQuery query)
    {
        var wave = query.Wave;
        var width = query.Width;
        var kw = query.Keyword;

        Expression<Func<S_ProductWaves, bool>> where = it =>
            (kw == null || (it.SPW_Wave != null && it.SPW_Wave.Contains(kw)))
            && (wave == null || it.SPW_Wave == wave)
            && (width == null || it.SPW_Width == width);

        var page = await _waves.PageAsync(where, query, "SPW_Width ASC, SPW_Wave ASC");
        var items = page.Items.Select(e => new WaveProfileDto
        {
            SPW_ID = e.SPW_ID,
            SPW_Width = e.SPW_Width,
            SPW_Wave = e.SPW_Wave ?? string.Empty,
            SPW_WDeepSF1 = e.SPW_WDeepSF1,
            SPW_WRateSF1 = e.SPW_WRateSF1,
            SPW_WDeepSF2 = e.SPW_WDeepSF2,
            SPW_WRateSF2 = e.SPW_WRateSF2,
            SPW_WDeepSF3 = e.SPW_WDeepSF3,
            SPW_WRateSF3 = e.SPW_WRateSF3,
            SPW_PaperDeep = e.SPW_PaperDeep,
            SPW_MaxCN = e.SPW_MaxCN,
            SPW_MinCutLength = e.SPW_MinCutLength,
            SPW_MaxCutLength = e.SPW_MaxCutLength,
            SPW_MinEdge = e.SPW_MinEdge,
            SPW_MaxEdge = e.SPW_MaxEdge,
            SPW_SmallScor = e.SPW_SmallScor,
            SPW_SmallScorDepth = e.SPW_SmallScorDepth,
            SPW_FlatScorDepth = e.SPW_FlatScorDepth,
            SPW_ComScorDepth = e.SPW_ComScorDepth,
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

    private async Task<TB_QDM_FormSetFactor?> GetFactorRowAsync(bool createIfMissing)
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

        var blank = new TB_QDM_FormSetFactor();
        await _factors.InsertAsync(blank);
        return blank;
    }

    private static void Apply(TB_QDM_FormSetFactor row, ProcessFactorUpdateDto input)
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
        return PropertyCache.GetOrAdd(typeof(TB_QDM_FormSetFactor), t =>
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
