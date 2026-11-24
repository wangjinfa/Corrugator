using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 点位设置表
/// </summary>
[SugarTable("TB_QDM_Point", TableDescription = "点位设置表")]
public class TB_QDM_Point
{
    /// <summary>点位名称</summary>
    [SugarColumn(ColumnName = "F_PointName", Length = 50, IsNullable = true, ColumnDescription = "点位名称")]
    public string? F_PointName { get; set; }

    /// <summary>F_Type</summary>
    [SugarColumn(ColumnName = "F_Type", Length = 50, ColumnDescription = "F_Type")]
    public string F_Type { get; set; } = default!;

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>位置表</summary>
    [SugarColumn(ColumnName = "F_PositionTable", Length = 50, IsNullable = true, ColumnDescription = "位置表")]
    public string? F_PositionTable { get; set; }

    /// <summary>参数1</summary>
    [SugarColumn(ColumnName = "F_Parameter", IsNullable = true, ColumnDescription = "参数1")]
    public int? F_Parameter { get; set; }

    /// <summary>参数2</summary>
    [SugarColumn(ColumnName = "F_Parameter2", IsNullable = true, ColumnDescription = "参数2")]
    public int? F_Parameter2 { get; set; }

    /// <summary>读写</summary>
    [SugarColumn(ColumnName = "F_ParameterRW", IsNullable = true, ColumnDescription = "读写")]
    public int? F_ParameterRW { get; set; }

    /// <summary>点位编码</summary>
    [SugarColumn(ColumnName = "F_Encoded", Length = 200, ColumnDescription = "点位编码")]
    public string F_Encoded { get; set; } = default!;

    /// <summary>排序</summary>
    [SugarColumn(ColumnName = "F_SortNo", IsNullable = true, ColumnDescription = "排序")]
    public int? F_SortNo { get; set; }

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

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}