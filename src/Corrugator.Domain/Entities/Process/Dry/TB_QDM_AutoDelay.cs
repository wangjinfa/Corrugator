using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 延时自动
/// </summary>
[SugarTable("TB_QDM_AutoDelay", TableDescription = "延时自动")]
public class TB_QDM_AutoDelay
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>胶水</summary>
    [SugarColumn(ColumnName = "F_Glue", IsNullable = true, ColumnDescription = "胶水")]
    public int? F_Glue { get; set; }

    /// <summary>包角</summary>
    [SugarColumn(ColumnName = "F_Wrap", IsNullable = true, ColumnDescription = "包角")]
    public int? F_Wrap { get; set; }

    /// <summary>张力</summary>
    [SugarColumn(ColumnName = "F_Tension", IsNullable = true, ColumnDescription = "张力")]
    public int? F_Tension { get; set; }

    /// <summary>压力辊压力</summary>
    [SugarColumn(ColumnName = "F_PressRollPress", IsNullable = true, ColumnDescription = "压力辊压力")]
    public int? F_PressRollPress { get; set; }

    /// <summary>瓦楞辊压力</summary>
    [SugarColumn(ColumnName = "F_CorrugatedRollPress", IsNullable = true, ColumnDescription = "瓦楞辊压力")]
    public int? F_CorrugatedRollPress { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "F_Steam", IsNullable = true, ColumnDescription = "蒸汽")]
    public int? F_Steam { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "F_Spray", IsNullable = true, ColumnDescription = "喷雾")]
    public int? F_Spray { get; set; }

    /// <summary>压板组数</summary>
    [SugarColumn(ColumnName = "F_LoadingSystemQty", IsNullable = true, ColumnDescription = "压板组数")]
    public int? F_LoadingSystemQty { get; set; }

    /// <summary>天桥张力</summary>
    [SugarColumn(ColumnName = "F_OffsetTension", IsNullable = true, ColumnDescription = "天桥张力")]
    public int? F_OffsetTension { get; set; }

    /// <summary>三段热板蒸汽</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam", IsNullable = true, ColumnDescription = "三段热板蒸汽")]
    public int? F_HotPlateSteam { get; set; }

    /// <summary>热板压力</summary>
    [SugarColumn(ColumnName = "F_HotPlatePress", IsNullable = true, ColumnDescription = "热板压力")]
    public int? F_HotPlatePress { get; set; }

    /// <summary>冷板压力</summary>
    [SugarColumn(ColumnName = "F_ColdPlatePress", IsNullable = true, ColumnDescription = "冷板压力")]
    public int? F_ColdPlatePress { get; set; }

    /// <summary>F_Type</summary>
    [SugarColumn(ColumnName = "F_Type", ColumnDescription = "F_Type")]
    public int F_Type { get; set; }

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

    /// <summary>巡航车速</summary>
    [SugarColumn(ColumnName = "F_CruiseSpeed", IsNullable = true, ColumnDescription = "巡航车速")]
    public int? F_CruiseSpeed { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}