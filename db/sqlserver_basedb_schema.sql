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
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ApiUserMaps] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* S_ApiUsers */
IF OBJECT_ID(N'dbo.S_ApiUsers', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_ApiUsers] (
    [SA_Account] nvarchar(50) NOT NULL  /* 账号 */,
    [SA_Password] nvarchar(100) NOT NULL  /* 密码 */,
    [SA_SystemName] nvarchar(50) NOT NULL  /* 系统名称 */,
    [SA_IsEnable] bit NOT NULL  /* 是否启用 */,
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_ApiUsers] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* S_Apis */
IF OBJECT_ID(N'dbo.S_Apis', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Apis] (
    [SA_Desc] nvarchar(max) NULL,
    [SA_Path] nvarchar(100) NOT NULL  /* 接口地址Url */,
    [SA_IsEnable] bit NOT NULL  /* 是否启用 */,
    [SA_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Apis] PRIMARY KEY CLUSTERED ([SA_ID] ASC)
);
END
GO

/* 菜单功能权限表 */
IF OBJECT_ID(N'dbo.S_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Permissions] (
    [SP_PID] int NOT NULL  /* 父ID */,
    [SP_Name] nvarchar(50) NOT NULL  /* 名称 */,
    [SP_Type] nvarchar(10) NOT NULL  /* 类型(菜单，功能) */,
    [SP_NameSpace] nvarchar(100) NULL  /* 命名空间 */,
    [SP_IsDel] bit NULL  /* 是否删除 */,
    [SP_SortNo] int NULL  /* 排序号 */,
    [SP_Creator] nvarchar(20) NULL  /* 创建者 */,
    [SP_CreateTime] datetime2 NULL  /* 创建时间 */,
    [SP_Editor] nvarchar(20) NULL  /* 修改人 */,
    [SP_EditTime] datetime2 NULL  /* 修改时间 */,
    [SP_Remark] nvarchar(500) NULL,
    [SP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Permissions] PRIMARY KEY CLUSTERED ([SP_ID] ASC)
);
END
GO

/* 角色权限关联表 */
IF OBJECT_ID(N'dbo.S_Role_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Role_Permissions] (
    [SR_ID] int NOT NULL  /* 角色ID */,
    [SP_ID] int NOT NULL  /* 权限ID */,
    [SRP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Role_Permissions] PRIMARY KEY CLUSTERED ([SRP_ID] ASC)
);
END
GO

/* 角色表 */
IF OBJECT_ID(N'dbo.S_Roles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Roles] (
    [SR_Name] nvarchar(50) NOT NULL  /* 角色名 */,
    [SR_SortNo] int NULL  /* 排序号 */,
    [SR_IsDel] bit NULL  /* 是否删除 */,
    [SR_Creator] nvarchar(20) NULL  /* 创建者 */,
    [SR_CreateTime] datetime2 NULL  /* 创建时间 */,
    [SR_Editor] nvarchar(20) NULL  /* 修改人 */,
    [SR_EditTime] datetime2 NULL  /* 修改时间 */,
    [SR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Roles] PRIMARY KEY CLUSTERED ([SR_ID] ASC)
);
END
GO

/* 用户权限关联表 */
IF OBJECT_ID(N'dbo.S_User_Permissions', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_User_Permissions] (
    [SU_ID] int NOT NULL  /* 用户ID */,
    [SP_ID] int NOT NULL  /* 权限ID */,
    [SUP_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_User_Permissions] PRIMARY KEY CLUSTERED ([SUP_ID] ASC)
);
END
GO

/* 用户角色关联表 */
IF OBJECT_ID(N'dbo.S_User_Roles', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_User_Roles] (
    [SU_ID] int NOT NULL  /* 用户ID */,
    [SR_ID] int NOT NULL  /* 角色ID */,
    [SUR_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_User_Roles] PRIMARY KEY CLUSTERED ([SUR_ID] ASC)
);
END
GO

/* 用户表 */
IF OBJECT_ID(N'dbo.S_Users', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[S_Users] (
    [SU_Account] nvarchar(50) NOT NULL  /* 账号 */,
    [SU_Password] nvarchar(200) NULL  /* 密码：PBKDF2 加盐哈希（pbkdf2$迭代$saltB64$hashB64），兼容历史 MD5/明文 */,
    [SU_UserName] nvarchar(50) NULL  /* 姓名 */,
    [SU_Gender] nvarchar(10) NULL  /* 性别 */,
    [SU_PhoneNo] nvarchar(50) NULL  /* 手机号码 */,
    [SU_IsMulti] bit NULL,
    [SU_IsDel] bit NULL  /* 是否删除 */,
    [SU_Creator] nvarchar(20) NULL  /* 创建者 */,
    [SU_CreateTime] datetime2 NULL  /* 创建时间 */,
    [SU_Editor] nvarchar(20) NULL  /* 修改人 */,
    [SU_EditTime] datetime2 NULL  /* 修改时间 */,
    [SU_StopPosition] nvarchar(50) NULL,
    [SU_ID] int IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_S_Users] PRIMARY KEY CLUSTERED ([SU_ID] ASC)
);
END
GO

/* TB_Line */
IF OBJECT_ID(N'dbo.TB_Line', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Line] (
    [F_Code] nvarchar(50) NOT NULL  /* 瓦线编码 */,
    [F_Name] nvarchar(50) NOT NULL  /* 瓦线名称 */,
    [F_ConfigID] nvarchar(50) NOT NULL  /* 数据库标识 */,
    [F_ConnectionString] nvarchar(200) NOT NULL  /* 数据库连接字符串 */,
    [F_ServerIP] nvarchar(50) NOT NULL  /* 服务端IP */,
    [F_ServerPort] int NOT NULL  /* 服务单端口号 */,
    [F_Gateway] nvarchar(50) NULL,
    [F_WaveLineLayer] int NULL,
    [F_DoorWidth] int NULL,
    [F_ID] int IDENTITY(1,1) NOT NULL,
    [F_ApiUrl] nvarchar(255) NULL  /* WebApi接口地址 */,
    CONSTRAINT [PK_TB_Line] PRIMARY KEY CLUSTERED ([F_ID] ASC)
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
