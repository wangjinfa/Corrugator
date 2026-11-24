using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_DataBase_List
/// </summary>
[SugarTable("W_QDM_DataBase_List", TableDescription = "W_QDM_DataBase_List")]
public class W_QDM_DataBase_List
{
    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WF_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "材质")]
    public string? WF_MaterialQua { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? WF_Flute { get; set; }

    /// <summary>DF的QDMID</summary>
    [SugarColumn(ColumnName = "WF_DF_Id", IsNullable = true, ColumnDescription = "DF的QDMID")]
    public int? WF_DF_Id { get; set; }

    /// <summary>SF1的QDMID</summary>
    [SugarColumn(ColumnName = "WF_SF1_Id", IsNullable = true, ColumnDescription = "SF1的QDMID")]
    public int? WF_SF1_Id { get; set; }

    /// <summary>SF2的QDMID</summary>
    [SugarColumn(ColumnName = "WF_SF2_Id", IsNullable = true, ColumnDescription = "SF2的QDMID")]
    public int? WF_SF2_Id { get; set; }

    /// <summary>SF3的QDMID</summary>
    [SugarColumn(ColumnName = "WF_SF3_Id", IsNullable = true, ColumnDescription = "SF3的QDMID")]
    public int? WF_SF3_Id { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}