/* =============================================================================
   汇总补齐脚本：基础信息 / 系统设置 新增业务表（幂等，可重复执行）
   适用：SQL Server（IPS 公共库，即 API 连接串指向的库；BaseDB 已并入 IPS 库）
   背景：现场日志 Error 208「对象名 ... 无效」，说明下列新表未在现网库中建表。
         本脚本只建表 / 补唯一索引，已有表不会被改动、不会丢数据；
         样例数据见各专题脚本（line_flute / paper / team ...）。

   覆盖表与接口：
     W_Line_Flute        GET/POST/PUT/DELETE /api/base/line-flutes
     W_Line_FluteRule    GET/POST            /api/base/line-flute-rules
     W_Paper_Info        GET/POST/PUT/DELETE /api/base/papers
     W_Paper_BrandParam   （原纸品牌参数，随 papers/{code}/brand-info 整组维护）
     W_Paper_GlueValue    （原纸胶水值，随 papers/{code}/brand-info 整组维护）
     W_Team_Info         GET/POST/PUT/DELETE /api/base/teams
     W_Sys_Config        GET/POST           /api/system/settings
     W_Order_ExtField     GET/POST           /api/system/order-ext-fields
     W_Order_ColorSet     GET/POST           /api/system/order-colors
     W_Ips_PartDisplay    GET/POST           /api/system/ips-parts
   ============================================================================= */

SET NOCOUNT ON;
GO

