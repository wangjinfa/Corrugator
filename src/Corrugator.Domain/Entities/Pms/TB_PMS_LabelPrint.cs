using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// 标签打印设置
/// </summary>
[SugarTable("W_PMS_LabelPrint", TableDescription = "标签打印设置")]
public class W_PMS_LabelPrint
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int WF_ID { get; set; }

    /// <summary>剖数</summary>
    [SugarColumn(ColumnName = "WF_CN", ColumnDescription = "剖数")]
    public int WF_CN { get; set; }

    /// <summary>切宽mm</summary>
    [SugarColumn(ColumnName = "WF_CutWidth", ColumnDescription = "切宽mm")]
    public int WF_CutWidth { get; set; }

    /// <summary>标签数量</summary>
    [SugarColumn(ColumnName = "WF_LabelQty", ColumnDescription = "标签数量")]
    public int WF_LabelQty { get; set; }

}