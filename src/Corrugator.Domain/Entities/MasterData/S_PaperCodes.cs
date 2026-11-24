using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 原纸基础资料设置表
/// </summary>
[SugarTable("W_PaperCodes", TableDescription = "原纸基础资料设置表")]
public class W_PaperCodes
{
    /// <summary>原纸代号</summary>
    [SugarColumn(ColumnName = "WSPC_Code", Length = 50, ColumnDescription = "原纸代号")]
    public string WSPC_Code { get; set; } = default!;

    /// <summary>ERP原纸代码</summary>
    [SugarColumn(ColumnName = "WSPC_ErpCode", Length = 50, IsNullable = true, ColumnDescription = "ERP原纸代码")]
    public string? WSPC_ErpCode { get; set; }

    /// <summary>原纸克重</summary>
    [SugarColumn(ColumnName = "WSPC_Weight", ColumnDescription = "原纸克重")]
    public int WSPC_Weight { get; set; }

    /// <summary>额定张力</summary>
    [SugarColumn(ColumnName = "WSPC_RatedTension", IsNullable = true, ColumnDescription = "额定张力")]
    public int? WSPC_RatedTension { get; set; }

    /// <summary>蒸汽克重</summary>
    [SugarColumn(ColumnName = "WSPC_SteamWeight", IsNullable = true, ColumnDescription = "蒸汽克重")]
    public int? WSPC_SteamWeight { get; set; }

    /// <summary>胶水克重</summary>
    [SugarColumn(ColumnName = "WSPC_GlueWeight", IsNullable = true, ColumnDescription = "胶水克重")]
    public int? WSPC_GlueWeight { get; set; }

    /// <summary>包角克重</summary>
    [SugarColumn(ColumnName = "WSPC_WrapWeight", IsNullable = true, ColumnDescription = "包角克重")]
    public int? WSPC_WrapWeight { get; set; }

