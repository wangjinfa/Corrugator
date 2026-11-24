using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 瓦楞辊门幅系数表
/// </summary>
[SugarTable("W_IPS_CorrugatedRollWidthCoef", TableDescription = "瓦楞辊门幅系数表")]
public class W_IPS_CorrugatedRollWidthCoef
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "门幅")]
    public int WF_Width { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}