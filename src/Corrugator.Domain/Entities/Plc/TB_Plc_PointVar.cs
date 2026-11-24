using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC点位配置表
/// </summary>
[SugarTable("TB_Plc_PointVar", TableDescription = "PLC点位配置表")]
public class TB_Plc_PointVar
{
    /// <summary>F_Code</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 200, ColumnDescription = "F_Code")]
    public string F_Code { get; set; } = default!;

    /// <summary>F_Name</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, IsNullable = true, ColumnDescription = "F_Name")]
    public string? F_Name { get; set; }

    /// <summary>F_Desc</summary>
    [SugarColumn(ColumnName = "F_Desc", Length = 100, IsNullable = true, ColumnDescription = "F_Desc")]
    public string? F_Desc { get; set; }

    /// <summary>F_DriverCode</summary>
    [SugarColumn(ColumnName = "F_DriverCode", Length = 36, IsNullable = true, ColumnDescription = "F_DriverCode")]
    public string? F_DriverCode { get; set; }

    /// <summary>F_VarAddress</summary>
    [SugarColumn(ColumnName = "F_VarAddress", Length = 100, IsNullable = true, ColumnDescription = "F_VarAddress")]
    public string? F_VarAddress { get; set; }

    /// <summary>F_DataType</summary>
    [SugarColumn(ColumnName = "F_DataType", Length = 36, IsNullable = true, ColumnDescription = "F_DataType")]
    public string? F_DataType { get; set; }

    /// <summary>F_RW</summary>
    [SugarColumn(ColumnName = "F_RW", ColumnDescription = "F_RW")]
    public int F_RW { get; set; }

    /// <summary>F_Interval</summary>
    [SugarColumn(ColumnName = "F_Interval", ColumnDescription = "F_Interval")]
    public int F_Interval { get; set; }

    /// <summary>F_Priority</summary>
    [SugarColumn(ColumnName = "F_Priority", ColumnDescription = "F_Priority")]
    public int F_Priority { get; set; }

    /// <summary>F_IsUse</summary>
    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "F_IsUse")]
    public bool? F_IsUse { get; set; }

    /// <summary>F_CurValue</summary>
    [SugarColumn(ColumnName = "F_CurValue", Length = 100, IsNullable = true, ColumnDescription = "F_CurValue")]
    public string? F_CurValue { get; set; }

    /// <summary>F_Creator</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "F_Creator")]
    public string? F_Creator { get; set; }

    /// <summary>F_CreateTime</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "F_CreateTime")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>F_Editor</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "F_Editor")]
    public string? F_Editor { get; set; }

    /// <summary>F_EditTime</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "F_EditTime")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>F_IsDelete</summary>
    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "F_IsDelete")]
    public bool F_IsDelete { get; set; }

    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "F_Position")]
    public string? F_Position { get; set; }

    /// <summary>F_IsAlarm</summary>
    [SugarColumn(ColumnName = "F_IsAlarm", ColumnDescription = "F_IsAlarm")]
    public bool F_IsAlarm { get; set; }

    /// <summary>F_AlarmInterval</summary>
    [SugarColumn(ColumnName = "F_AlarmInterval", ColumnDescription = "F_AlarmInterval")]
    public int F_AlarmInterval { get; set; }

    /// <summary>F_AlarmOffset</summary>
    [SugarColumn(ColumnName = "F_AlarmOffset", Length = 18, DecimalDigits = 2, ColumnDescription = "F_AlarmOffset")]
    public decimal F_AlarmOffset { get; set; }

    /// <summary>F_DataOKAddress</summary>
    [SugarColumn(ColumnName = "F_DataOKAddress", Length = 100, IsNullable = true, ColumnDescription = "F_DataOKAddress")]
    public string? F_DataOKAddress { get; set; }

    /// <summary>F_DataOKDataType</summary>
    [SugarColumn(ColumnName = "F_DataOKDataType", Length = 36, IsNullable = true, ColumnDescription = "F_DataOKDataType")]
    public string? F_DataOKDataType { get; set; }

    /// <summary>F_TransferKeyAddress</summary>
    [SugarColumn(ColumnName = "F_TransferKeyAddress", Length = 100, IsNullable = true, ColumnDescription = "F_TransferKeyAddress")]
    public string? F_TransferKeyAddress { get; set; }

    /// <summary>F_TransferKeyDataType</summary>
    [SugarColumn(ColumnName = "F_TransferKeyDataType", Length = 36, IsNullable = true, ColumnDescription = "F_TransferKeyDataType")]
    public string? F_TransferKeyDataType { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}