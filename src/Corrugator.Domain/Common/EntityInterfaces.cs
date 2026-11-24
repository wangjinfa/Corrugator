namespace Corrugator.Domain.Common;

/// <summary>软删除标记：实现该接口的实体删除时只做逻辑删除</summary>
public interface ISoftDelete
{
    bool IsDeleted { get; set; }
}

/// <summary>审计字段：新增/修改时由仓储层自动填充</summary>
public interface IAuditable
{
    DateTime CreatedAt { get; set; }
    string? CreatedBy { get; set; }
    DateTime? UpdatedAt { get; set; }
    string? UpdatedBy { get; set; }
}

/// <summary>分布式 ID（雪花算法）标记：实现该接口的实体由仓储层生成主键</summary>
public interface IAssignableId
{
    long Id { get; set; }
}
