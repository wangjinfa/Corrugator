/* =====================================================================
   BaseDB.TB_Line 示例数据 —— 多瓦线多库路由的入口配置
   执行前先跑 db/sqlserver_basedb_schema.sql 建表
   注意：F_ConnectionString 填的是“该瓦线自己的业务库”（IPS 结构那 155 张表）
   ===================================================================== */
SET ANSI_NULLS ON;
SET QUOTED_IDENTIFIER ON;
GO

/* 一号瓦线 -> 库 IPS_L1 */
IF NOT EXISTS (SELECT 1 FROM dbo.TB_Line WHERE WF_Code = N'Line1')
INSERT INTO dbo.TB_Line
    (WF_Code, WF_Name, F_ConfigID, F_ConnectionString, F_ServerIP, F_ServerPort, F_Gateway, F_WaveLineLayer, WF_DoorWidth, F_ApiUrl)
VALUES
    (N'Line1', N'一号瓦线', N'IPS_L1',
     N'Server=localhost;Database=IPS_L1;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False',
     N'127.0.0.1', 5099, NULL, 5, 2500, N'http://127.0.0.1:5099');
GO

/* 二号瓦线 -> 库 IPS_L2 */
IF NOT EXISTS (SELECT 1 FROM dbo.TB_Line WHERE WF_Code = N'Line2')
INSERT INTO dbo.TB_Line
    (WF_Code, WF_Name, F_ConfigID, F_ConnectionString, F_ServerIP, F_ServerPort, F_Gateway, F_WaveLineLayer, WF_DoorWidth, F_ApiUrl)
VALUES
    (N'Line2', N'二号瓦线', N'IPS_L2',
     N'Server=localhost;Database=IPS_L2;User Id=sa;Password=YourStrong!Passw0rd;TrustServerCertificate=True;Encrypt=False',
     N'127.0.0.1', 5099, NULL, 7, 2800, N'http://127.0.0.1:5099');
GO

SELECT WF_ID, WF_Code, WF_Name, F_ConfigID, F_WaveLineLayer, WF_DoorWidth, F_ApiUrl FROM dbo.TB_Line;
GO
