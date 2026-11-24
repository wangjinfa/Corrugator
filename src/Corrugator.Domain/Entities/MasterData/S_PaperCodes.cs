using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 原纸基础资料设置表
/// </summary>
[SugarTable("S_PaperCodes", TableDescription = "原纸基础资料设置表")]
public class S_PaperCodes
{
    /// <summary>原纸代号</summary>
    [SugarColumn(ColumnName = "SPC_Code", Length = 50, ColumnDescription = "原纸代号")]
    public string SPC_Code { get; set; } = default!;

    /// <summary>ERP原纸代码</summary>
    [SugarColumn(ColumnName = "SPC_ErpCode", Length = 50, IsNullable = true, ColumnDescription = "ERP原纸代码")]
    public string? SPC_ErpCode { get; set; }

    /// <summary>原纸克重</summary>
    [SugarColumn(ColumnName = "SPC_Weight", ColumnDescription = "原纸克重")]
    public int SPC_Weight { get; set; }

    /// <summary>额定张力</summary>
    [SugarColumn(ColumnName = "SPC_RatedTension", IsNullable = true, ColumnDescription = "额定张力")]
    public int? SPC_RatedTension { get; set; }

    /// <summary>蒸汽克重</summary>
    [SugarColumn(ColumnName = "SPC_SteamWeight", IsNullable = true, ColumnDescription = "蒸汽克重")]
    public int? SPC_SteamWeight { get; set; }

    /// <summary>胶水克重</summary>
    [SugarColumn(ColumnName = "SPC_GlueWeight", IsNullable = true, ColumnDescription = "胶水克重")]
    public int? SPC_GlueWeight { get; set; }

    /// <summary>包角克重</summary>
    [SugarColumn(ColumnName = "SPC_WrapWeight", IsNullable = true, ColumnDescription = "包角克重")]
    public int? SPC_WrapWeight { get; set; }

