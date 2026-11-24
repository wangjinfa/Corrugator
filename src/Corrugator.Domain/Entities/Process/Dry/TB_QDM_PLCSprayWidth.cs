using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// PLC喷雾门幅
/// </summary>
[SugarTable("W_QDM_PLCSprayWidth", TableDescription = "PLC喷雾门幅")]
public class W_QDM_PLCSprayWidth
{
    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "WF_MinWidth", ColumnDescription = "最小门幅")]
    public int WF_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "WF_MaxWidth", ColumnDescription = "最大门幅")]
    public int WF_MaxWidth { get; set; }

    /// <summary>左位置</summary>
    [SugarColumn(ColumnName = "WF_LeftPosition", ColumnDescription = "左位置")]
    public int WF_LeftPosition { get; set; }

    /// <summary>右位置</summary>
    [SugarColumn(ColumnName = "WF_RightPosition", ColumnDescription = "右位置")]
    public int WF_RightPosition { get; set; }

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

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}