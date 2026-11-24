using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸资料（基础信息 → 原纸资料）：原纸代号主数据 + 残卷量。</summary>
[SugarTable("W_Paper_Info", TableDescription = "原纸资料")]
public class W_Paper_Info
{
    /// <summary>原纸代号（区分大小写，如 J / Z）</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 30, ColumnDescription = "原纸代号")]
    public string WF_Code { get; set; } = default!;

    /// <summary>克重(gsm)</summary>
    [SugarColumn(ColumnName = "WF_GramWeight", IsNullable = true, ColumnDescription = "克重(gsm)")]
    public decimal? WF_GramWeight { get; set; }

    /// <summary>原纸门幅(mm)</summary>
    [SugarColumn(ColumnName = "WF_PaperWidth", IsNullable = true, ColumnDescription = "门幅(mm)")]
    public decimal? WF_PaperWidth { get; set; }

    /// <summary>品牌</summary>
    [SugarColumn(ColumnName = "WF_Brand", Length = 60, IsNullable = true, ColumnDescription = "品牌")]
    public string? WF_Brand { get; set; }

    /// <summary>LS2 残卷(m)</summary>
    [SugarColumn(ColumnName = "WF_RemainLS2", IsNullable = true, ColumnDescription = "LS2残卷")]
    public decimal? WF_RemainLS2 { get; set; }

    /// <summary>MS3 残卷(m)</summary>
    [SugarColumn(ColumnName = "WF_RemainMS3", IsNullable = true, ColumnDescription = "MS3残卷")]
    public decimal? WF_RemainMS3 { get; set; }

    /// <summary>LS3 残卷(m)</summary>
    [SugarColumn(ColumnName = "WF_RemainLS3", IsNullable = true, ColumnDescription = "LS3残卷")]
    public decimal? WF_RemainLS3 { get; set; }

    [SugarColumn(ColumnName = "WF_IsDelete", IsNullable = true)]
    public bool? WF_IsDelete { get; set; }

    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true)]
    public string? WF_Creator { get; set; }

    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true)]
    public DateTime? WF_CreateTime { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
