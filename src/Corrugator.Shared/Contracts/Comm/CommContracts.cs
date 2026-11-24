namespace Corrugator.Shared.Contracts.Comm;

/// <summary>通讯配置（TB_Plc_DriverConfig）</summary>
public class CommConfigDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public string? ParCode { get; set; }
    public string? ParValue { get; set; }
    public bool IsDelete { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
    /// <summary>勾选状态（客户端填充，用于批量删除）</summary>
    public bool IsChecked { get; set; }
}

/// <summary>通讯配置新增/修改</summary>
public class CommConfigSaveRequest
{
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public string? ParCode { get; set; }
    public string? ParValue { get; set; }
    public bool IsDelete { get; set; }
}

/// <summary>通讯设备（TB_Plc_Device）</summary>
public class CommDeviceDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    /// <summary>通讯类型（协议驱动）</summary>
    public string? CommType { get; set; }
    /// <summary>通讯配置（配置名称）</summary>
    public string? ConfigName { get; set; }
    public bool IsUse { get; set; }
    public bool IsDelete { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
    /// <summary>勾选状态（客户端填充，用于批量删除）</summary>
    public bool IsChecked { get; set; }
}

/// <summary>通讯设备新增/修改</summary>
public class CommDeviceSaveRequest
{
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? CommType { get; set; }
    public string? ConfigName { get; set; }
    public bool IsUse { get; set; }
    public bool IsDelete { get; set; }
}

/// <summary>通讯配置下拉项（通讯设备页「通讯配置」用）</summary>
public class CommConfigOption
{
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
}

/// <summary>通讯点位变量（TB_Plc_PointVar）</summary>
public class CommPointDto
{
    public long Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Desc { get; set; }
    /// <summary>部位（双面机/单面机1…）</summary>
    public string? Position { get; set; }
    /// <summary>所属设备（设备名称/编码）</summary>
    public string? DriverCode { get; set; }
    /// <summary>PLC 地址 / MDI 变量名</summary>
    public string? VarAddress { get; set; }
    public string? DataType { get; set; }
    /// <summary>可读可写：ReadOnly / ReadWrite / WriteOnly</summary>
    public string RW { get; set; } = "ReadWrite";
    /// <summary>读取间隔（毫秒）</summary>
    public int Interval { get; set; }
    public int Priority { get; set; }
    public bool IsUse { get; set; }
    public string? CurValue { get; set; }
    public bool IsAlarm { get; set; }
    public int AlarmInterval { get; set; }
    public decimal AlarmOffset { get; set; }
    public string? DataOkAddress { get; set; }
    public string? DataOkDataType { get; set; }
    public string? TransferKeyAddress { get; set; }
    public string? TransferKeyDataType { get; set; }
    public string? Creator { get; set; }
    public DateTime? CreateTime { get; set; }
    public string? Editor { get; set; }
    public DateTime? EditTime { get; set; }
    public bool IsDelete { get; set; }
    public bool IsChecked { get; set; }
}

/// <summary>通讯点位变量新增/修改</summary>
public class CommPointSaveRequest
{
    public string Code { get; set; } = string.Empty;
    public string? Name { get; set; }
    public string? Desc { get; set; }
    public string? Position { get; set; }
    public string? DriverCode { get; set; }
    public string? VarAddress { get; set; }
    public string? DataType { get; set; }
    public string RW { get; set; } = "ReadWrite";
    public int Interval { get; set; } = 200;
    public int Priority { get; set; }
    public bool IsUse { get; set; } = true;
    public string? CurValue { get; set; }
    public bool IsAlarm { get; set; }
    public int AlarmInterval { get; set; }
    public decimal AlarmOffset { get; set; }
    public bool IsDelete { get; set; }
}

/// <summary>通讯点位页的各类下拉项</summary>
public class CommPointOptions
{
    /// <summary>部位</summary>
    public List<string> Positions { get; set; } = new();
    /// <summary>所属设备</summary>
    public List<string> Devices { get; set; } = new();
    /// <summary>数据类型</summary>
    public List<string> DataTypes { get; set; } = new();
    /// <summary>可读可写</summary>
    public List<string> Rw { get; set; } = new();
}

/// <summary>按 ID 批量删除</summary>
public class BatchDeleteRequest
{
    public List<long> Ids { get; set; } = new();
}
