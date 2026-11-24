using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 瓦楞辊对照表
/// </summary>
[SugarTable("W_WaveComparison", TableDescription = "瓦楞辊对照表")]
public class W_WaveComparison
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WWave", Length = 50, ColumnDescription = "楞型")]
    public string WWave { get; set; } = default!;

    /// <summary>Type</summary>
    [SugarColumn(ColumnName = "WType", Length = 50, ColumnDescription = "Type")]
    public string WType { get; set; } = default!;

    /// <summary>瓦楞辊编号</summary>
    [SugarColumn(ColumnName = "WCode", Length = 50, ColumnDescription = "瓦楞辊编号")]
    public string WCode { get; set; } = default!;

    /// <summary>带分隔符的id字符串拼接</summary>
    [SugarColumn(ColumnName = "WIDExtra", Length = 50, ColumnDescription = "带分隔符的id字符串拼接")]
    public string WIDExtra { get; set; } = default!;

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}