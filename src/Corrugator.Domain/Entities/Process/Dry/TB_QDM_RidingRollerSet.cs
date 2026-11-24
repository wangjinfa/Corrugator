using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_RidingRollerSet
/// </summary>
[SugarTable("TB_QDM_RidingRollerSet", TableDescription = "TB_QDM_RidingRollerSet")]
public class TB_QDM_RidingRollerSet
{
    /// <summary>CorrugatedRollCode</summary>
    [SugarColumn(ColumnName = "CorrugatedRollCode", Length = 50, ColumnDescription = "CorrugatedRollCode")]
    public string CorrugatedRollCode { get; set; } = default!;

    /// <summary>Deep</summary>
    [SugarColumn(ColumnName = "Deep", Length = 18, DecimalDigits = 2, ColumnDescription = "Deep")]
    public decimal Deep { get; set; }

    /// <summary>RidingDeep</summary>
    [SugarColumn(ColumnName = "RidingDeep", Length = 18, DecimalDigits = 2, ColumnDescription = "RidingDeep")]
    public decimal RidingDeep { get; set; }

    /// <summary>MinValue</summary>
    [SugarColumn(ColumnName = "MinValue", Length = 18, DecimalDigits = 2, ColumnDescription = "MinValue")]
    public decimal MinValue { get; set; }

    /// <summary>MaxValue</summary>
    [SugarColumn(ColumnName = "MaxValue", Length = 18, DecimalDigits = 2, ColumnDescription = "MaxValue")]
    public decimal MaxValue { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}