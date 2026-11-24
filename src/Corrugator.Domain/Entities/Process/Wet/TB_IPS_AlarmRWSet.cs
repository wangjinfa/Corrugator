using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 报警读写偏差值设置表
/// </summary>
[SugarTable("W_IPS_AlarmRWSet", TableDescription = "报警读写偏差值设置表")]
public class W_IPS_AlarmRWSet
{
    /// <summary>WF_Code</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 50, ColumnDescription = "WF_Code")]
    public string WF_Code { get; set; } = default!;

    /// <summary>WF_Name</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 50, ColumnDescription = "WF_Name")]
    public string WF_Name { get; set; } = default!;

    /// <summary>WF_OffSet</summary>
    [SugarColumn(ColumnName = "WF_OffSet", Length = 18, DecimalDigits = 2, ColumnDescription = "WF_OffSet")]
    public decimal WF_OffSet { get; set; }

    /// <summary>WF_Interval</summary>
    [SugarColumn(ColumnName = "WF_Interval", ColumnDescription = "WF_Interval")]
    public int WF_Interval { get; set; }

    /// <summary>WF_IsUse</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "WF_IsUse")]
    public bool WF_IsUse { get; set; }

    /// <summary>WF_IsSend</summary>
    [SugarColumn(ColumnName = "WF_IsSend", ColumnDescription = "WF_IsSend")]
    public bool WF_IsSend { get; set; }

    /// <summary>WF_IsSave</summary>
    [SugarColumn(ColumnName = "WF_IsSave", ColumnDescription = "WF_IsSave")]
    public bool WF_IsSave { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}