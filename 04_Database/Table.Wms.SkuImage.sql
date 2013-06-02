USE [Wms]
GO

/****** Object:  Table [dbo].[SkuImage]    Script Date: 04/02/2013 10:51:24 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[SkuImage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[SkuId] [int] NOT NULL,
	[ImageIndex] [int] NOT NULL,
	[Image] [varchar](max) NOT NULL,
 CONSTRAINT [PK_SkuImage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'自增主键' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuImage', @level2type=N'COLUMN',@level2name=N'Id'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'货物编号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuImage', @level2type=N'COLUMN',@level2name=N'SkuId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片序号' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuImage', @level2type=N'COLUMN',@level2name=N'ImageIndex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'图片' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SkuImage', @level2type=N'COLUMN',@level2name=N'Image'
GO

