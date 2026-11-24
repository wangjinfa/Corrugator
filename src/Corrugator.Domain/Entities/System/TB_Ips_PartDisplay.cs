using SqlSugar;

namespace Corrugator.Domain.Entities.System;

/// <summary>
/// IPS 部位显示/隐藏（基础信息 → IPS部位显示/隐藏）。
/// 图形化控制页按部位编码决定该部位是否显示。
/// </summary>
[SugarTable("TB_Ips_PartDisplay", TableDescription = "IPS部位显示隐藏设置")]
public class TB_Ips_PartDisplay
{
    /// <summary>部位编码（GlueGU1 / WrapLS2 …）</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 40, ColumnDescription = "部位编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>部位名称（糊机胶水-1层 …）</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, IsNullable = true, ColumnDescription = "部位名称")]
    public string? F_Name { get; set; }

    /// <summary>显示/隐藏</summary>
    [SugarColumn(ColumnName = "F_IsShow", IsNullable = true, ColumnDescription = "显示/隐藏")]
    public bool? F_IsShow { get; set; }

    [SugarColumn(ColumnName = "F_SortNo", IsNullable = true, ColumnDescription = "排序号")]
    public int? F_SortNo { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
