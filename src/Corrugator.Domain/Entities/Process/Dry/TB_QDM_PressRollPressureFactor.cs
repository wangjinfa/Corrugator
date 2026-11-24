using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 压力辊部位楞型系数
/// </summary>
[SugarTable("TB_QDM_PressRollPressureFactor", TableDescription = "压力辊部位楞型系数")]
public class TB_QDM_PressRollPressureFactor
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 36, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 100, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal F_Factor { get; set; }

    /// <summary>压力辊压力Id</summary>
    [SugarColumn(ColumnName = "F_PressRollPressure_ID", ColumnDescription = "压力辊压力Id")]
    public int F_PressRollPressure_ID { get; set; }

    /// <summary>创建人</summary>
    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true, ColumnDescription = "创建人")]
    public string? F_Creator { get; set; }

    /// <summary>创建时间</summary>
    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true, ColumnDescription = "创建时间")]
    public DateTime? F_CreateTime { get; set; }

    /// <summary>编辑人</summary>
    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true, ColumnDescription = "编辑人")]
    public string? F_Editor { get; set; }

    /// <summary>编辑时间</summary>
    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true, ColumnDescription = "编辑时间")]
    public DateTime? F_EditTime { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}