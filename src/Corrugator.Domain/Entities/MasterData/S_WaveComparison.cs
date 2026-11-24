using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 瓦楞辊对照表
/// </summary>
[SugarTable("S_WaveComparison", TableDescription = "瓦楞辊对照表")]
public class S_WaveComparison
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "Wave", Length = 50, ColumnDescription = "楞型")]
    public string Wave { get; set; } = default!;

    /// <summary>Type</summary>
    [SugarColumn(ColumnName = "Type", Length = 50, ColumnDescription = "Type")]
    public string Type { get; set; } = default!;

    /// <summary>瓦楞辊编号</summary>
    [SugarColumn(ColumnName = "Code", Length = 50, ColumnDescription = "瓦楞辊编号")]
    public string Code { get; set; } = default!;

    /// <summary>带分隔符的id字符串拼接</summary>
    [SugarColumn(ColumnName = "IDExtra", Length = 50, ColumnDescription = "带分隔符的id字符串拼接")]
    public string IDExtra { get; set; } = default!;

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}