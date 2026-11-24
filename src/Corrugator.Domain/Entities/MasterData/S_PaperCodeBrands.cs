using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 原纸品牌详情表
/// </summary>
[SugarTable("W_PaperCodeBrands", TableDescription = "原纸品牌详情表")]
public class W_PaperCodeBrands
{
    /// <summary>品牌</summary>
    [SugarColumn(ColumnName = "WF_Brand", Length = 100, ColumnDescription = "品牌")]
    public string WF_Brand { get; set; } = default!;

    /// <summary>PaperCode表的ID</summary>
    [SugarColumn(ColumnName = "WF_PaperCodeID", ColumnDescription = "PaperCode表的ID")]
    public int WF_PaperCodeID { get; set; }

    /// <summary>额定张力</summary>
    [SugarColumn(ColumnName = "WF_RatedTension", IsNullable = true, ColumnDescription = "额定张力")]
    public int? WF_RatedTension { get; set; }

    /// <summary>蒸汽克重</summary>
    [SugarColumn(ColumnName = "WF_SteamWeight", IsNullable = true, ColumnDescription = "蒸汽克重")]
    public int? WF_SteamWeight { get; set; }

    /// <summary>胶水克重</summary>
    [SugarColumn(ColumnName = "WF_GlueWeight", IsNullable = true, ColumnDescription = "胶水克重")]
    public int? WF_GlueWeight { get; set; }

    /// <summary>包角克重</summary>
    [SugarColumn(ColumnName = "WF_WrapWeight", IsNullable = true, ColumnDescription = "包角克重")]
    public int? WF_WrapWeight { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>WF_LS0Tension</summary>
    [SugarColumn(ColumnName = "WF_LS0Tension", ColumnDescription = "WF_LS0Tension", DefaultValue = "0")]
    public int WF_LS0Tension { get; set; }

    /// <summary>WF_MS1Tension</summary>
    [SugarColumn(ColumnName = "WF_MS1Tension", IsNullable = true, ColumnDescription = "WF_MS1Tension", DefaultValue = "0")]
    public int? WF_MS1Tension { get; set; }

    /// <summary>WF_LS1Tension</summary>
    [SugarColumn(ColumnName = "WF_LS1Tension", IsNullable = true, ColumnDescription = "WF_LS1Tension", DefaultValue = "0")]
    public int? WF_LS1Tension { get; set; }

    /// <summary>WF_MS2Tension</summary>
    [SugarColumn(ColumnName = "WF_MS2Tension", IsNullable = true, ColumnDescription = "WF_MS2Tension", DefaultValue = "0")]
    public int? WF_MS2Tension { get; set; }

    /// <summary>WF_LS2Tension</summary>
    [SugarColumn(ColumnName = "WF_LS2Tension", IsNullable = true, ColumnDescription = "WF_LS2Tension", DefaultValue = "0")]
    public int? WF_LS2Tension { get; set; }

    /// <summary>WF_MS3Tension</summary>
    [SugarColumn(ColumnName = "WF_MS3Tension", IsNullable = true, ColumnDescription = "WF_MS3Tension", DefaultValue = "0")]
    public int? WF_MS3Tension { get; set; }

    /// <summary>WF_LS3Tension</summary>
    [SugarColumn(ColumnName = "WF_LS3Tension", IsNullable = true, ColumnDescription = "WF_LS3Tension", DefaultValue = "0")]
    public int? WF_LS3Tension { get; set; }

}