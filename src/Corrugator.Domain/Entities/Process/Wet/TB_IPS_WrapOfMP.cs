using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 包角基础设置表
/// </summary>
[SugarTable("W_IPS_WrapOfMP", TableDescription = "包角基础设置表")]
public class W_IPS_WrapOfMP
{
    /// <summary>0-->面纸；1-->夹层；2-->上层</summary>
    [SugarColumn(ColumnName = "WF_Flag", ColumnDescription = "0-->面纸；1-->夹层；2-->上层")]
    public int WF_Flag { get; set; }

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", ColumnDescription = "部位")]
    public int WF_Position { get; set; }

    /// <summary>最小包角</summary>
    [SugarColumn(ColumnName = "WF_MinWrap", ColumnDescription = "最小包角")]
    public int WF_MinWrap { get; set; }

    /// <summary>最大包角</summary>
    [SugarColumn(ColumnName = "WF_MaxWrap", ColumnDescription = "最大包角")]
    public int WF_MaxWrap { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinWeight", ColumnDescription = "最小克重")]
    public int WF_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxWeight", ColumnDescription = "最大克重")]
    public int WF_MaxWeight { get; set; }

    /// <summary>单楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "单楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "楞型系数")]
    public decimal? WF_Coef { get; set; }

    /// <summary>调整允许范围</summary>
    [SugarColumn(ColumnName = "WF_AdustRange", Length = 18, DecimalDigits = 2, ColumnDescription = "调整允许范围")]
    public decimal WF_AdustRange { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}