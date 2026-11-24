/* 原纸资料 W_Paper_Info + 原纸品牌信息 W_Paper_BrandParam + 胶水值 W_Paper_GlueValue
   基础信息 → 原纸资料；「详情」打开原纸品牌信息修改（供应商张力 + 胶水值）。 */

IF OBJECT_ID(N'dbo.W_Paper_Info', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Paper_Info] (
    [WF_Code]       nvarchar(30)  NOT NULL,
    [WF_GramWeight] decimal(10,2) NULL,
    [WF_PaperWidth] decimal(10,2) NULL,
    [WF_Brand]      nvarchar(60)  NULL,
    [WF_RemainLS2]  decimal(12,2) NULL,
    [WF_RemainMS3]  decimal(12,2) NULL,
    [WF_RemainLS3]  decimal(12,2) NULL,
    [WF_IsDelete]   bit           NULL,
    [WF_Creator]    nvarchar(50)  NULL,
    [WF_CreateTime] datetime2     NULL,
    [WF_Editor]     nvarchar(50)  NULL,
    [WF_EditTime]   datetime2     NULL,
    [WF_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Paper_Info] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
CREATE UNIQUE INDEX [UX_W_Paper_Info] ON dbo.[W_Paper_Info] ([WF_Code]) WHERE [WF_IsDelete] = 0;
END
GO

IF OBJECT_ID(N'dbo.W_Paper_BrandParam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Paper_BrandParam] (
    [WF_PaperCode]    nvarchar(30)  NOT NULL,
    [WF_Supplier]     nvarchar(60)  NOT NULL,
    [WF_RatedTension] decimal(12,2) NULL,
    [WF_SteamGsm]     decimal(12,2) NULL,
    [WF_GlueGsm]      decimal(12,2) NULL,
    [WF_WrapGsm]      decimal(12,2) NULL,
    [WF_TensionLS0]   decimal(12,2) NULL,
    [WF_TensionMS1]   decimal(12,2) NULL,
    [WF_TensionLS1]   decimal(12,2) NULL,
    [WF_TensionMS2]   decimal(12,2) NULL,
    [WF_TensionLS2]   decimal(12,2) NULL,
    [WF_TensionMS3]   decimal(12,2) NULL,
    [WF_TensionLS3]   decimal(12,2) NULL,
    [WF_Editor]       nvarchar(50)  NULL,
    [WF_EditTime]     datetime2     NULL,
    [WF_ID]           bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Paper_BrandParam] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

IF OBJECT_ID(N'dbo.W_Paper_GlueValue', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Paper_GlueValue] (
    [WF_PaperCode]   nvarchar(30)  NOT NULL,
    [WF_MachineType] nvarchar(20)  NOT NULL,
    [WF_FluteType]   nvarchar(20)  NOT NULL,
    [WF_Layer]       nvarchar(20)  NULL,
    [WF_GlueValue]   decimal(12,2) NULL,
    [WF_Editor]      nvarchar(50)  NULL,
    [WF_EditTime]    datetime2     NULL,
    [WF_ID]          bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Paper_GlueValue] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[W_Paper_Info])
BEGIN
INSERT INTO dbo.[W_Paper_Info] ([WF_Code],[WF_GramWeight],[WF_PaperWidth],[WF_Brand],[WF_RemainLS2],[WF_RemainMS3],[WF_RemainLS3],[WF_CreateTime],[WF_Creator]) VALUES
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

IF NOT EXISTS (SELECT 1 FROM dbo.[W_Paper_BrandParam])
BEGIN
INSERT INTO dbo.[W_Paper_BrandParam]
([WF_PaperCode],[WF_Supplier],[WF_RatedTension],[WF_SteamGsm],[WF_GlueGsm],[WF_WrapGsm],
 [WF_TensionLS0],[WF_TensionMS1],[WF_TensionLS1],[WF_TensionMS2],[WF_TensionLS2],[WF_TensionMS3],[WF_TensionLS3],[WF_EditTime]) VALUES
 (N'J', N'供应商1', 0, 0, 200, 0, 0, 0, 0, 0, 0, 0, 0, SYSDATETIME()),
 (N'J', N'供应商2', 0, 0, 230, 0, 0, 0, 0, 0, 0, 0, 0, SYSDATETIME());
END
GO

IF NOT EXISTS (SELECT 1 FROM dbo.[W_Paper_GlueValue])
BEGIN
INSERT INTO dbo.[W_Paper_GlueValue] ([WF_PaperCode],[WF_MachineType],[WF_FluteType],[WF_Layer],[WF_GlueValue],[WF_EditTime]) VALUES
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
