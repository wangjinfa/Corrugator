using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>
/// IPS 部位显示/隐藏（基础信息 → IPS部位显示/隐藏）。
/// 图形化控制页按部位编码决定该部位是否显示。
/// </summary>
[SugarTable("W_Ips_PartDisplay", TableDescription = "IPS部位显示隐藏设置")]
public class W_Ips_PartDisplay
{
    /// <summary>部位编码（GlueGU1 / WrapLS2 …）</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 40, ColumnDescription = "部位编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>部位名称（糊机胶水-1层 …）</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, IsNullable = true, ColumnDescription = "部位名称")]
    public string? WF_Name { get; set; }

    /// <summary>显示/隐藏</summary>
    [SugarColumn(ColumnName = "WF_IsShow", IsNullable = true, ColumnDescription = "显示/隐藏")]
    public bool? WF_IsShow { get; set; }

    [SugarColumn(ColumnName = "WF_SortNo", IsNullable = true, ColumnDescription = "排序号")]
    public int? WF_SortNo { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
