using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 换愣降速设置
/// </summary>
[SugarTable("W_IPS_CruiseChangewave", TableDescription = "换愣降速设置")]
public class W_IPS_CruiseChangewave
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>换愣前愣型</summary>
    [SugarColumn(ColumnName = "WF_Flute1", Length = 255, ColumnDescription = "换愣前愣型")]
    public string WF_Flute1 { get; set; } = default!;

    /// <summary>换愣后愣型</summary>
    [SugarColumn(ColumnName = "WF_Flute2", Length = 255, ColumnDescription = "换愣后愣型")]
    public string WF_Flute2 { get; set; } = default!;

    /// <summary>提前多少米</summary>
    [SugarColumn(ColumnName = "WF_PreMeter", ColumnDescription = "提前多少米")]
    public int WF_PreMeter { get; set; }

    /// <summary>车速降至</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "车速降至")]
    public int WF_Speed { get; set; }

}