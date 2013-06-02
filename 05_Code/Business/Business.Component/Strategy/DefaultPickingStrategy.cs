using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Domain.Warehouse;
using Business.Domain.Inventory.Views;
using Business.Domain.Inventory;
using Business.Common.DataDictionary;

namespace Business.Component.Strategy
{
    public class DefaultPickingStrategy : IPickingStrategy
    {
        public List<PickingStock> GetPickingStocks(int warehouseId, int skuId, int qty)
        {
            // get assigned stocks
            IList<StockView> stocks = StockManager.GetStocks(warehouseId, AreaType.Picking, skuId);
            
            //List<StockView> assignedStockViews = new List<StockView>();
            //int notAssignedQty = qty;
            //foreach (StockView stockView in stocks)
            //{
            //    if (stockView.Qty >= notAssignedQty)
            //    {
            //        StockView assignedStock = (StockView)stockView.Clone();
            //        assignedStock.Qty = notAssignedQty;
            //        assignedStockViews.Add(assignedStock);
            //        break;
            //    }
            //    else
            //    {
            //        StockView assignedStock = (StockView)stockView.Clone();
            //        assignedStockViews.Add(assignedStock);
            //        notAssignedQty = notAssignedQty - assignedStock.Qty;
            //    }
            //}

            // return picking stocks
            List<PickingStock> pickingStocks = new List<PickingStock>();
            foreach (StockView stockView in stocks)
            {
                PickingStock pickingStock = new PickingStock();
                pickingStock.BatchNumber = stockView.BatchNumber;
                pickingStock.ContainerId = stockView.ContainerId;
                if (pickingStock.ContainerId > 0)
                {
                    pickingStock.ContainerBarcode = WarehouseManager.GetContainerBarcode(pickingStock.ContainerId);
                    pickingStock.ContainerCode = stockView.ContainerCode;
                    pickingStock.ContainerName = stockView.ContainerName;
                }
                pickingStock.LocationId = stockView.LocationId;
                if (pickingStock.LocationId > 0)
                {
                    pickingStock.LocationBarcode = WarehouseManager.GetLocationBarcode(pickingStock.LocationId);
                    pickingStock.Route = WarehouseManager.GetLocationRoute(pickingStock.LocationId);
                    pickingStock.LocationCode = stockView.LocationCode;
                    pickingStock.LocationName = stockView.LocationName;
                }

                pickingStock.InboundBillNumber = stockView.BillNumber;
                pickingStock.PackId = stockView.PackId;
                pickingStock.PackName = stockView.PackName;
                pickingStock.SkuId = stockView.SkuId;
                pickingStock.SkuNumber = stockView.SkuNumber;
                pickingStock.SkuName = stockView.SkuName;
                pickingStock.StockId = stockView.StockId;
                if (pickingStock.SkuId > 0)
                {
                    pickingStock.SkuBarcode = SkuManager.GetSkuBarcode(pickingStock.SkuId);
                    pickingStock.UPC = SkuManager.GetSkuUPC(pickingStock.SkuId);
                }
                pickingStock.StockQty = stockView.Qty;
                pickingStocks.Add(pickingStock);
            }

            return pickingStocks;
        }
    }
}
