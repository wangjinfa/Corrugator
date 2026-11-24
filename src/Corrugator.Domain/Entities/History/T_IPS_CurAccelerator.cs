using SqlSugar;

namespace Corrugator.Domain.Entities.History;

/// <summary>
/// PLC加湿器
/// </summary>
[SugarTable("W_IPS_CurAccelerator", TableDescription = "PLC加湿器")]
public class W_IPS_CurAccelerator
{
    /// <summary>WF_IsUse</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "WF_IsUse")]
    public bool WF_IsUse { get; set; }

    /// <summary>WF_SetValue</summary>
    [SugarColumn(ColumnName = "WF_SetValue", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_SetValue")]
    public decimal WF_SetValue { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}