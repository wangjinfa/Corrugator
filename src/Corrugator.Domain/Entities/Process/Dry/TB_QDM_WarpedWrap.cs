using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Dry;

/// <summary>
/// 弯翘包角
/// </summary>
[SugarTable("W_QDM_WarpedWrap", TableDescription = "弯翘包角")]
public class W_QDM_WarpedWrap
{
    /// <summary>部位</summary>
    [SugarColumn(ColumnName = "WF_Position", Length = 50, ColumnDescription = "部位")]
    public string WF_Position { get; set; } = default!;

    /// <summary>设备</summary>
    [SugarColumn(ColumnName = "WF_Equipment", Length = 50, ColumnDescription = "设备")]
    public string WF_Equipment { get; set; } = default!;

    /// <summary>三层上弯轻</summary>
    [SugarColumn(ColumnName = "WF_UpWarpLight3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯轻")]
    public decimal? WF_UpWarpLight3rd { get; set; }

    /// <summary>三层上弯中</summary>
    [SugarColumn(ColumnName = "WF_UpWarpModerate3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯中")]
    public decimal? WF_UpWarpModerate3rd { get; set; }

    /// <summary>三层上弯重</summary>
    [SugarColumn(ColumnName = "WF_UpWarpSevere3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层上弯重")]
    public decimal? WF_UpWarpSevere3rd { get; set; }

    /// <summary>三层下弯轻</summary>
    [SugarColumn(ColumnName = "WF_DownWarpLight3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯轻")]
    public decimal? WF_DownWarpLight3rd { get; set; }

    /// <summary>三层下弯中</summary>
    [SugarColumn(ColumnName = "WF_DownWarpModerate3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯中")]
    public decimal? WF_DownWarpModerate3rd { get; set; }

    /// <summary>三层下弯轻</summary>
    [SugarColumn(ColumnName = "WF_DownWarpSevere3rd", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "三层下弯轻")]
    public decimal? WF_DownWarpSevere3rd { get; set; }

    /// <summary>五层上弯轻</summary>
    [SugarColumn(ColumnName = "WF_UpWarpLight5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯轻")]
    public decimal? WF_UpWarpLight5ve { get; set; }

    /// <summary>五层上弯中</summary>
    [SugarColumn(ColumnName = "WF_UpWarpModerate5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯中")]
    public decimal? WF_UpWarpModerate5ve { get; set; }

    /// <summary>五层上弯重</summary>
    [SugarColumn(ColumnName = "WF_UpWarpSevere5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层上弯重")]
    public decimal? WF_UpWarpSevere5ve { get; set; }

    /// <summary>五层下弯轻</summary>
    [SugarColumn(ColumnName = "WF_DownWarpLight5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯轻")]
    public decimal? WF_DownWarpLight5ve { get; set; }

    /// <summary>五层下弯中</summary>
    [SugarColumn(ColumnName = "WF_DownWarpModerate5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯中")]
    public decimal? WF_DownWarpModerate5ve { get; set; }

    /// <summary>五层下弯重</summary>
    [SugarColumn(ColumnName = "WF_DownWarpSevere5ve", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "五层下弯重")]
    public decimal? WF_DownWarpSevere5ve { get; set; }

    /// <summary>七层上弯轻</summary>
    [SugarColumn(ColumnName = "WF_UpWarpLight7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯轻")]
    public decimal? WF_UpWarpLight7en { get; set; }

    /// <summary>七层上弯中</summary>
    [SugarColumn(ColumnName = "WF_UpWarpModerate7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯中")]
    public decimal? WF_UpWarpModerate7en { get; set; }

    /// <summary>七层上弯重</summary>
    [SugarColumn(ColumnName = "WF_UpWarpSevere7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层上弯重")]
    public decimal? WF_UpWarpSevere7en { get; set; }

    /// <summary>七层下弯轻</summary>
    [SugarColumn(ColumnName = "WF_DownWarpLight7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯轻")]
    public decimal? WF_DownWarpLight7en { get; set; }

    /// <summary>七层下弯中</summary>
    [SugarColumn(ColumnName = "WF_DownWarpModerate7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯中")]
    public decimal? WF_DownWarpModerate7en { get; set; }

    /// <summary>七层下弯重</summary>
    [SugarColumn(ColumnName = "WF_DownWarpSevere7en", Length = 18, DecimalDigits = 2, IsNullable = true, ColumnDescription = "七层下弯重")]
    public decimal? WF_DownWarpSevere7en { get; set; }

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