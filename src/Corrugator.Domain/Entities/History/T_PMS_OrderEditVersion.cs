using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// 订单编辑版本表
/// </summary>
[SugarTable("T_PMS_OrderEditVersion", TableDescription = "订单编辑版本表")]
public class T_PMS_OrderEditVersion
{
    /// <summary>是否锁定</summary>
    [SugarColumn(ColumnName = "F_IsLock", IsNullable = true, ColumnDescription = "是否锁定")]
    public bool? F_IsLock { get; set; }

    /// <summary>用户ID</summary>
    [SugarColumn(ColumnName = "F_UID", IsNullable = true, ColumnDescription = "用户ID")]
    public int? F_UID { get; set; }

    /// <summary>上锁时间</summary>
    [SugarColumn(ColumnName = "F_LockTime", IsNullable = true, ColumnDescription = "上锁时间")]
    public DateTime? F_LockTime { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}