/* 订单颜色设置 W_Order_ColorSet
   基础信息 → 订单颜色设置。图形化控制页工单彩条按条件匹配，优先级数字越小越优先。 */

IF OBJECT_ID(N'dbo.W_Order_ColorSet', N'U') IS NULL
BEGIN
CREATE TABLE dbo.[W_Order_ColorSet] (
    [WF_Condition] nvarchar(50) NOT NULL,
    [WF_Priority]  int          NOT NULL,
    [WF_BackColor] nvarchar(20) NULL,
    [WF_FontColor] nvarchar(20) NULL,
    [WF_IsUse]     bit          NULL,
    [WF_Editor]    nvarchar(50) NULL,
    [WF_EditTime]  datetime2    NULL,
    [WF_ID]        bigint IDENTITY(1,1) NOT NULL,
    CONSTRAINT [PK_W_Order_ColorSet] PRIMARY KEY CLUSTERED ([WF_ID] ASC)
);
END
GO

/* 样例（与现场截图一致） */
IF NOT EXISTS (SELECT 1 FROM dbo.[W_Order_ColorSet])
BEGIN
INSERT INTO dbo.[W_Order_ColorSet] ([WF_Condition],[WF_Priority],[WF_BackColor],[WF_FontColor],[WF_IsUse],[WF_EditTime]) VALUES
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
