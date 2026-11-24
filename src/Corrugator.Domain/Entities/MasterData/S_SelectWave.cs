using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 选择楞型
/// </summary>
[SugarTable("W_SelectWave", TableDescription = "选择楞型")]
public class W_SelectWave
{
    /// <summary>选项ID</summary>
    [SugarColumn(ColumnName = "WSSO_ID", ColumnDescription = "选项ID")]
    public int WSSO_ID { get; set; }

    /// <summary>修改者</summary>
    [SugarColumn(ColumnName = "WSSO_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改者")]
    public string? WSSO_Editor { get; set; }

    /// <summary>修改时间</summary>
    [SugarColumn(ColumnName = "WSSO_EditTime", IsNullable = true, ColumnDescription = "修改时间")]
    public DateTime? WSSO_EditTime { get; set; }

    /// <summary>WSSW_ID</summary>
    [SugarColumn(ColumnName = "WSSW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSSW_ID")]
    public int WSSW_ID { get; set; }

}