using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// PLC喷雾
/// </summary>
[SugarTable("W_QDM_PLCSpray", TableDescription = "PLC喷雾")]
public class W_QDM_PLCSpray
{
    /// <summary>最小功率</summary>
    [SugarColumn(ColumnName = "WF_MinPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最小功率")]
    public decimal WF_MinPower { get; set; }

    /// <summary>最大功率</summary>
    [SugarColumn(ColumnName = "WF_MaxPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最大功率")]
    public decimal WF_MaxPower { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "WF_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾系数")]
    public decimal WF_Factor { get; set; }

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

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}