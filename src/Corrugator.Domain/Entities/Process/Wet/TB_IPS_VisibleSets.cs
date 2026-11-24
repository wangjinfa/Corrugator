using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// IPS控制模块显示/隐藏设置
/// </summary>
[SugarTable("W_IPS_VisibleSets", TableDescription = "IPS控制模块显示/隐藏设置")]
public class W_IPS_VisibleSets
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>编码</summary>
    [SugarColumn(ColumnName = "WF_Code", Length = 255, ColumnDescription = "编码")]
    public string WF_Code { get; set; } = default!;

    /// <summary>WF_Name</summary>
    [SugarColumn(ColumnName = "WF_Name", Length = 255, ColumnDescription = "WF_Name")]
    public string WF_Name { get; set; } = default!;

    /// <summary>显示/隐藏</summary>
    [SugarColumn(ColumnName = "WF_IsShow", ColumnDescription = "显示/隐藏")]
    public bool WF_IsShow { get; set; }

}