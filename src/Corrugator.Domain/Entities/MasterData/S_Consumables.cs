using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 耗材配置界面
/// </summary>
[SugarTable("W_Consumables", TableDescription = "耗材配置界面")]
public class W_Consumables
{
    /// <summary>WSC_ID</summary>
    [SugarColumn(ColumnName = "WSC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSC_ID")]
    public int WSC_ID { get; set; }

    /// <summary>WSC_Number</summary>
    [SugarColumn(ColumnName = "WSC_Number", Length = 50, IsNullable = true, ColumnDescription = "WSC_Number")]
    public string? WSC_Number { get; set; }

    /// <summary>WSC_Name</summary>
    [SugarColumn(ColumnName = "WSC_Name", Length = 50, IsNullable = true, ColumnDescription = "WSC_Name")]
    public string? WSC_Name { get; set; }

    /// <summary>WSC_Code</summary>
    [SugarColumn(ColumnName = "WSC_Code", Length = 50, IsNullable = true, ColumnDescription = "WSC_Code")]
    public string? WSC_Code { get; set; }

    /// <summary>WSC_Type</summary>
    [SugarColumn(ColumnName = "WSC_Type", Length = 50, IsNullable = true, ColumnDescription = "WSC_Type")]
    public string? WSC_Type { get; set; }

    /// <summary>WSC_Item</summary>
    [SugarColumn(ColumnName = "WSC_Item", Length = 50, IsNullable = true, ColumnDescription = "WSC_Item")]
    public string? WSC_Item { get; set; }

    /// <summary>WSC_Price</summary>
    [SugarColumn(ColumnName = "WSC_Price", Length = 10, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WSC_Price")]
    public decimal? WSC_Price { get; set; }

    /// <summary>WSC_Property</summary>
    [SugarColumn(ColumnName = "WSC_Property", Length = 50, IsNullable = true, ColumnDescription = "WSC_Property")]
    public string? WSC_Property { get; set; }

    /// <summary>WSC_ShowPrice</summary>
    [SugarColumn(ColumnName = "WSC_ShowPrice", IsNullable = true, ColumnDescription = "WSC_ShowPrice")]
    public bool? WSC_ShowPrice { get; set; }

    /// <summary>WSC_IsUse</summary>
    [SugarColumn(ColumnName = "WSC_IsUse", IsNullable = true, ColumnDescription = "WSC_IsUse")]
    public bool? WSC_IsUse { get; set; }

}