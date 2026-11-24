/* =====================================================================
   IPS 瓦楞纸板生产线生管系统 —— SQL Server 建表脚本
   由 DataDictionary（原 PostgreSQL 15 / IPS 库）转换生成
   类型映射：varchar->nvarchar, int4->int, bool->bit, timestamp->datetime2,
            numeric(p[,s])->decimal(p,s)（未写精度的 numeric 统一按 decimal(18,4)）
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* ERP订单中间表 */
IF OBJECT_ID(N'dbo.E_Orders', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[E_Orders] (
    [WEO_Guid] nvarchar(50) NULL,
    [EO_IsUrgent] bit NOT NULL,
    [EO_WorkNo] int NOT NULL,
    [EO_ClassNo] nvarchar(50) NULL,
    [EO_PaperCode] nvarchar(50) NOT NULL,
    [EO_Wave] nvarchar(50) NOT NULL,
    [EO_Floor] int NOT NULL,
    [EO_Width] int NOT NULL,
    [EO_Trim] int NULL,
    [EO_WidthInch] decimal(18,4) NULL,
    [EO_Weight] int NULL,
    [EO_Deep] decimal(18,4) NULL,
    [EO_Floor1] nvarchar(10) NULL,
    [EO_Floor1Deep] int NULL,
    [EO_Floor2] nvarchar(10) NULL,
    [EO_Floor2Deep] int NULL,
    [EO_Floor3] nvarchar(10) NULL,
    [EO_Floor3Deep] int NULL,
    [EO_Floor4] nvarchar(10) NULL,
    [EO_Floor4Deep] int NULL,
    [EO_Floor5] nvarchar(10) NULL,
    [EO_Floor5Deep] int NULL,
    [EO_Floor6] nvarchar(10) NULL,
    [EO_Floor6Deep] int NULL,
    [EO_Floor7] nvarchar(10) NULL,
    [EO_Floor7Deep] int NULL,
    [EO_Send] nvarchar(10) NULL,
    [EO_Speed] int NULL,
    [EO_ScheduleMeter] decimal(18,4) NULL,
    [EO_Stop] bit NOT NULL,
    [EO_UGoD] bit NOT NULL,
    [EO_StartTime] datetime2 NULL,
    [EO_EstFinshTime] datetime2 NULL,
    [EO_ModCutQty] int NULL,
    [EO_OrderNo] nvarchar(50) NULL,
    [EO_CustNo] nvarchar(50) NULL,
    [EO_TaskNo] nvarchar(50) NULL,
    [EO_CustName] nvarchar(100) NULL,
    [EO_CustPaperCode] nvarchar(50) NULL,
    [EO_CutWidth] int NOT NULL,
    [EO_CutWidthInch] decimal(18,4) NULL,
    [EO_CutLength] int NOT NULL,
    [EO_CutLengthInch] decimal(18,4) NULL,
    [EO_CutQty] int NOT NULL,
    [EO_OrderQty] int NULL,
    [EO_OrderMeter] decimal(18,4) NULL,
    [EO_OrderNoQty] int NULL,
    [EO_LabelQty] int NULL,
    [EO_CN] int NOT NULL,
    [EO_ScorType] nvarchar(10) NOT NULL,
    [EO_Scor] nvarchar(100) NULL,
    [EO_ScorDeep] decimal(18,4) NOT NULL,
    [EO_Remark] nvarchar(500) NULL,
    [EO_Stack] bit NOT NULL,
    [EO_StackQty] int NULL,
    [EO_BunQty] int NULL,
    [EO_Bundle] bit NOT NULL,
    [EO_BundleQty] int NULL,
    [EO_BundleNum] int NULL,
    [EO_OrderDate] datetime2 NULL,
    [EO_DeliDate] datetime2 NULL,
    [EO_StockMemo] nvarchar(200) NULL,
    [EO_BoxMemo] nvarchar(200) NULL,
    [EO_DeliMemo] nvarchar(200) NULL,
    [EO_PlanMemo] nvarchar(max) NULL,
    [EO_CutPaperMemo] nvarchar(200) NULL,
    [EO_Memo] nvarchar(max) NULL,
    [EO_OrderNo_D] nvarchar(50) NULL,
    [EO_CustNo_D] nvarchar(50) NULL,
    [EO_TaskNo_D] nvarchar(50) NULL,
    [EO_CustName_D] nvarchar(100) NULL,
    [EO_CustPaperCode_D] nvarchar(50) NULL,
    [EO_CutWidth_D] int NULL,
    [EO_CutWidthInch_D] decimal(18,4) NULL,
    [EO_CutLength_D] int NULL,
    [EO_CutLengthInch_D] decimal(18,4) NULL,
    [EO_CutQty_D] int NULL,
    [EO_OrderQty_D] int NULL,
    [EO_OrderMeter_D] decimal(18,4) NULL,
    [EO_OrderNoQty_D] int NULL,
    [EO_LabelQty_D] int NULL,
    [EO_CN_D] int NULL,
    [EO_ScorType_D] nvarchar(10) NULL,
    [EO_Scor_D] nvarchar(100) NULL,
    [EO_ScorDeep_D] decimal(18,4) NULL,
    [EO_Remark_D] nvarchar(500) NULL,
    [EO_Stack_D] bit NULL,
    [EO_StackQty_D] int NULL,
    [EO_BunQty_D] int NULL,
    [EO_Bundle_D] bit NULL,
    [EO_BundleQty_D] int NULL,
    [EO_BundleNum_D] int NULL,
    [EO_OrderDate_D] datetime2 NULL,
    [EO_DeliDate_D] datetime2 NULL,
    [EO_StockMemo_D] nvarchar(200) NULL,
    [EO_BoxMemo_D] nvarchar(200) NULL,
    [EO_DeliMemo_D] nvarchar(200) NULL,
    [EO_PlanMemo_D] nvarchar(max) NULL,
    [EO_CutPaperMemo_D] nvarchar(200) NULL,
    [EO_Memo_D] nvarchar(max) NULL,
    [EO_Status] int NULL,
    [EO_ErrorMsg] nvarchar(max) NULL,
    [EO_OperDate] datetime2 NULL,
    [EO_TrimCode] int NOT NULL,
    [EO_TOrderNo] nvarchar(50) NULL,
    [EO_IsDouble] bit NULL,
    [EO_SortSN] int NULL,
    [EO_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_E_Orders] PRIMARY KEY CLUSTERED ([EO_ID] ASC)
);
END
GO

/* 订单修改日志表 */
IF OBJECT_ID(N'dbo.L_OrderLogs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[L_OrderLogs] (
    [WEO_Guid] nvarchar(50) NULL,
    [WO_ID] int NOT NULL,
    [LOL_Time] datetime2 NOT NULL,
    [LOL_UserName] nvarchar(50) NOT NULL,
    [LOL_MachineIp] nvarchar(50) NOT NULL,
    [LOL_MachineName] nvarchar(50) NOT NULL,
    [LOL_Content] nvarchar(100) NOT NULL,
    [LOL_ClassNo] nvarchar(50) NULL,
    [LOL_WorkNo] int NOT NULL,
    [LOL_WorkNo_O] nvarchar(50) NULL,
    [LOL_PaperCode] nvarchar(50) NOT NULL,
    [LOL_PaperCode_O] nvarchar(50) NULL,
    [LOL_Wave] nvarchar(50) NOT NULL,
    [LOL_Wave_O] nvarchar(50) NULL,
    [LOL_Width] int NOT NULL,
    [LOL_Width_O] nvarchar(50) NULL,
    [LOL_Trim] int NOT NULL,
    [LOL_Trim_O] nvarchar(50) NULL,
    [LOL_TrimArea] decimal(18,4) NOT NULL,
    [LOL_TrimArea_O] nvarchar(50) NULL,
    [LOL_CustName] nvarchar(50) NOT NULL,
    [LOL_OrderNo] nvarchar(50) NOT NULL,
    [LOL_CutWidth] int NOT NULL,
    [LOL_CutWidth_O] nvarchar(50) NULL,
    [LOL_CutLength] int NOT NULL,
    [LOL_CutLength_O] nvarchar(50) NULL,
    [LOL_CutQty] int NOT NULL,
    [LOL_CutQty_O] nvarchar(50) NULL,
    [LOL_CN] int NOT NULL,
    [LOL_CN_O] nvarchar(50) NULL,
    [LOL_SheetQty] int NOT NULL,
    [LOL_SheetQty_O] nvarchar(50) NULL,
    [LOL_ScorType] nvarchar(10) NOT NULL,
    [LOL_ScorType_O] nvarchar(10) NULL,
    [LOL_Scor] nvarchar(100) NOT NULL,
    [LOL_Scor_O] nvarchar(100) NULL,
    [LOL_Area] decimal(18,4) NOT NULL,
    [LOL_Area_O] nvarchar(50) NULL,
    [LOL_Remark] nvarchar(500) NULL,
    [LOL_CustName_D] nvarchar(50) NULL,
    [LOL_OrderNo_D] nvarchar(50) NULL,
    [LOL_CutWidth_D] int NULL,
    [LOL_CutWidth_D_O] nvarchar(50) NULL,
    [LOL_CutLength_D] int NULL,
    [LOL_CutLength_D_O] nvarchar(50) NULL,
    [LOL_CutQty_D] int NULL,
    [LOL_CutQty_D_O] nvarchar(50) NULL,
    [LOL_CN_D] int NULL,
    [LOL_CN_D_O] nvarchar(50) NULL,
    [LOL_SheetQty_D] int NULL,
    [LOL_SheetQty_D_O] nvarchar(50) NULL,
    [LOL_ScorType_D] nvarchar(10) NULL,
    [LOL_ScorType_D_O] nvarchar(10) NULL,
    [LOL_Scor_D] nvarchar(100) NULL,
    [LOL_Scor_D_O] nvarchar(100) NULL,
    [LOL_Area_D] decimal(18,4) NULL,
    [LOL_Area_D_O] nvarchar(50) NULL,
    [LOL_Remark_D] nvarchar(500) NULL,
    [LOL_UpdateReason] nvarchar(500) NULL,
    [LOL_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_L_OrderLogs] PRIMARY KEY CLUSTERED ([LOL_ID] ASC)
);
END
GO

/* 系统日志表 */
IF OBJECT_ID(N'dbo.L_SystemLogs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[L_SystemLogs] (
    [LSL_Time] datetime2 NOT NULL,
    [LSL_UserName] nvarchar(50) NULL,
    [LSL_MachineIp] nvarchar(50) NULL,
    [LSL_MachineName] nvarchar(50) NULL,
    [LSL_SoftwareName] nvarchar(50) NOT NULL,
    [LSL_Module] nvarchar(50) NOT NULL,
    [LSL_Content] nvarchar(max) NOT NULL,
    [LSL_Type] int NOT NULL,
    [LSL_Order] nvarchar(200) NULL,
    [LSL_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_L_SystemLogs] PRIMARY KEY CLUSTERED ([LSL_ID] ASC)
);
END
GO

/* 数据字典明细表 */
IF OBJECT_ID(N'dbo.P_DictDatas', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[P_DictDatas] (
    [PD_TypeID] int NOT NULL,
    [PD_Property] nvarchar(50) NULL,
    [PD_EnglishName] nvarchar(50) NULL,
    [PD_Value] nvarchar(100) NULL,
    [PD_SortNo] int NULL,
    [PD_ChineseName] nvarchar(100) NULL,
    [PD_Ctreator] nvarchar(20) NOT NULL,
    [PD_CreateTime] datetime2 NOT NULL,
    [PD_Editor] nvarchar(20) NULL,
    [PD_EditTime] datetime2 NULL,
    [PD_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_P_DictDatas] PRIMARY KEY CLUSTERED ([PD_ID] ASC)
);
END
GO

/* 数据字典类型表 */
IF OBJECT_ID(N'dbo.P_DictTypes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[P_DictTypes] (
    [PD_PID] int NULL,
    [PD_Name] nvarchar(50) NULL,
    [PD_Code] nvarchar(50) NULL,
    [PD_Creator] nvarchar(20) NOT NULL,
    [PD_CreateTime] datetime2 NOT NULL,
    [PD_Editor] nvarchar(20) NULL,
    [PD_EditTime] datetime2 NULL,
    [PD_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_P_DictTypes] PRIMARY KEY CLUSTERED ([PD_ID] ASC)
);
END
GO

/* 预警部位 */
IF OBJECT_ID(N'dbo.S_AlarmParts', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_AlarmParts] (
    [SA_Code] nvarchar(20) NOT NULL,
    [SA_Name] nvarchar(50) NULL,
    [SA_IPAddress] nvarchar(50) NULL,
    [SA_PhoneID] nvarchar(max) NULL,
    [SA_PhoneGroup] nvarchar(100) NULL,
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_AlarmParts] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* 预警原因 */
IF OBJECT_ID(N'dbo.S_AlarmReasons', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_AlarmReasons] (
    [SA_Code] nvarchar(20) NOT NULL,
    [SA_Title] nvarchar(50) NULL,
    [SA_Content] nvarchar(100) NULL,
    [SA_SendTimes] int NULL,
    [SA_IntervalTime] int NULL,
    [SA_PartCode] nvarchar(20) NULL,
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_AlarmReasons] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* 预警复核人 */
IF OBJECT_ID(N'dbo.S_AlarmReviewers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_AlarmReviewers] (
    [SA_Name] nvarchar(20) NOT NULL,
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_AlarmReviewers] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* 基础楞型组合 */
IF OBJECT_ID(N'dbo.S_BaseWaveGroup', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_BaseWaveGroup] (
    [SBG_Wave] nvarchar(50) NOT NULL,
    [SBG_IsUseDFOuter] bit NULL,
    [SBG_IsUseSF1Medium] bit NULL,
    [SBG_IsUseSF1Inside] bit NULL,
    [SBG_IsUseSF2Medium] bit NULL,
    [SBG_IsUseSF2Inside] bit NULL,
    [SBG_IsUseSF3Medium] bit NULL,
    [SBG_IsUseSF3Inside] bit NULL,
    [SBG_IsOftenUse] bit NULL,
    [SBG_Creator] nvarchar(50) NULL,
    [SBG_CreateTime] datetime2 NULL,
    [SBG_Editor] nvarchar(50) NULL,
    [SBG_EditTime] datetime2 NULL,
    [SBG_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_BaseWaveGroup] PRIMARY KEY CLUSTERED ([SBG_ID] ASC)
);
END
GO

/* 基础楞型表 */
IF OBJECT_ID(N'dbo.S_BaseWaves', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_BaseWaves] (
    [SBW_Wave] nvarchar(10) NOT NULL,
    [SBW_WDeep] decimal(18,4) NOT NULL,
    [SBW_WRate] decimal(18,4) NOT NULL,
    [SBW_IsUse] bit NOT NULL,
    [SBW_Creator] nvarchar(50) NULL,
    [SBW_CreateTime] datetime2 NULL,
    [SBW_Editor] nvarchar(50) NULL,
    [SBW_EditTime] datetime2 NULL,
    [SBW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_BaseWaves] PRIMARY KEY CLUSTERED ([SBW_ID] ASC)
);
END
GO

/* 班组基础资料设置表 */
IF OBJECT_ID(N'dbo.S_Classes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Classes] (
    [SC_ShiftNum] nvarchar(10) NULL,
    [SC_Name] nvarchar(50) NOT NULL,
    [SC_Monitor] nvarchar(50) NULL,
    [SC_CarHugger1] nvarchar(50) NULL,
    [SC_CarHugger2] nvarchar(50) NULL,
    [SC_Creator] nvarchar(50) NOT NULL,
    [SC_CreateTime] datetime2 NOT NULL,
    [SC_Editor] nvarchar(50) NULL,
    [SC_EditTime] datetime2 NULL,
    [SC_StartTime] nvarchar(50) NULL,
    [SC_EndTime] nvarchar(50) NULL,
    [SC_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Classes] PRIMARY KEY CLUSTERED ([SC_ID] ASC)
);
END
GO

/* 耗材配置界面 */
IF OBJECT_ID(N'dbo.S_Consumables', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Consumables] (
    [SC_ID] int IDENTITY(1,1) NOT NULL,
    [SC_Number] nvarchar(50) NULL,
    [SC_Name] nvarchar(50) NULL,
    [SC_Code] nvarchar(50) NULL,
    [SC_Type] nvarchar(50) NULL,
    [SC_Item] nvarchar(50) NULL,
    [SC_Price] decimal(10,2) NULL,
    [SC_Property] nvarchar(50) NULL,
    [SC_ShowPrice] bit NULL,
    [SC_IsUse] bit NULL,
    CONSTRAINT [PK_S_Consumables] PRIMARY KEY CLUSTERED ([SC_ID] ASC)
);
END
GO

/* 当前班组表 */
IF OBJECT_ID(N'dbo.S_CurrentShift', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_CurrentShift] (
    [SCS_ClassId] int NULL,
    [SCS_P04TID] int NULL,
    [SCS_ShiftNum] nvarchar(10) NULL,
    [SCS_Shift] nvarchar(50) NULL,
    [SCS_LastClassId] int NULL,
    [SCS_LastP04TID] int NULL,
    [SCS_LastShiftNum] nvarchar(10) NULL,
    [SCS_LastShift] nvarchar(50) NULL,
    [SCS_ChangeTime] datetime2 NULL,
    [SCS_SF1CurUseFluteSF1] nvarchar(50) NULL,
    [SCS_SF2CurUseFluteSF2] nvarchar(50) NULL,
    [SCS_SF3CurUseFluteSF3] nvarchar(50) NULL,
    [SCS_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_CurrentShift] PRIMARY KEY CLUSTERED ([SCS_Id] ASC)
);
END
GO

/* 切长限速表 */
IF OBJECT_ID(N'dbo.S_CutSpeeds', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_CutSpeeds] (
    [SCS_CutLength] int NOT NULL,
    [SCS_Speed] int NOT NULL,
    [SCS_CreateTime] datetime2 NULL,
    [SCS_Creator] nvarchar(50) NULL,
    [SCS_EditTime] datetime2 NULL,
    [SCS_Editor] nvarchar(50) NULL,
    [SCS_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_CutSpeeds] PRIMARY KEY CLUSTERED ([SCS_ID] ASC)
);
END
GO

/* 原纸品牌详情表 */
IF OBJECT_ID(N'dbo.S_PaperCodeBrands', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_PaperCodeBrands] (
    [F_Brand] nvarchar(100) NOT NULL,
    [F_PaperCodeID] int NOT NULL,
    [F_RatedTension] int NULL,
    [F_SteamWeight] int NULL,
    [F_GlueWeight] int NULL,
    [F_WrapWeight] int NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_LS0Tension] int NOT NULL,
    [F_MS1Tension] int NULL,
    [F_LS1Tension] int NULL,
    [F_MS2Tension] int NULL,
    [F_LS2Tension] int NULL,
    [F_MS3Tension] int NULL,
    [F_LS3Tension] int NULL,
    CONSTRAINT [PK_S_PaperCodeBrands] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸基础资料设置表 */
IF OBJECT_ID(N'dbo.S_PaperCodes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_PaperCodes] (
    [SPC_Code] nvarchar(50) NOT NULL,
    [SPC_ErpCode] nvarchar(50) NULL,
    [SPC_Weight] int NOT NULL,
    [SPC_RatedTension] int NULL,
    [SPC_SteamWeight] int NULL,
    [SPC_GlueWeight] int NULL,
    [SPC_WrapWeight] int NULL,
    [SPC_Deep] decimal(18,4) NOT NULL,
    [SPC_LS0_TensionFactorLS0] decimal(18,2) NULL,
    [SPC_MS1_TensionFactorMS1] decimal(18,2) NULL,
    [SPC_LS1_TensionFactorLS1] decimal(18,2) NULL,
    [SPC_MS2_TensionFactorMS2] decimal(18,2) NULL,
    [SPC_LS2_TensionFactorLS2] decimal(18,2) NULL,
    [SPC_MS3_TensionFactorMS3] decimal(18,2) NULL,
    [SPC_LS3_TensionFactorLS3] decimal(18,2) NULL,
    [SPC_LS0_Speed] int NOT NULL,
    [SPC_MS1_Speed] int NULL,
    [SPC_LS1_Speed] int NULL,
    [SPC_MS2_Speed] int NULL,
    [SPC_LS2_Speed] int NULL,
    [SPC_MS3_Speed] int NULL,
    [SPC_LS3_Speed] int NULL,
    [SPC_Creator] nvarchar(50) NOT NULL,
    [SPC_CreateTime] datetime2 NOT NULL,
    [SPC_Editor] nvarchar(50) NULL,
    [SPC_EditTime] datetime2 NULL,
    [SPC_ID] int IDENTITY(1,1) NOT NULL,
    [SPC_LS0_SpeedRemain] int NOT NULL,
    [SPC_MS1_SpeedRemain] int NULL,
    [SPC_LS1_SpeedRemain] int NULL,
    [SPC_MS2_SpeedRemain] int NULL,
    [SPC_LS2_SpeedRemain] int NULL,
    [SPC_MS3_SpeedRemain] int NULL,
    [SPC_LS3_SpeedRemain] int NULL,
    [SPC_LS0Tension] int NOT NULL,
    [SPC_MS1Tension] int NULL,
    [SPC_LS1Tension] int NULL,
    [SPC_MS2Tension] int NULL,
    [SPC_LS2Tension] int NULL,
    [SPC_MS3Tension] int NULL,
    [SPC_LS3Tension] int NULL,
    CONSTRAINT [PK_S_PaperCodes] PRIMARY KEY CLUSTERED ([SPC_ID] ASC)
);
END
GO

/* 产线错位资料设置表 */
IF OBJECT_ID(N'dbo.S_ProductBunles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ProductBunles] (
    [SPB_Wave] nvarchar(50) NOT NULL,
    [SPB_StartSec] decimal(18,4) NOT NULL,
    [SPB_EndSec] decimal(18,4) NOT NULL,
    [SPB_CreateTime] datetime2 NOT NULL,
    [SPB_Creator] nvarchar(50) NOT NULL,
    [SPB_EditTime] datetime2 NULL,
    [SPB_Editor] nvarchar(50) NULL,
    [SPB_BunleQty] int NOT NULL,
    [SPB_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ProductBunles] PRIMARY KEY CLUSTERED ([SPB_ID] ASC)
);
END
GO

/* S_ProductTarget */
IF OBJECT_ID(N'dbo.S_ProductTarget', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ProductTarget] (
    [SP_ID] int IDENTITY(1,1) NOT NULL,
    [SP_Number] nvarchar(50) NULL,
    [SP_Type] nvarchar(50) NULL,
    [SP_Describe1] nvarchar(50) NULL,
    [SP_TargetValue1] decimal(18,4) NULL,
    [SP_Describe2] nvarchar(50) NULL,
    [SP_TargetValue2] decimal(18,4) NULL,
    [SP_Property] nvarchar(50) NULL,
    CONSTRAINT [PK_S_ProductTarget] PRIMARY KEY CLUSTERED ([SP_ID] ASC)
);
END
GO

/* 产线楞型基础资料设置表 */
IF OBJECT_ID(N'dbo.S_ProductWaves', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ProductWaves] (
    [SPW_Width] int NOT NULL,
    [SPW_Wave] nvarchar(50) NOT NULL,
    [SPW_WDeepSF1] decimal(18,4) NULL,
    [SPW_WRateSF1] decimal(18,4) NULL,
    [SPW_WDeepSF2] decimal(18,4) NULL,
    [SPW_WRateSF2] decimal(18,4) NULL,
    [SPW_WDeepSF3] decimal(18,4) NULL,
    [SPW_WRateSF3] decimal(18,4) NULL,
    [SPW_PaperDeep] decimal(18,4) NOT NULL,
    [SPW_MaxCN] int NOT NULL,
    [SPW_MinCutLength] int NOT NULL,
    [SPW_MaxCutLength] int NOT NULL,
    [SPW_MinEdge] int NOT NULL,
    [SPW_MaxEdge] int NOT NULL,
    [SPW_SmallScor] int NULL,
    [SPW_SmallScorDepth] int NULL,
    [SPW_FlatScorDepth] int NULL,
    [SPW_ComScorDepth] int NULL,
    [SPW_ProScorDePth] int NULL,
    [SPW_CreateTime] datetime2 NOT NULL,
    [SPW_Creator] nvarchar(50) NOT NULL,
    [SPW_EditTime] datetime2 NULL,
    [SPW_Editor] nvarchar(50) NULL,
    [SPW_MaxSpeed] int NULL,
    [SPW_PaperDeepWeight1] decimal(18,2) NOT NULL,
    [SPW_PaperDeepWeight2] decimal(18,2) NOT NULL,
    [SPW_PaperDeepWeight3] decimal(18,2) NOT NULL,
    [SPW_PaperDeep1] decimal(18,2) NOT NULL,
    [SPW_PaperDeep2] decimal(18,2) NOT NULL,
    [SPW_PaperDeep3] decimal(18,2) NOT NULL,
    [SPW_UpLimite] decimal(18,2) NOT NULL,
    [SPW_DownLimite] decimal(18,2) NOT NULL,
    [SPW_CN1] int NOT NULL,
    [SPW_CN2] int NOT NULL,
    [SPW_CN3] int NOT NULL,
    [SPW_StackQty] int NOT NULL,
    [SPW_StackQty_D] int NOT NULL,
    [SPW_StackQty2] int NOT NULL,
    [SPW_StackQty_D2] int NOT NULL,
    [SPW_StackQty3] int NOT NULL,
    [SPW_StackQty_D3] int NOT NULL,
    [BundleQty] int NOT NULL,
    [SPW_Trim] int NULL,
    [SPW_Wgt1] int NULL,
    [SPW_Wgt2] int NULL,
    [SPW_AddDepth1] int NULL,
    [SPW_AddDepth2] int NULL,
    [SPW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ProductWaves] PRIMARY KEY CLUSTERED ([SPW_ID] ASC)
);
END
GO

/* 补打原因表 */
IF OBJECT_ID(N'dbo.S_ReissueReasons', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ReissueReasons] (
    [F_Reason] nvarchar(500) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ReissueReasons] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 选择楞型 */
IF OBJECT_ID(N'dbo.S_SelectWave', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_SelectWave] (
    [SSO_ID] int NOT NULL,
    [SSO_Editor] nvarchar(50) NULL,
    [SSO_EditTime] datetime2 NULL,
    [SSW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_SelectWave] PRIMARY KEY CLUSTERED ([SSW_ID] ASC)
);
END
GO

/* 楞型配置选项 */
IF OBJECT_ID(N'dbo.S_SelectWaveOptions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_SelectWaveOptions] (
    [SSO_Name] nvarchar(50) NOT NULL,
    [SSO_Creator] nvarchar(50) NULL,
    [SSO_CreateTime] datetime2 NULL,
    [SSO_Editor] nvarchar(50) NULL,
    [SSO_EditTime] datetime2 NULL,
    [SSO_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_SelectWaveOptions] PRIMARY KEY CLUSTERED ([SSO_ID] ASC)
);
END
GO

/* 楞型配置关系 */
IF OBJECT_ID(N'dbo.S_SelectWaveRelation', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_SelectWaveRelation] (
    [SSO_ID] int NOT NULL,
    [SBG_ID] int NOT NULL,
    [SSR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_SelectWaveRelation] PRIMARY KEY CLUSTERED ([SSR_ID] ASC)
);
END
GO

/* 瓦楞辊对照表 */
IF OBJECT_ID(N'dbo.S_WaveComparison', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_WaveComparison] (
    [Wave] nvarchar(50) NOT NULL,
    [Type] nvarchar(50) NOT NULL,
    [Code] nvarchar(50) NOT NULL,
    [IDExtra] nvarchar(50) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_WaveComparison] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 瓦楞辊设置表 */
IF OBJECT_ID(N'dbo.S_WaveSetting', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_WaveSetting] (
    [Code] nvarchar(50) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [Deep] decimal(18,4) NOT NULL,
    [Rate] decimal(18,4) NOT NULL,
    [Position] nvarchar(50) NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_WaveSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* TB_BundleSetting */
IF OBJECT_ID(N'dbo.TB_BundleSetting', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_BundleSetting] (
    [HalfBundleMinWeight] int NOT NULL,
    [HalfBundleMinQty] int NOT NULL,
    [IsUseSplitPaperBundle] bit NOT NULL,
    [MinCutCount] int NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_BundleSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 订单列表行背景色设置 */
IF OBJECT_ID(N'dbo.TB_ColorSets', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_ColorSets] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Code] nvarchar(255) NOT NULL,
    [F_Name] nvarchar(255) NOT NULL,
    [F_BackColor] nvarchar(255) NOT NULL,
    [F_IsUse] bit NOT NULL,
    [F_Sort] nvarchar(255) NOT NULL,
    [F_ForeColor] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_TB_ColorSets] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_HotPlateSteamGram */
IF OBJECT_ID(N'dbo.TB_HotPlateSteamGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_HotPlateSteamGram] (
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinSteam] int NOT NULL,
    [F_MaxSteam] int NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_PrPressIncrease] int NULL,
    [F_Offset_1st] decimal(18,2) NULL,
    [F_Offset_2nd] decimal(18,2) NULL,
    [F_Offset_3rd] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_HotPlateSteamGram] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 报警读写偏差值设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_AlarmRWSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_AlarmRWSet] (
    [F_Code] nvarchar(50) NOT NULL,
    [F_Name] nvarchar(50) NOT NULL,
    [F_OffSet] decimal(18,2) NOT NULL,
    [F_Interval] int NOT NULL,
    [F_IsUse] bit NOT NULL,
    [F_IsSend] bit NOT NULL,
    [F_IsSave] bit NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_AlarmRWSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 自动预警设置 */
IF OBJECT_ID(N'dbo.TB_IPS_AlarmSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_AlarmSet] (
    [F_Code] nvarchar(36) NOT NULL,
    [F_Name] nvarchar(100) NULL,
    [F_Desc] nvarchar(max) NULL,
    [F_AlarmCron] nvarchar(200) NULL,
    [F_IsUse] bit NOT NULL,
    [F_IsSend] bit NOT NULL,
    [F_IsSave] bit NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_AlarmSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* BHS喷淋基础设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_BHS_Spray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_BHS_Spray] (
    [F_Position] nvarchar(50) NULL,
    [F_IsUse] bit NULL,
    [F_Power] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_BHS_Spray] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 天桥张力设置 */
IF OBJECT_ID(N'dbo.TB_IPS_BridgeTension', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_BridgeTension] (
    [F_Position] int NOT NULL,
    [F_Flute] nvarchar(10) NOT NULL,
    [F_MinValue] int NOT NULL,
    [F_MaxValue] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_BridgeTension] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 天桥张力门幅设置 */
IF OBJECT_ID(N'dbo.TB_IPS_BridgeTensionWidth', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_BridgeTensionWidth] (
    [F_Width] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_BridgeTensionWidth] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_ChangeMaterialQua */
IF OBJECT_ID(N'dbo.TB_IPS_ChangeMaterialQua', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_ChangeMaterialQua] (
    [F_MachinePosition] nvarchar(50) NULL,
    [F_RealMaterialQua] nvarchar(50) NULL,
    [F_RealWidth] int NULL,
    [F_TheoryMaterialQua] nvarchar(50) NULL,
    [F_TheoryWidth] int NULL,
    [F_TheoryNextMaterialQua] nvarchar(50) NULL,
    [F_TheoryNextWidth] int NULL,
    [F_SF_SameRemainMeter] int NULL,
    [F_DF_SameRemainMeter] int NULL,
    [F_IsSameReplaceMaterialQua] bit NULL,
    [F_IsRelaceMaterialQua] bit NULL,
    [F_DateTime] datetime2 NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_ChangeMaterialQua] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 瓦楞辊压力设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_CorrugatedRollPaperPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CorrugatedRollPaperPress] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NULL,
    [F_PressValue] decimal(18,2) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_CorrugatedRollPaperPress] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 瓦楞辊机台系数表 */
