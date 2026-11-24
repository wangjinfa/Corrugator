/* =====================================================================
   IPS 全量建库脚本（IPS 155 表 + BaseDB 12 表，同一个库）
   用法：在目标库上执行一次即可（例如 IPS）
   说明：
     1) BaseDB 不再单独建库，账号/角色/权限/瓦线配置与业务表同库共存，表名无冲突；
     2) 服务端把 Database.BaseConnectionString 留空即可（= 使用 Database.ConnectionString）；
     3) 账号首次启动由 SeedData 自动写入 W_Users（admin/planner/operator，密码 123456），
        也可用 db/sqlserver_base_user_seed.sql 手工插入；
     4) 瓦线配置见 db/basedb_tb_line_sample.sql（多瓦线时才需要）。
   ===================================================================== */

/* =============================== 第一部分：IPS 业务表 =============================== */
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
IF OBJECT_ID(N'dbo.W_E_Orders', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_E_Orders] (
    [WEO_Guid] nvarchar(50) NULL,
    [WEO_IsUrgent] bit NOT NULL,
    [WEO_WorkNo] int NOT NULL,
    [WEO_ClassNo] nvarchar(50) NULL,
    [WEO_PaperCode] nvarchar(50) NOT NULL,
    [WEO_Wave] nvarchar(50) NOT NULL,
    [WEO_Floor] int NOT NULL,
    [WEO_Width] int NOT NULL,
    [WEO_Trim] int NULL,
    [WEO_WidthInch] decimal(18,4) NULL,
    [WEO_Weight] int NULL,
    [WEO_Deep] decimal(18,4) NULL,
    [WEO_Floor1] nvarchar(10) NULL,
    [WEO_Floor1Deep] int NULL,
    [WEO_Floor2] nvarchar(10) NULL,
    [WEO_Floor2Deep] int NULL,
    [WEO_Floor3] nvarchar(10) NULL,
    [WEO_Floor3Deep] int NULL,
    [WEO_Floor4] nvarchar(10) NULL,
    [WEO_Floor4Deep] int NULL,
    [WEO_Floor5] nvarchar(10) NULL,
    [WEO_Floor5Deep] int NULL,
    [WEO_Floor6] nvarchar(10) NULL,
    [WEO_Floor6Deep] int NULL,
    [WEO_Floor7] nvarchar(10) NULL,
    [WEO_Floor7Deep] int NULL,
    [WEO_Send] nvarchar(10) NULL,
    [WEO_Speed] int NULL,
    [WEO_ScheduleMeter] decimal(18,4) NULL,
    [WEO_Stop] bit NOT NULL,
    [WEO_UGoD] bit NOT NULL,
    [WEO_StartTime] datetime2 NULL,
    [WEO_EstFinshTime] datetime2 NULL,
    [WEO_ModCutQty] int NULL,
    [WEO_OrderNo] nvarchar(50) NULL,
    [WEO_CustNo] nvarchar(50) NULL,
    [WEO_TaskNo] nvarchar(50) NULL,
    [WEO_CustName] nvarchar(100) NULL,
    [WEO_CustPaperCode] nvarchar(50) NULL,
    [WEO_CutWidth] int NOT NULL,
    [WEO_CutWidthInch] decimal(18,4) NULL,
    [WEO_CutLength] int NOT NULL,
    [WEO_CutLengthInch] decimal(18,4) NULL,
    [WEO_CutQty] int NOT NULL,
    [WEO_OrderQty] int NULL,
    [WEO_OrderMeter] decimal(18,4) NULL,
    [WEO_OrderNoQty] int NULL,
    [WEO_LabelQty] int NULL,
    [WEO_CN] int NOT NULL,
    [WEO_ScorType] nvarchar(10) NOT NULL,
    [WEO_Scor] nvarchar(100) NULL,
    [WEO_ScorDeep] decimal(18,4) NOT NULL,
    [WEO_Remark] nvarchar(500) NULL,
    [WEO_Stack] bit NOT NULL,
    [WEO_StackQty] int NULL,
    [WEO_BunQty] int NULL,
    [WEO_Bundle] bit NOT NULL,
    [WEO_BundleQty] int NULL,
    [WEO_BundleNum] int NULL,
    [WEO_OrderDate] datetime2 NULL,
    [WEO_DeliDate] datetime2 NULL,
    [WEO_StockMemo] nvarchar(200) NULL,
    [WEO_BoxMemo] nvarchar(200) NULL,
    [WEO_DeliMemo] nvarchar(200) NULL,
    [WEO_PlanMemo] nvarchar(max) NULL,
    [WEO_CutPaperMemo] nvarchar(200) NULL,
    [WEO_Memo] nvarchar(max) NULL,
    [WEO_OrderNo_D] nvarchar(50) NULL,
    [WEO_CustNo_D] nvarchar(50) NULL,
    [WEO_TaskNo_D] nvarchar(50) NULL,
    [WEO_CustName_D] nvarchar(100) NULL,
    [WEO_CustPaperCode_D] nvarchar(50) NULL,
    [WEO_CutWidth_D] int NULL,
    [WEO_CutWidthInch_D] decimal(18,4) NULL,
    [WEO_CutLength_D] int NULL,
    [WEO_CutLengthInch_D] decimal(18,4) NULL,
    [WEO_CutQty_D] int NULL,
    [WEO_OrderQty_D] int NULL,
    [WEO_OrderMeter_D] decimal(18,4) NULL,
    [WEO_OrderNoQty_D] int NULL,
    [WEO_LabelQty_D] int NULL,
    [WEO_CN_D] int NULL,
    [WEO_ScorType_D] nvarchar(10) NULL,
    [WEO_Scor_D] nvarchar(100) NULL,
    [WEO_ScorDeep_D] decimal(18,4) NULL,
    [WEO_Remark_D] nvarchar(500) NULL,
    [WEO_Stack_D] bit NULL,
    [WEO_StackQty_D] int NULL,
    [WEO_BunQty_D] int NULL,
    [WEO_Bundle_D] bit NULL,
    [WEO_BundleQty_D] int NULL,
    [WEO_BundleNum_D] int NULL,
    [WEO_OrderDate_D] datetime2 NULL,
    [WEO_DeliDate_D] datetime2 NULL,
    [WEO_StockMemo_D] nvarchar(200) NULL,
    [WEO_BoxMemo_D] nvarchar(200) NULL,
    [WEO_DeliMemo_D] nvarchar(200) NULL,
    [WEO_PlanMemo_D] nvarchar(max) NULL,
    [WEO_CutPaperMemo_D] nvarchar(200) NULL,
    [WEO_Memo_D] nvarchar(max) NULL,
    [WEO_Status] int NULL,
    [WEO_ErrorMsg] nvarchar(max) NULL,
    [WEO_OperDate] datetime2 NULL,
    [WEO_TrimCode] int NOT NULL,
    [WEO_TOrderNo] nvarchar(50) NULL,
    [WEO_IsDouble] bit NULL,
    [WEO_SortSN] int NULL,
    [WEO_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_E_Orders] PRIMARY KEY CLUSTERED ([WEO_ID] ASC)
);
END
GO

/* 订单修改日志表 */
IF OBJECT_ID(N'dbo.W_OrderLogs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_OrderLogs] (
    [WEO_Guid] nvarchar(50) NULL,
    [WO_ID] int NOT NULL,
    [WLOL_Time] datetime2 NOT NULL,
    [WLOL_UserName] nvarchar(50) NOT NULL,
    [WLOL_MachineIp] nvarchar(50) NOT NULL,
    [WLOL_MachineName] nvarchar(50) NOT NULL,
    [WLOL_Content] nvarchar(100) NOT NULL,
    [WLOL_ClassNo] nvarchar(50) NULL,
    [WLOL_WorkNo] int NOT NULL,
    [WLOL_WorkNo_O] nvarchar(50) NULL,
    [WLOL_PaperCode] nvarchar(50) NOT NULL,
    [WLOL_PaperCode_O] nvarchar(50) NULL,
    [WLOL_Wave] nvarchar(50) NOT NULL,
    [WLOL_Wave_O] nvarchar(50) NULL,
    [WLOL_Width] int NOT NULL,
    [WLOL_Width_O] nvarchar(50) NULL,
    [WLOL_Trim] int NOT NULL,
    [WLOL_Trim_O] nvarchar(50) NULL,
    [WLOL_TrimArea] decimal(18,4) NOT NULL,
    [WLOL_TrimArea_O] nvarchar(50) NULL,
    [WLOL_CustName] nvarchar(50) NOT NULL,
    [WLOL_OrderNo] nvarchar(50) NOT NULL,
    [WLOL_CutWidth] int NOT NULL,
    [WLOL_CutWidth_O] nvarchar(50) NULL,
    [WLOL_CutLength] int NOT NULL,
    [WLOL_CutLength_O] nvarchar(50) NULL,
    [WLOL_CutQty] int NOT NULL,
    [WLOL_CutQty_O] nvarchar(50) NULL,
    [WLOL_CN] int NOT NULL,
    [WLOL_CN_O] nvarchar(50) NULL,
    [WLOL_SheetQty] int NOT NULL,
    [WLOL_SheetQty_O] nvarchar(50) NULL,
    [WLOL_ScorType] nvarchar(10) NOT NULL,
    [WLOL_ScorType_O] nvarchar(10) NULL,
    [WLOL_Scor] nvarchar(100) NOT NULL,
    [WLOL_Scor_O] nvarchar(100) NULL,
    [WLOL_Area] decimal(18,4) NOT NULL,
    [WLOL_Area_O] nvarchar(50) NULL,
    [WLOL_Remark] nvarchar(500) NULL,
    [WLOL_CustName_D] nvarchar(50) NULL,
    [WLOL_OrderNo_D] nvarchar(50) NULL,
    [WLOL_CutWidth_D] int NULL,
    [WLOL_CutWidth_D_O] nvarchar(50) NULL,
    [WLOL_CutLength_D] int NULL,
    [WLOL_CutLength_D_O] nvarchar(50) NULL,
    [WLOL_CutQty_D] int NULL,
    [WLOL_CutQty_D_O] nvarchar(50) NULL,
    [WLOL_CN_D] int NULL,
    [WLOL_CN_D_O] nvarchar(50) NULL,
    [WLOL_SheetQty_D] int NULL,
    [WLOL_SheetQty_D_O] nvarchar(50) NULL,
    [WLOL_ScorType_D] nvarchar(10) NULL,
    [WLOL_ScorType_D_O] nvarchar(10) NULL,
    [WLOL_Scor_D] nvarchar(100) NULL,
    [WLOL_Scor_D_O] nvarchar(100) NULL,
    [WLOL_Area_D] decimal(18,4) NULL,
    [WLOL_Area_D_O] nvarchar(50) NULL,
    [WLOL_Remark_D] nvarchar(500) NULL,
    [WLOL_UpdateReason] nvarchar(500) NULL,
    [WLOL_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_OrderLogs] PRIMARY KEY CLUSTERED ([WLOL_ID] ASC)
);
END
GO

/* 系统日志表 */
IF OBJECT_ID(N'dbo.W_SystemLogs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_SystemLogs] (
    [WLSL_Time] datetime2 NOT NULL,
    [WLSL_UserName] nvarchar(50) NULL,
    [WLSL_MachineIp] nvarchar(50) NULL,
    [WLSL_MachineName] nvarchar(50) NULL,
    [WLSL_SoftwareName] nvarchar(50) NOT NULL,
    [WLSL_Module] nvarchar(50) NOT NULL,
    [WLSL_Content] nvarchar(max) NOT NULL,
    [WLSL_Type] int NOT NULL,
    [WLSL_Order] nvarchar(200) NULL,
    [WLSL_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_SystemLogs] PRIMARY KEY CLUSTERED ([WLSL_ID] ASC)
);
END
GO

/* 数据字典明细表 */
IF OBJECT_ID(N'dbo.W_DictDatas', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_DictDatas] (
    [WPD_TypeID] int NOT NULL,
    [WPD_Property] nvarchar(50) NULL,
    [WPD_EnglishName] nvarchar(50) NULL,
    [WPD_Value] nvarchar(100) NULL,
    [WPD_SortNo] int NULL,
    [WPD_ChineseName] nvarchar(100) NULL,
    [WPD_Ctreator] nvarchar(20) NOT NULL,
    [WPD_CreateTime] datetime2 NOT NULL,
    [WPD_Editor] nvarchar(20) NULL,
    [WPD_EditTime] datetime2 NULL,
    [WPD_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_DictDatas] PRIMARY KEY CLUSTERED ([WPD_ID] ASC)
);
END
GO

/* 数据字典类型表 */
IF OBJECT_ID(N'dbo.W_DictTypes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_DictTypes] (
    [WPD_PID] int NULL,
    [WPD_Name] nvarchar(50) NULL,
    [WPD_Code] nvarchar(50) NULL,
    [WPD_Creator] nvarchar(20) NOT NULL,
    [WPD_CreateTime] datetime2 NOT NULL,
    [WPD_Editor] nvarchar(20) NULL,
    [WPD_EditTime] datetime2 NULL,
    [WPD_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_DictTypes] PRIMARY KEY CLUSTERED ([WPD_ID] ASC)
);
END
GO

/* 预警部位 */
IF OBJECT_ID(N'dbo.W_AlarmParts', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_AlarmParts] (
    [WSA_Code] nvarchar(20) NOT NULL,
    [WSA_Name] nvarchar(50) NULL,
    [WSA_IPAddress] nvarchar(50) NULL,
    [WSA_PhoneID] nvarchar(max) NULL,
    [WSA_PhoneGroup] nvarchar(100) NULL,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_AlarmParts] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* 预警原因 */
