using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_PreheaterSteamSpeed
/// </summary>
[SugarTable("W_QDM_PreheaterSteamSpeed", TableDescription = "W_QDM_PreheaterSteamSpeed")]
public class W_QDM_PreheaterSteamSpeed
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? WF_Speed { get; set; }

    /// <summary>车速系数</summary>
    [SugarColumn(ColumnName = "WF_SpeedFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速系数")]
    public decimal? WF_SpeedFactor { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? WF_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? WF_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}