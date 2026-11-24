using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸品牌信息（按 原纸代号+供应商）：额定张力与克重参数。</summary>
[SugarTable("TB_Paper_BrandParam", TableDescription = "原纸品牌信息")]
public class TB_Paper_BrandParam
{
    [SugarColumn(ColumnName = "F_PaperCode", Length = 30, ColumnDescription = "原纸代号")]
    public string F_PaperCode { get; set; } = default!;

    [SugarColumn(ColumnName = "F_Supplier", Length = 60, ColumnDescription = "供应商")]
    public string F_Supplier { get; set; } = default!;

    [SugarColumn(ColumnName = "F_RatedTension", IsNullable = true, ColumnDescription = "额定接纸机张力")]
    public decimal? F_RatedTension { get; set; }

    [SugarColumn(ColumnName = "F_SteamGsm", IsNullable = true, ColumnDescription = "蒸汽克重(gsm)")]
    public decimal? F_SteamGsm { get; set; }

    [SugarColumn(ColumnName = "F_GlueGsm", IsNullable = true, ColumnDescription = "胶水克重(gsm)")]
    public decimal? F_GlueGsm { get; set; }

    [SugarColumn(ColumnName = "F_WrapGsm", IsNullable = true, ColumnDescription = "包角克重(gsm)")]
    public decimal? F_WrapGsm { get; set; }

    [SugarColumn(ColumnName = "F_TensionLS0", IsNullable = true, ColumnDescription = "LS0额定张力(daN)")]
    public decimal? F_TensionLS0 { get; set; }

    [SugarColumn(ColumnName = "F_TensionMS1", IsNullable = true, ColumnDescription = "MS1额定张力(daN)")]
    public decimal? F_TensionMS1 { get; set; }

    [SugarColumn(ColumnName = "F_TensionLS1", IsNullable = true, ColumnDescription = "LS1额定张力(daN)")]
    public decimal? F_TensionLS1 { get; set; }

    [SugarColumn(ColumnName = "F_TensionMS2", IsNullable = true, ColumnDescription = "MS2额定张力(daN)")]
    public decimal? F_TensionMS2 { get; set; }

    [SugarColumn(ColumnName = "F_TensionLS2", IsNullable = true, ColumnDescription = "LS2额定张力(daN)")]
    public decimal? F_TensionLS2 { get; set; }

    [SugarColumn(ColumnName = "F_TensionMS3", IsNullable = true, ColumnDescription = "MS3额定张力(daN)")]
    public decimal? F_TensionMS3 { get; set; }

    [SugarColumn(ColumnName = "F_TensionLS3", IsNullable = true, ColumnDescription = "LS3额定张力(daN)")]
    public decimal? F_TensionLS3 { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
