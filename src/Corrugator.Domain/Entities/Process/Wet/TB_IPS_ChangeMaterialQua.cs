using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_ChangeMaterialQua
/// </summary>
[SugarTable("W_IPS_ChangeMaterialQua", TableDescription = "W_IPS_ChangeMaterialQua")]
public class W_IPS_ChangeMaterialQua
{
    /// <summary>WF_MachinePosition</summary>
    [SugarColumn(ColumnName = "WF_MachinePosition", Length = 50, IsNullable = true, ColumnDescription = "WF_MachinePosition")]
    public string? WF_MachinePosition { get; set; }

    /// <summary>真实材质</summary>
    [SugarColumn(ColumnName = "WF_RealMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "真实材质")]
    public string? WF_RealMaterialQua { get; set; }

    /// <summary>真实门幅</summary>
    [SugarColumn(ColumnName = "WF_RealWidth", IsNullable = true, ColumnDescription = "真实门幅")]
    public int? WF_RealWidth { get; set; }

    /// <summary>理论材质</summary>
    [SugarColumn(ColumnName = "WF_TheoryMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "理论材质")]
    public string? WF_TheoryMaterialQua { get; set; }

    /// <summary>理论门幅</summary>
    [SugarColumn(ColumnName = "WF_TheoryWidth", IsNullable = true, ColumnDescription = "理论门幅")]
    public int? WF_TheoryWidth { get; set; }

    /// <summary>WF_TheoryNextMaterialQua</summary>
    [SugarColumn(ColumnName = "WF_TheoryNextMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "WF_TheoryNextMaterialQua")]
    public string? WF_TheoryNextMaterialQua { get; set; }

    /// <summary>WF_TheoryNextWidth</summary>
    [SugarColumn(ColumnName = "WF_TheoryNextWidth", IsNullable = true, ColumnDescription = "WF_TheoryNextWidth")]
    public int? WF_TheoryNextWidth { get; set; }

    /// <summary>坑机同材剩余米数</summary>
    [SugarColumn(ColumnName = "WF_SF_SameRemainMeter", IsNullable = true, ColumnDescription = "坑机同材剩余米数")]
    public int? WF_SF_SameRemainMeter { get; set; }

    /// <summary>糊机同材剩余米数</summary>
    [SugarColumn(ColumnName = "WF_DF_SameRemainMeter", IsNullable = true, ColumnDescription = "糊机同材剩余米数")]
    public int? WF_DF_SameRemainMeter { get; set; }

    /// <summary>是否同材换材</summary>
    [SugarColumn(ColumnName = "WF_IsSameReplaceMaterialQua", IsNullable = true, ColumnDescription = "是否同材换材")]
    public bool? WF_IsSameReplaceMaterialQua { get; set; }

    /// <summary>是否换材</summary>
    [SugarColumn(ColumnName = "WF_IsRelaceMaterialQua", IsNullable = true, ColumnDescription = "是否换材")]
    public bool? WF_IsRelaceMaterialQua { get; set; }

    /// <summary>WF_DateTime</summary>
    [SugarColumn(ColumnName = "WF_DateTime", IsNullable = true, ColumnDescription = "WF_DateTime")]
    public DateTime? WF_DateTime { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}