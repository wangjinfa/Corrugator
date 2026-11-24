namespace Corrugator.Shared.Contracts.Dictionary;

/// <summary>数据字典类型（W_DictTypes）</summary>
public class DictTypeDto
{
    public int WPD_ID { get; set; }
    public int? WPD_PID { get; set; }
    public string? WPD_Name { get; set; }
    public string? WPD_Code { get; set; }
    public string? WPD_Creator { get; set; }
    public DateTime? WPD_CreateTime { get; set; }
    public string? WPD_Editor { get; set; }
    public DateTime? WPD_EditTime { get; set; }
}

/// <summary>字典分类新增/修改</summary>
public class DictTypeSaveRequest
{
    public int? WPD_PID { get; set; }
    public string? WPD_Name { get; set; }
    public string? WPD_Code { get; set; }
}

/// <summary>数据字典明细（W_DictDatas）</summary>
public class DictDataDto
{
    public int WPD_ID { get; set; }
    public int? WPD_TypeID { get; set; }
    public string? WPD_Property { get; set; }
    public string? WPD_EnglishName { get; set; }
    public string? WPD_Value { get; set; }
    public string? WPD_ChineseName { get; set; }
    public int? WPD_SortNo { get; set; }
    /// <summary>列表序号（客户端填充，不参与接口语义）</summary>
    public int RowNo { get; set; }
    public string? WPD_Creator { get; set; }
    public DateTime? WPD_CreateTime { get; set; }
    public string? WPD_Editor { get; set; }
    public DateTime? WPD_EditTime { get; set; }
}

/// <summary>字典明细新增/修改</summary>
public class DictDataSaveRequest
{
    public int WPD_TypeID { get; set; }
    public string? WPD_Value { get; set; }
    public string? WPD_EnglishName { get; set; }
    public string? WPD_ChineseName { get; set; }
    public string? WPD_Property { get; set; }
    public int? WPD_SortNo { get; set; }
}
