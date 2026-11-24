using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 车速巡航
/// </summary>
[SugarTable("TB_QDM_CruisingSpeed", TableDescription = "车速巡航")]
public class TB_QDM_CruisingSpeed
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小车速</summary>
    [SugarColumn(ColumnName = "F_MinSpeed", ColumnDescription = "最小车速")]
    public int F_MinSpeed { get; set; }

    /// <summary>最大车速</summary>
    [SugarColumn(ColumnName = "F_MaxSpeed", ColumnDescription = "最大车速")]
    public int F_MaxSpeed { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal F_MaxGram { get; set; }

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