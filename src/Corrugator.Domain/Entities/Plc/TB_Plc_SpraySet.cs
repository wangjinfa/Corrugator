using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷雾设置
/// </summary>
[SugarTable("W_Plc_SpraySet", TableDescription = "PLC喷雾设置")]
public class W_Plc_SpraySet
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 10, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小功率</summary>
    [SugarColumn(ColumnName = "WF_MinPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最小功率")]
    public decimal WF_MinPower { get; set; }

    /// <summary>最大功率</summary>
    [SugarColumn(ColumnName = "WF_MaxPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最大功率")]
    public decimal WF_MaxPower { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>上喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_CoefUp", Length = 18, DecimalDigits = 2, ColumnDescription = "上喷雾系数")]
    public decimal WF_CoefUp { get; set; }

    /// <summary>中层喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_CoefMid", Length = 18, DecimalDigits = 2, ColumnDescription = "中层喷雾系数")]
    public decimal WF_CoefMid { get; set; }

    /// <summary>下层喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_CoefDown", Length = 18, DecimalDigits = 2, ColumnDescription = "下层喷雾系数")]
    public decimal WF_CoefDown { get; set; }

    /// <summary>大带喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_CoefDF", Length = 18, DecimalDigits = 2, ColumnDescription = "大带喷雾系数")]
    public decimal WF_CoefDF { get; set; }

    /// <summary>速度30系数</summary>
    [SugarColumn(ColumnName = "WF_Speed30", Length = 18, DecimalDigits = 2, ColumnDescription = "速度30系数")]
    public decimal WF_Speed30 { get; set; }

    /// <summary>速度50系数</summary>
    [SugarColumn(ColumnName = "WF_Speed50", Length = 18, DecimalDigits = 2, ColumnDescription = "速度50系数")]
    public decimal WF_Speed50 { get; set; }

    /// <summary>速度80系数</summary>
    [SugarColumn(ColumnName = "WF_Speed80", Length = 18, DecimalDigits = 2, ColumnDescription = "速度80系数")]
    public decimal WF_Speed80 { get; set; }

    /// <summary>速度110系数</summary>
    [SugarColumn(ColumnName = "WF_Speed110", Length = 18, DecimalDigits = 2, ColumnDescription = "速度110系数")]
    public decimal WF_Speed110 { get; set; }

    /// <summary>速度130系数</summary>
    [SugarColumn(ColumnName = "WF_Speed130", Length = 18, DecimalDigits = 2, ColumnDescription = "速度130系数")]
    public decimal WF_Speed130 { get; set; }

    /// <summary>速度160系数</summary>
    [SugarColumn(ColumnName = "WF_Speed160", Length = 18, DecimalDigits = 2, ColumnDescription = "速度160系数")]
    public decimal WF_Speed160 { get; set; }

    /// <summary>速度180系数</summary>
    [SugarColumn(ColumnName = "WF_Speed180", Length = 18, DecimalDigits = 2, ColumnDescription = "速度180系数")]
    public decimal WF_Speed180 { get; set; }

    /// <summary>速度210系数</summary>
    [SugarColumn(ColumnName = "WF_Speed210", Length = 18, DecimalDigits = 2, ColumnDescription = "速度210系数")]
    public decimal WF_Speed210 { get; set; }

    /// <summary>速度240系数</summary>
    [SugarColumn(ColumnName = "WF_Speed240", Length = 18, DecimalDigits = 2, ColumnDescription = "速度240系数")]
    public decimal WF_Speed240 { get; set; }

    /// <summary>速度270系数</summary>
    [SugarColumn(ColumnName = "WF_Speed270", Length = 18, DecimalDigits = 2, ColumnDescription = "速度270系数")]
    public decimal WF_Speed270 { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}