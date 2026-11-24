using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 瓦楞辊设置表
/// </summary>
[SugarTable("S_WaveSetting", TableDescription = "瓦楞辊设置表")]
public class S_WaveSetting
{
    /// <summary>瓦楞辊编号</summary>
    [SugarColumn(ColumnName = "Code", Length = 50, ColumnDescription = "瓦楞辊编号")]
    public string Code { get; set; } = default!;

    /// <summary>瓦楞辊名称</summary>
    [SugarColumn(ColumnName = "Name", Length = 50, ColumnDescription = "瓦楞辊名称")]
    public string Name { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "Wave", Length = 50, ColumnDescription = "楞型")]
    public string Wave { get; set; } = default!;

    /// <summary>楞高</summary>
    [SugarColumn(ColumnName = "Deep", Length = 18, DecimalDigits = 4, ColumnDescription = "楞高")]
    public decimal Deep { get; set; }

    /// <summary>楞率</summary>
    [SugarColumn(ColumnName = "Rate", Length = 18, DecimalDigits = 4, ColumnDescription = "楞率")]
    public decimal Rate { get; set; }

    /// <summary>Position</summary>
    [SugarColumn(ColumnName = "Position", Length = 50, IsNullable = true, ColumnDescription = "Position")]
    public string? Position { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}