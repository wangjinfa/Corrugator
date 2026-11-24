using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 订单编辑版本表
/// </summary>
[SugarTable("W_PMS_OrderEditVersion", TableDescription = "订单编辑版本表")]
public class W_PMS_OrderEditVersion
{
    /// <summary>是否锁定</summary>
    [SugarColumn(ColumnName = "WF_IsLock", IsNullable = true, ColumnDescription = "是否锁定")]
    public bool? WF_IsLock { get; set; }

    /// <summary>用户ID</summary>
    [SugarColumn(ColumnName = "WF_UID", IsNullable = true, ColumnDescription = "用户ID")]
    public int? WF_UID { get; set; }

    /// <summary>上锁时间</summary>
    [SugarColumn(ColumnName = "WF_LockTime", IsNullable = true, ColumnDescription = "上锁时间")]
    public DateTime? WF_LockTime { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}