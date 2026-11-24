/* IPS 部位显示/隐藏 TB_Ips_PartDisplay
   基础信息 → IPS部位显示/隐藏，图形化控制页按部位编码决定是否显示该部位。 */

IF OBJECT_ID(N'dbo.TB_Ips_PartDisplay', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Ips_PartDisplay] (
    [F_Code]     nvarchar(40)  NOT NULL,
    [F_Name]     nvarchar(100) NULL,
    [F_IsShow]   bit           NULL,
    [F_SortNo]   int           NULL,
    [F_Editor]   nvarchar(50)  NULL,
    [F_EditTime] datetime2     NULL,
    [F_ID]       bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Ips_PartDisplay] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 样例（与现场截图一致，18 个部位全为显示） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Ips_PartDisplay])
BEGIN
INSERT INTO dbo.[TB_Ips_PartDisplay] ([F_Code],[F_Name],[F_IsShow],[F_SortNo],[F_EditTime]) VALUES
 (N'GlueGU1',   N'糊机胶水-1层',      1, 1,  SYSDATETIME()),
 (N'GlueGU2',   N'糊机胶水-2层',      1, 2,  SYSDATETIME()),
 (N'GlueGU3',   N'糊机胶水-3层',      1, 3,  SYSDATETIME()),
 (N'GlueSF1',   N'单面机1胶水',       1, 4,  SYSDATETIME()),
 (N'GlueSF2',   N'单面机2胶水',       1, 5,  SYSDATETIME()),
 (N'GlueSF3',   N'单面机3胶水',       1, 6,  SYSDATETIME()),
 (N'WrapGU1',   N'糊机包角-1层',      1, 7,  SYSDATETIME()),
 (N'WrapGU2',   N'糊机包角-2层',      1, 8,  SYSDATETIME()),
 (N'WrapGU3',   N'糊机包角-3层',      1, 9,  SYSDATETIME()),
 (N'WrapGUAdd1',N'糊机包角-附加烘缸1', 1, 10, SYSDATETIME()),
 (N'WrapGUAdd2',N'糊机包角-附加烘缸2', 1, 11, SYSDATETIME()),
 (N'WrapLSO',   N'面纸包角',          1, 12, SYSDATETIME()),
 (N'WrapMS1',   N'1芯包角',           1, 13, SYSDATETIME()),
 (N'WrapLS1',   N'1里包角',           1, 14, SYSDATETIME()),
 (N'WrapMS2',   N'2芯包角',           1, 15, SYSDATETIME()),
 (N'WrapLS2',   N'2里包角',           1, 16, SYSDATETIME()),
 (N'WrapMS3',   N'3芯包角',           1, 17, SYSDATETIME()),
 (N'WrapLS3',   N'3里包角',           1, 18, SYSDATETIME());
END
GO
