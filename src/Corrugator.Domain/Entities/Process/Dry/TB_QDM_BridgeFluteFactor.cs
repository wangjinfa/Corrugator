using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 天桥张力楞型系数
/// </summary>
[SugarTable("TB_QDM_BridgeFluteFactor", TableDescription = "天桥张力楞型系数")]
public class TB_QDM_BridgeFluteFactor
{
    /// <summary>F_Position</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, IsNullable = true, ColumnDescription = "F_Position")]
    public string? F_Position { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, IsNullable = true, ColumnDescription = "楞型")]
    public string? F_Flute { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "F_FluteFactor", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "系数")]
    public decimal? F_FluteFactor { get; set; }

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

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}