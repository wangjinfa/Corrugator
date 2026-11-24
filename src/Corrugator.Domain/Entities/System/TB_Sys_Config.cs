using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>系统运行参数（基础信息 → 系统设置），键值对形式存放</summary>
[SugarTable("W_Sys_Config", TableDescription = "系统运行参数表")]
public class W_Sys_Config
{
    [SugarColumn(ColumnName = "WF_Key", Length = 60, ColumnDescription = "参数键")]
    public string WF_Key { get; set; } = default!;

    [SugarColumn(ColumnName = "WF_Value", Length = 300, IsNullable = true, ColumnDescription = "参数值")]
    public string? WF_Value { get; set; }

    [SugarColumn(ColumnName = "WF_Desc", Length = 100, IsNullable = true, ColumnDescription = "说明")]
    public string? WF_Desc { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
