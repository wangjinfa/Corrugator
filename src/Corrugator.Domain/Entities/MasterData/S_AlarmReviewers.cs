using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警复核人
/// </summary>
[SugarTable("W_AlarmReviewers", TableDescription = "预警复核人")]
public class W_AlarmReviewers
{
    /// <summary>姓名</summary>
    [SugarColumn(ColumnName = "WSA_Name", Length = 20, ColumnDescription = "姓名")]
    public string WSA_Name { get; set; } = default!;

    /// <summary>WSA_ID</summary>
    [SugarColumn(ColumnName = "WSA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSA_ID")]
    public int WSA_ID { get; set; }

}