IF OBJECT_ID(N'dbo.TB_IPS_CorrugatedRollSFCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CorrugatedRollSFCoef] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_SF1Coef] decimal(18,2) NULL,
    [F_SF2Coef] decimal(18,2) NULL,
    [F_SF3Coef] decimal(18,2) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_CorrugatedRollSFCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 瓦楞辊门幅系数表 */
IF OBJECT_ID(N'dbo.TB_IPS_CorrugatedRollWidthCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CorrugatedRollWidthCoef] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_CorrugatedRollWidthCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 换愣降速设置 */
IF OBJECT_ID(N'dbo.TB_IPS_CruiseChangewave', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CruiseChangewave] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Flute1] nvarchar(255) NOT NULL,
    [F_Flute2] nvarchar(255) NOT NULL,
    [F_PreMeter] int NOT NULL,
    [F_Speed] int NOT NULL,
    CONSTRAINT [PK_TB_IPS_CruiseChangewave] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 小订单米数对应的巡航车速 */
IF OBJECT_ID(N'dbo.TB_IPS_CruiseOrderMeterSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CruiseOrderMeterSpeed] (
    [F_Meter] int NOT NULL,
    [F_Speed] int NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_CruiseOrderMeterSpeed] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 备卷未就绪 剩余米数对应的巡航车速 */
IF OBJECT_ID(N'dbo.TB_IPS_CuriseRamain', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_CuriseRamain] (
    [F_Remain] int NOT NULL,
    [F_Speed] int NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_CuriseRamain] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 糊机糊间隙基础设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_GlueGu', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_GlueGu] (
    [F_Flute] nvarchar(10) NOT NULL,
    [F_Position] int NOT NULL,
    [F_MinGlue] int NOT NULL,
    [F_MaxGlue] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_GlueGu] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 单面机糊间隙设置 */
