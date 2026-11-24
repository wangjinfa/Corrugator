using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// QDM基准值
/// </summary>
[SugarTable("W_QDM_StandardValue", TableDescription = "QDM基准值")]
public class W_QDM_StandardValue
{
    /// <summary>QDM表ID</summary>
    [SugarColumn(ColumnName = "WF_QDMId", IsNullable = true, ColumnDescription = "QDM表ID")]
    public int? WF_QDMId { get; set; }

    /// <summary>部位表</summary>
    [SugarColumn(ColumnName = "WF_PositonTable", Length = 50, IsNullable = true, ColumnDescription = "部位表")]
    public string? WF_PositonTable { get; set; }

    /// <summary>WF_Type</summary>
    [SugarColumn(ColumnName = "WF_Type", Length = 50, IsNullable = true, ColumnDescription = "WF_Type")]
    public string? WF_Type { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WF_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "材质")]
    public string? WF_MaterialQua { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>位置材质</summary>
    [SugarColumn(ColumnName = "WF_Position_Material", Length = 50, IsNullable = true, ColumnDescription = "位置材质")]
    public string? WF_Position_Material { get; set; }

    /// <summary>位置楞型</summary>
    [SugarColumn(ColumnName = "WF_Position_Flute", Length = 50, IsNullable = true, ColumnDescription = "位置楞型")]
    public string? WF_Position_Flute { get; set; }

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? WF_Position { get; set; }

    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "WF_MinWidth", IsNullable = true, ColumnDescription = "最小门幅")]
    public int? WF_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "WF_MaxWidth", IsNullable = true, ColumnDescription = "最大门幅")]
    public int? WF_MaxWidth { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? WF_Speed { get; set; }

    /// <summary>几段</summary>
    [SugarColumn(ColumnName = "WF_Part", IsNullable = true, ColumnDescription = "几段")]
    public int? WF_Part { get; set; }

    /// <summary>基准值</summary>
    [SugarColumn(ColumnName = "WF_StandardValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "基准值")]
    public decimal? WF_StandardValue { get; set; }

    /// <summary>最小取值</summary>
    [SugarColumn(ColumnName = "WF_MinValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最小取值")]
    public decimal? WF_MinValue { get; set; }

    /// <summary>最大取值</summary>
    [SugarColumn(ColumnName = "WF_MaxValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最大取值")]
    public decimal? WF_MaxValue { get; set; }

    /// <summary>点位编码</summary>
    [SugarColumn(ColumnName = "WF_Encoded", Length = 200, IsNullable = true, ColumnDescription = "点位编码")]
    public string? WF_Encoded { get; set; }

    /// <summary>WF_EncodedOther</summary>
    [SugarColumn(ColumnName = "WF_EncodedOther", Length = 200, IsNullable = true, ColumnDescription = "WF_EncodedOther")]
    public string? WF_EncodedOther { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}