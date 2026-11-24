using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// S_ProductTarget
/// </summary>
[SugarTable("S_ProductTarget", TableDescription = "S_ProductTarget")]
public class S_ProductTarget
{
    /// <summary>SP_ID</summary>
    [SugarColumn(ColumnName = "SP_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SP_ID")]
    public int SP_ID { get; set; }

    /// <summary>编号</summary>
    [SugarColumn(ColumnName = "SP_Number", Length = 50, IsNullable = true, ColumnDescription = "编号")]
    public string? SP_Number { get; set; }

    /// <summary>SP_Type</summary>
    [SugarColumn(ColumnName = "SP_Type", Length = 50, IsNullable = true, ColumnDescription = "SP_Type")]
    public string? SP_Type { get; set; }

    /// <summary>目标值说明1</summary>
    [SugarColumn(ColumnName = "SP_Describe1", Length = 50, IsNullable = true, ColumnDescription = "目标值说明1")]
    public string? SP_Describe1 { get; set; }

    /// <summary>目标值1</summary>
    [SugarColumn(ColumnName = "SP_TargetValue1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "目标值1")]
    public decimal? SP_TargetValue1 { get; set; }

    /// <summary>目标值说明2</summary>
    [SugarColumn(ColumnName = "SP_Describe2", Length = 50, IsNullable = true, ColumnDescription = "目标值说明2")]
    public string? SP_Describe2 { get; set; }

    /// <summary>目标值2</summary>
    [SugarColumn(ColumnName = "SP_TargetValue2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "目标值2")]
    public decimal? SP_TargetValue2 { get; set; }

    /// <summary>属性</summary>
    [SugarColumn(ColumnName = "SP_Property", Length = 50, IsNullable = true, ColumnDescription = "属性")]
    public string? SP_Property { get; set; }

}