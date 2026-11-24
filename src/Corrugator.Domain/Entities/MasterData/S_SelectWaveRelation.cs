using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 楞型配置关系
/// </summary>
[SugarTable("W_SelectWaveRelation", TableDescription = "楞型配置关系")]
public class W_SelectWaveRelation
{
    /// <summary>选项ID</summary>
    [SugarColumn(ColumnName = "WSSO_ID", ColumnDescription = "选项ID")]
    public int WSSO_ID { get; set; }

    /// <summary>楞型组合ID</summary>
    [SugarColumn(ColumnName = "WSBG_ID", ColumnDescription = "楞型组合ID")]
    public int WSBG_ID { get; set; }

    /// <summary>WSSR_ID</summary>
    [SugarColumn(ColumnName = "WSSR_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSSR_ID")]
    public int WSSR_ID { get; set; }

}