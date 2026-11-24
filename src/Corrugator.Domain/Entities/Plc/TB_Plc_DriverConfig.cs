using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC设备配置表
/// </summary>
[SugarTable("W_Plc_DriverConfig", TableDescription = "PLC设备配置表")]
public class W_Plc_DriverConfig
{
    /// <summary>WF_Code</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 36, ColumnDescription = "WF_Code")]
    public string WF_Code { get; set; } = default!;

    /// <summary>WF_Name</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, IsNullable = true, ColumnDescription = "WF_Name")]
    public string? WF_Name { get; set; }

    /// <summary>WF_Desc</summary>
    [SugarColumn(ColumnName = "WF_Desc", IsNullable = true, ColumnDescription = "WF_Desc")]
    public string? WF_Desc { get; set; }

    /// <summary>WF_ParCode</summary>
    [SugarColumn(ColumnName = "WF_ParCode", Length = 100, IsNullable = true, ColumnDescription = "WF_ParCode")]
    public string? WF_ParCode { get; set; }

    /// <summary>WF_ParValue</summary>
    [SugarColumn(ColumnName = "WF_ParValue", Length = 100, IsNullable = true, ColumnDescription = "WF_ParValue")]
    public string? WF_ParValue { get; set; }

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

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}