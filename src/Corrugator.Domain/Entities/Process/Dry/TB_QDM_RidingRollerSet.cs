using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_RidingRollerSet
/// </summary>
[SugarTable("W_QDM_RidingRollerSet", TableDescription = "W_QDM_RidingRollerSet")]
public class W_QDM_RidingRollerSet
{
    /// <summary>CorrugatedRollCode</summary>
    [SugarColumn(ColumnName = "WCorrugatedRollCode", Length = 50, ColumnDescription = "CorrugatedRollCode")]
    public string WCorrugatedRollCode { get; set; } = default!;

    /// <summary>Deep</summary>
    [SugarColumn(ColumnName = "WDeep", Length = 18, DecimalDigits = 2, ColumnDescription = "Deep")]
    public decimal WDeep { get; set; }

    /// <summary>RidingDeep</summary>
    [SugarColumn(ColumnName = "WRidingDeep", Length = 18, DecimalDigits = 2, ColumnDescription = "RidingDeep")]
    public decimal WRidingDeep { get; set; }

    /// <summary>MinValue</summary>
    [SugarColumn(ColumnName = "WMinValue", Length = 18, DecimalDigits = 2, ColumnDescription = "MinValue")]
    public decimal WMinValue { get; set; }

    /// <summary>MaxValue</summary>
    [SugarColumn(ColumnName = "WMaxValue", Length = 18, DecimalDigits = 2, ColumnDescription = "MaxValue")]
    public decimal WMaxValue { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}