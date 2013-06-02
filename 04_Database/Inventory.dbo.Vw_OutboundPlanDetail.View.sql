USE [Inventory]
GO

/****** Object:  View [dbo].[Vw_OutboundPlanDetail]    Script Date: 05/02/2013 23:06:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[Vw_OutboundPlanDetail]
AS
SELECT     opd.Id,opd.PlanId,opd.SkuId,opd.PackId,opd.BatchNumber,opd.Qty,opd.IssuedQty, s.SkuNumber, s.SkuName, p.PackName, p.Length * p.Width * p.Height / 1000000 AS PackVolume, 
                      p.Weight / 1000 AS PackWeight
FROM         dbo.OutboundPlanDetail AS opd INNER JOIN
                      dbo.Vw_Sku AS s ON s.SkuId = opd.SkuId INNER JOIN
                      dbo.Vw_Sku AS p ON p.PackId = opd.PackId


GO


