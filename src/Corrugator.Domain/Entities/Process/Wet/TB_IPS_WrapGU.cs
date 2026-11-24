using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊机烘缸包角设置
/// </summary>
[SugarTable("W_IPS_WrapGU", TableDescription = "糊机烘缸包角设置")]
public class W_IPS_WrapGU
{
    /// <summary>纸张位置（面纸=0，1层=1，2层=2，3层=3）</summary>
    [SugarColumn(ColumnName = "WF_Position", ColumnDescription = "纸张位置（面纸=0，1层=1，2层=2，3层=3）")]
    public int WF_Position { get; set; }

    /// <summary>订单楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 10, ColumnDescription = "订单楞型")]
    public string WF_Flute { get; set; } = default!;

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

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "楞型系数")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}