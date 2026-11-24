using SqlSugar;

namespace Corrugator.Domain.Entities.BaseLine;

/// <summary>班组资料（基础信息 → 班组资料）：班次号、班组名称、班次时间段、班长与抱车工。</summary>
[SugarTable("TB_Team_Info", TableDescription = "班组资料")]
public class TB_Team_Info
{
    /// <summary>班次号（01/02/03…，唯一）</summary>
    [SugarColumn(ColumnName = "F_ShiftNo", Length = 10, ColumnDescription = "班次号")]
    public string F_ShiftNo { get; set; } = default!;

    /// <summary>班组名称（A/B/C/STOP…）</summary>
    [SugarColumn(ColumnName = "F_TeamName", Length = 60, ColumnDescription = "班组名称")]
    public string F_TeamName { get; set; } = default!;

    /// <summary>开始时间（HH:mm:ss）</summary>
    [SugarColumn(ColumnName = "F_StartTime", Length = 10, IsNullable = true, ColumnDescription = "开始时间")]
    public string? F_StartTime { get; set; }

    /// <summary>结束时间（HH:mm:ss）</summary>
    [SugarColumn(ColumnName = "F_EndTime", Length = 10, IsNullable = true, ColumnDescription = "结束时间")]
    public string? F_EndTime { get; set; }

    /// <summary>班长</summary>
    [SugarColumn(ColumnName = "F_Leader", Length = 50, IsNullable = true, ColumnDescription = "班长")]
    public string? F_Leader { get; set; }

    /// <summary>抱车工1</summary>
    [SugarColumn(ColumnName = "F_Forklift1", Length = 50, IsNullable = true, ColumnDescription = "抱车工1")]
    public string? F_Forklift1 { get; set; }

    /// <summary>抱车工2</summary>
    [SugarColumn(ColumnName = "F_Forklift2", Length = 50, IsNullable = true, ColumnDescription = "抱车工2")]
    public string? F_Forklift2 { get; set; }

    [SugarColumn(ColumnName = "F_IsDelete", IsNullable = true)]
    public bool? F_IsDelete { get; set; }

    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true)]
    public string? F_Creator { get; set; }

    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true)]
    public DateTime? F_CreateTime { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
