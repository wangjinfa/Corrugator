using Corrugator.Application.Abstractions;
using Corrugator.Domain.Common;
using Corrugator.Shared.Api;
using SqlSugar;
using System.Linq.Expressions;
using System.Reflection;

namespace Corrugator.Infrastructure.SqlSugar;

/// <summary>
/// 通用仓储实现：155 张业务表全部复用这一份代码。
/// 统一处理：软删除过滤、审计字段、按主键增删改、分页与排序。
/// </summary>
public class BaseRepository<T> : IRepository<T> where T : class, new()
{
    private readonly ILineDbAccess _access;
    private readonly IUserContext _user;
    private EntityInfo? _entityCache;

    public BaseRepository(ILineDbAccess access, IUserContext user)
    {
        _access = access;
        _user = user;
    }

    /// <summary>当前请求所属瓦线库；多瓦线多库路由就落在这里</summary>
    private ISqlSugarClient _db => _access.Db;

    private EntityInfo _entity => _entityCache ??= _db.EntityMaintenance.GetEntityInfo<T>();

    private bool IsSoftDelete => typeof(ISoftDelete).IsAssignableFrom(typeof(T));

    private string PrimaryKeyColumn =>
        _entity.Columns.FirstOrDefault(c => c.IsPrimarykey)?.DbColumnName ?? "Id";

    private PropertyInfo? PrimaryKeyProperty =>
        _entity.Columns.FirstOrDefault(c => c.IsPrimarykey)?.PropertyInfo;

    /// <summary>对外的查询入口，已带上软删除过滤</summary>
    public ISugarQueryable<T> Queryable => WithSoftDeleteFilter(_db.Queryable<T>());

    private ISugarQueryable<T> WithSoftDeleteFilter(ISugarQueryable<T> query)
        => IsSoftDelete ? query.Where("IsDeleted = 0") : query;

    public async Task<T?> GetByIdAsync(object id)
    {
        return await WithSoftDeleteFilter(_db.Queryable<T>())
            .Where($"{PrimaryKeyColumn} = @id", new { id })
            .FirstAsync();
    }

    public async Task<T?> FirstAsync(Expression<Func<T, bool>> where)
    {
        return await WithSoftDeleteFilter(_db.Queryable<T>()).Where(where).FirstAsync();
    }

    public async Task<List<T>> ListAsync(
        Expression<Func<T, bool>>? where = null,
        string? orderBy = null,
        int? top = null)
    {
        var query = WithSoftDeleteFilter(_db.Queryable<T>());
        if (where is not null)
        {
            query = query.Where(where);
        }

        query = query.OrderBy(string.IsNullOrWhiteSpace(orderBy) ? $"{PrimaryKeyColumn} ASC" : orderBy);

        if (top is > 0)
        {
            query = query.Take(top.Value);
        }

        return await query.ToListAsync();
    }

    public async Task<PagedResult<T>> PageAsync(
        Expression<Func<T, bool>>? where,
        PageQuery page,
        string? defaultOrderBy = null)
    {
        var countQuery = WithSoftDeleteFilter(_db.Queryable<T>());
        var listQuery = WithSoftDeleteFilter(_db.Queryable<T>());

        if (where is not null)
        {
            countQuery = countQuery.Where(where);
            listQuery = listQuery.Where(where);
        }

        var total = await countQuery.CountAsync();

        var order = string.IsNullOrWhiteSpace(page.OrderBy)
            ? (string.IsNullOrWhiteSpace(defaultOrderBy) ? $"{PrimaryKeyColumn} DESC" : defaultOrderBy)
            : BuildOrderBy(page.OrderBy!, page.Desc);

        var items = total == 0
            ? new List<T>()
            : await listQuery.OrderBy(order).Skip(page.Skip).Take(page.PageSize).ToListAsync();

        return new PagedResult<T>(items, total, page.PageIndex, page.PageSize);
    }

    /// <summary>只允许实体上真实存在的列参与排序，避免前端传入任意 SQL 片段</summary>
    private string BuildOrderBy(string orderBy, bool desc)
    {
        var columns = _entity.Columns;
        var parts = orderBy.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        var valid = new List<string>();
        foreach (var part in parts)
        {
            var name = part.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
            var column = columns.FirstOrDefault(c =>
                string.Equals(c.PropertyName, name, StringComparison.OrdinalIgnoreCase)
                || string.Equals(c.DbColumnName, name, StringComparison.OrdinalIgnoreCase));

            if (column is not null)
            {
                valid.Add($"{column.DbColumnName} {(desc ? "DESC" : "ASC")}");
            }
        }

        return valid.Count > 0 ? string.Join(", ", valid) : $"{PrimaryKeyColumn} DESC";
    }

