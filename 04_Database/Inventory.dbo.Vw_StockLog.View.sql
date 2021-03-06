USE [Inventory]
GO
/****** Object:  View [dbo].[Vw_StockLog]    Script Date: 04/25/2013 18:41:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Vw_StockLog]
AS
SELECT     sl.Id, sl.LogType, dd.DictionaryValue AS LogTypeName, sl.LogTime, sl.LinkBillType, dd1.DictionaryValue AS BillTypeName, sl.LinkBillId, sl.LinkBillNumber, sl.WarehouseId, w.WarehouseCode, 
                      w.WarehouseName, a.AreaId, a.AreaCode, a.AreaName, sl.LocationId, l.LocationCode, l.LocationName, sl.ContainerId, c.ContainerCode, c.ContainerName, sl.SkuId, sku.SkuNumber, sku.SkuName, 
                      sl.PackId, p.PackName, sl.BatchNumber, sl.BeforeQty, sl.InboundQty, sl.OutboundQty, sl.AfterQty, sl.InboundBillNumber, ib.ProductionDate, ib.ExpiringDate, ib.ProductionBatch, 
                      ib.ManufacturingOrigin, ib.PropertyValue1, ib.PropertyValue2, ib.PropertyValue3, ib.PropertyValue4, ib.PropertyValue5, ib.PropertyValue6
FROM         dbo.StockLog AS sl INNER JOIN
                      Warehouse.dbo.Location AS l ON l.LocationId = sl.LocationId INNER JOIN
                      Warehouse.dbo.Area AS a ON a.AreaId = l.AreaId INNER JOIN
                      Wms.dbo.Warehouse AS w ON w.WarehouseId = a.WarehouseId LEFT OUTER JOIN
                      dbo.InboundBatch AS b ON sl.BatchNumber = b.BatchNumber LEFT OUTER JOIN
                      Warehouse.dbo.Container AS c ON c.ContainerId = sl.ContainerId INNER JOIN
                      Wms.dbo.Sku AS sku ON sku.SkuId = sl.SkuId INNER JOIN
                      Wms.dbo.Pack AS p ON p.PackId = sl.PackId INNER JOIN
                      Application.dbo.DataDictionary AS dd ON dd.DictionaryId = sl.LogType LEFT OUTER JOIN
                      dbo.InboundBatch AS ib ON ib.BatchNumber = sl.BatchNumber INNER JOIN
                      Application.dbo.DataDictionary AS dd1 ON dd1.DictionaryId = sl.LinkBillType
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[23] 4[13] 2[29] 3) )"
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
         Begin Table = "l"
            Begin Extent = 
               Top = 6
               Left = 236
               Bottom = 126
               Right = 396
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "a"
            Begin Extent = 
               Top = 126
               Left = 38
               Bottom = 246
               Right = 198
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "w"
            Begin Extent = 
               Top = 126
               Left = 236
               Bottom = 246
               Right = 407
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "b"
            Begin Extent = 
               Top = 246
               Left = 38
               Bottom = 366
               Right = 224
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 246
               Left = 262
               Bottom = 366
               Right = 425
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sku"
            Begin Extent = 
               Top = 366
               Left = 38
               Bottom = 486
               Right = 232
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "p"
            Begin Extent = 
               Top = 366
               Left = 270
               Bottom = 486
               Right = 430
            End
            DisplayFlags = 280
            TopColumn = 0
         E' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_StockLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane2', @value=N'nd
         Begin Table = "dd"
            Begin Extent = 
               Top = 6
               Left = 434
               Bottom = 126
               Right = 597
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "ib"
            Begin Extent = 
               Top = 6
               Left = 635
               Bottom = 126
               Right = 821
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "dd1"
            Begin Extent = 
               Top = 126
               Left = 445
               Bottom = 246
               Right = 608
            End
            DisplayFlags = 280
            TopColumn = 0
         End
         Begin Table = "sl"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 126
               Right = 198
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
      Begin ColumnWidths = 41
         Width = 284
         Width = 1500
         Width = 1500
         Width = 1500
         Width = 1905
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
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_StockLog'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=2 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'Vw_StockLog'
GO
