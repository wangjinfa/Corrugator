using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// TB_PMS_StopReasonRecord
/// </summary>
[SugarTable("TB_PMS_StopReasonRecord", TableDescription = "TB_PMS_StopReasonRecord")]
public class TB_PMS_StopReasonRecord
{
    /// <summary>F_P04SID</summary>
    [SugarColumn(ColumnName = "F_P04SID", ColumnDescription = "F_P04SID")]
    public int F_P04SID { get; set; }

    /// <summary>F_StopReason</summary>
    [SugarColumn(ColumnName = "F_StopReason", Length = 200, ColumnDescription = "F_StopReason")]
    public string F_StopReason { get; set; } = default!;

    /// <summary>F_StopReasonID</summary>
    [SugarColumn(ColumnName = "F_StopReasonID", ColumnDescription = "F_StopReasonID")]
    public int F_StopReasonID { get; set; }

    /// <summary>F_StopType</summary>
    [SugarColumn(ColumnName = "F_StopType", Length = 200, ColumnDescription = "F_StopType")]
    public string F_StopType { get; set; } = default!;

    /// <summary>F_StopTypeID</summary>
    [SugarColumn(ColumnName = "F_StopTypeID", ColumnDescription = "F_StopTypeID")]
    public int F_StopTypeID { get; set; }

    /// <summary>F_StatisticsStop</summary>
    [SugarColumn(ColumnName = "F_StatisticsStop", ColumnDescription = "F_StatisticsStop")]
    public bool F_StatisticsStop { get; set; }

    /// <summary>F_PartName</summary>
    [SugarColumn(ColumnName = "F_PartName", Length = 50, ColumnDescription = "F_PartName")]
    public string F_PartName { get; set; } = default!;

    /// <summary>F_CreateUser</summary>
    [SugarColumn(ColumnName = "F_CreateUser", Length = 50, IsNullable = true, ColumnDescription = "F_CreateUser")]
    public string? F_CreateUser { get; set; }

    /// <summary>F_CreateTime</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "F_CreateTime")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>F_UpdateUser</summary>
    [SugarColumn(ColumnName = "F_UpdateUser", Length = 50, IsNullable = true, ColumnDescription = "F_UpdateUser")]
    public string? F_UpdateUser { get; set; }

    /// <summary>F_UpdateTime</summary>
    [SugarColumn(ColumnName = "F_UpdateTime", IsNullable = true, ColumnDescription = "F_UpdateTime")]
    public DateTime? F_UpdateTime { get; set; }

    /// <summary>F_Remark</summary>
    [SugarColumn(ColumnName = "F_Remark", Length = 500, IsNullable = true, ColumnDescription = "F_Remark")]
    public string? F_Remark { get; set; }

    /// <summary>F_IsModify</summary>
    [SugarColumn(ColumnName = "F_IsModify", ColumnDescription = "F_IsModify")]
    public bool F_IsModify { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}