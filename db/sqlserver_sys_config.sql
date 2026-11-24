/* 系统运行参数表 W_Sys_Config
   基础信息 → 系统设置 的持久化表，键值对形式。
   WF_Key 取值：UpdateUrl / StartPage / ShowTaskbar / Language / ShowGluePosition */

IF OBJECT_ID(N'dbo.W_Sys_Config', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Sys_Config] (
    [WF_Key]      nvarchar(60)  NOT NULL,
    [WF_Value]    nvarchar(300) NULL,
    [WF_Desc]     nvarchar(100) NULL,
    [WF_Editor]   nvarchar(50)  NULL,
    [WF_EditTime] datetime2     NULL,
    [WF_ID]       bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Sys_Config] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 默认值（与现场截图一致） */
IF NOT EXISTS (SELECT 1 FROM dbo.[W_Sys_Config] WHERE [WF_Key] = N'UpdateUrl')
BEGIN
INSERT INTO dbo.[W_Sys_Config] ([WF_Key],[WF_Value],[WF_Desc],[WF_EditTime]) VALUES
 (N'UpdateUrl',        N'http://127.0.0.1:7776/BtsClientUpdate.xml', N'自动更新URL',   SYSDATETIME()),
 (N'StartPage',        N'SF1生管',        N'生管控制起始页', SYSDATETIME()),
 (N'ShowTaskbar',      N'True',           N'是否显示任务栏', SYSDATETIME()),
 (N'Language',         N'zh-CN',          N'界面语言',      SYSDATETIME()),
 (N'ShowGluePosition', N'False',          N'显示糊机部位选择', SYSDATETIME());
END
GO
