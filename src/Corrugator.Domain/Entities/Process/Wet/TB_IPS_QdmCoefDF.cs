using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// 双面机糊机QDM系数
/// </summary>
[SugarTable("TB_IPS_QdmCoefDF", TableDescription = "双面机糊机QDM系数")]
public class TB_IPS_QdmCoefDF
{
    /// <summary>材质（去除 - ）</summary>
    [SugarColumn(ColumnName = "F_Paper", Length = 100, ColumnDescription = "材质（去除 - ）")]
    public string F_Paper { get; set; } = default!;

    /// <summary>订单楞型</summary>
    [SugarColumn(ColumnName = "F_Flute", Length = 10, ColumnDescription = "订单楞型")]
    public string F_Flute { get; set; } = default!;

    /// <summary>1层糊间隙系数（纸张的1层）</summary>
    [SugarColumn(ColumnName = "F_Glue1", Length = 18, DecimalDigits = 2, ColumnDescription = "1层糊间隙系数（纸张的1层）")]
    public decimal F_Glue1 { get; set; }

    /// <summary>2层糊间隙系数（纸张的2层）</summary>
    [SugarColumn(ColumnName = "F_Glue2", Length = 18, DecimalDigits = 2, ColumnDescription = "2层糊间隙系数（纸张的2层）")]
    public decimal F_Glue2 { get; set; }

    /// <summary>3层糊间隙系数（纸张的3层）</summary>
    [SugarColumn(ColumnName = "F_Glue3", Length = 18, DecimalDigits = 2, ColumnDescription = "3层糊间隙系数（纸张的3层）")]
    public decimal F_Glue3 { get; set; }

