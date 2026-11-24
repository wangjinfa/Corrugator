using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸实材表
/// </summary>
[SugarTable("T_IPS_SPPaper", TableDescription = "原纸实材表")]
public class T_IPS_SPPaper
{
    /// <summary>F_MachineID</summary>
    [SugarColumn(ColumnName = "F_MachineID", Length = 50, IsNullable = true, ColumnDescription = "F_MachineID")]
    public string? F_MachineID { get; set; }

    /// <summary>F_Brand</summary>
    [SugarColumn(ColumnName = "F_Brand", Length = 50, IsNullable = true, ColumnDescription = "F_Brand")]
    public string? F_Brand { get; set; }

    /// <summary>F_ErpPaper</summary>
    [SugarColumn(ColumnName = "F_ErpPaper", Length = 50, IsNullable = true, ColumnDescription = "F_ErpPaper")]
    public string? F_ErpPaper { get; set; }

    /// <summary>F_ErpWidth</summary>
    [SugarColumn(ColumnName = "F_ErpWidth", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_ErpWidth")]
    public decimal? F_ErpWidth { get; set; }

    /// <summary>F_ErpWeight</summary>
    [SugarColumn(ColumnName = "F_ErpWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_ErpWeight")]
    public decimal? F_ErpWeight { get; set; }

    /// <summary>F_ErpRollWeight</summary>
    [SugarColumn(ColumnName = "F_ErpRollWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_ErpRollWeight")]
    public decimal? F_ErpRollWeight { get; set; }

    /// <summary>F_ErpRollMeter</summary>
    [SugarColumn(ColumnName = "F_ErpRollMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_ErpRollMeter")]
    public decimal? F_ErpRollMeter { get; set; }

    /// <summary>F_Barcode</summary>
    [SugarColumn(ColumnName = "F_Barcode", IsNullable = true, ColumnDescription = "F_Barcode")]
    public string? F_Barcode { get; set; }

    /// <summary>F_CreateTime</summary>
    [SugarColumn(ColumnName = "F_CreateTime", ColumnDescription = "F_CreateTime")]
    public DateTime F_CreateTime { get; set; }

    /// <summary>F_State</summary>
    [SugarColumn(ColumnName = "F_State", ColumnDescription = "F_State")]
    public int F_State { get; set; }

    /// <summary>F_IsDel</summary>
    [SugarColumn(ColumnName = "F_IsDel", ColumnDescription = "F_IsDel")]
    public bool F_IsDel { get; set; }

    /// <summary>F_GUID</summary>
    [SugarColumn(ColumnName = "F_GUID", IsNullable = true, ColumnDescription = "F_GUID")]
    public string? F_GUID { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

    /// <summary>供应商</summary>
    [SugarColumn(ColumnName = "F_Supplier", Length = 50, IsNullable = true, ColumnDescription = "供应商")]
    public string? F_Supplier { get; set; }

}