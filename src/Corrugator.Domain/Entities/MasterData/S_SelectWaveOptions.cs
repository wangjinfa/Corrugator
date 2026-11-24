using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 楞型配置选项
/// </summary>
[SugarTable("S_SelectWaveOptions", TableDescription = "楞型配置选项")]
public class S_SelectWaveOptions
{
    /// <summary>配置名称</summary>
    [SugarColumn(ColumnName = "SSO_Name", Length = 50, ColumnDescription = "配置名称")]
    public string SSO_Name { get; set; } = default!;

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "SSO_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? SSO_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "SSO_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? SSO_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "SSO_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? SSO_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "SSO_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? SSO_EditTime { get; set; }

    /// <summary>SSO_ID</summary>
    [SugarColumn(ColumnName = "SSO_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SSO_ID")]
    public int SSO_ID { get; set; }

}