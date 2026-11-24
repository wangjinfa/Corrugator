using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// W_ProductTarget
/// </summary>
[SugarTable("W_ProductTarget", TableDescription = "W_ProductTarget")]
public class W_ProductTarget
{
    /// <summary>WSP_ID</summary>
    [SugarColumn(ColumnName = "WSP_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSP_ID")]
    public int WSP_ID { get; set; }

    /// <summary>编号</summary>
    [SugarColumn(ColumnName = "WSP_Number", Length = 50, IsNullable = true, ColumnDescription = "编号")]
    public string? WSP_Number { get; set; }

    /// <summary>WSP_Type</summary>
    [SugarColumn(ColumnName = "WSP_Type", Length = 50, IsNullable = true, ColumnDescription = "WSP_Type")]
    public string? WSP_Type { get; set; }

    /// <summary>目标值说明1</summary>
    [SugarColumn(ColumnName = "WSP_Describe1", Length = 50, IsNullable = true, ColumnDescription = "目标值说明1")]
    public string? WSP_Describe1 { get; set; }

    /// <summary>目标值1</summary>
    [SugarColumn(ColumnName = "WSP_TargetValue1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "目标值1")]
    public decimal? WSP_TargetValue1 { get; set; }

    /// <summary>目标值说明2</summary>
    [SugarColumn(ColumnName = "WSP_Describe2", Length = 50, IsNullable = true, ColumnDescription = "目标值说明2")]
    public string? WSP_Describe2 { get; set; }

    /// <summary>目标值2</summary>
    [SugarColumn(ColumnName = "WSP_TargetValue2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "目标值2")]
    public decimal? WSP_TargetValue2 { get; set; }

    /// <summary>属性</summary>
    [SugarColumn(ColumnName = "WSP_Property", Length = 50, IsNullable = true, ColumnDescription = "属性")]
    public string? WSP_Property { get; set; }

}