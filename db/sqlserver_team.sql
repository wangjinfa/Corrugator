/* 班组资料 TB_Team_Info —— 基础信息 → 班组资料
   班次号唯一（软删后可重录），开始/结束时间为 HH:mm:ss 文本。 */

IF OBJECT_ID(N'dbo.TB_Team_Info', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Team_Info] (
    [F_ShiftNo]    nvarchar(10) NOT NULL,
    [F_TeamName]   nvarchar(60) NOT NULL,
    [F_StartTime]  nvarchar(20) NULL,
    [F_EndTime]    nvarchar(20) NULL,
    [F_Leader]     nvarchar(50) NULL,
    [F_Forklift1]  nvarchar(50) NULL,
    [F_Forklift2]  nvarchar(50) NULL,
    [F_IsDelete]   bit          NULL,
    [F_Creator]    nvarchar(50) NULL,
    [F_CreateTime] datetime2    NULL,
    [F_Editor]     nvarchar(50) NULL,
    [F_EditTime]   datetime2    NULL,
    [F_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Team_Info] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
CREATE UNIQUE INDEX [UX_TB_Team_Info_ShiftNo] ON dbo.[TB_Team_Info] ([F_ShiftNo]) WHERE [F_IsDelete] = 0;
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Team_Info])
BEGIN
INSERT INTO dbo.[TB_Team_Info]
([F_ShiftNo],[F_TeamName],[F_StartTime],[F_EndTime],[F_Leader],[F_Forklift1],[F_Forklift2],
 [F_IsDelete],[F_Creator],[F_CreateTime],[F_Editor],[F_EditTime]) VALUES
 (N'01', N'A',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2022-03-25 14:46:16', N'超级管理员', '2025-05-28 13:07:21'),
 (N'02', N'B',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2022-03-25 14:46:21', NULL, '2025-04-22 11:22:41'),
 (N'03', N'C',     NULL,                 NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2023-03-13 13:43:52', NULL, NULL),
 (N'04', N'D',     N'07:00:00',          NULL,                 NULL, NULL, NULL, 0, N'超级管理员', '2023-04-14 09:55:43', NULL, NULL),
 (N'07', N'G',     N'2025-06-10 00:00:00', NULL,               NULL, NULL, NULL, 0, N'超级管理员', '2025-06-10 14:37:41', N'超级管理员', '2025-06-10 14:37:52'),
 (N'09', N'STOP',  N'00:00:00',          N'23:59:59',          NULL, NULL, NULL, 0, N'超级管理员', '2022-02-07 13:07:53', NULL, NULL);
END
GO
