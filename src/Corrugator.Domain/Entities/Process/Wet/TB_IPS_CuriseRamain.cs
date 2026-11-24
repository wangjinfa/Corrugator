using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 备卷未就绪 剩余米数对应的巡航车速
/// </summary>
[SugarTable("W_IPS_CuriseRamain", TableDescription = "备卷未就绪 剩余米数对应的巡航车速")]
public class W_IPS_CuriseRamain
{
    /// <summary>剩余米数</summary>
    [SugarColumn(ColumnName = "WF_Remain", ColumnDescription = "剩余米数")]
    public int WF_Remain { get; set; }

    /// <summary>巡航车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "巡航车速")]
    public int WF_Speed { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}