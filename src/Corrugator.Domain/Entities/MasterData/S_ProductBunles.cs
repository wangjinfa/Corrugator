using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 产线错位资料设置表
/// </summary>
[SugarTable("S_ProductBunles", TableDescription = "产线错位资料设置表")]
public class S_ProductBunles
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "SPB_Wave", Length = 50, ColumnDescription = "楞型")]
    public string SPB_Wave { get; set; } = default!;

    /// <summary>判断开始条件</summary>
    [SugarColumn(ColumnName = "SPB_StartSec", Length = 18, DecimalDigits = 4, ColumnDescription = "判断开始条件")]
    public decimal SPB_StartSec { get; set; }

    /// <summary>判断结束条件</summary>
    [SugarColumn(ColumnName = "SPB_EndSec", Length = 18, DecimalDigits = 4, ColumnDescription = "判断结束条件")]
    public decimal SPB_EndSec { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "SPB_CreateTime", ColumnDescription = "创建日期")]
    public DateTime SPB_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "SPB_Creator", Length = 50, ColumnDescription = "创建用户")]
    public string SPB_Creator { get; set; } = default!;

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "SPB_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? SPB_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "SPB_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? SPB_Editor { get; set; }

    /// <summary>错位张数</summary>
    [SugarColumn(ColumnName = "SPB_BunleQty", ColumnDescription = "错位张数")]
    public int SPB_BunleQty { get; set; }

    /// <summary>SPB_ID</summary>
    [SugarColumn(ColumnName = "SPB_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SPB_ID")]
    public int SPB_ID { get; set; }

}