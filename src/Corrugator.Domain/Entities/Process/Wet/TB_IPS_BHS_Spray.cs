using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// BHS喷淋基础设置表
/// </summary>
[SugarTable("TB_IPS_BHS_Spray", TableDescription = "BHS喷淋基础设置表")]
public class TB_IPS_BHS_Spray
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? F_Position { get; set; }

    /// <summary>是否使用</summary>
    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "是否使用")]
    public bool? F_IsUse { get; set; }

    /// <summary>功率</summary>
    [SugarColumn(ColumnName = "F_Power", IsNullable = true, ColumnDescription = "功率")]
    public int? F_Power { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}