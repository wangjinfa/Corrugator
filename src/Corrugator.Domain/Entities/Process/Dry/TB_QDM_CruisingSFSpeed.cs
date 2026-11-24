using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 坑机车速巡航
/// </summary>
[SugarTable("TB_QDM_CruisingSFSpeed", TableDescription = "坑机车速巡航")]
public class TB_QDM_CruisingSFSpeed
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小车速</summary>
    [SugarColumn(ColumnName = "F_MinSpeed", ColumnDescription = "最小车速")]
    public int F_MinSpeed { get; set; }

    /// <summary>最大车速</summary>
    [SugarColumn(ColumnName = "F_MaxSpeed", ColumnDescription = "最大车速")]
    public int F_MaxSpeed { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal F_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal F_MaxGram { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}