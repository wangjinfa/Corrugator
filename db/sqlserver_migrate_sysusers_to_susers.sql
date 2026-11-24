/* =====================================================================
   把老版 Sys_Users（本方案此前自己建的账号表）迁移到 BaseDB 的 S_Users
   适用：已经在生产库跑过旧版本、想保留原有账号（密码同为 PBKDF2 串，可直接沿用）
   执行顺序：先跑 sqlserver_ips_full.sql（或两段脚本），再执行本脚本
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* 1. 账号：UserId 不再保留，按账号名去重 */
IF OBJECT_ID(N'dbo.Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.S_Users (SU_Account, SU_Password, SU_UserName, SU_IsMulti, SU_IsDel, SU_Creator, SU_CreateTime)
SELECT u.UserName, u.PasswordHash, u.DisplayName, 1, 0, N'migrate', ISNULL(u.CreatedAt, SYSDATETIME())
FROM dbo.Sys_Users u
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.S_Users s WHERE s.SU_Account = u.UserName);
GO

/* 2. 角色：老表 Role 字段是 admin/planner/operator，S_Roles 里没有就补上 */
IF OBJECT_ID(N'dbo.Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.S_Roles (SR_Name, SR_SortNo, SR_IsDel, SR_Creator, SR_CreateTime)
SELECT DISTINCT u.Role, 10, 0, N'migrate', SYSDATETIME()
FROM dbo.Sys_Users u
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.S_Roles r WHERE r.SR_Name = u.Role);
GO

/* 3. 用户-角色关联 */
IF OBJECT_ID(N'dbo.Sys_Users', N'U') IS NOT NULL
INSERT INTO dbo.S_User_Roles (SU_ID, SR_ID)
SELECT s.SU_ID, r.SR_ID
FROM dbo.Sys_Users u
JOIN dbo.S_Users s ON s.SU_Account = u.UserName
JOIN dbo.S_Roles r ON r.SR_Name = u.Role
WHERE u.IsDeleted = 0
  AND NOT EXISTS (SELECT 1 FROM dbo.S_User_Roles ur WHERE ur.SU_ID = s.SU_ID AND ur.SR_ID = r.SR_ID);
GO

/* 4. 校验：迁移后的账号与角色 */
SELECT s.SU_Account, s.SU_UserName, s.SU_IsMulti, r.SR_Name
FROM dbo.S_Users s
LEFT JOIN dbo.S_User_Roles ur ON ur.SU_ID = s.SU_ID
LEFT JOIN dbo.S_Roles r ON r.SR_ID = ur.SR_ID
ORDER BY s.SU_Account;
GO
