using Corrugator.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Corrugator.Application;

public static class DependencyInjection
{
    /// <summary>注册应用层服务（业务逻辑全部在这里，API 层只做协议转换）</summary>
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IOrderService, OrderService>();
        services.AddScoped<IProcessParamService, ProcessParamService>();
        services.AddScoped<IAlarmService, AlarmService>();
        services.AddScoped<IDashboardService, DashboardService>();
        services.AddScoped<IDictionaryService, DictionaryService>();
        services.AddScoped<IAuthService, AuthService>();
        return services;
    }
}
