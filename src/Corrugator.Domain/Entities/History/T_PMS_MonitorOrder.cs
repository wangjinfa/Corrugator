using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// W_PMS_MonitorOrder
/// </summary>
[SugarTable("W_PMS_MonitorOrder", TableDescription = "W_PMS_MonitorOrder")]
public class W_PMS_MonitorOrder
{
    /// <summary>IsChange</summary>
    [SugarColumn(ColumnName = "WIsChange", ColumnDescription = "IsChange")]
    public bool WIsChange { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}