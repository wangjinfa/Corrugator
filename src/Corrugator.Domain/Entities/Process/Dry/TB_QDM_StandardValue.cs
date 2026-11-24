using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// QDM基准值
/// </summary>
[SugarTable("TB_QDM_StandardValue", TableDescription = "QDM基准值")]
public class TB_QDM_StandardValue
{
    /// <summary>QDM表ID</summary>
    [SugarColumn(ColumnName = "F_QDMId", IsNullable = true, ColumnDescription = "QDM表ID")]
    public int? F_QDMId { get; set; }

    /// <summary>部位表</summary>
    [SugarColumn(ColumnName = "F_PositonTable", Length = 50, IsNullable = true, ColumnDescription = "部位表")]
    public string? F_PositonTable { get; set; }

    /// <summary>F_Type</summary>
    [SugarColumn(ColumnName = "F_Type", Length = 50, IsNullable = true, ColumnDescription = "F_Type")]
    public string? F_Type { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "F_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "材质")]
    public string? F_MaterialQua { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? F_Flute { get; set; }

    /// <summary>位置材质</summary>
    [SugarColumn(ColumnName = "F_Position_Material", Length = 50, IsNullable = true, ColumnDescription = "位置材质")]
    public string? F_Position_Material { get; set; }

    /// <summary>位置楞型</summary>
    [SugarColumn(ColumnName = "F_Position_Flute", Length = 50, IsNullable = true, ColumnDescription = "位置楞型")]
    public string? F_Position_Flute { get; set; }

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? F_Position { get; set; }

    /// <summary>最小门幅</summary>
    [SugarColumn(ColumnName = "F_MinWidth", IsNullable = true, ColumnDescription = "最小门幅")]
    public int? F_MinWidth { get; set; }

    /// <summary>最大门幅</summary>
    [SugarColumn(ColumnName = "F_MaxWidth", IsNullable = true, ColumnDescription = "最大门幅")]
    public int? F_MaxWidth { get; set; }

    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? F_Speed { get; set; }

    /// <summary>几段</summary>
    [SugarColumn(ColumnName = "F_Part", IsNullable = true, ColumnDescription = "几段")]
    public int? F_Part { get; set; }

    /// <summary>基准值</summary>
    [SugarColumn(ColumnName = "F_StandardValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "基准值")]
    public decimal? F_StandardValue { get; set; }

    /// <summary>最小取值</summary>
    [SugarColumn(ColumnName = "F_MinValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最小取值")]
    public decimal? F_MinValue { get; set; }

    /// <summary>最大取值</summary>
    [SugarColumn(ColumnName = "F_MaxValue", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "最大取值")]
    public decimal? F_MaxValue { get; set; }

    /// <summary>点位编码</summary>
    [SugarColumn(ColumnName = "F_Encoded", Length = 200, IsNullable = true, ColumnDescription = "点位编码")]
    public string? F_Encoded { get; set; }

    /// <summary>F_EncodedOther</summary>
    [SugarColumn(ColumnName = "F_EncodedOther", Length = 200, IsNullable = true, ColumnDescription = "F_EncodedOther")]
    public string? F_EncodedOther { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}