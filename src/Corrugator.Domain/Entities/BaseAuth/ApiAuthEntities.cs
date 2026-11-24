using SqlSugar;

namespace Corrugator.Domain.Entities.BaseAuth;

/// <summary>对外接口调用账号 W_ApiUsers（基础信息 → API授权 左表）</summary>
[SugarTable("W_ApiUsers", TableDescription = "对外接口调用账号")]
public class S_ApiUser
{
    [SugarColumn(ColumnName = "WF_Account", Length = 50, ColumnDescription = "账号")]
    public string WF_Account { get; set; } = default!;

    [SugarColumn(ColumnName = "WF_Secret", Length = 50, IsNullable = true, ColumnDescription = "秘钥")]
    public string? WF_Secret { get; set; }

    [SugarColumn(ColumnName = "WF_SystemName", Length = 100, IsNullable = true, ColumnDescription = "系统名称")]
    public string? WF_SystemName { get; set; }

    [SugarColumn(ColumnName = "WF_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? WF_IsUse { get; set; }

    [SugarColumn(ColumnName = "WF_IsDelete", ColumnDescription = "是否删除")]
    public bool WF_IsDelete { get; set; }

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

/// <summary>对外接口清单 W_Apis（基础信息 → API授权 右表）</summary>
[SugarTable("W_Apis", TableDescription = "对外接口清单")]
public class S_Api
{
    [SugarColumn(ColumnName = "WF_Desc", Length = 100, IsNullable = true, ColumnDescription = "接口说明")]
    public string? WF_Desc { get; set; }

    [SugarColumn(ColumnName = "WF_Url", Length = 200, IsNullable = true, ColumnDescription = "Url路径")]
    public string? WF_Url { get; set; }

    [SugarColumn(ColumnName = "WF_SystemName", Length = 100, IsNullable = true, ColumnDescription = "系统名称")]
    public string? WF_SystemName { get; set; }

    [SugarColumn(ColumnName = "WF_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? WF_IsUse { get; set; }

    [SugarColumn(ColumnName = "WF_IsDelete", ColumnDescription = "是否删除")]
    public bool WF_IsDelete { get; set; }

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

/// <summary>账号到接口的授权关系 W_ApiAuthorizes</summary>
[SugarTable("W_ApiAuthorizes", TableDescription = "API授权关系")]
public class S_ApiAuthorize
{
    [SugarColumn(ColumnName = "WF_ApiUserId", ColumnDescription = "账号ID")]
    public long WF_ApiUserId { get; set; }

    [SugarColumn(ColumnName = "WF_ApiId", ColumnDescription = "接口ID")]
    public long WF_ApiId { get; set; }

    [SugarColumn(ColumnName = "WF_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? WF_IsUse { get; set; }

    [SugarColumn(ColumnName = "WF_Editor", Length = 50, IsNullable = true)]
    public string? WF_Editor { get; set; }

    [SugarColumn(ColumnName = "WF_EditTime", IsNullable = true)]
    public DateTime? WF_EditTime { get; set; }

    [SugarColumn(ColumnName = "WF_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long WF_ID { get; set; }
}
