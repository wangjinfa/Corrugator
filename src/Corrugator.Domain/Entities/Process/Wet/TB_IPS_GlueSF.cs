using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 单面机糊间隙设置
/// </summary>
[SugarTable("TB_IPS_GlueSF", TableDescription = "单面机糊间隙设置")]
public class TB_IPS_GlueSF
{
    /// <summary>单瓦楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "单瓦楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小糊间隙</summary>
    [SugarColumn(ColumnName = "F_MinGlue", ColumnDescription = "最小糊间隙")]
    public int F_MinGlue { get; set; }

    /// <summary>最大糊间隙</summary>
    [SugarColumn(ColumnName = "F_MaxGlue", ColumnDescription = "最大糊间隙")]
    public int F_MaxGlue { get; set; }

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