using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC设备配置表
/// </summary>
[SugarTable("TB_Plc_DriverConfig", TableDescription = "PLC设备配置表")]
public class TB_Plc_DriverConfig
{
    /// <summary>F_Code</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 36, ColumnDescription = "F_Code")]
    public string F_Code { get; set; } = default!;

    /// <summary>F_Name</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, IsNullable = true, ColumnDescription = "F_Name")]
    public string? F_Name { get; set; }

    /// <summary>F_Desc</summary>
    [SugarColumn(ColumnName = "F_Desc", IsNullable = true, ColumnDescription = "F_Desc")]
    public string? F_Desc { get; set; }

    /// <summary>F_ParCode</summary>
    [SugarColumn(ColumnName = "F_ParCode", Length = 100, IsNullable = true, ColumnDescription = "F_ParCode")]
    public string? F_ParCode { get; set; }

    /// <summary>F_ParValue</summary>
    [SugarColumn(ColumnName = "F_ParValue", Length = 100, IsNullable = true, ColumnDescription = "F_ParValue")]
    public string? F_ParValue { get; set; }

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

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}