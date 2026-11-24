using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 自动预警设置
/// </summary>
[SugarTable("W_IPS_AlarmSet", TableDescription = "自动预警设置")]
public class W_IPS_AlarmSet
{
    /// <summary>预警编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 36, ColumnDescription = "预警编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>预警名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 100, IsNullable = true, ColumnDescription = "预警名称")]
    public string? WF_Name { get; set; }

    /// <summary>预警设置说明</summary>
    [SugarColumn(ColumnName = "WF_Desc", IsNullable = true, ColumnDescription = "预警设置说明")]
    public string? WF_Desc { get; set; }

    /// <summary>预警表达式</summary>
    [SugarColumn(ColumnName = "WF_AlarmCron", Length = 200, IsNullable = true, ColumnDescription = "预警表达式")]
    public string? WF_AlarmCron { get; set; }

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "是否启用")]
    public bool WF_IsUse { get; set; }

    /// <summary>是否发送客户端</summary>
    [SugarColumn(ColumnName = "WF_IsSend", ColumnDescription = "是否发送客户端")]
    public bool WF_IsSend { get; set; }

    /// <summary>是否记录</summary>
    [SugarColumn(ColumnName = "WF_IsSave", ColumnDescription = "是否记录")]
    public bool WF_IsSave { get; set; }

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
    [SugarColumn(ColumnName = "WF_IsDelete", ColumnDescription = "是否删除")]
    public bool WF_IsDelete { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}