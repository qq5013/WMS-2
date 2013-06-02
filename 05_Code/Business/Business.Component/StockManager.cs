using System;
using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Inventory;
using Business.Domain;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Business.Domain.Wms;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Business.DataAccess;

namespace Business.Component
{
    /// <summary>
    /// 库存管理器
    /// </summary>
    public class StockManager
    {
        /// <summary>
        /// 并发锁定对象
        /// </summary>
        private static readonly object Locker = new object();

        #region stock

        /// <summary>
        /// 创建库存对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">入库单编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="locationId">库位编号</param>
        /// <param name="containerId">容器编号</param>
        /// <param name="qty">库存数量</param>
        /// <param name="batchNumber">入库批次</param>
        /// <param name="billNumber">入库单号</param>
        /// <param name="inboundDate">入库日期</param>
        /// <returns>成功返回库存对象，否则返回null</returns>
        public static Stock CreateStock(int warehouseId, int billId, int skuId, int packId, int locationId,
                                        int containerId, int qty, string batchNumber,string billNumber, string inboundDate)
        {
            var stock = new Stock
                            {
                                BatchNumber = batchNumber,
                                ContainerId = containerId,
                                LocationId = locationId,
                                Qty = qty,
                                SkuId = skuId,
                                PackId = packId,
                                WarehouseId = warehouseId
                            };

            var repository = new StockRepository();
            int insertResult = repository.Create(stock);

            List<BillSn> billSns = SerialNumberManager.GetBillSn(warehouseId, BillType.InboundBill, billId, skuId,
                                                                 packId, batchNumber);

            // create stock sn
            StockSnRepository billSnRepository = new StockSnRepository();
            foreach (var billSn in billSns)
            {
                StockSn stockSn = new StockSn
                                      {
                                          PackId = packId,
                                          SkuId = skuId,
                                          WarehouseId = warehouseId,
                                          Sn = billSn.Sn
                                      };
                stockSn.Id = billSnRepository.Create(stockSn);
                if (stockSn.Id <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("STOCK_SN_CREATE_ERROR");
            }

            if (insertResult > 0)
            {
                stock.StockId = insertResult;
                AppendStockLog(StockLogType.Receiving, BillType.InboundBill, billId, billNumber, stock, qty, 0);
                return stock;
            }
            else
            {
                BusinessExceptionHelper.ThrowBusinessException("STOCK_CREATE_ERROR");
            }

            return null;
        }

        /// <summary>
        /// 分割库存
        /// </summary>
        /// <param name="billType">引发库存分割单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="billNumber">单据号</param>
        /// <param name="sourceStock">原库存对象</param>
        /// <param name="splitQty">分割数量</param>
        /// <returns>成功返回分割后的库存对象，否则返回null</returns>
        public static Stock SplitStock(BillType billType, int billId, string billNumber, Stock sourceStock, int splitQty)
        {
            if (sourceStock == null) return null;
            if (splitQty <= 0) return null;
            if (splitQty >= sourceStock.Qty) return null;


            AppendStockLog(StockLogType.Splitting, billType, billId, billNumber, sourceStock, 0, splitQty);
            var newStock = (Stock)sourceStock.Clone();
            newStock.Qty = 0;
            AppendStockLog(StockLogType.Splitting, billType, billId, billNumber, newStock, splitQty, 0);

            newStock.Qty = splitQty;
            sourceStock.Qty = sourceStock.Qty - splitQty;

            var repository = new StockRepository();
            int insertResult = repository.Create(newStock);
            bool updateResult = repository.Update(sourceStock);

            if (insertResult > 0 && updateResult)
            {
                newStock.StockId = insertResult;
                
                
                return newStock;
            }

            return null;
        }

        /// <summary>
        /// 库存移动
        /// </summary>
        /// <param name="transferType">移货类型</param>
        /// <param name="billId">移货单编号</param>
        /// <param name="billNumber">移货单号</param>
        /// <param name="sourceStock">原库存对象</param>
        /// <param name="targetLocationId">移动目标库位编号</param>
        /// <param name="targetContainerId">移动目标容器编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>成功返回移动后库存对象，否则为null</returns>
        public static Stock TransferStock(TransferType transferType, int billId, string billNumber, Stock sourceStock, int targetLocationId,
                                          int targetContainerId, int userId)
        {
            Stock targetStock = GetStock(sourceStock.WarehouseId, targetLocationId, targetContainerId, sourceStock.SkuId, sourceStock.PackId,
                                         sourceStock.BatchNumber);

            var repository = new StockRepository();
            StockLogType inType = StockLogType.PutawayOut;
            StockLogType outType = StockLogType.PutawayOut;
            if (transferType == TransferType.Putaway)
            {
                inType = StockLogType.PutawayIn;
                outType = StockLogType.PutawayOut;
            }
            if (transferType == TransferType.Transfer)
            {
                inType = StockLogType.TransferIn;
                outType = StockLogType.TransferOut;
            }
            if (transferType == TransferType.Replenishment)
            {
                inType = StockLogType.ReplenishIn;
                outType = StockLogType.ReplenishOut;
            }

            if (targetStock == null)
            {
                // 目标位置无同批次货物存在,则直接更改存储位置
                AppendStockLog(outType, BillType.TransferBill, billId, billNumber, sourceStock, 0, sourceStock.Qty);

                sourceStock.LocationId = targetLocationId;
                sourceStock.ContainerId = targetContainerId;
                bool updateResult = repository.Update(sourceStock);

                targetStock = (Stock)sourceStock.Clone();
                targetStock.Qty = 0;
                AppendStockLog(inType, BillType.TransferBill, billId, billNumber, targetStock, sourceStock.Qty, 0);

                if (updateResult)
                    return sourceStock;
            }
            else
            {
                // 目标位置有同批次货物存在,则直接更改数量
                AppendStockLog(outType, BillType.TransferBill, billId, billNumber, sourceStock, 0, sourceStock.Qty);
                AppendStockLog(inType, BillType.TransferBill, billId, billNumber, targetStock, sourceStock.Qty, 0);
                targetStock.Qty = sourceStock.Qty + targetStock.Qty;
                bool updateResult = repository.Update(targetStock);
                
                if (updateResult)
                    return targetStock;
            }

            return null;
        }

        /// <summary>
        /// 销毁库存
        /// </summary>
        /// <param name="billId">出库单编号</param>
        /// <param name="billNumber">出库单号</param>
        /// <param name="stock">原库存对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DestroyStock(int billId, string billNumber, Stock stock)
        {
            if (stock == null) return false;

            AppendStockLog(StockLogType.Issuing, BillType.OutboundBill, billId, billNumber, stock, 0, stock.Qty);
            var repository = new StockRepository();
            return repository.Delete(stock.StockId);
        }

        /// <summary>
        /// 记录库存变更日志
        /// </summary>
        /// <param name="logType">库存日志类型</param>
        /// <param name="billType">引发变更单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="billNumber">单据号</param>
        /// <param name="stock">原库存</param>
        /// <param name="inboundQty">增加数量</param>
        /// <param name="outboundQty">减少数量</param>
        public static void AppendStockLog(StockLogType logType, BillType billType, int billId, string billNumber, Stock stock,
                                          int inboundQty, int outboundQty)
        {

            int originalQty = 0;
            if (!(logType == StockLogType.Receiving))
                originalQty = stock.Qty;
            int afterQty = originalQty + inboundQty - outboundQty;

            string batchNumber = stock.BatchNumber;
            string inboundBillNumber = string.Empty;
            if (batchNumber != string.Empty)
            {
                InboundBatch batch = InboundBatchManager.GetInboundBatch(stock.WarehouseId, batchNumber);
                if (batch != null)
                    inboundBillNumber = batch.BillNumber;
            }


            var log = new StockLog
                          {
                              BeforeQty = originalQty,
                              InboundQty = inboundQty,
                              OutboundQty = outboundQty,
                              AfterQty = afterQty,
                              BatchNumber = stock.BatchNumber,
                              ContainerId = stock.ContainerId,
                              LinkBillId = billId,
                              LinkBillNumber = billNumber,
                              LinkBillType = DictionaryManager.GetDictionaryIdByCode((int)billType),
                              LocationId = stock.LocationId,
                              LogTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                              LogType = DictionaryManager.GetDictionaryIdByCode((int)logType),
                              WarehouseId = stock.WarehouseId,
                              SkuId = stock.SkuId,
                              PackId = stock.PackId,
                              InboundBillNumber = inboundBillNumber
                          };


            var repository = new StockLogRepository();
            repository.Create(log);
        }

        /// <summary>
        /// 获取库存对象
        /// </summary>
        /// <param name="stockId">库存对象编号</param>
        /// <returns>成功返回库存对象，否则返回null</returns>
        public static Stock GetStock(int stockId)
        {
            var repository = new StockRepository();
            return repository.Get(stockId);
        }

        /// <summary>
        /// 获取库存对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="locationId">库位编号</param>
        /// <param name="containerId">容器编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="batchNumber">入库批次</param>
        /// <returns>成功返回库存对象，否则返回null</returns>
        public static Stock GetStock(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
            query.Criteria.Add(new Criterion("ContainerId", CriteriaOperator.Equal, containerId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
            query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));
            StockRepository repository = new StockRepository();
            return repository.GetByQuery(query);
        }

        ///// <summary>
        ///// 获取库存对象
        ///// </summary>
        ///// <param name="warehouseId">仓库编号</param>
        ///// <param name="locationId">库位编号</param>
        ///// <param name="containerId">容器编号</param>
        ///// <param name="skuId">货物编号</param>
        ///// <param name="packId">包装编号</param>
        ///// <param name="batchNumber">入库批次</param>
        ///// <param name="inboundBillNumber">入库单号</param>
        ///// <returns>成功返回库存对象，否则返回null</returns>
        //public static Stock GetStockByInboundBill(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber, string inboundBillNumber)
        //{
        //    var query = new Query();
        //    query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
        //    query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, inboundBillNumber));
        //    query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
        //    query.Criteria.Add(new Criterion("ContainerId", CriteriaOperator.Equal, containerId));
        //    query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
        //    query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
        //    query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));
        //    StockRepository repository = new StockRepository();
        //    return repository.GetByQuery(query);
        //}

        public static IList<StockView> GetStocks(int warehouseId, AreaType areaType, int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("AreaType", CriteriaOperator.Equal, DictionaryManager.GetDictionaryIdByCode((int)areaType)));

            query.OrderClauses.Add(new OrderClause("BatchNumber", OrderClause.OrderClauseCriteria.Ascending));

            StockViewRepository repository = new StockViewRepository();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }


