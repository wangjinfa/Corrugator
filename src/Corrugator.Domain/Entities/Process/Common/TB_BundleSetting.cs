using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// W_BundleSetting
/// </summary>
[SugarTable("W_BundleSetting", TableDescription = "W_BundleSetting")]
public class W_BundleSetting
{
    /// <summary>错位减半启用最小重量</summary>
    [SugarColumn(ColumnName = "WHalfBundleMinWeight", ColumnDescription = "错位减半启用最小重量")]
    public int WHalfBundleMinWeight { get; set; }

    /// <summary>错位减半启用最小张数</summary>
    [SugarColumn(ColumnName = "WHalfBundleMinQty", ColumnDescription = "错位减半启用最小张数")]
    public int WHalfBundleMinQty { get; set; }

    /// <summary>是否启用分纸错位功能</summary>
    [SugarColumn(ColumnName = "WIsUseSplitPaperBundle", ColumnDescription = "是否启用分纸错位功能")]
    public bool WIsUseSplitPaperBundle { get; set; }

    /// <summary>错位堆叠最小生产刀数</summary>
    [SugarColumn(ColumnName = "WMinCutCount", ColumnDescription = "错位堆叠最小生产刀数")]
    public int WMinCutCount { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}