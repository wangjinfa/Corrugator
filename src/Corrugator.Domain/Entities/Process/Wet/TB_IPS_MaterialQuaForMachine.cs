using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// TB_IPS_MaterialQuaForMachine
/// </summary>
[SugarTable("TB_IPS_MaterialQuaForMachine", TableDescription = "TB_IPS_MaterialQuaForMachine")]
public class TB_IPS_MaterialQuaForMachine
{
    /// <summary>F_P04TID</summary>
    [SugarColumn(ColumnName = "F_P04TID", IsNullable = true, ColumnDescription = "F_P04TID")]
    public int? F_P04TID { get; set; }

    /// <summary>ERP表ID</summary>
    [SugarColumn(ColumnName = "F_ErpTableId", ColumnDescription = "ERP表ID")]
    public long F_ErpTableId { get; set; }

    /// <summary>机位</summary>
    [SugarColumn(ColumnName = "F_MachinePsition", Length = 50, ColumnDescription = "机位")]
    public string F_MachinePsition { get; set; } = default!;

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "F_MaterialQua", Length = 50, ColumnDescription = "材质")]
    public string F_MaterialQua { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "F_Width", ColumnDescription = "门幅")]
    public int F_Width { get; set; }

    /// <summary>ERP唯一编码</summary>
    [SugarColumn(ColumnName = "F_Barcode", Length = 100, ColumnDescription = "ERP唯一编码")]
    public string F_Barcode { get; set; } = default!;

    /// <summary>开始订单ID</summary>
    [SugarColumn(ColumnName = "F_StartOrderId", ColumnDescription = "开始订单ID")]
    public int F_StartOrderId { get; set; }

    /// <summary>结束订单ID</summary>
    [SugarColumn(ColumnName = "F_EndOrderId", IsNullable = true, ColumnDescription = "结束订单ID")]
    public int? F_EndOrderId { get; set; }

    /// <summary>F_GUID</summary>
    [SugarColumn(ColumnName = "F_GUID", Length = 200, IsNullable = true, ColumnDescription = "F_GUID")]
    public string? F_GUID { get; set; }

    /// <summary>F_ErpStartRollMeters</summary>
    [SugarColumn(ColumnName = "F_ErpStartRollMeters", IsNullable = true, ColumnDescription = "F_ErpStartRollMeters")]
    public int? F_ErpStartRollMeters { get; set; }

    /// <summary>上机时同材剩余米数</summary>
    [SugarColumn(ColumnName = "F_StartSameMeters", IsNullable = true, ColumnDescription = "上机时同材剩余米数")]
    public int? F_StartSameMeters { get; set; }

    /// <summary>下机时同材剩余米数</summary>
    [SugarColumn(ColumnName = "F_EndSameMeters", IsNullable = true, ColumnDescription = "下机时同材剩余米数")]
    public int? F_EndSameMeters { get; set; }

    /// <summary>上机时纸卷米数</summary>
    [SugarColumn(ColumnName = "F_StartRollMeters", IsNullable = true, ColumnDescription = "上机时纸卷米数")]
    public int? F_StartRollMeters { get; set; }

    /// <summary>下机时纸卷米数</summary>
    [SugarColumn(ColumnName = "F_EndRollMeters", IsNullable = true, ColumnDescription = "下机时纸卷米数")]
    public int? F_EndRollMeters { get; set; }

    /// <summary>上机时间</summary>
    [SugarColumn(ColumnName = "F_StartTime", IsNullable = true, ColumnDescription = "上机时间")]
    public DateTime? F_StartTime { get; set; }

    /// <summary>F_UpdateTime</summary>
    [SugarColumn(ColumnName = "F_UpdateTime", IsNullable = true, ColumnDescription = "F_UpdateTime")]
    public DateTime? F_UpdateTime { get; set; }

    /// <summary>下机时间</summary>
    [SugarColumn(ColumnName = "F_EndTime", IsNullable = true, ColumnDescription = "下机时间")]
    public DateTime? F_EndTime { get; set; }

    /// <summary>使用米数</summary>
    [SugarColumn(ColumnName = "F_UseMeters", IsNullable = true, ColumnDescription = "使用米数")]
    public int? F_UseMeters { get; set; }

    /// <summary>F_TheoryMaterialQua</summary>
    [SugarColumn(ColumnName = "F_TheoryMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "F_TheoryMaterialQua")]
    public string? F_TheoryMaterialQua { get; set; }

    /// <summary>F_TheoryWidth</summary>
    [SugarColumn(ColumnName = "F_TheoryWidth", IsNullable = true, ColumnDescription = "F_TheoryWidth")]
    public int? F_TheoryWidth { get; set; }

    /// <summary>F_IsSameReplaceMaterialQua</summary>
    [SugarColumn(ColumnName = "F_IsSameReplaceMaterialQua", IsNullable = true, ColumnDescription = "F_IsSameReplaceMaterialQua")]
    public bool? F_IsSameReplaceMaterialQua { get; set; }

    /// <summary>F_IsRelaceMaterialQua</summary>
    [SugarColumn(ColumnName = "F_IsRelaceMaterialQua", IsNullable = true, ColumnDescription = "F_IsRelaceMaterialQua")]
    public bool? F_IsRelaceMaterialQua { get; set; }

    /// <summary>F_ID</summary>
    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "F_ID")]
    public long F_ID { get; set; }

}