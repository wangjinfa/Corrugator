using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸胶水值（按 原纸代号 + 机台(单面机/双面机) + 楞型 + 层数）。</summary>
[SugarTable("W_Paper_GlueValue", TableDescription = "原纸胶水值")]
public class W_Paper_GlueValue
{
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 30, ColumnDescription = "原纸代号")]
    public string WF_PaperCode { get; set; } = default!;

    /// <summary>单面机 / 双面机</summary>
    [SugarColumn(ColumnName = "WF_MachineType", Length = 20, ColumnDescription = "机台类型")]
    public string WF_MachineType { get; set; } = default!;

    /// <summary>A/B/C/E/3A/3B/3C/3E/4BA/4BC</summary>
    [SugarColumn(ColumnName = "WF_FluteType", Length = 20, ColumnDescription = "楞型")]
    public string WF_FluteType { get; set; } = default!;

    /// <summary>层数（1层/2层…）</summary>
    [SugarColumn(ColumnName = "WF_Layer", Length = 20, IsNullable = true, ColumnDescription = "层数")]
    public string? WF_Layer { get; set; }

    [SugarColumn(ColumnName = "WF_GlueValue", IsNullable = true, ColumnDescription = "胶水值")]
    public decimal? WF_GlueValue { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
