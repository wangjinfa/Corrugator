using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 天桥张力设置
/// </summary>
[SugarTable("TB_IPS_BridgeTension", TableDescription = "天桥张力设置")]
public class TB_IPS_BridgeTension
{
    /// <summary>纸张位置（1层=1，2层=2，3层=3）</summary>
    [SugarColumn(ColumnName = "F_Position", ColumnDescription = "纸张位置（1层=1，2层=2，3层=3）")]
    public int F_Position { get; set; }

    /// <summary>订单楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "订单楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小张力</summary>
    [SugarColumn(ColumnName = "F_MinValue", ColumnDescription = "最小张力")]
    public int F_MinValue { get; set; }

    /// <summary>最大张力</summary>
    [SugarColumn(ColumnName = "F_MaxValue", ColumnDescription = "最大张力")]
    public int F_MaxValue { get; set; }

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