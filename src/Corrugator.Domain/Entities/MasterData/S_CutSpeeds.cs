using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 切长限速表
/// </summary>
[SugarTable("S_CutSpeeds", TableDescription = "切长限速表")]
public class S_CutSpeeds
{
    /// <summary>切长mm</summary>
    [SugarColumn(ColumnName = "SCS_CutLength", ColumnDescription = "切长mm")]
    public int SCS_CutLength { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "SCS_Speed", ColumnDescription = "限速")]
    public int SCS_Speed { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "SCS_CreateTime", IsNullable = true, ColumnDescription = "创建日期")]
    public DateTime? SCS_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "SCS_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建用户")]
    public string? SCS_Creator { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "SCS_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? SCS_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "SCS_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? SCS_Editor { get; set; }

    /// <summary>SCS_ID</summary>
    [SugarColumn(ColumnName = "SCS_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SCS_ID")]
    public int SCS_ID { get; set; }

}