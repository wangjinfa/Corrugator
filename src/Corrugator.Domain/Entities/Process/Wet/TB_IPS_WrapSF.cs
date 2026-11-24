using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 单面机烘缸包角设置
/// </summary>
[SugarTable("TB_IPS_WrapSF", TableDescription = "单面机烘缸包角设置")]
public class TB_IPS_WrapSF
{
    /// <summary>纸张位置（芯纸MS or 里纸LS）</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 10, ColumnDescription = "纸张位置（芯纸MS or 里纸LS）")]
    public string F_Position { get; set; } = default!;

    /// <summary>单瓦楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "单瓦楞型")]
    public string F_Flute { get; set; } = default!;

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

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "楞型系数")]
    public decimal F_Coef { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}