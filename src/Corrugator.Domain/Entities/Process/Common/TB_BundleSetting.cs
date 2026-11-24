using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// TB_BundleSetting
/// </summary>
[SugarTable("TB_BundleSetting", TableDescription = "TB_BundleSetting")]
public class TB_BundleSetting
{
    /// <summary>错位减半启用最小重量</summary>
    [SugarColumn(ColumnName = "HalfBundleMinWeight", ColumnDescription = "错位减半启用最小重量")]
    public int HalfBundleMinWeight { get; set; }

    /// <summary>错位减半启用最小张数</summary>
    [SugarColumn(ColumnName = "HalfBundleMinQty", ColumnDescription = "错位减半启用最小张数")]
    public int HalfBundleMinQty { get; set; }

    /// <summary>是否启用分纸错位功能</summary>
    [SugarColumn(ColumnName = "IsUseSplitPaperBundle", ColumnDescription = "是否启用分纸错位功能")]
    public bool IsUseSplitPaperBundle { get; set; }

    /// <summary>错位堆叠最小生产刀数</summary>
    [SugarColumn(ColumnName = "MinCutCount", ColumnDescription = "错位堆叠最小生产刀数")]
    public int MinCutCount { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}