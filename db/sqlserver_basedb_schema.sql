/* =====================================================================
   BaseDB —— 基础库（用户/角色/权限/瓦线配置/日志）SQL Server 建表脚本
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
