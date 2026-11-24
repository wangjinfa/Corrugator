/* 订单扩展字段设置 TB_Order_ExtField
   基础信息 → 订单扩展字段设置，固定 18 个 Define 槽位（订单扩展信息以 Json 存放）。 */

IF OBJECT_ID(N'dbo.TB_Order_ExtField', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Order_ExtField] (
    [F_Seq]          int          NOT NULL,
    [F_Code]         nvarchar(40) NOT NULL,
    [F_JsonCode]     nvarchar(40) NULL,
    [F_Name]         nvarchar(100) NULL,
    [F_DataType]     nvarchar(20) NULL,
    [F_IsShowInList] bit          NULL,
    [F_Editor]       nvarchar(50) NULL,
    [F_EditTime]     datetime2    NULL,
    [F_ID]           bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Order_ExtField] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 样例：18 个槽位，前 3 个已启用（与现场截图一致） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Order_ExtField])
BEGIN
INSERT INTO dbo.[TB_Order_ExtField] ([F_Code],[F_Seq],[F_JsonCode],[F_Name],[F_DataType],[F_IsShowInList],[F_EditTime]) VALUES
 (N'Define1', 1, N'ex1', N'文本扩展', N'string', 1, SYSDATETIME()),
 (N'Define2', 2, N'ex2', N'数字扩展2', N'int', 1, SYSDATETIME()),
 (N'Define3', 3, N'ex3', N'布尔扩展3', N'bool', 1, SYSDATETIME()),
 (N'Define4', 4, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define5', 5, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define6', 6, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define7', 7, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define8', 8, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define9', 9, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define10', 10, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define11', 11, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define12', 12, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define13', 13, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define14', 14, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define15', 15, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define16', 16, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define17', 17, N'', N'', N'', 0, SYSDATETIME()),
 (N'Define18', 18, N'', N'', N'', 0, SYSDATETIME());
END
GO
