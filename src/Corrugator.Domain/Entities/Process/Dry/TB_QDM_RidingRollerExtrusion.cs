using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_RidingRollerExtrusion
/// </summary>
[SugarTable("W_QDM_RidingRollerExtrusion", TableDescription = "W_QDM_RidingRollerExtrusion")]
public class W_QDM_RidingRollerExtrusion
{
    /// <summary>Wave</summary>
    [SugarColumn(ColumnName = "WWave", Length = 50, ColumnDescription = "Wave")]
    public string WWave { get; set; } = default!;

    /// <summary>ExtrusionFactor</summary>
    [SugarColumn(ColumnName = "WExtrusionFactor", Length = 18, DecimalDigits = 2, ColumnDescription = "ExtrusionFactor")]
    public decimal WExtrusionFactor { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}