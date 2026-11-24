using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 天桥张力门幅设置
/// </summary>
[SugarTable("W_IPS_BridgeTensionWidth", TableDescription = "天桥张力门幅设置")]
public class W_IPS_BridgeTensionWidth
{
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