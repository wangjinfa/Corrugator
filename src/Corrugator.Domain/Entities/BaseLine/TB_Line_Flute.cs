using SqlSugar;

namespace Corrugator.Domain.Entities.BaseLine;

/// <summary>
/// 产线楞型（基础信息 → 产线楞型）。门幅 + 楞型唯一，决定厚度、切长、修边、堆码与压线参数。
/// </summary>
[SugarTable("TB_Line_Flute", TableDescription = "产线楞型")]
public class TB_Line_Flute
{
    [SugarColumn(ColumnName = "F_DoorWidth", ColumnDescription = "门幅(mm)")]
    public decimal F_DoorWidth { get; set; }

    [SugarColumn(ColumnName = "F_FluteType", Length = 20, ColumnDescription = "楞型")]
    public string F_FluteType { get; set; } = default!;

    [SugarColumn(ColumnName = "F_Thickness", IsNullable = true, ColumnDescription = "厚度(mm)")]
    public decimal? F_Thickness { get; set; }

    [SugarColumn(ColumnName = "F_Thickness1", IsNullable = true, ColumnDescription = "厚度1(mm)")]
    public decimal? F_Thickness1 { get; set; }

    [SugarColumn(ColumnName = "F_Thickness2", IsNullable = true, ColumnDescription = "厚度2(mm)")]
    public decimal? F_Thickness2 { get; set; }

    [SugarColumn(ColumnName = "F_Thickness3", IsNullable = true, ColumnDescription = "厚度3(mm)")]
    public decimal? F_Thickness3 { get; set; }

    [SugarColumn(ColumnName = "F_WeightThreshold1", IsNullable = true, ColumnDescription = "纸板克重临界值1")]
    public decimal? F_WeightThreshold1 { get; set; }

    [SugarColumn(ColumnName = "F_WeightThreshold2", IsNullable = true, ColumnDescription = "纸板克重临界值2")]
    public decimal? F_WeightThreshold2 { get; set; }

    [SugarColumn(ColumnName = "F_WeightThreshold3", IsNullable = true, ColumnDescription = "纸板克重临界值3")]
    public decimal? F_WeightThreshold3 { get; set; }

    [SugarColumn(ColumnName = "F_MaxSlit", IsNullable = true, ColumnDescription = "最大剖数")]
    public int? F_MaxSlit { get; set; }

    [SugarColumn(ColumnName = "F_MinCutLength", IsNullable = true, ColumnDescription = "最小切长(mm)")]
    public decimal? F_MinCutLength { get; set; }

    [SugarColumn(ColumnName = "F_MaxCutLength", IsNullable = true, ColumnDescription = "最大切长(mm)")]
    public decimal? F_MaxCutLength { get; set; }

    [SugarColumn(ColumnName = "F_MinTrim", IsNullable = true, ColumnDescription = "最小修边(mm)")]
    public decimal? F_MinTrim { get; set; }

    [SugarColumn(ColumnName = "F_MaxTrim", IsNullable = true, ColumnDescription = "最大修边(mm)")]
    public decimal? F_MaxTrim { get; set; }

    [SugarColumn(ColumnName = "F_UpperStackLimit", IsNullable = true, ColumnDescription = "上堆码限高(mm)")]
    public decimal? F_UpperStackLimit { get; set; }

    [SugarColumn(ColumnName = "F_LowerStackLimit", IsNullable = true, ColumnDescription = "下堆码限高(mm)")]
    public decimal? F_LowerStackLimit { get; set; }

    [SugarColumn(ColumnName = "F_StackOpenThreshold1", IsNullable = true, ColumnDescription = "出垛开数临界值1")]
    public int? F_StackOpenThreshold1 { get; set; }

    [SugarColumn(ColumnName = "F_StackOpenThreshold2", IsNullable = true, ColumnDescription = "出垛开数临界值2")]
    public int? F_StackOpenThreshold2 { get; set; }

    [SugarColumn(ColumnName = "F_StackOpenThreshold3", IsNullable = true, ColumnDescription = "出垛开数临界值3")]
    public int? F_StackOpenThreshold3 { get; set; }

    [SugarColumn(ColumnName = "F_UpperStackCount1", IsNullable = true, ColumnDescription = "上堆码出垛数1")]
    public int? F_UpperStackCount1 { get; set; }

    [SugarColumn(ColumnName = "F_UpperStackCount2", IsNullable = true, ColumnDescription = "上堆码出垛数2")]
    public int? F_UpperStackCount2 { get; set; }

    [SugarColumn(ColumnName = "F_UpperStackCount3", IsNullable = true, ColumnDescription = "上堆码出垛数3")]
    public int? F_UpperStackCount3 { get; set; }

    [SugarColumn(ColumnName = "F_LowerStackCount1", IsNullable = true, ColumnDescription = "下堆码出垛数1")]
    public int? F_LowerStackCount1 { get; set; }

    [SugarColumn(ColumnName = "F_LowerStackCount2", IsNullable = true, ColumnDescription = "下堆码出垛数2")]
    public int? F_LowerStackCount2 { get; set; }

    [SugarColumn(ColumnName = "F_LowerStackCount3", IsNullable = true, ColumnDescription = "下堆码出垛数3")]
    public int? F_LowerStackCount3 { get; set; }

    [SugarColumn(ColumnName = "F_SmallLine", IsNullable = true, ColumnDescription = "小压线(mm)")]
    public decimal? F_SmallLine { get; set; }

    [SugarColumn(ColumnName = "F_SmallLineDeepen", IsNullable = true, ColumnDescription = "小压线加深")]
    public decimal? F_SmallLineDeepen { get; set; }

    [SugarColumn(ColumnName = "F_PlainLineDepth", IsNullable = true, ColumnDescription = "平压线深度(丝)")]
    public decimal? F_PlainLineDepth { get; set; }

    [SugarColumn(ColumnName = "F_NormalLineDepth", IsNullable = true, ColumnDescription = "普压线深度(丝)")]
    public decimal? F_NormalLineDepth { get; set; }

    [SugarColumn(ColumnName = "F_DeepLineDepth", IsNullable = true, ColumnDescription = "深压线深度(丝)")]
    public decimal? F_DeepLineDepth { get; set; }

    [SugarColumn(ColumnName = "F_MaxSpeed", IsNullable = true, ColumnDescription = "最大车速(m/min)")]
    public decimal? F_MaxSpeed { get; set; }

    [SugarColumn(ColumnName = "F_RollerCount", IsNullable = true, ColumnDescription = "锟数数量")]
    public int? F_RollerCount { get; set; }

    [SugarColumn(ColumnName = "F_Trim", IsNullable = true, ColumnDescription = "修边(mm)")]
    public decimal? F_Trim { get; set; }

    [SugarColumn(ColumnName = "F_IsDelete", IsNullable = true)]
    public bool? F_IsDelete { get; set; }

    [SugarColumn(ColumnName = "F_Creator", Length = 50, IsNullable = true)]
    public string? F_Creator { get; set; }

    [SugarColumn(ColumnName = "F_CreateTime", IsNullable = true)]
    public DateTime? F_CreateTime { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
