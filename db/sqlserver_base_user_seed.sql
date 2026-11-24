/* =====================================================================
   BaseDB 账号/角色/权限种子（手工建库时使用）
   服务端 SeedData=true 时启动会自动写入同样的数据；本脚本用于禁用了自动种子、
   或想用 SQL 初始化生产库的情况。密码统一为 123456（PBKDF2 加盐哈希）。
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO


/* 账号 admin -> 角色 admin */
IF NOT EXISTS (SELECT 1 FROM dbo.W_Users WHERE WSU_Account = N'admin')
INSERT INTO dbo.W_Users (WSU_Account, WSU_Password, WSU_UserName, WSU_IsMulti, WSU_IsDel, WSU_Creator, WSU_CreateTime)
VALUES (N'admin', N'pbkdf2$100000$iymnE3FajaUQDVIjCGOSUw==$75Lk+ayOsraUqQTS03rc+odzyEVesfNF6Gd5AmUiymo=', N'系统管理员', 1, 0, N'system', SYSDATETIME());
GO


/* 账号 planner -> 角色 planner */
IF NOT EXISTS (SELECT 1 FROM dbo.W_Users WHERE WSU_Account = N'planner')
INSERT INTO dbo.W_Users (WSU_Account, WSU_Password, WSU_UserName, WSU_IsMulti, WSU_IsDel, WSU_Creator, WSU_CreateTime)
VALUES (N'planner', N'pbkdf2$100000$jzkN4DXHdvxV+wdQ2qbZuA==$3eXlu6mefGXw3M9P6KpZU0YHffIV+X83Xofx0TVhoMU=', N'生管排程员', 1, 0, N'system', SYSDATETIME());
GO


/* 账号 operator -> 角色 operator */
IF NOT EXISTS (SELECT 1 FROM dbo.W_Users WHERE WSU_Account = N'operator')
INSERT INTO dbo.W_Users (WSU_Account, WSU_Password, WSU_UserName, WSU_IsMulti, WSU_IsDel, WSU_Creator, WSU_CreateTime)
VALUES (N'operator', N'pbkdf2$100000$3XY8sEBtRb/fOSvwzLJSPg==$FXHmukEGaZuRBgiVNqDu+d3qaNJAoxoL8kH65BmwEXU=', N'车间操作工', 0, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Roles WHERE WSR_Name = N'admin')
INSERT INTO dbo.W_Roles (WSR_Name, WSR_SortNo, WSR_IsDel, WSR_Creator, WSR_CreateTime)
VALUES (N'admin', 1, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Roles WHERE WSR_Name = N'planner')
INSERT INTO dbo.W_Roles (WSR_Name, WSR_SortNo, WSR_IsDel, WSR_Creator, WSR_CreateTime)
VALUES (N'planner', 2, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Roles WHERE WSR_Name = N'operator')
INSERT INTO dbo.W_Roles (WSR_Name, WSR_SortNo, WSR_IsDel, WSR_Creator, WSR_CreateTime)
VALUES (N'operator', 3, 0, N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Permissions WHERE WSP_Name = N'lines:reload')
INSERT INTO dbo.W_Permissions (WSP_PID, WSP_Name, WSP_Type, WSP_NameSpace, WSP_IsDel, WSP_SortNo, WSP_Remark, WSP_Creator, WSP_CreateTime)
VALUES (0, N'lines:reload', N'功能', N'api', 0, 1, N'刷新瓦线配置', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Permissions WHERE WSP_Name = N'orders:write')
INSERT INTO dbo.W_Permissions (WSP_PID, WSP_Name, WSP_Type, WSP_NameSpace, WSP_IsDel, WSP_SortNo, WSP_Remark, WSP_Creator, WSP_CreateTime)
VALUES (0, N'orders:write', N'功能', N'api', 0, 2, N'工单新增/修改/删除', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Permissions WHERE WSP_Name = N'params:write')
INSERT INTO dbo.W_Permissions (WSP_PID, WSP_Name, WSP_Type, WSP_NameSpace, WSP_IsDel, WSP_SortNo, WSP_Remark, WSP_Creator, WSP_CreateTime)
VALUES (0, N'params:write', N'功能', N'api', 0, 3, N'工艺参数修改', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Permissions WHERE WSP_Name = N'alarms:confirm')
INSERT INTO dbo.W_Permissions (WSP_PID, WSP_Name, WSP_Type, WSP_NameSpace, WSP_IsDel, WSP_SortNo, WSP_Remark, WSP_Creator, WSP_CreateTime)
VALUES (0, N'alarms:confirm', N'功能', N'api', 0, 4, N'告警确认', N'system', SYSDATETIME());
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'lines:reload')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'lines:reload';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'orders:write')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'orders:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'params:write')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'params:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'alarms:confirm')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'admin' AND p.WSP_Name = N'alarms:confirm';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'planner' AND p.WSP_Name = N'orders:write')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'planner' AND p.WSP_Name = N'orders:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'planner' AND p.WSP_Name = N'params:write')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'planner' AND p.WSP_Name = N'params:write';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_Role_Permissions rp
               JOIN dbo.W_Roles r ON r.WSR_ID = rp.WSR_ID
               JOIN dbo.W_Permissions p ON p.WSP_ID = rp.WSP_ID
               WHERE r.WSR_Name = N'operator' AND p.WSP_Name = N'alarms:confirm')
