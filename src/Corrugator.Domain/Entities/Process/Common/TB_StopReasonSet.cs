using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 停机原因设置表
/// </summary>
[SugarTable("TB_StopReasonSet", TableDescription = "停机原因设置表")]
public class TB_StopReasonSet
{
    /// <summary>停机类型ID</summary>
    [SugarColumn(ColumnName = "F_StopTypeID", ColumnDescription = "停机类型ID")]
    public int F_StopTypeID { get; set; }

    /// <summary>停机原因</summary>
    [SugarColumn(ColumnName = "F_Reason", Length = 200, ColumnDescription = "停机原因")]
    public string F_Reason { get; set; } = default!;

    /// <summary>位置 SF、DF、HQ</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "位置 SF、DF、HQ")]
    public string F_Position { get; set; } = default!;

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}