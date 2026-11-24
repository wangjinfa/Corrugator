using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 停机类型设置表
/// </summary>
[SugarTable("W_StopTypeSet", TableDescription = "停机类型设置表")]
public class W_StopTypeSet
{
    /// <summary>停机类型编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 100, ColumnDescription = "停机类型编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>停机类型名称</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 200, ColumnDescription = "停机类型名称")]
    public string WF_Name { get; set; } = default!;

    /// <summary>是否统计停机</summary>
    [SugarColumn(ColumnName = "WF_StatisticsStop", ColumnDescription = "是否统计停机")]
    public bool WF_StatisticsStop { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

    /// <summary>所属部位 SF、DF、HQ</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 100, IsNullable = true, ColumnDescription = "所属部位 SF、DF、HQ")]
    public string? WF_Position { get; set; }

}