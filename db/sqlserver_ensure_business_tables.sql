/* =============================================================================
   汇总补齐脚本：基础信息 / 系统设置 新增业务表（幂等，可重复执行）
   适用：SQL Server（IPS 公共库，即 API 连接串指向的库；BaseDB 已并入 IPS 库）
   背景：现场日志 Error 208「对象名 ... 无效」，说明下列新表未在现网库中建表。
         本脚本只建表 / 补唯一索引，已有表不会被改动、不会丢数据；
         样例数据见各专题脚本（line_flute / paper / team ...）。

   覆盖表与接口：
     TB_Line_Flute        GET/POST/PUT/DELETE /api/base/line-flutes
     TB_Line_FluteRule    GET/POST            /api/base/line-flute-rules
     TB_Paper_Info        GET/POST/PUT/DELETE /api/base/papers
     TB_Paper_BrandParam   （原纸品牌参数，随 papers/{code}/brand-info 整组维护）
     TB_Paper_GlueValue    （原纸胶水值，随 papers/{code}/brand-info 整组维护）
     TB_Team_Info         GET/POST/PUT/DELETE /api/base/teams
     TB_Sys_Config        GET/POST           /api/system/settings
     TB_Order_ExtField     GET/POST           /api/system/order-ext-fields
     TB_Order_ColorSet     GET/POST           /api/system/order-colors
     TB_Ips_PartDisplay    GET/POST           /api/system/ips-parts
   ============================================================================= */

SET NOCOUNT ON;
GO

/* ---------------- 产线楞型 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Line_Flute')
BEGIN
    CREATE TABLE dbo.[TB_Line_Flute] (
        [F_DoorWidth]            decimal(10,2)  NOT NULL,
        [F_FluteType]            nvarchar(20)   NOT NULL,
        [F_Thickness]            decimal(10,4)   NULL,
        [F_Thickness1]           decimal(10,4)   NULL,
        [F_Thickness2]           decimal(10,4)   NULL,
        [F_Thickness3]           decimal(10,4)   NULL,
        [F_WeightThreshold1]    decimal(10,2)   NULL,
        [F_WeightThreshold2]    decimal(10,2)   NULL,
        [F_WeightThreshold3]    decimal(10,2)   NULL,
        [F_MaxSlit]              int            NULL,
        [F_MinCutLength]         decimal(10,2)   NULL,
        [F_MaxCutLength]         decimal(10,2)   NULL,
        [F_MinTrim]              decimal(10,2)   NULL,
        [F_MaxTrim]              decimal(10,2)   NULL,
        [F_UpperStackLimit]      decimal(10,2)   NULL,
        [F_LowerStackLimit]      decimal(10,2)   NULL,
        [F_StackOpenThreshold1]  int            NULL,
        [F_StackOpenThreshold2]  int            NULL,
        [F_StackOpenThreshold3]  int            NULL,
        [F_UpperStackCount1]     int            NULL,
        [F_UpperStackCount2]     int            NULL,
        [F_UpperStackCount3]     int            NULL,
        [F_LowerStackCount1]     int            NULL,
        [F_LowerStackCount2]     int            NULL,
        [F_LowerStackCount3]     int            NULL,
        [F_SmallLine]            decimal(10,2)   NULL,
        [F_SmallLineDeepen]      decimal(10,2)   NULL,
        [F_PlainLineDepth]       decimal(10,2)   NULL,
        [F_NormalLineDepth]      decimal(10,2)   NULL,
        [F_DeepLineDepth]        decimal(10,2)   NULL,
        [F_MaxSpeed]             decimal(10,2)   NULL,
        [F_RollerCount]          int            NULL,
        [F_Trim]                 decimal(10,2)   NULL,
        [F_IsDelete]             bit            NULL,
        [F_Creator]              nvarchar(50)   NULL,
        [F_CreateTime]           datetime2       NULL,
        [F_Editor]               nvarchar(50)   NULL,
        [F_EditTime]              datetime2      NULL,
        [F_ID]                    bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Line_Flute] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_TB_Line_Flute')
    CREATE UNIQUE INDEX [UX_TB_Line_Flute] ON dbo.[TB_Line_Flute] ([F_DoorWidth],[F_FluteType]) WHERE [F_IsDelete] = 0;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Line_FluteRule')
BEGIN
    CREATE TABLE dbo.[TB_Line_FluteRule] (
        [F_AutoTrimEnabled]        bit           NULL,
        [F_AutoTrimThreshold]     decimal(10,2) NULL,
        [F_AutoTrimType]          nvarchar(40)  NULL,
        [F_ThicknessCompressRate] decimal(10,2) NULL,
        [F_StackCountBasis]      nvarchar(40)  NULL,
        [F_StackDirection]       nvarchar(40)  NULL,
        [F_ThicknessCalcMode]     nvarchar(40)  NULL,
        [F_Editor]                nvarchar(50)   NULL,
        [F_EditTime]              datetime2      NULL,
        [F_ID]                    bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Line_FluteRule] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

/* ---------------- 原纸资料 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Paper_Info')
BEGIN
    CREATE TABLE dbo.[TB_Paper_Info] (
        [F_Code]       nvarchar(30)  NOT NULL,
        [F_GramWeight] decimal(10,2) NULL,
        [F_PaperWidth]  decimal(10,2) NULL,
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
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_TB_Paper_Info')
    CREATE UNIQUE INDEX [UX_TB_Paper_Info] ON dbo.[TB_Paper_Info] ([F_Code]) WHERE [F_IsDelete] = 0;
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Paper_BrandParam')
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

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Paper_GlueValue')
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

/* ---------------- 班组资料 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Team_Info')
BEGIN
    CREATE TABLE dbo.[TB_Team_Info] (
        [F_ShiftNo]    nvarchar(10)  NOT NULL,
        [F_TeamName]   nvarchar(60) NOT NULL,
        [F_StartTime]  nvarchar(20)  NULL,
        [F_EndTime]    nvarchar(20)  NULL,
        [F_Leader]     nvarchar(50)  NULL,
        [F_Forklift1]  nvarchar(50)  NULL,
        [F_Forklift2]  nvarchar(50)  NULL,
        [F_IsDelete]   bit           NULL,
        [F_Creator]    nvarchar(50)  NULL,
        [F_CreateTime] datetime2     NULL,
        [F_Editor]     nvarchar(50)  NULL,
        [F_EditTime]   datetime2     NULL,
        [F_ID]         bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Team_Info] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.indexes WHERE name = N'UX_TB_Team_Info_ShiftNo')
    CREATE UNIQUE INDEX [UX_TB_Team_Info_ShiftNo] ON dbo.[TB_Team_Info] ([F_ShiftNo]) WHERE [F_IsDelete] = 0;
GO

/* ---------------- 系统设置 / 订单颜色 / 扩展字段 / IPS 部位 ---------------- */
IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Sys_Config')
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

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Order_ExtField')
BEGIN
    CREATE TABLE dbo.[TB_Order_ExtField] (
        [F_Seq]          int          NOT NULL,
        [F_Code]         nvarchar(40) NOT NULL,
        [F_JsonCode]     nvarchar(40) NULL,
        [F_Name]         nvarchar(100) NULL,
        [F_DataType]     nvarchar(20) NULL,
        [F_IsShowInList] bit          NULL,
        [F_Editor]       nvarchar(50) NULL,
        [F_EditTime]     datetime2     NULL,
        [F_ID]           bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Order_ExtField] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Order_ColorSet')
