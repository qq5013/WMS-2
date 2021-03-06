USE [Inventory]
GO
/****** Object:  View [dbo].[Vw_Stock]    Script Date: 04/25/2013 18:41:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vw_Stock]
AS
SELECT     s.StockId, s.WarehouseId, w.WarehouseCode, w.WarehouseName, a.AreaId, a.AreaCode, a.AreaName, a.AreaType, s.LocationId, l.LocationCode, l.LocationName, s.ContainerId, c.ContainerCode, 
                      c.ContainerName, s.SkuId, sku.SkuNumber, sku.SkuName, s.PackId, p.PackName, s.BatchNumber, s.Qty, ip.PlanNumber, s.BillNumber, s.InboundDate, b.ProductionDate, b.ExpiringDate, 
                      b.ProductionBatch, b.ManufacturingOrigin, b.PropertyValue1, b.PropertyValue2, b.PropertyValue3, b.PropertyValue4, b.PropertyValue5, b.PropertyValue6
FROM         dbo.Stock AS s INNER JOIN
                      Warehouse.dbo.Location AS l ON l.LocationId = s.LocationId INNER JOIN
                      Warehouse.dbo.Area AS a ON a.AreaId = l.AreaId INNER JOIN
                      Wms.dbo.Warehouse AS w ON w.WarehouseId = a.WarehouseId LEFT OUTER JOIN
                      dbo.InboundBatch AS b ON s.BatchNumber = b.BatchNumber LEFT OUTER JOIN
                      Warehouse.dbo.Container AS c ON c.ContainerId = s.ContainerId INNER JOIN
                      Wms.dbo.Sku AS sku ON sku.SkuId = s.SkuId INNER JOIN
                      Wms.dbo.Pack AS p ON p.PackId = s.PackId INNER JOIN
                      dbo.InboundBill AS ib ON ib.BillNumber = s.BillNumber INNER JOIN
                      dbo.InboundPlan AS ip ON ip.PlanId = ib.PlanId
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[42] 4[15] 2[27] 3) )"
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
         Begin Table = "c"
            Begin Extent = 
               Top = 198
               Left = 658
               Bottom = 318
               Right = 821
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sku"
            Begin Extent = 
               Top = 318
               Left = 658
               Bottom = 438
               Right = 852
            End
            DisplayFlags = 280
            TopColumn = 0
   ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_Stock'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'      End
         Begin Table = "p"
            Begin Extent = 
               Top = 414
               Left = 38
               Bottom = 534
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ib"
            Begin Extent = 
               Top = 438
               Left = 445
               Bottom = 558
               Right = 622
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ip"
            Begin Extent = 
               Top = 438
               Left = 660
               Bottom = 558
               Right = 829
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
      Begin ColumnWidths = 35
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
