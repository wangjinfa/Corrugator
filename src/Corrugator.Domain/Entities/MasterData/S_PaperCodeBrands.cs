using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 原纸品牌详情表
/// </summary>
[SugarTable("S_PaperCodeBrands", TableDescription = "原纸品牌详情表")]
public class S_PaperCodeBrands
{
    /// <summary>品牌</summary>
    [SugarColumn(ColumnName = "F_Brand", Length = 100, ColumnDescription = "品牌")]
    public string F_Brand { get; set; } = default!;

    /// <summary>PaperCode表的ID</summary>
    [SugarColumn(ColumnName = "F_PaperCodeID", ColumnDescription = "PaperCode表的ID")]
    public int F_PaperCodeID { get; set; }

    /// <summary>额定张力</summary>
    [SugarColumn(ColumnName = "F_RatedTension", IsNullable = true, ColumnDescription = "额定张力")]
    public int? F_RatedTension { get; set; }

    /// <summary>蒸汽克重</summary>
    [SugarColumn(ColumnName = "F_SteamWeight", IsNullable = true, ColumnDescription = "蒸汽克重")]
    public int? F_SteamWeight { get; set; }

    /// <summary>胶水克重</summary>
    [SugarColumn(ColumnName = "F_GlueWeight", IsNullable = true, ColumnDescription = "胶水克重")]
    public int? F_GlueWeight { get; set; }

    /// <summary>包角克重</summary>
    [SugarColumn(ColumnName = "F_WrapWeight", IsNullable = true, ColumnDescription = "包角克重")]
    public int? F_WrapWeight { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>F_LS0Tension</summary>
    [SugarColumn(ColumnName = "F_LS0Tension", ColumnDescription = "F_LS0Tension", DefaultValue = "0")]
    public int F_LS0Tension { get; set; }

    /// <summary>F_MS1Tension</summary>
    [SugarColumn(ColumnName = "F_MS1Tension", IsNullable = true, ColumnDescription = "F_MS1Tension", DefaultValue = "0")]
    public int? F_MS1Tension { get; set; }

    /// <summary>F_LS1Tension</summary>
    [SugarColumn(ColumnName = "F_LS1Tension", IsNullable = true, ColumnDescription = "F_LS1Tension", DefaultValue = "0")]
    public int? F_LS1Tension { get; set; }

    /// <summary>F_MS2Tension</summary>
    [SugarColumn(ColumnName = "F_MS2Tension", IsNullable = true, ColumnDescription = "F_MS2Tension", DefaultValue = "0")]
    public int? F_MS2Tension { get; set; }

    /// <summary>F_LS2Tension</summary>
    [SugarColumn(ColumnName = "F_LS2Tension", IsNullable = true, ColumnDescription = "F_LS2Tension", DefaultValue = "0")]
    public int? F_LS2Tension { get; set; }

    /// <summary>F_MS3Tension</summary>
    [SugarColumn(ColumnName = "F_MS3Tension", IsNullable = true, ColumnDescription = "F_MS3Tension", DefaultValue = "0")]
    public int? F_MS3Tension { get; set; }

    /// <summary>F_LS3Tension</summary>
    [SugarColumn(ColumnName = "F_LS3Tension", IsNullable = true, ColumnDescription = "F_LS3Tension", DefaultValue = "0")]
    public int? F_LS3Tension { get; set; }

}