    /// <summary>面纸烘缸系数</summary>
    [SugarColumn(ColumnName = "F_Wrap0", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸烘缸系数")]
    public decimal F_Wrap0 { get; set; }

    /// <summary>1层烘缸系数（纸张的1层）</summary>
    [SugarColumn(ColumnName = "F_Wrap1", Length = 18, DecimalDigits = 2, ColumnDescription = "1层烘缸系数（纸张的1层）")]
    public decimal F_Wrap1 { get; set; }

    /// <summary>2层烘缸系数（纸张的2层）</summary>
    [SugarColumn(ColumnName = "F_Wrap2", Length = 18, DecimalDigits = 2, ColumnDescription = "2层烘缸系数（纸张的2层）")]
    public decimal F_Wrap2 { get; set; }

    /// <summary>3层烘缸系数（纸张的3层）</summary>
    [SugarColumn(ColumnName = "F_Wrap3", Length = 18, DecimalDigits = 2, ColumnDescription = "3层烘缸系数（纸张的3层）")]
    public decimal F_Wrap3 { get; set; }

    /// <summary>面纸烘缸蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam0", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸烘缸蒸汽系数")]
    public decimal F_PreheaterSteam0 { get; set; }

    /// <summary>1层烘缸蒸汽系数（纸张的1层）</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam1", Length = 18, DecimalDigits = 2, ColumnDescription = "1层烘缸蒸汽系数（纸张的1层）")]
    public decimal F_PreheaterSteam1 { get; set; }

    /// <summary>2层烘缸蒸汽系数（纸张的2层）</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam2", Length = 18, DecimalDigits = 2, ColumnDescription = "2层烘缸蒸汽系数（纸张的2层）")]
    public decimal F_PreheaterSteam2 { get; set; }

    /// <summary>3层烘缸蒸汽系数（纸张的3层）</summary>
    [SugarColumn(ColumnName = "F_PreheaterSteam3", Length = 18, DecimalDigits = 2, ColumnDescription = "3层烘缸蒸汽系数（纸张的3层）")]
    public decimal F_PreheaterSteam3 { get; set; }

    /// <summary>一段热板蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam1", Length = 18, DecimalDigits = 2, ColumnDescription = "一段热板蒸汽系数")]
    public decimal F_HotPlateSteam1 { get; set; }

    /// <summary>二段热板蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam2", Length = 18, DecimalDigits = 2, ColumnDescription = "二段热板蒸汽系数")]
    public decimal F_HotPlateSteam2 { get; set; }

    /// <summary>三段热板蒸汽系数</summary>
    [SugarColumn(ColumnName = "F_HotPlateSteam3", Length = 18, DecimalDigits = 2, ColumnDescription = "三段热板蒸汽系数")]
    public decimal F_HotPlateSteam3 { get; set; }

    /// <summary>压板组数系数</summary>
    [SugarColumn(ColumnName = "F_HotLoadGroupQty", Length = 18, DecimalDigits = 2, ColumnDescription = "压板组数系数")]
    public decimal F_HotLoadGroupQty { get; set; }

    /// <summary>热板压力系数</summary>
    [SugarColumn(ColumnName = "F_HotPlatePress", Length = 18, DecimalDigits = 2, ColumnDescription = "热板压力系数")]
    public decimal F_HotPlatePress { get; set; }

    /// <summary>冷板压力系数</summary>
    [SugarColumn(ColumnName = "F_ColdPlatePress", Length = 18, DecimalDigits = 2, ColumnDescription = "冷板压力系数")]
    public decimal F_ColdPlatePress { get; set; }

    /// <summary>面纸接纸机张力系数</summary>
    [SugarColumn(ColumnName = "F_SplicerTensionLS0", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸接纸机张力系数")]
    public decimal F_SplicerTensionLS0 { get; set; }

    /// <summary>1层天桥张力系数（纸张的1层）</summary>
    [SugarColumn(ColumnName = "F_BridgeTension1", Length = 18, DecimalDigits = 2, ColumnDescription = "1层天桥张力系数（纸张的1层）")]
    public decimal F_BridgeTension1 { get; set; }

    /// <summary>2层天桥张力系数（纸张的2层）</summary>
    [SugarColumn(ColumnName = "F_BridgeTension2", Length = 18, DecimalDigits = 2, ColumnDescription = "2层天桥张力系数（纸张的2层）")]
    public decimal F_BridgeTension2 { get; set; }

    /// <summary>3层天桥张力系数（纸张的3层）</summary>
    [SugarColumn(ColumnName = "F_BridgeTension3", Length = 18, DecimalDigits = 2, ColumnDescription = "3层天桥张力系数（纸张的3层）")]
    public decimal F_BridgeTension3 { get; set; }

    /// <summary>面纸喷雾系数</summary>
    [SugarColumn(ColumnName = "F_Spray0", Length = 18, DecimalDigits = 2, ColumnDescription = "面纸喷雾系数")]
    public decimal F_Spray0 { get; set; }

    /// <summary>1层喷雾系数（纸张的1层）</summary>
    [SugarColumn(ColumnName = "F_Spray1", Length = 18, DecimalDigits = 2, ColumnDescription = "1层喷雾系数（纸张的1层）")]
    public decimal F_Spray1 { get; set; }

    /// <summary>2层喷雾系数（纸张的2层）</summary>
    [SugarColumn(ColumnName = "F_Spray2", Length = 18, DecimalDigits = 2, ColumnDescription = "2层喷雾系数（纸张的2层）")]
    public decimal F_Spray2 { get; set; }

    /// <summary>3层喷雾系数（纸张的3层）</summary>
    [SugarColumn(ColumnName = "F_Spray3", Length = 18, DecimalDigits = 2, ColumnDescription = "3层喷雾系数（纸张的3层）")]
    public decimal F_Spray3 { get; set; }

    /// <summary>巡航系数</summary>
    [SugarColumn(ColumnName = "F_CruiseSpeed", Length = 18, DecimalDigits = 2, ColumnDescription = "巡航系数")]
    public decimal F_CruiseSpeed { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public int F_ID { get; set; }

}