using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 真空泵基础设置
/// </summary>
[SugarTable("W_QDM_VacuumBlowerBaseSet", TableDescription = "真空泵基础设置")]
public class W_QDM_VacuumBlowerBaseSet
{
    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "WPaperCode", Length = 50, ColumnDescription = "瓦纸代号")]
    public string WPaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WWave", Length = 50, ColumnDescription = "楞型")]
    public string WWave { get; set; } = default!;

    /// <summary>速度比例</summary>
    [SugarColumn(ColumnName = "WSpeedRatio", Length = 18, DecimalDigits = 4, ColumnDescription = "速度比例")]
    public decimal WSpeedRatio { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "WID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int WID { get; set; }

}