IF OBJECT_ID(N'dbo.TB_IPS_GlueSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_GlueSF] (
    [F_Flute] nvarchar(10) NOT NULL,
    [F_MinGlue] int NOT NULL,
    [F_MaxGlue] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_GlueSF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 糊间隙车速系数设置 */
IF OBJECT_ID(N'dbo.TB_IPS_GlueSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_GlueSpeedCoef] (
    [F_Position] int NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_MinValue] int NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_GlueSpeedCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 坑机热喷雾设置 */
IF OBJECT_ID(N'dbo.TB_IPS_HotSpraySF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_HotSpraySF] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NULL,
    [F_Value] decimal(18,2) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_HotSpraySF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 三段热板蒸汽设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_HotSteam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_HotSteam] (
    [F_Flute] nvarchar(100) NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Part1] decimal(18,2) NOT NULL,
    [F_Part2] decimal(18,2) NOT NULL,
    [F_Part3] decimal(18,2) NOT NULL,
    [F_MinValue] decimal(18,2) NOT NULL,
    [F_MaxValue] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_HotSteam] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 三段热板蒸汽车速系数表 */
IF OBJECT_ID(N'dbo.TB_IPS_HotSteamSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_HotSteamSpeedCoef] (
    [F_Speed] int NOT NULL,
    [F_Coef3] decimal(18,2) NULL,
    [F_Coef4] decimal(18,2) NULL,
    [F_Coef5] decimal(18,2) NULL,
    [F_Coef6] decimal(18,2) NULL,
    [F_Coef7] decimal(18,2) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_HotSteamSpeedCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_MaterialQuaForMachine */
IF OBJECT_ID(N'dbo.TB_IPS_MaterialQuaForMachine', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_MaterialQuaForMachine] (
    [F_P04TID] int NULL,
    [F_ErpTableId] bigint NOT NULL,
    [F_MachinePsition] nvarchar(50) NOT NULL,
    [F_MaterialQua] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_Barcode] nvarchar(100) NOT NULL,
    [F_StartOrderId] int NOT NULL,
    [F_EndOrderId] int NULL,
    [F_GUID] nvarchar(200) NULL,
    [F_ErpStartRollMeters] int NULL,
    [F_StartSameMeters] int NULL,
    [F_EndSameMeters] int NULL,
    [F_StartRollMeters] int NULL,
    [F_EndRollMeters] int NULL,
    [F_StartTime] datetime2 NULL,
    [F_UpdateTime] datetime2 NULL,
    [F_EndTime] datetime2 NULL,
    [F_UseMeters] int NULL,
    [F_TheoryMaterialQua] nvarchar(50) NULL,
    [F_TheoryWidth] int NULL,
    [F_IsSameReplaceMaterialQua] bit NULL,
    [F_IsRelaceMaterialQua] bit NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_MaterialQuaForMachine] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_PressRoll */
IF OBJECT_ID(N'dbo.TB_IPS_PressRoll', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_PressRoll] (
    [F_MinWidth] int NOT NULL,
    [F_MaxWidth] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_MinPress] decimal(18,2) NOT NULL,
    [F_MaxPress] decimal(18,2) NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_PressRoll] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_PressRollCoef */
IF OBJECT_ID(N'dbo.TB_IPS_PressRollCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_PressRollCoef] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_CoefSF1] decimal(18,2) NOT NULL,
    [F_CoefSF2] decimal(18,2) NOT NULL,
    [F_CoefSF3] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_PressRollCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_PressRollSpeedCoef */
IF OBJECT_ID(N'dbo.TB_IPS_PressRollSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_PressRollSpeedCoef] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Machine] nvarchar(255) NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Coef] decimal(18,4) NOT NULL,
    CONSTRAINT [PK_TB_IPS_PressRollSpeedCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_PressRollWidth_MP */
IF OBJECT_ID(N'dbo.TB_IPS_PressRollWidth_MP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_PressRollWidth_MP] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Width] int NOT NULL,
    [F_Flute] nvarchar(255) NOT NULL,
    [F_Coef] decimal(18,4) NOT NULL,
    [F_Machine] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_TB_IPS_PressRollWidth_MP] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_IPS_PressRoll_MP */
IF OBJECT_ID(N'dbo.TB_IPS_PressRoll_MP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_PressRoll_MP] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Machine] nvarchar(255) NOT NULL,
    [F_Flute] nvarchar(255) NOT NULL,
    [F_WgtMin] decimal(18,4) NOT NULL,
    [F_WgtMax] decimal(18,4) NOT NULL,
    [F_ValueMin] decimal(18,4) NOT NULL,
    [F_ValueMax] decimal(18,4) NOT NULL,
    CONSTRAINT [PK_TB_IPS_PressRoll_MP] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 压力辊QDM系数表 */
IF OBJECT_ID(N'dbo.TB_IPS_QDMPressRollCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_QDMPressRollCoef] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_QdmID] int NOT NULL,
    [F_CoefSF1] decimal(18,2) NOT NULL,
    [F_CoefSF2] decimal(18,2) NOT NULL,
    [F_CoefSF3] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_TB_IPS_QDMPressRollCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 双面机糊机QDM系数 */
IF OBJECT_ID(N'dbo.TB_IPS_QdmCoefDF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_QdmCoefDF] (
    [F_Paper] nvarchar(100) NOT NULL,
    [F_Flute] nvarchar(10) NOT NULL,
    [F_Glue1] decimal(18,2) NOT NULL,
    [F_Glue2] decimal(18,2) NOT NULL,
    [F_Glue3] decimal(18,2) NOT NULL,
    [F_Wrap0] decimal(18,2) NOT NULL,
    [F_Wrap1] decimal(18,2) NOT NULL,
    [F_Wrap2] decimal(18,2) NOT NULL,
    [F_Wrap3] decimal(18,2) NOT NULL,
    [F_PreheaterSteam0] decimal(18,2) NOT NULL,
    [F_PreheaterSteam1] decimal(18,2) NOT NULL,
    [F_PreheaterSteam2] decimal(18,2) NOT NULL,
    [F_PreheaterSteam3] decimal(18,2) NOT NULL,
    [F_HotPlateSteam1] decimal(18,2) NOT NULL,
    [F_HotPlateSteam2] decimal(18,2) NOT NULL,
    [F_HotPlateSteam3] decimal(18,2) NOT NULL,
    [F_HotLoadGroupQty] decimal(18,2) NOT NULL,
    [F_HotPlatePress] decimal(18,2) NOT NULL,
    [F_ColdPlatePress] decimal(18,2) NOT NULL,
    [F_SplicerTensionLS0] decimal(18,2) NOT NULL,
    [F_BridgeTension1] decimal(18,2) NOT NULL,
    [F_BridgeTension2] decimal(18,2) NOT NULL,
    [F_BridgeTension3] decimal(18,2) NOT NULL,
    [F_Spray0] decimal(18,2) NOT NULL,
    [F_Spray1] decimal(18,2) NOT NULL,
    [F_Spray2] decimal(18,2) NOT NULL,
    [F_Spray3] decimal(18,2) NOT NULL,
    [F_CruiseSpeed] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_QdmCoefDF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 单面机QDM系数 */
IF OBJECT_ID(N'dbo.TB_IPS_QdmCoefSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_QdmCoefSF] (
    [F_MS] nvarchar(10) NOT NULL,
    [F_LS] nvarchar(10) NOT NULL,
    [F_Flute] nvarchar(10) NOT NULL,
    [F_Glue] decimal(18,2) NOT NULL,
    [F_WrapMS] decimal(18,2) NOT NULL,
    [F_WrapLS] decimal(18,2) NOT NULL,
    [F_PreheaterSteam] decimal(18,2) NOT NULL,
    [F_PressRoll] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll] decimal(18,2) NOT NULL,
    [F_SplicerTensionMS] decimal(18,2) NOT NULL,
    [F_SplicerTensionLS] decimal(18,2) NOT NULL,
    [F_VacuumBlower] decimal(18,2) NOT NULL,
    [F_Spray] decimal(18,2) NOT NULL,
    [F_CruiseSpeed] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_QdmCoefSF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* IPS控制模块显示/隐藏设置 */
IF OBJECT_ID(N'dbo.TB_IPS_VisibleSets', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_VisibleSets] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Code] nvarchar(255) NOT NULL,
    [F_Name] nvarchar(255) NOT NULL,
    [F_IsShow] bit NOT NULL,
    CONSTRAINT [PK_TB_IPS_VisibleSets] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 弯翘设备检测信息表 */
IF OBJECT_ID(N'dbo.TB_IPS_WarpInspect', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WarpInspect] (
    [F_Id] int IDENTITY(1,1) NOT NULL,
    [F_WarpState] nvarchar(100) NULL,
    [F_WarpDegree] decimal(18,4) NULL,
    [F_CreateTime] datetime2 NULL,
    CONSTRAINT [PK_TB_IPS_WarpInspect] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 弯翘调平设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_WarpSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WarpSet] (
    [F_Id] int IDENTITY(1,1) NOT NULL,
    [F_Position] int NOT NULL,
    [F_ThreeUp1] decimal(18,4) NULL,
    [F_ThreeUp2] decimal(18,4) NULL,
    [F_ThreeUp3] decimal(18,4) NULL,
    [F_ThreeDown1] decimal(18,4) NULL,
    [F_ThreeDown2] decimal(18,4) NULL,
    [F_ThreeDown3] decimal(18,4) NULL,
    [F_FourUp1] decimal(18,4) NULL,
    [F_FourUp2] decimal(18,4) NULL,
    [F_FourUp3] decimal(18,4) NULL,
    [F_FourDown1] decimal(18,4) NULL,
    [F_FourDown2] decimal(18,4) NULL,
    [F_FourDown3] decimal(18,4) NULL,
    [F_FiveUp1] decimal(18,4) NULL,
    [F_FiveUp2] decimal(18,4) NULL,
    [F_FiveUp3] decimal(18,4) NULL,
    [F_FiveDown1] decimal(18,4) NULL,
    [F_FiveDown2] decimal(18,4) NULL,
    [F_FiveDown3] decimal(18,4) NULL,
    [F_SixUp1] decimal(18,4) NULL,
    [F_SixUp2] decimal(18,4) NULL,
    [F_SixUp3] decimal(18,4) NULL,
    [F_SixDown1] decimal(18,4) NULL,
    [F_SixDown2] decimal(18,4) NULL,
    [F_SixDown3] decimal(18,4) NULL,
    [F_SevenUp1] decimal(18,4) NULL,
    [F_SevenUp2] decimal(18,4) NULL,
    [F_SevenUp3] decimal(18,4) NULL,
    [F_SevenDown1] decimal(18,4) NULL,
    [F_SevenDown2] decimal(18,4) NULL,
    [F_SevenDown3] decimal(18,4) NULL,
    CONSTRAINT [PK_TB_IPS_WarpSet] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 糊机烘缸包角设置 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapGU', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapGU] (
    [F_Position] int NOT NULL,
    [F_Flute] nvarchar(10) NOT NULL,
    [F_MinWrap] int NOT NULL,
    [F_MaxWrap] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapGU] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 包角基础设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapOfMP] (
    [F_Flag] int NOT NULL,
    [F_Position] int NOT NULL,
    [F_MinWrap] int NOT NULL,
    [F_MaxWrap] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_Coef] decimal(18,2) NULL,
    [F_AdustRange] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapOfMP] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 单面机烘缸包角设置 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapSF] (
    [F_Position] nvarchar(10) NOT NULL,
    [F_Flute] nvarchar(10) NOT NULL,
    [F_MinWrap] int NOT NULL,
    [F_MaxWrap] int NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapSF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 车速修正 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapSpeedOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapSpeedOfMP] (
    [F_Flag] int NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Value] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapSpeedOfMP] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 糊机烘缸蒸汽设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapSteamHPH', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapSteamHPH] (
    [F_Flute] nvarchar(100) NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_GU0] decimal(18,2) NULL,
    [F_GU1] decimal(18,2) NULL,
    [F_GU2] decimal(18,2) NULL,
    [F_GU3] decimal(18,2) NULL,
    [F_GUAdd1] decimal(18,2) NULL,
    [F_GUAdd2] decimal(18,2) NULL,
    [F_GUAdd3] decimal(18,2) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapSteamHPH] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 单面机烘缸蒸汽设置表 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapSteamSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapSteamSF] (
    [F_Flute] nvarchar(100) NOT NULL,
    [F_MinWeight] int NOT NULL,
    [F_MaxWeight] int NOT NULL,
    [F_Value] decimal(18,2) NOT NULL,
    [F_MinValue] decimal(18,2) NOT NULL,
    [F_MaxValue] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapSteamSF] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 单面机烘缸蒸汽车速系数表 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapSteamSFSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapSteamSFSpeedCoef] (
    [F_Speed] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapSteamSFSpeedCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 包角克重修正表 */
IF OBJECT_ID(N'dbo.TB_IPS_WrapWeightOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_IPS_WrapWeightOfMP] (
    [F_Flag] int NOT NULL,
    [F_Weight] int NOT NULL,
    [F_Value] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_IPS_WrapWeightOfMP] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 订单生产路线分配设置表 */
IF OBJECT_ID(N'dbo.TB_OrderRoute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_OrderRoute] (
    [F_OrderNum] int NOT NULL,
    [F_OrderName] nvarchar(20) NOT NULL,
    [F_CutoffAllocation] int NOT NULL,
    [F_OSDS] int NOT NULL,
    [F_IsDouble] bit NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_OrderRoute] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 订单扩展字段对应关系表 */
IF OBJECT_ID(N'dbo.TB_Order_JsonTrans', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Order_JsonTrans] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Code] nvarchar(50) NULL,
    [F_Name] nvarchar(50) NULL,
    [F_DataType] nvarchar(20) NULL,
    [F_IsShow] bit NOT NULL,
    [F_DCode] nvarchar(50) NOT NULL,
    [F_Sort] int NOT NULL,
    CONSTRAINT [PK_TB_Order_JsonTrans] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_PMS_CurrentShiftStopMes */
