using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 热板蒸汽压力
/// </summary>
[SugarTable("W_QDM_HotPlateSteamGram", TableDescription = "热板蒸汽压力")]
public class W_QDM_HotPlateSteamGram
{
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

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最低气压</summary>
    [SugarColumn(ColumnName = "WF_MinSteam", Length = 18, DecimalDigits = 2, ColumnDescription = "最低气压")]
    public decimal WF_MinSteam { get; set; }

    /// <summary>最高气压</summary>
    [SugarColumn(ColumnName = "WF_MaxSteam", Length = 18, DecimalDigits = 2, ColumnDescription = "最高气压")]
    public decimal WF_MaxSteam { get; set; }

    /// <summary>最低克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最低克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最高克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最高克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>提前升压</summary>
    [SugarColumn(ColumnName = "WF_PrPressIncrease", IsNullable = true, ColumnDescription = "提前升压")]
    public int? WF_PrPressIncrease { get; set; }

    /// <summary>1段偏移值</summary>
    [SugarColumn(ColumnName = "WF_Offset_1st", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "1段偏移值")]
    public decimal? WF_Offset_1st { get; set; }

    /// <summary>2段偏移值</summary>
    [SugarColumn(ColumnName = "WF_Offset_2nd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "2段偏移值")]
    public decimal? WF_Offset_2nd { get; set; }

    /// <summary>3段偏移值</summary>
    [SugarColumn(ColumnName = "WF_Offset_3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "3段偏移值")]
    public decimal? WF_Offset_3rd { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}