using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 瓦楞辊门幅系数表
/// </summary>
[SugarTable("TB_IPS_CorrugatedRollWidthCoef", TableDescription = "瓦楞辊门幅系数表")]
public class TB_IPS_CorrugatedRollWidthCoef
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "门幅")]
    public int F_Width { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal F_Coef { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}