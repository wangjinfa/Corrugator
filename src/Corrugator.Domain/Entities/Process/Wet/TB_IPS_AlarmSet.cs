using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 自动预警设置
/// </summary>
[SugarTable("TB_IPS_AlarmSet", TableDescription = "自动预警设置")]
public class TB_IPS_AlarmSet
{
    /// <summary>预警编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 36, ColumnDescription = "预警编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>预警名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 100, IsNullable = true, ColumnDescription = "预警名称")]
    public string? F_Name { get; set; }

    /// <summary>预警设置说明</summary>
    [SugarColumn(ColumnName = "F_Desc", IsNullable = true, ColumnDescription = "预警设置说明")]
    public string? F_Desc { get; set; }

    /// <summary>预警表达式</summary>
    [SugarColumn(ColumnName = "F_AlarmCron", Length = 200, IsNullable = true, ColumnDescription = "预警表达式")]
    public string? F_AlarmCron { get; set; }

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "是否启用")]
    public bool F_IsUse { get; set; }

    /// <summary>是否发送客户端</summary>
    [SugarColumn(ColumnName = "F_IsSend", ColumnDescription = "是否发送客户端")]
    public bool F_IsSend { get; set; }

    /// <summary>是否记录</summary>
    [SugarColumn(ColumnName = "F_IsSave", ColumnDescription = "是否记录")]
    public bool F_IsSave { get; set; }

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
    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}