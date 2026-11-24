using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_DataBase_DF
/// </summary>
[SugarTable("TB_QDM_DataBase_DF", TableDescription = "TB_QDM_DataBase_DF")]
public class TB_QDM_DataBase_DF
{
    /// <summary>DF材质</summary>
    [SugarColumn(ColumnName = "F_DF_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "DF材质")]
    public string? F_DF_MaterialQua { get; set; }

    /// <summary>DF楞型</summary>
    [SugarColumn(ColumnName = "F_DF_Flute", Length = 50, IsNullable = true, ColumnDescription = "DF楞型")]
    public string? F_DF_Flute { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "F_Glue_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? F_Glue_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "F_Glue_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? F_Glue_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? F_PreheaterSteam_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? F_PreheaterSteam_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? F_PreheaterSteam_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>热板蒸汽一段系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam_DF_1Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽一段系数")]
    public decimal? F_HotPlateSteam_DF_1Part_QDM_Factor { get; set; }

    /// <summary>热板蒸汽二段系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam_DF_2Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽二段系数")]
    public decimal? F_HotPlateSteam_DF_2Part_QDM_Factor { get; set; }

    /// <summary>热板蒸汽三段系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam_DF_3Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽三段系数")]
    public decimal? F_HotPlateSteam_DF_3Part_QDM_Factor { get; set; }

    /// <summary>压板组数系数</summary>
    [SugarColumn(ColumnName = "F_HotLoadGroupQty_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压板组数系数")]
    public decimal? F_HotLoadGroupQty_DF_QDM_Factor { get; set; }

    /// <summary>热板压力系数</summary>
    [SugarColumn(ColumnName = "F_HotPlatePress_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板压力系数")]
    public decimal? F_HotPlatePress_DF_QDM_Factor { get; set; }

    /// <summary>冷板压力系数</summary>
    [SugarColumn(ColumnName = "F_ColdPlatePress_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "冷板压力系数")]
    public decimal? F_ColdPlatePress_DF_QDM_Factor { get; set; }

    /// <summary>接纸机张力门幅系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTension_LS0_QDM_FactorLS0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力门幅系数")]
    public decimal? F_SplicerTension_LS0_QDM_FactorLS0 { get; set; }

    /// <summary>天桥张力门幅系数</summary>
    [SugarColumn(ColumnName = "F_BridgeTension_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "天桥张力门幅系数")]
    public decimal? F_BridgeTension_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>天桥张力系数</summary>
    [SugarColumn(ColumnName = "F_BridgeTension_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "天桥张力系数")]
    public decimal? F_BridgeTension_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? F_Spray_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? F_Spray_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>车速巡航系数</summary>
    [SugarColumn(ColumnName = "F_CruisingSpeed_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速巡航系数")]
    public decimal? F_CruisingSpeed_DF_QDM_Factor { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}