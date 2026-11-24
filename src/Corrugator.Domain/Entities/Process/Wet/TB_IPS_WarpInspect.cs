using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 弯翘设备检测信息表
/// </summary>
[SugarTable("W_IPS_WarpInspect", TableDescription = "弯翘设备检测信息表")]
public class W_IPS_WarpInspect
{
    /// <summary>主键ID</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键ID")]
    public int WF_Id { get; set; }

    /// <summary>弯翘状态</summary>
    [SugarColumn(ColumnName = "WF_WarpState", Length = 100, IsNullable = true, ColumnDescription = "弯翘状态", DefaultValue = "NULL::character varying")]
    public string? WF_WarpState { get; set; }

    /// <summary>弯翘度数</summary>
    [SugarColumn(ColumnName = "WF_WarpDegree", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "弯翘度数", DefaultValue = "NULL::numeric")]
    public decimal? WF_WarpDegree { get; set; }

    /// <summary>检测时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "检测时间")]
    public DateTime? WF_CreateTime { get; set; }

}