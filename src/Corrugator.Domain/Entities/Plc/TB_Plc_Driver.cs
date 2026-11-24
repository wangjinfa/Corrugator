using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC设备表
/// </summary>
[SugarTable("TB_Plc_Driver", TableDescription = "PLC设备表")]
public class TB_Plc_Driver
{
    /// <summary>设备编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 36, ColumnDescription = "设备编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>设备名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, ColumnDescription = "设备名称")]
    public string F_Name { get; set; } = default!;

    /// <summary>通讯类型</summary>
    [SugarColumn(ColumnName = "F_CommunicationType", ColumnDescription = "通讯类型")]
    public int F_CommunicationType { get; set; }

    /// <summary>通讯配置编码</summary>
    [SugarColumn(ColumnName = "F_ConfigCode", Length = 36, ColumnDescription = "通讯配置编码")]
    public string F_ConfigCode { get; set; } = default!;

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "是否启用")]
    public bool F_IsUse { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? F_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? F_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "F_IsDelete", IsNullable = true, ColumnDescription = "是否删除")]
    public bool? F_IsDelete { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}