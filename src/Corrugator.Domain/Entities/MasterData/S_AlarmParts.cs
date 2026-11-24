using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警部位
/// </summary>
[SugarTable("S_AlarmParts", TableDescription = "预警部位")]
public class S_AlarmParts
{
    /// <summary>部位代码</summary>
    [SugarColumn(ColumnName = "SA_Code", Length = 20, ColumnDescription = "部位代码")]
    public string SA_Code { get; set; } = default!;

    /// <summary>部位名称</summary>
    [SugarColumn(ColumnName = "SA_Name", Length = 50, IsNullable = true, ColumnDescription = "部位名称")]
    public string? SA_Name { get; set; }

    /// <summary>机台IP地址(e.g 127.0.0.1:8089)</summary>
    [SugarColumn(ColumnName = "SA_IPAddress", Length = 50, IsNullable = true, ColumnDescription = "机台IP地址(e.g 127.0.0.1:8089)")]
    public string? SA_IPAddress { get; set; }

    /// <summary>手表ID</summary>
    [SugarColumn(ColumnName = "SA_PhoneID", IsNullable = true, ColumnDescription = "手表ID")]
    public string? SA_PhoneID { get; set; }

    /// <summary>组号</summary>
    [SugarColumn(ColumnName = "SA_PhoneGroup", Length = 100, IsNullable = true, ColumnDescription = "组号")]
    public string? SA_PhoneGroup { get; set; }

    /// <summary>SA_ID</summary>
    [SugarColumn(ColumnName = "SA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "SA_ID")]
    public int SA_ID { get; set; }

}