    /// <summary>原纸厚度</summary>
    [SugarColumn(ColumnName = "WSPC_Deep", Length = 18, DecimalDigits = 4, ColumnDescription = "原纸厚度")]
    public decimal WSPC_Deep { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_LS0_TensionFactorLS0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_LS0_TensionFactorLS0 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_MS1_TensionFactorMS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_MS1_TensionFactorMS1 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_LS1_TensionFactorLS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_LS1_TensionFactorLS1 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_MS2_TensionFactorMS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_MS2_TensionFactorMS2 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_LS2_TensionFactorLS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_LS2_TensionFactorLS2 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_MS3_TensionFactorMS3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_MS3_TensionFactorMS3 { get; set; }

    /// <summary>张力系数</summary>
    [SugarColumn(ColumnName = "WSPC_LS3_TensionFactorLS3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "张力系数")]
    public decimal? WSPC_LS3_TensionFactorLS3 { get; set; }

    /// <summary>LS0面纸接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_LS0_Speed", ColumnDescription = "LS0面纸接纸车速")]
    public int WSPC_LS0_Speed { get; set; }

    /// <summary>MS1接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_MS1_Speed", IsNullable = true, ColumnDescription = "MS1接纸车速")]
    public int? WSPC_MS1_Speed { get; set; }

    /// <summary>LS1接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_LS1_Speed", IsNullable = true, ColumnDescription = "LS1接纸车速")]
    public int? WSPC_LS1_Speed { get; set; }

    /// <summary>MS2接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_MS2_Speed", IsNullable = true, ColumnDescription = "MS2接纸车速")]
    public int? WSPC_MS2_Speed { get; set; }

    /// <summary>LS2接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_LS2_Speed", IsNullable = true, ColumnDescription = "LS2接纸车速")]
    public int? WSPC_LS2_Speed { get; set; }

    /// <summary>MS3接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_MS3_Speed", IsNullable = true, ColumnDescription = "MS3接纸车速")]
    public int? WSPC_MS3_Speed { get; set; }

    /// <summary>LS3接纸车速</summary>
    [SugarColumn(ColumnName = "WSPC_LS3_Speed", IsNullable = true, ColumnDescription = "LS3接纸车速")]
    public int? WSPC_LS3_Speed { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "WSPC_Creator", Length = 50, ColumnDescription = "创建者")]
    public string WSPC_Creator { get; set; } = default!;

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WSPC_CreateTime", ColumnDescription = "创建日期")]
    public DateTime WSPC_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "WSPC_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? WSPC_Editor { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "WSPC_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? WSPC_EditTime { get; set; }

    /// <summary>WSPC_ID</summary>
    [SugarColumn(ColumnName = "WSPC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSPC_ID")]
    public int WSPC_ID { get; set; }

    /// <summary>WSPC_LS0_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_LS0_SpeedRemain", ColumnDescription = "WSPC_LS0_SpeedRemain", DefaultValue = "0")]
    public int WSPC_LS0_SpeedRemain { get; set; }

    /// <summary>WSPC_MS1_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_MS1_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_MS1_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_MS1_SpeedRemain { get; set; }

    /// <summary>WSPC_LS1_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_LS1_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_LS1_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_LS1_SpeedRemain { get; set; }

    /// <summary>WSPC_MS2_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_MS2_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_MS2_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_MS2_SpeedRemain { get; set; }

    /// <summary>WSPC_LS2_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_LS2_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_LS2_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_LS2_SpeedRemain { get; set; }

    /// <summary>WSPC_MS3_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_MS3_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_MS3_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_MS3_SpeedRemain { get; set; }

    /// <summary>WSPC_LS3_SpeedRemain</summary>
    [SugarColumn(ColumnName = "WSPC_LS3_SpeedRemain", IsNullable = true, ColumnDescription = "WSPC_LS3_SpeedRemain", DefaultValue = "0")]
    public int? WSPC_LS3_SpeedRemain { get; set; }

    /// <summary>WSPC_LS0Tension</summary>
    [SugarColumn(ColumnName = "WSPC_LS0Tension", ColumnDescription = "WSPC_LS0Tension", DefaultValue = "0")]
    public int WSPC_LS0Tension { get; set; }

    /// <summary>WSPC_MS1Tension</summary>
    [SugarColumn(ColumnName = "WSPC_MS1Tension", IsNullable = true, ColumnDescription = "WSPC_MS1Tension", DefaultValue = "0")]
    public int? WSPC_MS1Tension { get; set; }

    /// <summary>WSPC_LS1Tension</summary>
    [SugarColumn(ColumnName = "WSPC_LS1Tension", IsNullable = true, ColumnDescription = "WSPC_LS1Tension", DefaultValue = "0")]
    public int? WSPC_LS1Tension { get; set; }

    /// <summary>WSPC_MS2Tension</summary>
    [SugarColumn(ColumnName = "WSPC_MS2Tension", IsNullable = true, ColumnDescription = "WSPC_MS2Tension", DefaultValue = "0")]
    public int? WSPC_MS2Tension { get; set; }

    /// <summary>WSPC_LS2Tension</summary>
    [SugarColumn(ColumnName = "WSPC_LS2Tension", IsNullable = true, ColumnDescription = "WSPC_LS2Tension", DefaultValue = "0")]
    public int? WSPC_LS2Tension { get; set; }

    /// <summary>WSPC_MS3Tension</summary>
    [SugarColumn(ColumnName = "WSPC_MS3Tension", IsNullable = true, ColumnDescription = "WSPC_MS3Tension", DefaultValue = "0")]
    public int? WSPC_MS3Tension { get; set; }

    /// <summary>WSPC_LS3Tension</summary>
    [SugarColumn(ColumnName = "WSPC_LS3Tension", IsNullable = true, ColumnDescription = "WSPC_LS3Tension", DefaultValue = "0")]
    public int? WSPC_LS3Tension { get; set; }

}