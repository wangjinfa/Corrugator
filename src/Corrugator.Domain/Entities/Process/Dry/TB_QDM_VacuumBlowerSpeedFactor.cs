using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_VacuumBlowerSpeedFactor
/// </summary>
[SugarTable("W_QDM_VacuumBlowerSpeedFactor", TableDescription = "W_QDM_VacuumBlowerSpeedFactor")]
public class W_QDM_VacuumBlowerSpeedFactor
{
    /// <summary>速度</summary>
    [SugarColumn(ColumnName = "WSpeed", ColumnDescription = "速度")]
    public int WSpeed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WFactor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}