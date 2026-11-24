using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// BHS喷淋基础设置表
/// </summary>
[SugarTable("W_IPS_BHS_Spray", TableDescription = "BHS喷淋基础设置表")]
public class W_IPS_BHS_Spray
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, IsNullable = true, ColumnDescription = "部位")]
    public string? WF_Position { get; set; }

    /// <summary>是否使用</summary>
    [SugarColumn(ColumnName = "WF_IsUse", IsNullable = true, ColumnDescription = "是否使用")]
    public bool? WF_IsUse { get; set; }

    /// <summary>功率</summary>
    [SugarColumn(ColumnName = "WF_Power", IsNullable = true, ColumnDescription = "功率")]
    public int? WF_Power { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}