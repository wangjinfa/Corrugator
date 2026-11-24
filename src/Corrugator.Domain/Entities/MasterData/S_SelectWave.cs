using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 选择楞型
/// </summary>
[SugarTable("S_SelectWave", TableDescription = "选择楞型")]
public class S_SelectWave
{
    /// <summary>选项ID</summary>
    [SugarColumn(ColumnName = "SSO_ID", ColumnDescription = "选项ID")]
    public int SSO_ID { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "SSO_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? SSO_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "SSO_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? SSO_EditTime { get; set; }

    /// <summary>SSW_ID</summary>
    [SugarColumn(ColumnName = "SSW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SSW_ID")]
    public int SSW_ID { get; set; }

}