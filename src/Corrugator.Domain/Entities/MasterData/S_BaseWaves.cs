using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 基础楞型表
/// </summary>
[SugarTable("S_BaseWaves", TableDescription = "基础楞型表")]
public class S_BaseWaves
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "SBW_Wave", Length = 10, ColumnDescription = "楞型")]
    public string SBW_Wave { get; set; } = default!;

    /// <summary>楞高</summary>
    [SugarColumn(ColumnName = "SBW_WDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "楞高")]
    public decimal SBW_WDeep { get; set; }

    /// <summary>楞率</summary>
    [SugarColumn(ColumnName = "SBW_WRate", Length = 18, DecimalDigits = 4, ColumnDescription = "楞率")]
    public decimal SBW_WRate { get; set; }

    /// <summary>是否在用</summary>
    [SugarColumn(ColumnName = "SBW_IsUse", ColumnDescription = "是否在用")]
    public bool SBW_IsUse { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "SBW_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? SBW_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "SBW_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? SBW_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "SBW_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? SBW_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "SBW_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? SBW_EditTime { get; set; }

    /// <summary>SBW_ID</summary>
    [SugarColumn(ColumnName = "SBW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SBW_ID")]
    public int SBW_ID { get; set; }

}