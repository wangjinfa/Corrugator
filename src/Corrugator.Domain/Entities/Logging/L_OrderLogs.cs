using SqlSugar;

namespace Corrugator.Domain.Entities.Logging;

/// <summary>
/// 订单修改日志表
/// </summary>
[SugarTable("L_OrderLogs", TableDescription = "订单修改日志表")]
public class L_OrderLogs
{
    /// <summary>ERP订单表Guid</summary>
    [SugarColumn(ColumnName = "WEO_Guid", Length = 50, IsNullable = true, ColumnDescription = "ERP订单表Guid")]
    public string? WEO_Guid { get; set; }

    /// <summary>未完工订单表ID</summary>
    [SugarColumn(ColumnName = "WO_ID", ColumnDescription = "未完工订单表ID")]
    public int WO_ID { get; set; }

    /// <summary>操作日期</summary>
    [SugarColumn(ColumnName = "LOL_Time", ColumnDescription = "操作日期")]
    public DateTime LOL_Time { get; set; }

    /// <summary>操作用户</summary>
    [SugarColumn(ColumnName = "LOL_UserName", Length = 50, ColumnDescription = "操作用户")]
    public string LOL_UserName { get; set; } = default!;

    /// <summary>操作电脑IP</summary>
    [SugarColumn(ColumnName = "LOL_MachineIp", Length = 50, ColumnDescription = "操作电脑IP")]
    public string LOL_MachineIp { get; set; } = default!;

    /// <summary>操作电脑名称</summary>
    [SugarColumn(ColumnName = "LOL_MachineName", Length = 50, ColumnDescription = "操作电脑名称")]
    public string LOL_MachineName { get; set; } = default!;

    /// <summary>操作日志信息</summary>
    [SugarColumn(ColumnName = "LOL_Content", Length = 100, ColumnDescription = "操作日志信息")]
    public string LOL_Content { get; set; } = default!;

    /// <summary>班组</summary>
    [SugarColumn(ColumnName = "LOL_ClassNo", Length = 50, IsNullable = true, ColumnDescription = "班组")]
    public string? LOL_ClassNo { get; set; }

    /// <summary>工号</summary>
    [SugarColumn(ColumnName = "LOL_WorkNo", ColumnDescription = "工号")]
    public int LOL_WorkNo { get; set; }

    /// <summary>原工号</summary>
    [SugarColumn(ColumnName = "LOL_WorkNo_O", Length = 50, IsNullable = true, ColumnDescription = "原工号")]
    public string? LOL_WorkNo_O { get; set; }

    /// <summary>材质</summary>
    [SugarColumn(ColumnName = "LOL_PaperCode", Length = 50, ColumnDescription = "材质")]
    public string LOL_PaperCode { get; set; } = default!;

    /// <summary>原材质</summary>
    [SugarColumn(ColumnName = "LOL_PaperCode_O", Length = 50, IsNullable = true, ColumnDescription = "原材质")]
    public string? LOL_PaperCode_O { get; set; }

    /// <summary>楞型</summary>
    [SugarColumn(ColumnName = "LOL_Wave", Length = 50, ColumnDescription = "楞型")]
    public string LOL_Wave { get; set; } = default!;

    /// <summary>原楞型</summary>
    [SugarColumn(ColumnName = "LOL_Wave_O", Length = 50, IsNullable = true, ColumnDescription = "原楞型")]
    public string? LOL_Wave_O { get; set; }

    /// <summary>门幅mm</summary>
    [SugarColumn(ColumnName = "LOL_Width", ColumnDescription = "门幅mm")]
    public int LOL_Width { get; set; }

    /// <summary>原门幅mm</summary>
    [SugarColumn(ColumnName = "LOL_Width_O", Length = 50, IsNullable = true, ColumnDescription = "原门幅mm")]
    public string? LOL_Width_O { get; set; }

    /// <summary>修边</summary>
    [SugarColumn(ColumnName = "LOL_Trim", ColumnDescription = "修边")]
    public int LOL_Trim { get; set; }

    /// <summary>原修边</summary>
    [SugarColumn(ColumnName = "LOL_Trim_O", Length = 50, IsNullable = true, ColumnDescription = "原修边")]
    public string? LOL_Trim_O { get; set; }

    /// <summary>修边面积</summary>
    [SugarColumn(ColumnName = "LOL_TrimArea", Length = 18, DecimalDigits = 4, ColumnDescription = "修边面积")]
    public decimal LOL_TrimArea { get; set; }