BEGIN
    CREATE TABLE dbo.[TB_Order_ColorSet] (
        [F_Condition] nvarchar(50) NOT NULL,
        [F_Priority]  int         NOT NULL,
        [F_BackColor] nvarchar(20) NULL,
        [F_FontColor] nvarchar(20) NULL,
        [F_IsUse]     bit          NULL,
        [F_Editor]    nvarchar(50) NULL,
        [F_EditTime]  datetime2    NULL,
        [F_ID]        bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Order_ColorSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

IF NOT EXISTS (SELECT 1 FROM sys.tables WHERE name = N'TB_Ips_PartDisplay')
BEGIN
    CREATE TABLE dbo.[TB_Ips_PartDisplay] (
        [F_Code]     nvarchar(40)  NOT NULL,
        [F_Name]     nvarchar(100) NULL,
        [F_IsShow]   bit           NULL,
        [F_SortNo]   int           NULL,
        [F_Editor]   nvarchar(50) NULL,
        [F_EditTime] datetime2     NULL,
        [F_ID]       bigint IDENTITY(1,1) NOT NULL,
        CONSTRAINT [PK_TB_Ips_PartDisplay] PRIMARY KEY CLUSTERED ([F_ID] ASC)
    );
END
GO

/* ---------------- 复核：列出本次应存在的表 ---------------- */
SELECT name AS 表名, create_date AS 创建时间
FROM sys.tables
WHERE name IN (
    N'TB_Line_Flute', N'TB_Line_FluteRule',
    N'TB_Paper_Info', N'TB_Paper_BrandParam', N'TB_Paper_GlueValue',
    N'TB_Team_Info', N'TB_Sys_Config', N'TB_Order_ExtField',
    N'TB_Order_ColorSet', N'TB_Ips_PartDisplay'
)
ORDER BY name;
GO
