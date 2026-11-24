using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 单面机烘缸蒸汽车速系数表
/// </summary>
[SugarTable("W_IPS_WrapSteamSFSpeedCoef", TableDescription = "单面机烘缸蒸汽车速系数表")]
public class W_IPS_WrapSteamSFSpeedCoef
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "车速")]
    public int WF_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}