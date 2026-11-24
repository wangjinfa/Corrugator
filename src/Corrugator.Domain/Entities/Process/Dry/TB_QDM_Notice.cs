using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// Qdm更改通知表
/// </summary>
[SugarTable("W_QDM_Notice", TableDescription = "Qdm更改通知表")]
public class W_QDM_Notice
{
    /// <summary>模块类型</summary>
    [SugarColumn(ColumnName = "WF_Type", Length = 50, IsNullable = true, ColumnDescription = "模块类型")]
    public string? WF_Type { get; set; }

    /// <summary>是否有修改</summary>
    [SugarColumn(ColumnName = "WF_IsModify", IsNullable = true, ColumnDescription = "是否有修改")]
    public bool? WF_IsModify { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}