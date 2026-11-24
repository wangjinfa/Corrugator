using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 单面机QDM系数
/// </summary>
[SugarTable("TB_IPS_QdmCoefSF", TableDescription = "单面机QDM系数")]
public class TB_IPS_QdmCoefSF
{
    /// <summary>芯纸材质</summary>
    [SugarColumn(ColumnName = "F_MS", Length = 10, ColumnDescription = "芯纸材质")]
    public string F_MS { get; set; } = default!;

    /// <summary>里纸材质</summary>
    [SugarColumn(ColumnName = "F_LS", Length = 10, ColumnDescription = "里纸材质")]
    public string F_LS { get; set; } = default!;

    /// <summary>单瓦楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "单瓦楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>糊间隙系数</summary>
    [SugarColumn(ColumnName = "F_Glue", Length = 18, DecimalDigits = 2, ColumnDescription = "糊间隙系数")]
    public decimal F_Glue { get; set; }

    /// <summary>芯纸包角系数</summary>
    [SugarColumn(ColumnName = "F_WrapMS", Length = 18, DecimalDigits = 2, ColumnDescription = "芯纸包角系数")]
    public decimal F_WrapMS { get; set; }

    /// <summary>里纸包角系数</summary>
    [SugarColumn(ColumnName = "F_WrapLS", Length = 18, DecimalDigits = 2, ColumnDescription = "里纸包角系数")]
    public decimal F_WrapLS { get; set; }

    /// <summary>烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam", Length = 18, DecimalDigits = 2, ColumnDescription = "烘缸蒸汽系数")]
    public decimal F_PreheaterSteam { get; set; }

    /// <summary>压力辊系数</summary>
    [SugarColumn(ColumnName = "F_PressRoll", Length = 18, DecimalDigits = 2, ColumnDescription = "压力辊系数")]
    public decimal F_PressRoll { get; set; }

    /// <summary>瓦楞辊系数</summary>
    [SugarColumn(ColumnName = "F_CorrugatedRoll", Length = 18, DecimalDigits = 2, ColumnDescription = "瓦楞辊系数")]
    public decimal F_CorrugatedRoll { get; set; }

    /// <summary>芯纸张力系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTensionMS", Length = 18, DecimalDigits = 2, ColumnDescription = "芯纸张力系数")]
    public decimal F_SplicerTensionMS { get; set; }

    /// <summary>里纸张力系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTensionLS", Length = 18, DecimalDigits = 2, ColumnDescription = "里纸张力系数")]
    public decimal F_SplicerTensionLS { get; set; }

    /// <summary>真空吹风机系数</summary>
    [SugarColumn(ColumnName = "F_VacuumBlower", Length = 18, DecimalDigits = 2, ColumnDescription = "真空吹风机系数")]
    public decimal F_VacuumBlower { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾系数")]
    public decimal F_Spray { get; set; }

    /// <summary>巡航系数</summary>
    [SugarColumn(ColumnName = "F_CruiseSpeed", Length = 18, DecimalDigits = 2, ColumnDescription = "巡航系数")]
    public decimal F_CruiseSpeed { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}