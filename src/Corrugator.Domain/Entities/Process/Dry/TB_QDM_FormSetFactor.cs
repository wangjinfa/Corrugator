using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 当前运行参数(包含各种QMD系数和界面系数以及是否启用)
/// </summary>
[SugarTable("W_QDM_FormSetFactor", TableDescription = "当前运行参数(包含各种QMD系数和界面系数以及是否启用)")]
public class W_QDM_FormSetFactor
{
    /// <summary>糊机胶水系数</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_1st_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "糊机胶水系数")]
    public decimal WF_Glue_GU_1st_Form_Factor { get; set; }

    /// <summary>二层糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层糊间隙")]
    public decimal WF_Glue_GU_2nd_Form_Factor { get; set; }

    /// <summary>WF_Glue_GU_3rd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_3rd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Glue_GU_3rd_Form_Factor")]
    public decimal WF_Glue_GU_3rd_Form_Factor { get; set; }

    /// <summary>糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "糊间隙")]
    public decimal WF_Glue_SF1_Form_FactorSF1 { get; set; }

    /// <summary>糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "糊间隙")]
    public decimal WF_Glue_SF2_Form_FactorSF2 { get; set; }

    /// <summary>WF_Glue_SF3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Glue_SF3_Form_Factor")]
    public decimal WF_Glue_SF3_Form_Factor { get; set; }

    /// <summary>面纸烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_0_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸烘缸")]
    public decimal WF_Wrap_GU_0_Form_Factor { get; set; }

    /// <summary>一层烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_1st_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层烘缸")]
    public decimal WF_Wrap_GU_1st_Form_Factor { get; set; }

    /// <summary>二层烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层烘缸")]
    public decimal WF_Wrap_GU_2nd_Form_Factor { get; set; }

    /// <summary>WF_Wrap_GU_3rd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_3rd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_GU_3rd_Form_Factor")]
    public decimal WF_Wrap_GU_3rd_Form_Factor { get; set; }

    /// <summary>里烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "里烘缸")]
    public decimal WF_Wrap_LS1_Form_FactorSF1 { get; set; }

    /// <summary>里烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "里烘缸")]
    public decimal WF_Wrap_LS2_Form_FactorSF2 { get; set; }

    /// <summary>WF_Wrap_LS3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_LS3_Form_Factor")]
    public decimal WF_Wrap_LS3_Form_Factor { get; set; }

    /// <summary>芯烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "芯烘缸")]
    public decimal WF_Wrap_MS1_Form_FactorSF1 { get; set; }

    /// <summary>芯烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "芯烘缸")]
    public decimal WF_Wrap_MS2_Form_FactorSF2 { get; set; }

    /// <summary>WF_Wrap_MS3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_MS3_Form_Factor")]
    public decimal WF_Wrap_MS3_Form_Factor { get; set; }

    /// <summary>一层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_0_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_0_Form_Factor { get; set; }

    /// <summary>二层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_1st_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_1st_Form_Factor { get; set; }

    /// <summary>三层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "三层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_2nd_Form_Factor { get; set; }

