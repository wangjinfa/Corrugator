using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>系统运行参数（基础信息 → 系统设置），键值对形式存放</summary>
[SugarTable("TB_Sys_Config", TableDescription = "系统运行参数表")]
public class TB_Sys_Config
{
    [SugarColumn(ColumnName = "F_Key", Length = 60, ColumnDescription = "参数键")]
    public string F_Key { get; set; } = default!;

    [SugarColumn(ColumnName = "F_Value", Length = 300, IsNullable = true, ColumnDescription = "参数值")]
    public string? F_Value { get; set; }

    [SugarColumn(ColumnName = "F_Desc", Length = 100, IsNullable = true, ColumnDescription = "说明")]
    public string? F_Desc { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
