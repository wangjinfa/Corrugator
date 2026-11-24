/* 通讯设备表 W_Plc_Device
   通讯设置 → 通讯设备设置 的持久化表。一条记录 = 一个 PLC/工段设备，
   挂一个通讯协议（WF_CommType）和一份通讯配置（WF_ConfigName，引用配置名称）。
   与 W_Plc_DriverConfig、W_Plc_PointVar 同库，属于 IPS 线库。 */

IF OBJECT_ID(N'dbo.W_Plc_Device', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_Device] (
    [WF_Code]       nvarchar(36)  NOT NULL,
    [WF_Name]       nvarchar(100) NULL,
    [WF_CommType]   nvarchar(50)  NULL,
    [WF_ConfigName] nvarchar(100) NULL,
    [WF_IsUse]      bit           NULL,
    [WF_IsDelete]   bit           NOT NULL,
    [WF_Creator]    nvarchar(50)  NULL,
    [WF_CreateTime] datetime2     NULL,
    [WF_Editor]     nvarchar(50)  NULL,
    [WF_EditTime]   datetime2     NULL,
    [WF_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_Device] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 样例数据（与现场截图一致，可按需删除） */
IF NOT EXISTS (SELECT 1 FROM dbo.[W_Plc_Device] WHERE [WF_Code] = N'DF')
BEGIN
INSERT INTO dbo.[W_Plc_Device] ([WF_Code],[WF_Name],[WF_CommType],[WF_ConfigName],[WF_IsUse],[WF_IsDelete],[WF_Creator],[WF_CreateTime])
VALUES
 (N'DF',    N'双面机',            N'Siemens_S7_1200', N'双面机',           1, 0, N'超级管理员', SYSDATETIME()),
 (N'LSO',   N'面纸接纸机',         N'Siemens_S7_1200', N'面纸接纸机',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'SF1',   N'单面机1',           N'Siemens_S7_1200', N'单面机1',          1, 0, N'超级管理员', SYSDATETIME()),
 (N'SF2',   N'单面机2',           N'Siemens_S7_1200', N'单面机2',          1, 0, N'超级管理员', SYSDATETIME()),
 (N'MS1',   N'单面机1芯纸接纸机',   N'Siemens_S7_1200', N'单面机1芯纸接纸机1', 1, 0, N'超级管理员', SYSDATETIME()),
 (N'MS2',   N'单面机2芯纸接纸机',   N'Siemens_S7_1200', N'单面机2芯纸接纸机',  1, 0, N'超级管理员', SYSDATETIME()),
 (N'LS1',   N'单面机1里纸接纸机',   N'Siemens_S7_1200', N'单面机1里纸接纸机',  1, 0, N'超级管理员', SYSDATETIME()),
 (N'LS2',   N'单面机2里纸接纸机',   N'Siemens_S7_1200', N'单面机2里纸接纸机',  1, 0, N'超级管理员', SYSDATETIME()),
 (N'PLC03', N'湿部PLC',           N'Siemens_S7_1200', N'湿部PLC配置',       1, 0, N'超级管理员', SYSDATETIME()),
 (N'PLC02', N'干部订单PLC',        N'Siemens_S7_1200', N'干部订单PLC配置',    1, 0, N'超级管理员', SYSDATETIME()),
 (N'PLC01', N'回收机PLC',          N'Siemens_S7_1200', N'回收机PLC配置',     0, 0, N'超级管理员', SYSDATETIME()),
 (N'PLC04', N'巡航PLC',           N'Siemens_S7_1200', N'巡航PLC配置',       0, 0, N'超级管理员', SYSDATETIME());
END
GO
