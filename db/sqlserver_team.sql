/* 班组资料 W_Team_Info —— 基础信息 → 班组资料
   班次号唯一（软删后可重录），开始/结束时间为 HH:mm:ss 文本。 */

IF OBJECT_ID(N'dbo.W_Team_Info', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Team_Info] (
    [WF_ShiftNo]    nvarchar(10) NOT NULL,
    [WF_TeamName]   nvarchar(60) NOT NULL,
    [WF_StartTime]  nvarchar(20) NULL,
    [WF_EndTime]    nvarchar(20) NULL,
    [WF_Leader]     nvarchar(50) NULL,
    [WF_Forklift1]  nvarchar(50) NULL,
    [WF_Forklift2]  nvarchar(50) NULL,
    [WF_IsDelete]   bit          NULL,
    [WF_Creator]    nvarchar(50) NULL,
    [WF_CreateTime] datetime2    NULL,
    [WF_Editor]     nvarchar(50) NULL,
    [WF_EditTime]   datetime2    NULL,
    [WF_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Team_Info] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
CREATE UNIQUE INDEX [UX_W_Team_Info_ShiftNo] ON dbo.[W_Team_Info] ([WF_ShiftNo]) WHERE [WF_IsDelete] = 0;
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[W_Team_Info])
BEGIN
INSERT INTO dbo.[W_Team_Info]
([WF_ShiftNo],[WF_TeamName],[WF_StartTime],[WF_EndTime],[WF_Leader],[WF_Forklift1],[WF_Forklift2],
 [WF_IsDelete],[WF_Creator],[WF_CreateTime],[WF_Editor],[WF_EditTime]) VALUES
 (N'01', N'A',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2022-03-25 14:46:16', N'超级管理员', '2025-05-28 13:07:21'),
 (N'02', N'B',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2022-03-25 14:46:21', NULL, '2025-04-22 11:22:41'),
 (N'03', N'C',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2023-03-13 13:43:52', NULL, NULL),
 (N'04', N'D',     N'07:00:00',          NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2023-04-14 09:55:43', NULL, NULL),
 (N'07', N'G',     N'2025-06-10 00:00:00', NULL,               NULL, NULL, NULL, 0, N'超级管理员', '2025-06-10 14:37:41', N'超级管理员', '2025-06-10 14:37:52'),
 (N'09', N'STOP',  N'00:00:00',          N'23:59:59',          NULL, NULL, NULL, 0, N'超级管理员', '2022-02-07 13:07:53', NULL, NULL);
END
GO
