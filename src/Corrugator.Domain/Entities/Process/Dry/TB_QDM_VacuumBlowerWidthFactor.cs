using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_VacuumBlowerWidthFactor
/// </summary>
[SugarTable("TB_QDM_VacuumBlowerWidthFactor", TableDescription = "TB_QDM_VacuumBlowerWidthFactor")]
public class TB_QDM_VacuumBlowerWidthFactor
{
    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "Width", Length = 50, ColumnDescription = "门幅")]
    public string Width { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "Wave", Length = 50, ColumnDescription = "楞型")]
    public string Wave { get; set; } = default!;

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal Factor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}