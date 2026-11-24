using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 延时自动
/// </summary>
[SugarTable("W_QDM_AutoDelay", TableDescription = "延时自动")]
public class W_QDM_AutoDelay
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>胶水</summary>
    [SugarColumn(ColumnName = "WF_Glue", IsNullable = true, ColumnDescription = "胶水")]
    public int? WF_Glue { get; set; }

    /// <summary>包角</summary>
    [SugarColumn(ColumnName = "WF_Wrap", IsNullable = true, ColumnDescription = "包角")]
    public int? WF_Wrap { get; set; }

    /// <summary>张力</summary>
    [SugarColumn(ColumnName = "WF_Tension", IsNullable = true, ColumnDescription = "张力")]
    public int? WF_Tension { get; set; }

    /// <summary>压力辊压力</summary>
    [SugarColumn(ColumnName = "WF_PressRollPress", IsNullable = true, ColumnDescription = "压力辊压力")]
    public int? WF_PressRollPress { get; set; }

    /// <summary>瓦楞辊压力</summary>
    [SugarColumn(ColumnName = "WF_CorrugatedRollPress", IsNullable = true, ColumnDescription = "瓦楞辊压力")]
    public int? WF_CorrugatedRollPress { get; set; }

    /// <summary>蒸汽</summary>
    [SugarColumn(ColumnName = "WF_Steam", IsNullable = true, ColumnDescription = "蒸汽")]
    public int? WF_Steam { get; set; }

    /// <summary>喷雾</summary>
    [SugarColumn(ColumnName = "WF_Spray", IsNullable = true, ColumnDescription = "喷雾")]
    public int? WF_Spray { get; set; }

    /// <summary>压板组数</summary>
    [SugarColumn(ColumnName = "WF_LoadingSystemQty", IsNullable = true, ColumnDescription = "压板组数")]
    public int? WF_LoadingSystemQty { get; set; }

    /// <summary>天桥张力</summary>
    [SugarColumn(ColumnName = "WF_OffsetTension", IsNullable = true, ColumnDescription = "天桥张力")]
    public int? WF_OffsetTension { get; set; }

    /// <summary>三段热板蒸汽</summary>
    [SugarColumn(ColumnName = "WF_HotPlateSteam", IsNullable = true, ColumnDescription = "三段热板蒸汽")]
    public int? WF_HotPlateSteam { get; set; }

    /// <summary>热板压力</summary>
    [SugarColumn(ColumnName = "WF_HotPlatePress", IsNullable = true, ColumnDescription = "热板压力")]
    public int? WF_HotPlatePress { get; set; }

    /// <summary>冷板压力</summary>
    [SugarColumn(ColumnName = "WF_ColdPlatePress", IsNullable = true, ColumnDescription = "冷板压力")]
    public int? WF_ColdPlatePress { get; set; }

    /// <summary>WF_Type</summary>
    [SugarColumn(ColumnName = "WF_Type", ColumnDescription = "WF_Type")]
    public int WF_Type { get; set; }

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

    /// <summary>巡航车速</summary>
    [SugarColumn(ColumnName = "WF_CruiseSpeed", IsNullable = true, ColumnDescription = "巡航车速")]
    public int? WF_CruiseSpeed { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}