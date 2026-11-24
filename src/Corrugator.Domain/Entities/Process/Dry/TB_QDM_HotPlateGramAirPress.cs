using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 热板克重气压
/// </summary>
[SugarTable("W_QDM_HotPlateGramAirPress", TableDescription = "热板克重气压")]
public class W_QDM_HotPlateGramAirPress
{
    /// <summary>棱型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "棱型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小气压</summary>
    [SugarColumn(ColumnName = "WF_MinPressure", Length = 18, DecimalDigits = 2, ColumnDescription = "最小气压")]
    public decimal WF_MinPressure { get; set; }

    /// <summary>最大气压</summary>
    [SugarColumn(ColumnName = "WF_MaxPressure", Length = 18, DecimalDigits = 2, ColumnDescription = "最大气压")]
    public decimal WF_MaxPressure { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>楞型系数</summary>
    [SugarColumn(ColumnName = "WF_FluteFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "楞型系数")]
    public decimal WF_FluteFactor { get; set; }

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