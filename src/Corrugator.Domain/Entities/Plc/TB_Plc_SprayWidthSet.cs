using SqlSugar;

namespace Corrugator.Domain.Entities.Plc;

/// <summary>
/// PLC喷嘴设置
/// </summary>
[SugarTable("TB_Plc_SprayWidthSet", TableDescription = "PLC喷嘴设置")]
public class TB_Plc_SprayWidthSet
{
    /// <summary>喷嘴编号</summary>
    [SugarColumn(ColumnName = "F_Code", ColumnDescription = "喷嘴编号")]
    public int F_Code { get; set; }

    /// <summary>门幅临界值(>=该值)</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "门幅临界值(>=该值)")]
    public int F_Width { get; set; }

    /// <summary>是否启用</summary>
    [SugarColumn(ColumnName = "F_IsUse", ColumnDescription = "是否启用")]
    public bool F_IsUse { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}