/* ---------------- 产线楞型 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Line_Flute')
BEGIN
    CREATE TABLE dbo.[W_Line_Flute] (
        [WF_DoorWidth]            decimal(10,2)  NOT NULL,
        [WF_FluteType]            nvarchar(20)   NOT NULL,
        [WF_Thickness]            decimal(10,4)   NULL,
        [WF_Thickness1]           decimal(10,4)   NULL,
        [WF_Thickness2]           decimal(10,4)   NULL,
        [WF_Thickness3]           decimal(10,4)   NULL,
        [WF_WeightThreshold1]    decimal(10,2)   NULL,
        [WF_WeightThreshold2]    decimal(10,2)   NULL,
        [WF_WeightThreshold3]    decimal(10,2)   NULL,
        [WF_MaxSlit]              int            NULL,
        [WF_MinCutLength]         decimal(10,2)   NULL,
        [WF_MaxCutLength]         decimal(10,2)   NULL,
        [WF_MinTrim]              decimal(10,2)   NULL,
        [WF_MaxTrim]              decimal(10,2)   NULL,
        [WF_UpperStackLimit]      decimal(10,2)   NULL,
        [WF_LowerStackLimit]      decimal(10,2)   NULL,
        [WF_StackOpenThreshold1]  int            NULL,
        [WF_StackOpenThreshold2]  int            NULL,
        [WF_StackOpenThreshold3]  int            NULL,
        [WF_UpperStackCount1]     int            NULL,
        [WF_UpperStackCount2]     int            NULL,
        [WF_UpperStackCount3]     int            NULL,
        [WF_LowerStackCount1]     int            NULL,
        [WF_LowerStackCount2]     int            NULL,
        [WF_LowerStackCount3]     int            NULL,
        [WF_SmallLine]            decimal(10,2)   NULL,
        [WF_SmallLineDeepen]      decimal(10,2)   NULL,
        [WF_PlainLineDepth]       decimal(10,2)   NULL,
        [WF_NormalLineDepth]      decimal(10,2)   NULL,
        [WF_DeepLineDepth]        decimal(10,2)   NULL,
        [WF_MaxSpeed]             decimal(10,2)   NULL,
        [WF_RollerCount]          int            NULL,
        [WF_Trim]                 decimal(10,2)   NULL,
        [WF_IsDelete]             bit            NULL,
        [WF_Creator]              nvarchar(50)   NULL,
        [WF_CreateTime]           datetime2       NULL,
        [WF_Editor]               nvarchar(50)   NULL,
        [WF_EditTime]              datetime2      NULL,
        [WF_ID]                    bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Line_Flute] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_W_Line_Flute')
    CREATE UNIQUE INDEX [UX_W_Line_Flute] ON dbo.[W_Line_Flute] ([WF_DoorWidth],[WF_FluteType]) WHERE [WF_IsDelete] = 0;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Line_FluteRule')
BEGIN
    CREATE TABLE dbo.[W_Line_FluteRule] (
        [WF_AutoTrimEnabled]        bit           NULL,
        [WF_AutoTrimThreshold]     decimal(10,2) NULL,
        [WF_AutoTrimType]          nvarchar(40)  NULL,
        [WF_ThicknessCompressRate] decimal(10,2) NULL,
        [WF_StackCountBasis]      nvarchar(40)  NULL,
        [WF_StackDirection]       nvarchar(40)  NULL,
        [WF_ThicknessCalcMode]     nvarchar(40)  NULL,
        [WF_Editor]                nvarchar(50)   NULL,
        [WF_EditTime]              datetime2      NULL,
        [WF_ID]                    bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Line_FluteRule] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

/* ---------------- 原纸资料 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Paper_Info')
BEGIN
    CREATE TABLE dbo.[W_Paper_Info] (
        [WF_Code]       nvarchar(30)  NOT NULL,
        [WF_GramWeight] decimal(10,2) NULL,
        [WF_PaperWidth]  decimal(10,2) NULL,
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
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_W_Paper_Info')
    CREATE UNIQUE INDEX [UX_W_Paper_Info] ON dbo.[W_Paper_Info] ([WF_Code]) WHERE [WF_IsDelete] = 0;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Paper_BrandParam')
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

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Paper_GlueValue')
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

/* ---------------- 班组资料 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Team_Info')
BEGIN
    CREATE TABLE dbo.[W_Team_Info] (
        [WF_ShiftNo]    nvarchar(10)  NOT NULL,
        [WF_TeamName]   nvarchar(60) NOT NULL,
        [WF_StartTime]  nvarchar(20)  NULL,
        [WF_EndTime]    nvarchar(20)  NULL,
        [WF_Leader]     nvarchar(50)  NULL,
        [WF_Forklift1]  nvarchar(50)  NULL,
        [WF_Forklift2]  nvarchar(50)  NULL,
        [WF_IsDelete]   bit           NULL,
        [WF_Creator]    nvarchar(50)  NULL,
        [WF_CreateTime] datetime2     NULL,
        [WF_Editor]     nvarchar(50)  NULL,
        [WF_EditTime]   datetime2     NULL,
        [WF_ID]         bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Team_Info] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_W_Team_Info_ShiftNo')
    CREATE UNIQUE INDEX [UX_W_Team_Info_ShiftNo] ON dbo.[W_Team_Info] ([WF_ShiftNo]) WHERE [WF_IsDelete] = 0;
GO

/* ---------------- 系统设置 / 订单颜色 / 扩展字段 / IPS 部位 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Sys_Config')
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

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Order_ExtField')
BEGIN
    CREATE TABLE dbo.[W_Order_ExtField] (
        [WF_Seq]          int          NOT NULL,
        [WF_Code]         nvarchar(40) NOT NULL,
        [WF_JsonCode]     nvarchar(40) NULL,
        [WF_Name]         nvarchar(100) NULL,
        [WF_DataType]     nvarchar(20) NULL,
        [WF_IsShowInList] bit          NULL,
        [WF_Editor]       nvarchar(50) NULL,
        [WF_EditTime]     datetime2     NULL,
        [WF_ID]           bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Order_ExtField] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Order_ColorSet')
BEGIN
    CREATE TABLE dbo.[W_Order_ColorSet] (
        [WF_Condition] nvarchar(50) NOT NULL,
        [WF_Priority]  int         NOT NULL,
        [WF_BackColor] nvarchar(20) NULL,
        [WF_FontColor] nvarchar(20) NULL,
        [WF_IsUse]     bit          NULL,
        [WF_Editor]    nvarchar(50) NULL,
        [WF_EditTime]  datetime2    NULL,
        [WF_ID]        bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Order_ColorSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'W_Ips_PartDisplay')
BEGIN
    CREATE TABLE dbo.[W_Ips_PartDisplay] (
        [WF_Code]     nvarchar(40)  NOT NULL,
        [WF_Name]     nvarchar(100) NULL,
        [WF_IsShow]   bit           NULL,
        [WF_SortNo]   int           NULL,
        [WF_Editor]   nvarchar(50) NULL,
        [WF_EditTime] datetime2     NULL,
        [WF_ID]       bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_W_Ips_PartDisplay] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
    );
END
GO

/* ---------------- 复核：列出本次应存在的表 ---------------- */
SELECT name AS 表名, create_date AS 创建时间
FROM sys.tables
WHERE name IN (
    N'W_Line_Flute', N'W_Line_FluteRule',
    N'W_Paper_Info', N'W_Paper_BrandParam', N'W_Paper_GlueValue',
    N'W_Team_Info', N'W_Sys_Config', N'W_Order_ExtField',
    N'W_Order_ColorSet', N'W_Ips_PartDisplay'
)
ORDER BY name;
GO