IF OBJECT_ID(N'dbo.TB_PMS_CurrentShiftStopMes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_CurrentShiftStopMes] (
    [F_CurrShiftNum] nvarchar(50) NULL,
    [F_StopTimesDF] int NULL,
    [F_StopDateTimeDF] int NULL,
    [F_CurrP04SIdDF] int NULL,
    [F_StopTimesSF1] int NULL,
    [F_StopDateTimeSF1] int NULL,
    [F_CurrP04SIdSF1] int NULL,
    [F_StopTimesSF2] int NULL,
    [F_StopDateTimeSF2] int NULL,
    [F_CurrP04SIdSF2] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_PMS_CurrentShiftStopMes] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_PMS_EnergyMaintenance */
IF OBJECT_ID(N'dbo.TB_PMS_EnergyMaintenance', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_EnergyMaintenance] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_P04TID] int NOT NULL,
    [F_ShiftNum] nvarchar(20) NULL,
    [F_StartTime] datetime2 NULL,
    [F_EndTime] datetime2 NULL,
    [F_Number] nvarchar(50) NULL,
    [F_Name] nvarchar(50) NULL,
    [F_StartValue] decimal(18,4) NULL,
    [F_EndValue] decimal(18,4) NULL,
    [F_DiffValue] decimal(18,4) NULL,
    [F_Price] decimal(10,2) NULL,
    [F_Source] nvarchar(50) NULL,
    [F_ShowPrice] bit NULL,
    CONSTRAINT [PK_TB_PMS_EnergyMaintenance] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 标签打印设置 */
IF OBJECT_ID(N'dbo.TB_PMS_LabelPrint', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_LabelPrint] (
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_CN] int NOT NULL,
    [F_CutWidth] int NOT NULL,
    [F_LabelQty] int NOT NULL,
    CONSTRAINT [PK_TB_PMS_LabelPrint] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_PMS_LineMsg */
IF OBJECT_ID(N'dbo.TB_PMS_LineMsg', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_LineMsg] (
    [F_IsRun] bit NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_PMS_LineMsg] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_PMS_Report_Class */
IF OBJECT_ID(N'dbo.TB_PMS_Report_Class', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_Report_Class] (
    [P04T_ID] int NULL,
    [P04T_ShiftNumber] nvarchar(20) NULL,
    [P04T_GroupNameShift] nvarchar(20) NULL,
    [P04T_Year] int NULL,
    [P04T_Month] int NULL,
    [P04T_Day] int NULL,
    [P04T_WeekDay] nvarchar(30) NULL,
    [P04T_Week] int NULL,
    [P04T_StartTime] datetime2 NULL,
    [P04T_EndTime] datetime2 NULL,
    [P04T_StartYearMontDay] datetime2 NULL,
    [P04P_StartTime] datetime2 NULL,
    [P04P_EndTime] datetime2 NULL,
    [P04T_ProduceTime] decimal(28,2) NULL,
    [P04T_OrderStopTime] int NULL,
    [P04T_OrderStopNum] int NULL,
    [P04T_ScheduleMeter] float NULL,
    [P04T_ProduceMeter] float NULL,
    [P04T_BadMeter] float NULL,
    [P04T_GoodMeter] float NULL,
    [P04T_ScheduleArea] float NULL,
    [P04T_ProduceArea] float NULL,
    [P04T_BadArea] float NULL,
    [P04T_GoodArea] float NULL,
    [P04T_ScheduleSheet] bigint NULL,
    [P04T_ProduceSheet] bigint NULL,
    [P04T_BadSheet] bigint NULL,
    [P04T_GoodSheet] bigint NULL,
    [P04T_AvgSpeed] decimal(28,2) NULL,
    [P04T_BadPercent] decimal(18,6) NULL,
    [P04T_TrimArea] float NULL,
    [P04T_TrimPecent] decimal(18,6) NULL,
    [P04T_OrderNum] bigint NULL,
    [P04T_AvgWidth] int NULL,
    [P04T_AvgMeter] decimal(18,2) NULL,
    [P04T_PaperCodeNum] int NULL,
    [P04T_PaperCodeAvgMeter] decimal(18,2) NULL,
    [P04T_BadOrderNum] int NULL,
    [P04T_BadMuchNum] int NULL,
    [P04T_OrderNumUp] bigint NULL,
    [P04T_OrderNumUp_All] bigint NULL,
    [P04T_OrderNumDown] bigint NULL,
    [P04T_CountWidth] float NULL,
    [P04T_IsEnd] bit NULL,
    [P04T_AccumulatedSteamFlow] decimal(18,4) NULL,
    [P04T_AccumulatedElectricity] decimal(18,4) NULL,
    [P04T_TheoryWeight] decimal(18,4) NULL,
    [P04T_SteamRate] decimal(18,4) NULL,
    [P04T_ElectricityRate] decimal(18,4) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_PMS_Report_Class] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_PMS_StopReasonRecord */
IF OBJECT_ID(N'dbo.TB_PMS_StopReasonRecord', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_PMS_StopReasonRecord] (
    [F_P04SID] int NOT NULL,
    [F_StopReason] nvarchar(200) NOT NULL,
    [F_StopReasonID] int NOT NULL,
    [F_StopType] nvarchar(200) NOT NULL,
    [F_StopTypeID] int NOT NULL,
    [F_StatisticsStop] bit NOT NULL,
    [F_PartName] nvarchar(50) NOT NULL,
    [F_CreateUser] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_UpdateUser] nvarchar(50) NULL,
    [F_UpdateTime] datetime2 NULL,
    [F_Remark] nvarchar(500) NULL,
    [F_IsModify] bit NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_PMS_StopReasonRecord] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_Plc_AcceleratorSet */
IF OBJECT_ID(N'dbo.TB_Plc_AcceleratorSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_AcceleratorSet] (
    [F_Speed] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_AcceleratorSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC设备表 */
IF OBJECT_ID(N'dbo.TB_Plc_Driver', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_Driver] (
    [F_Code] nvarchar(36) NOT NULL,
    [F_Name] nvarchar(100) NOT NULL,
    [F_CommunicationType] int NOT NULL,
    [F_ConfigCode] nvarchar(36) NOT NULL,
    [F_IsUse] bit NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_Driver] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC设备配置表 */
IF OBJECT_ID(N'dbo.TB_Plc_DriverConfig', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_DriverConfig] (
    [F_Code] nvarchar(36) NOT NULL,
    [F_Name] nvarchar(100) NULL,
    [F_Desc] nvarchar(max) NULL,
    [F_ParCode] nvarchar(100) NULL,
    [F_ParValue] nvarchar(100) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_DriverConfig] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC点位配置表 */
IF OBJECT_ID(N'dbo.TB_Plc_PointVar', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_PointVar] (
    [F_Code] nvarchar(200) NOT NULL,
    [F_Name] nvarchar(100) NULL,
    [F_Desc] nvarchar(100) NULL,
    [F_DriverCode] nvarchar(36) NULL,
    [F_VarAddress] nvarchar(100) NULL,
    [F_DataType] nvarchar(36) NULL,
    [F_RW] int NOT NULL,
    [F_Interval] int NOT NULL,
    [F_Priority] int NOT NULL,
    [F_IsUse] bit NULL,
    [F_CurValue] nvarchar(100) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Position] nvarchar(50) NULL,
    [F_IsAlarm] bit NOT NULL,
    [F_AlarmInterval] int NOT NULL,
    [F_AlarmOffset] decimal(18,2) NOT NULL,
    [F_DataOKAddress] nvarchar(100) NULL,
    [F_DataOKDataType] nvarchar(36) NULL,
    [F_TransferKeyAddress] nvarchar(100) NULL,
    [F_TransferKeyDataType] nvarchar(36) NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_PointVar] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC喷雾设置 */
IF OBJECT_ID(N'dbo.TB_Plc_SpraySet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_SpraySet] (
    [F_Flute] nvarchar(10) NOT NULL,
    [F_MinPower] decimal(18,2) NOT NULL,
    [F_MaxPower] decimal(18,2) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_CoefUp] decimal(18,2) NOT NULL,
    [F_CoefMid] decimal(18,2) NOT NULL,
    [F_CoefDown] decimal(18,2) NOT NULL,
    [F_CoefDF] decimal(18,2) NOT NULL,
    [F_Speed30] decimal(18,2) NOT NULL,
    [F_Speed50] decimal(18,2) NOT NULL,
    [F_Speed80] decimal(18,2) NOT NULL,
    [F_Speed110] decimal(18,2) NOT NULL,
    [F_Speed130] decimal(18,2) NOT NULL,
    [F_Speed160] decimal(18,2) NOT NULL,
    [F_Speed180] decimal(18,2) NOT NULL,
    [F_Speed210] decimal(18,2) NOT NULL,
    [F_Speed240] decimal(18,2) NOT NULL,
    [F_Speed270] decimal(18,2) NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_SpraySet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC喷雾车速系数表 */
IF OBJECT_ID(N'dbo.TB_Plc_SpraySpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_SpraySpeedCoef] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Coef] decimal(18,2) NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_SpraySpeedCoef] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC喷嘴设置 */
IF OBJECT_ID(N'dbo.TB_Plc_SprayWidthSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Plc_SprayWidthSet] (
    [F_Code] int NOT NULL,
    [F_Width] int NOT NULL,
    [F_IsUse] bit NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Plc_SprayWidthSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 延时自动 */
IF OBJECT_ID(N'dbo.TB_QDM_AutoDelay', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_AutoDelay] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Glue] int NULL,
    [F_Wrap] int NULL,
    [F_Tension] int NULL,
    [F_PressRollPress] int NULL,
    [F_CorrugatedRollPress] int NULL,
    [F_Steam] int NULL,
    [F_Spray] int NULL,
    [F_LoadingSystemQty] int NULL,
    [F_OffsetTension] int NULL,
    [F_HotPlateSteam] int NULL,
    [F_HotPlatePress] int NULL,
    [F_ColdPlatePress] int NULL,
    [F_Type] int NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_CruiseSpeed] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_AutoDelay] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* BHS喷雾 */
IF OBJECT_ID(N'dbo.TB_QDM_BHSSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_BHSSpray] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_MinPercentage] decimal(18,2) NOT NULL,
    [F_MaxPercentage] decimal(18,2) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_BHSSpray] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* BHS热喷雾车速系数 */
IF OBJECT_ID(N'dbo.TB_QDM_BHSSpraySpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_BHSSpraySpeedFactor] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Factor] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_BHSSpraySpeedFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 泠凝回水备压 */
IF OBJECT_ID(N'dbo.TB_QDM_BackWaterForPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_BackWaterForPress] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_HighPreDecompressionIV] decimal(18,2) NOT NULL,
    [F_HighPreDecompressionEV] decimal(18,2) NOT NULL,
    [F_LowPreDecompressionIV] decimal(18,2) NOT NULL,
    [F_LowPreDecompressionEV] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_BackWaterForPress] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 天桥张力楞型系数 */
IF OBJECT_ID(N'dbo.TB_QDM_BridgeFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_BridgeFluteFactor] (
    [F_Position] nvarchar(50) NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_FluteFactor] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_BridgeFluteFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 天桥张力克重表 */
IF OBJECT_ID(N'dbo.TB_QDM_BridgeTension', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_BridgeTension] (
    [F_Position] nvarchar(50) NULL,
    [F_MinTension] int NULL,
    [F_MaxTension] int NULL,
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_GramFactor] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_BridgeTension] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 冷板压力 */
IF OBJECT_ID(N'dbo.TB_QDM_ColdPlatePressure', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_ColdPlatePressure] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_AirPress] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_ColdPlatePressure] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 瓦楞楞型部位系数 */
IF OBJECT_ID(N'dbo.TB_QDM_CorrugatedFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_CorrugatedFluteFactor] (
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_CorrugatedRollPre_ID] int NOT NULL,
    [F_Position] nvarchar(50) NOT NULL,
    [F_Flute] nvarchar(50) NOT NULL,
    [F_Factor] decimal(18,2) NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_CorrugatedFluteFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 瓦楞辊压力 */
IF OBJECT_ID(N'dbo.TB_QDM_CorrugatedRollerPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_CorrugatedRollerPress] (
    [F_MinWidth] int NOT NULL,
    [F_MaxWidth] int NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_WidthFactor] decimal(18,2) NOT NULL,
    [F_MinPressure] int NOT NULL,
    [F_MaxPressure] int NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_DSFactor] decimal(18,2) NOT NULL,
    [F_OSFactor] decimal(18,2) NOT NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_CorrugatedRollerPress] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 坑机车速巡航 */
IF OBJECT_ID(N'dbo.TB_QDM_CruisingSFSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_CruisingSFSpeed] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinSpeed] int NOT NULL,
    [F_MaxSpeed] int NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_CruisingSFSpeed] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 车速巡航 */
IF OBJECT_ID(N'dbo.TB_QDM_CruisingSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_CruisingSpeed] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinSpeed] int NOT NULL,
    [F_MaxSpeed] int NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_CruisingSpeed] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_DataBase_DF */
