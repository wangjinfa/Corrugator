using SqlSugar;

namespace Corrugator.Domain.Entities.BaseAuth;

/// <summary>对外接口调用账号 S_ApiUsers（基础信息 → API授权 左表）</summary>
[SugarTable("S_ApiUsers", TableDescription = "对外接口调用账号")]
public class S_ApiUser
{
    [SugarColumn(ColumnName = "F_Account", Length = 50, ColumnDescription = "账号")]
    public string F_Account { get; set; } = default!;

    [SugarColumn(ColumnName = "F_Secret", Length = 50, IsNullable = true, ColumnDescription = "秘钥")]
    public string? F_Secret { get; set; }

    [SugarColumn(ColumnName = "F_SystemName", Length = 100, IsNullable = true, ColumnDescription = "系统名称")]
    public string? F_SystemName { get; set; }

    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? F_IsUse { get; set; }

    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

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

/// <summary>对外接口清单 S_Apis（基础信息 → API授权 右表）</summary>
[SugarTable("S_Apis", TableDescription = "对外接口清单")]
public class S_Api
{
    [SugarColumn(ColumnName = "F_Desc", Length = 100, IsNullable = true, ColumnDescription = "接口说明")]
    public string? F_Desc { get; set; }

    [SugarColumn(ColumnName = "F_Url", Length = 200, IsNullable = true, ColumnDescription = "Url路径")]
    public string? F_Url { get; set; }

    [SugarColumn(ColumnName = "F_SystemName", Length = 100, IsNullable = true, ColumnDescription = "系统名称")]
    public string? F_SystemName { get; set; }

    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? F_IsUse { get; set; }

    [SugarColumn(ColumnName = "F_IsDelete", ColumnDescription = "是否删除")]
    public bool F_IsDelete { get; set; }

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

/// <summary>账号到接口的授权关系 S_ApiAuthorizes</summary>
[SugarTable("S_ApiAuthorizes", TableDescription = "API授权关系")]
public class S_ApiAuthorize
{
    [SugarColumn(ColumnName = "F_ApiUserId", ColumnDescription = "账号ID")]
    public long F_ApiUserId { get; set; }

    [SugarColumn(ColumnName = "F_ApiId", ColumnDescription = "接口ID")]
    public long F_ApiId { get; set; }

    [SugarColumn(ColumnName = "F_IsUse", IsNullable = true, ColumnDescription = "启用")]
    public bool? F_IsUse { get; set; }

    [SugarColumn(ColumnName = "F_Editor", Length = 50, IsNullable = true)]
    public string? F_Editor { get; set; }

    [SugarColumn(ColumnName = "F_EditTime", IsNullable = true)]
    public DateTime? F_EditTime { get; set; }

    [SugarColumn(ColumnName = "F_ID", IsPrimaryKey = true, IsIdentity = true)]
    public long F_ID { get; set; }
}
