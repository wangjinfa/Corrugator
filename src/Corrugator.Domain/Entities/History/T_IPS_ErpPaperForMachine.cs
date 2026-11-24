using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸实材表
/// </summary>
[SugarTable("W_IPS_ErpPaperForMachine", TableDescription = "原纸实材表")]
public class W_IPS_ErpPaperForMachine
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_MachineID", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? WF_MachineID { get; set; }

    /// <summary>ERP材质代码</summary>
    [SugarColumn(ColumnName = "WF_ErpPaper", Length = 50, IsNullable = true, ColumnDescription = "ERP材质代码")]
    public string? WF_ErpPaper { get; set; }

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WF_ErpWidth", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅")]
    public decimal? WF_ErpWidth { get; set; }

    /// <summary>克重</summary>
    [SugarColumn(ColumnName = "WF_ErpWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "克重")]
    public decimal? WF_ErpWeight { get; set; }

    /// <summary>卷重</summary>
    [SugarColumn(ColumnName = "WF_ErpRollWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "卷重")]
    public decimal? WF_ErpRollWeight { get; set; }

    /// <summary>WF_ErpRollMeter</summary>
    [SugarColumn(ColumnName = "WF_ErpRollMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "WF_ErpRollMeter")]
    public decimal? WF_ErpRollMeter { get; set; }

    /// <summary>WF_GUID</summary>
    [SugarColumn(ColumnName = "WF_GUID", IsNullable = true, ColumnDescription = "WF_GUID")]
    public string? WF_GUID { get; set; }

    /// <summary>条码</summary>
    [SugarColumn(ColumnName = "WF_Barcode", IsNullable = true, ColumnDescription = "条码")]
    public string? WF_Barcode { get; set; }

    /// <summary>时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", ColumnDescription = "时间")]
    public DateTime WF_CreateTime { get; set; }

    /// <summary>状态 0：初始 1：加入队列 2：已使用</summary>
    [SugarColumn(ColumnName = "WF_State", ColumnDescription = "状态 0：初始 1：加入队列 2：已使用")]
    public int WF_State { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "WF_IsDel", ColumnDescription = "是否删除")]
    public bool WF_IsDel { get; set; }

    /// <summary>WF_SID</summary>
    [SugarColumn(ColumnName = "WF_SID", IsNullable = true, ColumnDescription = "WF_SID")]
    public int? WF_SID { get; set; }

    /// <summary>WF_Brand</summary>
    [SugarColumn(ColumnName = "WF_Brand", Length = 50, IsNullable = true, ColumnDescription = "WF_Brand")]
    public string? WF_Brand { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

    /// <summary>供应商触发器时间插入更新删除截断trg_insert_erp_paperAFTER</summary>
    [SugarColumn(ColumnName = "WF_Supplier", Length = 50, ColumnDescription = "供应商触发器时间插入更新删除截断trg_insert_erp_paperAFTER")]
    public string WF_Supplier { get; set; } = default!;

}