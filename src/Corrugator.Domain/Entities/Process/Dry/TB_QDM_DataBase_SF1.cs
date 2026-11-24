using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_DataBase_SF1
/// </summary>
[SugarTable("TB_QDM_DataBase_SF1", TableDescription = "TB_QDM_DataBase_SF1")]
public class TB_QDM_DataBase_SF1
{
    /// <summary>SF1材质</summary>
    [SugarColumn(ColumnName = "F_SF1_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "SF1材质")]
    public string? F_SF1_MaterialQua { get; set; }

    /// <summary>SF1楞型</summary>
    [SugarColumn(ColumnName = "F_SF1_Flute", Length = 50, IsNullable = true, ColumnDescription = "SF1楞型")]
    public string? F_SF1_Flute { get; set; }

    /// <summary>F_SF1_LineFlute</summary>
    [SugarColumn(ColumnName = "F_SF1_LineFlute", Length = 50, IsNullable = true, ColumnDescription = "F_SF1_LineFlute")]
    public string? F_SF1_LineFlute { get; set; }

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "F_Glue_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "糊间隙系数")]
    public decimal? F_Glue_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_MS1_QDM_FactorMS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_MS1_QDM_FactorMS1 { get; set; }

    /// <summary>包角系数</summary>
    [SugarColumn(ColumnName = "F_Wrap_LS1_QDM_FactorLS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "包角系数")]
    public decimal? F_Wrap_LS1_QDM_FactorLS1 { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "烘缸蒸汽系数")]
    public decimal? F_PreheaterSteam_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>压力辊门幅系数</summary>
    [SugarColumn(ColumnName = "F_PressRoll_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "压力辊门幅系数")]
    public decimal? F_PressRoll_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>瓦楞辊门幅系数</summary>
    [SugarColumn(ColumnName = "F_CorrugatedRoll_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "瓦楞辊门幅系数")]
    public decimal? F_CorrugatedRoll_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>接纸机张力门幅系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTension_MS1_QDM_FactorMS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力门幅系数")]
    public decimal? F_SplicerTension_MS1_QDM_FactorMS1 { get; set; }

    /// <summary>接纸机张力门幅系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTension_LS1_QDM_FactorLS1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "接纸机张力门幅系数")]
    public decimal? F_SplicerTension_LS1_QDM_FactorLS1 { get; set; }

    /// <summary>真空泵门幅系数</summary>
    [SugarColumn(ColumnName = "F_VacuumBlower_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "真空泵门幅系数")]
    public decimal? F_VacuumBlower_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray_SF1_QDM_FactorSF1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "喷雾系数")]
    public decimal? F_Spray_SF1_QDM_FactorSF1 { get; set; }

    /// <summary>F_CruisingSpeed_SF1_QDM_Factor</summary>
    [SugarColumn(ColumnName = "F_CruisingSpeed_SF1_QDM_Factor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_CruisingSpeed_SF1_QDM_Factor")]
    public decimal? F_CruisingSpeed_SF1_QDM_Factor { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}