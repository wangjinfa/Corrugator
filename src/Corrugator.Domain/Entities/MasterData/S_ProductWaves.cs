using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 产线楞型基础资料设置表
/// </summary>
[SugarTable("S_ProductWaves", TableDescription = "产线楞型基础资料设置表")]
public class S_ProductWaves
{
    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "SPW_Width", ColumnDescription = "门幅mm")]
    public int SPW_Width { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "SPW_Wave", Length = 50, ColumnDescription = "楞型")]
    public string SPW_Wave { get; set; } = default!;

    /// <summary>SF1楞高</summary>
    [SugarColumn(ColumnName = "SPW_WDeepSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF1楞高")]
    public decimal? SPW_WDeepSF1 { get; set; }

    /// <summary>SF1楞率</summary>
    [SugarColumn(ColumnName = "SPW_WRateSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF1楞率")]
    public decimal? SPW_WRateSF1 { get; set; }

    /// <summary>SF2楞高</summary>
    [SugarColumn(ColumnName = "SPW_WDeepSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF2楞高")]
    public decimal? SPW_WDeepSF2 { get; set; }

    /// <summary>SF2楞率</summary>
    [SugarColumn(ColumnName = "SPW_WRateSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF2楞率")]
    public decimal? SPW_WRateSF2 { get; set; }

    /// <summary>SF3楞高</summary>
    [SugarColumn(ColumnName = "SPW_WDeepSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF3楞高")]
    public decimal? SPW_WDeepSF3 { get; set; }

    /// <summary>SF3楞率</summary>
    [SugarColumn(ColumnName = "SPW_WRateSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF3楞率")]
    public decimal? SPW_WRateSF3 { get; set; }

    /// <summary>纸板厚度</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "纸板厚度")]
    public decimal SPW_PaperDeep { get; set; }

    /// <summary>最大剖数</summary>
    [SugarColumn(ColumnName = "SPW_MaxCN", ColumnDescription = "最大剖数")]
    public int SPW_MaxCN { get; set; }

    /// <summary>最小切长mm</summary>
    [SugarColumn(ColumnName = "SPW_MinCutLength", ColumnDescription = "最小切长mm")]
    public int SPW_MinCutLength { get; set; }

    /// <summary>最大切长mm</summary>
    [SugarColumn(ColumnName = "SPW_MaxCutLength", ColumnDescription = "最大切长mm")]
    public int SPW_MaxCutLength { get; set; }

    /// <summary>最小修边mm</summary>
    [SugarColumn(ColumnName = "SPW_MinEdge", ColumnDescription = "最小修边mm")]
    public int SPW_MinEdge { get; set; }

    /// <summary>最大修边mm</summary>
    [SugarColumn(ColumnName = "SPW_MaxEdge", ColumnDescription = "最大修边mm")]
    public int SPW_MaxEdge { get; set; }

    /// <summary>小压线mm</summary>
    [SugarColumn(ColumnName = "SPW_SmallScor", IsNullable = true, ColumnDescription = "小压线mm")]
    public int? SPW_SmallScor { get; set; }

    /// <summary>小压线加深</summary>
    [SugarColumn(ColumnName = "SPW_SmallScorDepth", IsNullable = true, ColumnDescription = "小压线加深")]
    public int? SPW_SmallScorDepth { get; set; }

    /// <summary>平压线深度</summary>
    [SugarColumn(ColumnName = "SPW_FlatScorDepth", IsNullable = true, ColumnDescription = "平压线深度")]
    public int? SPW_FlatScorDepth { get; set; }

    /// <summary>普压线深度</summary>
    [SugarColumn(ColumnName = "SPW_ComScorDepth", IsNullable = true, ColumnDescription = "普压线深度")]
    public int? SPW_ComScorDepth { get; set; }

    /// <summary>深压线深度</summary>
    [SugarColumn(ColumnName = "SPW_ProScorDePth", IsNullable = true, ColumnDescription = "深压线深度")]
    public int? SPW_ProScorDePth { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "SPW_CreateTime", ColumnDescription = "创建日期")]
    public DateTime SPW_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "SPW_Creator", Length = 50, ColumnDescription = "创建用户")]
    public string SPW_Creator { get; set; } = default!;

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "SPW_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? SPW_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "SPW_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? SPW_Editor { get; set; }

    /// <summary>SPW_MaxSpeed</summary>
    [SugarColumn(ColumnName = "SPW_MaxSpeed", IsNullable = true, ColumnDescription = "SPW_MaxSpeed")]
    public int? SPW_MaxSpeed { get; set; }

    /// <summary>SPW_PaperDeepWeight1</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeepWeight1", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeepWeight1")]
    public decimal SPW_PaperDeepWeight1 { get; set; }

    /// <summary>SPW_PaperDeepWeight2</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeepWeight2", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeepWeight2")]
    public decimal SPW_PaperDeepWeight2 { get; set; }

    /// <summary>SPW_PaperDeepWeight3</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeepWeight3", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeepWeight3")]
    public decimal SPW_PaperDeepWeight3 { get; set; }

    /// <summary>SPW_PaperDeep1</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeep1", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeep1")]
    public decimal SPW_PaperDeep1 { get; set; }

    /// <summary>SPW_PaperDeep2</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeep2", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeep2")]
    public decimal SPW_PaperDeep2 { get; set; }

    /// <summary>SPW_PaperDeep3</summary>
    [SugarColumn(ColumnName = "SPW_PaperDeep3", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_PaperDeep3")]
    public decimal SPW_PaperDeep3 { get; set; }

    /// <summary>SPW_UpLimite</summary>
    [SugarColumn(ColumnName = "SPW_UpLimite", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_UpLimite")]
    public decimal SPW_UpLimite { get; set; }

    /// <summary>SPW_DownLimite</summary>
    [SugarColumn(ColumnName = "SPW_DownLimite", Length = 18, DecimalDigits = 2, ColumnDescription = "SPW_DownLimite")]
    public decimal SPW_DownLimite { get; set; }

    /// <summary>SPW_CN1</summary>
    [SugarColumn(ColumnName = "SPW_CN1", ColumnDescription = "SPW_CN1")]
    public int SPW_CN1 { get; set; }

    /// <summary>SPW_CN2</summary>
    [SugarColumn(ColumnName = "SPW_CN2", ColumnDescription = "SPW_CN2")]
    public int SPW_CN2 { get; set; }

    /// <summary>SPW_CN3</summary>
    [SugarColumn(ColumnName = "SPW_CN3", ColumnDescription = "SPW_CN3")]
    public int SPW_CN3 { get; set; }

    /// <summary>上堆码出垛数</summary>
    [SugarColumn(ColumnName = "SPW_StackQty", ColumnDescription = "上堆码出垛数")]
    public int SPW_StackQty { get; set; }

    /// <summary>下堆码出垛数</summary>
    [SugarColumn(ColumnName = "SPW_StackQty_D", ColumnDescription = "下堆码出垛数")]
    public int SPW_StackQty_D { get; set; }

    /// <summary>SPW_StackQty2</summary>
    [SugarColumn(ColumnName = "SPW_StackQty2", ColumnDescription = "SPW_StackQty2")]
    public int SPW_StackQty2 { get; set; }

    /// <summary>SPW_StackQty_D2</summary>
    [SugarColumn(ColumnName = "SPW_StackQty_D2", ColumnDescription = "SPW_StackQty_D2")]
    public int SPW_StackQty_D2 { get; set; }

    /// <summary>SPW_StackQty3</summary>
    [SugarColumn(ColumnName = "SPW_StackQty3", ColumnDescription = "SPW_StackQty3")]
    public int SPW_StackQty3 { get; set; }

    /// <summary>SPW_StackQty_D3</summary>
    [SugarColumn(ColumnName = "SPW_StackQty_D3", ColumnDescription = "SPW_StackQty_D3")]
    public int SPW_StackQty_D3 { get; set; }

    /// <summary>错位数量</summary>
    [SugarColumn(ColumnName = "BundleQty", ColumnDescription = "错位数量")]
    public int BundleQty { get; set; }

    /// <summary>SPW_Trim</summary>
    [SugarColumn(ColumnName = "SPW_Trim", IsNullable = true, ColumnDescription = "SPW_Trim")]
    public int? SPW_Trim { get; set; }

    /// <summary>SPW_Wgt1</summary>
    [SugarColumn(ColumnName = "SPW_Wgt1", IsNullable = true, ColumnDescription = "SPW_Wgt1")]
    public int? SPW_Wgt1 { get; set; }

    /// <summary>SPW_Wgt2</summary>
    [SugarColumn(ColumnName = "SPW_Wgt2", IsNullable = true, ColumnDescription = "SPW_Wgt2")]
    public int? SPW_Wgt2 { get; set; }

    /// <summary>SPW_AddDepth1</summary>
    [SugarColumn(ColumnName = "SPW_AddDepth1", IsNullable = true, ColumnDescription = "SPW_AddDepth1")]
    public int? SPW_AddDepth1 { get; set; }

    /// <summary>SPW_AddDepth2</summary>
    [SugarColumn(ColumnName = "SPW_AddDepth2", IsNullable = true, ColumnDescription = "SPW_AddDepth2")]
    public int? SPW_AddDepth2 { get; set; }

    /// <summary>SPW_ID</summary>
    [SugarColumn(ColumnName = "SPW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SPW_ID")]
    public int SPW_ID { get; set; }

}