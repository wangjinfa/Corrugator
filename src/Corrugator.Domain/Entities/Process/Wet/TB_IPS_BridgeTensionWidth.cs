using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 天桥张力门幅设置
/// </summary>
[SugarTable("TB_IPS_BridgeTensionWidth", TableDescription = "天桥张力门幅设置")]
public class TB_IPS_BridgeTensionWidth
{
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