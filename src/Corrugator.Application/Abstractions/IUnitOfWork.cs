namespace Corrugator.Application.Abstractions;

/// <summary>
/// 工作单元：把多个仓储操作放进同一个数据库事务。
/// 支持嵌套调用，只有最外层真正提交/回滚。
/// </summary>
public interface IUnitOfWork
{
    Task<T> ExecuteAsync<T>(Func<Task<T>> action);

    Task ExecuteAsync(Func<Task> action);
}

/// <summary>当前登录用户上下文，供审计字段填充、日志记录使用</summary>
public interface IUserContext
{
    string? UserName { get; }
    string? Ip { get; }
    bool IsAuthenticated { get; }
}
