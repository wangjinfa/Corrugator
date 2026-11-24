using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 产线楞型基础资料设置表
/// </summary>
[SugarTable("W_ProductWaves", TableDescription = "产线楞型基础资料设置表")]
public class W_ProductWaves
{
    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "WSPW_Width", ColumnDescription = "门幅mm")]
    public int WSPW_Width { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "WSPW_Wave", Length = 50, ColumnDescription = "楞型")]
    public string WSPW_Wave { get; set; } = default!;

    /// <summary>SF1楞高</summary>
    [SugarColumn(ColumnName = "WSPW_WDeepSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF1楞高")]
    public decimal? WSPW_WDeepSF1 { get; set; }

    /// <summary>SF1楞率</summary>
    [SugarColumn(ColumnName = "WSPW_WRateSF1", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF1楞率")]
    public decimal? WSPW_WRateSF1 { get; set; }

    /// <summary>SF2楞高</summary>
    [SugarColumn(ColumnName = "WSPW_WDeepSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF2楞高")]
    public decimal? WSPW_WDeepSF2 { get; set; }

    /// <summary>SF2楞率</summary>
    [SugarColumn(ColumnName = "WSPW_WRateSF2", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF2楞率")]
    public decimal? WSPW_WRateSF2 { get; set; }

    /// <summary>SF3楞高</summary>
    [SugarColumn(ColumnName = "WSPW_WDeepSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF3楞高")]
    public decimal? WSPW_WDeepSF3 { get; set; }

    /// <summary>SF3楞率</summary>
    [SugarColumn(ColumnName = "WSPW_WRateSF3", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "SF3楞率")]
    public decimal? WSPW_WRateSF3 { get; set; }

    /// <summary>纸板厚度</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeep", Length = 18, DecimalDigits = 4, ColumnDescription = "纸板厚度")]
    public decimal WSPW_PaperDeep { get; set; }

    /// <summary>最大剖数</summary>
    [SugarColumn(ColumnName = "WSPW_MaxCN", ColumnDescription = "最大剖数")]
    public int WSPW_MaxCN { get; set; }

    /// <summary>最小切长mm</summary>
    [SugarColumn(ColumnName = "WSPW_MinCutLength", ColumnDescription = "最小切长mm")]
    public int WSPW_MinCutLength { get; set; }

    /// <summary>最大切长mm</summary>
    [SugarColumn(ColumnName = "WSPW_MaxCutLength", ColumnDescription = "最大切长mm")]
    public int WSPW_MaxCutLength { get; set; }

    /// <summary>最小修边mm</summary>
    [SugarColumn(ColumnName = "WSPW_MinEdge", ColumnDescription = "最小修边mm")]
    public int WSPW_MinEdge { get; set; }

    /// <summary>最大修边mm</summary>
    [SugarColumn(ColumnName = "WSPW_MaxEdge", ColumnDescription = "最大修边mm")]
    public int WSPW_MaxEdge { get; set; }

    /// <summary>小压线mm</summary>
    [SugarColumn(ColumnName = "WSPW_SmallScor", IsNullable = true, ColumnDescription = "小压线mm")]
    public int? WSPW_SmallScor { get; set; }

    /// <summary>小压线加深</summary>
    [SugarColumn(ColumnName = "WSPW_SmallScorDepth", IsNullable = true, ColumnDescription = "小压线加深")]
    public int? WSPW_SmallScorDepth { get; set; }

    /// <summary>平压线深度</summary>
    [SugarColumn(ColumnName = "WSPW_FlatScorDepth", IsNullable = true, ColumnDescription = "平压线深度")]
    public int? WSPW_FlatScorDepth { get; set; }

    /// <summary>普压线深度</summary>
    [SugarColumn(ColumnName = "WSPW_ComScorDepth", IsNullable = true, ColumnDescription = "普压线深度")]
    public int? WSPW_ComScorDepth { get; set; }

    /// <summary>深压线深度</summary>
    [SugarColumn(ColumnName = "WSPW_ProScorDePth", IsNullable = true, ColumnDescription = "深压线深度")]
    public int? WSPW_ProScorDePth { get; set; }

    /// <summary>创建日期</summary>
    [SugarColumn(ColumnName = "WSPW_CreateTime", ColumnDescription = "创建日期")]
    public DateTime WSPW_CreateTime { get; set; }

    /// <summary>创建用户</summary>
    [SugarColumn(ColumnName = "WSPW_Creator", Length = 50, ColumnDescription = "创建用户")]
    public string WSPW_Creator { get; set; } = default!;

    /// <summary>修改日期</summary>
    [SugarColumn(ColumnName = "WSPW_EditTime", IsNullable = true, ColumnDescription = "修改日期")]
    public DateTime? WSPW_EditTime { get; set; }

    /// <summary>修改用户</summary>
    [SugarColumn(ColumnName = "WSPW_Editor", Length = 50, IsNullable = true, ColumnDescription = "修改用户")]
    public string? WSPW_Editor { get; set; }

    /// <summary>WSPW_MaxSpeed</summary>
    [SugarColumn(ColumnName = "WSPW_MaxSpeed", IsNullable = true, ColumnDescription = "WSPW_MaxSpeed")]
    public int? WSPW_MaxSpeed { get; set; }

    /// <summary>WSPW_PaperDeepWeight1</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeepWeight1", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeepWeight1")]
    public decimal WSPW_PaperDeepWeight1 { get; set; }

    /// <summary>WSPW_PaperDeepWeight2</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeepWeight2", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeepWeight2")]
    public decimal WSPW_PaperDeepWeight2 { get; set; }

    /// <summary>WSPW_PaperDeepWeight3</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeepWeight3", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeepWeight3")]
    public decimal WSPW_PaperDeepWeight3 { get; set; }

    /// <summary>WSPW_PaperDeep1</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeep1", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeep1")]
    public decimal WSPW_PaperDeep1 { get; set; }

    /// <summary>WSPW_PaperDeep2</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeep2", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeep2")]
    public decimal WSPW_PaperDeep2 { get; set; }

    /// <summary>WSPW_PaperDeep3</summary>
    [SugarColumn(ColumnName = "WSPW_PaperDeep3", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_PaperDeep3")]
    public decimal WSPW_PaperDeep3 { get; set; }

    /// <summary>WSPW_UpLimite</summary>
    [SugarColumn(ColumnName = "WSPW_UpLimite", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_UpLimite")]
    public decimal WSPW_UpLimite { get; set; }

    /// <summary>WSPW_DownLimite</summary>
    [SugarColumn(ColumnName = "WSPW_DownLimite", Length = 18, DecimalDigits = 2, ColumnDescription = "WSPW_DownLimite")]
    public decimal WSPW_DownLimite { get; set; }

    /// <summary>WSPW_CN1</summary>
    [SugarColumn(ColumnName = "WSPW_CN1", ColumnDescription = "WSPW_CN1")]
    public int WSPW_CN1 { get; set; }

    /// <summary>WSPW_CN2</summary>
    [SugarColumn(ColumnName = "WSPW_CN2", ColumnDescription = "WSPW_CN2")]
    public int WSPW_CN2 { get; set; }

    /// <summary>WSPW_CN3</summary>
    [SugarColumn(ColumnName = "WSPW_CN3", ColumnDescription = "WSPW_CN3")]
    public int WSPW_CN3 { get; set; }

    /// <summary>上堆码出垛数</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty", ColumnDescription = "上堆码出垛数")]
    public int WSPW_StackQty { get; set; }

    /// <summary>下堆码出垛数</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty_D", ColumnDescription = "下堆码出垛数")]
    public int WSPW_StackQty_D { get; set; }

    /// <summary>WSPW_StackQty2</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty2", ColumnDescription = "WSPW_StackQty2")]
    public int WSPW_StackQty2 { get; set; }

    /// <summary>WSPW_StackQty_D2</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty_D2", ColumnDescription = "WSPW_StackQty_D2")]
    public int WSPW_StackQty_D2 { get; set; }

    /// <summary>WSPW_StackQty3</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty3", ColumnDescription = "WSPW_StackQty3")]
    public int WSPW_StackQty3 { get; set; }

    /// <summary>WSPW_StackQty_D3</summary>
    [SugarColumn(ColumnName = "WSPW_StackQty_D3", ColumnDescription = "WSPW_StackQty_D3")]
    public int WSPW_StackQty_D3 { get; set; }

    /// <summary>错位数量</summary>
    [SugarColumn(ColumnName = "WBundleQty", ColumnDescription = "错位数量")]
    public int WBundleQty { get; set; }

    /// <summary>WSPW_Trim</summary>
    [SugarColumn(ColumnName = "WSPW_Trim", IsNullable = true, ColumnDescription = "WSPW_Trim")]
    public int? WSPW_Trim { get; set; }

    /// <summary>WSPW_Wgt1</summary>
    [SugarColumn(ColumnName = "WSPW_Wgt1", IsNullable = true, ColumnDescription = "WSPW_Wgt1")]
    public int? WSPW_Wgt1 { get; set; }

    /// <summary>WSPW_Wgt2</summary>
    [SugarColumn(ColumnName = "WSPW_Wgt2", IsNullable = true, ColumnDescription = "WSPW_Wgt2")]
    public int? WSPW_Wgt2 { get; set; }

    /// <summary>WSPW_AddDepth1</summary>
    [SugarColumn(ColumnName = "WSPW_AddDepth1", IsNullable = true, ColumnDescription = "WSPW_AddDepth1")]
    public int? WSPW_AddDepth1 { get; set; }

    /// <summary>WSPW_AddDepth2</summary>
    [SugarColumn(ColumnName = "WSPW_AddDepth2", IsNullable = true, ColumnDescription = "WSPW_AddDepth2")]
    public int? WSPW_AddDepth2 { get; set; }

    /// <summary>WSPW_ID</summary>
    [SugarColumn(ColumnName = "WSPW_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSPW_ID")]
    public int WSPW_ID { get; set; }

}