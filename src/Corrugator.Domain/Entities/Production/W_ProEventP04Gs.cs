using SqlSugar;

namespace Corrugator.Domain.Entities.Production;

/// <summary>
/// 克重变动表
/// </summary>
[SugarTable("W_ProEventP04Gs", TableDescription = "克重变动表")]
public class W_ProEventP04Gs
{
    /// <summary>材质标识</summary>
    [SugarColumn(ColumnName = "WP_QualityId", Length = 50, IsNullable = true, ColumnDescription = "材质标识")]
    public string? WP_QualityId { get; set; }

    /// <summary>开始时间</summary>
    [SugarColumn(ColumnName = "WP_StartTime", IsNullable = true, ColumnDescription = "开始时间")]
    public DateTime? WP_StartTime { get; set; }

    /// <summary>结束时间</summary>
    [SugarColumn(ColumnName = "WP_EndTime", IsNullable = true, ColumnDescription = "结束时间")]
    public DateTime? WP_EndTime { get; set; }

    /// <summary>周期</summary>
    [SugarColumn(ColumnName = "WP_Duration", Length = 20, IsNullable = true, ColumnDescription = "周期")]
    public string? WP_Duration { get; set; }

    /// <summary>材质长米数</summary>
    [SugarColumn(ColumnName = "WP_LiealMeters", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "材质长米数")]
    public decimal? WP_LiealMeters { get; set; }

    /// <summary>总的生产平米</summary>
    [SugarColumn(ColumnName = "WP_TotalProduced", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "总的生产平米")]
    public decimal? WP_TotalProduced { get; set; }

    /// <summary>修边平米数</summary>
    [SugarColumn(ColumnName = "WP_SideTrim", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "修边平米数")]
    public decimal? WP_SideTrim { get; set; }

    /// <summary>最大车速</summary>
    [SugarColumn(ColumnName = "WP_MaxV", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "最大车速")]
    public decimal? WP_MaxV { get; set; }

    /// <summary>平均车速</summary>
    [SugarColumn(ColumnName = "WP_AverageV", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "平均车速")]
    public decimal? WP_AverageV { get; set; }

    /// <summary>WP_Id</summary>
    [SugarColumn(ColumnName = "WP_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WP_Id")]
    public int WP_Id { get; set; }

}