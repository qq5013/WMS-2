using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Service.Contract;
using System.ServiceModel.Activation;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Business.Domain.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Mobile;
using Business.DataAccess;
using Business.DataAccess.Repository;
using Business.DataAccess.Repository.Wms;
using Business.DataAccess.Repository.Application;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Inventory;
using Framework.Core.Collections;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Component;
using Business.Common.DataDictionary;
using Business.Common.Toolkit;
using Business.Domain;
using Framework.Core.Logger;
using Business.Component.Strategy;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MobileService : IMobileService
    {
        #region test
        public void CreateTestData()
        {
            //// create warehouse
            //Warehouse warehouse = new Warehouse();
            //warehouse.

        }
        #endregion

        /// <summary>
        /// 获取服务器系统时间
        /// </summary>
        /// <returns>服务器系统时间</returns>
        public string GetServerDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public string Hello(string name)
        {
            return "Hello " + name;
        }

        public Warehouse CreateWarehouse(Warehouse warehouse)
        {
            try
            {
                var repository = new WarehouseRepository();
                warehouse.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                warehouse.WarehouseId = repository.Create(warehouse);

                return warehouse;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }


        public List<Warehouse> GetAllWarehouse()
        {
            try
            {
                var repository = new WarehouseRepository();
                return CollectionHelper.ToList<Warehouse>(repository.GetAll());
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<Warehouse>();
        }

        public List<User> GetWarehouseUsers(string warehouseCode)
        {
            try
            {
                var repository = new WarehouseRepository();
                Warehouse warehouse = repository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");
                IList<User> users = repository.GetUsers(warehouse.WarehouseId);

                return CollectionHelper.ToList<User>(users);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<User>();
        }

        public User ValidateUser(string warehouseCode, string userCode, string password)
        {
            try
            {
                UserRepository userRepository = new UserRepository();
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                User user = userRepository.GetByCode(Business.Common.ApplicationInformation.ApplicationCode, userCode);
                if (user != null)
                {
                    if (user.IsActive && user.Password == password)
                    {
                        WarehouseUserRepository repository = new WarehouseUserRepository();
                        if (repository.IsWarehouseUser(warehouse.WarehouseId, user.UserId))
                            return user;
                    }
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<string> GetReceivingTasks(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                int confirmedStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Confirmed);
                int partialStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.PartialReceived);

                // get confirmed plan
                var confirmedQuery = new Query();
                confirmedQuery.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                confirmedQuery.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.Equal, confirmedStatus));

                var inboundPlanRepository = new InboundPlanRepository();
                IList<InboundPlan> confirmedPlans = inboundPlanRepository.GetListByQuery(confirmedQuery);

                // get receiving plan
                var partialQuery = new Query();
                partialQuery.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                partialQuery.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.Equal, partialStatus));
                IList<InboundPlan> partialPlans = inboundPlanRepository.GetListByQuery(partialQuery);
                
                var results = new List<string>();
                foreach (InboundPlan plan in confirmedPlans)
                    results.Add(plan.PlanNumber);

                foreach (InboundPlan plan1 in partialPlans)
                    results.Add(plan1.PlanNumber);
                LogHelper.WriteDebugLog(partialStatus.ToString());
                return results;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<string>(); 
        }

        public ReceivingTask GetReceivingTask(string billNumber)
        {
            try
            {
                int confirmedStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Confirmed);
                int partialStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.PartialReceived);

                var query = new Query();
                query.Criteria.Add(new Criterion("PlanNumber", CriteriaOperator.Equal, billNumber));

                var inboundPlanRepository = new InboundPlanRepository();
                InboundPlan plan = inboundPlanRepository.GetByQuery(query);

                if (plan.BillStatus != confirmedStatus && plan.BillStatus != partialStatus)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_CANNOT_RECEIVE");

                ReceivingTask task = new ReceivingTask();
                task.BillNumber = plan.PlanNumber;
                task.LinkBillNumber = plan.LinkBillNumber;
                task.PlanReceivingTime = plan.PlanReceiveTime;
                task.Remark = plan.Remark;

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(plan.WarehouseId);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                task.WarehouseCode = warehouse.WarehouseCode;

                query.Criteria.Clear();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, plan.PlanId));
                InboundPlanDetailRepository detailRepository = new InboundPlanDetailRepository();
                IList<InboundPlanDetailView> planDetails = detailRepository.GetViewByPlan(plan.PlanId);
                List<ReceivingTaskDetail> details = new List<ReceivingTaskDetail>();

                foreach (InboundPlanDetailView view in planDetails)
                {
                    ReceivingTaskDetail detail = new ReceivingTaskDetail();
                    detail.Barcode = SkuManager.GetSkuBarcode(view.SkuId);
                    detail.IsPieceManagement = SkuManager.IsPieceManagementSku(view.SkuId); 
                    detail.PackName = view.PackName;
                    detail.Qty = view.Qty - view.ReceivedQty;
                    detail.SkuName = view.SkuName;
                    detail.SkuNumber = view.SkuNumber;
                    detail.UPC = SkuManager.GetSkuUPC(view.SkuId);

                    details.Add(detail);
                }

                task.Details = details;
                return task;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null; 
        }

        public List<Location> GetReceivingLocation()
        {
            throw new NotImplementedException();
        }

        public BoolResultObject UploadReceivingTaskResult(ReceivingTaskResult result)
        {
            InboundBillRepository billRepository = new InboundBillRepository();

            try
            {
                billRepository.BeginTransaction();

                if (result == null)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVING_RESULT_ERROR");
                if (result.Details == null || result.Details.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVING_RESULT_DETAIL_ERROR");

                string warehouseCode = result.WarehouseCode;
                string billNumber = result.BillNumber;

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouseCode == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                InboundPlanRepository planRepository = new InboundPlanRepository();
                InboundPlanDetailRepository planDetailRepository = new InboundPlanDetailRepository();
                InboundPlan plan = planRepository.GetByBillNumber(warehouseCode, billNumber);
                if (plan == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

                IList<InboundPlanDetailView> planDetails = planDetailRepository.GetViewByPlan(plan.PlanId);
                if (planDetails.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_DETAIL_NOTFOUND");

                Location location = WarehouseManager.GetLocationByBarcode(warehouse.WarehouseId, result.LocationBarcode);
                if (location == null)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATION_NOTFOUND");


                // create inbound bill
                InboundBill bill = new InboundBill();
                bill.ArrivalTime = result.ArrivalTime;
                bill.BillNumber = BillManager.GetNewBillNumber(warehouse.WarehouseId, BillType.InboundBill);
                bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundBillStatus.Created);
                bill.ClientId = plan.ClientId;
                bill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.CreateUser = result.Operator;
                bill.DeliveryMan = result.DeliveryMan;
                bill.MerchantId = plan.MerchantId;
                bill.PlanId = plan.PlanId;
                bill.ReceiveLocationId = location.LocationId;
                bill.Receiver = result.Operator;
                bill.ReceiveTime = result.ReceiveTime;
                bill.Vehicle = result.Vehicle;
                bill.VendorId = plan.VendorId;
                bill.WarehouseId = warehouse.WarehouseId;

                InboundBillDetailRepository billDetailRepository = new InboundBillDetailRepository();
                int billId = billRepository.Create(bill);

                foreach (var detail in result.Details)
                {
                    Sku sku = SkuManager.GetSkuByNumber(plan.MerchantId, detail.SkuNumber);
                    if (sku == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");

                    InboundBillDetail billDetail = new InboundBillDetail();
                    billDetail.BatchNumber = detail.BatchNumber;
                    billDetail.BillId = billId;

                    if (detail.ContainerBarcode != string.Empty)
                    {
                        Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, detail.ContainerBarcode);
                        if (container == null)
                            BusinessExceptionHelper.ThrowBusinessException("CONTAINER_NOTFOUND");

                        billDetail.ContainerId = container.ContainerId;
                    }
                    
                    Pack pack = SkuManager.GetPackByName(sku.SkuId, detail.PackName);
                    billDetail.PackId = pack.PackId;
                    billDetail.Qty = detail.ReceivedQty;
                    billDetail.SkuId = sku.SkuId;

                    int detailId = billDetailRepository.Create(billDetail);
                }

                billRepository.CommitTransaction();

                // auto confirm inboundbill
                StockRepository stockRepository = new StockRepository();
                try
                {
                    if (SettingManager.IsAutoConfirmIB(warehouse.WarehouseId))
                    {
                        stockRepository.BeginTransaction();
                        BillManager.Confirm(warehouse.WarehouseId, BillType.InboundBill, billId, 0);
                        stockRepository.CommitTransaction();
                    }
                }
                catch (Exception ex)
                {
                    stockRepository.RollBackTransaction();
                    Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                }

                return new BoolResultObject(true);
            }
            catch (Exception ex)
            {
                billRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new BoolResultObject(false);
        }

        public List<StockView> GetStockByBarcode(string warehouseCode, string barcode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");
                LogHelper.WriteDebugLog("1");
                var query = new Query();

                Sku sku = SkuManager.GetSkuByBarcode(barcode);
                if (sku != null)
                    query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, sku.SkuId));
                else
                {
                    Location location = WarehouseManager.GetLocationByBarcode(warehouse.WarehouseId, barcode);
                    if (location != null)
                    {
                        query.Criteria.Clear();
                        query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, location.LocationId));
                    }
                    else
                    {
                        Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, barcode);
                        if (container != null)
                        {
                            query.Criteria.Clear();
                            query.Criteria.Add(new Criterion("ContainerId", CriteriaOperator.Equal, container.ContainerId));
                        }
                    }
                }
                LogHelper.WriteDebugLog("2");
                if (query.Criteria.Count > 0)
                {
                    Repository<StockView> repository = new Repository<StockView>();
                    repository.Database = DatabaseConfigName.Inventory;
                    LogHelper.WriteDebugLog("3");
                    IList<StockView> stocks = repository.GetListByQuery(query);
                    LogHelper.WriteDebugLog("R：" + stocks.Count.ToString());
                    List<StockView> list = CollectionHelper.ToList<StockView>(stocks);
                    LogHelper.WriteDebugLog("R2：" + list.Count.ToString());
                    LogHelper.WriteDebugLog("4");
                    return list;
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<StockView>();

        }

        public List<StockView> GetStockByLocation(string warehouseCode, string locationBarcode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");
                
                Location location = WarehouseManager.GetLocationByBarcode(warehouse.WarehouseId, locationBarcode);
                if (location == null)
                    BusinessExceptionHelper.ThrowBusinessException("LOCATION_NOTFOUND");

                var query = new Query();
                query.Criteria.Clear();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, location.LocationId));

                Repository<StockView> repository = new Repository<StockView>();
                repository.Database = DatabaseConfigName.Inventory;
                return CollectionHelper.ToList<StockView>(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<StockView>();
        }

        #region putaway
        public List<PutawayLocation> GetPutawayLocations(string warehouseCode, string strategyName, string barcode, int qty)
        {
            try
            {
                int skuId = 0;
                if (barcode != "")
                {
                    SkuRepository skuRepository = new SkuRepository();
                    var skuQuery = new Query();
                    skuQuery.Criteria.Add(new Criterion("Barcode", CriteriaOperator.Equal, barcode));
                    Sku Sku = skuRepository.GetByQuery(skuQuery);
                    skuId = Sku.SkuId;
                }
                 WarehouseRepository warehouseRepository = new WarehouseRepository();
                 Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                 if (warehouseCode == null)
                     BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                IPutawayStrategy strategy = PutawayStrategyFactory.GetPutawayStrategy(strategyName);
                if (strategy != null)
                {
                    return strategy.GetPutawayLocations(warehouse.WarehouseId, skuId, qty);
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<PutawayLocation>();
        }

        public List<string> GetPutawayTasks(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                int putawayStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferType.Putaway);
                int createdStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferBillStatus.Created);

                // get created Transfer
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("TransferType", CriteriaOperator.Equal, putawayStatus));
                query.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.Equal, createdStatus));

                var transferBillRepository = new TransferBillRepository();
                IList<TransferBill> taskBills = transferBillRepository.GetListByQuery(query);

                var results = new List<string>();
                foreach (TransferBill transfer in taskBills)
                {
                    results.Add(transfer.BillNumber);
                }

                return results;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<string>();
        }

        public PutawayTask GetPutawayTask(string billNumber)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

                var transferBillRepository = new TransferBillRepository();

                TransferBill transferBill = transferBillRepository.GetByQuery(query);
                if (transferBill == null)
                    BusinessExceptionHelper.ThrowBusinessException("TRANSFERBILL_NOTFOUND");

                var inboundBillRepository = new InboundBillRepository();
                InboundBill inboundBill = inboundBillRepository.Get((int)transferBill.LinkBillId);
                if (inboundBill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                var inboundBillDetailRepository = new InboundBillDetailRepository();
                IList<InboundBillDetailView> inboundBillDetails = inboundBillDetailRepository.GetViewByBill(transferBill.LinkBillId);

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(inboundBill.WarehouseId);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                PutawayTask task = new PutawayTask();
                task.BillNumber = billNumber;
                task.PlanTransferDate = transferBill.PlanTransferDate;
                task.Remark = transferBill.Remark;
                task.LinkBillNumber = inboundBill.BillNumber;
                task.WarehouseCode = warehouse.WarehouseCode;

                List<PutawayTaskDetail> details = new List<PutawayTaskDetail>();
                SkuRepository skuRepository = new SkuRepository();
                foreach (InboundBillDetailView inboundBillDetail in inboundBillDetails)
                {
                    PutawayTaskDetail detail = new PutawayTaskDetail();
                    detail.ContainerName = inboundBillDetail.ContainerName;
                    detail.ContainerBarcode = WarehouseManager.GetContainerBarcode(inboundBillDetail.ContainerId);
                    detail.PackName = inboundBillDetail.PackName;
                    detail.Qty = inboundBillDetail.Qty;
                    detail.SkuName = inboundBillDetail.SkuName;
                    detail.SkuNumber = inboundBillDetail.SkuNumber;
                    detail.BatchNumber = inboundBillDetail.BatchNumber;
                    detail.IsPieceManagement = SkuManager.IsPieceManagementSku(inboundBillDetail.SkuId);
                    detail.Barcode = SkuManager.GetSkuBarcode(inboundBillDetail.SkuId);
                    detail.UPC = SkuManager.GetSkuUPC(inboundBillDetail.SkuId);
                    
                    details.Add(detail);
                }

                task.Details = details;

                return task;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }
            return null;
        }

        public BoolResultObject UploadPutawayTaskResult(PutawayTaskResult result)
        {
            TransferBillRepository transferBillRepository = new TransferBillRepository();
            
            try
            {
                transferBillRepository.BeginTransaction();

                if (result == null)
                    BusinessExceptionHelper.ThrowBusinessException("PUTAWAY_RESULT_ERROR");

                if (result.Details == null || result.Details.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVING_RESULT_DETAIL_ERROR");

                string warehouseCode = result.WarehouseCode;
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouseCode == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                var query = new Query();
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, result.BillNumber));
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                TransferBill transferBill = transferBillRepository.GetByQuery(query);

                InboundBillRepository billRepository = new InboundBillRepository();
                InboundBill inboundBill = billRepository.Get(transferBill.LinkBillId);
                if (inboundBill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                // create tranferbill detail
                foreach (var detail in result.Details)
                {
                    TransferBillDetail billDetail = new TransferBillDetail();
                    Sku sku = SkuManager.GetSkuByNumber(inboundBill.MerchantId, detail.SkuNumber);
                    if (sku == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");

                    Pack pack = SkuManager.GetPackByName(sku.SkuId, detail.PackName);
                    if (pack != null)
                        billDetail.PackId = pack.PackId;

                    billDetail.TransferedQty = detail.TransferedQty;
                    billDetail.SkuId = sku.SkuId;
                    billDetail.BillId = transferBill.BillId;
                    billDetail.BatchNumber = detail.BatchNumber;
                    billDetail.IsTransferContainer = detail.IsTransferContainer;
                    billDetail.PlanQty = 0;

                    Location targetLocation = WarehouseManager.GetLocationByBarcode(warehouse.WarehouseId, detail.TargetLocationBarcode);
                    if (targetLocation == null)
                        BusinessExceptionHelper.ThrowBusinessException("LOCATION_NOTFOUND"); 

                    billDetail.SourceLocationId = inboundBill.ReceiveLocationId;
                    billDetail.TargetLocationId = targetLocation.LocationId;

                    int sourceContainerId = 0;
                    int targetContainerId = 0;
                    Container sourceContainer = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, detail.SourceContainerBarcode);
                    if (sourceContainer != null)
                        sourceContainerId = sourceContainer.ContainerId;

                    Container targetContainer = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, detail.TargetContainerBarcode);
                    if (targetContainer != null)
                        targetContainerId = targetContainer.ContainerId;

                    billDetail.SourceContainerId = sourceContainerId;
                    billDetail.TargetContainerId = targetContainerId;

                    Stock stock = StockManager.GetStock(warehouse.WarehouseId, billDetail.SourceLocationId, sourceContainerId, sku.SkuId, pack.PackId, detail.BatchNumber);
                    if (stock == null)
                        BusinessExceptionHelper.ThrowBusinessException("STOCK_NOTFOUND"); 
                    billDetail.StockId = stock.StockId;

                    TransferBillDetailRepository transferBillDetailRepository = new TransferBillDetailRepository();
                    int detailId = transferBillDetailRepository.Create(billDetail);
                }


                // update transfer bill status 
                transferBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferBillStatus.Transfered);
                transferBill.EditUser = result.Operator;
                transferBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                transferBill.TransferTime = result.TransferTime;
                transferBillRepository.Update(transferBill);

                transferBillRepository.CommitTransaction();

                // auto confirm transferbill
                StockRepository stockRepository = new StockRepository();
                try
                {
                    if (SettingManager.IsAutoConfirmTB(warehouse.WarehouseId))
                    {
                        stockRepository.BeginTransaction();
                        BillManager.Confirm(warehouse.WarehouseId, BillType.TransferBill, transferBill.BillId, 0);
                        stockRepository.CommitTransaction();
                    }
                }
                catch (Exception ex)
                {
                    stockRepository.RollBackTransaction();
                    Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                }

                return new BoolResultObject(true);
            }
            catch (Exception ex)
            {
                transferBillRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new BoolResultObject(false);
        }

        public int GetPutawaySkuIdTask(string SkuNumber)
        {
            try
            {
                if (SkuNumber != "")
                {
                    SkuRepository skuRepository = new SkuRepository();
                    var skuQuery = new Query();
                    skuQuery.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, SkuNumber));
                    Sku Sku = skuRepository.GetByQuery(skuQuery);
                    return Sku.SkuId;
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }
        #endregion

        #region pick
        public List<string> GetPickTasks(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                int createdStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Confirmed);

                // get created Transfer
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.Equal, createdStatus));

                var outboundPlanRepository = new OutboundPlanRepository();
                IList<OutboundPlan> taskBills = outboundPlanRepository.GetListByQuery(query);

                var results = new List<string>();
                foreach (OutboundPlan transfer in taskBills)
                {
                    results.Add(transfer.PlanNumber);
                }

                return results;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<string>();
        }

        public PickTask GetPickTask(string planNumber)
        {
            try
            {
                int confirmedStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Confirmed);
                int partialStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Created);

                var query = new Query();
                query.Criteria.Add(new Criterion("PlanNumber", CriteriaOperator.Equal, planNumber));

                var outboundPlanRepository = new OutboundPlanRepository();
                OutboundPlan plan = outboundPlanRepository.GetByQuery(query);

                if (plan.BillStatus != confirmedStatus && plan.BillStatus != partialStatus)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_CANNOT_RECEIVE");

                PickTask task = new PickTask();
                task.PlanNumber = plan.PlanNumber;
                task.PlanId = plan.PlanId;
                task.ClientId = plan.ClientId;
                task.LinkBillNumber = plan.LinkBillNumber;
                task.PlanIssueTime = plan.PlanIssueTime;
                task.Remark = plan.Remark;

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(plan.WarehouseId);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                task.WarehouseCode = warehouse.WarehouseCode;

                query.Criteria.Clear();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, plan.PlanId));
                OutboundPlanDetailRepository detailRepository = new OutboundPlanDetailRepository();
                IList<OutboundPlanDetailView> planDetails = detailRepository.GetViewByPlan(plan.PlanId);
                List<PickTaskDetail> details = new List<PickTaskDetail>();

                foreach (OutboundPlanDetailView view in planDetails)
                {
                    PickTaskDetail detail = new PickTaskDetail();
                    detail.Barcode = SkuManager.GetSkuBarcode(view.SkuId);
                    detail.IsPieceManagement = SkuManager.IsPieceManagementSku(view.SkuId);
                    detail.PackName = view.PackName;
                    detail.Qty = view.Qty - view.IssuedQty;
                    detail.SkuName = view.SkuName;
                    detail.SkuNumber = view.SkuNumber;
                    detail.UPC = SkuManager.GetSkuUPC(view.SkuId);

                    details.Add(detail);
                }

                task.Details = details;
                return task;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public Pack GetPickSkuTask(string SkuNumber)
        {
            if (SkuNumber != "")
            {
                SkuRepository skuRepository = new SkuRepository();
                var skuQuery = new Query();
                skuQuery.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, SkuNumber));
                Sku sku = skuRepository.GetByQuery(skuQuery);
                return GetPickPackTask(sku.SkuId);
            }

            return null;
        }

        public Pack GetPickPackTask(int SkuId)
        {
            if (SkuId > 0)
            {
                PackRepository packRepository = new PackRepository();
                var skuQuery = new Query();
                skuQuery.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, SkuId));
                Pack pack = packRepository.GetByQuery(skuQuery);
                return pack;
            }
            return null;
        }

        public BoolResultObject UploadPickTaskResult(PickTaskResult result)
        {
            OutboundBillRepository billRepository = new OutboundBillRepository();

            try
            {
                billRepository.BeginTransaction();

                if (result == null)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVING_RESULT_ERROR");
                if (result.Details == null || result.Details.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVING_RESULT_DETAIL_ERROR");

                string warehouseCode = result.WarehouseCode;
                string planNumber = result.PlanNumber;

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouseCode == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                OutboundPlanRepository planRepository = new OutboundPlanRepository();
                OutboundPlanDetailRepository planDetailRepository = new OutboundPlanDetailRepository();
                OutboundPlan plan = planRepository.GetByBillNumber(warehouseCode, planNumber);
                if (plan == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_NOTFOUND");

                IList<OutboundPlanDetailView> planDetails = planDetailRepository.GetViewByPlan(plan.PlanId);
                if (planDetails.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_DETAIL_NOTFOUND");


                // create inbound bill
                OutboundBill bill = new OutboundBill();
                bill.IssueTime = result.PlanIssueTime;
                bill.BillNumber = BillManager.GetNewBillNumber(warehouse.WarehouseId, BillType.OutboundBill);
                bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Created);
                bill.ClientId = plan.ClientId;
                bill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.CreateUser = result.Operator;
                bill.MerchantId = plan.MerchantId;
                bill.PlanId = plan.PlanId;
                bill.IssueTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.WarehouseId = warehouse.WarehouseId;
                bill.IssuePerson = result.Operator;

                OutboundBillDetailRepository billDetailRepository = new OutboundBillDetailRepository();
                int billId = billRepository.Create(bill);

                foreach (var detail in result.Details)
                {
                    Sku sku = SkuManager.GetSkuByNumber(plan.MerchantId, detail.SkuNumber);
                    if (sku == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");

                    OutboundBillDetail billDetail = new OutboundBillDetail();
                    billDetail.BatchNumber = detail.BatchNumber;
                    billDetail.BillId = billId;

                    if (detail.ContainerBarcode != string.Empty)
                    {
                        Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, detail.ContainerBarcode);
                        if (container == null)
                            BusinessExceptionHelper.ThrowBusinessException("CONTAINER_NOTFOUND");

                        billDetail.ContainerId = container.ContainerId;
                    }

                    Pack pack = SkuManager.GetPackByName(sku.SkuId, detail.PackName);
                    billDetail.PackId = pack.PackId;
                    billDetail.Qty = detail.ReceivedQty;
                    billDetail.SkuId = sku.SkuId;
                    billDetail.BatchNumber = detail.BatchNumber;
                    billDetail.LocationId = detail.LocationId;
                    billDetail.StockId = detail.StockId;

                    int detailId = billDetailRepository.Create(billDetail);
                }

                billRepository.CommitTransaction();

                // auto confirm outboundbill
                //StockRepository stockRepository = new StockRepository();
                //try
                //{
                //    if (SettingManager.IsAutoConfirmIB(warehouse.WarehouseId))
                //    {
                //        stockRepository.BeginTransaction();
                //        BillManager.Confirm(warehouse.WarehouseId, BillType.OutboundBill, billId, 0);
                //        stockRepository.CommitTransaction();
                //    }
                //}
                //catch (Exception ex)
                //{
                //    stockRepository.RollBackTransaction();
                //    Framework.Core.Exception.ExceptionHelper.HandleException(ex, true, false);
                //}

                return new BoolResultObject(true);
            }
            catch (Exception ex)
            {
                billRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new BoolResultObject(false);
        }

        public List<PickingStock> GetPickingStock(string warehouseCode, string strategyName, string skuNumber)
        {
            try
            {
                IPickingStrategy pickingStrategy = PickingStrategyFactory.GetPickingStrategy(strategyName);

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouseCode == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                Sku sku = SkuManager.GetSkuByNumber(skuNumber);
                if (sku == null)
                    BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");

                return pickingStrategy.GetPickingStocks(warehouse.WarehouseId, sku.SkuId, 0);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<PickingStock>();
        }

        #endregion

        #region delivery
        public List<string> GetDeliveryTasks(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                int createdStatus1 = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Cancelled);
                int createdStatus2 = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Confirmed);

                // get created Transfer
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.NotEqual, createdStatus1));
                query.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.NotEqual, createdStatus2));

                var outboundBillRepository = new OutboundBillRepository();
                IList<OutboundBill> taskBills = outboundBillRepository.GetListByQuery(query);

                var results = new List<string>();
                foreach (OutboundBill transfer in taskBills)
                {
                    results.Add(transfer.BillNumber);
                }

                return results;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<string>();
        }

        public DeliveryTask GetDeliveryTask(string billNumber)
        {
            try
            {
                int confirmedStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Confirmed);
                int partialStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Created);

                var query = new Query();
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

                var outboundBillRepository = new OutboundBillRepository();
                OutboundBill bill = outboundBillRepository.GetByQuery(query);

                //if (bill.BillStatus != confirmedStatus && bill.BillStatus != partialStatus)
                //    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_CANNOT_RECEIVE");

                DeliveryTask task = new DeliveryTask();
                task.BillNumber = bill.BillNumber;
                task.BillId = bill.PlanId;
                task.ClientId = bill.ClientId;
                task.IssueTime = bill.IssueTime;
                task.Remark = bill.Remark;

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(bill.WarehouseId);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                task.WarehouseCode = warehouse.WarehouseCode;

                query.Criteria.Clear();
                query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, bill.BillId));
                OutboundBillDetailRepository detailRepository = new OutboundBillDetailRepository();
                IList<OutboundBillDetailView> billDetails = detailRepository.GetViewByBill(bill.BillId);
                List<DeliveryTaskDetail> details = new List<DeliveryTaskDetail>();

                foreach (OutboundBillDetailView view in billDetails)
                {
                    DeliveryTaskDetail detail = new DeliveryTaskDetail();
                    detail.PackName = view.PackName;
                    detail.Qty = view.Qty;
                    detail.BatchNumber = view.BatchNumber;
                    detail.SkuName = view.SkuName;
                    detail.SkuNumber = view.SkuNumber;

                    details.Add(detail);
                }

                task.Details = details;
                return task;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public BoolResultObject UpdateDeliveryTask(OutboundBill outboundBill)
        {
            //var billRepository = new OutboundBillRepository();
            try
            {
                //outboundBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                //// if current status is created, set status modified
                //if (DictionaryManager.IsEuqalDictionary(outboundBill.BillStatus, (int)OutboundBillStatus.Created) || DictionaryManager.IsEuqalDictionary(outboundBill.BillStatus, (int)OutboundBillStatus.Modified))
                //    outboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Modified);

                //bool updateResult = billRepository.Update(outboundBill);
                //if (!updateResult)
                //    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_UPDATE_ERROR");

                bool revoke = BillManager.Confirm(outboundBill.WarehouseId, BillType.OutboundBill, outboundBill.BillId, outboundBill.CreateUser);

                return new BoolResultObject(true);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new BoolResultObject(false);
        }

        public OutboundBill GetDeliveryBill(string billNumber)
        {
            try
            {
                int confirmedStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Confirmed);
                int partialStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Created);

                var query = new Query();
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

                var outboundBillRepository = new OutboundBillRepository();
                OutboundBill outboundBill = outboundBillRepository.GetByQuery(query);

                return outboundBill;

            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region transfer
        public LocationInfo GetLocationByBarcode(string warehouseCode, string barcode)
        {

            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                Location location = WarehouseManager.GetLocationByBarcode(warehouse.WarehouseId, barcode);
                if (location != null)
                {
                    LocationInfo info = new LocationInfo();
                    info.LocationId = location.LocationId;
                    info.LocationCode = location.LocationCode;
                    info.LocationName = location.LocationName;
                    info.Barcode = location.Barcode;

                    return info;
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public ContainerInfo GetContainerByBarcode(string warehouseCode, string barcode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                Container container = WarehouseManager.GetContainerByBarcode(warehouse.WarehouseId, barcode);

                if (container != null)
                {
                    ContainerInfo info = new ContainerInfo();
                    info.ContainerId = container.ContainerId;
                    info.ContainerCode = container.ContainerCode;
                    info.ContainerName = container.ContainerName;
                    info.Barcode = container.Barcode;

                    return info;
                }
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }


            return null;
        }

        public BoolResultObject UploadTransferResult(string warehouseCode, List<TransferBillDetailView> transferResult, int operatorId)
        {
            TransferBillRepository billRespository = new TransferBillRepository();
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                TransferBill bill = new TransferBill();
                bill.BillNumber = BillManager.GetNewBillNumber(warehouse.WarehouseId, BillType.TransferBill);
                bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferBillStatus.Transfered);
                bill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.CreateUser = operatorId;
                bill.LinkBillId = 0;
                bill.LinkBillType = 0;
                bill.PlanTransferDate = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.Remark = "";
                bill.TransferTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.TransferType = DictionaryManager.GetDictionaryIdByCode((int)TransferType.Transfer);
                bill.WarehouseId = warehouse.WarehouseId;
                bill.Auditor = 0;
                bill.AuditTime = string.Empty;

                billRespository.BeginTransaction();
                int newId = billRespository.Create(bill);
                TransferBillDetailRepository billDetailRespository = new TransferBillDetailRepository();
                foreach (var resultDetail in transferResult)
                {
                    TransferBillDetail billDetail = new TransferBillDetail();
                    billDetail.BatchNumber = resultDetail.BatchNumber;
                    billDetail.BillId = newId;
                    billDetail.IsTransferContainer = resultDetail.IsTransferContainer;
                    billDetail.PackId = resultDetail.PackId;
                    billDetail.PlanQty = resultDetail.PlanQty;
                    billDetail.SkuId = resultDetail.SkuId;
                    billDetail.SourceContainerId = resultDetail.SourceContainerId;
                    billDetail.SourceLocationId = resultDetail.SourceLocationId;
                    billDetail.StockId = resultDetail.StockId;
                    billDetail.TargetContainerId = resultDetail.TargetContainerId;
                    billDetail.TargetLocationId = resultDetail.TargetLocationId;
                    billDetail.TransferedQty = resultDetail.TransferedQty;
                    billDetailRespository.Create(billDetail);
                }

                billRespository.CommitTransaction();
                return new BoolResultObject(true);
            }
            catch (Exception ex)
            {
                billRespository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new BoolResultObject(false);
        }
        #endregion
    }
}
