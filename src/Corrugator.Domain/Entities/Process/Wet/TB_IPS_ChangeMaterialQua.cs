using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_ChangeMaterialQua
/// </summary>
[SugarTable("TB_IPS_ChangeMaterialQua", TableDescription = "TB_IPS_ChangeMaterialQua")]
public class TB_IPS_ChangeMaterialQua
{
    /// <summary>F_MachinePosition</summary>
    [SugarColumn(ColumnName = "F_MachinePosition", Length = 50, IsNullable = true, ColumnDescription = "F_MachinePosition")]
    public string? F_MachinePosition { get; set; }

    /// <summary>真实材质</summary>
    [SugarColumn(ColumnName = "F_RealMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "真实材质")]
    public string? F_RealMaterialQua { get; set; }

    /// <summary>真实门幅</summary>
    [SugarColumn(ColumnName = "F_RealWidth", IsNullable = true, ColumnDescription = "真实门幅")]
    public int? F_RealWidth { get; set; }

    /// <summary>理论材质</summary>
    [SugarColumn(ColumnName = "F_TheoryMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "理论材质")]
    public string? F_TheoryMaterialQua { get; set; }

    /// <summary>理论门幅</summary>
    [SugarColumn(ColumnName = "F_TheoryWidth", IsNullable = true, ColumnDescription = "理论门幅")]
    public int? F_TheoryWidth { get; set; }

    /// <summary>F_TheoryNextMaterialQua</summary>
    [SugarColumn(ColumnName = "F_TheoryNextMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "F_TheoryNextMaterialQua")]
    public string? F_TheoryNextMaterialQua { get; set; }

    /// <summary>F_TheoryNextWidth</summary>
    [SugarColumn(ColumnName = "F_TheoryNextWidth", IsNullable = true, ColumnDescription = "F_TheoryNextWidth")]
    public int? F_TheoryNextWidth { get; set; }

    /// <summary>坑机同材剩余米数</summary>
    [SugarColumn(ColumnName = "F_SF_SameRemainMeter", IsNullable = true, ColumnDescription = "坑机同材剩余米数")]
    public int? F_SF_SameRemainMeter { get; set; }

    /// <summary>糊机同材剩余米数</summary>
    [SugarColumn(ColumnName = "F_DF_SameRemainMeter", IsNullable = true, ColumnDescription = "糊机同材剩余米数")]
    public int? F_DF_SameRemainMeter { get; set; }

    /// <summary>是否同材换材</summary>
    [SugarColumn(ColumnName = "F_IsSameReplaceMaterialQua", IsNullable = true, ColumnDescription = "是否同材换材")]
    public bool? F_IsSameReplaceMaterialQua { get; set; }

    /// <summary>是否换材</summary>
    [SugarColumn(ColumnName = "F_IsRelaceMaterialQua", IsNullable = true, ColumnDescription = "是否换材")]
    public bool? F_IsRelaceMaterialQua { get; set; }

    /// <summary>F_DateTime</summary>
    [SugarColumn(ColumnName = "F_DateTime", IsNullable = true, ColumnDescription = "F_DateTime")]
    public DateTime? F_DateTime { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}