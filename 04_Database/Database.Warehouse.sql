USE [Warehouse]
GO
/****** Object:  StoredProcedure [dbo].[usp_SplitPager]    Script Date: 04/02/2013 10:46:11 ******/
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
/****** Object:  Table [dbo].[Tag]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Tag](
	[TagId] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[TagNumber] [nvarchar](30) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TAG] PRIMARY KEY CLUSTERED 
(
	[TagId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'TagId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'TagNumber'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Tag', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[SkuTag]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkuTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_SKUTAG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuTag', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuTag', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuTag', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuTag', @level2type=N'COLUMN',@level2name=N'TagId'
GO
/****** Object:  Table [dbo].[SkuLocation]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SkuLocation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
 CONSTRAINT [PK_SkuLocation_1] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [PK_SKULOCATION] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuLocation', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuLocation', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuLocation', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuLocation', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
/****** Object:  Table [dbo].[Shelf]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Shelf](
	[ShelfId] [int] IDENTITY(10000,1) NOT NULL,
	[ShelfCode] [varchar](30) NOT NULL,
	[ShelfName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[AisleId] [int] NULL,
	[ShelfType] [int] NOT NULL,
	[DirectionAngle] [int] NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[Row] [int] NOT NULL,
	[Column] [int] NOT NULL,
	[Depth] [int] NOT NULL,
	[CoordX] [numeric](18, 6) NULL,
	[CoordY] [numeric](18, 6) NULL,
	[CoordZ] [numeric](18, 6) NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SHELF] PRIMARY KEY NONCLUSTERED 
(
	[ShelfId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'ShelfId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'ShelfCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'ShelfName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'AreaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'面向通道编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'AisleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'ShelfType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方向角度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'DirectionAngle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'行' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Row'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'列' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Column'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'深度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Depth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'X坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'CoordX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'CoordY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Z坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'CoordZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Shelf', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[Setting]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Setting](
	[SettingId] [int] IDENTITY(10000,1) NOT NULL,
	[SettingCode] [varchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[ValueType] [varchar](20) NOT NULL,
	[SettingValue] [nvarchar](100) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SETTING] PRIMARY KEY CLUSTERED 
(
	[SettingId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'SettingId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'SettingCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'值类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'ValueType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'设置值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'SettingValue'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Setting', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[SafetyStock]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SafetyStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[MinQty] [int] NOT NULL,
	[MaxQty] [int] NOT NULL,
 CONSTRAINT [PK_SAFETYSTOCK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小库存量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'MinQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大库存量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SafetyStock', @level2type=N'COLUMN',@level2name=N'MaxQty'
GO
/****** Object:  Table [dbo].[OperatorGroup]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[OperatorGroup](
	[GroupId] [int] IDENTITY(10000,1) NOT NULL,
	[GroupName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[OperationType] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_OPERATORGROUP] PRIMARY KEY CLUSTERED 
(
	[GroupId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组名' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'GroupName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隶属仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'OperationType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'OperatorGroup', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[LocationTag]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationTag](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[TagId] [int] NOT NULL,
 CONSTRAINT [PK_LOCATIONTAG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationTag', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationTag', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationTag', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'标签编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationTag', @level2type=N'COLUMN',@level2name=N'TagId'
GO
/****** Object:  Table [dbo].[LocationSafetyStock]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LocationSafetyStock](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[LocationId] [int] NOT NULL,
	[SkuId] [int] NOT NULL,
	[PackId] [int] NOT NULL,
	[MinQty] [int] NOT NULL,
	[MaxQty] [int] NOT NULL,
 CONSTRAINT [PK_LOCATIONSAFETYSTOCK] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'拣货库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'SkuId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'包装编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'PackId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最小库存量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'MinQty'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'最大库存量' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'LocationSafetyStock', @level2type=N'COLUMN',@level2name=N'MaxQty'
GO
/****** Object:  Table [dbo].[Location]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Location](
	[LocationId] [int] IDENTITY(100000,1) NOT NULL,
	[LocationCode] [varchar](30) NOT NULL,
	[LocationName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[ShelfId] [int] NULL,
	[ShelfRow] [int] NULL,
	[ShelfColumn] [int] NULL,
	[ShelfDepth] [int] NULL,
	[CoordX] [numeric](18, 6) NULL,
	[CoordY] [numeric](18, 6) NULL,
	[CoordZ] [numeric](18, 6) NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[BearingWeight] [numeric](18, 6) NOT NULL,
	[Barcode] [varchar](30) NOT NULL,
	[Route] [int] NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_LOCATION] PRIMARY KEY CLUSTERED 
(
	[LocationId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'LocationId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'LocationCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'LocationName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'AreaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'ShelfId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架行号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'ShelfRow'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架列号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'ShelfColumn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货架深度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'ShelfDepth'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'X坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'CoordX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'CoordY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Z坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'CoordZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'BearingWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库位条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Barcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'路线序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Route'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否禁用' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Location', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_GROUPMEMBER] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupMember', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupMember', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupMember', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用户编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GroupMember', @level2type=N'COLUMN',@level2name=N'UserId'
GO
/****** Object:  Table [dbo].[ContainerType]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContainerType](
	[TypeId] [int] IDENTITY(1,1) NOT NULL,
	[TypeCode] [varchar](30) NOT NULL,
	[TypeName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[Weight] [numeric](18, 6) NOT NULL,
	[BearingWeight] [numeric](18, 6) NOT NULL,
	[PurposeType] [int] NOT NULL,
 CONSTRAINT [PK_CONTAINERTYPE] PRIMARY KEY NONCLUSTERED 
(
	[TypeId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器类型编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'TypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'TypeCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'类型名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'TypeName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隶属仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'Weight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'承重' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'BearingWeight'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'用途类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'ContainerType', @level2type=N'COLUMN',@level2name=N'PurposeType'
GO
/****** Object:  Table [dbo].[Container]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Container](
	[ContainerId] [int] IDENTITY(100000,1) NOT NULL,
	[ContainerCode] [varchar](30) NOT NULL,
	[ContainerName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[ContainerType] [int] NOT NULL,
	[Barcode] [varchar](30) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CONTAINER] PRIMARY KEY NONCLUSTERED 
(
	[ContainerId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'ContainerId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'ContainerCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'ContainerName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'隶属仓库' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'ContainerType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'容器条码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'Barcode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Container', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[AreaGroup]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AreaGroup](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[AreaId] [int] NOT NULL,
	[GroupId] [int] NOT NULL,
 CONSTRAINT [PK_AREAGROUP] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自动编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaGroup', @level2type=N'COLUMN',@level2name=N'Id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaGroup', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaGroup', @level2type=N'COLUMN',@level2name=N'AreaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'操作员组编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'AreaGroup', @level2type=N'COLUMN',@level2name=N'GroupId'
GO
/****** Object:  Table [dbo].[Area]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Area](
	[AreaId] [int] IDENTITY(10000,1) NOT NULL,
	[AreaCode] [varchar](30) NOT NULL,
	[AreaName] [nvarchar](30) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[AreaType] [int] NOT NULL,
	[CoordX] [numeric](18, 6) NULL,
	[CoordY] [numeric](18, 6) NULL,
	[CoordZ] [numeric](18, 6) NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[CreateUser] [int] NOT NULL,
	[CreateTime] [varchar](20) NOT NULL,
	[EditUser] [int] NULL,
	[EditTime] [varchar](20) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AREA] PRIMARY KEY CLUSTERED 
(
	[AreaId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'AreaId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'AreaCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'AreaName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'库区类型' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'AreaType'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'X坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'CoordX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'CoordY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Z坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'CoordZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'备注' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'CreateUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'创建时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'CreateTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑用户' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'EditUser'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'编辑时间' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'EditTime'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Area', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
/****** Object:  Table [dbo].[Aisle]    Script Date: 04/02/2013 10:46:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Aisle](
	[AisleId] [int] IDENTITY(10000,1) NOT NULL,
	[WarehouseId] [int] NOT NULL,
	[AisleCode] [varchar](30) NOT NULL,
	[AisleName] [nvarchar](30) NOT NULL,
	[DirectionAngle] [int] NOT NULL,
	[CoordX] [numeric](18, 6) NULL,
	[CoordY] [numeric](18, 6) NULL,
	[CoordZ] [numeric](18, 6) NULL,
	[Length] [numeric](18, 6) NOT NULL,
	[Width] [numeric](18, 6) NOT NULL,
	[Height] [numeric](18, 6) NOT NULL,
	[Remark] [nvarchar](250) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_AISLE] PRIMARY KEY NONCLUSTERED 
(
	[AisleId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通道编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'AisleId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'仓库编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'WarehouseId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通道代码' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'AisleCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'通道名称' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'AisleName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'方向角度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'DirectionAngle'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'X坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'CoordX'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Y坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'CoordY'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Z坐标' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'CoordZ'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'长度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'Length'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'宽度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'Width'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'高度' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'Height'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'描述' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'Remark'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'是否激活' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Aisle', @level2type=N'COLUMN',@level2name=N'IsActive'
GO