INSERT INTO dbo.W_Role_Permissions (WSR_ID, WSP_ID)
SELECT r.WSR_ID, p.WSP_ID FROM dbo.W_Roles r, dbo.W_Permissions p
WHERE r.WSR_Name = N'operator' AND p.WSP_Name = N'alarms:confirm';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_User_Roles ur
               JOIN dbo.W_Users u ON u.WSU_ID = ur.WSU_ID
               JOIN dbo.W_Roles r ON r.WSR_ID = ur.WSR_ID
               WHERE u.WSU_Account = N'admin' AND r.WSR_Name = N'admin')
INSERT INTO dbo.W_User_Roles (WSU_ID, WSR_ID)
SELECT u.WSU_ID, r.WSR_ID FROM dbo.W_Users u, dbo.W_Roles r
WHERE u.WSU_Account = N'admin' AND r.WSR_Name = N'admin';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_User_Roles ur
               JOIN dbo.W_Users u ON u.WSU_ID = ur.WSU_ID
               JOIN dbo.W_Roles r ON r.WSR_ID = ur.WSR_ID
               WHERE u.WSU_Account = N'planner' AND r.WSR_Name = N'planner')
INSERT INTO dbo.W_User_Roles (WSU_ID, WSR_ID)
SELECT u.WSU_ID, r.WSR_ID FROM dbo.W_Users u, dbo.W_Roles r
WHERE u.WSU_Account = N'planner' AND r.WSR_Name = N'planner';
GO


IF NOT EXISTS (SELECT 1 FROM dbo.W_User_Roles ur
               JOIN dbo.W_Users u ON u.WSU_ID = ur.WSU_ID
               JOIN dbo.W_Roles r ON r.WSR_ID = ur.WSR_ID
               WHERE u.WSU_Account = N'operator' AND r.WSR_Name = N'operator')
INSERT INTO dbo.W_User_Roles (WSU_ID, WSR_ID)
SELECT u.WSU_ID, r.WSR_ID FROM dbo.W_Users u, dbo.W_Roles r
WHERE u.WSU_Account = N'operator' AND r.WSR_Name = N'operator';
GO


SELECT u.WSU_Account, u.WSU_UserName, u.WSU_IsMulti, r.WSR_Name AS RoleName
FROM dbo.W_Users u
LEFT JOIN dbo.W_User_Roles ur ON ur.WSU_ID = u.WSU_ID
LEFT JOIN dbo.W_Roles r ON r.WSR_ID = ur.WSR_ID;
GO
