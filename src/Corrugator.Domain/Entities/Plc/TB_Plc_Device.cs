using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// 通讯设备表（通讯设置 → 通讯设备设置）。
/// 一条设备记录 = 一个 PLC/工段设备，挂一个通讯协议类型和一份通讯配置。
/// </summary>
[SugarTable("TB_Plc_Device", TableDescription = "通讯设备表")]
public class TB_Plc_Device
{
    /// <summary>设备编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 36, ColumnDescription = "设备编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>设备名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, IsNullable = true, ColumnDescription = "设备名称")]
    public string? F_Name { get; set; }

    /// <summary>通讯类型（协议驱动，如 Siemens_S7_1200）</summary>
    [SugarColumn(ColumnName = "F_CommType", Length = 50, IsNullable = true, ColumnDescription = "通讯类型")]
    public string? F_CommType { get; set; }

    /// <summary>通讯配置（引用 TB_Plc_DriverConfig 的配置名称，如 双面机）</summary>
    [SugarColumn(ColumnName = "F_ConfigName", Length = 100, IsNullable = true, ColumnDescription = "通讯配置")]
    public string? F_ConfigName { get; set; }

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "是否启用")]
    public bool? F_IsUse { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true)]
    public string? F_Creator { get; set; }

    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true)]
    public DateTime? F_CreateTime { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
