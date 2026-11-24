#!/usr/bin/env python3
"""解析 BaseDB 数据字典 PDF -> schema_basedb.json + SQL Server 建表脚本

BaseDB 与 IPS 是两个库：BaseDB 是用户/角色/权限/瓦线配置/日志等基础库（12 表 + 1 函数）。
版面为 Navicat 生成的「位置 / 名称 / 类型 / Not Null / 其它」五列，按内容流顺序还原。
类型映射沿用 IPS 脚本：varchar->nvarchar、text->nvarchar(max)、int4->int、int8->bigint、
bool->bit、timestamp(6)->datetime2、nextval -> IDENTITY(1,1) 并作为主键。
"""
import json
import re

import pymupdf

PDF = "/home/user/Doubao/chats/38453480137175554/DataDictionary_new.pdf"
OUT_JSON = "/home/user/Doubao/chats/38453480137175554/tools/schema_basedb.json"
OUT_SQL = "/home/user/Doubao/chats/38453480137175554/db/sqlserver_basedb_schema.sql"

HEAD = re.compile(r"^\d+\.\d+\.\d+\.\d+\.\d+\.\s*表:\s*([A-Za-z0-9_]+)\s*$")
TYPES = {
    "varchar", "nvarchar", "char", "bpchar", "text", "int2", "int4", "int8", "serial",
    "bigserial", "bool", "timestamp", "timestamptz", "date", "time", "numeric", "decimal",
    "float4", "float8", "money", "uuid", "jsonb", "json", "bytea",
}
TYPE_RE = re.compile(r"^([a-z][a-z0-9_]*)(\((\d+)(?:\s*,\s*(\d+))?\))?$")


def is_type(line: str) -> bool:
    m = TYPE_RE.match(line.replace(" ", ""))
    return bool(m) and m.group(1) in TYPES


def load_lines(pdf: str) -> list[str]:
    doc = pymupdf.open(pdf)
    out: list[str] = []
    for page in doc:
        pl = [l.strip() for l in page.get_text("text").split("\n")]
        # 去掉页眉「服务器: ...」「BaseDB」与页码
        while pl and (pl[0].startswith("服务器:") or pl[0] == "BaseDB"):
            pl.pop(0)
        if pl and re.fullmatch(r"\d+", pl[0]):
            pl.pop(0)
        out.extend(l for l in pl if l)
    # 跳过封面与目录：从「列出的数据库对象」之后开始解析（目录里也有 “表: xxx” 行）
    anchor = max(i for i, l in enumerate(out) if "列出的数据库对象" in l) if any("列出的数据库对象" in l for l in out) else 0
    return out[anchor + 1:]


def parse(lines: list[str]) -> list[dict]:
    tables: list[dict] = []
    i, n = 0, len(lines)
    while i < n:
        m = HEAD.match(lines[i])
        if not m:
            i += 1
            continue

        name = m.group(1)
        i += 1
        comment = ""
        if i < n and lines[i] not in ("字段",) and not HEAD.match(lines[i]):
            comment = lines[i].strip().rstrip(",").strip()
            i += 1

        table = {"name": name, "comment": comment, "columns": []}
        while i < n and lines[i] in ("字段", "位置", "名称", "类型", "Not Null", "其它"):
            i += 1

        expected = 1
        while i < n:
            line = lines[i]
            if HEAD.match(line) or "函数:" in line:
                break
            if not re.fullmatch(r"\d+", line):
                i += 1
                continue
            if int(line) != expected:  # 页码等噪声
                i += 1
                continue
            i += 1
            if i >= n or not re.fullmatch(r"[A-Za-z0-9_]+", lines[i]):
                continue
            col = {"name": lines[i], "comment": "", "type": "", "notnull": False, "identity": False}
            i += 1

            # 可选中文注释（不是类型、不是勾选标记、不是默认值）
            if i < n and not is_type(lines[i]) and lines[i] != "✓" and not lines[i].startswith("默认:"):
                if re.fullmatch(r"[A-Za-z0-9_]+", lines[i]) is None:
                    col["comment"] = lines[i].strip().rstrip(",").strip()
                    i += 1

            if i < n and is_type(lines[i]):
                col["type"] = lines[i].replace(" ", "")
                i += 1

            if i < n and lines[i] == "✓":
                col["notnull"] = True
                i += 1

            if i < n and lines[i].startswith("默认:"):
                j = i
                buf = ""
                while j < n and not re.fullmatch(r"\d+", lines[j]) and not HEAD.match(lines[j]):
                    buf += lines[j]
                    j += 1
                if "nextval" in buf:
                    col["identity"] = True
                i = j

            table["columns"].append(col)
            expected += 1

        if table["columns"]:
            tables.append(table)
    return tables


