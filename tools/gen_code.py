#!/usr/bin/env python3
"""由 schema.json 生成 SqlSugar 实体类与 SQL Server 建表脚本"""
import json
import os
import re

BASE = "/home/user/Doubao/chats/38453480137175554"
SCHEMA = os.path.join(BASE, "tools/schema.json")
ENT_DIR = os.path.join(BASE, "src/Corrugator.Domain/Entities")
SQL_OUT = os.path.join(BASE, "db/sqlserver_schema.sql")

MODULES = [
    ("E_", "Erp", "ERP 接口表"),
    ("L_", "Logging", "系统日志"),
    ("P_", "Dictionary", "字典与参数"),
    ("S_", "MasterData", "基础资料"),
    ("TB_IPS_", "Process/Wet", "湿部工艺参数"),
    ("TB_QDM_", "Process/Dry", "干部（QDM）工艺参数"),
    ("TB_Plc_", "Plc", "PLC 点位与设备参数"),
    ("TB_PMS_", "Pms", "生产管理 PMS"),
    ("TB_BDS_", "Bds", "BDS 设备参数"),
    ("TB_", "Process/Common", "工艺参数公共"),
    ("T_", "History", "历史与轨迹"),
    ("W_", "Production", "生产执行"),
    ("V_", "Views", "视图"),
]

TYPE_MAP = {
    "int4": "int",
    "int8": "bigint",
    "int2": "smallint",
    "bool": "bit",
    "timestamp": "datetime2",
    "date": "date",
    "time": "time",
    "text": "nvarchar(max)",
    "float8": "float",
    "float4": "real",
    "uuid": "uniqueidentifier",
    "bytea": "varbinary(max)",
    "json": "nvarchar(max)",
    "jsonb": "nvarchar(max)",
    "bpchar": "nvarchar",
    "char": "nvarchar",
    "varchar": "nvarchar",
    "nvarchar": "nvarchar",
}

CS_TYPE = {
    "int": "int",
    "bigint": "long",
    "smallint": "short",
    "bit": "bool",
    "datetime2": "DateTime",
    "date": "DateTime",
    "time": "TimeSpan",
    "nvarchar": "string",
    "nvarchar(max)": "string",
    "float": "double",
    "real": "float",
    "uniqueidentifier": "Guid",
    "varbinary(max)": "byte[]",
    "decimal": "decimal",
}


def parse_type(raw: str):
    """返回 (sql_type, cs_type, length, decimal_digits, is_string)"""
    raw = raw.strip().lower()
    m = re.match(r"^([a-z0-9]+)\s*(?:\(\s*([0-9]+)\s*(?:,\s*([0-9]+)\s*)?\))?", raw)
    if not m:
        return ("nvarchar(50)", "string", 50, 0, True)
    base, p1, p2 = m.group(1), m.group(2), m.group(3)
    if base == "numeric" or base == "decimal":
        precision = int(p1) if p1 else 18
        scale = int(p2) if p2 else (4 if not p2 else 0)
        if p1 and not p2:
            scale = 4 if precision >= 18 else 0
        if precision > 28:
            precision, scale = 28, min(scale, 6)
        return (f"decimal({precision},{scale})", "decimal", precision, scale, False)
    sql = TYPE_MAP.get(base, "nvarchar(50)")
    if sql in ("nvarchar", "nvarchar(max)"):
        if sql == "nvarchar(max)":
            return ("nvarchar(max)", "string", -1, 0, True)
        length = int(p1) if p1 else 50
        return (f"nvarchar({length})", "string", length, 0, True)
    cs = CS_TYPE.get(sql, "string")
    return (sql, cs, 0, 0, cs == "string")


def module_of(name: str):
    for prefix, folder, desc in MODULES:
        if name.startswith(prefix):
            return folder, desc
    return "Other", "其他"


def cs_literal(s: str) -> str:
    s = re.sub(r"\s+", " ", s or "").strip()
    s = s.replace("\\", "\\\\").replace('"', '\\"')
    return '"' + s + '"'


