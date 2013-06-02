USE [Inventory]
GO

/****** Object:  View [dbo].[Vw_InboundBillDetail]    Script Date: 04/22/2013 14:15:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[Vw_InboundBillDetail]
AS
SELECT     ibd.Id, ibd.BillId, ibd.ContainerId, ibd.SkuId, ibd.PackId, ibd.BatchNumber, ibd.Qty, c.ContainerName, s.SkuNumber, s.SkuName, p.PackName, p.Length * p.Width * p.Height / 1000000 AS PackVolume, 
                      p.Weight / 1000 AS PackWeight
FROM         dbo.InboundBillDetail AS ibd INNER JOIN
                      dbo.Vw_Sku AS s ON s.SkuId = ibd.SkuId INNER JOIN
                      dbo.Vw_Sku AS p ON p.PackId = ibd.PackId INNER JOIN
                      Warehouse.dbo.Container AS c ON c.ContainerId = ibd.ContainerId




GO