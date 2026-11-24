using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 备卷未就绪 剩余米数对应的巡航车速
/// </summary>
[SugarTable("TB_IPS_CuriseRamain", TableDescription = "备卷未就绪 剩余米数对应的巡航车速")]
public class TB_IPS_CuriseRamain
{
    /// <summary>剩余米数</summary>
    [SugarColumn(ColumnName = "F_Remain", ColumnDescription = "剩余米数")]
    public int F_Remain { get; set; }

    /// <summary>巡航车速</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "巡航车速")]
    public int F_Speed { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}