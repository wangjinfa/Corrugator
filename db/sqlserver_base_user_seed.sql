/* =====================================================================
   BaseDB 账号/角色/权限种子（手工建库时使用）
   服务端 SeedData=true 时启动会自动写入同样的数据；本脚本用于禁用了自动种子、
   或想用 SQL 初始化生产库的情况。密码统一为 123456（PBKDF2 加盐哈希）。
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO


/* 账号 admin -> 角色 admin */
IF NOT EXISTS (SELECT 1 FROM dbo.S_Users WHERE SU_Account = N'admin')
INSERT INTO dbo.S_Users (SU_Account, SU_Password, SU_UserName, SU_IsMulti, SU_IsDel, SU_Creator, SU_CreateTime)
VALUES (N'admin', N'pbkdf2$100000$iymnE3FajaUQDVIjCGOSUw==$75Lk+ayOsraUqQTS03rc+odzyEVesfNF6Gd5AmUiymo=', N'系统管理员', 1, 0, N'system', SYSDATETIME());
GO


/* 账号 planner -> 角色 planner */
IF NOT EXISTS (SELECT 1 FROM dbo.S_Users WHERE SU_Account = N'planner')
INSERT INTO dbo.S_Users (SU_Account, SU_Password, SU_UserName, SU_IsMulti, SU_IsDel, SU_Creator, SU_CreateTime)
VALUES (N'planner', N'pbkdf2$100000$jzkN4DXHdvxV+wdQ2qbZuA==$3eXlu6mefGXw3M9P6KpZU0YHffIV+X83Xofx0TVhoMU=', N'生管排程员', 1, 0, N'system', SYSDATETIME());
GO


/* 账号 operator -> 角色 operator */
IF NOT EXISTS (SELECT 1 FROM dbo.S_Users WHERE SU_Account = N'operator')
INSERT INTO dbo.S_Users (SU_Account, SU_Password, SU_UserName, SU_IsMulti, SU_IsDel, SU_Creator, SU_CreateTime)
VALUES (N'operator', N'pbkdf2$100000$3XY8sEBtRb/fOSvwzLJSPg==$FXHmukEGaZuRBgiVNqDu+d3qaNJAoxoL8kH65BmwEXU=', N'车间操作工', 0, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Roles WHERE SR_Name = N'admin')
INSERT INTO dbo.S_Roles (SR_Name, SR_SortNo, SR_IsDel, SR_Creator, SR_CreateTime)
VALUES (N'admin', 1, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Roles WHERE SR_Name = N'planner')
INSERT INTO dbo.S_Roles (SR_Name, SR_SortNo, SR_IsDel, SR_Creator, SR_CreateTime)
VALUES (N'planner', 2, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Roles WHERE SR_Name = N'operator')
INSERT INTO dbo.S_Roles (SR_Name, SR_SortNo, SR_IsDel, SR_Creator, SR_CreateTime)
VALUES (N'operator', 3, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Permissions WHERE SP_Name = N'lines:reload')
INSERT INTO dbo.S_Permissions (SP_PID, SP_Name, SP_Type, SP_NameSpace, SP_IsDel, SP_SortNo, SP_Remark, SP_Creator, SP_CreateTime)
VALUES (0, N'lines:reload', N'功能', N'api', 0, 1, N'刷新瓦线配置', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Permissions WHERE SP_Name = N'orders:write')
INSERT INTO dbo.S_Permissions (SP_PID, SP_Name, SP_Type, SP_NameSpace, SP_IsDel, SP_SortNo, SP_Remark, SP_Creator, SP_CreateTime)
VALUES (0, N'orders:write', N'功能', N'api', 0, 2, N'工单新增/修改/删除', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Permissions WHERE SP_Name = N'params:write')
INSERT INTO dbo.S_Permissions (SP_PID, SP_Name, SP_Type, SP_NameSpace, SP_IsDel, SP_SortNo, SP_Remark, SP_Creator, SP_CreateTime)
VALUES (0, N'params:write', N'功能', N'api', 0, 3, N'工艺参数修改', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Permissions WHERE SP_Name = N'alarms:confirm')
INSERT INTO dbo.S_Permissions (SP_PID, SP_Name, SP_Type, SP_NameSpace, SP_IsDel, SP_SortNo, SP_Remark, SP_Creator, SP_CreateTime)
VALUES (0, N'alarms:confirm', N'功能', N'api', 0, 4, N'告警确认', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'admin' AND p.SP_Name = N'lines:reload')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'admin' AND p.SP_Name = N'lines:reload';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'admin' AND p.SP_Name = N'orders:write')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'admin' AND p.SP_Name = N'orders:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'admin' AND p.SP_Name = N'params:write')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'admin' AND p.SP_Name = N'params:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'admin' AND p.SP_Name = N'alarms:confirm')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'admin' AND p.SP_Name = N'alarms:confirm';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'planner' AND p.SP_Name = N'orders:write')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'planner' AND p.SP_Name = N'orders:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'planner' AND p.SP_Name = N'params:write')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'planner' AND p.SP_Name = N'params:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_Role_Permissions rp
               JOIN dbo.S_Roles r ON r.SR_ID = rp.SR_ID
               JOIN dbo.S_Permissions p ON p.SP_ID = rp.SP_ID
               WHERE r.SR_Name = N'operator' AND p.SP_Name = N'alarms:confirm')
INSERT INTO dbo.S_Role_Permissions (SR_ID, SP_ID)
SELECT r.SR_ID, p.SP_ID FROM dbo.S_Roles r, dbo.S_Permissions p
WHERE r.SR_Name = N'operator' AND p.SP_Name = N'alarms:confirm';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_User_Roles ur
               JOIN dbo.S_Users u ON u.SU_ID = ur.SU_ID
               JOIN dbo.S_Roles r ON r.SR_ID = ur.SR_ID
               WHERE u.SU_Account = N'admin' AND r.SR_Name = N'admin')
INSERT INTO dbo.S_User_Roles (SU_ID, SR_ID)
SELECT u.SU_ID, r.SR_ID FROM dbo.S_Users u, dbo.S_Roles r
WHERE u.SU_Account = N'admin' AND r.SR_Name = N'admin';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_User_Roles ur
               JOIN dbo.S_Users u ON u.SU_ID = ur.SU_ID
               JOIN dbo.S_Roles r ON r.SR_ID = ur.SR_ID
               WHERE u.SU_Account = N'planner' AND r.SR_Name = N'planner')
INSERT INTO dbo.S_User_Roles (SU_ID, SR_ID)
SELECT u.SU_ID, r.SR_ID FROM dbo.S_Users u, dbo.S_Roles r
WHERE u.SU_Account = N'planner' AND r.SR_Name = N'planner';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.S_User_Roles ur
               JOIN dbo.S_Users u ON u.SU_ID = ur.SU_ID
               JOIN dbo.S_Roles r ON r.SR_ID = ur.SR_ID
               WHERE u.SU_Account = N'operator' AND r.SR_Name = N'operator')
INSERT INTO dbo.S_User_Roles (SU_ID, SR_ID)
SELECT u.SU_ID, r.SR_ID FROM dbo.S_Users u, dbo.S_Roles r
WHERE u.SU_Account = N'operator' AND r.SR_Name = N'operator';
GO


SELECT u.SU_Account, u.SU_UserName, u.SU_IsMulti, r.SR_Name AS RoleName
FROM dbo.S_Users u
LEFT JOIN dbo.S_User_Roles ur ON ur.SU_ID = u.SU_ID
LEFT JOIN dbo.S_Roles r ON r.SR_ID = ur.SR_ID;
GO
