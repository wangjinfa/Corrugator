/* 系统运行参数表 TB_Sys_Config
   基础信息 → 系统设置 的持久化表，键值对形式。
   F_Key 取值：UpdateUrl / StartPage / ShowTaskbar / Language / ShowGluePosition */

IF OBJECT_ID(N'dbo.TB_Sys_Config', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Sys_Config] (
    [F_Key]      nvarchar(60)  NOT NULL,
    [F_Value]    nvarchar(300) NULL,
    [F_Desc]     nvarchar(100) NULL,
    [F_Editor]   nvarchar(50)  NULL,
    [F_EditTime] datetime2     NULL,
    [F_ID]       bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Sys_Config] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 默认值（与现场截图一致） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Sys_Config] WHERE [F_Key] = N'UpdateUrl')
BEGIN
INSERT INTO dbo.[TB_Sys_Config] ([F_Key],[F_Value],[F_Desc],[F_EditTime]) VALUES
 (N'UpdateUrl',        N'http://127.0.0.1:7776/BtsClientUpdate.xml', N'自动更新URL',   SYSDATETIME()),
 (N'StartPage',        N'SF1生管',        N'生管控制起始页', SYSDATETIME()),
 (N'ShowTaskbar',      N'True',           N'是否显示任务栏', SYSDATETIME()),
 (N'Language',         N'zh-CN',          N'界面语言',      SYSDATETIME()),
 (N'ShowGluePosition', N'False',          N'显示糊机部位选择', SYSDATETIME());
END
GO
