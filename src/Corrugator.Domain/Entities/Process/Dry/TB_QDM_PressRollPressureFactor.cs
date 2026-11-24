using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压力辊部位楞型系数
/// </summary>
[SugarTable("W_QDM_PressRollPressureFactor", TableDescription = "压力辊部位楞型系数")]
public class W_QDM_PressRollPressureFactor
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 36, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 100, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WF_Factor { get; set; }

    /// <summary>压力辊压力Id</summary>
    [SugarColumn(ColumnName = "WF_PressRollPressure_ID", ColumnDescription = "压力辊压力Id")]
    public int WF_PressRollPressure_ID { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? WF_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? WF_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? WF_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? WF_EditTime { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public int WF_ID { get; set; }

}