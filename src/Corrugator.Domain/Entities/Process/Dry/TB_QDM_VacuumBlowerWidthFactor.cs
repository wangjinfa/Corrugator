using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_VacuumBlowerWidthFactor
/// </summary>
[SugarTable("W_QDM_VacuumBlowerWidthFactor", TableDescription = "W_QDM_VacuumBlowerWidthFactor")]
public class W_QDM_VacuumBlowerWidthFactor
{
    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WWidth", Length = 50, ColumnDescription = "门幅")]
    public string WWidth { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WWave", Length = 50, ColumnDescription = "楞型")]
    public string WWave { get; set; } = default!;

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WFactor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}