using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC设备表
/// </summary>
[SugarTable("W_Plc_Driver", TableDescription = "PLC设备表")]
public class W_Plc_Driver
{
    /// <summary>设备编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 36, ColumnDescription = "设备编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>设备名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, ColumnDescription = "设备名称")]
    public string WF_Name { get; set; } = default!;

    /// <summary>通讯类型</summary>
    [SugarColumn(ColumnName = "WF_CommunicationType", ColumnDescription = "通讯类型")]
    public int WF_CommunicationType { get; set; }

    /// <summary>通讯配置编码</summary>
    [SugarColumn(ColumnName = "WF_ConfigCode", Length = 36, ColumnDescription = "通讯配置编码")]
    public string WF_ConfigCode { get; set; } = default!;

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "是否启用")]
    public bool WF_IsUse { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? WF_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? WF_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "WF_IsDelete", IsNullable = true, ColumnDescription = "是否删除")]
    public bool? WF_IsDelete { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}