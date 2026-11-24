using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 耗材配置界面
/// </summary>
[SugarTable("S_Consumables", TableDescription = "耗材配置界面")]
public class S_Consumables
{
    /// <summary>SC_ID</summary>
    [SugarColumn(ColumnName = "SC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SC_ID")]
    public int SC_ID { get; set; }

    /// <summary>SC_Number</summary>
    [SugarColumn(ColumnName = "SC_Number", Length = 50, IsNullable = true, ColumnDescription = "SC_Number")]
    public string? SC_Number { get; set; }

    /// <summary>SC_Name</summary>
    [SugarColumn(ColumnName = "SC_Name", Length = 50, IsNullable = true, ColumnDescription = "SC_Name")]
    public string? SC_Name { get; set; }

    /// <summary>SC_Code</summary>
    [SugarColumn(ColumnName = "SC_Code", Length = 50, IsNullable = true, ColumnDescription = "SC_Code")]
    public string? SC_Code { get; set; }

    /// <summary>SC_Type</summary>
    [SugarColumn(ColumnName = "SC_Type", Length = 50, IsNullable = true, ColumnDescription = "SC_Type")]
    public string? SC_Type { get; set; }

    /// <summary>SC_Item</summary>
    [SugarColumn(ColumnName = "SC_Item", Length = 50, IsNullable = true, ColumnDescription = "SC_Item")]
    public string? SC_Item { get; set; }

    /// <summary>SC_Price</summary>
    [SugarColumn(ColumnName = "SC_Price", Length = 10, DecimalDigits = 2, IsNullable = true, ColumnDescription = "SC_Price")]
    public decimal? SC_Price { get; set; }

    /// <summary>SC_Property</summary>
    [SugarColumn(ColumnName = "SC_Property", Length = 50, IsNullable = true, ColumnDescription = "SC_Property")]
    public string? SC_Property { get; set; }

    /// <summary>SC_ShowPrice</summary>
    [SugarColumn(ColumnName = "SC_ShowPrice", IsNullable = true, ColumnDescription = "SC_ShowPrice")]
    public bool? SC_ShowPrice { get; set; }

    /// <summary>SC_IsUse</summary>
    [SugarColumn(ColumnName = "SC_IsUse", IsNullable = true, ColumnDescription = "SC_IsUse")]
    public bool? SC_IsUse { get; set; }

}