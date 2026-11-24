using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// IPS控制模块显示/隐藏设置
/// </summary>
[SugarTable("TB_IPS_VisibleSets", TableDescription = "IPS控制模块显示/隐藏设置")]
public class TB_IPS_VisibleSets
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>编码</summary>
    [SugarColumn(ColumnName = "F_Code", Length = 255, ColumnDescription = "编码")]
    public string F_Code { get; set; } = default!;

    /// <summary>F_Name</summary>
    [SugarColumn(ColumnName = "F_Name", Length = 255, ColumnDescription = "F_Name")]
    public string F_Name { get; set; } = default!;

    /// <summary>显示/隐藏</summary>
    [SugarColumn(ColumnName = "F_IsShow", ColumnDescription = "显示/隐藏")]
    public bool F_IsShow { get; set; }

}