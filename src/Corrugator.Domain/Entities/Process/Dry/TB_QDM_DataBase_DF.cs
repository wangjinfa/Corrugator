using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_DataBase_DF
/// </summary>
[SugarTable("W_QDM_DataBase_DF", TableDescription = "W_QDM_DataBase_DF")]
public class W_QDM_DataBase_DF
{
    /// <summary>DF材质</summary>
    [SugarColumn(ColumnName = "WF_DF_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "DF材质")]
    public string? WF_DF_MaterialQua { get; set; }

    /// <summary>DF楞型</summary>
    [SugarColumn(ColumnName = "WF_DF_Flute", Length = 50, IsNullable = true, ColumnDescription = "DF楞型")]
    public string? WF_DF_Flute { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? WF_Glue_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? WF_Glue_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? WF_Wrap_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? WF_Wrap_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? WF_Wrap_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? WF_PreheaterSteam_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? WF_PreheaterSteam_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? WF_PreheaterSteam_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>热板蒸汽一段系数</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_1Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽一段系数")]
    public decimal? WF_HotPlateSteam_DF_1Part_QDM_Factor { get; set; }

    /// <summary>热板蒸汽二段系数</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_2Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽二段系数")]
    public decimal? WF_HotPlateSteam_DF_2Part_QDM_Factor { get; set; }

    /// <summary>热板蒸汽三段系数</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_3Part_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板蒸汽三段系数")]
    public decimal? WF_HotPlateSteam_DF_3Part_QDM_Factor { get; set; }

    /// <summary>压板组数系数</summary>
    [SugarColumn(ColumnName = "WF_HotLoadGroupQty_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压板组数系数")]
    public decimal? WF_HotLoadGroupQty_DF_QDM_Factor { get; set; }

    /// <summary>热板压力系数</summary>
    [SugarColumn(ColumnName = "WF_HotPlatePress_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "热板压力系数")]
    public decimal? WF_HotPlatePress_DF_QDM_Factor { get; set; }

    /// <summary>冷板压力系数</summary>
    [SugarColumn(ColumnName = "WF_ColdPlatePress_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "冷板压力系数")]
    public decimal? WF_ColdPlatePress_DF_QDM_Factor { get; set; }

    /// <summary>接纸机张力门幅系数</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS0_QDM_FactorLS0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力门幅系数")]
    public decimal? WF_SplicerTension_LS0_QDM_FactorLS0 { get; set; }

    /// <summary>天桥张力门幅系数</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_1st_QDM_FactorGU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "天桥张力门幅系数")]
    public decimal? WF_BridgeTension_GU_1st_QDM_FactorGU1 { get; set; }

    /// <summary>天桥张力系数</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "天桥张力系数")]
    public decimal? WF_BridgeTension_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_0_QDM_FactorGU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? WF_Spray_GU_0_QDM_FactorGU0 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_2nd_QDM_FactorGU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? WF_Spray_GU_2nd_QDM_FactorGU2 { get; set; }

    /// <summary>车速巡航系数</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_DF_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速巡航系数")]
    public decimal? WF_CruisingSpeed_DF_QDM_Factor { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}