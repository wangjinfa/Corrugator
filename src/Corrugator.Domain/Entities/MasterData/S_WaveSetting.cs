using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 瓦楞辊设置表
/// </summary>
[SugarTable("W_WaveSetting", TableDescription = "瓦楞辊设置表")]
public class W_WaveSetting
{
    /// <summary>瓦楞辊编号</summary>
    [SugarColumn(ColumnName = "WCode", Length = 50, ColumnDescription = "瓦楞辊编号")]
    public string WCode { get; set; } = default!;

    /// <summary>瓦楞辊名称</summary>
    [SugarColumn(ColumnName = "WName", Length = 50, ColumnDescription = "瓦楞辊名称")]
    public string WName { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WWave", Length = 50, ColumnDescription = "楞型")]
    public string WWave { get; set; } = default!;

    /// <summary>楞高</summary>
    [SugarColumn(ColumnName = "WDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "楞高")]
    public decimal WDeep { get; set; }

    /// <summary>楞率</summary>
    [SugarColumn(ColumnName = "WRate", Length = 18, DecimalDigits = 4, ColumnDescription = "楞率")]
    public decimal WRate { get; set; }

    /// <summary>Position</summary>
    [SugarColumn(ColumnName = "WPosition", Length = 50, IsNullable = true, ColumnDescription = "Position")]
    public string? WPosition { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}