using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 烘缸蒸汽设置
/// </summary>
[SugarTable("W_QDM_PreheaterSteam", TableDescription = "烘缸蒸汽设置")]
public class W_QDM_PreheaterSteam
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>最低气压</summary>
    [SugarColumn(ColumnName = "WF_MinAirPress", Length = 18, DecimalDigits = 2, ColumnDescription = "最低气压")]
    public decimal WF_MinAirPress { get; set; }

    /// <summary>最高气压</summary>
    [SugarColumn(ColumnName = "WF_MaxAirPress", Length = 18, DecimalDigits = 2, ColumnDescription = "最高气压")]
    public decimal WF_MaxAirPress { get; set; }

    /// <summary>提前升压</summary>
    [SugarColumn(ColumnName = "WF_PrBoost", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "提前升压")]
    public decimal? WF_PrBoost { get; set; }

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