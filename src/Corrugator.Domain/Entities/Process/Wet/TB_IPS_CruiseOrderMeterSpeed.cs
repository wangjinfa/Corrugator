using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 小订单米数对应的巡航车速
/// </summary>
[SugarTable("W_IPS_CruiseOrderMeterSpeed", TableDescription = "小订单米数对应的巡航车速")]
public class W_IPS_CruiseOrderMeterSpeed
{
    /// <summary>小订单米数</summary>
    [SugarColumn(ColumnName = "WF_Meter", ColumnDescription = "小订单米数")]
    public int WF_Meter { get; set; }

    /// <summary>巡航限速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "巡航限速")]
    public int WF_Speed { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}