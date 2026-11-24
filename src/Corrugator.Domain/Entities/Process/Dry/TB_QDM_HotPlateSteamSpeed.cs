using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_HotPlateSteamSpeed
/// </summary>
[SugarTable("TB_QDM_HotPlateSteamSpeed", TableDescription = "TB_QDM_HotPlateSteamSpeed")]
public class TB_QDM_HotPlateSteamSpeed
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? F_Speed { get; set; }

    /// <summary>车速系数</summary>
    [SugarColumn(ColumnName = "F_SpeedFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速系数")]
    public decimal? F_SpeedFactor { get; set; }

    /// <summary>几层</summary>
    [SugarColumn(ColumnName = "F_Layer", IsNullable = true, ColumnDescription = "几层")]
    public int? F_Layer { get; set; }

    /// <summary>范围ID</summary>
    [SugarColumn(ColumnName = "F_Range_Id", IsNullable = true, ColumnDescription = "范围ID")]
    public int? F_Range_Id { get; set; }

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

    /// <summary>F_SortNo</summary>
    [SugarColumn(ColumnName = "F_SortNo", ColumnDescription = "F_SortNo")]
    public int F_SortNo { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}