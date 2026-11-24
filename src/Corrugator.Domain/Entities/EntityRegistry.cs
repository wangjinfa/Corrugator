using System.Reflection;

namespace Corrugator.Domain.Entities;

/// <summary>所有 SqlSugar 实体的注册表，供 CodeFirst.InitTables 建表</summary>
public static class EntityRegistry
{
    private const string BaseAuthNamespace = "Corrugator.Domain.Entities.BaseAuth";

    private static List<Type>? _cache;

    private static List<Type> Scan() => typeof(EntityRegistry).Assembly.GetTypes()
        .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<SqlSugar.SugarTable>() != null)
        .OrderBy(t => t.Name)
        .ToList();

    /// <summary>各瓦线业务库的表（155 张 IPS 表 + 手写系统表），不含 BaseDB 公共权限表</summary>
    public static IReadOnlyList<Type> All
    {
        get
        {
            _cache ??= Scan().Where(t => t.Namespace != BaseAuthNamespace).ToList();
            return _cache;
        }
    }

    /// <summary>BaseDB 公共表（账号/角色/权限），只在公共库建一次，不复制到各瓦线库</summary>
    public static IReadOnlyList<Type> BaseAuth => Scan()
        .Where(t => t.Namespace == BaseAuthNamespace)
        .ToList();
}
