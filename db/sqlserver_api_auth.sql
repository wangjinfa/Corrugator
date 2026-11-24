/* API 授权相关三张表（基础信息 → API授权）
   S_ApiUsers      对外接口调用账号（左表）
   S_Apis          对外接口清单（右表）
   S_ApiAuthorizes 账号到接口的授权关系（右下「授权」按钮写入） */

IF OBJECT_ID(N'dbo.S_ApiUsers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ApiUsers] (
    [F_Account]    nvarchar(50)  NOT NULL,
    [F_Secret]     nvarchar(50)  NULL,
    [F_SystemName] nvarchar(100) NULL,
    [F_IsUse]      bit           NULL,
    [F_IsDelete]   bit           NOT NULL,
    [F_Creator]    nvarchar(50)  NULL,
    [F_CreateTime] datetime2     NULL,
    [F_Editor]     nvarchar(50)  NULL,
    [F_EditTime]   datetime2     NULL,
    [F_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ApiUsers] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

IF OBJECT_ID(N'dbo.S_Apis', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Apis] (
    [F_Desc]       nvarchar(100) NULL,
    [F_Url]        nvarchar(200) NULL,
    [F_SystemName] nvarchar(100) NULL,
    [F_IsUse]      bit           NULL,
    [F_IsDelete]   bit           NOT NULL,
    [F_Creator]    nvarchar(50)  NULL,
    [F_CreateTime] datetime2     NULL,
    [F_Editor]     nvarchar(50)  NULL,
    [F_EditTime]   datetime2     NULL,
    [F_ID]         bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Apis] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

IF OBJECT_ID(N'dbo.S_ApiAuthorizes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ApiAuthorizes] (
    [F_ApiUserId] bigint       NOT NULL,
    [F_ApiId]     bigint       NOT NULL,
    [F_IsUse]     bit          NULL,
    [F_Editor]    nvarchar(50) NULL,
    [F_EditTime]  datetime2    NULL,
    [F_ID]        bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ApiAuthorizes] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 账号样例（截图三条） */
IF NOT EXISTS (SELECT 1 FROM dbo.[S_ApiUsers] WHERE [F_Account] = N'test')
BEGIN
INSERT INTO dbo.[S_ApiUsers] ([F_Account],[F_Secret],[F_SystemName],[F_IsUse],[F_IsDelete],[F_Creator],[F_CreateTime])
VALUES (N'test', N'1', N'测试账号', 1, 0, N'超级管理员', SYSDATETIME()),
       (N'baoche', N'123#', N'抱车系统1', 1, 0, N'超级管理员', SYSDATETIME()),
       (N'js', N'1', N'江苏', 1, 0, N'超级管理员', SYSDATETIME());
END
GO

/* 接口清单样例（截图 14 条） */
IF NOT EXISTS (SELECT 1 FROM dbo.[S_Apis])
BEGIN
INSERT INTO dbo.[S_Apis] ([F_Desc],[F_Url],[F_IsUse],[F_IsDelete],[F_Creator],[F_CreateTime]) VALUES
 (N'添加生产订单',            N'/api/ErpOrder/AddOrders',           1, 0, N'超级管理员', SYSDATETIME()),
 (N'订单生产数据回收',        N'/api/ErpOrder/RecOrders',           1, 0, N'超级管理员', SYSDATETIME()),
 (N'添加原纸卷信息',          N'/api/ErpOrder/AddErpPapers',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'删除生产订单',            N'/api/ErpOrder/DelOrders',           1, 0, N'超级管理员', SYSDATETIME()),
 (N'获取备料表信息',          N'/api/Paper/GetPaperReadyList',      1, 0, N'超级管理员', SYSDATETIME()),
 (N'获取当前班组信息',        N'/api/Order/GetCurShiftInfo',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'获取当前生产订单',        N'/api/ErpOrder/GetRealTimeProList',  1, 0, N'超级管理员', SYSDATETIME()),
 (N'未完工订单信息',          N'/api/Order/GetOrders',              1, 0, N'超级管理员', SYSDATETIME()),
 (N'未完工订单明细',          N'/api/Order/GetOrderDetail',         1, 0, N'超级管理员', SYSDATETIME()),
 (N'完工订单信息',            N'/api/Order/GetFinishOrders',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'完工订单明细',            N'/api/Order/GetFinishOrderDetail',   1, 0, N'超级管理员', SYSDATETIME()),
 (N'当前订单信息',            N'/api/Order/GetCurOrderInfo',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'当前班组信息',            N'/api/Order/GetCurShiftInfo',        1, 0, N'超级管理员', SYSDATETIME()),
 (N'获取接纸机本批和下批数据', N'/api/SPData/GetSPData',              1, 0, N'超级管理员', SYSDATETIME());
END
GO
