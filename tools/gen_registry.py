#!/usr/bin/env python3
"""生成实体注册表 EntityRegistry.cs —— 供 CodeFirst 一键建表使用"""
import os
import re

BASE = "/home/user/Doubao/chats/38453480137175554"
ENT = os.path.join(BASE, "src/Corrugator.Domain/Entities")
OUT = os.path.join(ENT, "EntityRegistry.cs")

entries = []
for root, dirs, files in os.walk(ENT):
    for f in sorted(files):
        if not f.endswith(".cs") or f == "EntityRegistry.cs":
            continue
        path = os.path.join(root, f)
        src = open(path, encoding="utf-8").read()
        ns = re.search(r"namespace ([A-Za-z0-9_.]+);", src)
        cls = re.search(r"public class ([A-Za-z0-9_]+)", src)
        if ns and cls:
            entries.append((ns.group(1), cls.group(1)))

entries.sort(key=lambda x: x[1])
lines = [
    "using System.Reflection;",
    "",
    "namespace Corrugator.Domain.Entities;",
    "",
    "/// <summary>所有 SqlSugar 实体的注册表，供 CodeFirst.InitTables 一次性建表</summary>",
    "public static class EntityRegistry",
    "{",
    "    private static List<Type>? _cache;",
    "",
    "    /// <summary>全部实体类型（含新增的系统表）</summary>",
    "    public static IReadOnlyList<Type> All",
    "    {",
    "        get",
    "        {",
    "            if (_cache is null)",
    "            {",
    "                _cache = typeof(EntityRegistry).Assembly.GetTypes()",
    "                    .Where(t => t.IsClass && !t.IsAbstract && t.GetCustomAttribute<SqlSugar.SugarTable>() != null)",
    "                    .OrderBy(t => t.Name)",
    "                    .ToList();",
    "            }",
    "",
    "            return _cache;",
    "        }",
    "    }",
    "}",
    "",
]
open(OUT, "w", encoding="utf-8").write("\n".join(lines))
print("entities registered:", len(entries))
print(entries[:5])