MSSQL_TYPE_BASE = {
    "varchar": "nvarchar", "nvarchar": "nvarchar", "char": "nchar", "bpchar": "nchar",
    "text": "nvarchar(max)", "int2": "smallint", "int4": "int", "int8": "bigint",
    "serial": "int", "bigserial": "bigint", "bool": "bit", "timestamp": "datetime2",
    "timestamptz": "datetime2", "date": "date", "time": "time", "numeric": "decimal",
    "decimal": "decimal", "float4": "real", "float8": "float", "money": "money",
    "uuid": "uniqueidentifier", "jsonb": "nvarchar(max)", "json": "nvarchar(max)",
    "bytea": "varbinary(max)",
}


def to_mssql(col: dict) -> str:
    m = TYPE_RE.match(col["type"].replace(" ", ""))
    base = m.group(1) if m else "nvarchar"
    size1, size2 = (m.group(3), m.group(4)) if m else (None, None)

    sql = MSSQL_TYPE_BASE.get(base, "nvarchar")
    if sql == "nvarchar" and base == "varchar":
        sql = f"nvarchar({size1})" if size1 else "nvarchar(max)"
    elif sql == "nvarchar" and base == "nvarchar":
        sql = f"nvarchar({size1})" if size1 else "nvarchar(max)"
    elif sql in ("nchar",) and size1:
        sql = f"nchar({size1})"
    elif base == "numeric" and base != "decimal" or base == "decimal" and sql == "decimal":
        if size1 and size2:
            sql = f"decimal({size1},{size2})"
        elif size1:
            sql = f"decimal({size1},0)"
        else:
            sql = "decimal(18,4)"
    if col["identity"]:
        sql += " IDENTITY(1,1)"
    return sql


def generate_sql(tables: list[dict]) -> str:
    out = [
        "/* =====================================================================",
        "   BaseDB —— 基础库（用户/角色/权限/瓦线配置/日志）SQL Server 建表脚本",
        "   由 DataDictionary（原 PostgreSQL 15 / BaseDB 库，2026-11-13 导出）转换生成",
        "   类型映射：varchar->nvarchar、text->nvarchar(max)、int4->int、int8->bigint、",
        "            bool->bit、timestamp(6)->datetime2、nextval->IDENTITY(1,1)（并作为主键）",
        "   脚本幂等：表已存在则跳过",
        "   ===================================================================== */",
        "SET ANSI_NULLS ON;",
        "SET QUOTED_IDENTIFIER ON;",
        "GO",
        "",
    ]
    for t in tables:
        name = t["name"]
        pk = next((c["name"] for c in t["columns"] if c["identity"]), None)
        out.append(f"/* {t['comment'] or name} */" if t["comment"] else f"/* {name} */")
        out.append(f"IF OBJECT_ID(N'dbo.{name}', N'U') IS NULL")
        out.append("BEGIN")
        out.append(f"CREATE TABLE dbo.[{name}] (")
        lines = []
        for c in t["columns"]:
            seg = f"    [{c['name']}] {to_mssql(c)}"
            seg += " NOT NULL" if (c["notnull"] or c["identity"]) else " NULL"
            if c["comment"]:
                seg += f"  /* {c['comment']} */"
            lines.append(seg)
        if pk:
            lines.append(f"    CONSTRAINT [PK_{name}] PRIMARY KEY CLUSTERED ([{pk}] ASC)")
        out.append(",\n".join(lines))
        out.append(");")
        out.append("END")
        out.append("GO")
        out.append("")
    return "\n".join(out)


if __name__ == "__main__":
    lines = load_lines(PDF)
    tables = parse(lines)
    with open(OUT_JSON, "w", encoding="utf-8") as f:
        json.dump({"database": "BaseDB", "tables": tables}, f, ensure_ascii=False, indent=1)
    with open(OUT_SQL, "w", encoding="utf-8") as f:
        f.write(generate_sql(tables))

    print(f"tables={len(tables)} columns={sum(len(t['columns']) for t in tables)}")
    for t in tables:
        pk = next((c["name"] for c in t["columns"] if c["identity"]), "无")
        print(f"  {t['name']:<22} {len(t['columns']):>2} 字段  PK={pk}  {t['comment']}")
