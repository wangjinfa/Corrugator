using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 报警读写偏差值设置表
/// </summary>
[SugarTable("TB_IPS_AlarmRWSet", TableDescription = "报警读写偏差值设置表")]
public class TB_IPS_AlarmRWSet
{
    /// <summary>F_Code</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 50, ColumnDescription = "F_Code")]
    public string F_Code { get; set; } = default!;

    /// <summary>F_Name</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 50, ColumnDescription = "F_Name")]
    public string F_Name { get; set; } = default!;

    /// <summary>F_OffSet</summary>
    [SugarColumn(ColumnName = "F_OffSet", Length = 18, DecimalDigits = 2, ColumnDescription = "F_OffSet")]
    public decimal F_OffSet { get; set; }

    /// <summary>F_Interval</summary>
    [SugarColumn(ColumnName = "F_Interval", ColumnDescription = "F_Interval")]
    public int F_Interval { get; set; }

    /// <summary>F_IsUse</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "F_IsUse")]
    public bool F_IsUse { get; set; }

    /// <summary>F_IsSend</summary>
    [SugarColumn(ColumnName = "F_IsSend", ColumnDescription = "F_IsSend")]
    public bool F_IsSend { get; set; }

    /// <summary>F_IsSave</summary>
    [SugarColumn(ColumnName = "F_IsSave", ColumnDescription = "F_IsSave")]
    public bool F_IsSave { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}