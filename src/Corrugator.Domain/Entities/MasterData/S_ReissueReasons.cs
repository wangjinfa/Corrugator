using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 补打原因表
/// </summary>
[SugarTable("S_ReissueReasons", TableDescription = "补打原因表")]
public class S_ReissueReasons
{
    /// <summary>原因</summary>
    [SugarColumn(ColumnName = "F_Reason", Length = 500, IsNullable = true, ColumnDescription = "原因")]
    public string? F_Reason { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}