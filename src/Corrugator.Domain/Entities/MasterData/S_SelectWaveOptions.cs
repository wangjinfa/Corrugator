using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 楞型配置选项
/// </summary>
[SugarTable("W_SelectWaveOptions", TableDescription = "楞型配置选项")]
public class W_SelectWaveOptions
{
    /// <summary>配置名称</summary>
    [SugarColumn(ColumnName = "WSSO_Name", Length = 50, ColumnDescription = "配置名称")]
    public string WSSO_Name { get; set; } = default!;

    /// <summary>创建者</summary>
    [SugarColumn(ColumnName = "WSSO_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建者")]
    public string? WSSO_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WSSO_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WSSO_CreateTime { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "WSSO_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? WSSO_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WSSO_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WSSO_EditTime { get; set; }

    /// <summary>WSSO_ID</summary>
    [SugarColumn(ColumnName = "WSSO_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSSO_ID")]
    public int WSSO_ID { get; set; }

}