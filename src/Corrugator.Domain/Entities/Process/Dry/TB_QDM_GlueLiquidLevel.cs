using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 糊盆液位
/// </summary>
[SugarTable("W_QDM_GlueLiquidLevel", TableDescription = "糊盆液位")]
public class W_QDM_GlueLiquidLevel
{
    /// <summary>测量液位高度</summary>
    [SugarColumn(ColumnName = "WF_MeasureLiquidHeight", IsNullable = true, ColumnDescription = "测量液位高度")]
    public int? WF_MeasureLiquidHeight { get; set; }

    /// <summary>正常液位高度</summary>
    [SugarColumn(ColumnName = "WF_LiquidHeight", ColumnDescription = "正常液位高度")]
    public int WF_LiquidHeight { get; set; }

    /// <summary>送胶液位高度</summary>
    [SugarColumn(ColumnName = "WF_GlueLiquidHeight", ColumnDescription = "送胶液位高度")]
    public int WF_GlueLiquidHeight { get; set; }

    /// <summary>警报液位高度</summary>
    [SugarColumn(ColumnName = "WF_AlarmLiquidHeight", ColumnDescription = "警报液位高度")]
    public int WF_AlarmLiquidHeight { get; set; }

    /// <summary>运行车速</summary>
    [SugarColumn(ColumnName = "WF_LoadingSpeed", ColumnDescription = "运行车速")]
    public int WF_LoadingSpeed { get; set; }

    /// <summary>停机液位高度</summary>
    [SugarColumn(ColumnName = "WF_HaltLiquidHeight", ColumnDescription = "停机液位高度")]
    public int WF_HaltLiquidHeight { get; set; }

    /// <summary>启用状态</summary>
    [SugarColumn(ColumnName = "WF_IsActive", ColumnDescription = "启用状态")]
    public bool WF_IsActive { get; set; }

    /// <summary>报警发出信息</summary>
    [SugarColumn(ColumnName = "WF_IsAlarm", ColumnDescription = "报警发出信息")]
    public bool WF_IsAlarm { get; set; }

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

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}