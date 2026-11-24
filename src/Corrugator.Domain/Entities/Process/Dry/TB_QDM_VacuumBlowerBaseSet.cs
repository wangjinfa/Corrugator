using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 真空泵基础设置
/// </summary>
[SugarTable("TB_QDM_VacuumBlowerBaseSet", TableDescription = "真空泵基础设置")]
public class TB_QDM_VacuumBlowerBaseSet
{
    /// <summary>瓦纸代号</summary>
    [SugarColumn(ColumnName = "PaperCode", Length = 50, ColumnDescription = "瓦纸代号")]
    public string PaperCode { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "Wave", Length = 50, ColumnDescription = "楞型")]
    public string Wave { get; set; } = default!;

    /// <summary>速度比例</summary>
    [SugarColumn(ColumnName = "SpeedRatio", Length = 18, DecimalDigits = 4, ColumnDescription = "速度比例")]
    public decimal SpeedRatio { get; set; }

    /// <summary>ID</summary>
    [SugarColumn(ColumnName = "ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "ID")]
    public int ID { get; set; }

}