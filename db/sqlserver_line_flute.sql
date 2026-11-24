/* 产线楞型 TB_Line_Flute + 规则设置 TB_Line_FluteRule
   基础信息 → 产线楞型：门幅+楞型唯一，厚度/切长/修边/堆码/压线参数，页面底部为全局规则。 */

IF OBJECT_ID(N'dbo.TB_Line_Flute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Line_Flute] (
    [F_DoorWidth]        decimal(10,2) NOT NULL,
    [F_FluteType]        nvarchar(20)  NOT NULL,
    [F_Thickness]        decimal(10,4) NULL,
    [F_Thickness1]       decimal(10,4) NULL,
    [F_Thickness2]       decimal(10,4) NULL,
    [F_Thickness3]       decimal(10,4) NULL,
    [F_WeightThreshold1] decimal(10,2) NULL,
    [F_WeightThreshold2] decimal(10,2) NULL,
    [F_WeightThreshold3] decimal(10,2) NULL,
    [F_MaxSlit]          int           NULL,
    [F_MinCutLength]     decimal(10,2) NULL,
    [F_MaxCutLength]     decimal(10,2) NULL,
    [F_MinTrim]          decimal(10,2) NULL,
    [F_MaxTrim]          decimal(10,2) NULL,
    [F_UpperStackLimit]  decimal(10,2) NULL,
    [F_LowerStackLimit]  decimal(10,2) NULL,
    [F_StackOpenThreshold1] int NULL,
    [F_StackOpenThreshold2] int NULL,
    [F_StackOpenThreshold3] int NULL,
    [F_UpperStackCount1] int NULL,
    [F_UpperStackCount2] int NULL,
    [F_UpperStackCount3] int NULL,
    [F_LowerStackCount1] int NULL,
    [F_LowerStackCount2] int NULL,
    [F_LowerStackCount3] int NULL,
    [F_SmallLine]        decimal(10,2) NULL,
    [F_SmallLineDeepen]  decimal(10,2) NULL,
    [F_PlainLineDepth]   decimal(10,2) NULL,
    [F_NormalLineDepth]  decimal(10,2) NULL,
    [F_DeepLineDepth]    decimal(10,2) NULL,
    [F_MaxSpeed]         decimal(10,2) NULL,
    [F_RollerCount]      int           NULL,
    [F_Trim]             decimal(10,2) NULL,
    [F_IsDelete]         bit           NULL,
    [F_Creator]          nvarchar(50)  NULL,
    [F_CreateTime]       datetime2     NULL,
    [F_Editor]           nvarchar(50)  NULL,
    [F_EditTime]         datetime2     NULL,
    [F_ID]               bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Line_Flute] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
CREATE UNIQUE INDEX [UX_TB_Line_Flute] ON dbo.[TB_Line_Flute] ([F_DoorWidth],[F_FluteType]) WHERE [F_IsDelete] = 0;
END
GO

IF OBJECT_ID(N'dbo.TB_Line_FluteRule', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Line_FluteRule] (
    [F_AutoTrimEnabled]       bit           NULL,
    [F_AutoTrimThreshold]     decimal(10,2) NULL,
    [F_AutoTrimType]          nvarchar(40)  NULL,
    [F_ThicknessCompressRate] decimal(10,2) NULL,
    [F_StackCountBasis]       nvarchar(40)  NULL,
    [F_StackDirection]        nvarchar(40)  NULL,
    [F_ThicknessCalcMode]     nvarchar(40)  NULL,
    [F_Editor]                nvarchar(50)  NULL,
    [F_EditTime]              datetime2     NULL,
    [F_ID]                    bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Line_FluteRule] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 样例：11 条产线楞型（与截图同款首行 2800/3A） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Line_Flute])
