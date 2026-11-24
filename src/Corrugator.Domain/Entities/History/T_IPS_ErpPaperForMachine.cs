using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 原纸实材表
/// </summary>
[SugarTable("T_IPS_ErpPaperForMachine", TableDescription = "原纸实材表")]
public class T_IPS_ErpPaperForMachine
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_MachineID", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? F_MachineID { get; set; }

    /// <summary>ERP材质代码</summary>
    [SugarColumn(ColumnName = "F_ErpPaper", Length = 50, IsNullable = true, ColumnDescription = "ERP材质代码")]
    public string? F_ErpPaper { get; set; }

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "F_ErpWidth", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "门幅")]
    public decimal? F_ErpWidth { get; set; }

    /// <summary>克重</summary>
    [SugarColumn(ColumnName = "F_ErpWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "克重")]
    public decimal? F_ErpWeight { get; set; }

    /// <summary>卷重</summary>
    [SugarColumn(ColumnName = "F_ErpRollWeight", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "卷重")]
    public decimal? F_ErpRollWeight { get; set; }

    /// <summary>F_ErpRollMeter</summary>
    [SugarColumn(ColumnName = "F_ErpRollMeter", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "F_ErpRollMeter")]
    public decimal? F_ErpRollMeter { get; set; }

    /// <summary>F_GUID</summary>
    [SugarColumn(ColumnName = "F_GUID", IsNullable = true, ColumnDescription = "F_GUID")]
    public string? F_GUID { get; set; }

    /// <summary>条码</summary>
    [SugarColumn(ColumnName = "F_Barcode", IsNullable = true, ColumnDescription = "条码")]
    public string? F_Barcode { get; set; }

    /// <summary>时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", ColumnDescription = "时间")]
    public DateTime F_CreateTime { get; set; }

    /// <summary>状态 0：初始 1：加入队列 2：已使用</summary>
    [SugarColumn(ColumnName = "F_State", ColumnDescription = "状态 0：初始 1：加入队列 2：已使用")]
    public int F_State { get; set; }

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "F_IsDel", ColumnDescription = "是否删除")]
    public bool F_IsDel { get; set; }

    /// <summary>F_SID</summary>
    [SugarColumn(ColumnName = "F_SID", IsNullable = true, ColumnDescription = "F_SID")]
    public int? F_SID { get; set; }

    /// <summary>F_Brand</summary>
    [SugarColumn(ColumnName = "F_Brand", Length = 50, IsNullable = true, ColumnDescription = "F_Brand")]
    public string? F_Brand { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

    /// <summary>供应商触发器时间插入更新删除截断trg_insert_erp_paperAFTER</summary>
    [SugarColumn(ColumnName = "F_Supplier", Length = 50, ColumnDescription = "供应商触发器时间插入更新删除截断trg_insert_erp_paperAFTER")]
    public string F_Supplier { get; set; } = default!;

}