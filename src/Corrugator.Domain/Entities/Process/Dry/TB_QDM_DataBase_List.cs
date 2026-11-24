using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_DataBase_List
/// </summary>
[SugarTable("TB_QDM_DataBase_List", TableDescription = "TB_QDM_DataBase_List")]
public class TB_QDM_DataBase_List
{
    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "F_MaterialQua", Length = 50, IsNullable = true, ColumnDescription = "材质")]
    public string? F_MaterialQua { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? F_Flute { get; set; }

    /// <summary>DF的QDMID</summary>
    [SugarColumn(ColumnName = "F_DF_Id", IsNullable = true, ColumnDescription = "DF的QDMID")]
    public int? F_DF_Id { get; set; }

    /// <summary>SF1的QDMID</summary>
    [SugarColumn(ColumnName = "F_SF1_Id", IsNullable = true, ColumnDescription = "SF1的QDMID")]
    public int? F_SF1_Id { get; set; }

    /// <summary>SF2的QDMID</summary>
    [SugarColumn(ColumnName = "F_SF2_Id", IsNullable = true, ColumnDescription = "SF2的QDMID")]
    public int? F_SF2_Id { get; set; }

    /// <summary>SF3的QDMID</summary>
    [SugarColumn(ColumnName = "F_SF3_Id", IsNullable = true, ColumnDescription = "SF3的QDMID")]
    public int? F_SF3_Id { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}