    /// <summary>原修边面积</summary>
    [SugarColumn(ColumnName = "LOL_TrimArea_O", Length = 50, IsNullable = true, ColumnDescription = "原修边面积")]
    public string? LOL_TrimArea_O { get; set; }

    /// <summary>上刀客户名称</summary>
    [SugarColumn(ColumnName = "LOL_CustName", Length = 50, ColumnDescription = "上刀客户名称")]
    public string LOL_CustName { get; set; } = default!;

    /// <summary>上刀订单号</summary>
    [SugarColumn(ColumnName = "LOL_OrderNo", Length = 50, ColumnDescription = "上刀订单号")]
    public string LOL_OrderNo { get; set; } = default!;

    /// <summary>上刀切宽</summary>
    [SugarColumn(ColumnName = "LOL_CutWidth", ColumnDescription = "上刀切宽")]
    public int LOL_CutWidth { get; set; }

    /// <summary>原上刀切宽</summary>
    [SugarColumn(ColumnName = "LOL_CutWidth_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀切宽")]
    public string? LOL_CutWidth_O { get; set; }

    /// <summary>上刀切长</summary>
    [SugarColumn(ColumnName = "LOL_CutLength", ColumnDescription = "上刀切长")]
    public int LOL_CutLength { get; set; }

    /// <summary>原上刀切长</summary>
    [SugarColumn(ColumnName = "LOL_CutLength_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀切长")]
    public string? LOL_CutLength_O { get; set; }

    /// <summary>上刀切数</summary>
    [SugarColumn(ColumnName = "LOL_CutQty", ColumnDescription = "上刀切数")]
    public int LOL_CutQty { get; set; }

    /// <summary>原上刀切数</summary>
    [SugarColumn(ColumnName = "LOL_CutQty_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀切数")]
    public string? LOL_CutQty_O { get; set; }

    /// <summary>上刀剖数</summary>
    [SugarColumn(ColumnName = "LOL_CN", ColumnDescription = "上刀剖数")]
    public int LOL_CN { get; set; }

    /// <summary>原上刀剖数</summary>
    [SugarColumn(ColumnName = "LOL_CN_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀剖数")]
    public string? LOL_CN_O { get; set; }

    /// <summary>上刀张数</summary>
    [SugarColumn(ColumnName = "LOL_SheetQty", ColumnDescription = "上刀张数")]
    public int LOL_SheetQty { get; set; }

    /// <summary>原上刀张数</summary>
    [SugarColumn(ColumnName = "LOL_SheetQty_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀张数")]
    public string? LOL_SheetQty_O { get; set; }

    /// <summary>上刀压型</summary>
    [SugarColumn(ColumnName = "LOL_ScorType", Length = 10, ColumnDescription = "上刀压型")]
    public string LOL_ScorType { get; set; } = default!;

    /// <summary>原上刀压型</summary>
    [SugarColumn(ColumnName = "LOL_ScorType_O", Length = 10, IsNullable = true, ColumnDescription = "原上刀压型")]
    public string? LOL_ScorType_O { get; set; }

    /// <summary>上刀压线</summary>
    [SugarColumn(ColumnName = "LOL_Scor", Length = 100, ColumnDescription = "上刀压线")]
    public string LOL_Scor { get; set; } = default!;

    /// <summary>原上刀压线</summary>
    [SugarColumn(ColumnName = "LOL_Scor_O", Length = 100, IsNullable = true, ColumnDescription = "原上刀压线")]
    public string? LOL_Scor_O { get; set; }

    /// <summary>上刀平方</summary>
    [SugarColumn(ColumnName = "LOL_Area", Length = 18, DecimalDigits = 4, ColumnDescription = "上刀平方")]
    public decimal LOL_Area { get; set; }

    /// <summary>原上刀平方</summary>
    [SugarColumn(ColumnName = "LOL_Area_O", Length = 50, IsNullable = true, ColumnDescription = "原上刀平方")]
    public string? LOL_Area_O { get; set; }

    /// <summary>上刀生产备注</summary>
    [SugarColumn(ColumnName = "LOL_Remark", Length = 500, IsNullable = true, ColumnDescription = "上刀生产备注")]
    public string? LOL_Remark { get; set; }

    /// <summary>下刀客户名称</summary>
    [SugarColumn(ColumnName = "LOL_CustName_D", Length = 50, IsNullable = true, ColumnDescription = "下刀客户名称")]
    public string? LOL_CustName_D { get; set; }