        /// <summary>
        /// 获取库存对象列表
        /// </summary>
        /// <param name="locationId">库位编号</param>
        /// <returns>成功返回库存对象列表，否则返回空列表</returns>
        public static IList<Stock> GetStocks(int locationId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
            StockRepository repository = new StockRepository();
            return repository.GetListByQuery(query);
        }

        /// <summary>
        /// 为出库计划分配拣货库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">出库计划编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="batchNumber">入库批次</param>
        /// <param name="qty">拣选数量</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool AssignStock(int warehouseId, int planId, int skuId, int packId, string batchNumber, int qty)
        {
            lock (Locker)
            {
                OutboundPlan outboundPlan = BillManager.GetOutboundPlan(planId);
                if (outboundPlan == null)
                {
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_NOTFOUND");
                    return false;
                }

                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
                query.Criteria.Add(new Criterion("AreaType", CriteriaOperator.Equal, (int)AreaType.Picking));
                if (batchNumber != string.Empty)
                    query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

                // set stock order by property
                List<BatchProperty> batchProperties = SkuManager.GetBatchProperty(skuId);
                bool hasExpiringDate = false;
                bool hasProductionDate = false;
                foreach (var property in batchProperties)
                {
                    if (property.PropertyCode.ToUpper() == "EXPIRINGDATE")
                        hasExpiringDate = true;
                    if (property.PropertyCode.ToUpper() == "PRODUCTIONDATE")
                        hasProductionDate = true;
                }

                if (hasExpiringDate)
                    query.OrderClauses.Add(new OrderClause("ExpiringDate", OrderClause.OrderClauseCriteria.Ascending));
                else
                    if (hasProductionDate)
                        query.OrderClauses.Add(new OrderClause("ProductionDate", OrderClause.OrderClauseCriteria.Ascending));
                    else
                        query.OrderClauses.Add(new OrderClause("InboundDate", OrderClause.OrderClauseCriteria.Ascending));

                var repository = new StockRepository();
                List<Stock> stocks = CollectionHelper.ToList<Stock>(repository.GetListByQuery(query));
                int pickingQty = qty;
                foreach (var stock in stocks)
                {
                    // int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber
                    int lockedQty = LockManager.GetLockedQty(warehouseId, stock.LocationId, stock.ContainerId, skuId, packId, batchNumber);
                    int availableQty = stock.Qty - lockedQty;
                    // 此库存可用数量为0或为负数则跳过此库存条目
                    if (availableQty <= 0) continue;

                    if (availableQty >= pickingQty)
                    {
                        // 此库存可用数量足够分配
                        Lock @lock = new Lock
                        {
                            ContainerId = stock.ContainerId,
                            CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                            CreateUser = 0,
                            LocationId = stock.LocationId,
                            LockMode = (int)LockMode.Automatic,
                            LockObject = stock.StockId,
                            LockReason = (int)LockReason.Pick,
                            LockTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                            LockType = (int)LockType.Inventory,
                            Operator = 0,
                            PackId = stock.PackId,
                            Qty = pickingQty,
                            Remark = outboundPlan.PlanNumber,
                            SkuId = stock.SkuId,
                            WarehouseId = warehouseId
                        };
                        LockManager.CreateLock(@lock);

                        pickingQty = 0;
                        break;
                    }
                    else
                    {
                        // 此库存可用数量不足分配
                        Lock @lock = new Lock
                        {
                            ContainerId = stock.ContainerId,
                            CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                            CreateUser = 0,
                            LocationId = stock.LocationId,
                            LockMode = (int)LockMode.Automatic,
                            LockObject = stock.StockId,
                            LockReason = (int)LockReason.Pick,
                            LockTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                            LockType = (int)LockType.Inventory,
                            Operator = 0,
                            PackId = stock.PackId,
                            Qty = availableQty,
                            Remark = outboundPlan.PlanNumber,
                            SkuId = stock.SkuId,
                            WarehouseId = warehouseId
                        };
                        LockManager.CreateLock(@lock);

                        pickingQty = pickingQty - availableQty;
                        continue;
                    }
                }

                if (pickingQty > 0)
                {
                    BusinessExceptionHelper.ThrowBusinessException("STOCK_LESS_ASSIGN");
                    return false;
                }

                return true;
            }
        }

        #endregion stock

        #region serialnumber stock

        /// <summary>
        /// 创建库存序列号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="sn">序列号</param>
        /// <returns>成功返回库存序列号对象，否则返回null</returns>
        public static StockSn CreateStockSn(int warehouseId, int skuId, int packId, string sn)
        {
            var stockSn = new StockSn
                              {
                                  PackId = packId,
                                  SkuId = skuId,
                                  Sn = sn,
                                  WarehouseId = warehouseId
                              };
            var repository = new StockSnRepository();
            stockSn.Id = repository.Create(stockSn);
            if (stockSn.Id > 0)
                return stockSn;

            return null;
        }

        /// <summary>
        /// 删除库存序列号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="sn">序列号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DeleteStockSn(int warehouseId, int skuId, int packId, string sn)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var repository = new StockSnRepository();
            StockSn stockSn = repository.GetByQuery(query);
            if (stockSn != null)
                return repository.Delete(stockSn.Id);

            return false;
        }

        #endregion serialnumber stock
    }
}