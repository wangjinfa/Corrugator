using SqlSugar;

namespace Corrugator.Domain.Entities.Pms;

/// <summary>
/// 标签打印设置
/// </summary>
[SugarTable("TB_PMS_LabelPrint", TableDescription = "标签打印设置")]
public class TB_PMS_LabelPrint
{
    /// <summary>主键</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "主键")]
    public int F_ID { get; set; }

    /// <summary>剖数</summary>
    [SugarColumn(ColumnName = "F_CN", ColumnDescription = "剖数")]
    public int F_CN { get; set; }

    /// <summary>切宽mm</summary>
    [SugarColumn(ColumnName = "F_CutWidth", ColumnDescription = "切宽mm")]
    public int F_CutWidth { get; set; }

    /// <summary>标签数量</summary>
    [SugarColumn(ColumnName = "F_LabelQty", ColumnDescription = "标签数量")]
    public int F_LabelQty { get; set; }

}