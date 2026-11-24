using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// W_QDM_HotPlateSteamSpeed
/// </summary>
[SugarTable("W_QDM_HotPlateSteamSpeed", TableDescription = "W_QDM_HotPlateSteamSpeed")]
public class W_QDM_HotPlateSteamSpeed
{
    /// <summary>车速</summary>
    [SugarColumn(ColumnName = "WF_Speed", IsNullable = true, ColumnDescription = "车速")]
    public int? WF_Speed { get; set; }

    /// <summary>车速系数</summary>
    [SugarColumn(ColumnName = "WF_SpeedFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "车速系数")]
    public decimal? WF_SpeedFactor { get; set; }

    /// <summary>几层</summary>
    [SugarColumn(ColumnName = "WF_Layer", IsNullable = true, ColumnDescription = "几层")]
    public int? WF_Layer { get; set; }

    /// <summary>范围ID</summary>
    [SugarColumn(ColumnName = "WF_Range_Id", IsNullable = true, ColumnDescription = "范围ID")]
    public int? WF_Range_Id { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? WF_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? WF_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>WF_SortNo</summary>
    [SugarColumn(ColumnName = "WF_SortNo", ColumnDescription = "WF_SortNo")]
    public int WF_SortNo { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}