    /// <summary>下刀订单号</summary>
    [SugarColumn(ColumnName = "LOL_OrderNo_D", Length = 50, IsNullable = true, ColumnDescription = "下刀订单号")]
    public string? LOL_OrderNo_D { get; set; }

    /// <summary>下刀切宽</summary>
    [SugarColumn(ColumnName = "LOL_CutWidth_D", IsNullable = true, ColumnDescription = "下刀切宽")]
    public int? LOL_CutWidth_D { get; set; }

    /// <summary>原下刀切宽</summary>
    [SugarColumn(ColumnName = "LOL_CutWidth_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀切宽")]
    public string? LOL_CutWidth_D_O { get; set; }

    /// <summary>下刀切长</summary>
    [SugarColumn(ColumnName = "LOL_CutLength_D", IsNullable = true, ColumnDescription = "下刀切长")]
    public int? LOL_CutLength_D { get; set; }

    /// <summary>原下刀切长</summary>
    [SugarColumn(ColumnName = "LOL_CutLength_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀切长")]
    public string? LOL_CutLength_D_O { get; set; }

    /// <summary>下刀切数</summary>
    [SugarColumn(ColumnName = "LOL_CutQty_D", IsNullable = true, ColumnDescription = "下刀切数")]
    public int? LOL_CutQty_D { get; set; }

    /// <summary>原下刀切数</summary>
    [SugarColumn(ColumnName = "LOL_CutQty_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀切数")]
    public string? LOL_CutQty_D_O { get; set; }

    /// <summary>下刀剖数</summary>
    [SugarColumn(ColumnName = "LOL_CN_D", IsNullable = true, ColumnDescription = "下刀剖数")]
    public int? LOL_CN_D { get; set; }

    /// <summary>原下刀剖数</summary>
    [SugarColumn(ColumnName = "LOL_CN_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀剖数")]
    public string? LOL_CN_D_O { get; set; }

    /// <summary>下刀张数</summary>
    [SugarColumn(ColumnName = "LOL_SheetQty_D", IsNullable = true, ColumnDescription = "下刀张数")]
    public int? LOL_SheetQty_D { get; set; }

    /// <summary>原下刀张数</summary>
    [SugarColumn(ColumnName = "LOL_SheetQty_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀张数")]
    public string? LOL_SheetQty_D_O { get; set; }

    /// <summary>下刀压型</summary>
    [SugarColumn(ColumnName = "LOL_ScorType_D", Length = 10, IsNullable = true, ColumnDescription = "下刀压型")]
    public string? LOL_ScorType_D { get; set; }

    /// <summary>原下刀压型</summary>
    [SugarColumn(ColumnName = "LOL_ScorType_D_O", Length = 10, IsNullable = true, ColumnDescription = "原下刀压型")]
    public string? LOL_ScorType_D_O { get; set; }

    /// <summary>下刀压线</summary>
    [SugarColumn(ColumnName = "LOL_Scor_D", Length = 100, IsNullable = true, ColumnDescription = "下刀压线")]
    public string? LOL_Scor_D { get; set; }

    /// <summary>原下刀压线</summary>
    [SugarColumn(ColumnName = "LOL_Scor_D_O", Length = 100, IsNullable = true, ColumnDescription = "原下刀压线")]
    public string? LOL_Scor_D_O { get; set; }

    /// <summary>下刀平方</summary>
    [SugarColumn(ColumnName = "LOL_Area_D", Length = 18, DecimalDigits = 4, IsNullable = true, ColumnDescription = "下刀平方")]
    public decimal? LOL_Area_D { get; set; }

    /// <summary>原下刀平方</summary>
    [SugarColumn(ColumnName = "LOL_Area_D_O", Length = 50, IsNullable = true, ColumnDescription = "原下刀平方")]
    public string? LOL_Area_D_O { get; set; }

    /// <summary>下刀生产备注</summary>
    [SugarColumn(ColumnName = "LOL_Remark_D", Length = 500, IsNullable = true, ColumnDescription = "下刀生产备注")]
    public string? LOL_Remark_D { get; set; }

    /// <summary>LOL_UpdateReason</summary>
    [SugarColumn(ColumnName = "LOL_UpdateReason", Length = 500, IsNullable = true, ColumnDescription = "LOL_UpdateReason")]
    public string? LOL_UpdateReason { get; set; }

    /// <summary>LOL_ID</summary>
    [SugarColumn(ColumnName = "LOL_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "LOL_ID")]
    public int LOL_ID { get; set; }

}