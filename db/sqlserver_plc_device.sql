/* 通讯设备表 TB_Plc_Device
   通讯设置 → 通讯设备设置 的持久化表。一条记录 = 一个 PLC/工段设备，
   挂一个通讯协议（F_CommType）和一份通讯配置（F_ConfigName，引用配置名称）。
   与 TB_Plc_DriverConfig、TB_Plc_PointVar 同库，属于 IPS 线库。 */

IF OBJECT_ID(N'dbo.TB_Plc_Device', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_Device] (
    [F_Code]       nvarchar(36)  NOT NULL,
    [F_Name]       nvarchar(100) NULL,
    [F_CommType]   nvarchar(50)  NULL,
    [F_ConfigName] nvarchar(100) NULL,
    [F_IsUse]      bit           NULL,
    [F_IsDelete]   bit           NOT NULL,
    [F_Creator]    nvarchar(50)  NULL,
    [F_CreateTime] datetime2     NULL,
    [F_Editor]     nvarchar(50)  NULL,
    [F_EditTime]   datetime2     NULL,
    [F_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_Device] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 样例数据（与现场截图一致，可按需删除） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Plc_Device] WHERE [F_Code] = N'DF')
BEGIN
INSERT INTO dbo.[TB_Plc_Device] ([F_Code],[F_Name],[F_CommType],[F_ConfigName],[F_IsUse],[F_IsDelete],[F_Creator],[F_CreateTime])
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
