using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// W_Plc_AcceleratorSet
/// </summary>
[SugarTable("W_Plc_AcceleratorSet", TableDescription = "W_Plc_AcceleratorSet")]
public class W_Plc_AcceleratorSet
{
    /// <summary>WF_Speed</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "WF_Speed")]
    public int WF_Speed { get; set; }

    /// <summary>WF_Coef</summary>
    [SugarColumn(ColumnName = "WF_Coef", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_Coef")]
    public decimal WF_Coef { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}