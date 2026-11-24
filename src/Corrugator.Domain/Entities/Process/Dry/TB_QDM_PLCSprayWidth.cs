using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// PLC喷雾门幅
/// </summary>
[SugarTable("TB_QDM_PLCSprayWidth", TableDescription = "PLC喷雾门幅")]
public class TB_QDM_PLCSprayWidth
{
    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "F_MinWidth", ColumnDescription = "最小门幅")]
    public int F_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", ColumnDescription = "最大门幅")]
    public int F_MaxWidth { get; set; }

    /// <summary>左位置</summary>
    [SugarColumn(ColumnName = "F_LeftPosition", ColumnDescription = "左位置")]
    public int F_LeftPosition { get; set; }

    /// <summary>右位置</summary>
    [SugarColumn(ColumnName = "F_RightPosition", ColumnDescription = "右位置")]
    public int F_RightPosition { get; set; }

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

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}