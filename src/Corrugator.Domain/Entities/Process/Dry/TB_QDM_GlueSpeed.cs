using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 糊间隙车速
/// </summary>
[SugarTable("TB_QDM_GlueSpeed", TableDescription = "糊间隙车速")]
public class TB_QDM_GlueSpeed
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? F_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_SpeedFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "系数")]
    public decimal? F_SpeedFactor { get; set; }

    /// <summary>F_Positon</summary>
    [SugarColumn(ColumnName = "F_Positon", Length = 50, IsNullable = true, ColumnDescription = "F_Positon")]
    public string? F_Positon { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? F_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? F_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}