def gen_entity(t):
    name = t["name"]
    cols = t["columns"]
    t_comment = re.sub(r"\s+", " ", t["comment"] or name).strip() or name
    lines = []
    folder, desc = module_of(name)
    lines.append("using SqlSugar;")
    lines.append("")
    lines.append("namespace Corrugator.Domain.Entities." + folder.replace("/", ".") + ";")
    lines.append("")
    lines.append("/// <summary>")
    lines.append(f"/// {t_comment}")
    lines.append("/// </summary>")
    lines.append(f"""[SugarTable({cs_literal(name)}, TableDescription = {cs_literal(t_comment)})]""")
    lines.append(f"public class {name}")
    lines.append("{")
    for c in cols:
        sql_type, cs_type, length, scale, is_str = parse_type(c["type"])
        pk = "nextval" in c.get("default", "") or c.get("pk", False)
        attrs = [f"ColumnName = {cs_literal(c['name'])}"]
        if pk:
            attrs.append("IsPrimaryKey = true")
            if cs_type in ("int", "long"):
                attrs.append("IsIdentity = true")
        if is_str and length > 0:
            attrs.append(f"Length = {length}")
        if sql_type.startswith("decimal"):
            attrs.append(f"Length = {length}")
            attrs.append(f"DecimalDigits = {scale}")
        if not c["notnull"]:
            attrs.append("IsNullable = true")
        attrs.append(f"ColumnDescription = {cs_literal(c['comment'] or c['name'])}")
        if c.get("default") and "nextval" not in c["default"]:
            d = c["default"].replace("默认:", "").strip()
            if d and len(d) < 40:
                attrs.append(f"DefaultValue = {cs_literal(d)}")
        c_comment = re.sub(r"\s+", " ", c["comment"] or c["name"]).strip() or c["name"]
        lines.append("    /// <summary>" + c_comment + "</summary>")
        lines.append("    [SugarColumn(" + ", ".join(attrs) + ")]")
        cs = cs_type if c["notnull"] else cs_type + "?"
        if cs_type == "byte[]":
            cs = "byte[]"
        init = " = default!;" if (c["notnull"] and cs_type == "string") else ""
        lines.append(f"    public {cs} {c['name']} {{ get; set; }}{init}")
        lines.append("")
    lines.append("}")
    return folder, "\n".join(lines)


def gen_sql(tables):
    out = []
    out.append("/* =====================================================================")
    out.append("   IPS 瓦楞纸板生产线生管系统 —— SQL Server 建表脚本")
    out.append("   由 DataDictionary（原 PostgreSQL 15 / IPS 库）转换生成")
    out.append("   类型映射：varchar->nvarchar, int4->int, bool->bit, timestamp->datetime2,")
    out.append("            numeric(p[,s])->decimal(p,s)（未写精度的 numeric 统一按 decimal(18,4)）")
    out.append("   ===================================================================== */")
    out.append("SET ANSI_NULLS ON;")
    out.append("SET QUOTED_IDENTIFIER ON;")
    out.append("GO")
    out.append("")
    for t in tables:
        name = t["name"]
        cols = []
        for c in t["columns"]:
            sql_type, cs_type, length, scale, is_str = parse_type(c["type"])
            pk = "nextval" in c.get("default", "")
            part = f"    [{c['name']}] {sql_type}"
            if pk and cs_type in ("int", "long"):
                part += " IDENTITY(1,1)"
            part += " NULL" if not c["notnull"] and not pk else " NOT NULL"
            cols.append(part)
        pkcol = next((c["name"] for c in t["columns"] if "nextval" in c.get("default", "")), None)
        body = ",\n".join(cols)
        if pkcol:
            body += f",\n    CONSTRAINT [PK_{name}] PRIMARY KEY CLUSTERED ([{pkcol}] ASC)"
        cmt = (t["comment"] or name).replace("*/", "")
        out.append(f"/* {cmt} */")
        out.append(f"IF OBJECT_ID(N'dbo.{name}', N'U') IS NULL")
        out.append("BEGIN")
        out.append(f"CREATE TABLE dbo.[{name}] (")
        out.append(body)
        out.append(");")
        out.append("END")
        out.append("GO")
        out.append("")
    return "\n".join(out)


def main():
    schema = json.load(open(SCHEMA, encoding="utf-8"))["tables"]
    if os.path.isdir(ENT_DIR):
        import shutil
        # 只清理由脚本管理的模块目录，保留手写的 System 等目录
        for _prefix, _folder, _desc in MODULES:
            _d = os.path.join(ENT_DIR, _folder)
            if os.path.isdir(_d):
                shutil.rmtree(_d)
    os.makedirs(ENT_DIR, exist_ok=True)
    os.makedirs(os.path.dirname(SQL_OUT), exist_ok=True)
    count = 0
    for t in schema:
        folder, code = gen_entity(t)
        d = os.path.join(ENT_DIR, folder)
        os.makedirs(d, exist_ok=True)
        with open(os.path.join(d, t["name"] + ".cs"), "w", encoding="utf-8") as f:
            f.write(code)
        count += 1
    with open(SQL_OUT, "w", encoding="utf-8") as f:
        f.write(gen_sql(schema))
    print("entities:", count, "| sql lines:", len(open(SQL_OUT, encoding="utf-8").read().splitlines()))


if __name__ == "__main__":
    main()