IF OBJECT_ID(N'dbo.TB_QDM_DataBase_DF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_DataBase_DF] (
    [F_DF_MaterialQua] nvarchar(50) NULL,
    [F_DF_Flute] nvarchar(50) NULL,
    [F_Glue_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [F_Glue_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [F_Wrap_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [F_Wrap_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [F_Wrap_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [F_PreheaterSteam_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [F_PreheaterSteam_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [F_PreheaterSteam_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [F_HotPlateSteam_DF_1Part_QDM_Factor] decimal(18,2) NULL,
    [F_HotPlateSteam_DF_2Part_QDM_Factor] decimal(18,2) NULL,
    [F_HotPlateSteam_DF_3Part_QDM_Factor] decimal(18,2) NULL,
    [F_HotLoadGroupQty_DF_QDM_Factor] decimal(18,2) NULL,
    [F_HotPlatePress_DF_QDM_Factor] decimal(18,2) NULL,
    [F_ColdPlatePress_DF_QDM_Factor] decimal(18,2) NULL,
    [F_SplicerTension_LS0_QDM_FactorLS0] decimal(18,2) NULL,
    [F_BridgeTension_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [F_BridgeTension_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [F_Spray_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [F_Spray_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [F_CruisingSpeed_DF_QDM_Factor] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_DataBase_DF] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_DataBase_List */
IF OBJECT_ID(N'dbo.TB_QDM_DataBase_List', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_DataBase_List] (
    [F_MaterialQua] nvarchar(50) NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_DF_Id] int NULL,
    [F_SF1_Id] int NULL,
    [F_SF2_Id] int NULL,
    [F_SF3_Id] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_DataBase_List] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_DataBase_SF1 */
IF OBJECT_ID(N'dbo.TB_QDM_DataBase_SF1', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_DataBase_SF1] (
    [F_SF1_MaterialQua] nvarchar(50) NULL,
    [F_SF1_Flute] nvarchar(50) NULL,
    [F_SF1_LineFlute] nvarchar(50) NULL,
    [F_Glue_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_Wrap_MS1_QDM_FactorMS1] decimal(18,2) NULL,
    [F_Wrap_LS1_QDM_FactorLS1] decimal(18,2) NULL,
    [F_PreheaterSteam_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_PressRoll_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_CorrugatedRoll_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_SplicerTension_MS1_QDM_FactorMS1] decimal(18,2) NULL,
    [F_SplicerTension_LS1_QDM_FactorLS1] decimal(18,2) NULL,
    [F_VacuumBlower_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_Spray_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [F_CruisingSpeed_SF1_QDM_Factor] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_DataBase_SF1] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_DataBase_SF2 */
IF OBJECT_ID(N'dbo.TB_QDM_DataBase_SF2', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_DataBase_SF2] (
    [F_SF2_MaterialQua] nvarchar(50) NULL,
    [F_SF2_Flute] nvarchar(50) NULL,
    [F_SF2_LineFlute] nvarchar(50) NULL,
    [F_Glue_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_Wrap_MS2_QDM_FactorMS2] decimal(18,2) NULL,
    [F_Wrap_LS2_QDM_FactorLS2] decimal(18,2) NULL,
    [F_PreheaterSteam_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_PressRoll_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_CorrugatedRoll_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_SplicerTension_MS2_QDM_FactorMS2] decimal(18,2) NULL,
    [F_SplicerTension_LS2_QDM_FactorLS2] decimal(18,2) NULL,
    [F_VacuumBlower_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_Spray_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [F_CruisingSpeed_SF2_QDM_Factor] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_DataBase_SF2] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 当前运行参数(包含各种QMD系数和界面系数以及是否启用) */
IF OBJECT_ID(N'dbo.TB_QDM_FormSetFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_FormSetFactor] (
    [F_Glue_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [F_Glue_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_Glue_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_Glue_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_LS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_Wrap_LS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_Wrap_LS3_Form_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_MS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_Wrap_MS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_Wrap_MS3_Form_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [F_PressRoll_SF1_OS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_PressRoll_SF1_DS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_PressRoll_SF2_OS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_PressRoll_SF2_DS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_PressRoll_SF3_OS_Form_Factor] decimal(18,2) NOT NULL,
    [F_PressRoll_SF3_DS_Form_Factor] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF1_OS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF1_DS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF2_OS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF2_DS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF3_OS_Form_Factor] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF3_DS_Form_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_1Part_Form_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_2Part_Form_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_3Part_Form_Factor] decimal(18,2) NOT NULL,
    [F_HotLoadGroupQty_DF_Form_Factor] decimal(18,2) NOT NULL,
    [F_HotPlatePress_DF_Form_Factor] decimal(18,2) NOT NULL,
    [F_ColdPlatePress_DF_Form_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS0_Form_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS3_Form_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS3_Form_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [F_Spray_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [F_Spray_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_Spray_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [F_Spray_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [F_Spray_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [F_CruisingSpeed_DF_Form_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_1st_Form_IsOpen] bit NOT NULL,
    [F_Glue_GU_2nd_Form_IsOpen] bit NOT NULL,
    [F_Glue_GU_3rd_Form_IsOpen] bit NOT NULL,
    [F_Glue_SF1_Form_IsOpen] bit NOT NULL,
    [F_Glue_SF2_Form_IsOpen] bit NOT NULL,
    [F_Glue_SF3_Form_IsOpen] bit NOT NULL,
    [F_Wrap_GU_0_Form_IsOpen] bit NOT NULL,
    [F_Wrap_GU_1st_Form_IsOpen] bit NOT NULL,
    [F_Wrap_GU_2nd_Form_IsOpen] bit NOT NULL,
    [F_Wrap_GU_3rd_Form_IsOpen] bit NOT NULL,
    [F_Wrap_LS1_Form_IsOpen] bit NOT NULL,
    [F_Wrap_LS2_Form_IsOpen] bit NOT NULL,
    [F_Wrap_LS3_Form_IsOpen] bit NOT NULL,
    [F_Wrap_MS1_Form_IsOpen] bit NOT NULL,
    [F_Wrap_MS2_Form_IsOpen] bit NOT NULL,
    [F_Wrap_MS3_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_GU_0_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_GU_1st_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_GU_2nd_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_GU_3rd_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_SF1_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_SF2_Form_IsOpen] bit NOT NULL,
    [F_PreheaterSteam_SF3_Form_IsOpen] bit NOT NULL,
    [F_PressRoll_SF1_Form_IsOpen] bit NOT NULL,
    [F_PressRoll_SF2_Form_IsOpen] bit NOT NULL,
    [F_PressRoll_SF3_Form_IsOpen] bit NOT NULL,
    [F_CorrugatedRoll_SF1_Form_IsOpen] bit NOT NULL,
    [F_CorrugatedRoll_SF2_Form_IsOpen] bit NOT NULL,
    [F_CorrugatedRoll_SF3_Form_IsOpen] bit NOT NULL,
    [F_HotPlateSteam_DF_1Part_Form_IsOpen] bit NOT NULL,
    [F_HotPlateSteam_DF_2Part_Form_IsOpen] bit NOT NULL,
    [F_HotPlateSteam_DF_3Part_Form_IsOpen] bit NOT NULL,
    [F_HotLoadGroupQty_DF_Form] bit NOT NULL,
    [F_HotPlatePress_DF_Form_IsOpen] bit NOT NULL,
    [F_ColdPlatePress_DF_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_LS0_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_MS1_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_LS1_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_MS2_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_LS2_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_MS3_Form_IsOpen] bit NOT NULL,
    [F_SplicerTension_LS3_Form_IsOpen] bit NOT NULL,
    [F_BridgeTension_GU_1st_Form_IsOpen] bit NOT NULL,
    [F_BridgeTension_GU_2nd_Form_IsOpen] bit NOT NULL,
    [F_BridgeTension_GU_3rd_Form_IsOpen] bit NOT NULL,
    [F_VacuumBlower_SF1_Form_IsOpen] bit NOT NULL,
    [F_VacuumBlower_SF2_Form_IsOpen] bit NOT NULL,
    [F_VacuumBlower_SF3_Form_IsOpen] bit NOT NULL,
    [F_Spray_GU_0_Form_IsOpen] bit NOT NULL,
    [F_Spray_GU_2nd_Form_IsOpen] bit NOT NULL,
    [F_Spray_SF1_Form_IsOpen] bit NOT NULL,
    [F_Spray_SF2_Form_IsOpen] bit NOT NULL,
    [F_Spray_SF3_Form_IsOpen] bit NOT NULL,
    [F_CruisingSpeed_ALL_Form_IsOpen] bit NOT NULL,
    [F_CruisingSpeed_DF_Form_IsOpen] bit NOT NULL,
    [F_CruisingSpeed_SF1_Form_IsOpen] bit NOT NULL,
    [F_CruisingSpeed_SF2_Form_IsOpen] bit NOT NULL,
    [F_CruisingSpeed_SF3_Form_IsOpen] bit NOT NULL,
    [F_Glue_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Glue_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_Glue_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_Glue_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_LS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_Wrap_LS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_Wrap_LS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Wrap_MS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_Wrap_MS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_Wrap_MS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_PreheaterSteam_SF3_Form] decimal(18,2) NOT NULL,
    [F_PressRoll_SF1_OS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_PressRoll_SF1_DS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_PressRoll_SF2_OS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_PressRoll_SF2_DS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_PressRoll_SF3_OS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_PressRoll_SF3_DS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF1_OS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF1_DS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF2_OS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF2_DS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF3_OS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_CorrugatedRoll_SF3_DS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_1Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_2Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_HotPlateSteam_DF_3Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_HotLoadGroupQty_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_HotPlatePress_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_ColdPlatePress_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_SplicerTension_MS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_SplicerTension_LS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_BridgeTension_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_VacuumBlower_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Spray_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Spray_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Spray_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [F_Spray_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [F_Spray_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_CruisingSpeed_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [F_Glue_GU_1st_Form_IsOn] bit NULL,
    [F_Glue_GU_2nd_Form_IsOn] bit NULL,
    [F_Glue_GU_3rd_Form_IsOn] bit NULL,
    [F_Wrap_GU_1st_Form_IsOn] bit NULL,
    [F_Wrap_GU_2nd_Form_IsOn] bit NULL,
    [F_Wrap_GU_3rd_Form_IsOn] bit NULL,
    [F_RidingRoll_1st_Form_Factor] decimal(18,2) NOT NULL,
    [F_RidingRoll_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [F_RidingRoll_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [F_RidingRoll_1st_Form_IsOpen] bit NOT NULL,
    [F_RidingRoll_2nd_Form_IsOpen] bit NOT NULL,
    [F_RidingRoll_3rd_Form_IsOpen] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    [F_Warp_Form_IsOpen] bit NOT NULL,
    CONSTRAINT [PK_TB_QDM_FormSetFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 糊盆液位 */
IF OBJECT_ID(N'dbo.TB_QDM_GlueLiquidLevel', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_GlueLiquidLevel] (
    [F_MeasureLiquidHeight] int NULL,
    [F_LiquidHeight] int NOT NULL,
    [F_GlueLiquidHeight] int NOT NULL,
    [F_AlarmLiquidHeight] int NOT NULL,
    [F_LoadingSpeed] int NOT NULL,
    [F_HaltLiquidHeight] int NOT NULL,
    [F_IsActive] bit NOT NULL,
    [F_IsAlarm] bit NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Position] nvarchar(50) NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_GlueLiquidLevel] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 糊间隙车速 */
IF OBJECT_ID(N'dbo.TB_QDM_GlueSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_GlueSpeed] (
    [F_Speed] int NULL,
    [F_SpeedFactor] decimal(18,2) NULL,
    [F_Positon] nvarchar(50) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_GlueSpeed] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 压板组数 */
IF OBJECT_ID(N'dbo.TB_QDM_HotLoadGroupQty', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_HotLoadGroupQty] (
    [F_Flute] nvarchar(50) NULL,
    [F_StartLoadSpeed] int NULL,
    [F_StartLoadGroupQty] int NULL,
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_MinGramFullLoadSpeed] int NULL,
    [F_MaxGramFullLoadSpeed] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_SortNo] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_HotLoadGroupQty] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 热板克重气压 */
IF OBJECT_ID(N'dbo.TB_QDM_HotPlateGramAirPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_HotPlateGramAirPress] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinPressure] decimal(18,2) NOT NULL,
    [F_MaxPressure] decimal(18,2) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_FluteFactor] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_HotPlateGramAirPress] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 热板蒸汽压力 */
IF OBJECT_ID(N'dbo.TB_QDM_HotPlateSteamGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_HotPlateSteamGram] (
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinSteam] decimal(18,2) NOT NULL,
    [F_MaxSteam] decimal(18,2) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_PrPressIncrease] int NULL,
    [F_Offset_1st] decimal(18,2) NULL,
    [F_Offset_2nd] decimal(18,2) NULL,
    [F_Offset_3rd] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_HotPlateSteamGram] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_HotPlateSteamGramRange */
IF OBJECT_ID(N'dbo.TB_QDM_HotPlateSteamGramRange', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_HotPlateSteamGramRange] (
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_SortNo] int NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_HotPlateSteamGramRange] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_HotPlateSteamSpeed */
IF OBJECT_ID(N'dbo.TB_QDM_HotPlateSteamSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_HotPlateSteamSpeed] (
    [F_Speed] int NULL,
    [F_SpeedFactor] decimal(18,2) NULL,
    [F_Layer] int NULL,
    [F_Range_Id] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_SortNo] int NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_HotPlateSteamSpeed] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* Qdm更改通知表 */
IF OBJECT_ID(N'dbo.TB_QDM_Notice', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_Notice] (
    [F_Type] nvarchar(50) NULL,
    [F_IsModify] bit NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_Notice] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* PLC喷雾 */
IF OBJECT_ID(N'dbo.TB_QDM_PLCSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PLCSpray] (
    [F_MinPower] decimal(18,2) NOT NULL,
    [F_MaxPower] decimal(18,2) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_Factor] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Flute] nvarchar(50) NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PLCSpray] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* PLC热喷雾车速系数 */
IF OBJECT_ID(N'dbo.TB_QDM_PLCSpraySpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PLCSpraySpeedFactor] (
    [F_Flute] nvarchar(50) NOT NULL,
    [F_Speed] int NOT NULL,
    [F_Factor] decimal(18,2) NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PLCSpraySpeedFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* PLC喷雾门幅 */
IF OBJECT_ID(N'dbo.TB_QDM_PLCSprayWidth', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PLCSprayWidth] (
    [F_MinWidth] int NOT NULL,
    [F_MaxWidth] int NOT NULL,
    [F_LeftPosition] int NOT NULL,
    [F_RightPosition] int NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PLCSprayWidth] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 点位设置表 */
IF OBJECT_ID(N'dbo.TB_QDM_Point', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_Point] (
    [F_PointName] nvarchar(50) NULL,
    [F_Type] nvarchar(50) NOT NULL,
    [F_Position] nvarchar(50) NOT NULL,
    [F_PositionTable] nvarchar(50) NULL,
    [F_Parameter] int NULL,
    [F_Parameter2] int NULL,
    [F_ParameterRW] int NULL,
    [F_Encoded] nvarchar(200) NOT NULL,
    [F_SortNo] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_IsDelete] bit NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_Point] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 烘缸蒸汽设置 */
IF OBJECT_ID(N'dbo.TB_QDM_PreheaterSteam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PreheaterSteam] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Flute] nvarchar(50) NOT NULL,
    [F_MinGram] decimal(18,2) NOT NULL,
    [F_MaxGram] decimal(18,2) NOT NULL,
    [F_MinAirPress] decimal(18,2) NOT NULL,
    [F_MaxAirPress] decimal(18,2) NOT NULL,
    [F_PrBoost] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PreheaterSteam] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_PreheaterSteamSpeed */
IF OBJECT_ID(N'dbo.TB_QDM_PreheaterSteamSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PreheaterSteamSpeed] (
    [F_Speed] int NULL,
    [F_SpeedFactor] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PreheaterSteamSpeed] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 压力辊压力 */
IF OBJECT_ID(N'dbo.TB_QDM_PressRollPressure', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PressRollPressure] (
    [F_MaxWidth] int NOT NULL,
    [F_MinWidth] int NOT NULL,
    [F_WidthFactor] decimal(18,2) NULL,
    [F_MaxPressure] int NULL,
    [F_MinPressure] int NULL,
    [F_MaxGram] decimal(18,2) NULL,
    [F_MinGram] decimal(18,2) NULL,
    [F_DriverFactor] decimal(18,2) NULL,
    [F_OperationFactor] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PressRollPressure] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 压力辊部位楞型系数 */
IF OBJECT_ID(N'dbo.TB_QDM_PressRollPressureFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_PressRollPressureFactor] (
    [F_Position] nvarchar(36) NOT NULL,
    [F_Flute] nvarchar(100) NOT NULL,
    [F_Factor] decimal(18,2) NOT NULL,
    [F_PressRollPressure_ID] int NOT NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_PressRollPressureFactor] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* TB_QDM_RidingRollerExtrusion */
IF OBJECT_ID(N'dbo.TB_QDM_RidingRollerExtrusion', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_RidingRollerExtrusion] (
    [Wave] nvarchar(50) NOT NULL,
    [ExtrusionFactor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_RidingRollerExtrusion] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* TB_QDM_RidingRollerSet */
IF OBJECT_ID(N'dbo.TB_QDM_RidingRollerSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_RidingRollerSet] (
    [CorrugatedRollCode] nvarchar(50) NOT NULL,
    [Deep] decimal(18,2) NOT NULL,
    [RidingDeep] decimal(18,2) NOT NULL,
    [MinValue] decimal(18,2) NOT NULL,
    [MaxValue] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_RidingRollerSet] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* SF糊间隙克重表 */
IF OBJECT_ID(N'dbo.TB_QDM_SFGlueGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_SFGlueGram] (
    [F_Position] nvarchar(50) NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_MinGlueGap] int NULL,
    [F_MaxGlueGap] int NULL,
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_FluteFactor] decimal(18,2) NULL,
    [F_SortNo] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_SFGlueGram] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 接纸机张力克重差值表 */
IF OBJECT_ID(N'dbo.TB_QDM_SplicerGramDiff', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_SplicerGramDiff] (
    [F_MinDiff] int NULL,
    [F_MaxDiff] int NULL,
    [F_Offset] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_SplicerGramDiff] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_SplicerTensionFactor */
IF OBJECT_ID(N'dbo.TB_QDM_SplicerTensionFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_SplicerTensionFactor] (
    [F_LS0_TensionFactor] decimal(18,2) NULL,
    [F_MS1_TensionFactor] decimal(18,2) NULL,
    [F_LS1_TensionFactor] decimal(18,2) NULL,
    [F_MS2_TensionFactor] decimal(18,2) NULL,
    [F_LS2_TensionFactor] decimal(18,2) NULL,
    [F_MS3_TensionFactor] decimal(18,2) NULL,
    [F_LS3_TensionFactor] decimal(18,2) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_SplicerTensionFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* QDM基准值 */
IF OBJECT_ID(N'dbo.TB_QDM_StandardValue', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_StandardValue] (
    [F_QDMId] int NULL,
    [F_PositonTable] nvarchar(50) NULL,
    [F_Type] nvarchar(50) NULL,
    [F_MaterialQua] nvarchar(50) NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_Position_Material] nvarchar(50) NULL,
    [F_Position_Flute] nvarchar(50) NULL,
    [F_Position] nvarchar(50) NULL,
    [F_MinWidth] int NULL,
    [F_MaxWidth] int NULL,
    [F_Speed] int NULL,
    [F_Part] int NULL,
    [F_StandardValue] decimal(18,2) NULL,
    [F_MinValue] decimal(18,2) NULL,
    [F_MaxValue] decimal(18,2) NULL,
    [F_Encoded] nvarchar(200) NULL,
    [F_EncodedOther] nvarchar(200) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_StandardValue] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 张力车速系数 */
IF OBJECT_ID(N'dbo.TB_QDM_TensionSpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_TensionSpeedFactor] (
    [F_Speed] int NULL,
    [F_Factor] decimal(18,2) NULL,
    [F_Type] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_TensionSpeedFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 张力门幅系数 */
IF OBJECT_ID(N'dbo.TB_QDM_TensionWidthFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_TensionWidthFactor] (
    [F_MinWidth] int NULL,
    [F_MaxWidth] int NULL,
    [F_WidthFactor] decimal(18,2) NULL,
    [F_Type] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_TensionWidthFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 真空泵参数设置 */
IF OBJECT_ID(N'dbo.TB_QDM_VacuumBlower', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_VacuumBlower] (
    [F_MaxWidth] int NOT NULL,
    [F_MinWidth] int NOT NULL,
    [F_WidthFactor] decimal(18,2) NULL,
    [F_MinSpeedRatio] decimal(18,2) NULL,
    [F_MaxSpeedRatio] decimal(18,2) NULL,
    [F_MaxGram] decimal(18,2) NULL,
    [F_MinGram] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_VacuumBlower] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 真空泵基础设置 */
IF OBJECT_ID(N'dbo.TB_QDM_VacuumBlowerBaseSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_VacuumBlowerBaseSet] (
    [PaperCode] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [SpeedRatio] decimal(18,4) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_VacuumBlowerBaseSet] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 真空泵部位楞型系数 */
IF OBJECT_ID(N'dbo.TB_QDM_VacuumBlowerFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_VacuumBlowerFluteFactor] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_Factor] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_VacuumBlower_Id] int NOT NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_VacuumBlowerFluteFactor] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* TB_QDM_VacuumBlowerSpeedFactor */
IF OBJECT_ID(N'dbo.TB_QDM_VacuumBlowerSpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_VacuumBlowerSpeedFactor] (
    [Speed] int NOT NULL,
    [Factor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_VacuumBlowerSpeedFactor] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* TB_QDM_VacuumBlowerWidthFactor */
IF OBJECT_ID(N'dbo.TB_QDM_VacuumBlowerWidthFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_VacuumBlowerWidthFactor] (
    [Width] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [Factor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_VacuumBlowerWidthFactor] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 弯翘包角 */
IF OBJECT_ID(N'dbo.TB_QDM_WarpedWrap', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_WarpedWrap] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_Equipment] nvarchar(50) NOT NULL,
    [F_UpWarpLight3rd] decimal(18,2) NULL,
    [F_UpWarpModerate3rd] decimal(18,2) NULL,
    [F_UpWarpSevere3rd] decimal(18,2) NULL,
    [F_DownWarpLight3rd] decimal(18,2) NULL,
    [F_DownWarpModerate3rd] decimal(18,2) NULL,
    [F_DownWarpSevere3rd] decimal(18,2) NULL,
    [F_UpWarpLight5ve] decimal(18,2) NULL,
    [F_UpWarpModerate5ve] decimal(18,2) NULL,
    [F_UpWarpSevere5ve] decimal(18,2) NULL,
    [F_DownWarpLight5ve] decimal(18,2) NULL,
    [F_DownWarpModerate5ve] decimal(18,2) NULL,
    [F_DownWarpSevere5ve] decimal(18,2) NULL,
    [F_UpWarpLight7en] decimal(18,2) NULL,
    [F_UpWarpModerate7en] decimal(18,2) NULL,
    [F_UpWarpSevere7en] decimal(18,2) NULL,
    [F_DownWarpLight7en] decimal(18,2) NULL,
    [F_DownWarpModerate7en] decimal(18,2) NULL,
    [F_DownWarpSevere7en] decimal(18,2) NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_WarpedWrap] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 包角楞型系数 */
IF OBJECT_ID(N'dbo.TB_QDM_WrapFlute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_WrapFlute] (
    [F_Position] nvarchar(50) NULL,
    [F_Flute] nvarchar(50) NULL,
    [F_Factor] decimal(18,2) NULL,
    [F_SortNo] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Type] int NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_WrapFlute] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 包角百分比克重表 */
IF OBJECT_ID(N'dbo.TB_QDM_WrapPercentGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_WrapPercentGram] (
    [F_Position] nvarchar(50) NULL,
    [F_MinPercent] int NULL,
    [F_MaxPercent] int NULL,
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_SortNo] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_WrapPercentGram] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 包角温度克重表 */
IF OBJECT_ID(N'dbo.TB_QDM_WrapTemperature', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_QDM_WrapTemperature] (
    [F_Position] nvarchar(50) NULL,
    [F_MinTemperature] int NULL,
    [F_MaxTemperature] int NULL,
    [F_MinGram] int NULL,
    [F_MaxGram] int NULL,
    [F_SortNo] int NULL,
    [F_Creator] nvarchar(50) NULL,
    [F_CreateTime] datetime2 NULL,
    [F_Editor] nvarchar(50) NULL,
    [F_EditTime] datetime2 NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_QDM_WrapTemperature] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* 停机原因设置表 */
IF OBJECT_ID(N'dbo.TB_StopReasonSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_StopReasonSet] (
    [F_StopTypeID] int NOT NULL,
    [F_Reason] nvarchar(200) NOT NULL,
    [F_Position] nvarchar(50) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_StopReasonSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 停机类型设置表 */
IF OBJECT_ID(N'dbo.TB_StopTypeSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_StopTypeSet] (
    [F_Code] nvarchar(100) NOT NULL,
    [F_Name] nvarchar(200) NOT NULL,
    [F_StatisticsStop] bit NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Position] nvarchar(100) NULL,
    CONSTRAINT [PK_TB_StopTypeSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸使用明细表 */
IF OBJECT_ID(N'dbo.T_BDS_HisRollInOut', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_BDS_HisRollInOut] (
    [F_MachineID] nvarchar(50) NOT NULL,
    [F_BarCode] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NOT NULL,
    [F_Brand] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_WidthInch] int NOT NULL,
    [F_Weight] int NOT NULL,
    [F_RollWeight] decimal(18,2) NOT NULL,
    [F_Dia] int NOT NULL,
    [F_RemainDia] int NOT NULL,
    [F_PlcRemainDia] int NOT NULL,
    [F_Meter] int NOT NULL,
    [F_RemainMeter] int NOT NULL,
    [F_PlcRemainMeter] int NOT NULL,
    [F_RemainRollWeight] decimal(18,2) NOT NULL,
    [F_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [F_ShelfTime] datetime2 NOT NULL,
    [F_OffShelfTime] datetime2 NOT NULL,
    [F_UseMeter] int NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_T_BDS_HisRollInOut] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* T_Cruise_ReasonLog */
IF OBJECT_ID(N'dbo.T_Cruise_ReasonLog', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_Cruise_ReasonLog] (
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    [F_Time] datetime2 NOT NULL,
    [F_OrderID] int NOT NULL,
    [F_OrderMeter] decimal(18,4) NOT NULL,
    [F_Shift] nvarchar(255) NOT NULL,
    [F_OrderNo] nvarchar(255) NOT NULL,
    [F_CutLength] int NOT NULL,
    [F_CutLengthSpeed] int NOT NULL,
    [F_PaperCode] nvarchar(255) NOT NULL,
    [F_PaperCodeSpeed] int NOT NULL,
    [F_PCodeSF1Speed] int NOT NULL,
    [F_PCodeSF2Speed] int NOT NULL,
    [F_PCodeSF3Speed] int NOT NULL,
    [F_LastSpeed] int NOT NULL,
    [F_CurSPeed] int NOT NULL,
    [F_LastCoef] decimal(18,4) NOT NULL,
    [F_CurCoef] decimal(18,4) NOT NULL,
    [F_Reason1] bit NOT NULL,
    [F_Reason2] bit NOT NULL,
    [F_Reason3] bit NOT NULL,
    [F_Reason4] bit NOT NULL,
    [F_Reason5] bit NOT NULL,
    [F_Reason6] bit NOT NULL,
    [F_Reason7] bit NOT NULL,
    [F_Reason8] bit NOT NULL,
    [F_Reason9] bit NOT NULL,
    [F_Reason10] bit NOT NULL,
    [F_Reason11] bit NOT NULL,
    [F_Reason12] bit NOT NULL,
    [F_Reason13] bit NOT NULL,
    [F_Reason14] bit NOT NULL,
    [F_Reason15] bit NOT NULL,
    [F_Reason16] bit NOT NULL,
    [F_Reason17] bit NOT NULL,
    [F_Reason18] bit NOT NULL,
    [F_Reason19] bit NOT NULL,
    [F_Reason20] bit NOT NULL,
    [F_Reason21] bit NOT NULL,
    [F_Reason22] bit NOT NULL,
    [F_Reason23] bit NOT NULL,
    [F_Reason24] bit NOT NULL,
    [F_Reason25] bit NOT NULL,
    [F_MainReason] int NULL,
    CONSTRAINT [PK_T_Cruise_ReasonLog] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* T_IPS_AutoAlarmHis */
IF OBJECT_ID(N'dbo.T_IPS_AutoAlarmHis', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_AutoAlarmHis] (
    [F_Code] nvarchar(36) NOT NULL,
    [F_Time] datetime2 NOT NULL,
    [F_Pairs] nvarchar(max) NULL,
    [F_PositionCode] nvarchar(100) NULL,
    [F_CurValue] nvarchar(50) NULL,
    [F_SetValue] nvarchar(50) NULL,
    [F_OffsetValue] nvarchar(50) NULL,
    [F_Offset] nvarchar(50) NULL,
    [F_OrderID] nvarchar(50) NULL,
    [F_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_IPS_AutoAlarmHis] PRIMARY KEY CLUSTERED ([F_Id] ASC)
);
END
GO

/* PLC加湿器 */
IF OBJECT_ID(N'dbo.T_IPS_CurAccelerator', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_CurAccelerator] (
    [F_IsUse] bit NOT NULL,
    [F_SetValue] decimal(18,2) NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_IPS_CurAccelerator] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* PLC冷喷雾 */
IF OBJECT_ID(N'dbo.T_IPS_CurPlcSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_CurPlcSpray] (
    [F_Position] nvarchar(50) NOT NULL,
    [F_IsUse] bit NOT NULL,
    [F_IsAuto] bit NOT NULL,
    [F_SetValue] decimal(18,2) NOT NULL,
    [F_Nozzle1] bit NOT NULL,
    [F_Nozzle2] bit NOT NULL,
    [F_Nozzle3] bit NOT NULL,
    [F_Nozzle4] bit NOT NULL,
    [F_Nozzle5] bit NOT NULL,
    [F_Nozzle6] bit NOT NULL,
    [F_Nozzle7] bit NOT NULL,
    [F_Nozzle8] bit NOT NULL,
    [F_Nozzle9] bit NOT NULL,
    [F_Nozzle10] bit NOT NULL,
    [F_Nozzle11] bit NOT NULL,
    [F_Nozzle12] bit NOT NULL,
    [F_Nozzle13] bit NOT NULL,
    [F_Nozzle14] bit NOT NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_IPS_CurPlcSpray] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸实材表 */
IF OBJECT_ID(N'dbo.T_IPS_ErpPaperForMachine', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_ErpPaperForMachine] (
    [F_MachineID] nvarchar(50) NULL,
    [F_ErpPaper] nvarchar(50) NULL,
    [F_ErpWidth] decimal(18,2) NULL,
    [F_ErpWeight] decimal(18,2) NULL,
    [F_ErpRollWeight] decimal(18,2) NULL,
    [F_ErpRollMeter] decimal(18,2) NULL,
    [F_GUID] nvarchar(max) NULL,
    [F_Barcode] nvarchar(max) NULL,
    [F_CreateTime] datetime2 NOT NULL,
    [F_State] int NOT NULL,
    [F_IsDel] bit NOT NULL,
    [F_SID] int NULL,
    [F_Brand] nvarchar(50) NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    [F_Supplier] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_T_IPS_ErpPaperForMachine] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸分摊基础表 */
IF OBJECT_ID(N'dbo.T_IPS_PaperShare', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_PaperShare] (
    [F_MachineID] nvarchar(50) NOT NULL,
    [F_OrderID] int NOT NULL,
    [F_BarCode] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NOT NULL,
    [F_Brand] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_WidthInch] int NOT NULL,
    [F_Weight] int NOT NULL,
    [F_RollWeight] decimal(18,2) NOT NULL,
    [F_Dia] int NOT NULL,
    [F_RemainDia] int NOT NULL,
    [F_PlcRemainDia] int NOT NULL,
    [F_Meter] int NOT NULL,
    [F_RemainMeter] int NOT NULL,
    [F_PlcRemainMeter] int NOT NULL,
    [F_RemainRollWeight] decimal(18,2) NOT NULL,
    [F_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [F_ShelfTime] datetime2 NOT NULL,
    [F_OffShelfTime] datetime2 NOT NULL,
    [F_UseMeter] int NOT NULL,
    [F_Percent] decimal(18,2) NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_IPS_PaperShare] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸实材表 */
IF OBJECT_ID(N'dbo.T_IPS_SPPaper', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_IPS_SPPaper] (
    [F_MachineID] nvarchar(50) NULL,
    [F_Brand] nvarchar(50) NULL,
    [F_ErpPaper] nvarchar(50) NULL,
    [F_ErpWidth] decimal(18,2) NULL,
    [F_ErpWeight] decimal(18,2) NULL,
    [F_ErpRollWeight] decimal(18,2) NULL,
    [F_ErpRollMeter] decimal(18,2) NULL,
    [F_Barcode] nvarchar(max) NULL,
    [F_CreateTime] datetime2 NOT NULL,
    [F_State] int NOT NULL,
    [F_IsDel] bit NOT NULL,
    [F_GUID] nvarchar(max) NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    [F_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_T_IPS_SPPaper] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* T_PMS_MonitorOrder */
IF OBJECT_ID(N'dbo.T_PMS_MonitorOrder', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_PMS_MonitorOrder] (
    [IsChange] bit NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_PMS_MonitorOrder] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 订单编辑版本表 */
IF OBJECT_ID(N'dbo.T_PMS_OrderEditVersion', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_PMS_OrderEditVersion] (
    [F_IsLock] bit NULL,
    [F_UID] int NULL,
    [F_LockTime] datetime2 NULL,
    [F_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_PMS_OrderEditVersion] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 订单标签打印表 */
IF OBJECT_ID(N'dbo.T_PMS_OrderLabels', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_PMS_OrderLabels] (
    [F_Guid] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NOT NULL,
    [F_Wave] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_WidthInch] decimal(18,4) NULL,
    [F_ScheduleMeter] decimal(18,4) NULL,
    [F_OrderNo] nvarchar(50) NULL,
    [F_CustNo] nvarchar(50) NULL,
    [F_TaskNo] nvarchar(50) NULL,
    [F_CustName] nvarchar(50) NULL,
    [F_CustPaperCode] nvarchar(50) NULL,
    [F_CutWidth] int NULL,
    [F_CutWidthInch] decimal(18,4) NULL,
    [F_CutLength] int NULL,
    [F_CutLengthInch] decimal(18,4) NULL,
    [F_CutQty] int NULL,
    [F_OrderQty] int NULL,
    [F_OrderMeter] decimal(18,4) NULL,
    [F_LabelQty] int NULL,
    [F_CN] int NULL,
    [F_Scor] nvarchar(50) NULL,
    [F_Remark] nvarchar(50) NULL,
    [F_StackQty] int NULL,
    [F_BunQty] int NULL,
    [F_OrderDate] datetime2 NULL,
    [F_DeliDate] datetime2 NULL,
    [F_StockMemo] nvarchar(50) NULL,
    [F_BoxMemo] nvarchar(50) NULL,
    [F_DeliMemo] nvarchar(50) NULL,
    [F_PlanMemo] nvarchar(50) NULL,
    [F_CutPaperMemo] nvarchar(50) NULL,
    [F_OrderNo_D] nvarchar(50) NULL,
    [F_CustNo_D] nvarchar(50) NULL,
    [F_TaskNo_D] nvarchar(50) NULL,
    [F_CustName_D] nvarchar(50) NULL,
    [F_CustPaperCode_D] nvarchar(50) NULL,
    [F_CutWidth_D] int NULL,
    [F_CutWidthInch_D] decimal(18,4) NULL,
    [F_CutLength_D] int NULL,
    [F_CutLengthInch_D] decimal(18,4) NULL,
    [F_CutQty_D] int NULL,
    [F_OrderQty_D] int NULL,
    [F_OrderMeter_D] decimal(18,4) NULL,
    [F_LabelQty_D] int NULL,
    [F_CN_D] int NULL,
    [F_Scor_D] nvarchar(50) NULL,
    [F_Remark_D] nvarchar(50) NULL,
    [F_StackQty_D] int NULL,
    [F_BunQty_D] int NULL,
    [F_OrderDate_D] datetime2 NULL,
    [F_DeliDate_D] datetime2 NULL,
    [F_StockMemo_D] nvarchar(50) NULL,
    [F_BoxMemo_D] nvarchar(50) NULL,
    [F_DeliMemo_D] nvarchar(50) NULL,
    [F_PlanMemo_D] nvarchar(50) NULL,
    [F_CutPaperMemo_D] nvarchar(50) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_PMS_OrderLabels] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 原纸使用明细表 */
IF OBJECT_ID(N'dbo.T_PR_HisRollInOut', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_PR_HisRollInOut] (
    [F_MachineID] nvarchar(50) NOT NULL,
    [F_BarCode] nvarchar(50) NOT NULL,
    [F_PaperCode] nvarchar(50) NOT NULL,
    [F_Brand] nvarchar(50) NOT NULL,
    [F_Width] int NOT NULL,
    [F_WidthInch] int NOT NULL,
    [F_Weight] int NOT NULL,
    [F_RollWeight] decimal(18,2) NOT NULL,
    [F_Dia] int NOT NULL,
    [F_RemainDia] int NOT NULL,
    [F_PlcRemainDia] int NOT NULL,
    [F_Meter] int NOT NULL,
    [F_RemainMeter] int NOT NULL,
    [F_PlcRemainMeter] int NOT NULL,
    [F_RemainRollWeight] decimal(18,2) NOT NULL,
    [F_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [F_ShelfTime] datetime2 NOT NULL,
    [F_OffShelfTime] datetime2 NULL,
    [F_UseMeter] int NOT NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_State] int NOT NULL,
    [F_ShiftName] nvarchar(50) NULL,
    [F_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_T_PR_HisRollInOut] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 预警历史记录表 */
IF OBJECT_ID(N'dbo.W_Alarms', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Alarms] (
    [WA_PartCode] nvarchar(20) NOT NULL,
    [WA_ReasonCode] nvarchar(20) NOT NULL,
    [WA_FirstSendTime] datetime2 NULL,
    [WA_LastSendTime] datetime2 NULL,
    [WA_SendNum] int NULL,
    [WA_IsConfirm] bit NULL,
    [WA_ConfirmBy] nvarchar(20) NULL,
    [WA_ConfirmTime] datetime2 NULL,
    [WA_IsReview] bit NULL,
    [WA_Reviewer] nvarchar(20) NULL,
    [WA_ReviewNote] nvarchar(200) NULL,
    [WA_ReasonText] nvarchar(max) NULL,
    [WA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Alarms] PRIMARY KEY CLUSTERED ([WA_ID] ASC)
);
END
GO

/* 完工表 */
IF OBJECT_ID(N'dbo.W_OrderFinishs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_OrderFinishs] (
    [WO_ID] int NOT NULL,
    [WOF_WorkNo] int NOT NULL,
    [WOF_ClassNo] nvarchar(50) NULL,
    [WOF_PaperCode] nvarchar(50) NOT NULL,
    [WOF_Wave] nvarchar(50) NOT NULL,
    [WOF_Floor] int NOT NULL,
    [WOF_Trim] int NOT NULL,
    [WOF_Width] int NOT NULL,
    [WOF_WidthInch] decimal(18,4) NULL,
    [WOF_Weight] int NULL,
    [WOF_Deep] decimal(18,4) NOT NULL,
    [WOF_Floor1] nvarchar(10) NULL,
    [WOF_Floor1Deep] int NULL,
    [WOF_Floor2] nvarchar(10) NULL,
    [WOF_Floor2Deep] int NULL,
    [WOF_Floor3] nvarchar(10) NULL,
    [WOF_Floor3Deep] int NULL,
    [WOF_Floor4] nvarchar(10) NULL,
    [WOF_Floor4Deep] int NULL,
    [WOF_Floor5] nvarchar(10) NULL,
    [WOF_Floor5Deep] int NULL,
    [WOF_Floor6] nvarchar(10) NULL,
    [WOF_Floor6Deep] int NULL,
    [WOF_Floor7] nvarchar(10) NULL,
    [WOF_Floor7Deep] int NULL,
    [WOF_Send] nvarchar(10) NULL,
    [WOF_Speed] int NOT NULL,
    [WOF_ScheduleMeter] decimal(18,4) NOT NULL,
    [WOF_Stop] bit NOT NULL,
    [WOF_UGoD] bit NOT NULL,
    [WOF_StartTime] datetime2 NULL,
    [WOF_FinishTime] datetime2 NULL,
    [WOF_EstFinshTime] datetime2 NULL,
    [WOF_ModCutQty] int NULL,
    [WOF_AvgSpeed] int NULL,
    [WOF_StopNum] int NULL,
    [WOF_StopTime] int NULL,
    [WOF_OrderNo] nvarchar(50) NULL,
    [WOF_CustNo] nvarchar(50) NULL,
    [WOF_TaskNo] nvarchar(50) NULL,
    [WOF_CustName] nvarchar(100) NULL,
    [WOF_CustPaperCode] nvarchar(50) NULL,
    [WOF_CutWidth] int NOT NULL,
    [WOF_CutWidthInch] decimal(18,4) NULL,
    [WOF_CutLength] int NOT NULL,
    [WOF_CutLengthInch] decimal(18,4) NULL,
    [WOF_CutQty] int NOT NULL,
    [WOF_OrderMeter] decimal(18,4) NULL,
    [WOF_OrderQty] int NULL,
    [WOF_OrderNoQty] int NULL,
    [WOF_LabelQty] int NULL,
    [WOF_CN] int NOT NULL,
    [WOF_ScorType] nvarchar(10) NOT NULL,
    [WOF_Scor] nvarchar(100) NULL,
    [WOF_ScorDeep] decimal(18,4) NOT NULL,
    [WOF_Remark] nvarchar(500) NULL,
    [WOF_Stack] bit NOT NULL,
    [WOF_StackQty] int NOT NULL,
    [WOF_BunQty] int NULL,
    [WOF_Bundle] bit NOT NULL,
    [WOF_BundleQty] int NOT NULL,
    [WOF_BundleNum] int NOT NULL,
    [WOF_OrderDate] datetime2 NULL,
    [WOF_DeliDate] datetime2 NULL,
    [WOF_StockMemo] nvarchar(200) NULL,
    [WOF_BoxMemo] nvarchar(200) NULL,
    [WOF_DeliMemo] nvarchar(200) NULL,
    [WOF_PlanMemo] nvarchar(max) NULL,
    [WOF_CutPaperMemo] nvarchar(200) NULL,
    [WOF_Memo] nvarchar(max) NULL,
    [WOF_FinishCutQty] int NULL,
    [WOF_FinishStackCutQty] int NULL,
    [WOF_LabelPrintNum] int NULL,
    [WOF_OrderNo_D] nvarchar(50) NULL,
    [WOF_CustNo_D] nvarchar(50) NULL,
    [WOF_TaskNo_D] nvarchar(50) NULL,
    [WOF_CustName_D] nvarchar(100) NULL,
    [WOF_CustPaperCode_D] nvarchar(50) NULL,
    [WOF_CutWidth_D] int NOT NULL,
    [WOF_CutWidthInch_D] decimal(18,4) NULL,
    [WOF_CutLength_D] int NOT NULL,
    [WOF_CutLengthInch_D] decimal(18,4) NULL,
    [WOF_CutQty_D] int NOT NULL,
    [WOF_OrderMeter_D] decimal(18,4) NULL,
    [WOF_OrderQty_D] int NULL,
    [WOF_OrderNoQty_D] int NULL,
    [WOF_LabelQty_D] int NULL,
    [WOF_CN_D] int NOT NULL,
    [WOF_ScorType_D] nvarchar(10) NULL,
    [WOF_Scor_D] nvarchar(100) NULL,
    [WOF_ScorDeep_D] decimal(18,4) NULL,
    [WOF_Remark_D] nvarchar(500) NULL,
    [WOF_Stack_D] bit NULL,
    [WOF_StackQty_D] int NULL,
    [WOF_BunQty_D] int NULL,
    [WOF_Bundle_D] bit NULL,
    [WOF_BundleQty_D] int NULL,
    [WOF_BundleNum_D] int NULL,
    [WOF_OrderDate_D] datetime2 NULL,
    [WOF_DeliDate_D] datetime2 NULL,
    [WOF_StockMemo_D] nvarchar(200) NULL,
    [WOF_BoxMemo_D] nvarchar(200) NULL,
    [WOF_DeliMemo_D] nvarchar(200) NULL,
    [WOF_PlanMemo_D] nvarchar(max) NULL,
    [WOF_CutPaperMemo_D] nvarchar(200) NULL,
    [WOF_Memo_D] nvarchar(max) NULL,
    [WOF_FinishCutQty_D] int NULL,
    [WOF_FinishStackCutQty_D] int NULL,
    [WOF_LabelPrintNum_D] int NULL,
    [WEO_Guid] nvarchar(50) NULL,
    [WOF_IsUrgent] bit NOT NULL,
    [WOF_OperType] int NOT NULL,
    [WOF_TrimCode] int NOT NULL,
    [WOF_ERPCutQty] int NOT NULL,
    [WOF_ERPCutQty_D] int NULL,
    [WOF_IsDouble] bit NULL,
    [WOF_IsOppositeStack] bit NOT NULL,
    [WOF_IsOppositeStack_D] bit NOT NULL,
    [WOF_SF2PlanUseFluteSF2] nvarchar(50) NULL,
    [WOF_SF3PlanUseFluteSF3] nvarchar(50) NULL,
    [WOF_SF1ActUseFluteSF1] nvarchar(50) NULL,
    [WOF_SF2ActUseFluteSF2] nvarchar(50) NULL,
    [WOF_SF3ActUseFluteSF3] nvarchar(50) NULL,
    [WOF_SF1PlanUseFluteSF1] nvarchar(50) NULL,
    [WOF_WavaType] nvarchar(50) NULL,
    [WOF_ID] int IDENTITY(1,1) NOT NULL,
    [WOF_PaperCodeExtra] nvarchar(50) NULL,
    [WOF_IsSmallCN_D] bit NOT NULL,
    CONSTRAINT [PK_W_OrderFinishs] PRIMARY KEY CLUSTERED ([WOF_ID] ASC)
);
END
GO

/* 订单堆码表 */
IF OBJECT_ID(N'dbo.W_OrderStackers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_OrderStackers] (
    [WOS_No] int NOT NULL,
    [WOS_Stack] int NOT NULL,
    [WOS_OrderNo] nvarchar(50) NOT NULL,
    [WOS_CustName] nvarchar(100) NOT NULL,
    [WOS_CutLength] int NOT NULL,
    [WOS_CutWidth] int NOT NULL,
    [WOS_Qty] int NOT NULL,
    [WOS_Height] int NOT NULL,
    [WOS_Last] int NOT NULL,
    [WOS_LastCust] int NOT NULL,
    [WO_ID] int NOT NULL,
    [WOS_CN] int NOT NULL,
    [WOS_SumQty] int NOT NULL,
    [WOS_CreateTime] datetime2 NOT NULL,
    [WOS_Print] int NOT NULL,
    [WOS_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_OrderStackers] PRIMARY KEY CLUSTERED ([WOS_ID] ASC)
);
END
GO

/* 未完工表 */
IF OBJECT_ID(N'dbo.W_Orders', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Orders] (
    [WEO_Guid] nvarchar(50) NULL,
    [WO_IsUrgent] bit NOT NULL,
    [WO_WorkNo] int NOT NULL,
    [WO_ClassNo] nvarchar(50) NULL,
    [WO_PaperCode] nvarchar(50) NOT NULL,
    [WO_Wave] nvarchar(50) NOT NULL,
    [WO_Floor] int NOT NULL,
    [WO_Width] int NOT NULL,
    [WO_Trim] int NOT NULL,
    [WO_WidthInch] decimal(18,4) NULL,
    [WO_Weight] int NULL,
    [WO_Deep] decimal(18,4) NULL,
    [WO_Floor1] nvarchar(10) NULL,
    [WO_Floor1Deep] int NULL,
    [WO_Floor2] nvarchar(10) NULL,
    [WO_Floor2Deep] int NULL,
    [WO_Floor3] nvarchar(10) NULL,
    [WO_Floor3Deep] int NULL,
    [WO_Floor4] nvarchar(10) NULL,
    [WO_Floor4Deep] int NULL,
    [WO_Floor5] nvarchar(10) NULL,
    [WO_Floor5Deep] int NULL,
    [WO_Floor6] nvarchar(10) NULL,
    [WO_Floor6Deep] int NULL,
    [WO_Floor7] nvarchar(10) NULL,
    [WO_Floor7Deep] int NULL,
    [WO_Send] nvarchar(10) NULL,
    [WO_Speed] int NOT NULL,
    [WO_ScheduleMeter] decimal(18,4) NULL,
    [WO_Stop] bit NOT NULL,
    [WO_UGoD] bit NOT NULL,
    [WO_StartTime] datetime2 NULL,
    [WO_EstFinshTime] datetime2 NULL,
    [WO_ModCutQty] int NULL,
    [WO_OrderNo] nvarchar(50) NULL,
    [WO_CustNo] nvarchar(50) NULL,
    [WO_TaskNo] nvarchar(50) NULL,
    [WO_CustName] nvarchar(100) NULL,
    [WO_CustPaperCode] nvarchar(50) NULL,
    [WO_CutWidth] int NOT NULL,
    [WO_CutWidthInch] decimal(18,4) NULL,
    [WO_CutLength] int NOT NULL,
    [WO_CutLengthInch] decimal(18,4) NULL,
    [WO_CutQty] int NOT NULL,
    [WO_OrderQty] int NULL,
    [WO_OrderMeter] decimal(18,4) NULL,
    [WO_OrderNoQty] int NULL,
    [WO_LabelQty] int NULL,
    [WO_CN] int NOT NULL,
    [WO_ScorType] nvarchar(10) NOT NULL,
    [WO_Scor] nvarchar(100) NULL,
    [WO_ScorDeep] decimal(18,4) NOT NULL,
    [WO_Remark] nvarchar(500) NULL,
    [WO_Stack] bit NOT NULL,
    [WO_StackQty] int NOT NULL,
    [WO_BunQty] int NULL,
    [WO_Bundle] bit NOT NULL,
    [WO_BundleQty] int NOT NULL,
    [WO_BundleNum] int NOT NULL,
    [WO_OrderDate] datetime2 NULL,
    [WO_DeliDate] datetime2 NULL,
    [WO_StockMemo] nvarchar(200) NULL,
    [WO_BoxMemo] nvarchar(200) NULL,
    [WO_DeliMemo] nvarchar(200) NULL,
    [WO_PlanMemo] nvarchar(max) NULL,
    [WO_CutPaperMemo] nvarchar(200) NULL,
    [WO_Memo] nvarchar(max) NULL,
    [WO_OrderNo_D] nvarchar(50) NULL,
    [WO_CustNo_D] nvarchar(50) NULL,
    [WO_TaskNo_D] nvarchar(50) NULL,
    [WO_CustName_D] nvarchar(100) NULL,
    [WO_CustPaperCode_D] nvarchar(50) NULL,
    [WO_CutWidth_D] int NULL,
    [WO_CutWidthInch_D] decimal(18,4) NULL,
    [WO_CutLength_D] int NULL,
    [WO_CutLengthInch_D] decimal(18,4) NULL,
    [WO_CutQty_D] int NULL,
    [WO_OrderQty_D] int NULL,
    [WO_OrderMeter_D] decimal(18,4) NULL,
    [WO_OrderNoQty_D] int NULL,
    [WO_LabelQty_D] int NULL,
    [WO_CN_D] int NULL,
    [WO_ScorType_D] nvarchar(10) NULL,
    [WO_Scor_D] nvarchar(100) NULL,
    [WO_ScorDeep_D] decimal(18,4) NULL,
    [WO_Remark_D] nvarchar(500) NULL,
    [WO_Stack_D] bit NULL,
    [WO_StackQty_D] int NULL,
    [WO_BunQty_D] int NULL,
    [WO_Bundle_D] bit NULL,
    [WO_BundleQty_D] int NULL,
    [WO_BundleNum_D] int NULL,
    [WO_OrderDate_D] datetime2 NULL,
    [WO_DeliDate_D] datetime2 NULL,
    [WO_StockMemo_D] nvarchar(200) NULL,
    [WO_BoxMemo_D] nvarchar(200) NULL,
    [WO_DeliMemo_D] nvarchar(200) NULL,
    [WO_PlanMemo_D] nvarchar(max) NULL,
    [WO_CutPaperMemo_D] nvarchar(200) NULL,
    [WO_Memo_D] nvarchar(max) NULL,
    [WO_IsDel] bit NULL,
    [WO_IsFake] bit NOT NULL,
    [WO_PrintNum] int NOT NULL,
    [WO_TrimCode] int NOT NULL,
    [WO_OperType] int NOT NULL,
    [WO_ERPCutQty] int NOT NULL,
    [WO_ERPCutQty_D] int NULL,
    [WO_IsDouble] bit NULL,
    [WO_IsOppositeStack] bit NOT NULL,
    [WO_IsOppositeStack_D] bit NOT NULL,
    [WO_SortSN] int NULL,
    [WO_TuneInStatue] int NOT NULL,
    [WO_SF2PlanUseFluteSF2] nvarchar(50) NULL,
    [WO_SF3PlanUseFluteSF3] nvarchar(50) NULL,
    [WO_SF1ActUseFlute] nvarchar(50) NULL,
    [WO_SF2ActUseFlute] nvarchar(50) NULL,
    [WO_SF3ActUseFlute] nvarchar(50) NULL,
    [WO_SF1PlanUseFluteSF1] nvarchar(50) NULL,
    [WO_WavaType] nvarchar(50) NULL,
    [WO_IsCalStack] bit NULL,
    [IndexNo] int NULL,
    [WO_ID] int IDENTITY(1,1) NOT NULL,
    [WO_PaperCodeExtra] nvarchar(50) NULL,
    [WO_IsSmallCN_D] bit NOT NULL,
    CONSTRAINT [PK_W_Orders] PRIMARY KEY CLUSTERED ([WO_ID] ASC)
);
END
GO

/* 领料表 */
IF OBJECT_ID(N'dbo.W_PaperGets', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PaperGets] (
    [WO_ID] int NULL,
    [WPG_WorkNo] int NOT NULL,
    [WPG_Wave] nvarchar(50) NOT NULL,
    [WPG_PaperCode] nvarchar(50) NOT NULL,
    [WPG_Width] int NOT NULL,
    [WPG_WidthInch] decimal(18,4) NULL,
    [WPG_OrderNum] int NOT NULL,
    [WPG_OrderMeter] decimal(18,4) NOT NULL,
    [WPG_DFOuter] nvarchar(10) NULL,
    [WPG_DFOuterMeter] decimal(18,4) NULL,
    [WPG_SF1Medium] nvarchar(10) NULL,
    [WPG_SF1MediumMeterSF1] decimal(18,4) NULL,
    [WPG_SF1Inside] nvarchar(10) NULL,
    [WPG_SF1InsideMeterSF1] decimal(18,4) NULL,
    [WPG_SF2Medium] nvarchar(10) NULL,
    [WPG_SF2MediumMeterSF2] decimal(18,4) NULL,
    [WPG_SF2Inside] nvarchar(10) NULL,
    [WPG_SF2InsideMeterSF2] decimal(18,4) NULL,
    [WPG_SF3Medium] nvarchar(10) NULL,
    [WPG_SF3MediumMeterSF3] decimal(18,4) NULL,
    [WPG_SF3Inside] nvarchar(10) NULL,
    [WPG_SF3InsideMeterSF3] decimal(18,4) NULL,
    [WPG_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PaperGets] PRIMARY KEY CLUSTERED ([WPG_ID] ASC)
);
END
GO

/* 备料表 */
IF OBJECT_ID(N'dbo.W_PaperReadys', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PaperReadys] (
    [WO_ID] int NULL,
    [WO_IDS] nvarchar(2000) NULL,
    [WP_P04TID] int NULL,
    [WPR_WorkNo] int NOT NULL,
    [Pro_PaperCode] int NULL,
    [WPR_Wave] nvarchar(50) NOT NULL,
    [WPR_PaperCode] nvarchar(50) NOT NULL,
    [WPR_Width] int NOT NULL,
    [WPR_WidthInch] decimal(18,4) NULL,
    [WPR_OrderNum] int NOT NULL,
    [WPR_OrderMeter] decimal(18,4) NOT NULL,
    [WPR_DFOuter] nvarchar(10) NULL,
    [WPR_DFOuterMeter] decimal(18,4) NULL,
    [WPR_SF1Medium] nvarchar(10) NULL,
    [WPR_SF1MediumMeterSF1] decimal(18,4) NULL,
    [WPR_SF1Inside] nvarchar(10) NULL,
    [WPR_SF1InsideMeterSF1] decimal(18,4) NULL,
    [WPR_SF2Medium] nvarchar(10) NULL,
    [WPR_SF2MediumMeterSF2] decimal(18,4) NULL,
    [WPR_SF2Inside] nvarchar(10) NULL,
    [WPR_SF2InsideMeterSF2] decimal(18,4) NULL,
    [WPR_SF3Medium] nvarchar(10) NULL,
    [WPR_SF3MediumMeterSF3] decimal(18,4) NULL,
    [WPR_SF3Inside] nvarchar(10) NULL,
    [WPR_SF3InsideMeterSF3] decimal(18,4) NULL,
    [WPR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PaperReadys] PRIMARY KEY CLUSTERED ([WPR_ID] ASC)
);
END
GO

/* 克重变动表 */
IF OBJECT_ID(N'dbo.W_ProEventP04Gs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProEventP04Gs] (
    [WP_QualityId] nvarchar(50) NULL,
    [WP_StartTime] datetime2 NULL,
    [WP_EndTime] datetime2 NULL,
    [WP_Duration] nvarchar(20) NULL,
    [WP_LiealMeters] decimal(18,4) NULL,
    [WP_TotalProduced] decimal(18,4) NULL,
    [WP_SideTrim] decimal(18,4) NULL,
    [WP_MaxV] decimal(18,4) NULL,
    [WP_AverageV] decimal(18,4) NULL,
    [WP_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProEventP04Gs] PRIMARY KEY CLUSTERED ([WP_Id] ASC)
);
END
GO

/* 低速运行表 */
IF OBJECT_ID(N'dbo.W_ProEventP04Ls', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProEventP04Ls] (
    [WP_StartTime] datetime2 NULL,
    [WP_EndTime] datetime2 NULL,
    [WP_MachineGroupNum] nvarchar(20) NULL,
    [WP_MachineNum] nvarchar(20) NULL,
    [WP_SlowKind] int NULL,
    [WP_SlowReason] nvarchar(20) NULL,
    [WP_SlowText] nvarchar(100) NULL,
    [WP_UserInfo] nvarchar(200) NULL,
    [WP_ShiftNum] nvarchar(20) NULL,
    [WP_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProEventP04Ls] PRIMARY KEY CLUSTERED ([WP_Id] ASC)
);
END
GO

/* 完工数据表 */
IF OBJECT_ID(N'dbo.W_ProEventP04Ps', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProEventP04Ps] (
    [WP_P04TID] int NULL,
    [WP_SetupID] int NOT NULL,
    [WP_StartTime] datetime2 NULL,
    [WP_EndTime] datetime2 NULL,
    [WP_LineMeters] decimal(18,4) NULL,
    [WP_AvgSpeed] decimal(18,4) NULL,
    [WP_TotalNominalMeters] decimal(18,4) NULL,
    [WP_TotalProQty] decimal(18,4) NULL,
    [WP_ProQtyEdgeAbsolute] decimal(18,4) NULL,
    [WP_ProQtyEdgeInPersent] decimal(18,4) NULL,
    [WP_ChangeCodeOSC] nvarchar(10) NULL,
    [WP_OrderStopTime] int NULL,
    [WP_OrderStopNum] int NULL,
    [WP_ShiftNum] nvarchar(10) NULL,
    [WP_KQMQty] int NULL,
    [WP_KQFQty] int NULL,
    [WP_ActualCuts1] int NULL,
    [WP_NominalCuts1] int NULL,
    [WP_OrderCut1] int NULL,
    [WP_AddCut1] int NULL,
    [WP_ActualCuts2] int NULL,
    [WP_NominalCuts2] int NULL,
    [WP_OrderCut2] int NULL,
    [WP_AddCut2] int NULL,
    [WP_ActualCuts3] int NULL,
    [WP_NominalCuts3] int NULL,
    [WP_OrderCut3] int NULL,
    [WP_AddCut3] int NULL,
    [WP_IsRec] bit NULL,
    [WP_GUID] nvarchar(50) NULL,
    [WP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProEventP04Ps] PRIMARY KEY CLUSTERED ([WP_ID] ASC)
);
END
GO

/* 停机数据表 */
IF OBJECT_ID(N'dbo.W_ProEventP04Ss', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProEventP04Ss] (
    [WP_StartTime] datetime2 NULL,
    [WP_EndTime] datetime2 NULL,
    [WP_MachineGroupNum] nvarchar(20) NULL,
    [WP_MachineNum] nvarchar(20) NULL,
    [WP_FaultKind] int NULL,
    [WP_FaultNum] nvarchar(20) NULL,
    [WP_FaltText] nvarchar(100) NULL,
    [WP_UserInfo] nvarchar(200) NULL,
    [WP_ShiftNum] nvarchar(20) NULL,
    [WP_P04TID] int NULL,
    [WP_OrderID] int NULL,
    [WP_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProEventP04Ss] PRIMARY KEY CLUSTERED ([WP_Id] ASC)
);
END
GO

/* 班组记录表 */
IF OBJECT_ID(N'dbo.W_ProEventP04Ts', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProEventP04Ts] (
    [WP_ShiftNumber] nvarchar(10) NULL,
    [WP_GroupNameShift] nvarchar(10) NULL,
    [WP_StartTime] datetime2 NULL,
    [WP_EndTime] datetime2 NULL,
    [WP_Duration] nvarchar(20) NULL,
    [WP_TotalLinealMeters] decimal(18,4) NULL,
    [WP_TotalProduced] decimal(18,4) NULL,
    [WP_SideTrim] decimal(18,4) NULL,
    [WP_MaxSpeed] decimal(18,4) NULL,
    [WP_AvgSpeed] decimal(18,4) NULL,
    [WP_IsEnd] bit NULL,
    [WP_StartSteam] decimal(18,4) NULL,
    [WP_EndSteam] decimal(18,4) NULL,
    [WP_StartELEC] decimal(18,4) NULL,
    [WP_EndELEC] decimal(18,4) NULL,
    [WP_ID] int IDENTITY(1,1) NOT NULL,
    [WP_StartGlue] decimal(18,4) NULL,
    [WP_EndGlue] decimal(18,4) NULL,
    CONSTRAINT [PK_W_ProEventP04Ts] PRIMARY KEY CLUSTERED ([WP_ID] ASC)
);
END
GO
