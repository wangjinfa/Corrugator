/* 原纸资料 TB_Paper_Info + 原纸品牌信息 TB_Paper_BrandParam + 胶水值 TB_Paper_GlueValue
   基础信息 → 原纸资料；「详情」打开原纸品牌信息修改（供应商张力 + 胶水值）。 */

IF OBJECT_ID(N'dbo.TB_Paper_Info', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Paper_Info] (
    [F_Code]       nvarchar(30)  NOT NULL,
    [F_GramWeight] decimal(10,2) NULL,
    [F_PaperWidth] decimal(10,2) NULL,
    [F_Brand]      nvarchar(60)  NULL,
    [F_RemainLS2]  decimal(12,2) NULL,
    [F_RemainMS3]  decimal(12,2) NULL,
    [F_RemainLS3]  decimal(12,2) NULL,
    [F_IsDelete]   bit           NULL,
    [F_Creator]    nvarchar(50)  NULL,
    [F_CreateTime] datetime2     NULL,
    [F_Editor]     nvarchar(50)  NULL,
    [F_EditTime]   datetime2     NULL,
    [F_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Paper_Info] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
CREATE UNIQUE INDEX [UX_TB_Paper_Info] ON dbo.[TB_Paper_Info] ([F_Code]) WHERE [F_IsDelete] = 0;
END
GO

IF OBJECT_ID(N'dbo.TB_Paper_BrandParam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Paper_BrandParam] (
    [F_PaperCode]    nvarchar(30)  NOT NULL,
    [F_Supplier]     nvarchar(60)  NOT NULL,
    [F_RatedTension] decimal(12,2) NULL,
    [F_SteamGsm]     decimal(12,2) NULL,
    [F_GlueGsm]      decimal(12,2) NULL,
    [F_WrapGsm]      decimal(12,2) NULL,
    [F_TensionLS0]   decimal(12,2) NULL,
    [F_TensionMS1]   decimal(12,2) NULL,
    [F_TensionLS1]   decimal(12,2) NULL,
    [F_TensionMS2]   decimal(12,2) NULL,
    [F_TensionLS2]   decimal(12,2) NULL,
    [F_TensionMS3]   decimal(12,2) NULL,
    [F_TensionLS3]   decimal(12,2) NULL,
    [F_Editor]       nvarchar(50)  NULL,
    [F_EditTime]     datetime2     NULL,
    [F_ID]           bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Paper_BrandParam] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

IF OBJECT_ID(N'dbo.TB_Paper_GlueValue', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Paper_GlueValue] (
    [F_PaperCode]   nvarchar(30)  NOT NULL,
    [F_MachineType] nvarchar(20)  NOT NULL,
    [F_FluteType]   nvarchar(20)  NOT NULL,
    [F_Layer]       nvarchar(20)  NULL,
    [F_GlueValue]   decimal(12,2) NULL,
    [F_Editor]      nvarchar(50)  NULL,
    [F_EditTime]    datetime2     NULL,
    [F_ID]          bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Paper_GlueValue] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Paper_Info])
BEGIN
INSERT INTO dbo.[TB_Paper_Info] ([F_Code],[F_GramWeight],[F_PaperWidth],[F_Brand],[F_RemainLS2],[F_RemainMS3],[F_RemainLS3],[F_CreateTime],[F_Creator]) VALUES
 (N'J', 170, 2500, N'玖龙', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'Z', 170, 2500, N'玖龙', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'S', 150, 2200, N'理文', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'K', 150, 2200, N'理文', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'M', 200, 2500, N'玖龙', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'L', 200, 2500, N'晨鸣', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'N', 120, 2200, N'理文', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'P', 120, 2200, N'晨鸣', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'Q', 170, 2800, N'玖龙', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'R', 170, 2800, N'理文', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'T', 150, 2500, N'晨鸣', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'U', 200, 2800, N'玖龙', 200, 210, 210, SYSDATETIME(), N'超级管理员')
 (N'V', 200, 2800, N'理文', 200, 210, 210, SYSDATETIME(), N'超级管理员');
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Paper_BrandParam])
BEGIN
INSERT INTO dbo.[TB_Paper_BrandParam]
([F_PaperCode],[F_Supplier],[F_RatedTension],[F_SteamGsm],[F_GlueGsm],[F_WrapGsm],
 [F_TensionLS0],[F_TensionMS1],[F_TensionLS1],[F_TensionMS2],[F_TensionLS2],[F_TensionMS3],[F_TensionLS3],[F_EditTime]) VALUES
 (N'J', N'供应商1', 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, SYSDATETIME()),
 (N'J', N'供应商2', 0, 0, 230, 0, 0, 0, 0, 0, 0, 0, 0, SYSDATETIME());
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Paper_GlueValue])
BEGIN
INSERT INTO dbo.[TB_Paper_GlueValue] ([F_PaperCode],[F_MachineType],[F_FluteType],[F_Layer],[F_GlueValue],[F_EditTime]) VALUES
 (N'J', N'单面机', N'A', NULL, 0, SYSDATETIME())
 (N'J', N'单面机', N'B', NULL, 0, SYSDATETIME())
 (N'J', N'单面机', N'C', NULL, 0, SYSDATETIME())
 (N'J', N'单面机', N'E', NULL, 0, SYSDATETIME()),
 (N'J', N'双面机', N'3A', N'1层', 0, SYSDATETIME())
 (N'J', N'双面机', N'3B', N'1层', 0, SYSDATETIME())
 (N'J', N'双面机', N'3C', N'1层', 0, SYSDATETIME())
 (N'J', N'双面机', N'3E', N'1层', 0, SYSDATETIME())
 (N'J', N'双面机', N'4BA', N'1层', 0, SYSDATETIME())
 (N'J', N'双面机', N'4BC', N'1层', 0, SYSDATETIME());
END
GO
