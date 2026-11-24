#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
实体表名 / 列名 / C# 属性名统一加 W 前缀。
规则（与用户确认）：
1. 表名：统一 W_ 前缀，去掉旧前缀；已 W_ 开头的保持不变；冲突表名单独映射。
2. 列名与 C# 属性名一起改；显式 ColumnName 与属性名同步。
3. 覆盖 Domain 下全部实体。
- 带前缀（含下划线）的字段：全局联动替换（控制器/服务/VM/契约/SQL）。
- 裸命名（无下划线）字段：仅在实体文件内改名，避免误伤外部同名标识符。
"""
import os, re, glob, sys, collections

ROOT = os.path.dirname(os.path.dirname(os.path.abspath(__file__)))
ENT = os.path.join(ROOT, "src", "Corrugator.Domain", "Entities")

# 表名冲突单独处理（转换后重名）
TABLE_OVERRIDE = {
    "Sys_Users": "W_Sys_Users",   # 与 S_Users 转换后的 W_Users 区分
    "E_Orders": "W_E_Orders",      # 与 Production.W_Orders 区分
}

def new_table(old: str) -> str:
    if old in TABLE_OVERRIDE:
        return TABLE_OVERRIDE[old]
    if old.startswith("W_"):
        return old
    parts = old.split("_", 1)
    return "W_" + (parts[1] if len(parts) > 1 else parts[0])

def w_col(col: str) -> str:
    """列名加 W：已以 W 开头（后跟大写/数字）保持原样，否则前面补 W。"""
    if col.startswith("W") and len(col) > 1 and (col[1].isupper() or col[1].isdigit()):
        return col
    return "W" + col

# ---------- 解析实体 ----------
prop_re = re.compile(
    r"(?P<attr>\[SugarColumn\([^\]]*\)\]\s*\r?\n\s*)"
    r"public\s+(?P<type>[\w?.<>,\s]+?)\s+(?P<name>\w+)\s*\{\s*get;\s*set;\s*\}",
    re.MULTILINE)
col_re = re.compile(r'ColumnName\s*=\s*"([^"]+)"')
table_re = re.compile(r'SugarTable\("([^"]+)"')

global_map = {}        # 旧列名 -> 新列名（带下划线，可全局替换）
bare_map = {}          # 旧裸名 -> 新裸名（仅实体内部）
table_map = {}
changed_files = []

entity_files = glob.glob(os.path.join(ENT, "**", "*.cs"), recursive=True)
for f in entity_files:
    text = open(f, encoding="utf-8").read()
    m = table_re.search(text)
    if not m:
        continue
    old_table = m.group(1)
    nt = new_table(old_table)
    if nt != old_table:
        table_map[old_table] = nt
        text = text.replace(f'SugarTable("{old_table}"', f'SugarTable("{nt}"', 1)

    def repl(mo):
        attr = mo.group("attr"); typ = mo.group("type"); name = mo.group("name")
        cm = col_re.search(attr)
        if cm:
            oldcol = cm.group(1)
            newcol = w_col(oldcol)
            if oldcol != newcol:
                attr = attr.replace(f'ColumnName = "{oldcol}"', f'ColumnName = "{newcol}"')
                if "_" in oldcol:
                    global_map[oldcol] = newcol
                else:
                    bare_map[oldcol] = newcol
            # 属性名与列名保持一致
            newname = newcol if name == oldcol else name
            if name != newname:
                if "_" in name:
                    global_map[name] = newname
                else:
                    bare_map[name] = newname
            return f"{attr}public {typ} {newname} {{ get; set; }}"
        else:
            # 无显式 ColumnName：属性名即列名
            newname = w_col(name)
            if name != newname:
                if "_" in name:
                    global_map[name] = newname
                else:
                    bare_map[name] = newname
            return f"{attr}public {typ} {newname} {{ get; set; }}"

    new_text = prop_re.sub(repl, text)
    if new_text != text:
        changed_files.append(f)
    open(f, "w", encoding="utf-8").write(new_text)

print(f"实体文件: {len(entity_files)}  改名实体: {len(changed_files)}")
print(f"表名映射: {len(table_map)}  全局字段: {len(global_map)}  裸字段: {len(bare_map)}")

# ---------- 全局替换（带前缀字段，每文件一次合并正则）----------
def code_files():
    skip = ("bin", "obj", ".tmp-tool-results")
    for base in ["src", "db", "tools", "tests"]:
        d = os.path.join(ROOT, base)
        if not os.path.isdir(d):
            continue
        for dp, dn, fn in os.walk(d):
            if any(s in dp.split(os.sep) for s in skip):
                continue
            for n in fn:
                if n.endswith((".cs", ".xaml", ".sql", ".ps1")):
                    yield os.path.join(dp, n)

# 长 token 优先，避免前缀嵌套
g_items = sorted(global_map.items(), key=lambda kv: len(kv[0]), reverse=True)
g_pat = re.compile(r'\b(?:' + '|'.join(re.escape(o) for o, _ in g_items) + r')\b')
g_lookup = dict(g_items)

t_items = sorted(table_map.items(), key=lambda kv: len(kv[0]), reverse=True)

for f in code_files():
    t = open(f, encoding="utf-8").read()
    orig = t
    if g_items:
        t = g_pat.sub(lambda m: g_lookup[m.group(0)], t)
    for old, new in t_items:
        if old in t:
            t = t.replace(old, new)
    if t != orig:
        open(f, "w", encoding="utf-8").write(t)

print("全局替换完成。")
print("表映射样例:", list(table_map.items())[:5])
print("裸字段(未全局):", bare_map)
