using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_RidingRollerExtrusion
/// </summary>
[SugarTable("TB_QDM_RidingRollerExtrusion", TableDescription = "TB_QDM_RidingRollerExtrusion")]
public class TB_QDM_RidingRollerExtrusion
{
    /// <summary>Wave</summary>
    [SugarColumn(ColumnName = "Wave", Length = 50, ColumnDescription = "Wave")]
    public string Wave { get; set; } = default!;

    /// <summary>ExtrusionFactor</summary>
    [SugarColumn(ColumnName = "ExtrusionFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "ExtrusionFactor")]
    public decimal ExtrusionFactor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}