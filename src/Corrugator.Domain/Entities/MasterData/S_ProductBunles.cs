using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 产线错位资料设置表
/// </summary>
[SugarTable("W_ProductBunles", TableDescription = "产线错位资料设置表")]
public class W_ProductBunles
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WSPB_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WSPB_Wave { get; set; } = default!;

    /// <summary>判断开始条件</summary>
    [SugarColumn(ColumnName = "WSPB_StartSec", Length = 18, DecimalDigits = 4, ColumnDescription = "判断开始条件")]
    public decimal WSPB_StartSec { get; set; }

    /// <summary>判断结束条件</summary>
    [SugarColumn(ColumnName = "WSPB_EndSec", Length = 18, DecimalDigits = 4, ColumnDescription = "判断结束条件")]
    public decimal WSPB_EndSec { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WSPB_CreateTime", ColumnDescription = "创建日期")]
    public DateTime WSPB_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "WSPB_Creator", Length = 50, ColumnDescription = "创建用户")]
    public string WSPB_Creator { get; set; } = default!;

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "WSPB_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? WSPB_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "WSPB_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? WSPB_Editor { get; set; }

    /// <summary>错位张数</summary>
    [SugarColumn(ColumnName = "WSPB_BunleQty", ColumnDescription = "错位张数")]
    public int WSPB_BunleQty { get; set; }

    /// <summary>WSPB_ID</summary>
    [SugarColumn(ColumnName = "WSPB_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSPB_ID")]
    public int WSPB_ID { get; set; }

}