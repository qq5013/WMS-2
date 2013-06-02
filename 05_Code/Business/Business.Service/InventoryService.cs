using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Application;
using Business.DataAccess.Repository.Inventory;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Business.Service.Contract;
using Framework.Core.Collections;
using Business.Component;
using Business.Domain.Inventory.Views;

namespace Business.Service 
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class InventoryService : IInventoryService
    {
        public List<Stock> GetStocksByWarehouse(int warehouseId)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetStocksByLocation(int warehouseId, string locationBarcode)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetStocksByContainer(int warehouseId, string containerBarcode)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetStocksBySku(int warehouseId, string skuBarcode)
        {
            throw new NotImplementedException();
        }

        public List<Stock> GetStocksByBatch(int warehouseId, string skuBarcode, string batchNumber)
        {
            throw new NotImplementedException();
        }

        public Stock GetStock(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber)
        {
            try
            {
                return StockManager.GetStock(warehouseId, locationId, containerId, skuId, packId, batchNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        #region Stock
        public List<Stock> GetStockByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new StockRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Stock>();
        }

        public List<StockView> GetStockViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new StockViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<StockView>();
        }

        #endregion

        #region Stock Log
        public List<StockLog> GetStockLogByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new StockLogRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<StockLog>();
        }

        public List<StockLogView> GetStockLogViewByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new StockLogViewRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<StockLogView>();
        }

        #endregion

        #region counting bill
        public string CreateCountBill(int warehouseId, string areaCode, string locationCode, string inboundPlanNumber, string inboundBillNumber, string skuNumber, string batchNumber, int operatorId)
        {
            try
            {
                return BillManager.CreateCountBill(warehouseId, areaCode, locationCode, inboundPlanNumber, inboundBillNumber, skuNumber, batchNumber, operatorId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return string.Empty;
        }

        public CountBill GetCountBill(int billId)
        {
            try
            {
                CountBillRepository repository = new CountBillRepository();
                return repository.Get(billId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool ConfirmCountBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Confirm(warehouseId, BillType.CountBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RevokeCountBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Revoke(warehouseId, BillType.CountBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public List<CountBillDetailView> GetCountBillDetailView(int billId)
        {
            try
            {
                var repository = new CountBillDetailViewRepository();
                List<CountBillDetailView> list = CollectionHelper.ToList<CountBillDetailView>(repository.GetViewByBill(billId));

                return list;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CountBillDetailView>();
        }

        public List<CountBill> GetCountBillByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new CountBillRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<CountBill>();
        }

        public bool UploadCountingResult(int warehouseId, int countBillId, List<CountBillDetailView> resultList, int operatorId)
        {
            bool uploadResult = true;
            try
            {
                Warehouse warehouse = WarehouseManager.GetWarehouse(warehouseId);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                CountBill bill = BillManager.GetCountBill(countBillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_NOTFOUND");

                if (!DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.Created)
                     && !DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.FirstCounting))
                    BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_STATUS_ERROR");
                
                foreach (CountBillDetailView billDetail in resultList)
                {
                    //int billId = billDetail.BillId;

                    int stockId = billDetail.StockId;
                    string locationCode = billDetail.LocationCode;
                    string containerCode = billDetail.ContainerCode;
                    string skuNumber = billDetail.SkuNumber;
                    string packName = billDetail.PackName;
                    string batchNumber = billDetail.BatchNumber;
                    int accountQty = billDetail.AccountQty;
                    int countedQty = billDetail.CountedQty;

                    CountBillDetailRepository countBillDetailRepository = new CountBillDetailRepository();
                    string message1 = string.Format("盘点单明细未发现：{0} / {1} / {2} / {3} / {4} / {5} / {6} / {7}。", stockId, locationCode, containerCode, skuNumber, packName, batchNumber, accountQty, countedQty);
                    Framework.Core.Logger.LogHelper.WriteDebugLog("DETAIL: " + message1);
                    // find by stockId 
                    Query query;
                    CountBillDetail detail = null;
                    if (detail == null)
                    {
                        // find by other information 
                        int locationId = 0;
                        int containerId = 0;
                        int skuId = 0;
                        int packId = 0;

                        Location location = WarehouseManager.GetLocationByCode(warehouse.WarehouseCode, locationCode);
                        if (location == null)
                            BusinessExceptionHelper.ThrowBusinessException("LOCATION_NOTFOUND");
                        else
                            locationId = location.LocationId;

                        Container container = WarehouseManager.GetContainerByCode(warehouse.WarehouseCode, containerCode);
                        if (container != null)
                            containerId = container.ContainerId;

                        Sku sku = SkuManager.GetSkuByNumber(skuNumber);
                        if (sku == null)
                            BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");
                        else
                            skuId = sku.SkuId;

                        Pack pack = SkuManager.GetPackByName(sku.SkuId, packName);
                        if (pack == null)
                            BusinessExceptionHelper.ThrowBusinessException("PACK_NOTFOUND");
                        else
                            packId = pack.PackId;

                        Framework.Core.Logger.LogHelper.WriteDebugLog("1");
                        Framework.Core.Logger.LogHelper.WriteDebugLog("SKU: " + skuNumber);
                        query = new Query();
                        query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, countBillId));
                        query.Criteria.Add(new Criterion("StockId", CriteriaOperator.Equal, stockId));
                        query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
                        query.Criteria.Add(new Criterion("ContainerId", CriteriaOperator.Equal, containerId));
                        query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                        query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
                        query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));
                        Framework.Core.Logger.LogHelper.WriteDebugLog("2");
                        detail = countBillDetailRepository.GetByQuery(query);
                        Framework.Core.Logger.LogHelper.WriteDebugLog("3");
                        if (detail == null)
                        {
                            string message = string.Format("盘点单明细未发现：{0} / {1} / {2} / {3} / {4} / {5} / {6} / {7}。", stockId, locationCode, containerCode, skuNumber, packName, batchNumber, accountQty, countedQty);
                            BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_DETAIL_UPLOAD_ERROR", message);
                        }
                        else
                        {
                            // update counting result
                            detail.CountedQty = countedQty;
                            detail.Operator = operatorId;
                            bool updateResult = countBillDetailRepository.Update(detail);
                            if (!updateResult)
                            {
                                uploadResult = false;
                                string message = string.Format("盘点单明细：{0} / {1} / {2} / {3} / {4} / {5} / {6} / {7} 上传失败。", stockId, locationCode, containerCode, skuNumber, packName, batchNumber, accountQty, countedQty);
                                BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_DETAIL_UPLOAD_ERROR", message);
                            }
                        }
                        Framework.Core.Logger.LogHelper.WriteDebugLog("4");
                    }
                }

                // update count bill status
                if (uploadResult)
                {
                    if (DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.Created))
                        bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)CountBillStatus.FirstCounting);
                    else
                        if (DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.FirstCounting))
                            bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)CountBillStatus.SecondCounting);

                    CountBillRepository billRepository = new CountBillRepository();
                    bill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                    bill.EditUser = operatorId;
                    billRepository.Update(bill);
                }
                Framework.Core.Logger.LogHelper.WriteDebugLog("5");
            }
            catch (Exception ex)
            {
                Framework.Core.Logger.LogHelper.WriteDebugLog(ex.ToString());
                uploadResult = false;
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return uploadResult;
        }
        #endregion
    }
}
