using SqlSugar;

namespace Corrugator.Domain.Entities.Paper;

/// <summary>原纸品牌信息（按 原纸代号+供应商）：额定张力与克重参数。</summary>
[SugarTable("W_Paper_BrandParam", TableDescription = "原纸品牌信息")]
public class W_Paper_BrandParam
{
    [SugarColumn(ColumnName = "WF_PaperCode", Length = 30, ColumnDescription = "原纸代号")]
    public string WF_PaperCode { get; set; } = default!;

    [SugarColumn(ColumnName = "WF_Supplier", Length = 60, ColumnDescription = "供应商")]
    public string WF_Supplier { get; set; } = default!;

    [SugarColumn(ColumnName = "WF_RatedTension", IsNullable = true, ColumnDescription = "额定接纸机张力")]
    public decimal? WF_RatedTension { get; set; }

    [SugarColumn(ColumnName = "WF_SteamGsm", IsNullable = true, ColumnDescription = "蒸汽克重(gsm)")]
    public decimal? WF_SteamGsm { get; set; }

    [SugarColumn(ColumnName = "WF_GlueGsm", IsNullable = true, ColumnDescription = "胶水克重(gsm)")]
    public decimal? WF_GlueGsm { get; set; }

    [SugarColumn(ColumnName = "WF_WrapGsm", IsNullable = true, ColumnDescription = "包角克重(gsm)")]
    public decimal? WF_WrapGsm { get; set; }

    [SugarColumn(ColumnName = "WF_TensionLS0", IsNullable = true, ColumnDescription = "LS0额定张力(daN)")]
    public decimal? WF_TensionLS0 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionMS1", IsNullable = true, ColumnDescription = "MS1额定张力(daN)")]
    public decimal? WF_TensionMS1 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionLS1", IsNullable = true, ColumnDescription = "LS1额定张力(daN)")]
    public decimal? WF_TensionLS1 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionMS2", IsNullable = true, ColumnDescription = "MS2额定张力(daN)")]
    public decimal? WF_TensionMS2 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionLS2", IsNullable = true, ColumnDescription = "LS2额定张力(daN)")]
    public decimal? WF_TensionLS2 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionMS3", IsNullable = true, ColumnDescription = "MS3额定张力(daN)")]
    public decimal? WF_TensionMS3 { get; set; }

    [SugarColumn(ColumnName = "WF_TensionLS3", IsNullable = true, ColumnDescription = "LS3额定张力(daN)")]
    public decimal? WF_TensionLS3 { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
