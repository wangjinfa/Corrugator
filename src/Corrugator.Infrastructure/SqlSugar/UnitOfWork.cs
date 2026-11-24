using Corrugator.Application.Abstractions;
using SqlSugar;

namespace Corrugator.Infrastructure.SqlSugar;

/// <summary>
/// 工作单元：一次业务流程里多个仓储调用共用一个事务。
/// 使用 SqlSugar 的 BeginTran / CommitTran / RollbackTran，支持嵌套调用。
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly ILineDbAccess _access;
    private int _depth;

    public UnitOfWork(ILineDbAccess access)
    {
        _access = access;
    }

    private ISqlSugarClient _db => _access.Db;

    public async Task<T> ExecuteAsync<T>(Func<Task<T>> action)
    {
        if (_depth > 0)
        {
            return await action();
        }

        _depth++;
        _db.AsTenant().BeginTran();
        try
        {
            var result = await action();
            _db.AsTenant().CommitTran();
            return result;
        }
        catch
        {
            _db.AsTenant().RollbackTran();
            throw;
        }
        finally
        {
            _depth--;
        }
    }

    public async Task ExecuteAsync(Func<Task> action)
    {
        await ExecuteAsync(async () =>
        {
            await action();
            return true;
        });
    }
}

/// <summary>默认用户上下文（后台任务/单元测试用），API 层会替换为 HttpUserContext</summary>
public class NullUserContext : IUserContext
{
    public string? UserName => "system";
    public string? Ip => null;
    public bool IsAuthenticated => false;
}
