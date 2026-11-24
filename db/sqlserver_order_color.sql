/* 订单颜色设置 TB_Order_ColorSet
   基础信息 → 订单颜色设置。图形化控制页工单彩条按条件匹配，优先级数字越小越优先。 */

IF OBJECT_ID(N'dbo.TB_Order_ColorSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[TB_Order_ColorSet] (
    [F_Condition] nvarchar(50) NOT NULL,
    [F_Priority]  int          NOT NULL,
    [F_BackColor] nvarchar(20) NULL,
    [F_FontColor] nvarchar(20) NULL,
    [F_IsUse]     bit          NULL,
    [F_Editor]    nvarchar(50) NULL,
    [F_EditTime]  datetime2    NULL,
    [F_ID]        bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_TB_Order_ColorSet] PRIMARY KEY CLUSTERED ([F_ID] ASC)
);
END
GO

/* 样例（与现场截图一致） */
IF NOT EXISTS (SELECT 1 FROM dbo.[TB_Order_ColorSet])
BEGIN
INSERT INTO dbo.[TB_Order_ColorSet] ([F_Condition],[F_Priority],[F_BackColor],[F_FontColor],[F_IsUse],[F_EditTime]) VALUES
 (N'首笔订单',   1, N'#0000FF', N'',       1, SYSDATETIME()),
 (N'前3笔订单',  2, N'#F7941E', N'',       1, SYSDATETIME()),
 (N'插单',       3, N'#FFFF99', N'#000000', 1, SYSDATETIME()),
 (N'修改订单',   4, N'#FF9EC4', N'#000000', 1, SYSDATETIME()),
 (N'新增订单',   5, N'#90EE90', N'#000000', 1, SYSDATETIME()),
 (N'复制订单',   6, N'#90EE90', N'#000000', 1, SYSDATETIME()),
 (N'重做订单',   7, N'#FF9EC4', N'#000000', 1, SYSDATETIME()),
 (N'默认',       8, N'#FFFFFF', N'#000000', 1, SYSDATETIME());
END
GO
