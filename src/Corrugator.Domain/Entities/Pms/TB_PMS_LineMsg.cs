using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// TB_PMS_LineMsg
/// </summary>
[SugarTable("TB_PMS_LineMsg", TableDescription = "TB_PMS_LineMsg")]
public class TB_PMS_LineMsg
{
    /// <summary>是否运行</summary>
    [SugarColumn(ColumnName = "F_IsRun", IsNullable = true, ColumnDescription = "是否运行")]
    public bool? F_IsRun { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}