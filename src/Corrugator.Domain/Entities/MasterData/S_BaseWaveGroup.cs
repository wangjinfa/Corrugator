using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 基础楞型组合
/// </summary>
[SugarTable("W_BaseWaveGroup", TableDescription = "基础楞型组合")]
public class W_BaseWaveGroup
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WSBG_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WSBG_Wave { get; set; } = default!;

    /// <summary>是否使用面纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseDFOuter", IsNullable = true, ColumnDescription = "是否使用面纸")]
    public bool? WSBG_IsUseDFOuter { get; set; }

    /// <summary>是否使用SF1芯纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF1Medium", IsNullable = true, ColumnDescription = "是否使用SF1芯纸")]
    public bool? WSBG_IsUseSF1Medium { get; set; }

    /// <summary>是否使用SF1里纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF1Inside", IsNullable = true, ColumnDescription = "是否使用SF1里纸")]
    public bool? WSBG_IsUseSF1Inside { get; set; }

    /// <summary>是否使用SF2芯纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF2Medium", IsNullable = true, ColumnDescription = "是否使用SF2芯纸")]
    public bool? WSBG_IsUseSF2Medium { get; set; }

    /// <summary>是否使用SF2里纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF2Inside", IsNullable = true, ColumnDescription = "是否使用SF2里纸")]
    public bool? WSBG_IsUseSF2Inside { get; set; }

    /// <summary>是否使用SF3芯纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF3Medium", IsNullable = true, ColumnDescription = "是否使用SF3芯纸")]
    public bool? WSBG_IsUseSF3Medium { get; set; }

    /// <summary>是否使用SF3里纸</summary>
    [SugarColumn(ColumnName = "WSBG_IsUseSF3Inside", IsNullable = true, ColumnDescription = "是否使用SF3里纸")]
    public bool? WSBG_IsUseSF3Inside { get; set; }

    /// <summary>是否常用</summary>
    [SugarColumn(ColumnName = "WSBG_IsOftenUse", IsNullable = true, ColumnDescription = "是否常用")]
    public bool? WSBG_IsOftenUse { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "WSBG_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? WSBG_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WSBG_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WSBG_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "WSBG_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? WSBG_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WSBG_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WSBG_EditTime { get; set; }

    /// <summary>WSBG_ID</summary>
    [SugarColumn(ColumnName = "WSBG_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSBG_ID")]
    public int WSBG_ID { get; set; }

}