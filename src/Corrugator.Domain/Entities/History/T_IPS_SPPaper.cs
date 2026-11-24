using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸实材表
/// </summary>
[SugarTable("W_IPS_SPPaper", TableDescription = "原纸实材表")]
public class W_IPS_SPPaper
{
    /// <summary>WF_MachineID</summary>
    [SugarColumn(ColumnName = "WF_MachineID", Length = 50, IsNullable = true, ColumnDescription = "WF_MachineID")]
    public string? WF_MachineID { get; set; }

    /// <summary>WF_Brand</summary>
    [SugarColumn(ColumnName = "WF_Brand", Length = 50, IsNullable = true, ColumnDescription = "WF_Brand")]
    public string? WF_Brand { get; set; }

    /// <summary>WF_ErpPaper</summary>
    [SugarColumn(ColumnName = "WF_ErpPaper", Length = 50, IsNullable = true, ColumnDescription = "WF_ErpPaper")]
    public string? WF_ErpPaper { get; set; }

    /// <summary>WF_ErpWidth</summary>
    [SugarColumn(ColumnName = "WF_ErpWidth", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_ErpWidth")]
    public decimal? WF_ErpWidth { get; set; }

    /// <summary>WF_ErpWeight</summary>
    [SugarColumn(ColumnName = "WF_ErpWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_ErpWeight")]
    public decimal? WF_ErpWeight { get; set; }

    /// <summary>WF_ErpRollWeight</summary>
    [SugarColumn(ColumnName = "WF_ErpRollWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_ErpRollWeight")]
    public decimal? WF_ErpRollWeight { get; set; }

    /// <summary>WF_ErpRollMeter</summary>
    [SugarColumn(ColumnName = "WF_ErpRollMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_ErpRollMeter")]
    public decimal? WF_ErpRollMeter { get; set; }

    /// <summary>WF_Barcode</summary>
    [SugarColumn(ColumnName = "WF_Barcode", IsNullable = true, ColumnDescription = "WF_Barcode")]
    public string? WF_Barcode { get; set; }

    /// <summary>WF_CreateTime</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", ColumnDescription = "WF_CreateTime")]
    public DateTime WF_CreateTime { get; set; }

    /// <summary>WF_State</summary>
    [SugarColumn(ColumnName = "WF_State", ColumnDescription = "WF_State")]
    public int WF_State { get; set; }

    /// <summary>WF_IsDel</summary>
    [SugarColumn(ColumnName = "WF_IsDel", ColumnDescription = "WF_IsDel")]
    public bool WF_IsDel { get; set; }

    /// <summary>WF_GUID</summary>
    [SugarColumn(ColumnName = "WF_GUID", IsNullable = true, ColumnDescription = "WF_GUID")]
    public string? WF_GUID { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

    /// <summary>供应商</summary>
    [SugarColumn(ColumnName = "WF_Supplier", Length = 50, IsNullable = true, ColumnDescription = "供应商")]
    public string? WF_Supplier { get; set; }

}