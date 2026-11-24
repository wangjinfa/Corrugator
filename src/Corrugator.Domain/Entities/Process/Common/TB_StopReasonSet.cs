using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Common;

/// <summary>
/// 停机原因设置表
/// </summary>
[SugarTable("W_StopReasonSet", TableDescription = "停机原因设置表")]
public class W_StopReasonSet
{
    /// <summary>停机类型ID</summary>
    [SugarColumn(ColumnName = "WF_StopTypeID", ColumnDescription = "停机类型ID")]
    public int WF_StopTypeID { get; set; }

    /// <summary>停机原因</summary>
    [SugarColumn(ColumnName = "WF_Reason", Length = 200, ColumnDescription = "停机原因")]
    public string WF_Reason { get; set; } = default!;

    /// <summary>位置 SF、DF、HQ</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "位置 SF、DF、HQ")]
    public string WF_Position { get; set; } = default!;

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}