IF OBJECT_ID(N'dbo.W_AlarmReasons', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_AlarmReasons] (
    [WSA_Code] nvarchar(20) NOT NULL,
    [WSA_Title] nvarchar(50) NULL,
    [WSA_Content] nvarchar(100) NULL,
    [WSA_SendTimes] int NULL,
    [WSA_IntervalTime] int NULL,
    [WSA_PartCode] nvarchar(20) NULL,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_AlarmReasons] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* 预警复核人 */
IF OBJECT_ID(N'dbo.W_AlarmReviewers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_AlarmReviewers] (
    [WSA_Name] nvarchar(20) NOT NULL,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_AlarmReviewers] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* 基础楞型组合 */
IF OBJECT_ID(N'dbo.W_BaseWaveGroup', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_BaseWaveGroup] (
    [WSBG_Wave] nvarchar(50) NOT NULL,
    [WSBG_IsUseDFOuter] bit NULL,
    [WSBG_IsUseSF1Medium] bit NULL,
    [WSBG_IsUseSF1Inside] bit NULL,
    [WSBG_IsUseSF2Medium] bit NULL,
    [WSBG_IsUseSF2Inside] bit NULL,
    [WSBG_IsUseSF3Medium] bit NULL,
    [WSBG_IsUseSF3Inside] bit NULL,
    [WSBG_IsOftenUse] bit NULL,
    [WSBG_Creator] nvarchar(50) NULL,
    [WSBG_CreateTime] datetime2 NULL,
    [WSBG_Editor] nvarchar(50) NULL,
    [WSBG_EditTime] datetime2 NULL,
    [WSBG_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_BaseWaveGroup] PRIMARY KEY CLUSTERED ([WSBG_ID] ASC)
);
END
GO

/* 基础楞型表 */
IF OBJECT_ID(N'dbo.W_BaseWaves', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_BaseWaves] (
    [WSBW_Wave] nvarchar(10) NOT NULL,
    [WSBW_WDeep] decimal(18,4) NOT NULL,
    [WSBW_WRate] decimal(18,4) NOT NULL,
    [WSBW_IsUse] bit NOT NULL,
    [WSBW_Creator] nvarchar(50) NULL,
    [WSBW_CreateTime] datetime2 NULL,
    [WSBW_Editor] nvarchar(50) NULL,
    [WSBW_EditTime] datetime2 NULL,
    [WSBW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_BaseWaves] PRIMARY KEY CLUSTERED ([WSBW_ID] ASC)
);
END
GO

/* 班组基础资料设置表 */
IF OBJECT_ID(N'dbo.W_Classes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Classes] (
    [WSC_ShiftNum] nvarchar(10) NULL,
    [WSC_Name] nvarchar(50) NOT NULL,
    [WSC_Monitor] nvarchar(50) NULL,
    [WSC_CarHugger1] nvarchar(50) NULL,
    [WSC_CarHugger2] nvarchar(50) NULL,
    [WSC_Creator] nvarchar(50) NOT NULL,
    [WSC_CreateTime] datetime2 NOT NULL,
    [WSC_Editor] nvarchar(50) NULL,
    [WSC_EditTime] datetime2 NULL,
    [WSC_StartTime] nvarchar(50) NULL,
    [WSC_EndTime] nvarchar(50) NULL,
    [WSC_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Classes] PRIMARY KEY CLUSTERED ([WSC_ID] ASC)
);
END
GO

/* 耗材配置界面 */
IF OBJECT_ID(N'dbo.W_Consumables', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Consumables] (
    [WSC_ID] int IDENTITY(1,1) NOT NULL,
    [WSC_Number] nvarchar(50) NULL,
    [WSC_Name] nvarchar(50) NULL,
    [WSC_Code] nvarchar(50) NULL,
    [WSC_Type] nvarchar(50) NULL,
    [WSC_Item] nvarchar(50) NULL,
    [WSC_Price] decimal(10,2) NULL,
    [WSC_Property] nvarchar(50) NULL,
    [WSC_ShowPrice] bit NULL,
    [WSC_IsUse] bit NULL,
    CONSTRAINT [PK_W_Consumables] PRIMARY KEY CLUSTERED ([WSC_ID] ASC)
);
END
GO

/* 当前班组表 */
IF OBJECT_ID(N'dbo.W_CurrentShift', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_CurrentShift] (
    [WSCS_ClassId] int NULL,
    [WSCS_P04TID] int NULL,
    [WSCS_ShiftNum] nvarchar(10) NULL,
    [WSCS_Shift] nvarchar(50) NULL,
    [WSCS_LastClassId] int NULL,
    [WSCS_LastP04TID] int NULL,
    [WSCS_LastShiftNum] nvarchar(10) NULL,
    [WSCS_LastShift] nvarchar(50) NULL,
    [WSCS_ChangeTime] datetime2 NULL,
    [WSCS_SF1CurUseFluteSF1] nvarchar(50) NULL,
    [WSCS_SF2CurUseFluteSF2] nvarchar(50) NULL,
    [WSCS_SF3CurUseFluteSF3] nvarchar(50) NULL,
    [WSCS_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_CurrentShift] PRIMARY KEY CLUSTERED ([WSCS_Id] ASC)
);
END
GO

/* 切长限速表 */
IF OBJECT_ID(N'dbo.W_CutSpeeds', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_CutSpeeds] (
    [WSCS_CutLength] int NOT NULL,
    [WSCS_Speed] int NOT NULL,
    [WSCS_CreateTime] datetime2 NULL,
    [WSCS_Creator] nvarchar(50) NULL,
    [WSCS_EditTime] datetime2 NULL,
    [WSCS_Editor] nvarchar(50) NULL,
    [WSCS_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_CutSpeeds] PRIMARY KEY CLUSTERED ([WSCS_ID] ASC)
);
END
GO

/* 原纸品牌详情表 */
IF OBJECT_ID(N'dbo.W_PaperCodeBrands', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PaperCodeBrands] (
    [WF_Brand] nvarchar(100) NOT NULL,
    [WF_PaperCodeID] int NOT NULL,
    [WF_RatedTension] int NULL,
    [WF_SteamWeight] int NULL,
    [WF_GlueWeight] int NULL,
    [WF_WrapWeight] int NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_LS0Tension] int NOT NULL,
    [WF_MS1Tension] int NULL,
    [WF_LS1Tension] int NULL,
    [WF_MS2Tension] int NULL,
    [WF_LS2Tension] int NULL,
    [WF_MS3Tension] int NULL,
    [WF_LS3Tension] int NULL,
    CONSTRAINT [PK_W_PaperCodeBrands] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸基础资料设置表 */
IF OBJECT_ID(N'dbo.W_PaperCodes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PaperCodes] (
    [WSPC_Code] nvarchar(50) NOT NULL,
    [WSPC_ErpCode] nvarchar(50) NULL,
    [WSPC_Weight] int NOT NULL,
    [WSPC_RatedTension] int NULL,
    [WSPC_SteamWeight] int NULL,
    [WSPC_GlueWeight] int NULL,
    [WSPC_WrapWeight] int NULL,
    [WSPC_Deep] decimal(18,4) NOT NULL,
    [WSPC_LS0_TensionFactorLS0] decimal(18,2) NULL,
    [WSPC_MS1_TensionFactorMS1] decimal(18,2) NULL,
    [WSPC_LS1_TensionFactorLS1] decimal(18,2) NULL,
    [WSPC_MS2_TensionFactorMS2] decimal(18,2) NULL,
    [WSPC_LS2_TensionFactorLS2] decimal(18,2) NULL,
    [WSPC_MS3_TensionFactorMS3] decimal(18,2) NULL,
    [WSPC_LS3_TensionFactorLS3] decimal(18,2) NULL,
    [WSPC_LS0_Speed] int NOT NULL,
    [WSPC_MS1_Speed] int NULL,
    [WSPC_LS1_Speed] int NULL,
    [WSPC_MS2_Speed] int NULL,
    [WSPC_LS2_Speed] int NULL,
    [WSPC_MS3_Speed] int NULL,
    [WSPC_LS3_Speed] int NULL,
    [WSPC_Creator] nvarchar(50) NOT NULL,
    [WSPC_CreateTime] datetime2 NOT NULL,
    [WSPC_Editor] nvarchar(50) NULL,
    [WSPC_EditTime] datetime2 NULL,
    [WSPC_ID] int IDENTITY(1,1) NOT NULL,
    [WSPC_LS0_SpeedRemain] int NOT NULL,
    [WSPC_MS1_SpeedRemain] int NULL,
    [WSPC_LS1_SpeedRemain] int NULL,
    [WSPC_MS2_SpeedRemain] int NULL,
    [WSPC_LS2_SpeedRemain] int NULL,
    [WSPC_MS3_SpeedRemain] int NULL,
    [WSPC_LS3_SpeedRemain] int NULL,
    [WSPC_LS0Tension] int NOT NULL,
    [WSPC_MS1Tension] int NULL,
    [WSPC_LS1Tension] int NULL,
    [WSPC_MS2Tension] int NULL,
    [WSPC_LS2Tension] int NULL,
    [WSPC_MS3Tension] int NULL,
    [WSPC_LS3Tension] int NULL,
    CONSTRAINT [PK_W_PaperCodes] PRIMARY KEY CLUSTERED ([WSPC_ID] ASC)
);
END
GO

/* 产线错位资料设置表 */
IF OBJECT_ID(N'dbo.W_ProductBunles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProductBunles] (
    [WSPB_Wave] nvarchar(50) NOT NULL,
    [WSPB_StartSec] decimal(18,4) NOT NULL,
    [WSPB_EndSec] decimal(18,4) NOT NULL,
    [WSPB_CreateTime] datetime2 NOT NULL,
    [WSPB_Creator] nvarchar(50) NOT NULL,
    [WSPB_EditTime] datetime2 NULL,
    [WSPB_Editor] nvarchar(50) NULL,
    [WSPB_BunleQty] int NOT NULL,
    [WSPB_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProductBunles] PRIMARY KEY CLUSTERED ([WSPB_ID] ASC)
);
END
GO

/* W_ProductTarget */
IF OBJECT_ID(N'dbo.W_ProductTarget', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProductTarget] (
    [WSP_ID] int IDENTITY(1,1) NOT NULL,
    [WSP_Number] nvarchar(50) NULL,
    [WSP_Type] nvarchar(50) NULL,
    [WSP_Describe1] nvarchar(50) NULL,
    [WSP_TargetValue1] decimal(18,4) NULL,
    [WSP_Describe2] nvarchar(50) NULL,
    [WSP_TargetValue2] decimal(18,4) NULL,
    [WSP_Property] nvarchar(50) NULL,
    CONSTRAINT [PK_W_ProductTarget] PRIMARY KEY CLUSTERED ([WSP_ID] ASC)
);
END
GO

/* 产线楞型基础资料设置表 */
IF OBJECT_ID(N'dbo.W_ProductWaves', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ProductWaves] (
    [WSPW_Width] int NOT NULL,
    [WSPW_Wave] nvarchar(50) NOT NULL,
    [WSPW_WDeepSF1] decimal(18,4) NULL,
    [WSPW_WRateSF1] decimal(18,4) NULL,
    [WSPW_WDeepSF2] decimal(18,4) NULL,
    [WSPW_WRateSF2] decimal(18,4) NULL,
    [WSPW_WDeepSF3] decimal(18,4) NULL,
    [WSPW_WRateSF3] decimal(18,4) NULL,
    [WSPW_PaperDeep] decimal(18,4) NOT NULL,
    [WSPW_MaxCN] int NOT NULL,
    [WSPW_MinCutLength] int NOT NULL,
    [WSPW_MaxCutLength] int NOT NULL,
    [WSPW_MinEdge] int NOT NULL,
    [WSPW_MaxEdge] int NOT NULL,
    [WSPW_SmallScor] int NULL,
    [WSPW_SmallScorDepth] int NULL,
    [WSPW_FlatScorDepth] int NULL,
    [WSPW_ComScorDepth] int NULL,
    [WSPW_ProScorDePth] int NULL,
    [WSPW_CreateTime] datetime2 NOT NULL,
    [WSPW_Creator] nvarchar(50) NOT NULL,
    [WSPW_EditTime] datetime2 NULL,
    [WSPW_Editor] nvarchar(50) NULL,
    [WSPW_MaxSpeed] int NULL,
    [WSPW_PaperDeepWeight1] decimal(18,2) NOT NULL,
    [WSPW_PaperDeepWeight2] decimal(18,2) NOT NULL,
    [WSPW_PaperDeepWeight3] decimal(18,2) NOT NULL,
    [WSPW_PaperDeep1] decimal(18,2) NOT NULL,
    [WSPW_PaperDeep2] decimal(18,2) NOT NULL,
    [WSPW_PaperDeep3] decimal(18,2) NOT NULL,
    [WSPW_UpLimite] decimal(18,2) NOT NULL,
    [WSPW_DownLimite] decimal(18,2) NOT NULL,
    [WSPW_CN1] int NOT NULL,
    [WSPW_CN2] int NOT NULL,
    [WSPW_CN3] int NOT NULL,
    [WSPW_StackQty] int NOT NULL,
    [WSPW_StackQty_D] int NOT NULL,
    [WSPW_StackQty2] int NOT NULL,
    [WSPW_StackQty_D2] int NOT NULL,
    [WSPW_StackQty3] int NOT NULL,
    [WSPW_StackQty_D3] int NOT NULL,
    [BundleQty] int NOT NULL,
    [WSPW_Trim] int NULL,
    [WSPW_Wgt1] int NULL,
    [WSPW_Wgt2] int NULL,
    [WSPW_AddDepth1] int NULL,
    [WSPW_AddDepth2] int NULL,
    [WSPW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ProductWaves] PRIMARY KEY CLUSTERED ([WSPW_ID] ASC)
);
END
GO

