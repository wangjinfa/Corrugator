using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警复核人
/// </summary>
[SugarTable("S_AlarmReviewers", TableDescription = "预警复核人")]
public class S_AlarmReviewers
{
    /// <summary>姓名</summary>
    [SugarColumn(ColumnName = "SA_Name", Length = 20, ColumnDescription = "姓名")]
    public string SA_Name { get; set; } = default!;

    /// <summary>SA_ID</summary>
    [SugarColumn(ColumnName = "SA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SA_ID")]
    public int SA_ID { get; set; }

}