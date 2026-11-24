namespace Corrugator.Shared.Api;

/// <summary>统一 API 返回结构（前端只需判断 code == 0）</summary>
public class ApiResult<T>
{
    public int Code { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public string? TraceId { get; set; }

    public bool Success => Code == 0;

    public static ApiResult<T> Ok(T data, string? message = null)
        => new() { Code = 0, Data = data, Message = message ?? "ok" };

    public static ApiResult<T> Fail(string message, int code = -1)
        => new() { Code = code, Message = message };

    public static ApiResult<T> Unauthorized(string message = "未登录或登录已过期")
        => new() { Code = 401, Message = message };
}

/// <summary>无数据的返回结构</summary>
public class ApiEmpty
{
}

/// <summary>分页结果</summary>
public class PagedResult<T>
{
    public int Total { get; set; }
    public int PageIndex { get; set; } = 1;
    public int PageSize { get; set; } = 20;
    public int Pages => PageSize <= 0 ? 0 : (Total + PageSize - 1) / PageSize;
    public List<T> Items { get; set; } = new();

    public PagedResult() { }

    public PagedResult(List<T> items, int total, int pageIndex, int pageSize)
    {
        Items = items;
        Total = total;
        PageIndex = pageIndex;
        PageSize = pageSize;
    }
}