    /// <summary>原纸厚度</summary>
    [SugarColumn(ColumnName = "SPC_Deep", Length = 18, DecimalDigits = 4, ColumnDescription = "原纸厚度")]
    public decimal SPC_Deep { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_LS0_TensionFactorLS0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_LS0_TensionFactorLS0 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_MS1_TensionFactorMS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_MS1_TensionFactorMS1 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_LS1_TensionFactorLS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_LS1_TensionFactorLS1 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_MS2_TensionFactorMS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_MS2_TensionFactorMS2 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_LS2_TensionFactorLS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_LS2_TensionFactorLS2 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_MS3_TensionFactorMS3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_MS3_TensionFactorMS3 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "SPC_LS3_TensionFactorLS3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? SPC_LS3_TensionFactorLS3 { get; set; }

    /// <summary>LS0面纸接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_LS0_Speed", ColumnDescription = "LS0面纸接纸车速")]
    public int SPC_LS0_Speed { get; set; }

    /// <summary>MS1接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_MS1_Speed", IsNullable = true, ColumnDescription = "MS1接纸车速")]
    public int? SPC_MS1_Speed { get; set; }

    /// <summary>LS1接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_LS1_Speed", IsNullable = true, ColumnDescription = "LS1接纸车速")]
    public int? SPC_LS1_Speed { get; set; }

    /// <summary>MS2接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_MS2_Speed", IsNullable = true, ColumnDescription = "MS2接纸车速")]
    public int? SPC_MS2_Speed { get; set; }

    /// <summary>LS2接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_LS2_Speed", IsNullable = true, ColumnDescription = "LS2接纸车速")]
    public int? SPC_LS2_Speed { get; set; }

    /// <summary>MS3接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_MS3_Speed", IsNullable = true, ColumnDescription = "MS3接纸车速")]
    public int? SPC_MS3_Speed { get; set; }

    /// <summary>LS3接纸车速</summary>
    [SugarColumn(ColumnName = "SPC_LS3_Speed", IsNullable = true, ColumnDescription = "LS3接纸车速")]
    public int? SPC_LS3_Speed { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "SPC_Creator", Length = 50, ColumnDescription = "创建者")]
    public string SPC_Creator { get; set; } = default!;

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "SPC_CreateTime", ColumnDescription = "创建日期")]
    public DateTime SPC_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "SPC_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? SPC_Editor { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "SPC_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? SPC_EditTime { get; set; }

    /// <summary>SPC_ID</summary>
    [SugarColumn(ColumnName = "SPC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SPC_ID")]
    public int SPC_ID { get; set; }

    /// <summary>SPC_LS0_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_LS0_SpeedRemain", ColumnDescription = "SPC_LS0_SpeedRemain", DefaultValue = "0")]
    public int SPC_LS0_SpeedRemain { get; set; }

    /// <summary>SPC_MS1_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_MS1_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_MS1_SpeedRemain", DefaultValue = "0")]
    public int? SPC_MS1_SpeedRemain { get; set; }

    /// <summary>SPC_LS1_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_LS1_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_LS1_SpeedRemain", DefaultValue = "0")]
    public int? SPC_LS1_SpeedRemain { get; set; }

    /// <summary>SPC_MS2_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_MS2_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_MS2_SpeedRemain", DefaultValue = "0")]
    public int? SPC_MS2_SpeedRemain { get; set; }

    /// <summary>SPC_LS2_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_LS2_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_LS2_SpeedRemain", DefaultValue = "0")]
    public int? SPC_LS2_SpeedRemain { get; set; }

    /// <summary>SPC_MS3_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_MS3_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_MS3_SpeedRemain", DefaultValue = "0")]
    public int? SPC_MS3_SpeedRemain { get; set; }

    /// <summary>SPC_LS3_SpeedRemain</summary>
    [SugarColumn(ColumnName = "SPC_LS3_SpeedRemain", IsNullable = true, ColumnDescription = "SPC_LS3_SpeedRemain", DefaultValue = "0")]
    public int? SPC_LS3_SpeedRemain { get; set; }

    /// <summary>SPC_LS0Tension</summary>
    [SugarColumn(ColumnName = "SPC_LS0Tension", ColumnDescription = "SPC_LS0Tension", DefaultValue = "0")]
    public int SPC_LS0Tension { get; set; }

    /// <summary>SPC_MS1Tension</summary>
    [SugarColumn(ColumnName = "SPC_MS1Tension", IsNullable = true, ColumnDescription = "SPC_MS1Tension", DefaultValue = "0")]
    public int? SPC_MS1Tension { get; set; }

    /// <summary>SPC_LS1Tension</summary>
    [SugarColumn(ColumnName = "SPC_LS1Tension", IsNullable = true, ColumnDescription = "SPC_LS1Tension", DefaultValue = "0")]
    public int? SPC_LS1Tension { get; set; }

    /// <summary>SPC_MS2Tension</summary>
    [SugarColumn(ColumnName = "SPC_MS2Tension", IsNullable = true, ColumnDescription = "SPC_MS2Tension", DefaultValue = "0")]
    public int? SPC_MS2Tension { get; set; }

    /// <summary>SPC_LS2Tension</summary>
    [SugarColumn(ColumnName = "SPC_LS2Tension", IsNullable = true, ColumnDescription = "SPC_LS2Tension", DefaultValue = "0")]
    public int? SPC_LS2Tension { get; set; }

    /// <summary>SPC_MS3Tension</summary>
    [SugarColumn(ColumnName = "SPC_MS3Tension", IsNullable = true, ColumnDescription = "SPC_MS3Tension", DefaultValue = "0")]
    public int? SPC_MS3Tension { get; set; }

    /// <summary>SPC_LS3Tension</summary>
    [SugarColumn(ColumnName = "SPC_LS3Tension", IsNullable = true, ColumnDescription = "SPC_LS3Tension", DefaultValue = "0")]
    public int? SPC_LS3Tension { get; set; }

}