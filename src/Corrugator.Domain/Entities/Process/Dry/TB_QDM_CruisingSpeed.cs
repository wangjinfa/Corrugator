using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 车速巡航
/// </summary>
[SugarTable("W_QDM_CruisingSpeed", TableDescription = "车速巡航")]
public class W_QDM_CruisingSpeed
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小车速</summary>
    [SugarColumn(ColumnName = "WF_MinSpeed", ColumnDescription = "最小车速")]
    public int WF_MinSpeed { get; set; }

    /// <summary>最大车速</summary>
    [SugarColumn(ColumnName = "WF_MaxSpeed", ColumnDescription = "最大车速")]
    public int WF_MaxSpeed { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

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