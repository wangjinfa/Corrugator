using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// Qdm更改通知表
/// </summary>
[SugarTable("TB_QDM_Notice", TableDescription = "Qdm更改通知表")]
public class TB_QDM_Notice
{
    /// <summary>模块类型</summary>
    [SugarColumn(ColumnName = "F_Type", Length = 50, IsNullable = true, ColumnDescription = "模块类型")]
    public string? F_Type { get; set; }

    /// <summary>是否有修改</summary>
    [SugarColumn(ColumnName = "F_IsModify", IsNullable = true, ColumnDescription = "是否有修改")]
    public bool? F_IsModify { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}