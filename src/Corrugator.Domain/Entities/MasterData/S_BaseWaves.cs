using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 基础楞型表
/// </summary>
[SugarTable("W_BaseWaves", TableDescription = "基础楞型表")]
public class W_BaseWaves
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WSBW_Wave", Length = 10, ColumnDescription = "楞型")]
    public string WSBW_Wave { get; set; } = default!;

    /// <summary>楞高</summary>
    [SugarColumn(ColumnName = "WSBW_WDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "楞高")]
    public decimal WSBW_WDeep { get; set; }

    /// <summary>楞率</summary>
    [SugarColumn(ColumnName = "WSBW_WRate", Length = 18, DecimalDigits = 4, ColumnDescription = "楞率")]
    public decimal WSBW_WRate { get; set; }

    /// <summary>是否在用</summary>
    [SugarColumn(ColumnName = "WSBW_IsUse", ColumnDescription = "是否在用")]
    public bool WSBW_IsUse { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "WSBW_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? WSBW_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WSBW_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WSBW_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "WSBW_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? WSBW_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WSBW_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WSBW_EditTime { get; set; }

    /// <summary>WSBW_ID</summary>
    [SugarColumn(ColumnName = "WSBW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSBW_ID")]
    public int WSBW_ID { get; set; }

}