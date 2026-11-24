using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// W_PMS_LineMsg
/// </summary>
[SugarTable("W_PMS_LineMsg", TableDescription = "W_PMS_LineMsg")]
public class W_PMS_LineMsg
{
    /// <summary>是否运行</summary>
    [SugarColumn(ColumnName = "WF_IsRun", IsNullable = true, ColumnDescription = "是否运行")]
    public bool? WF_IsRun { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}