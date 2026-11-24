using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// TB_QDM_PreheaterSteamSpeed
/// </summary>
[SugarTable("TB_QDM_PreheaterSteamSpeed", TableDescription = "TB_QDM_PreheaterSteamSpeed")]
public class TB_QDM_PreheaterSteamSpeed
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "F_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? F_Speed { get; set; }

    /// <summary>车速系数</summary>
    [SugarColumn(ColumnName = "F_SpeedFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速系数")]
    public decimal? F_SpeedFactor { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? F_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? F_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}