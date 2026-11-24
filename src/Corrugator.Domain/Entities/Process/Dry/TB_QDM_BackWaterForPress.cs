using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 泠凝回水备压
/// </summary>
[SugarTable("TB_QDM_BackWaterForPress", TableDescription = "泠凝回水备压")]
public class TB_QDM_BackWaterForPress
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 50, ColumnDescription = "楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>高压罐泄压开始值</summary>
    [SugarColumn(ColumnName = "F_HighPreDecompressionIV", Length = 18, DecimalDigits = 2, ColumnDescription = "高压罐泄压开始值")]
    public decimal F_HighPreDecompressionIV { get; set; }

    /// <summary>高压罐泄压结束值</summary>
    [SugarColumn(ColumnName = "F_HighPreDecompressionEV", Length = 18, DecimalDigits = 2, ColumnDescription = "高压罐泄压结束值")]
    public decimal F_HighPreDecompressionEV { get; set; }

    /// <summary>低压罐泄压开始值</summary>
    [SugarColumn(ColumnName = "F_LowPreDecompressionIV", Length = 18, DecimalDigits = 2, ColumnDescription = "低压罐泄压开始值")]
    public decimal F_LowPreDecompressionIV { get; set; }

    /// <summary>低压罐泄压结束值</summary>
    [SugarColumn(ColumnName = "F_LowPreDecompressionEV", Length = 18, DecimalDigits = 2, ColumnDescription = "低压罐泄压结束值")]
    public decimal F_LowPreDecompressionEV { get; set; }

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

    /// <summary>F_Id</summary>
    [SugarColumn(ColumnName = "F_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_Id")]
    public int F_Id { get; set; }

}