/* 系统用户 Sys_Users + 接口操作日志 Sys_OperationLogs
   ------------------------------------------------------------------
   两张都是新增表（不来自 IPS 数据字典）：
   - Sys_Users：演示软删除（IsDeleted）+ 审计字段（CreatedAt/CreatedBy/UpdatedAt/UpdatedBy）+ 仓储层统一填充。
   - Sys_OperationLogs：记录前端调用轨迹（账号 / 路径 / 方法 / 查询串 / 耗时 / 成功与否 / 提示）。

   注意：生产登录鉴权走 BaseDB 的 S_Users（见 db/sqlserver_basedb_schema.sql）；
   本表是应用内演示 / 备用账号表，不要把 S_Users 的迁移脚本（sqlserver_migrate_sysusers_to_susers.sql）
   与本表混用。
   ------------------------------------------------------------------ */

/* ====================== 1. 系统用户 ====================== */
IF OBJECT_ID(N'dbo.Sys_Users', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[Sys_Users] (
    [Id]           int IDENTITY(1,1) NOT NULL,
    [UserName]     nvarchar(50)  NOT NULL  /* 登录账号 */,
    [PasswordHash] nvarchar(200) NOT NULL  /* 密码：PBKDF2 加盐哈希（pbkdf2$迭代$saltB64$hashB64） */,
    [DisplayName]  nvarchar(50)  NOT NULL  /* 显示名 */,
    [Role]         nvarchar(20)  NOT NULL  /* 角色：admin / planner / operator */
                   CONSTRAINT [DF_Sys_Users_Role] DEFAULT (N'operator'),
    [IsActive]     bit           NOT NULL  /* 是否启用 */
                   CONSTRAINT [DF_Sys_Users_IsActive] DEFAULT (1),
    [IsDeleted]    bit           NOT NULL  /* 是否删除（软删） */
                   CONSTRAINT [DF_Sys_Users_IsDeleted] DEFAULT (0),
    [CreatedAt]    datetime2     NOT NULL  /* 创建时间 */,
    [CreatedBy]    nvarchar(50)  NULL      /* 创建人 */,
    [UpdatedAt]    datetime2     NULL     /* 修改时间 */,
    [UpdatedBy]    nvarchar(50)  NULL     /* 修改人 */,
    CONSTRAINT [PK_Sys_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

/* 登录账号唯一（软删后可重录同一账号） */
CREATE UNIQUE INDEX [UX_Sys_Users_UserName]
    ON dbo.[Sys_Users] ([UserName])
    WHERE [IsDeleted] = 0;
END
GO

/* ====================== 2. 接口操作日志 ====================== */
IF OBJECT_ID(N'dbo.Sys_OperationLogs', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[Sys_OperationLogs] (
    [Id]        int IDENTITY(1,1) NOT NULL,
    [UserName]  nvarchar(100) NULL,       /* 调用账号 */
    [Path]      nvarchar(200) NULL,       /* 接口路径 */
    [Method]    nvarchar(10)  NULL,        /* GET / POST / PUT / DELETE */
    [Query]     nvarchar(500) NULL,       /* 查询串 / 入参摘要 */
    [ElapsedMs] int          NULL,       /* 耗时毫秒 */
    [Success]   bit          NULL,        /* 是否成功 */
    [Message]   nvarchar(500) NULL,       /* 提示信息 / 异常摘要 */
    [CreatedAt] datetime2     NOT NULL,   /* 创建时间 */
    CONSTRAINT [PK_Sys_OperationLogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

/* 按时间倒序检索最近调用；按账号检索某人的操作轨迹 */
CREATE INDEX [IX_Sys_OperationLogs_CreatedAt] ON dbo.[Sys_OperationLogs] ([CreatedAt] DESC);
CREATE INDEX [IX_Sys_OperationLogs_UserName] ON dbo.[Sys_OperationLogs] ([UserName]);
END
GO

/* ====================== 3. 样例账号（可选） ======================
   PasswordHash 必须是后端 PasswordHasher.Hash("123456") 生成的 PBKDF2 哈希，
   不要在 SQL 里直接写明文；下面仅给出占位结构，实际由后端初始化或注册接口写入。

IF NOT EXISTS (SELECT 1 FROM dbo.[Sys_Users])
BEGIN
INSERT INTO dbo.[Sys_Users] ([UserName], [PasswordHash], [DisplayName], [Role], [IsActive], [CreatedAt]) VALUES
 (N'admin',    N'<pbkdf2$100000$saltB64$hashB64>', N'系统管理员', N'admin',    1, SYSDATETIME()),
 (N'planner',  N'<pbkdf2$100000$saltB64$hashB64>', N'生管排程员', N'planner', 1, SYSDATETIME()),
 (N'operator', N'<pbkdf2$100000$saltB64$hashB64>', N'车间操作工', N'operator', 1, SYSDATETIME());
END
GO
*/
