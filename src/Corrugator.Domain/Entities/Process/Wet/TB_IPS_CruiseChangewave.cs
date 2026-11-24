using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 换愣降速设置
/// </summary>
[SugarTable("TB_IPS_CruiseChangewave", TableDescription = "换愣降速设置")]
public class TB_IPS_CruiseChangewave
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>换愣前愣型</summary>
    [SugarColumn(ColumnName = "F_Flute1", Length = 255, ColumnDescription = "换愣前愣型")]
    public string F_Flute1 { get; set; } = default!;

    /// <summary>换愣后愣型</summary>
    [SugarColumn(ColumnName = "F_Flute2", Length = 255, ColumnDescription = "换愣后愣型")]
    public string F_Flute2 { get; set; } = default!;

    /// <summary>提前多少米</summary>
    [SugarColumn(ColumnName = "F_PreMeter", ColumnDescription = "提前多少米")]
    public int F_PreMeter { get; set; }

    /// <summary>车速降至</summary>
    [SugarColumn(ColumnName = "F_Speed", ColumnDescription = "车速降至")]
    public int F_Speed { get; set; }

}