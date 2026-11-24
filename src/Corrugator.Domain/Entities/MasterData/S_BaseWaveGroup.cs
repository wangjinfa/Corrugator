using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 基础楞型组合
/// </summary>
[SugarTable("S_BaseWaveGroup", TableDescription = "基础楞型组合")]
public class S_BaseWaveGroup
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "SBG_Wave", Length = 50, ColumnDescription = "楞型")]
    public string SBG_Wave { get; set; } = default!;

    /// <summary>是否使用面纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseDFOuter", IsNullable = true, ColumnDescription = "是否使用面纸")]
    public bool? SBG_IsUseDFOuter { get; set; }

    /// <summary>是否使用SF1芯纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF1Medium", IsNullable = true, ColumnDescription = "是否使用SF1芯纸")]
    public bool? SBG_IsUseSF1Medium { get; set; }

    /// <summary>是否使用SF1里纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF1Inside", IsNullable = true, ColumnDescription = "是否使用SF1里纸")]
    public bool? SBG_IsUseSF1Inside { get; set; }

    /// <summary>是否使用SF2芯纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF2Medium", IsNullable = true, ColumnDescription = "是否使用SF2芯纸")]
    public bool? SBG_IsUseSF2Medium { get; set; }

    /// <summary>是否使用SF2里纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF2Inside", IsNullable = true, ColumnDescription = "是否使用SF2里纸")]
    public bool? SBG_IsUseSF2Inside { get; set; }

    /// <summary>是否使用SF3芯纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF3Medium", IsNullable = true, ColumnDescription = "是否使用SF3芯纸")]
    public bool? SBG_IsUseSF3Medium { get; set; }

    /// <summary>是否使用SF3里纸</summary>
    [SugarColumn(ColumnName = "SBG_IsUseSF3Inside", IsNullable = true, ColumnDescription = "是否使用SF3里纸")]
    public bool? SBG_IsUseSF3Inside { get; set; }

    /// <summary>是否常用</summary>
    [SugarColumn(ColumnName = "SBG_IsOftenUse", IsNullable = true, ColumnDescription = "是否常用")]
    public bool? SBG_IsOftenUse { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "SBG_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? SBG_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "SBG_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? SBG_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "SBG_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? SBG_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "SBG_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? SBG_EditTime { get; set; }

    /// <summary>SBG_ID</summary>
    [SugarColumn(ColumnName = "SBG_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SBG_ID")]
    public int SBG_ID { get; set; }

}