USE [Wms]
GO
/****** Object:  StoredProcedure [dbo].[usp_SplitPager]    Script Date: 04/02/2013 10:46:46 ******/
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
/****** Object:  Table [dbo].[SkuProperty]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkuProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkuId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_SKUPROPERTY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuProperty', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuProperty', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次属性编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuProperty', @level2type=N'COLUMN',@level2name=N'PropertyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuProperty', @level2type=N'COLUMN',@level2name=N'Priority'
GO
/****** Object:  Table [dbo].[SkuManagement]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SkuManagement](
	[SkuId] [int] NOT NULL,
	[AbcType] [int] NOT NULL,
	[IsBigItem] [bit] NOT NULL,
	[IsHeavyItem] [bit] NOT NULL,
	[StorageCondition] [int] NOT NULL,
	[ContainerManagement] [bit] NOT NULL,
	[PieceManagement] [bit] NOT NULL,
	[BarcodeManagement] [bit] NOT NULL,
	[QcPercent] [int] NOT NULL,
	[PickRule] [int] NOT NULL,
	[PickGroup] [int] NOT NULL,
	[ReplenishGroup] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SKUMANAGEMENT] PRIMARY KEY NONCLUSTERED 
(
	[SkuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ABC分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'AbcType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否大货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'IsBigItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否重货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'IsHeavyItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'StorageCondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'ContainerManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单件管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'PieceManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条码管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'BarcodeManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检百分比' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'QcPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣选规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'PickRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣选分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'PickGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补货分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'ReplenishGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuManagement', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[Sku]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Sku](
	[SkuId] [int] IDENTITY(100000,1) NOT NULL,
	[ClientId] [int] NOT NULL,
	[MerchantId] [int] NOT NULL,
	[Manufacturer] [int] NULL,
	[SkuNumber] [varchar](30) NOT NULL,
	[SkuName] [nvarchar](100) NOT NULL,
	[ErpCode] [varchar](30) NULL,
	[Brand] [nvarchar](30) NULL,
	[Specification] [nvarchar](30) NULL,
	[Model] [nvarchar](30) NULL,
	[Upc] [varchar](30) NULL,
	[CategoryId] [int] NULL,
	[Barcode] [varchar](30) NULL,
	[GuranteePeriodYear] [int] NULL,
	[GuranteePeriodMonth] [int] NULL,
	[GuranteePeriodDay] [int] NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SKU] PRIMARY KEY CLUSTERED 
(
	[SkuId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'平台编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'ClientId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'商家编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'MerchantId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'制造商编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Manufacturer'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'SkuNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'SkuName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ERP代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'ErpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'品牌' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Brand'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'规格' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Specification'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'型号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Model'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通用产品代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Upc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Barcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保质期年' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'GuranteePeriodYear'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保质期月' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'GuranteePeriodMonth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'保质期天' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'GuranteePeriodDay'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Sku', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[Pack]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pack](
	[PackId] [int] IDENTITY(100000,1) NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackLevel] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[PackName] [nvarchar](10) NOT NULL,
	[ToPieceQty] [int] NOT NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[Weigth] [numeric](18, 6) NOT NULL,
	[DefaultPack] [bit] NOT NULL,
 CONSTRAINT [PK_PACK] PRIMARY KEY NONCLUSTERED 
(
	[PackId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物单位级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'PackLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'PackName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'转换单品数量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'ToPieceQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'重量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'Weigth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否缺省管理包装' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Pack', @level2type=N'COLUMN',@level2name=N'DefaultPack'
GO
/****** Object:  Table [dbo].[District]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [int] IDENTITY(10000,1) NOT NULL,
	[DistrictCode] [varchar](20) NOT NULL,
	[DistrictLevel] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[DistrictName] [nvarchar](30) NOT NULL,
	[PostalCode] [varchar](20) NULL,
 CONSTRAINT [PK_Bas_Areas] PRIMARY KEY NONCLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地区编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'DistrictId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'DistrictCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区域级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'DistrictLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'父级区域编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'DistrictName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'District', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
/****** Object:  Table [dbo].[CompanyType]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CompanyType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[CompanyTypeId] [int] NOT NULL,
 CONSTRAINT [PK_COMPANYTYPE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CompanyType', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CompanyType', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司类型编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CompanyType', @level2type=N'COLUMN',@level2name=N'CompanyTypeId'
GO
/****** Object:  Table [dbo].[Company]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Company](
	[CompanyId] [int] IDENTITY(10000,1) NOT NULL,
	[CompanyCode] [varchar](30) NOT NULL,
	[ParentId] [int] NULL,
	[ErpCode] [varchar](30) NULL,
	[CompanyName] [nvarchar](100) NOT NULL,
	[ShortName] [nvarchar](30) NOT NULL,
	[Address] [nvarchar](250) NULL,
	[PostalCode] [varchar](20) NULL,
	[Contactor] [nvarchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[FaxNumber] [varchar](20) NULL,
	[CountyId] [int] NULL,
	[OrganizationCode] [varchar](30) NULL,
	[Representative] [nvarchar](20) NULL,
	[Homepage] [varchar](250) NULL,
	[TaxRegisterationCode] [varchar](30) NULL,
	[TaxNumber] [varchar](30) NULL,
	[Bank] [nvarchar](50) NULL,
	[AccountNumber] [varchar](30) NULL,
	[CurrencyType] [int] NOT NULL,
	[InvoiceType] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CompanyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CompanyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级公司编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ERP代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'ErpCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CompanyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司短名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'ShortName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'公司地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮政编码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Contactor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'FaxNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区县编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CountyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组织代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'OrganizationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'法人代表' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Representative'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'主页' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Homepage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缴税注册号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'TaxRegisterationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'税号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'TaxNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'开户银行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Bank'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'银行帐号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'AccountNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货币类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CurrencyType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'发票类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'InvoiceType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Company', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[CategoryProperty]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProperty](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryId] [int] NOT NULL,
	[PropertyId] [int] NOT NULL,
	[Priority] [int] NOT NULL,
 CONSTRAINT [PK_CATEGORYPROPERTY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryProperty', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'管理分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryProperty', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'批次属性编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryProperty', @level2type=N'COLUMN',@level2name=N'PropertyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'优先级' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryProperty', @level2type=N'COLUMN',@level2name=N'Priority'
GO
/****** Object:  Table [dbo].[CategoryManagement]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CategoryManagement](
	[CategoryId] [int] IDENTITY(1,1) NOT NULL,
	[CategoryCode] [varchar](30) NOT NULL,
	[CategoryLevel] [int] NOT NULL,
	[ParentId] [int] NOT NULL,
	[CategoryName] [nvarchar](30) NOT NULL,
	[AbcType] [int] NOT NULL,
	[IsBigItem] [bit] NOT NULL,
	[IsHeavyItem] [bit] NOT NULL,
	[StorageCondition] [int] NOT NULL,
	[ContainerManagement] [bit] NOT NULL,
	[PieceManagement] [bit] NOT NULL,
	[BarcodeManagement] [bit] NOT NULL,
	[QcPercent] [int] NOT NULL,
	[PickRule] [int] NOT NULL,
	[PickGroup] [int] NOT NULL,
	[ReplenishGroup] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CATEGORYMANAGEMENT] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CategoryId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CategoryCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类级别' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CategoryLevel'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'上级分类编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'ParentId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'分类名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CategoryName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ABC分类' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'AbcType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否大货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'IsBigItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否重货' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'IsHeavyItem'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'存储条件' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'StorageCondition'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'ContainerManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'单件管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'PieceManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'条码管理' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'BarcodeManagement'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'质检百分比' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'QcPercent'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣选规则' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'PickRule'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣选分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'PickGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'补货分组' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'ReplenishGroup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CategoryManagement', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[BatchProperty]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BatchProperty](
	[PropertyId] [int] IDENTITY(100,1) NOT NULL,
	[PropertyCode] [varchar](30) NOT NULL,
	[PropertyName] [nvarchar](30) NOT NULL,
	[DefaultValue] [varchar](30) NOT NULL,
	[ValueType] [varchar](10) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_BATCHPROPERTY] PRIMARY KEY CLUSTERED 
(
	[PropertyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'PropertyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'PropertyCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'属性名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'PropertyName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'缺省值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'DefaultValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'ValueType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BatchProperty', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[WarehouseUser]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WarehouseUser](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_WAREHOUSEUSER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WarehouseUser', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WarehouseUser', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WarehouseUser', @level2type=N'COLUMN',@level2name=N'UserId'
GO
/****** Object:  Table [dbo].[Warehouse]    Script Date: 04/02/2013 10:46:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Warehouse](
	[WarehouseId] [int] IDENTITY(100,1) NOT NULL,
	[WarehouseCode] [char](2) NOT NULL,
	[WarehouseName] [nvarchar](30) NOT NULL,
	[CountyId] [int] NULL,
	[Isbonded] [bit] NOT NULL,
	[Acreage] [numeric](18, 6) NULL,
	[Address] [nvarchar](250) NULL,
	[Contactor] [nvarchar](20) NULL,
	[PostalCode] [varchar](20) NULL,
	[Phone] [varchar](20) NULL,
	[FaxNumber] [varchar](20) NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_WAREHOUSE] PRIMARY KEY CLUSTERED 
(
	[WarehouseId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'WarehouseCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'WarehouseName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'区县编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'CountyId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否保税' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Isbonded'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'面积' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Acreage'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'地址' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Address'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'联系人' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Contactor'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'邮编' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'PostalCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'电话' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Phone'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'传真' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'FaxNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Warehouse', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  View [dbo].[Vw_User]    Script Date: 04/02/2013 10:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vw_User]
AS
SELECT     u.ApplicationId, u.UserId, u.UserCode, u.UserName, u.Password, u.CreateTime, u.LoginTime, u.Remark, u.IsActive
FROM         Application.dbo.[User] AS u INNER JOIN
                      Application.dbo.Application AS a ON a.ApplicationId = u.ApplicationId
WHERE     (a.ApplicationCode = 'WMS')
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "u"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 125
               Right = 404
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
      Begin ColumnWidths = 10
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_User'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_User'
GO
/****** Object:  View [dbo].[Vw_Sku]    Script Date: 04/02/2013 10:46:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vw_Sku]
AS
SELECT     s.SkuId, s.ClientId, c1.CompanyName AS ClientName, s.MerchantId, c2.CompanyName AS MerchantName, s.Manufacturer, c3.CompanyName AS ManufacturerName, 
                      s.SkuNumber, s.SkuName, s.ErpCode, s.Brand, s.Specification, s.Model, s.Upc, s.CategoryId, cm.CategoryName, s.Barcode, s.GuranteePeriodYear, 
                      s.GuranteePeriodMonth, s.GuranteePeriodDay, s.Remark, s.CreateUser, s.CreateTime, s.EditUser, s.EditTime, s.IsActive
FROM         dbo.Sku AS s INNER JOIN
                      dbo.Company AS c1 ON c1.CompanyId = s.ClientId INNER JOIN
                      dbo.Company AS c2 ON c2.CompanyId = s.MerchantId LEFT OUTER JOIN
                      dbo.Company AS c3 ON c3.CompanyId = s.Manufacturer INNER JOIN
                      dbo.CategoryManagement AS cm ON cm.CategoryId = s.CategoryId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
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
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "s"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 125
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c1"
            Begin Extent = 
               Top = 6
               Left = 270
               Bottom = 125
               Right = 466
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c2"
            Begin Extent = 
               Top = 6
               Left = 504
               Bottom = 125
               Right = 700
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c3"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 245
               Right = 234
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "cm"
            Begin Extent = 
               Top = 126
               Left = 272
               Bottom = 245
               Right = 470
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
      Begin ColumnWidths = 9
         Width = 284
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
         Outp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Sku'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'ut = 720
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Sku'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Sku'
GO
