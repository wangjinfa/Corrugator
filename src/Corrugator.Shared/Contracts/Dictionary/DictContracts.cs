namespace Corrugator.Shared.Contracts.Dictionary;

/// <summary>数据字典类型（P_DictTypes）</summary>
public class DictTypeDto
{
    public int PD_ID { get; set; }
    public int? PD_PID { get; set; }
    public string? PD_Name { get; set; }
    public string? PD_Code { get; set; }
    public string? PD_Creator { get; set; }
    public DateTime? PD_CreateTime { get; set; }
    public string? PD_Editor { get; set; }
    public DateTime? PD_EditTime { get; set; }
}

/// <summary>字典分类新增/修改</summary>
public class DictTypeSaveRequest
{
    public int? PD_PID { get; set; }
    public string? PD_Name { get; set; }
    public string? PD_Code { get; set; }
}

/// <summary>数据字典明细（P_DictDatas）</summary>
public class DictDataDto
{
    public int PD_ID { get; set; }
    public int? PD_TypeID { get; set; }
    public string? PD_Property { get; set; }
    public string? PD_EnglishName { get; set; }
    public string? PD_Value { get; set; }
    public string? PD_ChineseName { get; set; }
    public int? PD_SortNo { get; set; }
    /// <summary>列表序号（客户端填充，不参与接口语义）</summary>
    public int RowNo { get; set; }
    public string? PD_Creator { get; set; }
    public DateTime? PD_CreateTime { get; set; }
    public string? PD_Editor { get; set; }
    public DateTime? PD_EditTime { get; set; }
}

/// <summary>字典明细新增/修改</summary>
public class DictDataSaveRequest
{
    public int PD_TypeID { get; set; }
    public string? PD_Value { get; set; }
    public string? PD_EnglishName { get; set; }
    public string? PD_ChineseName { get; set; }
    public string? PD_Property { get; set; }
    public int? PD_SortNo { get; set; }
}
