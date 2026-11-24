using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// PLC加湿器
/// </summary>
[SugarTable("T_IPS_CurAccelerator", TableDescription = "PLC加湿器")]
public class T_IPS_CurAccelerator
{
    /// <summary>F_IsUse</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "F_IsUse")]
    public bool F_IsUse { get; set; }

    /// <summary>F_SetValue</summary>
    [SugarColumn(ColumnName = "F_SetValue", Length = 18, DecimalDigits = 2, ColumnDescription = "F_SetValue")]
    public decimal F_SetValue { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}