/* 补打原因表 */
IF OBJECT_ID(N'dbo.W_ReissueReasons', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ReissueReasons] (
    [WF_Reason] nvarchar(500) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ReissueReasons] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 选择楞型 */
IF OBJECT_ID(N'dbo.W_SelectWave', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_SelectWave] (
    [WSSO_ID] int NOT NULL,
    [WSSO_Editor] nvarchar(50) NULL,
    [WSSO_EditTime] datetime2 NULL,
    [WSSW_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_SelectWave] PRIMARY KEY CLUSTERED ([WSSW_ID] ASC)
);
END
GO

/* 楞型配置选项 */
IF OBJECT_ID(N'dbo.W_SelectWaveOptions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_SelectWaveOptions] (
    [WSSO_Name] nvarchar(50) NOT NULL,
    [WSSO_Creator] nvarchar(50) NULL,
    [WSSO_CreateTime] datetime2 NULL,
    [WSSO_Editor] nvarchar(50) NULL,
    [WSSO_EditTime] datetime2 NULL,
    [WSSO_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_SelectWaveOptions] PRIMARY KEY CLUSTERED ([WSSO_ID] ASC)
);
END
GO

/* 楞型配置关系 */
IF OBJECT_ID(N'dbo.W_SelectWaveRelation', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_SelectWaveRelation] (
    [WSSO_ID] int NOT NULL,
    [WSBG_ID] int NOT NULL,
    [WSSR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_SelectWaveRelation] PRIMARY KEY CLUSTERED ([WSSR_ID] ASC)
);
END
GO

/* 瓦楞辊对照表 */
IF OBJECT_ID(N'dbo.W_WaveComparison', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_WaveComparison] (
    [Wave] nvarchar(50) NOT NULL,
    [Type] nvarchar(50) NOT NULL,
    [Code] nvarchar(50) NOT NULL,
    [IDExtra] nvarchar(50) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_WaveComparison] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 瓦楞辊设置表 */
IF OBJECT_ID(N'dbo.W_WaveSetting', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_WaveSetting] (
    [Code] nvarchar(50) NOT NULL,
    [Name] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [Deep] decimal(18,4) NOT NULL,
    [Rate] decimal(18,4) NOT NULL,
    [Position] nvarchar(50) NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_WaveSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* W_BundleSetting */
IF OBJECT_ID(N'dbo.W_BundleSetting', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_BundleSetting] (
    [HalfBundleMinWeight] int NOT NULL,
    [HalfBundleMinQty] int NOT NULL,
    [IsUseSplitPaperBundle] bit NOT NULL,
    [MinCutCount] int NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_BundleSetting] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 订单列表行背景色设置 */
IF OBJECT_ID(N'dbo.W_ColorSets', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ColorSets] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Code] nvarchar(255) NOT NULL,
    [WF_Name] nvarchar(255) NOT NULL,
    [WF_BackColor] nvarchar(255) NOT NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_Sort] nvarchar(255) NOT NULL,
    [WF_ForeColor] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_W_ColorSets] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_HotPlateSteamGram */
IF OBJECT_ID(N'dbo.W_HotPlateSteamGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_HotPlateSteamGram] (
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinSteam] int NOT NULL,
    [WF_MaxSteam] int NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_PrPressIncrease] int NULL,
    [WF_Offset_1st] decimal(18,2) NULL,
    [WF_Offset_2nd] decimal(18,2) NULL,
    [WF_Offset_3rd] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_HotPlateSteamGram] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 报警读写偏差值设置表 */
IF OBJECT_ID(N'dbo.W_IPS_AlarmRWSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_AlarmRWSet] (
    [WF_Code] nvarchar(50) NOT NULL,
    [WF_Name] nvarchar(50) NOT NULL,
    [WF_OffSet] decimal(18,2) NOT NULL,
    [WF_Interval] int NOT NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_IsSend] bit NOT NULL,
    [WF_IsSave] bit NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_AlarmRWSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 自动预警设置 */
IF OBJECT_ID(N'dbo.W_IPS_AlarmSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_AlarmSet] (
    [WF_Code] nvarchar(36) NOT NULL,
    [WF_Name] nvarchar(100) NULL,
    [WF_Desc] nvarchar(max) NULL,
    [WF_AlarmCron] nvarchar(200) NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_IsSend] bit NOT NULL,
    [WF_IsSave] bit NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_AlarmSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* BHS喷淋基础设置表 */
IF OBJECT_ID(N'dbo.W_IPS_BHS_Spray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_BHS_Spray] (
    [WF_Position] nvarchar(50) NULL,
    [WF_IsUse] bit NULL,
    [WF_Power] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_BHS_Spray] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 天桥张力设置 */
IF OBJECT_ID(N'dbo.W_IPS_BridgeTension', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_BridgeTension] (
    [WF_Position] int NOT NULL,
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_MinValue] int NOT NULL,
    [WF_MaxValue] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_BridgeTension] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 天桥张力门幅设置 */
IF OBJECT_ID(N'dbo.W_IPS_BridgeTensionWidth', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_BridgeTensionWidth] (
    [WF_Width] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_BridgeTensionWidth] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_ChangeMaterialQua */
IF OBJECT_ID(N'dbo.W_IPS_ChangeMaterialQua', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_ChangeMaterialQua] (
    [WF_MachinePosition] nvarchar(50) NULL,
    [WF_RealMaterialQua] nvarchar(50) NULL,
    [WF_RealWidth] int NULL,
    [WF_TheoryMaterialQua] nvarchar(50) NULL,
    [WF_TheoryWidth] int NULL,
    [WF_TheoryNextMaterialQua] nvarchar(50) NULL,
    [WF_TheoryNextWidth] int NULL,
    [WF_SF_SameRemainMeter] int NULL,
    [WF_DF_SameRemainMeter] int NULL,
    [WF_IsSameReplaceMaterialQua] bit NULL,
    [WF_IsRelaceMaterialQua] bit NULL,
    [WF_DateTime] datetime2 NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_ChangeMaterialQua] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 瓦楞辊压力设置表 */
IF OBJECT_ID(N'dbo.W_IPS_CorrugatedRollPaperPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CorrugatedRollPaperPress] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NULL,
    [WF_PressValue] decimal(18,2) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CorrugatedRollPaperPress] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 瓦楞辊机台系数表 */
IF OBJECT_ID(N'dbo.W_IPS_CorrugatedRollSFCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CorrugatedRollSFCoef] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_SF1Coef] decimal(18,2) NULL,
    [WF_SF2Coef] decimal(18,2) NULL,
    [WF_SF3Coef] decimal(18,2) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CorrugatedRollSFCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 瓦楞辊门幅系数表 */
IF OBJECT_ID(N'dbo.W_IPS_CorrugatedRollWidthCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CorrugatedRollWidthCoef] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CorrugatedRollWidthCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 换愣降速设置 */
IF OBJECT_ID(N'dbo.W_IPS_CruiseChangewave', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CruiseChangewave] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Flute1] nvarchar(255) NOT NULL,
    [WF_Flute2] nvarchar(255) NOT NULL,
    [WF_PreMeter] int NOT NULL,
    [WF_Speed] int NOT NULL,
    CONSTRAINT [PK_W_IPS_CruiseChangewave] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 小订单米数对应的巡航车速 */
IF OBJECT_ID(N'dbo.W_IPS_CruiseOrderMeterSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CruiseOrderMeterSpeed] (
    [WF_Meter] int NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CruiseOrderMeterSpeed] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 备卷未就绪 剩余米数对应的巡航车速 */
IF OBJECT_ID(N'dbo.W_IPS_CuriseRamain', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CuriseRamain] (
    [WF_Remain] int NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CuriseRamain] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 糊机糊间隙基础设置表 */
IF OBJECT_ID(N'dbo.W_IPS_GlueGu', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_GlueGu] (
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_Position] int NOT NULL,
    [WF_MinGlue] int NOT NULL,
    [WF_MaxGlue] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_GlueGu] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 单面机糊间隙设置 */
IF OBJECT_ID(N'dbo.W_IPS_GlueSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_GlueSF] (
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_MinGlue] int NOT NULL,
    [WF_MaxGlue] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_GlueSF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 糊间隙车速系数设置 */
IF OBJECT_ID(N'dbo.W_IPS_GlueSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_GlueSpeedCoef] (
    [WF_Position] int NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_MinValue] int NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_GlueSpeedCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 坑机热喷雾设置 */
IF OBJECT_ID(N'dbo.W_IPS_HotSpraySF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_HotSpraySF] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NULL,
    [WF_Value] decimal(18,2) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_HotSpraySF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 三段热板蒸汽设置表 */
IF OBJECT_ID(N'dbo.W_IPS_HotSteam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_HotSteam] (
    [WF_Flute] nvarchar(100) NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Part1] decimal(18,2) NOT NULL,
    [WF_Part2] decimal(18,2) NOT NULL,
    [WF_Part3] decimal(18,2) NOT NULL,
    [WF_MinValue] decimal(18,2) NOT NULL,
    [WF_MaxValue] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_HotSteam] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 三段热板蒸汽车速系数表 */
IF OBJECT_ID(N'dbo.W_IPS_HotSteamSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_HotSteamSpeedCoef] (
    [WF_Speed] int NOT NULL,
    [WF_Coef3] decimal(18,2) NULL,
    [WF_Coef4] decimal(18,2) NULL,
    [WF_Coef5] decimal(18,2) NULL,
    [WF_Coef6] decimal(18,2) NULL,
    [WF_Coef7] decimal(18,2) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_HotSteamSpeedCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_MaterialQuaForMachine */
IF OBJECT_ID(N'dbo.W_IPS_MaterialQuaForMachine', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_MaterialQuaForMachine] (
    [WF_P04TID] int NULL,
    [WF_ErpTableId] bigint NOT NULL,
    [WF_MachinePsition] nvarchar(50) NOT NULL,
    [WF_MaterialQua] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_Barcode] nvarchar(100) NOT NULL,
    [WF_StartOrderId] int NOT NULL,
    [WF_EndOrderId] int NULL,
    [WF_GUID] nvarchar(200) NULL,
    [WF_ErpStartRollMeters] int NULL,
    [WF_StartSameMeters] int NULL,
    [WF_EndSameMeters] int NULL,
    [WF_StartRollMeters] int NULL,
    [WF_EndRollMeters] int NULL,
    [WF_StartTime] datetime2 NULL,
    [WF_UpdateTime] datetime2 NULL,
    [WF_EndTime] datetime2 NULL,
    [WF_UseMeters] int NULL,
    [WF_TheoryMaterialQua] nvarchar(50) NULL,
    [WF_TheoryWidth] int NULL,
    [WF_IsSameReplaceMaterialQua] bit NULL,
    [WF_IsRelaceMaterialQua] bit NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_MaterialQuaForMachine] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_PressRoll */
IF OBJECT_ID(N'dbo.W_IPS_PressRoll', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PressRoll] (
    [WF_MinWidth] int NOT NULL,
    [WF_MaxWidth] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_MinPress] decimal(18,2) NOT NULL,
    [WF_MaxPress] decimal(18,2) NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_PressRoll] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_PressRollCoef */
IF OBJECT_ID(N'dbo.W_IPS_PressRollCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PressRollCoef] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_CoefSF1] decimal(18,2) NOT NULL,
    [WF_CoefSF2] decimal(18,2) NOT NULL,
    [WF_CoefSF3] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_PressRollCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_PressRollSpeedCoef */
IF OBJECT_ID(N'dbo.W_IPS_PressRollSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PressRollSpeedCoef] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Machine] nvarchar(255) NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Coef] decimal(18,4) NOT NULL,
    CONSTRAINT [PK_W_IPS_PressRollSpeedCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_PressRollWidth_MP */
IF OBJECT_ID(N'dbo.W_IPS_PressRollWidth_MP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PressRollWidth_MP] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_Flute] nvarchar(255) NOT NULL,
    [WF_Coef] decimal(18,4) NOT NULL,
    [WF_Machine] nvarchar(255) NOT NULL,
    CONSTRAINT [PK_W_IPS_PressRollWidth_MP] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_PressRoll_MP */
IF OBJECT_ID(N'dbo.W_IPS_PressRoll_MP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PressRoll_MP] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Machine] nvarchar(255) NOT NULL,
    [WF_Flute] nvarchar(255) NOT NULL,
    [WF_WgtMin] decimal(18,4) NOT NULL,
    [WF_WgtMax] decimal(18,4) NOT NULL,
    [WF_ValueMin] decimal(18,4) NOT NULL,
    [WF_ValueMax] decimal(18,4) NOT NULL,
    CONSTRAINT [PK_W_IPS_PressRoll_MP] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 压力辊QDM系数表 */
IF OBJECT_ID(N'dbo.W_IPS_QDMPressRollCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_QDMPressRollCoef] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_QdmID] int NOT NULL,
    [WF_CoefSF1] decimal(18,2) NOT NULL,
    [WF_CoefSF2] decimal(18,2) NOT NULL,
    [WF_CoefSF3] decimal(18,2) NOT NULL,
    CONSTRAINT [PK_W_IPS_QDMPressRollCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 双面机糊机QDM系数 */
IF OBJECT_ID(N'dbo.W_IPS_QdmCoefDF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_QdmCoefDF] (
    [WF_Paper] nvarchar(100) NOT NULL,
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_Glue1] decimal(18,2) NOT NULL,
    [WF_Glue2] decimal(18,2) NOT NULL,
    [WF_Glue3] decimal(18,2) NOT NULL,
    [WF_Wrap0] decimal(18,2) NOT NULL,
    [WF_Wrap1] decimal(18,2) NOT NULL,
    [WF_Wrap2] decimal(18,2) NOT NULL,
    [WF_Wrap3] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam0] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam1] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam2] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam3] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam1] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam2] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam3] decimal(18,2) NOT NULL,
    [WF_HotLoadGroupQty] decimal(18,2) NOT NULL,
    [WF_HotPlatePress] decimal(18,2) NOT NULL,
    [WF_ColdPlatePress] decimal(18,2) NOT NULL,
    [WF_SplicerTensionLS0] decimal(18,2) NOT NULL,
    [WF_BridgeTension1] decimal(18,2) NOT NULL,
    [WF_BridgeTension2] decimal(18,2) NOT NULL,
    [WF_BridgeTension3] decimal(18,2) NOT NULL,
    [WF_Spray0] decimal(18,2) NOT NULL,
    [WF_Spray1] decimal(18,2) NOT NULL,
    [WF_Spray2] decimal(18,2) NOT NULL,
    [WF_Spray3] decimal(18,2) NOT NULL,
    [WF_CruiseSpeed] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_QdmCoefDF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 单面机QDM系数 */
