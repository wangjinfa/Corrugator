using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸资料（基础信息 → 原纸资料）：原纸代号主数据 + 残卷量。</summary>
[SugarTable("TB_Paper_Info", TableDescription = "原纸资料")]
public class TB_Paper_Info
{
    /// <summary>原纸代号（区分大小写，如 J / Z）</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 30, ColumnDescription = "原纸代号")]
    public string F_Code { get; set; } = default!;

    /// <summary>克重(gsm)</summary>
    [SugarColumn(ColumnName = "F_GramWeight", IsNullable = true, ColumnDescription = "克重(gsm)")]
    public decimal? F_GramWeight { get; set; }

    /// <summary>原纸门幅(mm)</summary>
    [SugarColumn(ColumnName = "F_PaperWidth", IsNullable = true, ColumnDescription = "门幅(mm)")]
    public decimal? F_PaperWidth { get; set; }

    /// <summary>品牌</summary>
    [SugarColumn(ColumnName = "F_Brand", Length = 60, IsNullable = true, ColumnDescription = "品牌")]
    public string? F_Brand { get; set; }

    /// <summary>LS2 残卷(m)</summary>
    [SugarColumn(ColumnName = "F_RemainLS2", IsNullable = true, ColumnDescription = "LS2残卷")]
    public decimal? F_RemainLS2 { get; set; }

    /// <summary>MS3 残卷(m)</summary>
    [SugarColumn(ColumnName = "F_RemainMS3", IsNullable = true, ColumnDescription = "MS3残卷")]
    public decimal? F_RemainMS3 { get; set; }

    /// <summary>LS3 残卷(m)</summary>
    [SugarColumn(ColumnName = "F_RemainLS3", IsNullable = true, ColumnDescription = "LS3残卷")]
    public decimal? F_RemainLS3 { get; set; }

    [SugarColumn(ColumnName = "F_IsDelete", IsNullable = true)]
    public bool? F_IsDelete { get; set; }

    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true)]
    public string? F_Creator { get; set; }

    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true)]
    public DateTime? F_CreateTime { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
