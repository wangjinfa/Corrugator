/* 内置账号初始化时「将截断字符串或二进制数据」修复
   ------------------------------------------------------------------
   现象：启动日志
     warn: Startup[0] 内置账号初始化失败
     Microsoft.Data.SqlClient.SqlException: 将截断字符串或二进制数据。语句已终止。

   原因：W_Users / W_Roles / W_Permissions 是现场老库已有的表，
        列宽比代码实体窄（典型 WSU_Password 只有 nvarchar(20) 存明文 1），
        写入 84 字符的 PBKDF2 哈希（pbkdf2$100000$saltB64$hashB64）时被截断。

   处理：下面把种子要写的字符列加宽到代码要求的最小宽度。
        只加宽、不改类型语义，已足够宽的列执行也不会有副作用（可重复执行）。
   ------------------------------------------------------------------ */

/* 1) 先看现有列宽 */
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, CHARACTER_MAXIMUM_LENGTH, IS_NULLABLE
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('W_Users', 'W_Roles', 'W_Permissions')
  AND DATA_TYPE IN ('nvarchar', 'varchar', 'nchar', 'char')
ORDER BY TABLE_NAME, COLUMN_NAME;
GO

/* 2) W_Users：账号 / 密码（PBKDF2 哈希）/ 姓名 / 手机 / 审计 */
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_Account]      nvarchar(50)  NOT NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_Password]     nvarchar(200) NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_UserName]     nvarchar(50)  NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_Gender]       nvarchar(10)  NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_PhoneNo]      nvarchar(50)  NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_StopPosition] nvarchar(50)  NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_Creator]      nvarchar(20)  NULL;
ALTER TABLE dbo.[W_Users] ALTER COLUMN [WSU_Editor]       nvarchar(20)  NULL;
GO

/* 3) W_Roles */
ALTER TABLE dbo.[W_Roles] ALTER COLUMN [WSR_Name]    nvarchar(50) NOT NULL;  /* 角色编码：admin/planner/operator */
ALTER TABLE dbo.[W_Roles] ALTER COLUMN [WSR_Creator] nvarchar(20) NULL;
ALTER TABLE dbo.[W_Roles] ALTER COLUMN [WSR_Editor]  nvarchar(20) NULL;
GO

/* 4) W_Permissions */
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_Name]      nvarchar(50)  NOT NULL;
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_Type]      nvarchar(10)  NULL;
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_NameSpace] nvarchar(100) NULL;
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_Remark]    nvarchar(500) NULL;
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_Creator]   nvarchar(20)  NULL;
ALTER TABLE dbo.[W_Permissions] ALTER COLUMN [WSP_Editor]    nvarchar(20)  NULL;
GO

/* 5) 验证：密码列长度应 >= 200 */
SELECT COLUMN_NAME, CHARACTER_MAXIMUM_LENGTH
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME = 'W_Users' AND COLUMN_NAME IN ('WSU_Account', 'WSU_Password', 'WSU_UserName', 'WSU_Creator');
GO

/* 说明
   - 服务端启动时也会自动做同样的加宽检查（AuthService.EnsureSeedColumnWidthsAsync），
     仅对 SqlServer 生效，已够宽的列不动；日志里会打印 [SeedFix] W_Users.WSU_Password 由 20 加宽到 200。
   - 若现场密码列原本是明文（如 "1"），加宽不会改数据，登录仍按「明文/MD5/PBKDF2」三种兼容；
     新建账号一律写 PBKDF2。
   - WSU_Account 是 NOT NULL 主查询列，加宽时保留 NOT NULL；其余保持原 NULL 语义。
*/