IF OBJECT_ID(N'dbo.W_IPS_QdmCoefSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_QdmCoefSF] (
    [WF_MS] nvarchar(10) NOT NULL,
    [WF_LS] nvarchar(10) NOT NULL,
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_Glue] decimal(18,2) NOT NULL,
    [WF_WrapMS] decimal(18,2) NOT NULL,
    [WF_WrapLS] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam] decimal(18,2) NOT NULL,
    [WF_PressRoll] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll] decimal(18,2) NOT NULL,
    [WF_SplicerTensionMS] decimal(18,2) NOT NULL,
    [WF_SplicerTensionLS] decimal(18,2) NOT NULL,
    [WF_VacuumBlower] decimal(18,2) NOT NULL,
    [WF_Spray] decimal(18,2) NOT NULL,
    [WF_CruiseSpeed] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_QdmCoefSF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* IPS控制模块显示/隐藏设置 */
IF OBJECT_ID(N'dbo.W_IPS_VisibleSets', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_VisibleSets] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Code] nvarchar(255) NOT NULL,
    [WF_Name] nvarchar(255) NOT NULL,
    [WF_IsShow] bit NOT NULL,
    CONSTRAINT [PK_W_IPS_VisibleSets] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 弯翘设备检测信息表 */
IF OBJECT_ID(N'dbo.W_IPS_WarpInspect', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WarpInspect] (
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    [WF_WarpState] nvarchar(100) NULL,
    [WF_WarpDegree] decimal(18,4) NULL,
    [WF_CreateTime] datetime2 NULL,
    CONSTRAINT [PK_W_IPS_WarpInspect] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 弯翘调平设置表 */
IF OBJECT_ID(N'dbo.W_IPS_WarpSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WarpSet] (
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    [WF_Position] int NOT NULL,
    [WF_ThreeUp1] decimal(18,4) NULL,
    [WF_ThreeUp2] decimal(18,4) NULL,
    [WF_ThreeUp3] decimal(18,4) NULL,
    [WF_ThreeDown1] decimal(18,4) NULL,
    [WF_ThreeDown2] decimal(18,4) NULL,
    [WF_ThreeDown3] decimal(18,4) NULL,
    [WF_FourUp1] decimal(18,4) NULL,
    [WF_FourUp2] decimal(18,4) NULL,
    [WF_FourUp3] decimal(18,4) NULL,
    [WF_FourDown1] decimal(18,4) NULL,
    [WF_FourDown2] decimal(18,4) NULL,
    [WF_FourDown3] decimal(18,4) NULL,
    [WF_FiveUp1] decimal(18,4) NULL,
    [WF_FiveUp2] decimal(18,4) NULL,
    [WF_FiveUp3] decimal(18,4) NULL,
    [WF_FiveDown1] decimal(18,4) NULL,
    [WF_FiveDown2] decimal(18,4) NULL,
    [WF_FiveDown3] decimal(18,4) NULL,
    [WF_SixUp1] decimal(18,4) NULL,
    [WF_SixUp2] decimal(18,4) NULL,
    [WF_SixUp3] decimal(18,4) NULL,
    [WF_SixDown1] decimal(18,4) NULL,
    [WF_SixDown2] decimal(18,4) NULL,
    [WF_SixDown3] decimal(18,4) NULL,
    [WF_SevenUp1] decimal(18,4) NULL,
    [WF_SevenUp2] decimal(18,4) NULL,
    [WF_SevenUp3] decimal(18,4) NULL,
    [WF_SevenDown1] decimal(18,4) NULL,
    [WF_SevenDown2] decimal(18,4) NULL,
    [WF_SevenDown3] decimal(18,4) NULL,
    CONSTRAINT [PK_W_IPS_WarpSet] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 糊机烘缸包角设置 */
IF OBJECT_ID(N'dbo.W_IPS_WrapGU', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapGU] (
    [WF_Position] int NOT NULL,
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_MinWrap] int NOT NULL,
    [WF_MaxWrap] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapGU] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 包角基础设置表 */
IF OBJECT_ID(N'dbo.W_IPS_WrapOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapOfMP] (
    [WF_Flag] int NOT NULL,
    [WF_Position] int NOT NULL,
    [WF_MinWrap] int NOT NULL,
    [WF_MaxWrap] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_Coef] decimal(18,2) NULL,
    [WF_AdustRange] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapOfMP] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 单面机烘缸包角设置 */
IF OBJECT_ID(N'dbo.W_IPS_WrapSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapSF] (
    [WF_Position] nvarchar(10) NOT NULL,
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_MinWrap] int NOT NULL,
    [WF_MaxWrap] int NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapSF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 车速修正 */
IF OBJECT_ID(N'dbo.W_IPS_WrapSpeedOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapSpeedOfMP] (
    [WF_Flag] int NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Value] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapSpeedOfMP] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 糊机烘缸蒸汽设置表 */
IF OBJECT_ID(N'dbo.W_IPS_WrapSteamHPH', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapSteamHPH] (
    [WF_Flute] nvarchar(100) NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_GU0] decimal(18,2) NULL,
    [WF_GU1] decimal(18,2) NULL,
    [WF_GU2] decimal(18,2) NULL,
    [WF_GU3] decimal(18,2) NULL,
    [WF_GUAdd1] decimal(18,2) NULL,
    [WF_GUAdd2] decimal(18,2) NULL,
    [WF_GUAdd3] decimal(18,2) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapSteamHPH] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 单面机烘缸蒸汽设置表 */
IF OBJECT_ID(N'dbo.W_IPS_WrapSteamSF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapSteamSF] (
    [WF_Flute] nvarchar(100) NOT NULL,
    [WF_MinWeight] int NOT NULL,
    [WF_MaxWeight] int NOT NULL,
    [WF_Value] decimal(18,2) NOT NULL,
    [WF_MinValue] decimal(18,2) NOT NULL,
    [WF_MaxValue] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapSteamSF] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 单面机烘缸蒸汽车速系数表 */
IF OBJECT_ID(N'dbo.W_IPS_WrapSteamSFSpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapSteamSFSpeedCoef] (
    [WF_Speed] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapSteamSFSpeedCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 包角克重修正表 */
IF OBJECT_ID(N'dbo.W_IPS_WrapWeightOfMP', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_WrapWeightOfMP] (
    [WF_Flag] int NOT NULL,
    [WF_Weight] int NOT NULL,
    [WF_Value] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_WrapWeightOfMP] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 订单生产路线分配设置表 */
IF OBJECT_ID(N'dbo.W_OrderRoute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_OrderRoute] (
    [WF_OrderNum] int NOT NULL,
    [WF_OrderName] nvarchar(20) NOT NULL,
    [WF_CutoffAllocation] int NOT NULL,
    [WF_OSDS] int NOT NULL,
    [WF_IsDouble] bit NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_OrderRoute] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 订单扩展字段对应关系表 */
IF OBJECT_ID(N'dbo.W_Order_JsonTrans', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Order_JsonTrans] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Code] nvarchar(50) NULL,
    [WF_Name] nvarchar(50) NULL,
    [WF_DataType] nvarchar(20) NULL,
    [WF_IsShow] bit NOT NULL,
    [WF_DCode] nvarchar(50) NOT NULL,
    [WF_Sort] int NOT NULL,
    CONSTRAINT [PK_W_Order_JsonTrans] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_PMW_CurrentShiftStopMes */
IF OBJECT_ID(N'dbo.W_PMW_CurrentShiftStopMes', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMW_CurrentShiftStopMes] (
    [WF_CurrShiftNum] nvarchar(50) NULL,
    [WF_StopTimesDF] int NULL,
    [WF_StopDateTimeDF] int NULL,
    [WF_CurrP04SIdDF] int NULL,
    [WF_StopTimesSF1] int NULL,
    [WF_StopDateTimeSF1] int NULL,
    [WF_CurrP04SIdSF1] int NULL,
    [WF_StopTimesSF2] int NULL,
    [WF_StopDateTimeSF2] int NULL,
    [WF_CurrP04SIdSF2] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMW_CurrentShiftStopMes] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_PMS_EnergyMaintenance */
IF OBJECT_ID(N'dbo.W_PMS_EnergyMaintenance', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_EnergyMaintenance] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_P04TID] int NOT NULL,
    [WF_ShiftNum] nvarchar(20) NULL,
    [WF_StartTime] datetime2 NULL,
    [WF_EndTime] datetime2 NULL,
    [WF_Number] nvarchar(50) NULL,
    [WF_Name] nvarchar(50) NULL,
    [WF_StartValue] decimal(18,4) NULL,
    [WF_EndValue] decimal(18,4) NULL,
    [WF_DiffValue] decimal(18,4) NULL,
    [WF_Price] decimal(10,2) NULL,
    [WF_Source] nvarchar(50) NULL,
    [WF_ShowPrice] bit NULL,
    CONSTRAINT [PK_W_PMS_EnergyMaintenance] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 标签打印设置 */
IF OBJECT_ID(N'dbo.W_PMS_LabelPrint', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_LabelPrint] (
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_CN] int NOT NULL,
    [WF_CutWidth] int NOT NULL,
    [WF_LabelQty] int NOT NULL,
    CONSTRAINT [PK_W_PMS_LabelPrint] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_PMS_LineMsg */
IF OBJECT_ID(N'dbo.W_PMS_LineMsg', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_LineMsg] (
    [WF_IsRun] bit NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_LineMsg] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_PMS_Report_Class */
IF OBJECT_ID(N'dbo.W_PMS_Report_Class', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_Report_Class] (
    [WP04T_ID] int NULL,
    [WP04T_ShiftNumber] nvarchar(20) NULL,
    [WP04T_GroupNameShift] nvarchar(20) NULL,
    [WP04T_Year] int NULL,
    [WP04T_Month] int NULL,
    [WP04T_Day] int NULL,
    [WP04T_WeekDay] nvarchar(30) NULL,
    [WP04T_Week] int NULL,
    [WP04T_StartTime] datetime2 NULL,
    [WP04T_EndTime] datetime2 NULL,
    [WP04T_StartYearMontDay] datetime2 NULL,
    [WP04P_StartTime] datetime2 NULL,
    [WP04P_EndTime] datetime2 NULL,
    [WP04T_ProduceTime] decimal(28,2) NULL,
    [WP04T_OrderStopTime] int NULL,
    [WP04T_OrderStopNum] int NULL,
    [WP04T_ScheduleMeter] float NULL,
    [WP04T_ProduceMeter] float NULL,
    [WP04T_BadMeter] float NULL,
    [WP04T_GoodMeter] float NULL,
    [WP04T_ScheduleArea] float NULL,
    [WP04T_ProduceArea] float NULL,
    [WP04T_BadArea] float NULL,
    [WP04T_GoodArea] float NULL,
    [WP04T_ScheduleSheet] bigint NULL,
    [WP04T_ProduceSheet] bigint NULL,
    [WP04T_BadSheet] bigint NULL,
    [WP04T_GoodSheet] bigint NULL,
    [WP04T_AvgSpeed] decimal(28,2) NULL,
    [WP04T_BadPercent] decimal(18,6) NULL,
    [WP04T_TrimArea] float NULL,
    [WP04T_TrimPecent] decimal(18,6) NULL,
    [WP04T_OrderNum] bigint NULL,
    [WP04T_AvgWidth] int NULL,
    [WP04T_AvgMeter] decimal(18,2) NULL,
    [WP04T_PaperCodeNum] int NULL,
    [WP04T_PaperCodeAvgMeter] decimal(18,2) NULL,
    [WP04T_BadOrderNum] int NULL,
    [WP04T_BadMuchNum] int NULL,
    [WP04T_OrderNumUp] bigint NULL,
    [WP04T_OrderNumUp_All] bigint NULL,
    [WP04T_OrderNumDown] bigint NULL,
    [WP04T_CountWidth] float NULL,
    [WP04T_IsEnd] bit NULL,
    [WP04T_AccumulatedSteamFlow] decimal(18,4) NULL,
    [WP04T_AccumulatedElectricity] decimal(18,4) NULL,
    [WP04T_TheoryWeight] decimal(18,4) NULL,
    [WP04T_SteamRate] decimal(18,4) NULL,
    [WP04T_ElectricityRate] decimal(18,4) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_Report_Class] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_PMS_StopReasonRecord */
IF OBJECT_ID(N'dbo.W_PMS_StopReasonRecord', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_StopReasonRecord] (
    [WF_P04SID] int NOT NULL,
    [WF_StopReason] nvarchar(200) NOT NULL,
    [WF_StopReasonID] int NOT NULL,
    [WF_StopType] nvarchar(200) NOT NULL,
    [WF_StopTypeID] int NOT NULL,
    [WF_StatisticsStop] bit NOT NULL,
    [WF_PartName] nvarchar(50) NOT NULL,
    [WF_CreateUser] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_UpdateUser] nvarchar(50) NULL,
    [WF_UpdateTime] datetime2 NULL,
    [WF_Remark] nvarchar(500) NULL,
    [WF_IsModify] bit NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_StopReasonRecord] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_Plc_AcceleratorSet */
