using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 补打原因表
/// </summary>
[SugarTable("W_ReissueReasons", TableDescription = "补打原因表")]
public class W_ReissueReasons
{
    /// <summary>原因</summary>
    [SugarColumn(ColumnName = "WF_Reason", Length = 500, IsNullable = true, ColumnDescription = "原因")]
    public string? WF_Reason { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}