using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_VacuumBlowerSpeedFactor
/// </summary>
[SugarTable("TB_QDM_VacuumBlowerSpeedFactor", TableDescription = "TB_QDM_VacuumBlowerSpeedFactor")]
public class TB_QDM_VacuumBlowerSpeedFactor
{
    /// <summary>速度</summary>
    [SugarColumn(ColumnName = "Speed", ColumnDescription = "速度")]
    public int Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal Factor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}