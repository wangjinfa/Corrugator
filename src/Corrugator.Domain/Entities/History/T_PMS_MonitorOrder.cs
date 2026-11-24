using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// T_PMS_MonitorOrder
/// </summary>
[SugarTable("T_PMS_MonitorOrder", TableDescription = "T_PMS_MonitorOrder")]
public class T_PMS_MonitorOrder
{
    /// <summary>IsChange</summary>
    [SugarColumn(ColumnName = "IsChange", ColumnDescription = "IsChange")]
    public bool IsChange { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}