IF OBJECT_ID(N'dbo.W_Plc_AcceleratorSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_AcceleratorSet] (
    [WF_Speed] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_AcceleratorSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC设备表 */
IF OBJECT_ID(N'dbo.W_Plc_Driver', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_Driver] (
    [WF_Code] nvarchar(36) NOT NULL,
    [WF_Name] nvarchar(100) NOT NULL,
    [WF_CommunicationType] int NOT NULL,
    [WF_ConfigCode] nvarchar(36) NOT NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_Driver] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC设备配置表 */
IF OBJECT_ID(N'dbo.W_Plc_DriverConfig', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_DriverConfig] (
    [WF_Code] nvarchar(36) NOT NULL,
    [WF_Name] nvarchar(100) NULL,
    [WF_Desc] nvarchar(max) NULL,
    [WF_ParCode] nvarchar(100) NULL,
    [WF_ParValue] nvarchar(100) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_DriverConfig] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC点位配置表 */
IF OBJECT_ID(N'dbo.W_Plc_PointVar', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_PointVar] (
    [WF_Code] nvarchar(200) NOT NULL,
    [WF_Name] nvarchar(100) NULL,
    [WF_Desc] nvarchar(100) NULL,
    [WF_DriverCode] nvarchar(36) NULL,
    [WF_VarAddress] nvarchar(100) NULL,
    [WF_DataType] nvarchar(36) NULL,
    [WF_RW] int NOT NULL,
    [WF_Interval] int NOT NULL,
    [WF_Priority] int NOT NULL,
    [WF_IsUse] bit NULL,
    [WF_CurValue] nvarchar(100) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Position] nvarchar(50) NULL,
    [WF_IsAlarm] bit NOT NULL,
    [WF_AlarmInterval] int NOT NULL,
    [WF_AlarmOffset] decimal(18,2) NOT NULL,
    [WF_DataOKAddress] nvarchar(100) NULL,
    [WF_DataOKDataType] nvarchar(36) NULL,
    [WF_TransferKeyAddress] nvarchar(100) NULL,
    [WF_TransferKeyDataType] nvarchar(36) NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_PointVar] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC喷雾设置 */
IF OBJECT_ID(N'dbo.W_Plc_SpraySet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_SpraySet] (
    [WF_Flute] nvarchar(10) NOT NULL,
    [WF_MinPower] decimal(18,2) NOT NULL,
    [WF_MaxPower] decimal(18,2) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_CoefUp] decimal(18,2) NOT NULL,
    [WF_CoefMid] decimal(18,2) NOT NULL,
    [WF_CoefDown] decimal(18,2) NOT NULL,
    [WF_CoefDF] decimal(18,2) NOT NULL,
    [WF_Speed30] decimal(18,2) NOT NULL,
    [WF_Speed50] decimal(18,2) NOT NULL,
    [WF_Speed80] decimal(18,2) NOT NULL,
    [WF_Speed110] decimal(18,2) NOT NULL,
    [WF_Speed130] decimal(18,2) NOT NULL,
    [WF_Speed160] decimal(18,2) NOT NULL,
    [WF_Speed180] decimal(18,2) NOT NULL,
    [WF_Speed210] decimal(18,2) NOT NULL,
    [WF_Speed240] decimal(18,2) NOT NULL,
    [WF_Speed270] decimal(18,2) NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_SpraySet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC喷雾车速系数表 */
IF OBJECT_ID(N'dbo.W_Plc_SpraySpeedCoef', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_SpraySpeedCoef] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Coef] decimal(18,2) NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_SpraySpeedCoef] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC喷嘴设置 */
IF OBJECT_ID(N'dbo.W_Plc_SprayWidthSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Plc_SprayWidthSet] (
    [WF_Code] int NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Plc_SprayWidthSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 延时自动 */
IF OBJECT_ID(N'dbo.W_QDM_AutoDelay', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_AutoDelay] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Glue] int NULL,
    [WF_Wrap] int NULL,
    [WF_Tension] int NULL,
    [WF_PressRollPress] int NULL,
    [WF_CorrugatedRollPress] int NULL,
    [WF_Steam] int NULL,
    [WF_Spray] int NULL,
    [WF_LoadingSystemQty] int NULL,
    [WF_OffsetTension] int NULL,
    [WF_HotPlateSteam] int NULL,
    [WF_HotPlatePress] int NULL,
    [WF_ColdPlatePress] int NULL,
    [WF_Type] int NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_CruiseSpeed] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_AutoDelay] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* BHS喷雾 */
IF OBJECT_ID(N'dbo.W_QDM_BHSSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_BHSSpray] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_MinPercentage] decimal(18,2) NOT NULL,
    [WF_MaxPercentage] decimal(18,2) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_BHSSpray] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* BHS热喷雾车速系数 */
IF OBJECT_ID(N'dbo.W_QDM_BHSSpraySpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_BHSSpraySpeedFactor] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Factor] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_BHSSpraySpeedFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 泠凝回水备压 */
IF OBJECT_ID(N'dbo.W_QDM_BackWaterForPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_BackWaterForPress] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_HighPreDecompressionIV] decimal(18,2) NOT NULL,
    [WF_HighPreDecompressionEV] decimal(18,2) NOT NULL,
    [WF_LowPreDecompressionIV] decimal(18,2) NOT NULL,
    [WF_LowPreDecompressionEV] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_BackWaterForPress] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 天桥张力楞型系数 */
IF OBJECT_ID(N'dbo.W_QDM_BridgeFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_BridgeFluteFactor] (
    [WF_Position] nvarchar(50) NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_FluteFactor] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_BridgeFluteFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 天桥张力克重表 */
IF OBJECT_ID(N'dbo.W_QDM_BridgeTension', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_BridgeTension] (
    [WF_Position] nvarchar(50) NULL,
    [WF_MinTension] int NULL,
    [WF_MaxTension] int NULL,
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_GramFactor] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_BridgeTension] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 冷板压力 */
IF OBJECT_ID(N'dbo.W_QDM_ColdPlatePressure', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_ColdPlatePressure] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_AirPress] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_ColdPlatePressure] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 瓦楞楞型部位系数 */
IF OBJECT_ID(N'dbo.W_QDM_CorrugatedFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_CorrugatedFluteFactor] (
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_CorrugatedRollPre_ID] int NOT NULL,
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_Factor] decimal(18,2) NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_CorrugatedFluteFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 瓦楞辊压力 */
IF OBJECT_ID(N'dbo.W_QDM_CorrugatedRollerPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_CorrugatedRollerPress] (
    [WF_MinWidth] int NOT NULL,
    [WF_MaxWidth] int NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_WidthFactor] decimal(18,2) NOT NULL,
    [WF_MinPressure] int NOT NULL,
    [WF_MaxPressure] int NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_DSFactor] decimal(18,2) NOT NULL,
    [WF_OSFactor] decimal(18,2) NOT NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_CorrugatedRollerPress] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 坑机车速巡航 */
IF OBJECT_ID(N'dbo.W_QDM_CruisingSFSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_CruisingSFSpeed] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinSpeed] int NOT NULL,
    [WF_MaxSpeed] int NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_CruisingSFSpeed] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 车速巡航 */
IF OBJECT_ID(N'dbo.W_QDM_CruisingSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_CruisingSpeed] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinSpeed] int NOT NULL,
    [WF_MaxSpeed] int NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_CruisingSpeed] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_DataBase_DF */
