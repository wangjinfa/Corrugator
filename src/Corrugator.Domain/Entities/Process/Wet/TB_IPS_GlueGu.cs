using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊机糊间隙基础设置表
/// </summary>
[SugarTable("TB_IPS_GlueGu", TableDescription = "糊机糊间隙基础设置表")]
public class TB_IPS_GlueGu
{
    /// <summary>订单楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "订单楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>纸张部位(1=1层，2=2层，3=3层)</summary>
    [SugarColumn(ColumnName = "F_Position", ColumnDescription = "纸张部位(1=1层，2=2层，3=3层)")]
    public int F_Position { get; set; }

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