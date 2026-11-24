using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 弯翘包角
/// </summary>
[SugarTable("TB_QDM_WarpedWrap", TableDescription = "弯翘包角")]
public class TB_QDM_WarpedWrap
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "F_Position", Length = 50, ColumnDescription = "部位")]
    public string F_Position { get; set; } = default!;

    /// <summary>设备</summary>
    [SugarColumn(ColumnName = "F_Equipment", Length = 50, ColumnDescription = "设备")]
    public string F_Equipment { get; set; } = default!;

    /// <summary>三层上弯轻</summary>
    [SugarColumn(ColumnName = "F_UpWarpLight3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯轻")]
    public decimal? F_UpWarpLight3rd { get; set; }

    /// <summary>三层上弯中</summary>
    [SugarColumn(ColumnName = "F_UpWarpModerate3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯中")]
    public decimal? F_UpWarpModerate3rd { get; set; }

    /// <summary>三层上弯重</summary>
    [SugarColumn(ColumnName = "F_UpWarpSevere3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯重")]
    public decimal? F_UpWarpSevere3rd { get; set; }

    /// <summary>三层下弯轻</summary>
    [SugarColumn(ColumnName = "F_DownWarpLight3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯轻")]
    public decimal? F_DownWarpLight3rd { get; set; }

    /// <summary>三层下弯中</summary>
    [SugarColumn(ColumnName = "F_DownWarpModerate3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯中")]
    public decimal? F_DownWarpModerate3rd { get; set; }

    /// <summary>三层下弯轻</summary>
    [SugarColumn(ColumnName = "F_DownWarpSevere3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯轻")]
    public decimal? F_DownWarpSevere3rd { get; set; }

    /// <summary>五层上弯轻</summary>
    [SugarColumn(ColumnName = "F_UpWarpLight5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯轻")]
    public decimal? F_UpWarpLight5ve { get; set; }

    /// <summary>五层上弯中</summary>
    [SugarColumn(ColumnName = "F_UpWarpModerate5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯中")]
    public decimal? F_UpWarpModerate5ve { get; set; }

    /// <summary>五层上弯重</summary>
    [SugarColumn(ColumnName = "F_UpWarpSevere5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯重")]
    public decimal? F_UpWarpSevere5ve { get; set; }

    /// <summary>五层下弯轻</summary>
    [SugarColumn(ColumnName = "F_DownWarpLight5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯轻")]
    public decimal? F_DownWarpLight5ve { get; set; }

    /// <summary>五层下弯中</summary>
    [SugarColumn(ColumnName = "F_DownWarpModerate5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯中")]
    public decimal? F_DownWarpModerate5ve { get; set; }

    /// <summary>五层下弯重</summary>
    [SugarColumn(ColumnName = "F_DownWarpSevere5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯重")]
    public decimal? F_DownWarpSevere5ve { get; set; }

    /// <summary>七层上弯轻</summary>
    [SugarColumn(ColumnName = "F_UpWarpLight7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯轻")]
    public decimal? F_UpWarpLight7en { get; set; }

    /// <summary>七层上弯中</summary>
    [SugarColumn(ColumnName = "F_UpWarpModerate7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯中")]
    public decimal? F_UpWarpModerate7en { get; set; }

    /// <summary>七层上弯重</summary>
    [SugarColumn(ColumnName = "F_UpWarpSevere7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯重")]
    public decimal? F_UpWarpSevere7en { get; set; }

    /// <summary>七层下弯轻</summary>
    [SugarColumn(ColumnName = "F_DownWarpLight7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯轻")]
    public decimal? F_DownWarpLight7en { get; set; }

    /// <summary>七层下弯中</summary>
    [SugarColumn(ColumnName = "F_DownWarpModerate7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯中")]
    public decimal? F_DownWarpModerate7en { get; set; }

    /// <summary>七层下弯重</summary>
    [SugarColumn(ColumnName = "F_DownWarpSevere7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯重")]
    public decimal? F_DownWarpSevere7en { get; set; }

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