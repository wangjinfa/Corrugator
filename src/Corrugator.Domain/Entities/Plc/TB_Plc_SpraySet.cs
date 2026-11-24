using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷雾设置
/// </summary>
[SugarTable("TB_Plc_SpraySet", TableDescription = "PLC喷雾设置")]
public class TB_Plc_SpraySet
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小功率</summary>
    [SugarColumn(ColumnName = "F_MinPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最小功率")]
    public decimal F_MinPower { get; set; }

    /// <summary>最大功率</summary>
    [SugarColumn(ColumnName = "F_MaxPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最大功率")]
    public decimal F_MaxPower { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal F_MaxGram { get; set; }

    /// <summary>上喷雾系数</summary>
    [SugarColumn(ColumnName = "F_CoefUp", Length = 18, DecimalDigits = 2, ColumnDescription = "上喷雾系数")]
    public decimal F_CoefUp { get; set; }

    /// <summary>中层喷雾系数</summary>
    [SugarColumn(ColumnName = "F_CoefMid", Length = 18, DecimalDigits = 2, ColumnDescription = "中层喷雾系数")]
    public decimal F_CoefMid { get; set; }

    /// <summary>下层喷雾系数</summary>
    [SugarColumn(ColumnName = "F_CoefDown", Length = 18, DecimalDigits = 2, ColumnDescription = "下层喷雾系数")]
    public decimal F_CoefDown { get; set; }

    /// <summary>大带喷雾系数</summary>
    [SugarColumn(ColumnName = "F_CoefDF", Length = 18, DecimalDigits = 2, ColumnDescription = "大带喷雾系数")]
    public decimal F_CoefDF { get; set; }

    /// <summary>速度30系数</summary>
    [SugarColumn(ColumnName = "F_Speed30", Length = 18, DecimalDigits = 2, ColumnDescription = "速度30系数")]
    public decimal F_Speed30 { get; set; }

    /// <summary>速度50系数</summary>
    [SugarColumn(ColumnName = "F_Speed50", Length = 18, DecimalDigits = 2, ColumnDescription = "速度50系数")]
    public decimal F_Speed50 { get; set; }

    /// <summary>速度80系数</summary>
    [SugarColumn(ColumnName = "F_Speed80", Length = 18, DecimalDigits = 2, ColumnDescription = "速度80系数")]
    public decimal F_Speed80 { get; set; }

    /// <summary>速度110系数</summary>
    [SugarColumn(ColumnName = "F_Speed110", Length = 18, DecimalDigits = 2, ColumnDescription = "速度110系数")]
    public decimal F_Speed110 { get; set; }

    /// <summary>速度130系数</summary>
    [SugarColumn(ColumnName = "F_Speed130", Length = 18, DecimalDigits = 2, ColumnDescription = "速度130系数")]
    public decimal F_Speed130 { get; set; }

    /// <summary>速度160系数</summary>
    [SugarColumn(ColumnName = "F_Speed160", Length = 18, DecimalDigits = 2, ColumnDescription = "速度160系数")]
    public decimal F_Speed160 { get; set; }

    /// <summary>速度180系数</summary>
    [SugarColumn(ColumnName = "F_Speed180", Length = 18, DecimalDigits = 2, ColumnDescription = "速度180系数")]
    public decimal F_Speed180 { get; set; }

    /// <summary>速度210系数</summary>
    [SugarColumn(ColumnName = "F_Speed210", Length = 18, DecimalDigits = 2, ColumnDescription = "速度210系数")]
    public decimal F_Speed210 { get; set; }

    /// <summary>速度240系数</summary>
    [SugarColumn(ColumnName = "F_Speed240", Length = 18, DecimalDigits = 2, ColumnDescription = "速度240系数")]
    public decimal F_Speed240 { get; set; }

    /// <summary>速度270系数</summary>
    [SugarColumn(ColumnName = "F_Speed270", Length = 18, DecimalDigits = 2, ColumnDescription = "速度270系数")]
    public decimal F_Speed270 { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}