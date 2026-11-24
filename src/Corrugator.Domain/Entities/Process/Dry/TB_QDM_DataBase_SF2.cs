using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_DataBase_SF2
/// </summary>
[SugarTable("TB_QDM_DataBase_SF2", TableDescription = "TB_QDM_DataBase_SF2")]
public class TB_QDM_DataBase_SF2
{
    /// <summary>SF2材质</summary>
    [SugarColumn(ColumnName = "F_SF2_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "SF2材质")]
    public string? F_SF2_MaterialQua { get; set; }

    /// <summary>SF2楞型</summary>
    [SugarColumn(ColumnName = "F_SF2_Flute", Length = 50, IsNullable = true, ColumnDescription = "SF2楞型")]
    public string? F_SF2_Flute { get; set; }

    /// <summary>F_SF2_LineFlute</summary>
    [SugarColumn(ColumnName = "F_SF2_LineFlute", Length = 50, IsNullable = true, ColumnDescription = "F_SF2_LineFlute")]
    public string? F_SF2_LineFlute { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "F_Glue_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? F_Glue_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_MS2_QDM_FactorMS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_MS2_QDM_FactorMS2 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_LS2_QDM_FactorLS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_LS2_QDM_FactorLS2 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? F_PreheaterSteam_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>压力楞辊门幅系数</summary>
    [SugarColumn(ColumnName = "F_PressRoll_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压力楞辊门幅系数")]
    public decimal? F_PressRoll_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>瓦楞辊门幅系数</summary>
    [SugarColumn(ColumnName = "F_CorrugatedRoll_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "瓦楞辊门幅系数")]
    public decimal? F_CorrugatedRoll_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>接纸机张力门幅系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTension_MS2_QDM_FactorMS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力门幅系数")]
    public decimal? F_SplicerTension_MS2_QDM_FactorMS2 { get; set; }

    /// <summary>接纸机张力系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTension_LS2_QDM_FactorLS2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力系数")]
    public decimal? F_SplicerTension_LS2_QDM_FactorLS2 { get; set; }

    /// <summary>真空泵门幅系数</summary>
    [SugarColumn(ColumnName = "F_VacuumBlower_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "真空泵门幅系数")]
    public decimal? F_VacuumBlower_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray_SF2_QDM_FactorSF2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? F_Spray_SF2_QDM_FactorSF2 { get; set; }

    /// <summary>F_CruisingSpeed_SF2_QDM_Factor</summary>
    [SugarColumn(ColumnName = "F_CruisingSpeed_SF2_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_CruisingSpeed_SF2_QDM_Factor")]
    public decimal? F_CruisingSpeed_SF2_QDM_Factor { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}