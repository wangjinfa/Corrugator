using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 瓦楞楞型部位系数
/// </summary>
[SugarTable("TB_QDM_CorrugatedFluteFactor", TableDescription = "瓦楞楞型部位系数")]
public class TB_QDM_CorrugatedFluteFactor
{
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

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

    /// <summary>瓦楞辊压力主键id</summary>
    [SugarColumn(ColumnName = "F_CorrugatedRollPre_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "瓦楞辊压力主键id")]
    public int F_CorrugatedRollPre_ID { get; set; }

    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal F_Factor { get; set; }

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}