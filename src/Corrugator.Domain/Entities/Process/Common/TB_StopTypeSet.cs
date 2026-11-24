using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 停机类型设置表
/// </summary>
[SugarTable("TB_StopTypeSet", TableDescription = "停机类型设置表")]
public class TB_StopTypeSet
{
    /// <summary>停机类型编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 100, ColumnDescription = "停机类型编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>停机类型名称</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 200, ColumnDescription = "停机类型名称")]
    public string F_Name { get; set; } = default!;

    /// <summary>是否统计停机</summary>
    [SugarColumn(ColumnName = "F_StatisticsStop", ColumnDescription = "是否统计停机")]
    public bool F_StatisticsStop { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

    /// <summary>所属部位 SF、DF、HQ</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 100, IsNullable = true, ColumnDescription = "所属部位 SF、DF、HQ")]
    public string? F_Position { get; set; }

}