    public async Task<int> CountAsync(Expression<Func<T, bool>>? where = null)
    {
        var query = WithSoftDeleteFilter(_db.Queryable<T>());
        if (where is not null)
        {
            query = query.Where(where);
        }

        return await query.CountAsync();
    }

    public async Task<bool> ExistsAsync(Expression<Func<T, bool>> where)
    {
        return await CountAsync(where) > 0;
    }

    /// <summary>
    /// 插入并回填自增主键：业务层 new 完实体调用 Insert 后，能直接拿到数据库生成的 Id。
    /// （155 张表的自增主键都由数据字典里的 nextval 默认值推导而来，统一走这条路）
    /// </summary>
    public async Task<int> InsertAsync(T entity)
    {
        FillAudit(entity, isUpdate: false);

        var pk = PrimaryKeyProperty;
        if (pk is not null && pk.PropertyType != typeof(string) && IsIdentityKey())
        {
            var returned = await _db.Insertable(entity).ExecuteReturnEntityAsync();
            var newId = returned is null ? null : pk.GetValue(returned);
            if (newId is not null && pk.CanWrite)
            {
                pk.SetValue(entity, newId);
            }

            return newId is null ? 0 : 1;
        }

        return await _db.Insertable(entity).ExecuteCommandAsync();
    }

    private bool IsIdentityKey()
        => _entity.Columns.Any(c => c.IsPrimarykey && c.IsIdentity);

    public async Task<int> InsertRangeAsync(IEnumerable<T> entities)
    {
        var list = entities.ToList();
        foreach (var entity in list)
        {
            FillAudit(entity, isUpdate: false);
        }

        return await _db.Insertable(list).ExecuteCommandAsync();
    }

    public async Task<int> UpdateAsync(T entity)
    {
        FillAudit(entity, isUpdate: true);
        return await _db.Updateable(entity).ExecuteCommandAsync();
    }

    public async Task<int> UpdateRangeAsync(IEnumerable<T> entities)
    {
        var list = entities.ToList();
        foreach (var entity in list)
        {
            FillAudit(entity, isUpdate: true);
        }

        return await _db.Updateable(list).ExecuteCommandAsync();
    }

    public async Task<int> DeleteAsync(object id)
    {
        if (IsSoftDelete)
        {
            var entity = await GetByIdAsync(id);
            if (entity is null)
            {
                return 0;
            }

            ((ISoftDelete)entity).IsDeleted = true;
            FillAudit(entity, isUpdate: true);
            return await _db.Updateable(entity).ExecuteCommandAsync();
        }

        return id switch
        {
            int i => await _db.Deleteable<T>().In(i).ExecuteCommandAsync(),
            long l => await _db.Deleteable<T>().In(l).ExecuteCommandAsync(),
            string s => await _db.Deleteable<T>().In(s).ExecuteCommandAsync(),
            _ => await _db.Deleteable<T>().Where($"{PrimaryKeyColumn} = @id", new { id }).ExecuteCommandAsync(),
        };
    }

    public async Task<int> DeleteAsync(Expression<Func<T, bool>> where)
    {
        if (IsSoftDelete)
        {
            var rows = await WithSoftDeleteFilter(_db.Queryable<T>()).Where(where).ToListAsync();
            if (rows.Count == 0)
            {
                return 0;
            }

            foreach (var row in rows)
            {
                ((ISoftDelete)row).IsDeleted = true;
                FillAudit(row, isUpdate: true);
            }

            return await _db.Updateable(rows).ExecuteCommandAsync();
        }

        return await _db.Deleteable<T>().Where(where).ExecuteCommandAsync();
    }

    public async Task<int> SaveAsync(T entity)
    {
        var pkProperty = PrimaryKeyProperty;
        if (pkProperty is null)
        {
            return await InsertAsync(entity);
        }

        var value = pkProperty.GetValue(entity);
        var isDefault = value is null || value.Equals(Activator.CreateInstance(pkProperty.PropertyType));

        return isDefault ? await InsertAsync(entity) : await UpdateAsync(entity);
    }

    private void FillAudit(T entity, bool isUpdate)
    {
        if (entity is not IAuditable auditable)
        {
            return;
        }

        var now = DateTime.Now;
        if (isUpdate)
        {
            auditable.UpdatedAt = now;
            auditable.UpdatedBy = _user.UserName ?? "system";
        }
        else
        {
            auditable.CreatedAt = now;
            auditable.CreatedBy = _user.UserName ?? "system";
            auditable.UpdatedAt = now;
            auditable.UpdatedBy = _user.UserName ?? "system";
        }
    }
}
