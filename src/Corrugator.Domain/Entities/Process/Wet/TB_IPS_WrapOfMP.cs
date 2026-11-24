using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 包角基础设置表
/// </summary>
[SugarTable("TB_IPS_WrapOfMP", TableDescription = "包角基础设置表")]
public class TB_IPS_WrapOfMP
{
    /// <summary>0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "F_Flag", ColumnDescription = "0-->面纸；1-->夹层；2-->上层")]
    public int F_Flag { get; set; }

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", ColumnDescription = "部位")]
    public int F_Position { get; set; }

    /// <summary>最小包角</summary>
    [SugarColumn(ColumnName = "F_MinWrap", ColumnDescription = "最小包角")]
    public int F_MinWrap { get; set; }

    /// <summary>最大包角</summary>
    [SugarColumn(ColumnName = "F_MaxWrap", ColumnDescription = "最大包角")]
    public int F_MaxWrap { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinWeight", ColumnDescription = "最小克重")]
    public int F_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxWeight", ColumnDescription = "最大克重")]
    public int F_MaxWeight { get; set; }

    /// <summary>单楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "单楞型")]
    public string? F_Flute { get; set; }

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "楞型系数")]
    public decimal? F_Coef { get; set; }

    /// <summary>调整允许范围</summary>
    [SugarColumn(ColumnName = "F_AdustRange", Length = 18, DecimalDigits = 2, ColumnDescription = "调整允许范围")]
    public decimal F_AdustRange { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}