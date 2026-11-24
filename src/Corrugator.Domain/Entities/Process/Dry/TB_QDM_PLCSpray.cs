using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// PLC喷雾
/// </summary>
[SugarTable("TB_QDM_PLCSpray", TableDescription = "PLC喷雾")]
public class TB_QDM_PLCSpray
{
    /// <summary>最小功率</summary>
    [SugarColumn(ColumnName = "F_MinPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最小功率")]
    public decimal F_MinPower { get; set; }

    /// <summary>最大功率</summary>
    [SugarColumn(ColumnName = "F_MaxPower", Length = 18, DecimalDigits = 2, ColumnDescription = "最大功率")]
    public decimal F_MaxPower { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal F_MaxGram { get; set; }

    /// <summary>喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "喷雾系数")]
    public decimal F_Factor { get; set; }

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

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}