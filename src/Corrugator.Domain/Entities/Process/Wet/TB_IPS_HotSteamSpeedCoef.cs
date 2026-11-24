using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 三段热板蒸汽车速系数表
/// </summary>
[SugarTable("W_IPS_HotSteamSpeedCoef", TableDescription = "三段热板蒸汽车速系数表")]
public class W_IPS_HotSteamSpeedCoef
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "车速")]
    public int WF_Speed { get; set; }

    /// <summary>3层系数</summary>
    [SugarColumn(ColumnName = "WF_Coef3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "3层系数")]
    public decimal? WF_Coef3 { get; set; }

    /// <summary>4层系数</summary>
    [SugarColumn(ColumnName = "WF_Coef4", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "4层系数")]
    public decimal? WF_Coef4 { get; set; }

    /// <summary>5层系数</summary>
    [SugarColumn(ColumnName = "WF_Coef5", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "5层系数")]
    public decimal? WF_Coef5 { get; set; }

    /// <summary>6层系数</summary>
    [SugarColumn(ColumnName = "WF_Coef6", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "6层系数")]
    public decimal? WF_Coef6 { get; set; }

    /// <summary>7层系数</summary>
    [SugarColumn(ColumnName = "WF_Coef7", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "7层系数")]
    public decimal? WF_Coef7 { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}