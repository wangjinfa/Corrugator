namespace Corrugator.Application.Exceptions;

/// <summary>可预期的业务异常（提示给用户，不记录堆栈）</summary>
public class BusinessException : Exception
{
    public int Code { get; }

    public BusinessException(string message, int code = 4001) : base(message)
    {
        Code = code;
    }
}

/// <summary>未认证 / 认证失效</summary>
public class UnauthorizedException : BusinessException
{
    public UnauthorizedException(string message = "用户名或密码错误") : base(message, 401)
    {
    }
}

/// <summary>资源不存在</summary>
public class NotFoundException : BusinessException
{
    public NotFoundException(string message = "数据不存在") : base(message, 404)
    {
    }
}
