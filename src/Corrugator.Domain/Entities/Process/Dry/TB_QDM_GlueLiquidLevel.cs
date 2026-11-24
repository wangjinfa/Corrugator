using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 糊盆液位
/// </summary>
[SugarTable("TB_QDM_GlueLiquidLevel", TableDescription = "糊盆液位")]
public class TB_QDM_GlueLiquidLevel
{
    /// <summary>测量液位高度</summary>
    [SugarColumn(ColumnName = "F_MeasureLiquidHeight", IsNullable = true, ColumnDescription = "测量液位高度")]
    public int? F_MeasureLiquidHeight { get; set; }

    /// <summary>正常液位高度</summary>
    [SugarColumn(ColumnName = "F_LiquidHeight", ColumnDescription = "正常液位高度")]
    public int F_LiquidHeight { get; set; }

    /// <summary>送胶液位高度</summary>
    [SugarColumn(ColumnName = "F_GlueLiquidHeight", ColumnDescription = "送胶液位高度")]
    public int F_GlueLiquidHeight { get; set; }

    /// <summary>警报液位高度</summary>
    [SugarColumn(ColumnName = "F_AlarmLiquidHeight", ColumnDescription = "警报液位高度")]
    public int F_AlarmLiquidHeight { get; set; }

    /// <summary>运行车速</summary>
    [SugarColumn(ColumnName = "F_LoadingSpeed", ColumnDescription = "运行车速")]
    public int F_LoadingSpeed { get; set; }

    /// <summary>停机液位高度</summary>
    [SugarColumn(ColumnName = "F_HaltLiquidHeight", ColumnDescription = "停机液位高度")]
    public int F_HaltLiquidHeight { get; set; }

    /// <summary>启用状态</summary>
    [SugarColumn(ColumnName = "F_IsActive", ColumnDescription = "启用状态")]
    public bool F_IsActive { get; set; }

    /// <summary>报警发出信息</summary>
    [SugarColumn(ColumnName = "F_IsAlarm", ColumnDescription = "报警发出信息")]
    public bool F_IsAlarm { get; set; }

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

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}