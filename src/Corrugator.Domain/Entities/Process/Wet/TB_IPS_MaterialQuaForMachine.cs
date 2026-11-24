using SqlSugar;

namespace Corrugator.Domain.Entities.Process.Wet;

/// <summary>
/// W_IPS_MaterialQuaForMachine
/// </summary>
[SugarTable("W_IPS_MaterialQuaForMachine", TableDescription = "W_IPS_MaterialQuaForMachine")]
public class W_IPS_MaterialQuaForMachine
{
    /// <summary>WF_P04TID</summary>
    [SugarColumn(ColumnName = "WF_P04TID", IsNullable = true, ColumnDescription = "WF_P04TID")]
    public int? WF_P04TID { get; set; }

    /// <summary>ERP表ID</summary>
    [SugarColumn(ColumnName = "WF_ErpTableId", ColumnDescription = "ERP表ID")]
    public long WF_ErpTableId { get; set; }

    /// <summary>机位</summary>
    [SugarColumn(ColumnName = "WF_MachinePsition", Length = 50, ColumnDescription = "机位")]
    public string WF_MachinePsition { get; set; } = default!;

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "WF_MaterialQua", Length = 50, ColumnDescription = "材质")]
    public string WF_MaterialQua { get; set; } = default!;

    /// <summary>门幅</summary>
    [SugarColumn(ColumnName = "WF_Width", ColumnDescription = "门幅")]
    public int WF_Width { get; set; }

    /// <summary>ERP唯一编码</summary>
    [SugarColumn(ColumnName = "WF_Barcode", Length = 100, ColumnDescription = "ERP唯一编码")]
    public string WF_Barcode { get; set; } = default!;

    /// <summary>开始订单ID</summary>
    [SugarColumn(ColumnName = "WF_StartOrderId", ColumnDescription = "开始订单ID")]
    public int WF_StartOrderId { get; set; }

    /// <summary>结束订单ID</summary>
    [SugarColumn(ColumnName = "WF_EndOrderId", IsNullable = true, ColumnDescription = "结束订单ID")]
    public int? WF_EndOrderId { get; set; }

    /// <summary>WF_GUID</summary>
    [SugarColumn(ColumnName = "WF_GUID", Length = 200, IsNullable = true, ColumnDescription = "WF_GUID")]
    public string? WF_GUID { get; set; }

    /// <summary>WF_ErpStartRollMeters</summary>
    [SugarColumn(ColumnName = "WF_ErpStartRollMeters", IsNullable = true, ColumnDescription = "WF_ErpStartRollMeters")]
    public int? WF_ErpStartRollMeters { get; set; }

    /// <summary>上机时同材剩余米数</summary>
    [SugarColumn(ColumnName = "WF_StartSameMeters", IsNullable = true, ColumnDescription = "上机时同材剩余米数")]
    public int? WF_StartSameMeters { get; set; }

    /// <summary>下机时同材剩余米数</summary>
    [SugarColumn(ColumnName = "WF_EndSameMeters", IsNullable = true, ColumnDescription = "下机时同材剩余米数")]
    public int? WF_EndSameMeters { get; set; }

    /// <summary>上机时纸卷米数</summary>
    [SugarColumn(ColumnName = "WF_StartRollMeters", IsNullable = true, ColumnDescription = "上机时纸卷米数")]
    public int? WF_StartRollMeters { get; set; }

    /// <summary>下机时纸卷米数</summary>
    [SugarColumn(ColumnName = "WF_EndRollMeters", IsNullable = true, ColumnDescription = "下机时纸卷米数")]
    public int? WF_EndRollMeters { get; set; }

    /// <summary>上机时间</summary>
    [SugarColumn(ColumnName = "WF_StartTime", IsNullable = true, ColumnDescription = "上机时间")]
    public DateTime? WF_StartTime { get; set; }

    /// <summary>WF_UpdateTime</summary>
    [SugarColumn(ColumnName = "WF_UpdateTime", IsNullable = true, ColumnDescription = "WF_UpdateTime")]
    public DateTime? WF_UpdateTime { get; set; }

    /// <summary>下机时间</summary>
    [SugarColumn(ColumnName = "WF_EndTime", IsNullable = true, ColumnDescription = "下机时间")]
    public DateTime? WF_EndTime { get; set; }

    /// <summary>使用米数</summary>
    [SugarColumn(ColumnName = "WF_UseMeters", IsNullable = true, ColumnDescription = "使用米数")]
    public int? WF_UseMeters { get; set; }

    /// <summary>WF_TheoryMaterialQua</summary>
    [SugarColumn(ColumnName = "WF_TheoryMaterialQua", Length = 50, IsNullable = true, ColumnDescription = "WF_TheoryMaterialQua")]
    public string? WF_TheoryMaterialQua { get; set; }

    /// <summary>WF_TheoryWidth</summary>
    [SugarColumn(ColumnName = "WF_TheoryWidth", IsNullable = true, ColumnDescription = "WF_TheoryWidth")]
    public int? WF_TheoryWidth { get; set; }

    /// <summary>WF_IsSameReplaceMaterialQua</summary>
    [SugarColumn(ColumnName = "WF_IsSameReplaceMaterialQua", IsNullable = true, ColumnDescription = "WF_IsSameReplaceMaterialQua")]
    public bool? WF_IsSameReplaceMaterialQua { get; set; }

    /// <summary>WF_IsRelaceMaterialQua</summary>
    [SugarColumn(ColumnName = "WF_IsRelaceMaterialQua", IsNullable = true, ColumnDescription = "WF_IsRelaceMaterialQua")]
    public bool? WF_IsRelaceMaterialQua { get; set; }

    /// <summary>WF_ID</summary>
    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WF_ID")]
    public long WF_ID { get; set; }

}