using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷嘴设置
/// </summary>
[SugarTable("W_Plc_SprayWidthSet", TableDescription = "PLC喷嘴设置")]
public class W_Plc_SprayWidthSet
{
    /// <summary>喷嘴编号</summary>
    [SugarColumn(ColumnName = "WF_Code", ColumnDescription = "喷嘴编号")]
    public int WF_Code { get; set; }

    /// <summary>门幅临界值(>=该值)</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "门幅临界值(>=该值)")]
    public int WF_Width { get; set; }

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "WF_IsUse", ColumnDescription = "是否启用")]
    public bool WF_IsUse { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}