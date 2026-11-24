/* =====================================================================
   把老版 W_Sys_Users（本方案此前自己建的账号表）迁移到 BaseDB 的 W_Users
   适用：已经在生产库跑过旧版本、想保留原有账号（密码同为 PBKDF2 串，可直接沿用）
   执行顺序：先跑 sqlserver_ips_full.sql（或两段脚本），再执行本脚本
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* 1. 账号：UserId 不再保留，按账号名去重 */
IF OBJECT_ID(N'dbo.W_Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.W_Users (WSU_Account, WSU_Password, WSU_UserName, WSU_IsMulti, WSU_IsDel, WSU_Creator, WSU_CreateTime)
SELECT u.UserName, u.PasswordHash, u.DisplayName, 1, 0, N'migrate', ISNULL(u.CreatedAt, SYSDATETIME())
FROM dbo.W_Sys_Users u
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.W_Users s WHERE s.WSU_Account = u.UserName);
GO

/* 2. 角色：老表 Role 字段是 admin/planner/operator，W_Roles 里没有就补上 */
IF OBJECT_ID(N'dbo.W_Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.W_Roles (WSR_Name, WSR_SortNo, WSR_IsDel, WSR_Creator, WSR_CreateTime)
SELECT DISTINCT u.Role, 10, 0, N'migrate', SYSDATETIME()
FROM dbo.W_Sys_Users u
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.W_Roles r WHERE r.WSR_Name = u.Role);
GO

/* 3. 用户-角色关联 */
IF OBJECT_ID(N'dbo.W_Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.W_User_Roles (WSU_ID, WSR_ID)
SELECT s.WSU_ID, r.WSR_ID
FROM dbo.W_Sys_Users u
JOIN dbo.W_Users s ON s.WSU_Account = u.UserName
JOIN dbo.W_Roles r ON r.WSR_Name = u.Role
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.W_User_Roles ur WHERE ur.WSU_ID = s.WSU_ID AND ur.WSR_ID = r.WSR_ID);
GO

/* 4. 校验：迁移后的账号与角色 */
SELECT s.WSU_Account, s.WSU_UserName, s.WSU_IsMulti, r.WSR_Name
FROM dbo.W_Users s
LEFT JOIN dbo.W_User_Roles ur ON ur.WSU_ID = s.WSU_ID
LEFT JOIN dbo.W_Roles r ON r.WSR_ID = ur.WSR_ID
ORDER BY s.WSU_Account;
GO
