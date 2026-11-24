using System.Linq.Expressions;
using Corrugator.Shared.Api;
using SqlSugar;

namespace Corrugator.Application.Abstractions;

/// <summary>
/// 通用仓储接口。所有业务表（IPS 155 张表）共用这一套实现，
/// 业务服务只依赖该接口，不直接使用 DbContext / SqlSugarClient。
/// </summary>
public interface IRepository<T> where T : class, new()
{
    /// <summary>复杂查询逃生门：需要多表联查/子查询时使用，仍受软删除过滤</summary>
    ISugarQueryable<T> Queryable { get; }

    Task<T?> GetByIdAsync(object id);

    Task<T?> FirstAsync(Expression<Func<T, bool>> where);

    Task<List<T>> ListAsync(Expression<Func<T, bool>>? where = null, string? orderBy = null, int? top = null);

    Task<PagedResult<T>> PageAsync(Expression<Func<T, bool>>? where, PageQuery page, string? defaultOrderBy = null);

    Task<int> CountAsync(Expression<Func<T, bool>>? where = null);

    Task<bool> ExistsAsync(Expression<Func<T, bool>> where);

    Task<int> InsertAsync(T entity);

    Task<int> InsertRangeAsync(IEnumerable<T> entities);

    Task<int> UpdateAsync(T entity);

    Task<int> UpdateRangeAsync(IEnumerable<T> entities);

    /// <summary>按主键删除；实现 ISoftDelete 的实体会转为逻辑删除</summary>
    Task<int> DeleteAsync(object id);

    Task<int> DeleteAsync(Expression<Func<T, bool>> where);

    /// <summary>主键存在则更新，否则新增</summary>
    Task<int> SaveAsync(T entity);
}
