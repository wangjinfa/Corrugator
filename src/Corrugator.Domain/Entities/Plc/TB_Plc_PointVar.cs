using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC点位配置表
/// </summary>
[SugarTable("W_Plc_PointVar", TableDescription = "PLC点位配置表")]
public class W_Plc_PointVar
{
    /// <summary>WF_Code</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 200, ColumnDescription = "WF_Code")]
    public string WF_Code { get; set; } = default!;

    /// <summary>WF_Name</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, IsNullable = true, ColumnDescription = "WF_Name")]
    public string? WF_Name { get; set; }

    /// <summary>WF_Desc</summary>
    [SugarColumn(ColumnName = "WF_Desc", Length = 100, IsNullable = true, ColumnDescription = "WF_Desc")]
    public string? WF_Desc { get; set; }

    /// <summary>WF_DriverCode</summary>
    [SugarColumn(ColumnName = "WF_DriverCode", Length = 36, IsNullable = true, ColumnDescription = "WF_DriverCode")]
    public string? WF_DriverCode { get; set; }

    /// <summary>WF_VarAddress</summary>
    [SugarColumn(ColumnName = "WF_VarAddress", Length = 100, IsNullable = true, ColumnDescription = "WF_VarAddress")]
    public string? WF_VarAddress { get; set; }

    /// <summary>WF_DataType</summary>
    [SugarColumn(ColumnName = "WF_DataType", Length = 36, IsNullable = true, ColumnDescription = "WF_DataType")]
    public string? WF_DataType { get; set; }

    /// <summary>WF_RW</summary>
    [SugarColumn(ColumnName = "WF_RW", ColumnDescription = "WF_RW")]
    public int WF_RW { get; set; }

    /// <summary>WF_Interval</summary>
    [SugarColumn(ColumnName = "WF_Interval", ColumnDescription = "WF_Interval")]
    public int WF_Interval { get; set; }

    /// <summary>WF_Priority</summary>
    [SugarColumn(ColumnName = "WF_Priority", ColumnDescription = "WF_Priority")]
    public int WF_Priority { get; set; }

    /// <summary>WF_IsUse</summary>
    [SugarColumn(ColumnName = "WF_IsUse", IsNullable = true, ColumnDescription = "WF_IsUse")]
    public bool? WF_IsUse { get; set; }

    /// <summary>WF_CurValue</summary>
    [SugarColumn(ColumnName = "WF_CurValue", Length = 100, IsNullable = true, ColumnDescription = "WF_CurValue")]
    public string? WF_CurValue { get; set; }

    /// <summary>WF_Creator</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "WF_Creator")]
    public string? WF_Creator { get; set; }

    /// <summary>WF_CreateTime</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "WF_CreateTime")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>WF_Editor</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "WF_Editor")]
    public string? WF_Editor { get; set; }

    /// <summary>WF_EditTime</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "WF_EditTime")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>WF_IsDelete</summary>
    [SugarColumn(ColumnName = "WF_IsDelete", ColumnDescription = "WF_IsDelete")]
    public bool WF_IsDelete { get; set; }

    /// <summary>WF_Position</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "WF_Position")]
    public string? WF_Position { get; set; }

    /// <summary>WF_IsAlarm</summary>
    [SugarColumn(ColumnName = "WF_IsAlarm", ColumnDescription = "WF_IsAlarm")]
    public bool WF_IsAlarm { get; set; }

    /// <summary>WF_AlarmInterval</summary>
    [SugarColumn(ColumnName = "WF_AlarmInterval", ColumnDescription = "WF_AlarmInterval")]
    public int WF_AlarmInterval { get; set; }

    /// <summary>WF_AlarmOffset</summary>
    [SugarColumn(ColumnName = "WF_AlarmOffset", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_AlarmOffset")]
    public decimal WF_AlarmOffset { get; set; }

    /// <summary>WF_DataOKAddress</summary>
    [SugarColumn(ColumnName = "WF_DataOKAddress", Length = 100, IsNullable = true, ColumnDescription = "WF_DataOKAddress")]
    public string? WF_DataOKAddress { get; set; }

    /// <summary>WF_DataOKDataType</summary>
    [SugarColumn(ColumnName = "WF_DataOKDataType", Length = 36, IsNullable = true, ColumnDescription = "WF_DataOKDataType")]
    public string? WF_DataOKDataType { get; set; }

    /// <summary>WF_TransferKeyAddress</summary>
    [SugarColumn(ColumnName = "WF_TransferKeyAddress", Length = 100, IsNullable = true, ColumnDescription = "WF_TransferKeyAddress")]
    public string? WF_TransferKeyAddress { get; set; }

    /// <summary>WF_TransferKeyDataType</summary>
    [SugarColumn(ColumnName = "WF_TransferKeyDataType", Length = 36, IsNullable = true, ColumnDescription = "WF_TransferKeyDataType")]
    public string? WF_TransferKeyDataType { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}