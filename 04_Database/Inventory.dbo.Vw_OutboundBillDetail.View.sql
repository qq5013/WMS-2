USE [Inventory]
GO

/****** Object:  View [dbo].[Vw_OutboundBillDetail]    Script Date: 05/02/2013 23:05:18 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO





CREATE VIEW [dbo].[Vw_OutboundBillDetail]
AS
SELECT     obd.Id, obd.BillId, obd.StockId, obd.LocationId, obd.ContainerId, obd.SkuId, obd.PackId, obd.BatchNumber, obd.Qty, s.SkuNumber, s.SkuName, p.PackName, p.Length * p.Width * p.Height / 1000000 AS PackVolume, 
                      p.Weight / 1000 AS PackWeight
FROM         dbo.OutboundBillDetail AS obd INNER JOIN
                      dbo.Vw_Sku AS s ON s.SkuId = obd.SkuId INNER JOIN
                      dbo.Vw_Sku AS p ON p.PackId = obd.PackId





GO


