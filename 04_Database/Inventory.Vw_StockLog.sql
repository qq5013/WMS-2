USE [Inventory]
GO

/****** Object:  View [dbo].[Vw_StockLog]    Script Date: 04/24/2013 12:04:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[Vw_StockLog]
AS
SELECT     sl.Id, sl.LogType, sl.LogTime, sl.LinkBillType, sl.LinkBillId, sl.WarehouseId, sl.LocationId, sl.ContainerId, sl.SkuId, sl.PackId, sl.BatchNumber, sl.BeforeQty, sl.InboundQty, 
           sl.OutboundQty, sl.AfterQty, '' as LogTypeName, sku.SkuName, p.PackName, w.WarehouseName, a.AreaName, l.LocationName, c.ContainerName
FROM         dbo.StockLog AS sl INNER JOIN
                      Warehouse.dbo.Location AS l ON l.LocationId = sl.LocationId INNER JOIN
                      Warehouse.dbo.Area AS a ON a.AreaId = l.AreaId INNER JOIN
                      Wms.dbo.Warehouse AS w ON w.WarehouseId = a.WarehouseId LEFT OUTER JOIN
                      dbo.InboundBatch AS b ON sl.BatchNumber = b.BatchNumber LEFT OUTER JOIN
                      Warehouse.dbo.Container AS c ON c.ContainerId = sl.ContainerId INNER JOIN
                      Wms.dbo.Sku AS sku ON sku.SkuId = sl.SkuId INNER JOIN
                      Wms.dbo.Pack AS p ON p.PackId = sl.PackId




GO