    /// <summary>WF_PreheaterSteam_GU_3rd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_3rd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PreheaterSteam_GU_3rd_Form_Factor")]
    public decimal WF_PreheaterSteam_GU_3rd_Form_Factor { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "蒸汽")]
    public decimal WF_PreheaterSteam_SF1_Form_FactorSF1 { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "蒸汽")]
    public decimal WF_PreheaterSteam_SF2_Form_FactorSF2 { get; set; }

    /// <summary>WF_PreheaterSteam_SF3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PreheaterSteam_SF3_Form_Factor")]
    public decimal WF_PreheaterSteam_SF3_Form_Factor { get; set; }

    /// <summary>压力辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF1_OS_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊操作侧")]
    public decimal WF_PressRoll_SF1_OS_Form_FactorSF1 { get; set; }

    /// <summary>压力辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF1_DS_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊驱动侧")]
    public decimal WF_PressRoll_SF1_DS_Form_FactorSF1 { get; set; }

    /// <summary>压力辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF2_OS_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊操作侧")]
    public decimal WF_PressRoll_SF2_OS_Form_FactorSF2 { get; set; }

    /// <summary>压力辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF2_DS_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊驱动侧")]
    public decimal WF_PressRoll_SF2_DS_Form_FactorSF2 { get; set; }

    /// <summary>WF_PressRoll_SF3_OS_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF3_OS_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PressRoll_SF3_OS_Form_Factor")]
    public decimal WF_PressRoll_SF3_OS_Form_Factor { get; set; }

    /// <summary>WF_PressRoll_SF3_DS_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF3_DS_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PressRoll_SF3_DS_Form_Factor")]
    public decimal WF_PressRoll_SF3_DS_Form_Factor { get; set; }

    /// <summary>瓦楞辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF1_OS_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊操作侧")]
    public decimal WF_CorrugatedRoll_SF1_OS_Form_FactorSF1 { get; set; }

    /// <summary>瓦楞辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF1_DS_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊驱动侧")]
    public decimal WF_CorrugatedRoll_SF1_DS_Form_FactorSF1 { get; set; }

    /// <summary>瓦楞辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF2_OS_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊操作侧")]
    public decimal WF_CorrugatedRoll_SF2_OS_Form_FactorSF2 { get; set; }

    /// <summary>瓦楞辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF2_DS_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊驱动侧")]
    public decimal WF_CorrugatedRoll_SF2_DS_Form_FactorSF2 { get; set; }

    /// <summary>WF_CorrugatedRoll_SF3_OS_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF3_OS_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CorrugatedRoll_SF3_OS_Form_Factor")]
    public decimal WF_CorrugatedRoll_SF3_OS_Form_Factor { get; set; }

    /// <summary>WF_CorrugatedRoll_SF3_DS_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF3_DS_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CorrugatedRoll_SF3_DS_Form_Factor")]
    public decimal WF_CorrugatedRoll_SF3_DS_Form_Factor { get; set; }

    /// <summary>一段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_1Part_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_1Part_Form_Factor { get; set; }

    /// <summary>二段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_2Part_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_2Part_Form_Factor { get; set; }

    /// <summary>三段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_3Part_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "三段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_3Part_Form_Factor { get; set; }

    /// <summary>热板组数</summary>
    [SugarColumn(ColumnName = "WF_HotLoadGroupQty_DF_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "热板组数")]
    public decimal WF_HotLoadGroupQty_DF_Form_Factor { get; set; }

    /// <summary>热板压力</summary>
    [SugarColumn(ColumnName = "WF_HotPlatePress_DF_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "热板压力")]
    public decimal WF_HotPlatePress_DF_Form_Factor { get; set; }

    /// <summary>冷板压力</summary>
    [SugarColumn(ColumnName = "WF_ColdPlatePress_DF_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "冷板压力")]
    public decimal WF_ColdPlatePress_DF_Form_Factor { get; set; }

    /// <summary>面纸张力</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS0_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸张力")]
    public decimal WF_SplicerTension_LS0_Form_Factor { get; set; }

    /// <summary>芯</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "芯")]
    public decimal WF_SplicerTension_MS1_Form_FactorSF1 { get; set; }

    /// <summary>里</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "里")]
    public decimal WF_SplicerTension_LS1_Form_FactorSF1 { get; set; }

    /// <summary>芯</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "芯")]
    public decimal WF_SplicerTension_MS2_Form_FactorSF2 { get; set; }

    /// <summary>里</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "里")]
    public decimal WF_SplicerTension_LS2_Form_FactorSF2 { get; set; }

    /// <summary>WF_SplicerTension_MS3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SplicerTension_MS3_Form_Factor")]
    public decimal WF_SplicerTension_MS3_Form_Factor { get; set; }

    /// <summary>WF_SplicerTension_LS3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SplicerTension_LS3_Form_Factor")]
    public decimal WF_SplicerTension_LS3_Form_Factor { get; set; }

    /// <summary>一层张力</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_1st_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层张力")]
    public decimal WF_BridgeTension_GU_1st_Form_Factor { get; set; }

    /// <summary>二层张力</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层张力")]
    public decimal WF_BridgeTension_GU_2nd_Form_Factor { get; set; }

    /// <summary>WF_BridgeTension_GU_3rd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_3rd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_BridgeTension_GU_3rd_Form_Factor")]
    public decimal WF_BridgeTension_GU_3rd_Form_Factor { get; set; }

    /// <summary>真空泵</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "真空泵")]
    public decimal WF_VacuumBlower_SF1_Form_FactorSF1 { get; set; }

    /// <summary>真空泵</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "真空泵")]
    public decimal WF_VacuumBlower_SF2_Form_FactorSF2 { get; set; }

    /// <summary>WF_VacuumBlower_SF3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_VacuumBlower_SF3_Form_Factor")]
    public decimal WF_VacuumBlower_SF3_Form_Factor { get; set; }

    /// <summary>上喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_0_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "上喷雾")]
    public decimal WF_Spray_GU_0_Form_Factor { get; set; }

    /// <summary>下喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "下喷雾")]
    public decimal WF_Spray_GU_2nd_Form_Factor { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF1_Form_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾")]
    public decimal WF_Spray_SF1_Form_FactorSF1 { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF2_Form_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾")]
    public decimal WF_Spray_SF2_Form_FactorSF2 { get; set; }

    /// <summary>WF_Spray_SF3_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF3_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Spray_SF3_Form_Factor")]
    public decimal WF_Spray_SF3_Form_Factor { get; set; }

    /// <summary>车速巡航</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_DF_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "车速巡航")]
    public decimal WF_CruisingSpeed_DF_Form_Factor { get; set; }

    /// <summary>WF_Glue_GU_1st_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_1st_Form_IsOpen", ColumnDescription = "WF_Glue_GU_1st_Form_IsOpen")]
    public bool WF_Glue_GU_1st_Form_IsOpen { get; set; }

    /// <summary>WF_Glue_GU_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_2nd_Form_IsOpen", ColumnDescription = "WF_Glue_GU_2nd_Form_IsOpen")]
    public bool WF_Glue_GU_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_Glue_GU_3rd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_3rd_Form_IsOpen", ColumnDescription = "WF_Glue_GU_3rd_Form_IsOpen")]
    public bool WF_Glue_GU_3rd_Form_IsOpen { get; set; }

    /// <summary>WF_Glue_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF1_Form_IsOpen", ColumnDescription = "WF_Glue_SF1_Form_IsOpen")]
    public bool WF_Glue_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_Glue_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF2_Form_IsOpen", ColumnDescription = "WF_Glue_SF2_Form_IsOpen")]
    public bool WF_Glue_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_Glue_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF3_Form_IsOpen", ColumnDescription = "WF_Glue_SF3_Form_IsOpen")]
    public bool WF_Glue_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_GU_0_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_0_Form_IsOpen", ColumnDescription = "WF_Wrap_GU_0_Form_IsOpen")]
    public bool WF_Wrap_GU_0_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_GU_1st_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_1st_Form_IsOpen", ColumnDescription = "WF_Wrap_GU_1st_Form_IsOpen")]
    public bool WF_Wrap_GU_1st_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_GU_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_2nd_Form_IsOpen", ColumnDescription = "WF_Wrap_GU_2nd_Form_IsOpen")]
    public bool WF_Wrap_GU_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_GU_3rd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_3rd_Form_IsOpen", ColumnDescription = "WF_Wrap_GU_3rd_Form_IsOpen")]
    public bool WF_Wrap_GU_3rd_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_LS1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS1_Form_IsOpen", ColumnDescription = "WF_Wrap_LS1_Form_IsOpen")]
    public bool WF_Wrap_LS1_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_LS2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS2_Form_IsOpen", ColumnDescription = "WF_Wrap_LS2_Form_IsOpen")]
    public bool WF_Wrap_LS2_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_LS3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS3_Form_IsOpen", ColumnDescription = "WF_Wrap_LS3_Form_IsOpen")]
    public bool WF_Wrap_LS3_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_MS1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS1_Form_IsOpen", ColumnDescription = "WF_Wrap_MS1_Form_IsOpen")]
    public bool WF_Wrap_MS1_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_MS2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS2_Form_IsOpen", ColumnDescription = "WF_Wrap_MS2_Form_IsOpen")]
    public bool WF_Wrap_MS2_Form_IsOpen { get; set; }

    /// <summary>WF_Wrap_MS3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS3_Form_IsOpen", ColumnDescription = "WF_Wrap_MS3_Form_IsOpen")]
    public bool WF_Wrap_MS3_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_GU_0_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_0_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_GU_0_Form_IsOpen")]
    public bool WF_PreheaterSteam_GU_0_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_GU_1st_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_1st_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_GU_1st_Form_IsOpen")]
    public bool WF_PreheaterSteam_GU_1st_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_GU_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_2nd_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_GU_2nd_Form_IsOpen")]
    public bool WF_PreheaterSteam_GU_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_GU_3rd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_3rd_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_GU_3rd_Form_IsOpen")]
    public bool WF_PreheaterSteam_GU_3rd_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF1_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_SF1_Form_IsOpen")]
    public bool WF_PreheaterSteam_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF2_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_SF2_Form_IsOpen")]
    public bool WF_PreheaterSteam_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_PreheaterSteam_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF3_Form_IsOpen", ColumnDescription = "WF_PreheaterSteam_SF3_Form_IsOpen")]
    public bool WF_PreheaterSteam_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_PressRoll_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF1_Form_IsOpen", ColumnDescription = "WF_PressRoll_SF1_Form_IsOpen")]
    public bool WF_PressRoll_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_PressRoll_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF2_Form_IsOpen", ColumnDescription = "WF_PressRoll_SF2_Form_IsOpen")]
    public bool WF_PressRoll_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_PressRoll_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF3_Form_IsOpen", ColumnDescription = "WF_PressRoll_SF3_Form_IsOpen")]
    public bool WF_PressRoll_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_CorrugatedRoll_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF1_Form_IsOpen", ColumnDescription = "WF_CorrugatedRoll_SF1_Form_IsOpen")]
    public bool WF_CorrugatedRoll_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_CorrugatedRoll_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF2_Form_IsOpen", ColumnDescription = "WF_CorrugatedRoll_SF2_Form_IsOpen")]
    public bool WF_CorrugatedRoll_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_CorrugatedRoll_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF3_Form_IsOpen", ColumnDescription = "WF_CorrugatedRoll_SF3_Form_IsOpen")]
    public bool WF_CorrugatedRoll_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_HotPlateSteam_DF_1Part_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_1Part_Form_IsOpen", ColumnDescription = "WF_HotPlateSteam_DF_1Part_Form_IsOpen")]
    public bool WF_HotPlateSteam_DF_1Part_Form_IsOpen { get; set; }

    /// <summary>WF_HotPlateSteam_DF_2Part_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_2Part_Form_IsOpen", ColumnDescription = "WF_HotPlateSteam_DF_2Part_Form_IsOpen")]
    public bool WF_HotPlateSteam_DF_2Part_Form_IsOpen { get; set; }

    /// <summary>WF_HotPlateSteam_DF_3Part_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_3Part_Form_IsOpen", ColumnDescription = "WF_HotPlateSteam_DF_3Part_Form_IsOpen")]
    public bool WF_HotPlateSteam_DF_3Part_Form_IsOpen { get; set; }

    /// <summary>_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_HotLoadGroupQty_DF_Form", ColumnDescription = "_IsOpen")]
    public bool WF_HotLoadGroupQty_DF_Form { get; set; }

    /// <summary>WF_HotPlatePress_DF_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_HotPlatePress_DF_Form_IsOpen", ColumnDescription = "WF_HotPlatePress_DF_Form_IsOpen")]
    public bool WF_HotPlatePress_DF_Form_IsOpen { get; set; }

    /// <summary>WF_ColdPlatePress_DF_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_ColdPlatePress_DF_Form_IsOpen", ColumnDescription = "WF_ColdPlatePress_DF_Form_IsOpen")]
    public bool WF_ColdPlatePress_DF_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_LS0_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS0_Form_IsOpen", ColumnDescription = "WF_SplicerTension_LS0_Form_IsOpen")]
    public bool WF_SplicerTension_LS0_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_MS1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS1_Form_IsOpen", ColumnDescription = "WF_SplicerTension_MS1_Form_IsOpen")]
    public bool WF_SplicerTension_MS1_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_LS1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS1_Form_IsOpen", ColumnDescription = "WF_SplicerTension_LS1_Form_IsOpen")]
    public bool WF_SplicerTension_LS1_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_MS2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS2_Form_IsOpen", ColumnDescription = "WF_SplicerTension_MS2_Form_IsOpen")]
    public bool WF_SplicerTension_MS2_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_LS2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS2_Form_IsOpen", ColumnDescription = "WF_SplicerTension_LS2_Form_IsOpen")]
    public bool WF_SplicerTension_LS2_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_MS3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS3_Form_IsOpen", ColumnDescription = "WF_SplicerTension_MS3_Form_IsOpen")]
    public bool WF_SplicerTension_MS3_Form_IsOpen { get; set; }

    /// <summary>WF_SplicerTension_LS3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS3_Form_IsOpen", ColumnDescription = "WF_SplicerTension_LS3_Form_IsOpen")]
    public bool WF_SplicerTension_LS3_Form_IsOpen { get; set; }

    /// <summary>WF_BridgeTension_GU_1st_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_1st_Form_IsOpen", ColumnDescription = "WF_BridgeTension_GU_1st_Form_IsOpen")]
    public bool WF_BridgeTension_GU_1st_Form_IsOpen { get; set; }

    /// <summary>WF_BridgeTension_GU_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_2nd_Form_IsOpen", ColumnDescription = "WF_BridgeTension_GU_2nd_Form_IsOpen")]
    public bool WF_BridgeTension_GU_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_BridgeTension_GU_3rd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_3rd_Form_IsOpen", ColumnDescription = "WF_BridgeTension_GU_3rd_Form_IsOpen")]
    public bool WF_BridgeTension_GU_3rd_Form_IsOpen { get; set; }

    /// <summary>WF_VacuumBlower_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF1_Form_IsOpen", ColumnDescription = "WF_VacuumBlower_SF1_Form_IsOpen")]
    public bool WF_VacuumBlower_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_VacuumBlower_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF2_Form_IsOpen", ColumnDescription = "WF_VacuumBlower_SF2_Form_IsOpen")]
    public bool WF_VacuumBlower_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_VacuumBlower_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF3_Form_IsOpen", ColumnDescription = "WF_VacuumBlower_SF3_Form_IsOpen")]
    public bool WF_VacuumBlower_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_Spray_GU_0_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_0_Form_IsOpen", ColumnDescription = "WF_Spray_GU_0_Form_IsOpen")]
    public bool WF_Spray_GU_0_Form_IsOpen { get; set; }

    /// <summary>WF_Spray_GU_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_2nd_Form_IsOpen", ColumnDescription = "WF_Spray_GU_2nd_Form_IsOpen")]
    public bool WF_Spray_GU_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_Spray_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF1_Form_IsOpen", ColumnDescription = "WF_Spray_SF1_Form_IsOpen")]
    public bool WF_Spray_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_Spray_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF2_Form_IsOpen", ColumnDescription = "WF_Spray_SF2_Form_IsOpen")]
    public bool WF_Spray_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_Spray_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF3_Form_IsOpen", ColumnDescription = "WF_Spray_SF3_Form_IsOpen")]
    public bool WF_Spray_SF3_Form_IsOpen { get; set; }

    /// <summary>WF_CruisingSpeed_ALL_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_ALL_Form_IsOpen", ColumnDescription = "WF_CruisingSpeed_ALL_Form_IsOpen")]
    public bool WF_CruisingSpeed_ALL_Form_IsOpen { get; set; }

    /// <summary>WF_CruisingSpeed_DF_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_DF_Form_IsOpen", ColumnDescription = "WF_CruisingSpeed_DF_Form_IsOpen")]
    public bool WF_CruisingSpeed_DF_Form_IsOpen { get; set; }

    /// <summary>WF_CruisingSpeed_SF1_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_SF1_Form_IsOpen", ColumnDescription = "WF_CruisingSpeed_SF1_Form_IsOpen")]
    public bool WF_CruisingSpeed_SF1_Form_IsOpen { get; set; }

    /// <summary>WF_CruisingSpeed_SF2_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_SF2_Form_IsOpen", ColumnDescription = "WF_CruisingSpeed_SF2_Form_IsOpen")]
    public bool WF_CruisingSpeed_SF2_Form_IsOpen { get; set; }

    /// <summary>WF_CruisingSpeed_SF3_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_SF3_Form_IsOpen", ColumnDescription = "WF_CruisingSpeed_SF3_Form_IsOpen")]
    public bool WF_CruisingSpeed_SF3_Form_IsOpen { get; set; }

    /// <summary>糊机胶水系数</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_1st_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "糊机胶水系数")]
    public decimal WF_Glue_GU_1st_FormQdm_Factor { get; set; }

    /// <summary>二层糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_2nd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层糊间隙")]
    public decimal WF_Glue_GU_2nd_FormQdm_Factor { get; set; }

    /// <summary>WF_Glue_GU_3rd_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_3rd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Glue_GU_3rd_FormQdm_Factor")]
    public decimal WF_Glue_GU_3rd_FormQdm_Factor { get; set; }

    /// <summary>糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "糊间隙")]
    public decimal WF_Glue_SF1_FormQdm_FactorSF1 { get; set; }

    /// <summary>糊间隙</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "糊间隙")]
    public decimal WF_Glue_SF2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_Glue_SF3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Glue_SF3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Glue_SF3_FormQdm_Factor")]
    public decimal WF_Glue_SF3_FormQdm_Factor { get; set; }

    /// <summary>面纸烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_0_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸烘缸")]
    public decimal WF_Wrap_GU_0_FormQdm_Factor { get; set; }

    /// <summary>一层烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_1st_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层烘缸")]
    public decimal WF_Wrap_GU_1st_FormQdm_Factor { get; set; }

    /// <summary>二层烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_2nd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层烘缸")]
    public decimal WF_Wrap_GU_2nd_FormQdm_Factor { get; set; }

    /// <summary>WF_Wrap_GU_3rd_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_3rd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_GU_3rd_FormQdm_Factor")]
    public decimal WF_Wrap_GU_3rd_FormQdm_Factor { get; set; }

    /// <summary>里烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "里烘缸")]
    public decimal WF_Wrap_LS1_FormQdm_FactorSF1 { get; set; }

    /// <summary>里烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "里烘缸")]
    public decimal WF_Wrap_LS2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_Wrap_LS3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_LS3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_LS3_FormQdm_Factor")]
    public decimal WF_Wrap_LS3_FormQdm_Factor { get; set; }

    /// <summary>芯烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "芯烘缸")]
    public decimal WF_Wrap_MS1_FormQdm_FactorSF1 { get; set; }

    /// <summary>芯烘缸</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "芯烘缸")]
    public decimal WF_Wrap_MS2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_Wrap_MS3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Wrap_MS3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Wrap_MS3_FormQdm_Factor")]
    public decimal WF_Wrap_MS3_FormQdm_Factor { get; set; }

    /// <summary>一层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_0_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_0_FormQdm_Factor { get; set; }

    /// <summary>二层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_1st_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_1st_FormQdm_Factor { get; set; }

    /// <summary>三层烘缸蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_2nd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "三层烘缸蒸汽")]
    public decimal WF_PreheaterSteam_GU_2nd_FormQdm_Factor { get; set; }

    /// <summary>WF_PreheaterSteam_GU_3rd_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_GU_3rd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PreheaterSteam_GU_3rd_FormQdm_Factor")]
    public decimal WF_PreheaterSteam_GU_3rd_FormQdm_Factor { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "蒸汽")]
    public decimal WF_PreheaterSteam_SF1_FormQdm_FactorSF1 { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "蒸汽")]
    public decimal WF_PreheaterSteam_SF2_FormQdm_FactorSF2 { get; set; }

    /// <summary>Qdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_PreheaterSteam_SF3_Form", Length = 18, DecimalDigits = 2, ColumnDescription = "Qdm_Factor")]
    public decimal WF_PreheaterSteam_SF3_Form { get; set; }

    /// <summary>压力辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF1_OS_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊操作侧")]
    public decimal WF_PressRoll_SF1_OS_FormQdm_FactorSF1 { get; set; }

    /// <summary>压力辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF1_DS_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊驱动侧")]
    public decimal WF_PressRoll_SF1_DS_FormQdm_FactorSF1 { get; set; }

    /// <summary>压力辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF2_OS_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊操作侧")]
    public decimal WF_PressRoll_SF2_OS_FormQdm_FactorSF2 { get; set; }

    /// <summary>压力辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF2_DS_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊驱动侧")]
    public decimal WF_PressRoll_SF2_DS_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_PressRoll_SF3_OS_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF3_OS_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PressRoll_SF3_OS_FormQdm_Factor")]
    public decimal WF_PressRoll_SF3_OS_FormQdm_Factor { get; set; }

    /// <summary>WF_PressRoll_SF3_DS_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_PressRoll_SF3_DS_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_PressRoll_SF3_DS_FormQdm_Factor")]
    public decimal WF_PressRoll_SF3_DS_FormQdm_Factor { get; set; }

    /// <summary>瓦楞辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF1_OS_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊操作侧")]
    public decimal WF_CorrugatedRoll_SF1_OS_FormQdm_FactorSF1 { get; set; }

    /// <summary>瓦楞辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF1_DS_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊驱动侧")]
    public decimal WF_CorrugatedRoll_SF1_DS_FormQdm_FactorSF1 { get; set; }

    /// <summary>瓦楞辊操作侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF2_OS_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊操作侧")]
    public decimal WF_CorrugatedRoll_SF2_OS_FormQdm_FactorSF2 { get; set; }

    /// <summary>瓦楞辊驱动侧</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF2_DS_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊驱动侧")]
    public decimal WF_CorrugatedRoll_SF2_DS_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_CorrugatedRoll_SF3_OS_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF3_OS_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CorrugatedRoll_SF3_OS_FormQdm_Factor")]
    public decimal WF_CorrugatedRoll_SF3_OS_FormQdm_Factor { get; set; }

    /// <summary>WF_CorrugatedRoll_SF3_DS_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRoll_SF3_DS_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_CorrugatedRoll_SF3_DS_FormQdm_Factor")]
    public decimal WF_CorrugatedRoll_SF3_DS_FormQdm_Factor { get; set; }

    /// <summary>一段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_1Part_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_1Part_FormQdm_Factor { get; set; }

    /// <summary>二段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_2Part_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_2Part_FormQdm_Factor { get; set; }

    /// <summary>三段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam_DF_3Part_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "三段热板蒸汽")]
    public decimal WF_HotPlateSteam_DF_3Part_FormQdm_Factor { get; set; }

    /// <summary>热板组数</summary>
    [SugarColumn(ColumnName = "WF_HotLoadGroupQty_DF_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "热板组数")]
    public decimal WF_HotLoadGroupQty_DF_FormQdm_Factor { get; set; }

    /// <summary>热板压力</summary>
    [SugarColumn(ColumnName = "WF_HotPlatePress_DF_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "热板压力")]
    public decimal WF_HotPlatePress_DF_FormQdm_Factor { get; set; }

    /// <summary>冷板压力</summary>
    [SugarColumn(ColumnName = "WF_ColdPlatePress_DF_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "冷板压力")]
    public decimal WF_ColdPlatePress_DF_FormQdm_Factor { get; set; }

    /// <summary>面纸张力</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS0_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸张力")]
    public decimal WF_SplicerTension_LS0_FormQdm_Factor { get; set; }

    /// <summary>芯</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "芯")]
    public decimal WF_SplicerTension_MS1_FormQdm_FactorSF1 { get; set; }

    /// <summary>里</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "里")]
    public decimal WF_SplicerTension_LS1_FormQdm_FactorSF1 { get; set; }

    /// <summary>芯</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "芯")]
    public decimal WF_SplicerTension_MS2_FormQdm_FactorSF2 { get; set; }

    /// <summary>里</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "里")]
    public decimal WF_SplicerTension_LS2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_SplicerTension_MS3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_MS3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SplicerTension_MS3_FormQdm_Factor")]
    public decimal WF_SplicerTension_MS3_FormQdm_Factor { get; set; }

    /// <summary>WF_SplicerTension_LS3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_SplicerTension_LS3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SplicerTension_LS3_FormQdm_Factor")]
    public decimal WF_SplicerTension_LS3_FormQdm_Factor { get; set; }

    /// <summary>一层张力</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_1st_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "一层张力")]
    public decimal WF_BridgeTension_GU_1st_FormQdm_Factor { get; set; }

    /// <summary>二层张力</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_2nd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "二层张力")]
    public decimal WF_BridgeTension_GU_2nd_FormQdm_Factor { get; set; }

    /// <summary>WF_BridgeTension_GU_3rd_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_BridgeTension_GU_3rd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_BridgeTension_GU_3rd_FormQdm_Factor")]
    public decimal WF_BridgeTension_GU_3rd_FormQdm_Factor { get; set; }

    /// <summary>真空泵</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "真空泵")]
    public decimal WF_VacuumBlower_SF1_FormQdm_FactorSF1 { get; set; }

    /// <summary>真空泵</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "真空泵")]
    public decimal WF_VacuumBlower_SF2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_VacuumBlower_SF3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_VacuumBlower_SF3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_VacuumBlower_SF3_FormQdm_Factor")]
    public decimal WF_VacuumBlower_SF3_FormQdm_Factor { get; set; }

    /// <summary>上喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_0_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "上喷雾")]
    public decimal WF_Spray_GU_0_FormQdm_Factor { get; set; }

    /// <summary>下喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_GU_2nd_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "下喷雾")]
    public decimal WF_Spray_GU_2nd_FormQdm_Factor { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF1_FormQdm_FactorSF1", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾")]
    public decimal WF_Spray_SF1_FormQdm_FactorSF1 { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF2_FormQdm_FactorSF2", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾")]
    public decimal WF_Spray_SF2_FormQdm_FactorSF2 { get; set; }

    /// <summary>WF_Spray_SF3_FormQdm_Factor</summary>
    [SugarColumn(ColumnName = "WF_Spray_SF3_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Spray_SF3_FormQdm_Factor")]
    public decimal WF_Spray_SF3_FormQdm_Factor { get; set; }

    /// <summary>车速巡航</summary>
    [SugarColumn(ColumnName = "WF_CruisingSpeed_DF_FormQdm_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "车速巡航")]
    public decimal WF_CruisingSpeed_DF_FormQdm_Factor { get; set; }

    /// <summary>WF_Glue_GU_1st_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_1st_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Glue_GU_1st_Form_IsOn")]
    public bool? WF_Glue_GU_1st_Form_IsOn { get; set; }

    /// <summary>WF_Glue_GU_2nd_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_2nd_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Glue_GU_2nd_Form_IsOn")]
    public bool? WF_Glue_GU_2nd_Form_IsOn { get; set; }

    /// <summary>WF_Glue_GU_3rd_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Glue_GU_3rd_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Glue_GU_3rd_Form_IsOn")]
    public bool? WF_Glue_GU_3rd_Form_IsOn { get; set; }

    /// <summary>WF_Wrap_GU_1st_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_1st_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Wrap_GU_1st_Form_IsOn")]
    public bool? WF_Wrap_GU_1st_Form_IsOn { get; set; }

    /// <summary>WF_Wrap_GU_2nd_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_2nd_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Wrap_GU_2nd_Form_IsOn")]
    public bool? WF_Wrap_GU_2nd_Form_IsOn { get; set; }

    /// <summary>WF_Wrap_GU_3rd_Form_IsOn</summary>
    [SugarColumn(ColumnName = "WF_Wrap_GU_3rd_Form_IsOn", IsNullable = true, ColumnDescription = "WF_Wrap_GU_3rd_Form_IsOn")]
    public bool? WF_Wrap_GU_3rd_Form_IsOn { get; set; }

    /// <summary>WF_RidingRoll_1st_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_1st_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_RidingRoll_1st_Form_Factor")]
    public decimal WF_RidingRoll_1st_Form_Factor { get; set; }

    /// <summary>WF_RidingRoll_2nd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_2nd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_RidingRoll_2nd_Form_Factor")]
    public decimal WF_RidingRoll_2nd_Form_Factor { get; set; }

    /// <summary>WF_RidingRoll_3rd_Form_Factor</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_3rd_Form_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_RidingRoll_3rd_Form_Factor")]
    public decimal WF_RidingRoll_3rd_Form_Factor { get; set; }

    /// <summary>WF_RidingRoll_1st_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_1st_Form_IsOpen", ColumnDescription = "WF_RidingRoll_1st_Form_IsOpen")]
    public bool WF_RidingRoll_1st_Form_IsOpen { get; set; }

    /// <summary>WF_RidingRoll_2nd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_2nd_Form_IsOpen", ColumnDescription = "WF_RidingRoll_2nd_Form_IsOpen")]
    public bool WF_RidingRoll_2nd_Form_IsOpen { get; set; }

    /// <summary>WF_RidingRoll_3rd_Form_IsOpen</summary>
    [SugarColumn(ColumnName = "WF_RidingRoll_3rd_Form_IsOpen", ColumnDescription = "WF_RidingRoll_3rd_Form_IsOpen")]
    public bool WF_RidingRoll_3rd_Form_IsOpen { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

    /// <summary>弯翘自动开关</summary>
    [SugarColumn(ColumnName = "WF_Warp_Form_IsOpen", ColumnDescription = "弯翘自动开关", DefaultValue = "false")]
    public bool WF_Warp_Form_IsOpen { get; set; }

}