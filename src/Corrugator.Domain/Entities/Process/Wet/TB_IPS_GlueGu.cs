using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊机糊间隙基础设置表
/// </summary>
[SugarTable("W_IPS_GlueGu", TableDescription = "糊机糊间隙基础设置表")]
public class W_IPS_GlueGu
{
    /// <summary>订单楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 10, ColumnDescription = "订单楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>纸张部位(1=1层，2=2层，3=3层)</summary>
    [SugarColumn(ColumnName = "WF_Position", ColumnDescription = "纸张部位(1=1层，2=2层，3=3层)")]
    public int WF_Position { get; set; }

    /// <summary>最小糊间隙</summary>
    [SugarColumn(ColumnName = "WF_MinGlue", ColumnDescription = "最小糊间隙")]
    public int WF_MinGlue { get; set; }

    /// <summary>最大糊间隙</summary>
    [SugarColumn(ColumnName = "WF_MaxGlue", ColumnDescription = "最大糊间隙")]
    public int WF_MaxGlue { get; set; }

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