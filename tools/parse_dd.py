#!/usr/bin/env python3
"""解析 IPS 数据字典 PDF -> schema.json
关键点：PDF 存在“两个原始页叠加到同一页”的情况，因此必须按内容流(block)顺序解析，
不能用坐标排序。每个块独立还原字段行。
"""
import json
import re
import pymupdf

PDF = "/home/user/Doubao/chats/38453480137175554/DataDictionary.pdf"
HEAD = re.compile(r"^\d+\.\d+\.\d+\.\d+\.\d+\.\s*表:\s*([A-Za-z0-9_]+)", re.M)
HEAD_ANY = re.compile(r"表:\s*([A-Za-z0-9_]+)")
TYPE_RE = re.compile(
    r"^(?:varchar|nvarchar|char|bpchar|int4|int8|int2|serial|numeric|decimal|bool|"
    r"timestamp|timestamptz|date|time|text|float4|float8|money|uuid|jsonb?|bytea)"
)
SKIP = {"位置", "名称", "类型", "Not Null", "其它", "字段"}

doc = pymupdf.open(PDF)
tables = {}
order = []
cur = None
col = None
sec = "table"   # table / view / func
seen_heading = None


def new_table(name):
    global cur, col, seen_heading
    if name not in tables:
        tables[name] = {"name": name, "comment": "", "columns": []}
        order.append(name)
    cur = name
    col = None
    seen_heading = True


for page in doc:
    blocks = page.get_text("blocks")  # 内容流顺序
    for b in blocks:
        text = b[4]
        if not text:
            continue
        if text.startswith("服务器:") or re.match(r"^IPS\s*\n\d+\s*$", text):
            continue
        # 标题行
        lines = [l.strip() for l in text.split("\n") if l.strip()]
        if any(len(l) < 60 and HEAD_ANY.search(l) for l in lines):
            names = HEAD_ANY.findall(text)
            kind = "table"
            if "视图:" in text:
                kind = "view"
            elif "函数:" in text:
                kind = "func"
            if kind != "table":
                sec = "other"
                cur = None
                continue
            sec = "table"
            if len(names) > 1:
                # 叠加标题：取最后一个（视觉上后画的）
                new_table(names[-1])
            else:
                new_table(names[0])
            continue
        if sec != "table" or cur is None:
            continue
        # 表注释：紧跟标题、位于 x=53 的块
        if seen_heading and b[0] < 58 and not HEAD_ANY.search(text):
            if len(text.strip()) < 40 and text.strip() not in SKIP:
                # 表格注释只取首行，PDF 中常与“字段”标签合并成一块
                first = text.strip().split("\n")[0].strip()
                if first and first not in SKIP:
                    tables[cur]["comment"] = first
            seen_heading = False
            continue
        seen_heading = False
        for ln in lines:
            s = ln.strip()
            if not s or s in SKIP:
                continue
            if s.isdigit():
                col = {"pos": int(s), "name": "", "type": "", "notnull": False,
                       "pk": False, "comment": "", "default": ""}
                tables[cur]["columns"].append(col)
                continue
            if col is None:
                continue
            low = s.replace(" ", "")
            if TYPE_RE.match(low) and "(" not in s[:4]:
                if not col["type"]:
                    col["type"] = low
                continue
            if s == "✓":
                col["notnull"] = True
                continue
            if s.startswith("默认") or s.startswith("nextval") or s.startswith("'") or "::" in s:
                col["default"] += s
                continue
            if not col["name"] and re.fullmatch(r"[A-Za-z0-9_]+", s):
                col["name"] = s
            elif not col["comment"]:
                col["comment"] = s
            else:
                col["comment"] += s

for t in tables.values():
    for c in t["columns"]:
        if "主键" in c["comment"] or "PK" in c["default"]:
            c["pk"] = True

# ---------- 清洗：去掉空字段、修复被列宽折断的字段名 ----------
for t in tables.values():
    kept = []
    for c in t["columns"]:
        c["comment"] = re.sub(r"\s+", " ", c["comment"] or "").strip()
        if not c["name"] or not c["type"]:
            continue
        # 字段名被列宽截断，剩余片段落到了注释里（如 F_PreheaterSteam_GU_1st_Fo + rm_IsOpen）
        if len(c["name"]) >= 18 and c["comment"]:
            if re.fullmatch(r"[A-Za-z0-9_]+", c["comment"]) and (
                c["name"].endswith("_")
                or re.match(r"[a-z]", c["comment"])
                or (len(c["comment"]) <= 6 and len(c["name"]) >= 20)
            ):
                c["name"] += c["comment"]
                c["comment"] = ""
            else:
                m = re.match(r"([A-Za-z0-9_]+)([\u4e00-\u9fff].*)", c["comment"])
                if m and len(c["name"]) >= 18:
                    c["name"] += m.group(1)
                    c["comment"] = m.group(2)
        kept.append(c)
    t["columns"] = kept

with open("/home/user/Doubao/chats/38453480137175554/tools/schema.json", "w", encoding="utf-8") as f:
    json.dump({"tables": [tables[n] for n in order]}, f, ensure_ascii=False, indent=1)

bad = [n for n in order if not tables[n]["columns"]]
print("tables:", len(order), "| empty:", bad)
print("columns:", sum(len(tables[n]["columns"]) for n in order))
print("unnamed:", sum(1 for n in order for c in tables[n]["columns"] if not c["name"]))
print("types empty:", sum(1 for n in order for c in tables[n]["columns"] if not c["type"]))
