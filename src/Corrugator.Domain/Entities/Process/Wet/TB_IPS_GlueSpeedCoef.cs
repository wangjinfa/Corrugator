using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊间隙车速系数设置
/// </summary>
[SugarTable("TB_IPS_GlueSpeedCoef", TableDescription = "糊间隙车速系数设置")]
public class TB_IPS_GlueSpeedCoef
{
    /// <summary>设备部位(枚举值SF1,SF2,SF3,GU1,GU2,GU3)</summary>
    [SugarColumn(ColumnName = "F_Position", ColumnDescription = "设备部位(枚举值SF1,SF2,SF3,GU1,GU2,GU3)")]
    public int F_Position { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "车速")]
    public int F_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal F_Coef { get; set; }

    /// <summary>最小糊间隙值</summary>
    [SugarColumn(ColumnName = "F_MinValue", IsNullable = true, ColumnDescription = "最小糊间隙值")]
    public int? F_MinValue { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}