BEGIN
INSERT INTO dbo.[TB_Line_Flute]
([F_DoorWidth],[F_FluteType],[F_Thickness],[F_Thickness1],[F_Thickness2],[F_Thickness3],
 [F_WeightThreshold1],[F_WeightThreshold2],[F_WeightThreshold3],[F_MaxSlit],
 [F_MinCutLength],[F_MaxCutLength],[F_MinTrim],[F_MaxTrim],
 [F_UpperStackLimit],[F_LowerStackLimit],
 [F_StackOpenThreshold1],[F_StackOpenThreshold2],[F_StackOpenThreshold3],
 [F_UpperStackCount1],[F_UpperStackCount2],[F_UpperStackCount3],
 [F_LowerStackCount1],[F_LowerStackCount2],[F_LowerStackCount3],
 [F_SmallLine],[F_SmallLineDeepen],[F_PlainLineDepth],[F_NormalLineDepth],[F_DeepLineDepth],
 [F_MaxSpeed],[F_RollerCount],[F_Trim],[F_CreateTime],[F_Creator]) VALUES
 (2800, N'3A', 4.34, 4.36, 4.31, 4.3, 210, 400, 590, 7, 500, 4500, 0, 300, 1800, 1700, 7, 7, 7, 300, 300, 300, 300, 300, 300, 0, 0, 200, 440, 350, 300, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2800, N'3B', 4.28, 4.3, 4.25, 4.2, 220, 410, 600, 7, 500, 4500, 0, 300, 1800, 1700, 7, 7, 7, 300, 300, 300, 300, 300, 300, 0, 0, 300, 440, 350, 280, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2500, N'3A', 4.34, 4.36, 4.31, 4.3, 210, 400, 590, 6, 500, 4000, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 250, 440, 350, 280, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2500, N'3B', 4.28, 4.3, 4.25, 4.2, 220, 410, 600, 6, 500, 4000, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 250, 400, 300, 260, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2500, N'5A', 6.1, 6.15, 6.05, 6.0, 260, 480, 700, 6, 500, 4000, 0, 300, 1800, 1700, 7, 7, 7, 300, 300, 300, 300, 300, 300, 0, 0, 370, 520, 600, 240, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2200, N'5A', 6.1, 6.15, 6.05, 6.0, 260, 480, 700, 5, 450, 3500, 0, 300, 1800, 1700, 7, 7, 7, 300, 300, 300, 300, 300, 300, 101, 70, 370, 520, 600, 230, 0, NULL, SYSDATETIME(), N'超级管理员')
 (2200, N'5B', 6.05, 6.1, 6.0, 5.95, 270, 490, 710, 5, 450, 3500, 0, 300, 1800, 1700, 7, 7, 7, 300, 300, 300, 300, 300, 300, 0, 0, 370, 510, 590, 230, 0, NULL, SYSDATETIME(), N'超级管理员')
 (1800, N'5A', 6.1, 6.15, 6.05, 6.0, 260, 480, 700, 4, 400, 3000, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 350, 520, 600, 210, 0, NULL, SYSDATETIME(), N'超级管理员')
 (1800, N'5B', 6.05, 6.1, 6.0, 5.95, 270, 490, 710, 4, 400, 3000, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 350, 510, 590, 210, 0, NULL, SYSDATETIME(), N'超级管理员')
 (1600, N'7A', 7.8, 7.85, 7.75, 7.7, 300, 520, 760, 4, 400, 2800, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 370, 560, 640, 200, 0, NULL, SYSDATETIME(), N'超级管理员')
 (1600, N'7B', 7.75, 7.8, 7.7, 7.65, 310, 530, 770, 4, 400, 2800, 0, 300, 1800, 1700, 7, 7, 7, 250, 250, 250, 250, 250, 250, 0, 0, 370, 560, 640, 200, 0, NULL, SYSDATETIME(), N'超级管理员');
END
GO

/* 样例：页面底部规则设置 */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Line_FluteRule])
BEGIN
INSERT INTO dbo.[TB_Line_FluteRule]
([F_AutoTrimEnabled],[F_AutoTrimThreshold],[F_AutoTrimType],[F_ThicknessCompressRate],
 [F_StackCountBasis],[F_StackDirection],[F_ThicknessCalcMode],[F_EditTime]) VALUES
(0, 10, N'不修边', 0.8, N'剁数', N'操作侧', N'克重区间模式', SYSDATETIME());
END
GO
