using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 班组基础资料设置表
/// </summary>
[SugarTable("S_Classes", TableDescription = "班组基础资料设置表")]
public class S_Classes
{
    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "SC_ShiftNum", Length = 10, IsNullable = true, ColumnDescription = "班次号")]
    public string? SC_ShiftNum { get; set; }

    /// <summary>班组名称</summary>
    [SugarColumn(ColumnName = "SC_Name", Length = 50, ColumnDescription = "班组名称")]
    public string SC_Name { get; set; } = default!;

    /// <summary>班长</summary>
    [SugarColumn(ColumnName = "SC_Monitor", Length = 50, IsNullable = true, ColumnDescription = "班长")]
    public string? SC_Monitor { get; set; }

    /// <summary>抱车工1</summary>
    [SugarColumn(ColumnName = "SC_CarHugger1", Length = 50, IsNullable = true, ColumnDescription = "抱车工1")]
    public string? SC_CarHugger1 { get; set; }

    /// <summary>抱车工2</summary>
    [SugarColumn(ColumnName = "SC_CarHugger2", Length = 50, IsNullable = true, ColumnDescription = "抱车工2")]
    public string? SC_CarHugger2 { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "SC_Creator", Length = 50, ColumnDescription = "创建者")]
    public string SC_Creator { get; set; } = default!;

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "SC_CreateTime", ColumnDescription = "创建日期")]
    public DateTime SC_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "SC_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? SC_Editor { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "SC_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? SC_EditTime { get; set; }

    /// <summary>SC_StartTime</summary>
    [SugarColumn(ColumnName = "SC_StartTime", Length = 50, IsNullable = true, ColumnDescription = "SC_StartTime")]
    public string? SC_StartTime { get; set; }

    /// <summary>SC_EndTime</summary>
    [SugarColumn(ColumnName = "SC_EndTime", Length = 50, IsNullable = true, ColumnDescription = "SC_EndTime")]
    public string? SC_EndTime { get; set; }

    /// <summary>SC_ID</summary>
    [SugarColumn(ColumnName = "SC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SC_ID")]
    public int SC_ID { get; set; }

}