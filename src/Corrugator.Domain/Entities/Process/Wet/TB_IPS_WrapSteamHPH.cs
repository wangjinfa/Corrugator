using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 糊机烘缸蒸汽设置表
/// </summary>
[SugarTable("W_IPS_WrapSteamHPH", TableDescription = "糊机烘缸蒸汽设置表")]
public class W_IPS_WrapSteamHPH
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 100, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>最小克重</summary>
    [SugarColumn(ColumnName = "WF_MinWeight", ColumnDescription = "最小克重")]
    public int WF_MinWeight { get; set; }

    /// <summary>最大克重</summary>
    [SugarColumn(ColumnName = "WF_MaxWeight", ColumnDescription = "最大克重")]
    public int WF_MaxWeight { get; set; }

    /// <summary>面纸烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GU0", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "面纸烘缸值")]
    public decimal? WF_GU0 { get; set; }

    /// <summary>一层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GU1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "一层烘缸值")]
    public decimal? WF_GU1 { get; set; }

    /// <summary>二层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GU2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "二层烘缸值")]
    public decimal? WF_GU2 { get; set; }

    /// <summary>三层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GU3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层烘缸值")]
    public decimal? WF_GU3 { get; set; }

    /// <summary>附加一层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GUAdd1", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加一层烘缸值")]
    public decimal? WF_GUAdd1 { get; set; }

    /// <summary>附加二层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GUAdd2", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加二层烘缸值")]
    public decimal? WF_GUAdd2 { get; set; }

    /// <summary>附加三层烘缸值</summary>
    [SugarColumn(ColumnName = "WF_GUAdd3", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "附加三层烘缸值")]
    public decimal? WF_GUAdd3 { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}