IF OBJECT_ID(N'dbo.W_QDM_DataBase_DF', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_DataBase_DF] (
    [WF_DF_MaterialQua] nvarchar(50) NULL,
    [WF_DF_Flute] nvarchar(50) NULL,
    [WF_Glue_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [WF_Glue_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [WF_Wrap_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [WF_Wrap_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [WF_Wrap_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [WF_PreheaterSteam_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [WF_PreheaterSteam_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [WF_PreheaterSteam_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [WF_HotPlateSteam_DF_1Part_QDM_Factor] decimal(18,2) NULL,
    [WF_HotPlateSteam_DF_2Part_QDM_Factor] decimal(18,2) NULL,
    [WF_HotPlateSteam_DF_3Part_QDM_Factor] decimal(18,2) NULL,
    [WF_HotLoadGroupQty_DF_QDM_Factor] decimal(18,2) NULL,
    [WF_HotPlatePress_DF_QDM_Factor] decimal(18,2) NULL,
    [WF_ColdPlatePress_DF_QDM_Factor] decimal(18,2) NULL,
    [WF_SplicerTension_LS0_QDM_FactorLS0] decimal(18,2) NULL,
    [WF_BridgeTension_GU_1st_QDM_FactorGU1] decimal(18,2) NULL,
    [WF_BridgeTension_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [WF_Spray_GU_0_QDM_FactorGU0] decimal(18,2) NULL,
    [WF_Spray_GU_2nd_QDM_FactorGU2] decimal(18,2) NULL,
    [WF_CruisingSpeed_DF_QDM_Factor] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_DataBase_DF] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_DataBase_List */
IF OBJECT_ID(N'dbo.W_QDM_DataBase_List', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_DataBase_List] (
    [WF_MaterialQua] nvarchar(50) NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_DF_Id] int NULL,
    [WF_SF1_Id] int NULL,
    [WF_SF2_Id] int NULL,
    [WF_SF3_Id] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_DataBase_List] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_DataBase_SF1 */
IF OBJECT_ID(N'dbo.W_QDM_DataBase_SF1', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_DataBase_SF1] (
    [WF_SF1_MaterialQua] nvarchar(50) NULL,
    [WF_SF1_Flute] nvarchar(50) NULL,
    [WF_SF1_LineFlute] nvarchar(50) NULL,
    [WF_Glue_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_Wrap_MS1_QDM_FactorMS1] decimal(18,2) NULL,
    [WF_Wrap_LS1_QDM_FactorLS1] decimal(18,2) NULL,
    [WF_PreheaterSteam_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_PressRoll_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_CorrugatedRoll_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_SplicerTension_MS1_QDM_FactorMS1] decimal(18,2) NULL,
    [WF_SplicerTension_LS1_QDM_FactorLS1] decimal(18,2) NULL,
    [WF_VacuumBlower_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_Spray_SF1_QDM_FactorSF1] decimal(18,2) NULL,
    [WF_CruisingSpeed_SF1_QDM_Factor] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_DataBase_SF1] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_DataBase_SF2 */
IF OBJECT_ID(N'dbo.W_QDM_DataBase_SF2', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_DataBase_SF2] (
    [WF_SF2_MaterialQua] nvarchar(50) NULL,
    [WF_SF2_Flute] nvarchar(50) NULL,
    [WF_SF2_LineFlute] nvarchar(50) NULL,
    [WF_Glue_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_Wrap_MS2_QDM_FactorMS2] decimal(18,2) NULL,
    [WF_Wrap_LS2_QDM_FactorLS2] decimal(18,2) NULL,
    [WF_PreheaterSteam_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_PressRoll_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_CorrugatedRoll_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_SplicerTension_MS2_QDM_FactorMS2] decimal(18,2) NULL,
    [WF_SplicerTension_LS2_QDM_FactorLS2] decimal(18,2) NULL,
    [WF_VacuumBlower_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_Spray_SF2_QDM_FactorSF2] decimal(18,2) NULL,
    [WF_CruisingSpeed_SF2_QDM_Factor] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_DataBase_SF2] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 当前运行参数(包含各种QMD系数和界面系数以及是否启用) */
IF OBJECT_ID(N'dbo.W_QDM_FormSetFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_FormSetFactor] (
    [WF_Glue_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Glue_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Glue_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_LS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Wrap_LS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Wrap_LS3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_MS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Wrap_MS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Wrap_MS3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF1_OS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF1_DS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF2_OS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF2_DS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF3_OS_Form_Factor] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF3_DS_Form_Factor] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF1_OS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF1_DS_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF2_OS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF2_DS_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF3_OS_Form_Factor] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF3_DS_Form_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_1Part_Form_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_2Part_Form_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_3Part_Form_Factor] decimal(18,2) NOT NULL,
    [WF_HotLoadGroupQty_DF_Form_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlatePress_DF_Form_Factor] decimal(18,2) NOT NULL,
    [WF_ColdPlatePress_DF_Form_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS0_Form_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_1st_Form_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_GU_0_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_GU_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_SF1_Form_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Spray_SF2_Form_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Spray_SF3_Form_Factor] decimal(18,2) NOT NULL,
    [WF_CruisingSpeed_DF_Form_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_1st_Form_IsOpen] bit NOT NULL,
    [WF_Glue_GU_2nd_Form_IsOpen] bit NOT NULL,
    [WF_Glue_GU_3rd_Form_IsOpen] bit NOT NULL,
    [WF_Glue_SF1_Form_IsOpen] bit NOT NULL,
    [WF_Glue_SF2_Form_IsOpen] bit NOT NULL,
    [WF_Glue_SF3_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_GU_0_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_GU_1st_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_GU_2nd_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_GU_3rd_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_LS1_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_LS2_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_LS3_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_MS1_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_MS2_Form_IsOpen] bit NOT NULL,
    [WF_Wrap_MS3_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_GU_0_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_GU_1st_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_GU_2nd_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_GU_3rd_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_SF1_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_SF2_Form_IsOpen] bit NOT NULL,
    [WF_PreheaterSteam_SF3_Form_IsOpen] bit NOT NULL,
    [WF_PressRoll_SF1_Form_IsOpen] bit NOT NULL,
    [WF_PressRoll_SF2_Form_IsOpen] bit NOT NULL,
    [WF_PressRoll_SF3_Form_IsOpen] bit NOT NULL,
    [WF_CorrugatedRoll_SF1_Form_IsOpen] bit NOT NULL,
    [WF_CorrugatedRoll_SF2_Form_IsOpen] bit NOT NULL,
    [WF_CorrugatedRoll_SF3_Form_IsOpen] bit NOT NULL,
    [WF_HotPlateSteam_DF_1Part_Form_IsOpen] bit NOT NULL,
    [WF_HotPlateSteam_DF_2Part_Form_IsOpen] bit NOT NULL,
    [WF_HotPlateSteam_DF_3Part_Form_IsOpen] bit NOT NULL,
    [WF_HotLoadGroupQty_DF_Form] bit NOT NULL,
    [WF_HotPlatePress_DF_Form_IsOpen] bit NOT NULL,
    [WF_ColdPlatePress_DF_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_LS0_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_MS1_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_LS1_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_MS2_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_LS2_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_MS3_Form_IsOpen] bit NOT NULL,
    [WF_SplicerTension_LS3_Form_IsOpen] bit NOT NULL,
    [WF_BridgeTension_GU_1st_Form_IsOpen] bit NOT NULL,
    [WF_BridgeTension_GU_2nd_Form_IsOpen] bit NOT NULL,
    [WF_BridgeTension_GU_3rd_Form_IsOpen] bit NOT NULL,
    [WF_VacuumBlower_SF1_Form_IsOpen] bit NOT NULL,
    [WF_VacuumBlower_SF2_Form_IsOpen] bit NOT NULL,
    [WF_VacuumBlower_SF3_Form_IsOpen] bit NOT NULL,
    [WF_Spray_GU_0_Form_IsOpen] bit NOT NULL,
    [WF_Spray_GU_2nd_Form_IsOpen] bit NOT NULL,
    [WF_Spray_SF1_Form_IsOpen] bit NOT NULL,
    [WF_Spray_SF2_Form_IsOpen] bit NOT NULL,
    [WF_Spray_SF3_Form_IsOpen] bit NOT NULL,
    [WF_CruisingSpeed_ALL_Form_IsOpen] bit NOT NULL,
    [WF_CruisingSpeed_DF_Form_IsOpen] bit NOT NULL,
    [WF_CruisingSpeed_SF1_Form_IsOpen] bit NOT NULL,
    [WF_CruisingSpeed_SF2_Form_IsOpen] bit NOT NULL,
    [WF_CruisingSpeed_SF3_Form_IsOpen] bit NOT NULL,
    [WF_Glue_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Glue_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Glue_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_LS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Wrap_LS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Wrap_LS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Wrap_MS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Wrap_MS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Wrap_MS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PreheaterSteam_SF3_Form] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF1_OS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF1_DS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF2_OS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF2_DS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF3_OS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_PressRoll_SF3_DS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF1_OS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF1_DS_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF2_OS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF2_DS_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF3_OS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_CorrugatedRoll_SF3_DS_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_1Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_2Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlateSteam_DF_3Part_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_HotLoadGroupQty_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_HotPlatePress_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_ColdPlatePress_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_SplicerTension_MS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_SplicerTension_LS3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_1st_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_BridgeTension_GU_3rd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_VacuumBlower_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_GU_0_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_GU_2nd_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Spray_SF1_FormQdm_FactorSF1] decimal(18,2) NOT NULL,
    [WF_Spray_SF2_FormQdm_FactorSF2] decimal(18,2) NOT NULL,
    [WF_Spray_SF3_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_CruisingSpeed_DF_FormQdm_Factor] decimal(18,2) NOT NULL,
    [WF_Glue_GU_1st_Form_IsOn] bit NULL,
    [WF_Glue_GU_2nd_Form_IsOn] bit NULL,
    [WF_Glue_GU_3rd_Form_IsOn] bit NULL,
    [WF_Wrap_GU_1st_Form_IsOn] bit NULL,
    [WF_Wrap_GU_2nd_Form_IsOn] bit NULL,
    [WF_Wrap_GU_3rd_Form_IsOn] bit NULL,
    [WF_RidingRoll_1st_Form_Factor] decimal(18,2) NOT NULL,
    [WF_RidingRoll_2nd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_RidingRoll_3rd_Form_Factor] decimal(18,2) NOT NULL,
    [WF_RidingRoll_1st_Form_IsOpen] bit NOT NULL,
    [WF_RidingRoll_2nd_Form_IsOpen] bit NOT NULL,
    [WF_RidingRoll_3rd_Form_IsOpen] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    [WF_Warp_Form_IsOpen] bit NOT NULL,
    CONSTRAINT [PK_W_QDM_FormSetFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 糊盆液位 */
IF OBJECT_ID(N'dbo.W_QDM_GlueLiquidLevel', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_GlueLiquidLevel] (
    [WF_MeasureLiquidHeight] int NULL,
    [WF_LiquidHeight] int NOT NULL,
    [WF_GlueLiquidHeight] int NOT NULL,
    [WF_AlarmLiquidHeight] int NOT NULL,
    [WF_LoadingSpeed] int NOT NULL,
    [WF_HaltLiquidHeight] int NOT NULL,
    [WF_IsActive] bit NOT NULL,
    [WF_IsAlarm] bit NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_GlueLiquidLevel] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 糊间隙车速 */
IF OBJECT_ID(N'dbo.W_QDM_GlueSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_GlueSpeed] (
    [WF_Speed] int NULL,
    [WF_SpeedFactor] decimal(18,2) NULL,
    [WF_Positon] nvarchar(50) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_GlueSpeed] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 压板组数 */
IF OBJECT_ID(N'dbo.W_QDM_HotLoadGroupQty', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_HotLoadGroupQty] (
    [WF_Flute] nvarchar(50) NULL,
    [WF_StartLoadSpeed] int NULL,
    [WF_StartLoadGroupQty] int NULL,
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_MinGramFullLoadSpeed] int NULL,
    [WF_MaxGramFullLoadSpeed] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_SortNo] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_HotLoadGroupQty] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 热板克重气压 */
IF OBJECT_ID(N'dbo.W_QDM_HotPlateGramAirPress', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_HotPlateGramAirPress] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinPressure] decimal(18,2) NOT NULL,
    [WF_MaxPressure] decimal(18,2) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_FluteFactor] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_HotPlateGramAirPress] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 热板蒸汽压力 */
IF OBJECT_ID(N'dbo.W_QDM_HotPlateSteamGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_HotPlateSteamGram] (
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinSteam] decimal(18,2) NOT NULL,
    [WF_MaxSteam] decimal(18,2) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_PrPressIncrease] int NULL,
    [WF_Offset_1st] decimal(18,2) NULL,
    [WF_Offset_2nd] decimal(18,2) NULL,
    [WF_Offset_3rd] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_HotPlateSteamGram] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_HotPlateSteamGramRange */
IF OBJECT_ID(N'dbo.W_QDM_HotPlateSteamGramRange', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_HotPlateSteamGramRange] (
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_SortNo] int NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_HotPlateSteamGramRange] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_HotPlateSteamSpeed */
IF OBJECT_ID(N'dbo.W_QDM_HotPlateSteamSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_HotPlateSteamSpeed] (
    [WF_Speed] int NULL,
    [WF_SpeedFactor] decimal(18,2) NULL,
    [WF_Layer] int NULL,
    [WF_Range_Id] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_SortNo] int NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_HotPlateSteamSpeed] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* Qdm更改通知表 */
IF OBJECT_ID(N'dbo.W_QDM_Notice', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_Notice] (
    [WF_Type] nvarchar(50) NULL,
    [WF_IsModify] bit NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_Notice] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* PLC喷雾 */
IF OBJECT_ID(N'dbo.W_QDM_PLCSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PLCSpray] (
    [WF_MinPower] decimal(18,2) NOT NULL,
    [WF_MaxPower] decimal(18,2) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_Factor] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PLCSpray] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* PLC热喷雾车速系数 */
IF OBJECT_ID(N'dbo.W_QDM_PLCSpraySpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PLCSpraySpeedFactor] (
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_Speed] int NOT NULL,
    [WF_Factor] decimal(18,2) NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PLCSpraySpeedFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* PLC喷雾门幅 */
IF OBJECT_ID(N'dbo.W_QDM_PLCSprayWidth', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PLCSprayWidth] (
    [WF_MinWidth] int NOT NULL,
    [WF_MaxWidth] int NOT NULL,
    [WF_LeftPosition] int NOT NULL,
    [WF_RightPosition] int NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PLCSprayWidth] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 点位设置表 */
IF OBJECT_ID(N'dbo.W_QDM_Point', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_Point] (
    [WF_PointName] nvarchar(50) NULL,
    [WF_Type] nvarchar(50) NOT NULL,
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_PositionTable] nvarchar(50) NULL,
    [WF_Parameter] int NULL,
    [WF_Parameter2] int NULL,
    [WF_ParameterRW] int NULL,
    [WF_Encoded] nvarchar(200) NOT NULL,
    [WF_SortNo] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_IsDelete] bit NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_Point] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 烘缸蒸汽设置 */
IF OBJECT_ID(N'dbo.W_QDM_PreheaterSteam', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PreheaterSteam] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Flute] nvarchar(50) NOT NULL,
    [WF_MinGram] decimal(18,2) NOT NULL,
    [WF_MaxGram] decimal(18,2) NOT NULL,
    [WF_MinAirPress] decimal(18,2) NOT NULL,
    [WF_MaxAirPress] decimal(18,2) NOT NULL,
    [WF_PrBoost] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PreheaterSteam] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_PreheaterSteamSpeed */
IF OBJECT_ID(N'dbo.W_QDM_PreheaterSteamSpeed', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PreheaterSteamSpeed] (
    [WF_Speed] int NULL,
    [WF_SpeedFactor] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PreheaterSteamSpeed] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 压力辊压力 */
IF OBJECT_ID(N'dbo.W_QDM_PressRollPressure', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PressRollPressure] (
    [WF_MaxWidth] int NOT NULL,
    [WF_MinWidth] int NOT NULL,
    [WF_WidthFactor] decimal(18,2) NULL,
    [WF_MaxPressure] int NULL,
    [WF_MinPressure] int NULL,
    [WF_MaxGram] decimal(18,2) NULL,
    [WF_MinGram] decimal(18,2) NULL,
    [WF_DriverFactor] decimal(18,2) NULL,
    [WF_OperationFactor] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PressRollPressure] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 压力辊部位楞型系数 */
IF OBJECT_ID(N'dbo.W_QDM_PressRollPressureFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_PressRollPressureFactor] (
    [WF_Position] nvarchar(36) NOT NULL,
    [WF_Flute] nvarchar(100) NOT NULL,
    [WF_Factor] decimal(18,2) NOT NULL,
    [WF_PressRollPressure_ID] int NOT NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_PressRollPressureFactor] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_QDM_RidingRollerExtrusion */
IF OBJECT_ID(N'dbo.W_QDM_RidingRollerExtrusion', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_RidingRollerExtrusion] (
    [Wave] nvarchar(50) NOT NULL,
    [ExtrusionFactor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_RidingRollerExtrusion] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* W_QDM_RidingRollerSet */
IF OBJECT_ID(N'dbo.W_QDM_RidingRollerSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_RidingRollerSet] (
    [CorrugatedRollCode] nvarchar(50) NOT NULL,
    [Deep] decimal(18,2) NOT NULL,
    [RidingDeep] decimal(18,2) NOT NULL,
    [MinValue] decimal(18,2) NOT NULL,
    [MaxValue] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_RidingRollerSet] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* SF糊间隙克重表 */
IF OBJECT_ID(N'dbo.W_QDM_SFGlueGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_SFGlueGram] (
    [WF_Position] nvarchar(50) NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_MinGlueGap] int NULL,
    [WF_MaxGlueGap] int NULL,
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_FluteFactor] decimal(18,2) NULL,
    [WF_SortNo] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_SFGlueGram] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 接纸机张力克重差值表 */
IF OBJECT_ID(N'dbo.W_QDM_SplicerGramDiff', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_SplicerGramDiff] (
    [WF_MinDiff] int NULL,
    [WF_MaxDiff] int NULL,
    [WF_Offset] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_SplicerGramDiff] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_SplicerTensionFactor */
IF OBJECT_ID(N'dbo.W_QDM_SplicerTensionFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_SplicerTensionFactor] (
    [WF_LS0_TensionFactor] decimal(18,2) NULL,
    [WF_MS1_TensionFactor] decimal(18,2) NULL,
    [WF_LS1_TensionFactor] decimal(18,2) NULL,
    [WF_MS2_TensionFactor] decimal(18,2) NULL,
    [WF_LS2_TensionFactor] decimal(18,2) NULL,
    [WF_MS3_TensionFactor] decimal(18,2) NULL,
    [WF_LS3_TensionFactor] decimal(18,2) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_SplicerTensionFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* QDM基准值 */
IF OBJECT_ID(N'dbo.W_QDM_StandardValue', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_StandardValue] (
    [WF_QDMId] int NULL,
    [WF_PositonTable] nvarchar(50) NULL,
    [WF_Type] nvarchar(50) NULL,
    [WF_MaterialQua] nvarchar(50) NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_Position_Material] nvarchar(50) NULL,
    [WF_Position_Flute] nvarchar(50) NULL,
    [WF_Position] nvarchar(50) NULL,
    [WF_MinWidth] int NULL,
    [WF_MaxWidth] int NULL,
    [WF_Speed] int NULL,
    [WF_Part] int NULL,
    [WF_StandardValue] decimal(18,2) NULL,
    [WF_MinValue] decimal(18,2) NULL,
    [WF_MaxValue] decimal(18,2) NULL,
    [WF_Encoded] nvarchar(200) NULL,
    [WF_EncodedOther] nvarchar(200) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_StandardValue] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 张力车速系数 */
