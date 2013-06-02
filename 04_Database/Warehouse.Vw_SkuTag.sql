USE [Warehouse]
GO

/****** Object:  View [dbo].[Vw_SkuTag]    Script Date: 04/26/2013 09:39:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO






CREATE VIEW [dbo].[Vw_SkuTag]
AS
SELECT     st.Id, st.WarehouseId, st.SkuId, st.TagId, s.SkuName, s.SkuNumber, t.TagNumber, w.WarehouseName
FROM         dbo.SkuTag AS st INNER JOIN
                      Wms.dbo.Sku AS s ON s.SkuId = st.SkuId INNER JOIN
                      dbo.Tag AS t ON t.TagId = st.TagId INNER JOIN
                      wms.dbo.Warehouse AS w ON w.WarehouseId = st.WarehouseId






GO


