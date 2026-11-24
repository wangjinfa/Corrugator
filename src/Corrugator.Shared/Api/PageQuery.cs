namespace Corrugator.Shared.Api;

/// <summary>通用分页/排序查询基类</summary>
public class PageQuery
{
    private int _pageSize = 20;

    public int PageIndex { get; set; } = 1;

    /// <summary>每页条数，最大 200</summary>
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value is <= 0 or > 200 ? 20 : value;
    }

    /// <summary>关键字（模糊匹配，具体字段由各业务实现决定）</summary>
    public string? Keyword { get; set; }

    /// <summary>排序字段（实体列名，空则按主键倒序）</summary>
    public string? OrderBy { get; set; }

    public bool Desc { get; set; } = true;

    public int Skip => (Math.Max(PageIndex, 1) - 1) * PageSize;
}
