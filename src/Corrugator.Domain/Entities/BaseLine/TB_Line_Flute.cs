using SqlSugar;

namespace Corrugator.Domain.Entities.BaseLine;

/// <summary>
/// 产线楞型（基础信息 → 产线楞型）。门幅 + 楞型唯一，决定厚度、切长、修边、堆码与压线参数。
/// </summary>
[SugarTable("W_Line_Flute", TableDescription = "产线楞型")]
public class W_Line_Flute
{
    [SugarColumn(ColumnName = "WF_DoorWidth", ColumnDescription = "门幅(mm)")]
    public decimal WF_DoorWidth { get; set; }

    [SugarColumn(ColumnName = "WF_FluteType", Length = 20, ColumnDescription = "楞型")]
    public string WF_FluteType { get; set; } = default!;

    [SugarColumn(ColumnName = "WF_Thickness", IsNullable = true, ColumnDescription = "厚度(mm)")]
    public decimal? WF_Thickness { get; set; }

    [SugarColumn(ColumnName = "WF_Thickness1", IsNullable = true, ColumnDescription = "厚度1(mm)")]
    public decimal? WF_Thickness1 { get; set; }

    [SugarColumn(ColumnName = "WF_Thickness2", IsNullable = true, ColumnDescription = "厚度2(mm)")]
    public decimal? WF_Thickness2 { get; set; }

    [SugarColumn(ColumnName = "WF_Thickness3", IsNullable = true, ColumnDescription = "厚度3(mm)")]
    public decimal? WF_Thickness3 { get; set; }

    [SugarColumn(ColumnName = "WF_WeightThreshold1", IsNullable = true, ColumnDescription = "纸板克重临界值1")]
    public decimal? WF_WeightThreshold1 { get; set; }

    [SugarColumn(ColumnName = "WF_WeightThreshold2", IsNullable = true, ColumnDescription = "纸板克重临界值2")]
    public decimal? WF_WeightThreshold2 { get; set; }

    [SugarColumn(ColumnName = "WF_WeightThreshold3", IsNullable = true, ColumnDescription = "纸板克重临界值3")]
    public decimal? WF_WeightThreshold3 { get; set; }

    [SugarColumn(ColumnName = "WF_MaxSlit", IsNullable = true, ColumnDescription = "最大剖数")]
    public int? WF_MaxSlit { get; set; }

    [SugarColumn(ColumnName = "WF_MinCutLength", IsNullable = true, ColumnDescription = "最小切长(mm)")]
    public decimal? WF_MinCutLength { get; set; }

    [SugarColumn(ColumnName = "WF_MaxCutLength", IsNullable = true, ColumnDescription = "最大切长(mm)")]
    public decimal? WF_MaxCutLength { get; set; }

    [SugarColumn(ColumnName = "WF_MinTrim", IsNullable = true, ColumnDescription = "最小修边(mm)")]
    public decimal? WF_MinTrim { get; set; }

    [SugarColumn(ColumnName = "WF_MaxTrim", IsNullable = true, ColumnDescription = "最大修边(mm)")]
    public decimal? WF_MaxTrim { get; set; }

    [SugarColumn(ColumnName = "WF_UpperStackLimit", IsNullable = true, ColumnDescription = "上堆码限高(mm)")]
    public decimal? WF_UpperStackLimit { get; set; }

    [SugarColumn(ColumnName = "WF_LowerStackLimit", IsNullable = true, ColumnDescription = "下堆码限高(mm)")]
    public decimal? WF_LowerStackLimit { get; set; }

    [SugarColumn(ColumnName = "WF_StackOpenThreshold1", IsNullable = true, ColumnDescription = "出垛开数临界值1")]
    public int? WF_StackOpenThreshold1 { get; set; }

    [SugarColumn(ColumnName = "WF_StackOpenThreshold2", IsNullable = true, ColumnDescription = "出垛开数临界值2")]
    public int? WF_StackOpenThreshold2 { get; set; }

    [SugarColumn(ColumnName = "WF_StackOpenThreshold3", IsNullable = true, ColumnDescription = "出垛开数临界值3")]
    public int? WF_StackOpenThreshold3 { get; set; }

    [SugarColumn(ColumnName = "WF_UpperStackCount1", IsNullable = true, ColumnDescription = "上堆码出垛数1")]
    public int? WF_UpperStackCount1 { get; set; }

    [SugarColumn(ColumnName = "WF_UpperStackCount2", IsNullable = true, ColumnDescription = "上堆码出垛数2")]
    public int? WF_UpperStackCount2 { get; set; }

    [SugarColumn(ColumnName = "WF_UpperStackCount3", IsNullable = true, ColumnDescription = "上堆码出垛数3")]
    public int? WF_UpperStackCount3 { get; set; }

    [SugarColumn(ColumnName = "WF_LowerStackCount1", IsNullable = true, ColumnDescription = "下堆码出垛数1")]
    public int? WF_LowerStackCount1 { get; set; }

    [SugarColumn(ColumnName = "WF_LowerStackCount2", IsNullable = true, ColumnDescription = "下堆码出垛数2")]
    public int? WF_LowerStackCount2 { get; set; }

    [SugarColumn(ColumnName = "WF_LowerStackCount3", IsNullable = true, ColumnDescription = "下堆码出垛数3")]
    public int? WF_LowerStackCount3 { get; set; }

    [SugarColumn(ColumnName = "WF_SmallLine", IsNullable = true, ColumnDescription = "小压线(mm)")]
    public decimal? WF_SmallLine { get; set; }

    [SugarColumn(ColumnName = "WF_SmallLineDeepen", IsNullable = true, ColumnDescription = "小压线加深")]
    public decimal? WF_SmallLineDeepen { get; set; }

    [SugarColumn(ColumnName = "WF_PlainLineDepth", IsNullable = true, ColumnDescription = "平压线深度(丝)")]
    public decimal? WF_PlainLineDepth { get; set; }

    [SugarColumn(ColumnName = "WF_NormalLineDepth", IsNullable = true, ColumnDescription = "普压线深度(丝)")]
    public decimal? WF_NormalLineDepth { get; set; }

    [SugarColumn(ColumnName = "WF_DeepLineDepth", IsNullable = true, ColumnDescription = "深压线深度(丝)")]
    public decimal? WF_DeepLineDepth { get; set; }

    [SugarColumn(ColumnName = "WF_MaxSpeed", IsNullable = true, ColumnDescription = "最大车速(m/min)")]
    public decimal? WF_MaxSpeed { get; set; }

    [SugarColumn(ColumnName = "WF_RollerCount", IsNullable = true, ColumnDescription = "锟数数量")]
    public int? WF_RollerCount { get; set; }

    [SugarColumn(ColumnName = "WF_Trim", IsNullable = true, ColumnDescription = "修边(mm)")]
    public decimal? WF_Trim { get; set; }

    [SugarColumn(ColumnName = "WF_IsDelete", IsNullable = true)]
    public bool? WF_IsDelete { get; set; }

    [SugarColumn(ColumnName = "WF_Creator", Length = 50, IsNullable = true)]
    public string? WF_Creator { get; set; }

    [SugarColumn(ColumnName = "WF_CreateTime", IsNullable = true)]
    public DateTime? WF_CreateTime { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
