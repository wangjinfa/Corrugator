using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊间隙车速系数设置
/// </summary>
[SugarTable("W_IPS_GlueSpeedCoef", TableDescription = "糊间隙车速系数设置")]
public class W_IPS_GlueSpeedCoef
{
    /// <summary>设备部位(枚举值SF1,SF2,SF3,GU1,GU2,GU3)</summary>
    [SugarColumn(ColumnName = "WF_Position", ColumnDescription = "设备部位(枚举值SF1,SF2,SF3,GU1,GU2,GU3)")]
    public int WF_Position { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "车速")]
    public int WF_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WF_Coef { get; set; }

    /// <summary>最小糊间隙值</summary>
    [SugarColumn(ColumnName = "WF_MinValue", IsNullable = true, ColumnDescription = "最小糊间隙值")]
    public int? WF_MinValue { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}