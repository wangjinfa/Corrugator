using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 单面机烘缸蒸汽车速系数表
/// </summary>
[SugarTable("TB_IPS_WrapSteamSFSpeedCoef", TableDescription = "单面机烘缸蒸汽车速系数表")]
public class TB_IPS_WrapSteamSFSpeedCoef
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "车速")]
    public int F_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal F_Coef { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}