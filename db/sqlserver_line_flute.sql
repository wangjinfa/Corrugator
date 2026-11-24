/* 产线楞型 W_Line_Flute + 规则设置 W_Line_FluteRule
   基础信息 → 产线楞型：门幅+楞型唯一，厚度/切长/修边/堆码/压线参数，页面底部为全局规则。 */

IF OBJECT_ID(N'dbo.W_Line_Flute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Line_Flute] (
    [WF_DoorWidth]        decimal(10,2) NOT NULL,
    [WF_FluteType]        nvarchar(20)  NOT NULL,
    [WF_Thickness]        decimal(10,4) NULL,
    [WF_Thickness1]       decimal(10,4) NULL,
    [WF_Thickness2]       decimal(10,4) NULL,
    [WF_Thickness3]       decimal(10,4) NULL,
    [WF_WeightThreshold1] decimal(10,2) NULL,
    [WF_WeightThreshold2] decimal(10,2) NULL,
    [WF_WeightThreshold3] decimal(10,2) NULL,
    [WF_MaxSlit]          int           NULL,
    [WF_MinCutLength]     decimal(10,2) NULL,
    [WF_MaxCutLength]     decimal(10,2) NULL,
    [WF_MinTrim]          decimal(10,2) NULL,
    [WF_MaxTrim]          decimal(10,2) NULL,
    [WF_UpperStackLimit]  decimal(10,2) NULL,
    [WF_LowerStackLimit]  decimal(10,2) NULL,
    [WF_StackOpenThreshold1] int NULL,
    [WF_StackOpenThreshold2] int NULL,
    [WF_StackOpenThreshold3] int NULL,
    [WF_UpperStackCount1] int NULL,
    [WF_UpperStackCount2] int NULL,
    [WF_UpperStackCount3] int NULL,
    [WF_LowerStackCount1] int NULL,
    [WF_LowerStackCount2] int NULL,
    [WF_LowerStackCount3] int NULL,
    [WF_SmallLine]        decimal(10,2) NULL,
    [WF_SmallLineDeepen]  decimal(10,2) NULL,
    [WF_PlainLineDepth]   decimal(10,2) NULL,
    [WF_NormalLineDepth]  decimal(10,2) NULL,
    [WF_DeepLineDepth]    decimal(10,2) NULL,
    [WF_MaxSpeed]         decimal(10,2) NULL,
    [WF_RollerCount]      int           NULL,
    [WF_Trim]             decimal(10,2) NULL,
    [WF_IsDelete]         bit           NULL,
    [WF_Creator]          nvarchar(50)  NULL,
    [WF_CreateTime]       datetime2     NULL,
    [WF_Editor]           nvarchar(50)  NULL,
    [WF_EditTime]         datetime2     NULL,
    [WF_ID]               bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Line_Flute] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
CREATE UNIQUE INDEX [UX_W_Line_Flute] ON dbo.[W_Line_Flute] ([WF_DoorWidth],[WF_FluteType]) WHERE [WF_IsDelete] = 0;
END
GO

IF OBJECT_ID(N'dbo.W_Line_FluteRule', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Line_FluteRule] (
    [WF_AutoTrimEnabled]       bit           NULL,
    [WF_AutoTrimThreshold]     decimal(10,2) NULL,
    [WF_AutoTrimType]          nvarchar(40)  NULL,
    [WF_ThicknessCompressRate] decimal(10,2) NULL,
    [WF_StackCountBasis]       nvarchar(40)  NULL,
    [WF_StackDirection]        nvarchar(40)  NULL,
    [WF_ThicknessCalcMode]     nvarchar(40)  NULL,
    [WF_Editor]                nvarchar(50)  NULL,
    [WF_EditTime]              datetime2     NULL,
    [WF_ID]                    bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Line_FluteRule] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 样例：11 条产线楞型（与截图同款首行 2800/3A） */
IF NOT EXISTS (SELECT 1 FROM dbo.[W_Line_Flute])
BEGIN
INSERT INTO dbo.[W_Line_Flute]
([WF_DoorWidth],[WF_FluteType],[WF_Thickness],[WF_Thickness1],[WF_Thickness2],[WF_Thickness3],
 [WF_WeightThreshold1],[WF_WeightThreshold2],[WF_WeightThreshold3],[WF_MaxSlit],
 [WF_MinCutLength],[WF_MaxCutLength],[WF_MinTrim],[WF_MaxTrim],
 [WF_UpperStackLimit],[WF_LowerStackLimit],
 [WF_StackOpenThreshold1],[WF_StackOpenThreshold2],[WF_StackOpenThreshold3],
 [WF_UpperStackCount1],[WF_UpperStackCount2],[WF_UpperStackCount3],
 [WF_LowerStackCount1],[WF_LowerStackCount2],[WF_LowerStackCount3],
 [WF_SmallLine],[WF_SmallLineDeepen],[WF_PlainLineDepth],[WF_NormalLineDepth],[WF_DeepLineDepth],
 [WF_MaxSpeed],[WF_RollerCount],[WF_Trim],[WF_CreateTime],[WF_Creator]) VALUES
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
IF NOT EXISTS (SELECT 1 FROM dbo.[W_Line_FluteRule])
BEGIN
INSERT INTO dbo.[W_Line_FluteRule]
([WF_AutoTrimEnabled],[WF_AutoTrimThreshold],[WF_AutoTrimType],[WF_ThicknessCompressRate],
 [WF_StackCountBasis],[WF_StackDirection],[WF_ThicknessCalcMode],[WF_EditTime]) VALUES
(0, 10, N'不修边', 0.8, N'剁数', N'操作侧', N'克重区间模式', SYSDATETIME());
END
GO
