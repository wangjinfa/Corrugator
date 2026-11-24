using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸胶水值（按 原纸代号 + 机台(单面机/双面机) + 楞型 + 层数）。</summary>
[SugarTable("TB_Paper_GlueValue", TableDescription = "原纸胶水值")]
public class TB_Paper_GlueValue
{
    [SugarColumn(ColumnName = "F_PaperCode", Length = 30, ColumnDescription = "原纸代号")]
    public string F_PaperCode { get; set; } = default!;

    /// <summary>单面机 / 双面机</summary>
    [SugarColumn(ColumnName = "F_MachineType", Length = 20, ColumnDescription = "机台类型")]
    public string F_MachineType { get; set; } = default!;

    /// <summary>A/B/C/E/3A/3B/3C/3E/4BA/4BC</summary>
    [SugarColumn(ColumnName = "F_FluteType", Length = 20, ColumnDescription = "楞型")]
    public string F_FluteType { get; set; } = default!;

    /// <summary>层数（1层/2层…）</summary>
    [SugarColumn(ColumnName = "F_Layer", Length = 20, IsNullable = true, ColumnDescription = "层数")]
    public string? F_Layer { get; set; }

    [SugarColumn(ColumnName = "F_GlueValue", IsNullable = true, ColumnDescription = "胶水值")]
    public decimal? F_GlueValue { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
