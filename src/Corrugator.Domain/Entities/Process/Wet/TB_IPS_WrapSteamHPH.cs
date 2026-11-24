using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊机烘缸蒸汽设置表
/// </summary>
[SugarTable("TB_IPS_WrapSteamHPH", TableDescription = "糊机烘缸蒸汽设置表")]
public class TB_IPS_WrapSteamHPH
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 100, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "F_MinWeight", ColumnDescription = "最小克重")]
    public int F_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "F_MaxWeight", ColumnDescription = "最大克重")]
    public int F_MaxWeight { get; set; }

    /// <summary>面纸烘缸值</summary>
    [SugarColumn(ColumnName = "F_GU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "面纸烘缸值")]
    public decimal? F_GU0 { get; set; }

    /// <summary>一层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "一层烘缸值")]
    public decimal? F_GU1 { get; set; }

    /// <summary>二层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "二层烘缸值")]
    public decimal? F_GU2 { get; set; }

    /// <summary>三层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GU3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层烘缸值")]
    public decimal? F_GU3 { get; set; }

    /// <summary>附加一层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GUAdd1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加一层烘缸值")]
    public decimal? F_GUAdd1 { get; set; }

    /// <summary>附加二层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GUAdd2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加二层烘缸值")]
    public decimal? F_GUAdd2 { get; set; }

    /// <summary>附加三层烘缸值</summary>
    [SugarColumn(ColumnName = "F_GUAdd3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加三层烘缸值")]
    public decimal? F_GUAdd3 { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}