IF OBJECT_ID(N'dbo.W_QDM_TensionSpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_TensionSpeedFactor] (
    [WF_Speed] int NULL,
    [WF_Factor] decimal(18,2) NULL,
    [WF_Type] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_TensionSpeedFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 张力门幅系数 */
IF OBJECT_ID(N'dbo.W_QDM_TensionWidthFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_TensionWidthFactor] (
    [WF_MinWidth] int NULL,
    [WF_MaxWidth] int NULL,
    [WF_WidthFactor] decimal(18,2) NULL,
    [WF_Type] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_TensionWidthFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 真空泵参数设置 */
IF OBJECT_ID(N'dbo.W_QDM_VacuumBlower', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_VacuumBlower] (
    [WF_MaxWidth] int NOT NULL,
    [WF_MinWidth] int NOT NULL,
    [WF_WidthFactor] decimal(18,2) NULL,
    [WF_MinSpeedRatio] decimal(18,2) NULL,
    [WF_MaxSpeedRatio] decimal(18,2) NULL,
    [WF_MaxGram] decimal(18,2) NULL,
    [WF_MinGram] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_VacuumBlower] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 真空泵基础设置 */
IF OBJECT_ID(N'dbo.W_QDM_VacuumBlowerBaseSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_VacuumBlowerBaseSet] (
    [PaperCode] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [SpeedRatio] decimal(18,4) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_VacuumBlowerBaseSet] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 真空泵部位楞型系数 */
IF OBJECT_ID(N'dbo.W_QDM_VacuumBlowerFluteFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_VacuumBlowerFluteFactor] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_Factor] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_VacuumBlower_Id] int NOT NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_VacuumBlowerFluteFactor] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* W_QDM_VacuumBlowerSpeedFactor */
IF OBJECT_ID(N'dbo.W_QDM_VacuumBlowerSpeedFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_VacuumBlowerSpeedFactor] (
    [Speed] int NOT NULL,
    [Factor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_VacuumBlowerSpeedFactor] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* W_QDM_VacuumBlowerWidthFactor */
IF OBJECT_ID(N'dbo.W_QDM_VacuumBlowerWidthFactor', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_VacuumBlowerWidthFactor] (
    [Width] nvarchar(50) NOT NULL,
    [Wave] nvarchar(50) NOT NULL,
    [Factor] decimal(18,2) NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_VacuumBlowerWidthFactor] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 弯翘包角 */
IF OBJECT_ID(N'dbo.W_QDM_WarpedWrap', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_WarpedWrap] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_Equipment] nvarchar(50) NOT NULL,
    [WF_UpWarpLight3rd] decimal(18,2) NULL,
    [WF_UpWarpModerate3rd] decimal(18,2) NULL,
    [WF_UpWarpSevere3rd] decimal(18,2) NULL,
    [WF_DownWarpLight3rd] decimal(18,2) NULL,
    [WF_DownWarpModerate3rd] decimal(18,2) NULL,
    [WF_DownWarpSevere3rd] decimal(18,2) NULL,
    [WF_UpWarpLight5ve] decimal(18,2) NULL,
    [WF_UpWarpModerate5ve] decimal(18,2) NULL,
    [WF_UpWarpSevere5ve] decimal(18,2) NULL,
    [WF_DownWarpLight5ve] decimal(18,2) NULL,
    [WF_DownWarpModerate5ve] decimal(18,2) NULL,
    [WF_DownWarpSevere5ve] decimal(18,2) NULL,
    [WF_UpWarpLight7en] decimal(18,2) NULL,
    [WF_UpWarpModerate7en] decimal(18,2) NULL,
    [WF_UpWarpSevere7en] decimal(18,2) NULL,
    [WF_DownWarpLight7en] decimal(18,2) NULL,
    [WF_DownWarpModerate7en] decimal(18,2) NULL,
    [WF_DownWarpSevere7en] decimal(18,2) NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_WarpedWrap] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 包角楞型系数 */
IF OBJECT_ID(N'dbo.W_QDM_WrapFlute', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_WrapFlute] (
    [WF_Position] nvarchar(50) NULL,
    [WF_Flute] nvarchar(50) NULL,
    [WF_Factor] decimal(18,2) NULL,
    [WF_SortNo] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Type] int NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_WrapFlute] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 包角百分比克重表 */
IF OBJECT_ID(N'dbo.W_QDM_WrapPercentGram', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_WrapPercentGram] (
    [WF_Position] nvarchar(50) NULL,
    [WF_MinPercent] int NULL,
    [WF_MaxPercent] int NULL,
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_SortNo] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_WrapPercentGram] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 包角温度克重表 */
IF OBJECT_ID(N'dbo.W_QDM_WrapTemperature', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_QDM_WrapTemperature] (
    [WF_Position] nvarchar(50) NULL,
    [WF_MinTemperature] int NULL,
    [WF_MaxTemperature] int NULL,
    [WF_MinGram] int NULL,
    [WF_MaxGram] int NULL,
    [WF_SortNo] int NULL,
    [WF_Creator] nvarchar(50) NULL,
    [WF_CreateTime] datetime2 NULL,
    [WF_Editor] nvarchar(50) NULL,
    [WF_EditTime] datetime2 NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_QDM_WrapTemperature] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* 停机原因设置表 */
