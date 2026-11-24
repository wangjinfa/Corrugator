using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 坑机车速巡航
/// </summary>
[SugarTable("W_QDM_CruisingSFSpeed", TableDescription = "坑机车速巡航")]
public class W_QDM_CruisingSFSpeed
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小车速</summary>
    [SugarColumn(ColumnName = "WF_MinSpeed", ColumnDescription = "最小车速")]
    public int WF_MinSpeed { get; set; }

    /// <summary>最大车速</summary>
    [SugarColumn(ColumnName = "WF_MaxSpeed", ColumnDescription = "最大车速")]
    public int WF_MaxSpeed { get; set; }

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最小克重")]
    public decimal WF_MinGram { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxGram", Length = 18, DecimalDigits = 2, ColumnDescription = "最大克重")]
    public decimal WF_MaxGram { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}