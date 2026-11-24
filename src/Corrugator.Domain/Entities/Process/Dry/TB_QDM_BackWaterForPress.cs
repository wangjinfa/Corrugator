using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 泠凝回水备压
/// </summary>
[SugarTable("W_QDM_BackWaterForPress", TableDescription = "泠凝回水备压")]
public class W_QDM_BackWaterForPress
{
    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WF_Flute", Length = 50, ColumnDescription = "楞型")]
    public string WF_Flute { get; set; } = default!;

    /// <summary>高压罐泄压开始值</summary>
    [SugarColumn(ColumnName = "WF_HighPreDecompressionIV", Length = 18, DecimalDigits = 2, ColumnDescription = "高压罐泄压开始值")]
    public decimal WF_HighPreDecompressionIV { get; set; }

    /// <summary>高压罐泄压结束值</summary>
    [SugarColumn(ColumnName = "WF_HighPreDecompressionEV", Length = 18, DecimalDigits = 2, ColumnDescription = "高压罐泄压结束值")]
    public decimal WF_HighPreDecompressionEV { get; set; }

    /// <summary>低压罐泄压开始值</summary>
    [SugarColumn(ColumnName = "WF_LowPreDecompressionIV", Length = 18, DecimalDigits = 2, ColumnDescription = "低压罐泄压开始值")]
    public decimal WF_LowPreDecompressionIV { get; set; }

    /// <summary>低压罐泄压结束值</summary>
    [SugarColumn(ColumnName = "WF_LowPreDecompressionEV", Length = 18, DecimalDigits = 2, ColumnDescription = "低压罐泄压结束值")]
    public decimal WF_LowPreDecompressionEV { get; set; }

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

    /// <summary>是否删除</summary>
    [SugarColumn(ColumnName = "WF_IsDelete", ColumnDescription = "是否删除")]
    public bool WF_IsDelete { get; set; }

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}