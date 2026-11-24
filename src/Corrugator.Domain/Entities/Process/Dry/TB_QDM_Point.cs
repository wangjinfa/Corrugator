using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 点位设置表
/// </summary>
[SugarTable("W_QDM_Point", TableDescription = "点位设置表")]
public class W_QDM_Point
{
    /// <summary>点位名称</summary>
    [SugarColumn(ColumnName = "WF_PointName", Length = 50, IsNullable = true, ColumnDescription = "点位名称")]
    public string? WF_PointName { get; set; }

    /// <summary>WF_Type</summary>
    [SugarColumn(ColumnName = "WF_Type", Length = 50, ColumnDescription = "WF_Type")]
    public string WF_Type { get; set; } = default!;

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>位置表</summary>
    [SugarColumn(ColumnName = "WF_PositionTable", Length = 50, IsNullable = true, ColumnDescription = "位置表")]
    public string? WF_PositionTable { get; set; }

    /// <summary>参数1</summary>
    [SugarColumn(ColumnName = "WF_Parameter", IsNullable = true, ColumnDescription = "参数1")]
    public int? WF_Parameter { get; set; }

    /// <summary>参数2</summary>
    [SugarColumn(ColumnName = "WF_Parameter2", IsNullable = true, ColumnDescription = "参数2")]
    public int? WF_Parameter2 { get; set; }

    /// <summary>读写</summary>
    [SugarColumn(ColumnName = "WF_ParameterRW", IsNullable = true, ColumnDescription = "读写")]
    public int? WF_ParameterRW { get; set; }

    /// <summary>点位编码</summary>
    [SugarColumn(ColumnName = "WF_Encoded", Length = 200, ColumnDescription = "点位编码")]
    public string WF_Encoded { get; set; } = default!;

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "WF_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? WF_SortNo { get; set; }

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

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}