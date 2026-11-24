using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 楞型配置关系
/// </summary>
[SugarTable("S_SelectWaveRelation", TableDescription = "楞型配置关系")]
public class S_SelectWaveRelation
{
    /// <summary>选项ID</summary>
    [SugarColumn(ColumnName = "SSO_ID", ColumnDescription = "选项ID")]
    public int SSO_ID { get; set; }

    /// <summary>楞型组合ID</summary>
    [SugarColumn(ColumnName = "SBG_ID", ColumnDescription = "楞型组合ID")]
    public int SBG_ID { get; set; }

    /// <summary>SSR_ID</summary>
    [SugarColumn(ColumnName = "SSR_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SSR_ID")]
    public int SSR_ID { get; set; }

}