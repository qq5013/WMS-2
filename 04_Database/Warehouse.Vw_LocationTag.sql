USE [Warehouse]
GO

/****** Object:  View [dbo].[Vw_LocationTag]    Script Date: 04/26/2013 09:37:48 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO







CREATE VIEW [dbo].[Vw_LocationTag]
AS
SELECT     lt.Id, lt.WarehouseId, lt.LocationId, lt.TagId, l.LocationName, l.LocationCode, t.TagNumber, w.WarehouseName
FROM         dbo.LocationTag AS lt INNER JOIN
                      dbo.Location AS l ON l.LocationId = lt.LocationId INNER JOIN
                      dbo.Tag AS t ON t.TagId = lt.TagId INNER JOIN
                      wms.dbo.Warehouse AS w ON w.WarehouseId = lt.WarehouseId







GO


