using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// BHS热喷雾车速系数
/// </summary>
[SugarTable("W_QDM_BHSSpraySpeedFactor", TableDescription = "BHS热喷雾车速系数")]
public class W_QDM_BHSSpraySpeedFactor
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>速度</summary>
    [SugarColumn(ColumnName = "WF_Speed", ColumnDescription = "速度")]
    public int WF_Speed { get; set; }

    /// <summary>系数</summary>
    [SugarColumn(ColumnName = "WF_Factor", Length = 18, DecimalDigits = 2, ColumnDescription = "系数")]
    public decimal WF_Factor { get; set; }

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

    /// <summary>WF_Id</summary>
    [SugarColumn(ColumnName = "WF_Id", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_Id")]
    public int WF_Id { get; set; }

}