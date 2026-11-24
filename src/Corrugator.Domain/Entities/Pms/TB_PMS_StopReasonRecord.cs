using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// W_PMS_StopReasonRecord
/// </summary>
[SugarTable("W_PMS_StopReasonRecord", TableDescription = "W_PMS_StopReasonRecord")]
public class W_PMS_StopReasonRecord
{
    /// <summary>WF_P04SID</summary>
    [SugarColumn(ColumnName = "WF_P04SID", ColumnDescription = "WF_P04SID")]
    public int WF_P04SID { get; set; }

    /// <summary>WF_StopReason</summary>
    [SugarColumn(ColumnName = "WF_StopReason", Length = 200, ColumnDescription = "WF_StopReason")]
    public string WF_StopReason { get; set; } = default!;

    /// <summary>WF_StopReasonID</summary>
    [SugarColumn(ColumnName = "WF_StopReasonID", ColumnDescription = "WF_StopReasonID")]
    public int WF_StopReasonID { get; set; }

    /// <summary>WF_StopType</summary>
    [SugarColumn(ColumnName = "WF_StopType", Length = 200, ColumnDescription = "WF_StopType")]
    public string WF_StopType { get; set; } = default!;

    /// <summary>WF_StopTypeID</summary>
    [SugarColumn(ColumnName = "WF_StopTypeID", ColumnDescription = "WF_StopTypeID")]
    public int WF_StopTypeID { get; set; }

    /// <summary>WF_StatisticsStop</summary>
    [SugarColumn(ColumnName = "WF_StatisticsStop", ColumnDescription = "WF_StatisticsStop")]
    public bool WF_StatisticsStop { get; set; }

    /// <summary>WF_PartName</summary>
    [SugarColumn(ColumnName = "WF_PartName", Length = 50, ColumnDescription = "WF_PartName")]
    public string WF_PartName { get; set; } = default!;

    /// <summary>WF_CreateUser</summary>
    [SugarColumn(ColumnName = "WF_CreateUser", Length = 50, IsNullable = true, ColumnDescription = "WF_CreateUser")]
    public string? WF_CreateUser { get; set; }

    /// <summary>WF_CreateTime</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "WF_CreateTime")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>WF_UpdateUser</summary>
    [SugarColumn(ColumnName = "WF_UpdateUser", Length = 50, IsNullable = true, ColumnDescription = "WF_UpdateUser")]
    public string? WF_UpdateUser { get; set; }

    /// <summary>WF_UpdateTime</summary>
    [SugarColumn(ColumnName = "WF_UpdateTime", IsNullable = true, ColumnDescription = "WF_UpdateTime")]
    public DateTime? WF_UpdateTime { get; set; }

    /// <summary>WF_Remark</summary>
    [SugarColumn(ColumnName = "WF_Remark", Length = 500, IsNullable = true, ColumnDescription = "WF_Remark")]
    public string? WF_Remark { get; set; }

    /// <summary>WF_IsModify</summary>
    [SugarColumn(ColumnName = "WF_IsModify", ColumnDescription = "WF_IsModify")]
    public bool WF_IsModify { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}