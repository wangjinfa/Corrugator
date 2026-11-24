using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 热板蒸汽压力
/// </summary>
[SugarTable("TB_QDM_HotPlateSteamGram", TableDescription = "热板蒸汽压力")]
public class TB_QDM_HotPlateSteamGram
{
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

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最低气压</summary>
    [SugarColumn(ColumnName = "F_MinSteam", Length = 18, DecimalDigits = 2, ColumnDescription = "最低气压")]
    public decimal F_MinSteam { get; set; }

    /// <summary>最高气压</summary>
    [SugarColumn(ColumnName = "F_MaxSteam", Length = 18, DecimalDigits = 2, ColumnDescription = "最高气压")]
    public decimal F_MaxSteam { get; set; }

    /// <summary>最低克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最低克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最高克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最高克重")]
    public decimal F_MaxGram { get; set; }

    /// <summary>提前升压</summary>
    [SugarColumn(ColumnName = "F_PrPressIncrease", IsNullable = true, ColumnDescription = "提前升压")]
    public int? F_PrPressIncrease { get; set; }

    /// <summary>1段偏移值</summary>
    [SugarColumn(ColumnName = "F_Offset_1st", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "1段偏移值")]
    public decimal? F_Offset_1st { get; set; }

    /// <summary>2段偏移值</summary>
    [SugarColumn(ColumnName = "F_Offset_2nd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "2段偏移值")]
    public decimal? F_Offset_2nd { get; set; }

    /// <summary>3段偏移值</summary>
    [SugarColumn(ColumnName = "F_Offset_3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "3段偏移值")]
    public decimal? F_Offset_3rd { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}