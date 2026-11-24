using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 小订单米数对应的巡航车速
/// </summary>
[SugarTable("TB_IPS_CruiseOrderMeterSpeed", TableDescription = "小订单米数对应的巡航车速")]
public class TB_IPS_CruiseOrderMeterSpeed
{
    /// <summary>小订单米数</summary>
    [SugarColumn(ColumnName = "F_Meter", ColumnDescription = "小订单米数")]
    public int F_Meter { get; set; }

    /// <summary>巡航限速</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "巡航限速")]
    public int F_Speed { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}