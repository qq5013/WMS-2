USE [Inventory]
GO
/****** Object:  StoredProcedure [dbo].[usp_SplitPager]    Script Date: 04/02/2013 10:45:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- DROP PROCEDURE [dbo].[usp_SplitPager]
CREATE  PROCEDURE [dbo].[usp_SplitPager]
    @TableName          NVARCHAR(255), -- 表名
    @SelectFields       NVARCHAR(1000) = '*', -- 需要返回的列
    @OrderByField       NVARCHAR(255) = '', -- 排序的字段名
    @PageSize           INT = 100, -- 页尺寸
    @PageIndex          INT = 1, -- 页码
    @OrderType          BIT = 0, -- 设置排序类型, 非 0 值则降序
    @SelectCondition    NVARCHAR(2000) = '', -- 查询条件 (注意: 不要加 where)
    @RecordsCount       INT = 0 output -- 返回记录总数
AS
  DECLARE @SqlCount NVARCHAR(4000)
  DECLARE @SqlText VARCHAR(5000) -- 主语句
  DECLARE @TempSql VARCHAR(110) -- 临时变量
  DECLARE @OrderClause VARCHAR(400) -- 排序类型
  Declare @TempOut   int   
  
    IF @SelectCondition != ''
      begin
        SET @SqlCount = 'select @RecordsCount=count(*) from [' + @TableName + '] where ' + @SelectCondition
      end
    ELSE
      begin
        SET @SqlCount = 'select @RecordsCount=count(*) from [' + @TableName + ']'
      end
    exec   sp_executesql @SqlCount,N'@RecordsCount int output',@TempOut output
    select @RecordsCount = @TempOut

    IF @OrderType != 0
    BEGIN
      SET @TempSql = '<(select min'
      SET @OrderClause = ' order by [' + @OrderByField + '] desc'
       --如果@OrderType不是0，就执行降序。                                                
    END
    ELSE
    BEGIN
      SET @TempSql = '>(select max'
      SET @OrderClause = ' order by [' + @OrderByField + '] asc'
    END
    
    IF @PageIndex = 1
    BEGIN
      IF @SelectCondition != ''
          SET @SqlText = 'select top ' + Str(@PageSize) + ' ' + @SelectFields 
                       + ' from [' + @TableName + '] where ' + @SelectCondition + ' ' + @OrderClause
      ELSE
          SET @SqlText = 'select top ' + Str(@PageSize) + ' ' + @SelectFields 
                       + ' from [' + @TableName + '] ' + @OrderClause
      --如果是第一页就执行以上代码，这样会加快执行速度
    END
    ELSE
    BEGIN
      --以下代码赋予了@SqlText以真正执行的SQL代码
      -- ELSE BEGIN
      SET @SqlText = 'select top ' + Str(@PageSize) + ' ' + @SelectFields 
                   + ' from [' + @TableName + '] where [' + @OrderByField + '] ' + @TempSql + ' ([' + @OrderByField 
                   + ']) from (select top ' + Str((@PageIndex - 1) * @PageSize) + ' [' + @OrderByField 
                   + '] from [' + @TableName + ']' + @OrderClause + ') as tblTmp)' + @OrderClause
                                                                                                                                                                                                                                                                                                            
      IF @SelectCondition != ''
      SET @SqlText = 'select top ' + Str(@PageSize) + ' ' + @SelectFields 
                   + ' from [' + @TableName + '] where [' + @OrderByField + '] ' + @TempSql + ' ([' + @OrderByField 
                   + ']) from (select top ' + Str((@PageIndex - 1) * @PageSize) + ' [' + @OrderByField 
                   + '] from [' + @TableName + '] where ' + @SelectCondition + ' ' + @OrderClause 
                   + ') as tblTmp) and ' + @SelectCondition + ' ' + @OrderClause
    END
  
  
  EXEC (@SqlText)
GO
/****** Object:  Table [dbo].[TransferBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransferBillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[SourceLocationId] [int] NOT NULL,
	[TargetLocationId] [int] NOT NULL,
	[SourceContainerId] [int] NULL,
	[TargetContainerId] [int] NULL,
	[PlanQty] [int] NOT NULL,
	[PieceQty] [int] NOT NULL,
	[IsTransferContainer] [bit] NOT NULL,
 CONSTRAINT [PK_TRANSFERBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原库位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'SourceLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标库位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'TargetLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'SourceContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'TargetContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划移库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'PlanQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'PieceQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否移动容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBillDetail', @level2type=N'COLUMN',@level2name=N'IsTransferContainer'
GO
/****** Object:  Table [dbo].[TransferBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[TransferBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [nvarchar](50) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[TransferType] [int] NOT NULL,
	[LinkBillType] [int] NULL,
	[LinkBillId] [int] NULL,
	[PlanTransferDate] [varchar](20) NOT NULL,
	[TransferTime] [varchar](20) NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_TRANSFERBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库单代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'TransferType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'LinkBillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'LinkBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划移库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'PlanTransferDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'移库时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'TransferTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'TransferBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[StockSnLog]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockSnLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[StockLogId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Sn] [varchar](30) NOT NULL,
 CONSTRAINT [PK_STOCKSNLOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存日志编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'StockLogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSnLog', @level2type=N'COLUMN',@level2name=N'Sn'
GO
/****** Object:  Table [dbo].[StockSn]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[StockSn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Sn] [varchar](30) NOT NULL,
 CONSTRAINT [PK_STOCKSN] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSn', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSn', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商品编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSn', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSn', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'StockSn', @level2type=N'COLUMN',@level2name=N'Sn'
GO
/****** Object:  Table [dbo].[StockLog]    Script Date: 04/02/2013 10:45:23 ******/
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
/****** Object:  Table [dbo].[Stock]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Stock](
	[StockId] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_STOCK] PRIMARY KEY CLUSTERED 
(
	[StockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Stock', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[SortBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SortBillDetail](
	[Id] [int] NOT NULL,
	[SortBillId] [int] IDENTITY(1,1) NOT NULL,
	[StockId] [int] NOT NULL,
	[ContainerId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
	[SortOperator] [int] NOT NULL,
 CONSTRAINT [PK_SORTBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'SortBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBillDetail', @level2type=N'COLUMN',@level2name=N'SortOperator'
GO
/****** Object:  Table [dbo].[SortBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SortBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [varchar](30) NULL,
	[PickBillId] [int] NOT NULL,
	[PlanId] [int] NOT NULL,
	[SortTime] [varchar](20) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[IssueLocationId] [int] NOT NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_SORTBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣单代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'PickBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'SortTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'IssueLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SortBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[SerialNumber]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SerialNumber](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[PlanId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[SnIndex] [int] NOT NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[Sn] [varchar](30) NOT NULL,
 CONSTRAINT [PK_SERIALNUMBER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号索引' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'SnIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SerialNumber', @level2type=N'COLUMN',@level2name=N'Sn'
GO
/****** Object:  Table [dbo].[PickWave]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PickWave](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PickBillId] [int] NOT NULL,
	[PlanId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_PICKWAVE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'PickBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickWave', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[PickBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PickBillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PickBillId] [int] NOT NULL,
	[StockId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[PlanBatchNumber] [varchar](30) NULL,
	[PlanLocationId] [int] NOT NULL,
	[PlanContainerId] [int] NOT NULL,
	[PlanQty] [int] NOT NULL,
	[PickBatchNumber] [varchar](30) NULL,
	[PickLocationId] [int] NOT NULL,
	[PickContainerId] [int] NOT NULL,
	[PickQty] [int] NULL,
	[PickOperator] [int] NOT NULL,
 CONSTRAINT [PK_PICKBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PlanBatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PlanLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划容器' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PlanContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PlanQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickBatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBillDetail', @level2type=N'COLUMN',@level2name=N'PickOperator'
GO
/****** Object:  Table [dbo].[PickBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PickBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [varchar](30) NULL,
	[PickMode] [int] NULL,
	[WarehouseId] [int] NOT NULL,
	[Priority] [int] NULL,
	[PlanPickTime] [varchar](20) NULL,
	[PickTime] [varchar](20) NULL,
	[SortLocationId] [int] NOT NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_PICKBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货模式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'PickMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣选仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'Priority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划拣货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'PlanPickTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'PickTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'SortLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PickBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[PackageDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PackageDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PackageId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_PACKAGEDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'PackageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'PackageDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[Package]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Package](
	[PackageId] [int] IDENTITY(1,1) NOT NULL,
	[PackageNumber] [nvarchar](50) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[BillId] [int] NOT NULL,
	[LinkBillNumber] [varchar](30) NULL,
	[PackageIndex] [int] NOT NULL,
	[Weight] [numeric](18, 6) NOT NULL,
	[Volume] [numeric](18, 6) NOT NULL,
 CONSTRAINT [PK_PACKAGE] PRIMARY KEY CLUSTERED 
(
	[PackageId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'PackageId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'PackageNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'LinkBillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹索引' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'PackageIndex'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹重量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'Weight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包裹体积' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Package', @level2type=N'COLUMN',@level2name=N'Volume'
GO
/****** Object:  Table [dbo].[OutboundPlanDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OutboundPlanDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
	[IssuedQty] [int] NOT NULL,
 CONSTRAINT [PK_OUTBOUNDPLANDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已出库数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlanDetail', @level2type=N'COLUMN',@level2name=N'IssuedQty'
GO
/****** Object:  Table [dbo].[OutboundPlan]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OutboundPlan](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[PlanNumber] [varchar](30) NOT NULL,
	[OutboundType] [int] NOT NULL,
	[Priority] [int] NULL,
	[LinkBillType] [int] NULL,
	[LinkBillNumber] [varchar](30) NULL,
	[ClientId] [int] NOT NULL,
	[MerchantId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[Receiver] [nvarchar](20) NULL,
	[PlanIssueTime] [varchar](20) NOT NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_OUTBOUNDPLAN] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'PlanNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'OutboundType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'Priority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'LinkBillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'LinkBillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'ClientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'Receiver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划发货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'PlanIssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundPlan', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[OutboundBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OutboundBillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_OUTBOUNDBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货存储单元' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBillDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[OutboundBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OutboundBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [nvarchar](50) NOT NULL,
	[PlanId] [int] NOT NULL,
	[PickBillId] [int] NULL,
	[SortBillId] [int] NULL,
	[ClientId] [int] NOT NULL,
	[MerchantId] [int] NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[IssuePerson] [int] NOT NULL,
	[IssueLocationId] [int] NULL,
	[IssueTime] [varchar](20) NOT NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_OUTBOUNDBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'PickBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分拣单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'SortBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'ClientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'IssuePerson'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'IssueLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'IssueTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OutboundBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[OperationLog]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OperationLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [varchar](20) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[Operator] [int] NOT NULL,
	[OperationType] [int] NOT NULL,
	[LinkBillType] [int] NOT NULL,
	[LinkBillId] [int] NOT NULL,
	[SourceLocationId] [int] NOT NULL,
	[TargetLocationId] [int] NOT NULL,
	[SourceContainerId] [int] NULL,
	[TargetContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_OPERATIONLOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'LogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'Operator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'OperationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'LinkBillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'LinkBillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'SourceLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'TargetLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'原容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'SourceContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'目标容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'TargetContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperationLog', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[LockLog]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LockLog](
	[LogId] [int] IDENTITY(1,1) NOT NULL,
	[LogTime] [varchar](20) NOT NULL,
	[LockLogType] [int] NOT NULL,
	[LockId] [int] NOT NULL,
	[LockTime] [varchar](20) NOT NULL,
	[LockType] [int] NOT NULL,
	[LockMode] [int] NOT NULL,
	[LockReason] [int] NOT NULL,
	[Operator] [int] NOT NULL,
	[LockObject] [int] NOT NULL,
	[WarehouseId] [int] NULL,
	[LocationId] [int] NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NULL,
	[PackId] [int] NULL,
	[BatchNumber] [varchar](30) NOT NULL,
	[Qty] [int] NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_LOCKLOG] PRIMARY KEY CLUSTERED 
(
	[LogId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LogId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'日志时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LogTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定日志类型
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockLogType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定模式
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定原因
   
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockReason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'Operator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定对象' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LockObject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'托盘' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LockLog', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[Lock]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Lock](
	[LockId] [int] IDENTITY(1,1) NOT NULL,
	[LockTime] [varchar](20) NOT NULL,
	[LockType] [int] NOT NULL,
	[LockMode] [int] NOT NULL,
	[LockReason] [int] NOT NULL,
	[Operator] [int] NOT NULL,
	[LockObject] [int] NOT NULL,
	[WarehouseId] [int] NULL,
	[LocationId] [int] NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NULL,
	[PackId] [int] NULL,
	[BatchNumber] [varchar](30) NOT NULL,
	[Qty] [int] NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_LOCK] PRIMARY KEY CLUSTERED 
(
	[LockId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定类型
   库位
   容器
   货物' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定模式
   系统锁
   人工锁' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定原因
   预留
   拣货
   质检
   破损
   盘点
   移货
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockReason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定操作员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'Operator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定对象' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LockObject'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'托盘' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'锁定数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Lock', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[InboundPlanDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboundPlanDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[ReceivedQty] [int] NULL,
 CONSTRAINT [PK_INBOUNDPLANDETAIL] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'已收数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlanDetail', @level2type=N'COLUMN',@level2name=N'ReceivedQty'
GO
/****** Object:  Table [dbo].[InboundPlan]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InboundPlan](
	[PlanId] [int] IDENTITY(1,1) NOT NULL,
	[PlanNumber] [varchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[InboundType] [int] NOT NULL,
	[Priority] [int] NULL,
	[LinkBillType] [int] NULL,
	[LinkBillNumber] [varchar](30) NULL,
	[ClientId] [int] NOT NULL,
	[MerchantId] [int] NOT NULL,
	[VendorId] [int] NULL,
	[PlanReceiveTime] [varchar](20) NULL,
	[IsCrossDock] [bit] NOT NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_INBOUNDPLAN] PRIMARY KEY CLUSTERED 
(
	[PlanId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'PlanNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'InboundType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'Priority'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'LinkBillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'关联单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'LinkBillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'ClientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'VendorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划收货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'PlanReceiveTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否越库转运' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'IsCrossDock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundPlan', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[InboundBillException]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboundBillException](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[ExceptionReason] [int] NOT NULL,
 CONSTRAINT [PK_INBOUNDBILLEXCEPTION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'异常原因' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException', @level2type=N'COLUMN',@level2name=N'ExceptionReason'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货异常信息表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillException'
GO
/****** Object:  Table [dbo].[InboundBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InboundBillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_INBOUNDBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillDetail', @level2type=N'COLUMN',@level2name=N'Qty'
GO
/****** Object:  Table [dbo].[InboundBillAggregate]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InboundBillAggregate](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
 CONSTRAINT [PK_INBOUNDBILLAGGREGATE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实收数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单合计表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBillAggregate'
GO
/****** Object:  Table [dbo].[InboundBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InboundBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [varchar](30) NOT NULL,
	[PlanId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[MerchantId] [int] NOT NULL,
	[VendorId] [int] NULL,
	[WarehouseId] [int] NOT NULL,
	[DeliveryMan] [nvarchar](50) NULL,
	[Vehicle] [nvarchar](100) NULL,
	[ArrivalTime] [varchar](20) NOT NULL,
	[ReceiveTime] [varchar](20) NOT NULL,
	[ReceiveLocationId] [int] NOT NULL,
	[Receiver] [int] NOT NULL,
	[BillStatus] [int] NOT NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_INBOUNDBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'ClientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'供应商' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'VendorId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'DeliveryMan'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'送货车辆' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'Vehicle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'到仓时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'ArrivalTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'ReceiveTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'ReceiveLocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'Receiver'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[InboundBatch]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[InboundBatch](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[PlanNumber] [varchar](30) NOT NULL,
	[BillNumber] [varchar](30) NOT NULL,
	[BatchNumber] [varchar](30) NOT NULL,
	[InboundDate] [varchar](20) NOT NULL,
	[SkuId] [int] NOT NULL,
	[Qty] [int] NOT NULL,
	[ProductionDate] [varchar](20) NULL,
	[ExpiringDate] [varchar](20) NULL,
	[ProductionBatch] [varchar](20) NULL,
	[ManufacturingOrigin] [varchar](20) NULL,
	[PropertyValue1] [varchar](20) NULL,
	[PropertyValue2] [varchar](20) NULL,
	[PropertyValue3] [varchar](20) NULL,
	[PropertyValue4] [varchar](20) NULL,
	[PropertyValue5] [varchar](20) NULL,
	[PropertyValue6] [varchar](20) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
 CONSTRAINT [PK_INBOUNDBATCH] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库计划号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PlanNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'InboundDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'Qty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'生产日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'ProductionDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'过期日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'ExpiringDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产品批号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'ProductionBatch'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'产地' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'ManufacturingOrigin'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue1'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue2'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue3'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue4'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性5' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue5'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'扩展属性6' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'PropertyValue6'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'InboundBatch', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
/****** Object:  Table [dbo].[Distribution]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Distribution](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PlanId] [int] NOT NULL,
	[OrderNumber] [varchar](30) NOT NULL,
	[OrderTime] [varchar](20) NOT NULL,
	[ExpressCompany] [int] NOT NULL,
	[ExpressService] [int] NOT NULL,
	[PlanDeliveryDate] [varchar](20) NULL,
	[PlanDeliveryPeriod] [int] NULL,
	[PayMode] [int] NOT NULL,
	[CollectingAmount] [numeric](18, 6) NOT NULL,
	[DeliveryStaff] [nvarchar](20) NULL,
	[PurchaserName] [nvarchar](30) NOT NULL,
	[ReceiverName] [nvarchar](30) NOT NULL,
	[ReceiverAddress] [nvarchar](250) NOT NULL,
	[ReceiverPostalCode] [nvarchar](50) NOT NULL,
	[ReceiverCellphone] [nvarchar](50) NOT NULL,
	[ReceiverPhone] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_BIL_ORDERDISTRIBUTION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'出库计划编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'PlanId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'销售订单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'OrderNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'订单时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'OrderTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快递公司' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ExpressCompany'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'快递服务类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ExpressService'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划送货日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'PlanDeliveryDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划时间段' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'PlanDeliveryPeriod'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'付款方式' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'PayMode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'代收金额' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'CollectingAmount'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'配送员' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'DeliveryStaff'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'客户姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'PurchaserName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人姓名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ReceiverName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ReceiverAddress'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ReceiverPostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人手机' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ReceiverCellphone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'收货人联系电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Distribution', @level2type=N'COLUMN',@level2name=N'ReceiverPhone'
GO
/****** Object:  Table [dbo].[CountBillDetail]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CountBillDetail](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[BillId] [int] NOT NULL,
	[StockId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[ContainerId] [int] NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[AccountQty] [int] NOT NULL,
	[CountedQty] [int] NULL,
	[Operator] [int] NULL,
 CONSTRAINT [PK_COUNTBILLDETAIL] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库存编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'StockId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储单元编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装单位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'账面数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'AccountQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'实盘数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'CountedQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBillDetail', @level2type=N'COLUMN',@level2name=N'Operator'
GO
/****** Object:  Table [dbo].[CountBill]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CountBill](
	[BillId] [int] IDENTITY(1,1) NOT NULL,
	[BillNumber] [varchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[PlanCountDate] [varchar](20) NOT NULL,
	[CountTime] [varchar](20) NULL,
	[Auditor] [int] NULL,
	[AuditTime] [varchar](20) NULL,
	[BillStatus] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
 CONSTRAINT [PK_COUNTBILL] PRIMARY KEY CLUSTERED 
(
	[BillId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点单编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点单号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'BillNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'计划盘点日期' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'PlanCountDate'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'盘点时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'CountTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'Auditor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'审核时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'AuditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据状态' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'BillStatus'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CountBill', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
/****** Object:  Table [dbo].[BillSn]    Script Date: 04/02/2013 10:45:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BillSn](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[BillType] [int] NOT NULL,
	[BillId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[BatchNumber] [varchar](30) NULL,
	[Sn] [varchar](30) NOT NULL,
 CONSTRAINT [PK_BILLSN] PRIMARY KEY NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'BillType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单据编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'BillId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'入库批次号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'BatchNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'序列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BillSn', @level2type=N'COLUMN',@level2name=N'Sn'
GO
/****** Object:  View [dbo].[Vw_Stock]    Script Date: 04/02/2013 10:45:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vw_Stock]
AS
SELECT     s.StockId, s.WarehouseId, a.AreaId, a.AreaType, s.LocationId, s.ContainerId, s.SkuId, s.PackId, s.BatchNumber, s.Qty, b.PlanNumber, b.BillNumber, b.InboundDate, 
                      b.ProductionDate, b.ExpiringDate, b.ProductionBatch, b.ManufacturingOrigin, b.PropertyValue1, b.PropertyValue2, b.PropertyValue3, b.PropertyValue4, 
                      b.PropertyValue5, b.PropertyValue6
FROM         dbo.Stock AS s INNER JOIN
                      Warehouse.dbo.Location AS l ON l.LocationId = s.LocationId INNER JOIN
                      Warehouse.dbo.Area AS a ON a.AreaId = l.AreaId INNER JOIN
                      Wms.dbo.Warehouse AS w ON w.WarehouseId = a.WarehouseId INNER JOIN
                      dbo.InboundBatch AS b ON s.BatchNumber = b.BatchNumber
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[41] 4[21] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = -192
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 198
               Left = 38
               Bottom = 413
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 198
               Left = 236
               Bottom = 401
               Right = 422
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "l"
            Begin Extent = 
               Top = 198
               Left = 460
               Bottom = 317
               Right = 620
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 318
               Left = 460
               Bottom = 437
               Right = 620
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "w"
            Begin Extent = 
               Top = 402
               Left = 236
               Bottom = 521
               Right = 407
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
      Begin ColumnWidths = 24
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Widt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'h = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1500
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Stock'
GO
