using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 班组基础资料设置表
/// </summary>
[SugarTable("W_Classes", TableDescription = "班组基础资料设置表")]
public class W_Classes
{
    /// <summary>班次号</summary>
    [SugarColumn(ColumnName = "WSC_ShiftNum", Length = 10, IsNullable = true, ColumnDescription = "班次号")]
    public string? WSC_ShiftNum { get; set; }

    /// <summary>班组名称</summary>
    [SugarColumn(ColumnName = "WSC_Name", Length = 50, ColumnDescription = "班组名称")]
    public string WSC_Name { get; set; } = default!;

    /// <summary>班长</summary>
    [SugarColumn(ColumnName = "WSC_Monitor", Length = 50, IsNullable = true, ColumnDescription = "班长")]
    public string? WSC_Monitor { get; set; }

    /// <summary>抱车工1</summary>
    [SugarColumn(ColumnName = "WSC_CarHugger1", Length = 50, IsNullable = true, ColumnDescription = "抱车工1")]
    public string? WSC_CarHugger1 { get; set; }

    /// <summary>抱车工2</summary>
    [SugarColumn(ColumnName = "WSC_CarHugger2", Length = 50, IsNullable = true, ColumnDescription = "抱车工2")]
    public string? WSC_CarHugger2 { get; set; }

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "WSC_Creator", Length = 50, ColumnDescription = "创建者")]
    public string WSC_Creator { get; set; } = default!;

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WSC_CreateTime", ColumnDescription = "创建日期")]
    public DateTime WSC_CreateTime { get; set; }

    /// <summary>修改人</summary>
    [SugarColumn(ColumnName = "WSC_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改人")]
    public string? WSC_Editor { get; set; }

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "WSC_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? WSC_EditTime { get; set; }

    /// <summary>WSC_StartTime</summary>
    [SugarColumn(ColumnName = "WSC_StartTime", Length = 50, IsNullable = true, ColumnDescription = "WSC_StartTime")]
    public string? WSC_StartTime { get; set; }

    /// <summary>WSC_EndTime</summary>
    [SugarColumn(ColumnName = "WSC_EndTime", Length = 50, IsNullable = true, ColumnDescription = "WSC_EndTime")]
    public string? WSC_EndTime { get; set; }

    /// <summary>WSC_ID</summary>
    [SugarColumn(ColumnName = "WSC_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSC_ID")]
    public int WSC_ID { get; set; }

}