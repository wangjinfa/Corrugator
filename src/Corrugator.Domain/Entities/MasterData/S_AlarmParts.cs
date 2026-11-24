using SqlSugar;

namespace Corrugator.Domain.Entities.MasterData;

/// <summary>
/// 预警部位
/// </summary>
[SugarTable("W_AlarmParts", TableDescription = "预警部位")]
public class W_AlarmParts
{
    /// <summary>部位代码</summary>
    [SugarColumn(ColumnName = "WSA_Code", Length = 20, ColumnDescription = "部位代码")]
    public string WSA_Code { get; set; } = default!;

    /// <summary>部位名称</summary>
    [SugarColumn(ColumnName = "WSA_Name", Length = 50, IsNullable = true, ColumnDescription = "部位名称")]
    public string? WSA_Name { get; set; }

    /// <summary>机台IP地址(e.g 127.0.0.1:8089)</summary>
    [SugarColumn(ColumnName = "WSA_IPAddress", Length = 50, IsNullable = true, ColumnDescription = "机台IP地址(e.g 127.0.0.1:8089)")]
    public string? WSA_IPAddress { get; set; }

    /// <summary>手表ID</summary>
    [SugarColumn(ColumnName = "WSA_PhoneID", IsNullable = true, ColumnDescription = "手表ID")]
    public string? WSA_PhoneID { get; set; }

    /// <summary>组号</summary>
    [SugarColumn(ColumnName = "WSA_PhoneGroup", Length = 100, IsNullable = true, ColumnDescription = "组号")]
    public string? WSA_PhoneGroup { get; set; }

    /// <summary>WSA_ID</summary>
    [SugarColumn(ColumnName = "WSA_ID", IsPrimaryKey = true, IsIdentity = true, ColumnDescription = "WSA_ID")]
    public int WSA_ID { get; set; }

}