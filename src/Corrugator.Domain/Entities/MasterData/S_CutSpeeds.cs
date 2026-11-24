using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 切长限速表
/// </summary>
[SugarTable("W_CutSpeeds", TableDescription = "切长限速表")]
public class W_CutSpeeds
{
    /// <summary>切长mm</summary>
    [SugarColumn(ColumnName = "WSCS_CutLength", ColumnDescription = "切长mm")]
    public int WSCS_CutLength { get; set; }

    /// <summary>限速</summary>
    [SugarColumn(ColumnName = "WSCS_Speed", ColumnDescription = "限速")]
    public int WSCS_Speed { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WSCS_CreateTime", IsNullable = true, ColumnDescription = "创建日期")]
    public DateTime? WSCS_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "WSCS_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建用户")]
    public string? WSCS_Creator { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "WSCS_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? WSCS_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "WSCS_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? WSCS_Editor { get; set; }

    /// <summary>WSCS_ID</summary>
    [SugarColumn(ColumnName = "WSCS_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSCS_ID")]
    public int WSCS_ID { get; set; }

}