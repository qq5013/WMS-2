USE [Inventory]
GO
/****** Object:  Table [dbo].[StockLog]    Script Date: 04/25/2013 18:41:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[LogType] [int] NOT NULL,
	[LogTime] [varchar](20) NOT NULL,
	[LinkBillType] [int] NOT NULL,
	[LinkBillId] [int] NOT NULL,
	[LinkBillNumber] [varchar](30) NULL,
	[WarehouseId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NOT NULL,
	[BeforeQty] [int] NOT NULL,
	[InboundQty] [int] NOT NULL,
	[OutboundQty] [int] NOT NULL,
	[AfterQty] [int] NOT NULL,
	[InboundBillNumber] [varchar](30) NULL,
 CONSTRAINT [PK_STOCKLOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存日志类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'LogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'LinkBillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'LinkBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变更前数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'BeforeQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'InboundQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'OutboundQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'变更后数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockLog', @level2type=N'COLUMN',@level2name=N'AfterQty'
GO