IF OBJECT_ID(N'dbo.W_StopReasonSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_StopReasonSet] (
    [WF_StopTypeID] int NOT NULL,
    [WF_Reason] nvarchar(200) NOT NULL,
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_StopReasonSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 停机类型设置表 */
IF OBJECT_ID(N'dbo.W_StopTypeSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_StopTypeSet] (
    [WF_Code] nvarchar(100) NOT NULL,
    [WF_Name] nvarchar(200) NOT NULL,
    [WF_StatisticsStop] bit NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Position] nvarchar(100) NULL,
    CONSTRAINT [PK_W_StopTypeSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸使用明细表 */
IF OBJECT_ID(N'dbo.W_BDS_HisRollInOut', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_BDS_HisRollInOut] (
    [WF_MachineID] nvarchar(50) NOT NULL,
    [WF_BarCode] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NOT NULL,
    [WF_Brand] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_WidthInch] int NOT NULL,
    [WF_Weight] int NOT NULL,
    [WF_RollWeight] decimal(18,2) NOT NULL,
    [WF_Dia] int NOT NULL,
    [WF_RemainDia] int NOT NULL,
    [WF_PlcRemainDia] int NOT NULL,
    [WF_Meter] int NOT NULL,
    [WF_RemainMeter] int NOT NULL,
    [WF_PlcRemainMeter] int NOT NULL,
    [WF_RemainRollWeight] decimal(18,2) NOT NULL,
    [WF_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [WF_ShelfTime] datetime2 NOT NULL,
    [WF_OffShelfTime] datetime2 NOT NULL,
    [WF_UseMeter] int NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_W_BDS_HisRollInOut] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_Cruise_ReasonLog */
IF OBJECT_ID(N'dbo.W_Cruise_ReasonLog', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Cruise_ReasonLog] (
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    [WF_Time] datetime2 NOT NULL,
    [WF_OrderID] int NOT NULL,
    [WF_OrderMeter] decimal(18,4) NOT NULL,
    [WF_Shift] nvarchar(255) NOT NULL,
    [WF_OrderNo] nvarchar(255) NOT NULL,
    [WF_CutLength] int NOT NULL,
    [WF_CutLengthSpeed] int NOT NULL,
    [WF_PaperCode] nvarchar(255) NOT NULL,
    [WF_PaperCodeSpeed] int NOT NULL,
    [WF_PCodeSF1Speed] int NOT NULL,
    [WF_PCodeSF2Speed] int NOT NULL,
    [WF_PCodeSF3Speed] int NOT NULL,
    [WF_LastSpeed] int NOT NULL,
    [WF_CurSPeed] int NOT NULL,
    [WF_LastCoef] decimal(18,4) NOT NULL,
    [WF_CurCoef] decimal(18,4) NOT NULL,
    [WF_Reason1] bit NOT NULL,
    [WF_Reason2] bit NOT NULL,
    [WF_Reason3] bit NOT NULL,
    [WF_Reason4] bit NOT NULL,
    [WF_Reason5] bit NOT NULL,
    [WF_Reason6] bit NOT NULL,
    [WF_Reason7] bit NOT NULL,
    [WF_Reason8] bit NOT NULL,
    [WF_Reason9] bit NOT NULL,
    [WF_Reason10] bit NOT NULL,
    [WF_Reason11] bit NOT NULL,
    [WF_Reason12] bit NOT NULL,
    [WF_Reason13] bit NOT NULL,
    [WF_Reason14] bit NOT NULL,
    [WF_Reason15] bit NOT NULL,
    [WF_Reason16] bit NOT NULL,
    [WF_Reason17] bit NOT NULL,
    [WF_Reason18] bit NOT NULL,
    [WF_Reason19] bit NOT NULL,
    [WF_Reason20] bit NOT NULL,
    [WF_Reason21] bit NOT NULL,
    [WF_Reason22] bit NOT NULL,
    [WF_Reason23] bit NOT NULL,
    [WF_Reason24] bit NOT NULL,
    [WF_Reason25] bit NOT NULL,
    [WF_MainReason] int NULL,
    CONSTRAINT [PK_W_Cruise_ReasonLog] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_IPS_AutoAlarmHis */
IF OBJECT_ID(N'dbo.W_IPS_AutoAlarmHis', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_AutoAlarmHis] (
    [WF_Code] nvarchar(36) NOT NULL,
    [WF_Time] datetime2 NOT NULL,
    [WF_Pairs] nvarchar(max) NULL,
    [WF_PositionCode] nvarchar(100) NULL,
    [WF_CurValue] nvarchar(50) NULL,
    [WF_SetValue] nvarchar(50) NULL,
    [WF_OffsetValue] nvarchar(50) NULL,
    [WF_Offset] nvarchar(50) NULL,
    [WF_OrderID] nvarchar(50) NULL,
    [WF_Id] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_AutoAlarmHis] PRIMARY KEY CLUSTERED ([WF_Id] ASC)
);
END
GO

/* PLC加湿器 */
IF OBJECT_ID(N'dbo.W_IPS_CurAccelerator', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CurAccelerator] (
    [WF_IsUse] bit NOT NULL,
    [WF_SetValue] decimal(18,2) NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CurAccelerator] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* PLC冷喷雾 */
IF OBJECT_ID(N'dbo.W_IPS_CurPlcSpray', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_CurPlcSpray] (
    [WF_Position] nvarchar(50) NOT NULL,
    [WF_IsUse] bit NOT NULL,
    [WF_IsAuto] bit NOT NULL,
    [WF_SetValue] decimal(18,2) NOT NULL,
    [WF_Nozzle1] bit NOT NULL,
    [WF_Nozzle2] bit NOT NULL,
    [WF_Nozzle3] bit NOT NULL,
    [WF_Nozzle4] bit NOT NULL,
    [WF_Nozzle5] bit NOT NULL,
    [WF_Nozzle6] bit NOT NULL,
    [WF_Nozzle7] bit NOT NULL,
    [WF_Nozzle8] bit NOT NULL,
    [WF_Nozzle9] bit NOT NULL,
    [WF_Nozzle10] bit NOT NULL,
    [WF_Nozzle11] bit NOT NULL,
    [WF_Nozzle12] bit NOT NULL,
    [WF_Nozzle13] bit NOT NULL,
    [WF_Nozzle14] bit NOT NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_CurPlcSpray] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸实材表 */
IF OBJECT_ID(N'dbo.W_IPS_ErpPaperForMachine', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_ErpPaperForMachine] (
    [WF_MachineID] nvarchar(50) NULL,
    [WF_ErpPaper] nvarchar(50) NULL,
    [WF_ErpWidth] decimal(18,2) NULL,
    [WF_ErpWeight] decimal(18,2) NULL,
    [WF_ErpRollWeight] decimal(18,2) NULL,
    [WF_ErpRollMeter] decimal(18,2) NULL,
    [WF_GUID] nvarchar(max) NULL,
    [WF_Barcode] nvarchar(max) NULL,
    [WF_CreateTime] datetime2 NOT NULL,
    [WF_State] int NOT NULL,
    [WF_IsDel] bit NOT NULL,
    [WF_SID] int NULL,
    [WF_Brand] nvarchar(50) NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    [WF_Supplier] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_W_IPS_ErpPaperForMachine] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸分摊基础表 */
IF OBJECT_ID(N'dbo.W_IPS_PaperShare', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_PaperShare] (
    [WF_MachineID] nvarchar(50) NOT NULL,
    [WF_OrderID] int NOT NULL,
    [WF_BarCode] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NOT NULL,
    [WF_Brand] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_WidthInch] int NOT NULL,
    [WF_Weight] int NOT NULL,
    [WF_RollWeight] decimal(18,2) NOT NULL,
    [WF_Dia] int NOT NULL,
    [WF_RemainDia] int NOT NULL,
    [WF_PlcRemainDia] int NOT NULL,
    [WF_Meter] int NOT NULL,
    [WF_RemainMeter] int NOT NULL,
    [WF_PlcRemainMeter] int NOT NULL,
    [WF_RemainRollWeight] decimal(18,2) NOT NULL,
    [WF_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [WF_ShelfTime] datetime2 NOT NULL,
    [WF_OffShelfTime] datetime2 NOT NULL,
    [WF_UseMeter] int NOT NULL,
    [WF_Percent] decimal(18,2) NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_IPS_PaperShare] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸实材表 */
IF OBJECT_ID(N'dbo.W_IPS_SPPaper', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_IPS_SPPaper] (
    [WF_MachineID] nvarchar(50) NULL,
    [WF_Brand] nvarchar(50) NULL,
    [WF_ErpPaper] nvarchar(50) NULL,
    [WF_ErpWidth] decimal(18,2) NULL,
    [WF_ErpWeight] decimal(18,2) NULL,
    [WF_ErpRollWeight] decimal(18,2) NULL,
    [WF_ErpRollMeter] decimal(18,2) NULL,
    [WF_Barcode] nvarchar(max) NULL,
    [WF_CreateTime] datetime2 NOT NULL,
    [WF_State] int NOT NULL,
    [WF_IsDel] bit NOT NULL,
    [WF_GUID] nvarchar(max) NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    [WF_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_W_IPS_SPPaper] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* W_PMS_MonitorOrder */
IF OBJECT_ID(N'dbo.W_PMS_MonitorOrder', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_MonitorOrder] (
    [IsChange] bit NOT NULL,
    [ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_MonitorOrder] PRIMARY KEY CLUSTERED ([ID] ASC)
);
END
GO

/* 订单编辑版本表 */
IF OBJECT_ID(N'dbo.W_PMS_OrderEditVersion', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_OrderEditVersion] (
    [WF_IsLock] bit NULL,
    [WF_UID] int NULL,
    [WF_LockTime] datetime2 NULL,
    [WF_ID] bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_OrderEditVersion] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 订单标签打印表 */
IF OBJECT_ID(N'dbo.W_PMS_OrderLabels', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PMS_OrderLabels] (
    [WF_Guid] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NOT NULL,
    [WF_Wave] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_WidthInch] decimal(18,4) NULL,
    [WF_ScheduleMeter] decimal(18,4) NULL,
    [WF_OrderNo] nvarchar(50) NULL,
    [WF_CustNo] nvarchar(50) NULL,
    [WF_TaskNo] nvarchar(50) NULL,
    [WF_CustName] nvarchar(50) NULL,
    [WF_CustPaperCode] nvarchar(50) NULL,
    [WF_CutWidth] int NULL,
    [WF_CutWidthInch] decimal(18,4) NULL,
    [WF_CutLength] int NULL,
    [WF_CutLengthInch] decimal(18,4) NULL,
    [WF_CutQty] int NULL,
    [WF_OrderQty] int NULL,
    [WF_OrderMeter] decimal(18,4) NULL,
    [WF_LabelQty] int NULL,
    [WF_CN] int NULL,
    [WF_Scor] nvarchar(50) NULL,
    [WF_Remark] nvarchar(50) NULL,
    [WF_StackQty] int NULL,
    [WF_BunQty] int NULL,
    [WF_OrderDate] datetime2 NULL,
    [WF_DeliDate] datetime2 NULL,
    [WF_StockMemo] nvarchar(50) NULL,
    [WF_BoxMemo] nvarchar(50) NULL,
    [WF_DeliMemo] nvarchar(50) NULL,
    [WF_PlanMemo] nvarchar(50) NULL,
    [WF_CutPaperMemo] nvarchar(50) NULL,
    [WF_OrderNo_D] nvarchar(50) NULL,
    [WF_CustNo_D] nvarchar(50) NULL,
    [WF_TaskNo_D] nvarchar(50) NULL,
    [WF_CustName_D] nvarchar(50) NULL,
    [WF_CustPaperCode_D] nvarchar(50) NULL,
    [WF_CutWidth_D] int NULL,
    [WF_CutWidthInch_D] decimal(18,4) NULL,
    [WF_CutLength_D] int NULL,
    [WF_CutLengthInch_D] decimal(18,4) NULL,
    [WF_CutQty_D] int NULL,
    [WF_OrderQty_D] int NULL,
    [WF_OrderMeter_D] decimal(18,4) NULL,
    [WF_LabelQty_D] int NULL,
    [WF_CN_D] int NULL,
    [WF_Scor_D] nvarchar(50) NULL,
    [WF_Remark_D] nvarchar(50) NULL,
    [WF_StackQty_D] int NULL,
    [WF_BunQty_D] int NULL,
    [WF_OrderDate_D] datetime2 NULL,
    [WF_DeliDate_D] datetime2 NULL,
    [WF_StockMemo_D] nvarchar(50) NULL,
    [WF_BoxMemo_D] nvarchar(50) NULL,
    [WF_DeliMemo_D] nvarchar(50) NULL,
    [WF_PlanMemo_D] nvarchar(50) NULL,
    [WF_CutPaperMemo_D] nvarchar(50) NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_PMS_OrderLabels] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 原纸使用明细表 */
IF OBJECT_ID(N'dbo.W_PR_HisRollInOut', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_PR_HisRollInOut] (
    [WF_MachineID] nvarchar(50) NOT NULL,
    [WF_BarCode] nvarchar(50) NOT NULL,
    [WF_PaperCode] nvarchar(50) NOT NULL,
    [WF_Brand] nvarchar(50) NOT NULL,
    [WF_Width] int NOT NULL,
    [WF_WidthInch] int NOT NULL,
    [WF_Weight] int NOT NULL,
    [WF_RollWeight] decimal(18,2) NOT NULL,
    [WF_Dia] int NOT NULL,
    [WF_RemainDia] int NOT NULL,
    [WF_PlcRemainDia] int NOT NULL,
    [WF_Meter] int NOT NULL,
    [WF_RemainMeter] int NOT NULL,
    [WF_PlcRemainMeter] int NOT NULL,
    [WF_RemainRollWeight] decimal(18,2) NOT NULL,
    [WF_PlcRemainRollWeight] decimal(18,2) NOT NULL,
    [WF_ShelfTime] datetime2 NOT NULL,
    [WF_OffShelfTime] datetime2 NULL,
    [WF_UseMeter] int NOT NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [WF_State] int NOT NULL,
    [WF_ShiftName] nvarchar(50) NULL,
    [WF_Supplier] nvarchar(50) NULL,
    CONSTRAINT [PK_W_PR_HisRollInOut] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
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
    [WPro_PaperCode] int NULL,
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


/* =============================== 第二部分：BaseDB 公共表 =============================== */
/* =====================================================================
   BaseDB —— 并入 IPS 库后的公共表（用户/角色/权限/瓦线配置/日志）
   由 DataDictionary（原 PostgreSQL 15 / BaseDB 库，2026-11-13 导出）转换生成
   类型映射：varchar->nvarchar、text->nvarchar(max)、int4->int、int8->bigint、
            bool->bit、timestamp(6)->datetime2、nextval->IDENTITY(1,1)（并作为主键）
   脚本幂等：表已存在则跳过
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* S_ApiUserMaps */
IF OBJECT_ID(N'dbo.S_ApiUserMaps', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ApiUserMaps] (
    [SAA_ApiID] int NOT NULL  /* 接口ID */,
    [SAA_ApiUserID] int NOT NULL  /* 接口授权账号 */,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ApiUserMaps] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* W_ApiUsers */
IF OBJECT_ID(N'dbo.W_ApiUsers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_ApiUsers] (
    [SA_Account] nvarchar(50) NOT NULL  /* 账号 */,
    [SA_Password] nvarchar(100) NOT NULL  /* 密码 */,
    [SA_SystemName] nvarchar(50) NOT NULL  /* 系统名称 */,
    [SA_IsEnable] bit NOT NULL  /* 是否启用 */,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_ApiUsers] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* W_Apis */
IF OBJECT_ID(N'dbo.W_Apis', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Apis] (
    [SA_Desc] nvarchar(max) NULL,
    [SA_Path] nvarchar(100) NOT NULL  /* 接口地址Url */,
    [SA_IsEnable] bit NOT NULL  /* 是否启用 */,
    [WSA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Apis] PRIMARY KEY CLUSTERED ([WSA_ID] ASC)
);
END
GO

/* 菜单功能权限表 */
IF OBJECT_ID(N'dbo.W_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Permissions] (
    [WSP_PID] int NOT NULL  /* 父ID */,
    [WSP_Name] nvarchar(50) NOT NULL  /* 名称 */,
    [WSP_Type] nvarchar(10) NOT NULL  /* 类型(菜单，功能) */,
    [WSP_NameSpace] nvarchar(100) NULL  /* 命名空间 */,
    [WSP_IsDel] bit NULL  /* 是否删除 */,
    [WSP_SortNo] int NULL  /* 排序号 */,
    [WSP_Creator] nvarchar(20) NULL  /* 创建者 */,
    [WSP_CreateTime] datetime2 NULL  /* 创建时间 */,
    [WSP_Editor] nvarchar(20) NULL  /* 修改人 */,
    [WSP_EditTime] datetime2 NULL  /* 修改时间 */,
    [WSP_Remark] nvarchar(500) NULL,
    [WSP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Permissions] PRIMARY KEY CLUSTERED ([WSP_ID] ASC)
);
END
GO

/* 角色权限关联表 */
IF OBJECT_ID(N'dbo.W_Role_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Role_Permissions] (
    [WSR_ID] int NOT NULL  /* 角色ID */,
    [WSP_ID] int NOT NULL  /* 权限ID */,
    [WSRP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Role_Permissions] PRIMARY KEY CLUSTERED ([WSRP_ID] ASC)
);
END
GO

/* 角色表 */
IF OBJECT_ID(N'dbo.W_Roles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Roles] (
    [WSR_Name] nvarchar(50) NOT NULL  /* 角色名 */,
    [WSR_SortNo] int NULL  /* 排序号 */,
    [WSR_IsDel] bit NULL  /* 是否删除 */,
    [WSR_Creator] nvarchar(20) NULL  /* 创建者 */,
    [WSR_CreateTime] datetime2 NULL  /* 创建时间 */,
    [WSR_Editor] nvarchar(20) NULL  /* 修改人 */,
    [WSR_EditTime] datetime2 NULL  /* 修改时间 */,
    [WSR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Roles] PRIMARY KEY CLUSTERED ([WSR_ID] ASC)
);
END
GO

/* 用户权限关联表 */
IF OBJECT_ID(N'dbo.W_User_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_User_Permissions] (
    [WSU_ID] int NOT NULL  /* 用户ID */,
    [WSP_ID] int NOT NULL  /* 权限ID */,
    [WSUP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_User_Permissions] PRIMARY KEY CLUSTERED ([WSUP_ID] ASC)
);
END
GO

/* 用户角色关联表 */
IF OBJECT_ID(N'dbo.W_User_Roles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_User_Roles] (
    [WSU_ID] int NOT NULL  /* 用户ID */,
    [WSR_ID] int NOT NULL  /* 角色ID */,
    [WSUR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_User_Roles] PRIMARY KEY CLUSTERED ([WSUR_ID] ASC)
);
END
GO

/* 用户表 */
IF OBJECT_ID(N'dbo.W_Users', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Users] (
    [WSU_Account] nvarchar(50) NOT NULL  /* 账号 */,
    [WSU_Password] nvarchar(200) NULL  /* 密码：PBKDF2 加盐哈希（pbkdf2$迭代$saltB64$hashB64），兼容历史 MD5/明文 */,
    [WSU_UserName] nvarchar(50) NULL  /* 姓名 */,
    [WSU_Gender] nvarchar(10) NULL  /* 性别 */,
    [WSU_PhoneNo] nvarchar(50) NULL  /* 手机号码 */,
    [WSU_IsMulti] bit NULL,
    [WSU_IsDel] bit NULL  /* 是否删除 */,
    [WSU_Creator] nvarchar(20) NULL  /* 创建者 */,
    [WSU_CreateTime] datetime2 NULL  /* 创建时间 */,
    [WSU_Editor] nvarchar(20) NULL  /* 修改人 */,
    [WSU_EditTime] datetime2 NULL  /* 修改时间 */,
    [WSU_StopPosition] nvarchar(50) NULL,
    [WSU_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Users] PRIMARY KEY CLUSTERED ([WSU_ID] ASC)
);
END
GO

/* TB_Line */
IF OBJECT_ID(N'dbo.TB_Line', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Line] (
    [WF_Code] nvarchar(50) NOT NULL  /* 瓦线编码 */,
    [WF_Name] nvarchar(50) NOT NULL  /* 瓦线名称 */,
    [F_ConfigID] nvarchar(50) NOT NULL  /* 数据库标识 */,
    [F_ConnectionString] nvarchar(200) NOT NULL  /* 数据库连接字符串 */,
    [F_ServerIP] nvarchar(50) NOT NULL  /* 服务端IP */,
    [F_ServerPort] int NOT NULL  /* 服务单端口号 */,
    [F_Gateway] nvarchar(50) NULL,
    [F_WaveLineLayer] int NULL,
    [WF_DoorWidth] int NULL,
    [WF_ID] int IDENTITY(1,1) NOT NULL,
    [F_ApiUrl] nvarchar(255) NULL  /* WebApi接口地址 */,
    CONSTRAINT [PK_TB_Line] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 日志表 */
IF OBJECT_ID(N'dbo.T_Log', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_Log] (
    [Id] bigint IDENTITY(1,1) NOT NULL,
    [Date] datetime2 NULL,
    [Thread] nvarchar(10) NULL,
    [Level] nvarchar(10) NULL,
    [Logger] nvarchar(255) NULL,
    [Message] nvarchar(max) NULL,
    [Exception] nvarchar(max) NULL,
    CONSTRAINT [PK_T_Log] PRIMARY KEY CLUSTERED ([Id] ASC)
);
END
GO

/* T_UserLoginCache */
IF OBJECT_ID(N'dbo.T_UserLoginCache', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[T_UserLoginCache] (
    [F_Account] nvarchar(50) NULL,
    [F_Time] datetime2 NULL,
    [F_IP] nvarchar(50) NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_T_UserLoginCache] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO
