using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using Business.Common;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Application;
using Business.DataAccess.Repository.Inventory;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Inventory;
using Business.Domain.Wms;
using Business.Domain.Report;
using Business.Service.Contract;
using Framework.Core.Collections;
using Business.Component;
using Business.Domain.Inventory.Views;
using Framework.Core.Logger;

namespace Business.Service
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class InboundService : IInboundService
    {
        #region inbound plan
        public InboundPlan GetInboundPlan(int planId)
        {
            try
            {
                var repository = new InboundPlanRepository();
                return repository.Get(planId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<InboundPlan> GetInboundPlanByQuery(Query query)
        {
            try
            {
                var repository = new InboundPlanRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundPlan>();
        }

        public List<InboundPlan> GetInboundPlanByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new InboundPlanRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundPlan>();
        }

        public InboundPlan GetInboundPlanByNumber(string warehouseCode, string planNumber)
        {
            try
            {
                var repository = new InboundPlanRepository();
                return repository.GetByBillNumber(warehouseCode, planNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetInboundPlanNewNumber(int warehouseId)
        {
            try
            {
                return BillManager.GetNewBillNumber(warehouseId, BillType.InboundPlan);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public InboundPlan CreateInboundPlan(InboundPlan inboundPlan)
        {
            var planRepository = new InboundPlanRepository();
            var dictionaryRepository = new DataDictionaryRepository();
            try
            {
                inboundPlan.PlanNumber = BillManager.GetNewBillNumber(inboundPlan.WarehouseId, BillType.InboundPlan);
                inboundPlan.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                inboundPlan.EditTime = string.Empty;
                inboundPlan.AuditTime = string.Empty;

                DataDictionary dictionary =  dictionaryRepository.GetByCode(ApplicationInformation.ApplicationCode, ((int)InboundPlanStatus.Created).ToString());
                if (dictionary != null)
                    inboundPlan.BillStatus = dictionary.DictionaryId;
                int planId = planRepository.Create(inboundPlan);
                if (planId <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_CREATE_ERROR");

                inboundPlan.PlanId = planId;
                return inboundPlan;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdateInboundPlan(InboundPlan inboundPlan)
        {

            var planRepository = new InboundPlanRepository();
            try
            {
                inboundPlan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                // if current status is created, set status modified
                if (DictionaryManager.IsEuqalDictionary(inboundPlan.BillStatus, (int)InboundPlanStatus.Created))
                    inboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Modified);

                bool updateResult = planRepository.Update(inboundPlan);
                if (!updateResult)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_UPDATE_ERROR");

                return true;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ConfirmInboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                return BillManager.Confirm(warehouseId, BillType.InboundPlan, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool CloseInboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                return BillManager.CloseInboundPlan(warehouseId, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RevokeInboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                return BillManager.Revoke(warehouseId, BillType.InboundPlan, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public int AddInboundPlanDetail(int inboundPlanId, InboundPlanDetail planDetail)
        {
            var planDetailRepository = new InboundPlanDetailRepository();
            try
            {
                planDetail.PlanId = inboundPlanId;
                return  planDetailRepository.Create(planDetail);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateInboundPlanDetail(InboundPlanDetail planDetail)
        {
            var planDetailRepository = new InboundPlanDetailRepository();
            try
            {
                return planDetailRepository.Update(planDetail);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveInboundPlanDetail(int planDetailId)
        {
            var planDetailRepository = new InboundPlanDetailRepository();
            try
            {
                return planDetailRepository.Delete(planDetailId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ImportInboundPlan(string clientCode, string message)
        {
            throw new NotImplementedException();
        }

        public List<InboundPlanDetail> GetInboundPlanDetails(int planId)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

                var repository = new InboundPlanDetailRepository();
                return CollectionHelper.ToList<InboundPlanDetail>(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundPlanDetail>();
        }

        public List<InboundPlanDetailView> GetInboundPlanDetailView(int planId)
        {
            try
            {
                var repository = new InboundPlanDetailRepository();
                return CollectionHelper.ToList<InboundPlanDetailView>(repository.GetViewByPlan(planId));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundPlanDetailView>();
        }

        public List<InboundBill> GetInboundBillsByPlan(int planDetailId)
        {
            throw new NotImplementedException();
        }

        public List<SerialNumber> GetSerialNumbersByPlan(int planDetailId)
        {
            throw new NotImplementedException();
        }

        public List<SerialNumber> CreateSerialNumber(int warehouseId, int planId, int skuId, int packId, int qty,
                                                            int userId)
        {
            return SerialNumberManager.CreateSerialNumber(warehouseId, planId, skuId, packId, qty, userId);
        }

        public InboundPlanReportEntity GetInboundPlanReport(int planId, int operatorId)
        {
            try
            {
                InboundPlan plan = GetInboundPlan(planId);
                if (plan == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

                Company owner = CompanyManager.GetCompany(plan.MerchantId);
                if (owner == null)
                    BusinessExceptionHelper.ThrowBusinessException("COMPANY_NOTFOUND");

                InboundPlanReportEntity reportEntity = new InboundPlanReportEntity();

                reportEntity.BillNumber = plan.LinkBillNumber;
                reportEntity.BillType = string.Format("{0} - {1}", "入库计划", DictionaryManager.GetDictionaryValueById(plan.InboundType));
                reportEntity.ContactInformation = string.Format("{0} {1} {2}", owner.Contactor, owner.Phone, owner.FaxNumber);
                reportEntity.Details = new List<InboundPlanDetailReportEntity>();
                reportEntity.LogisticsCompanyName = "";
                reportEntity.OwnerName = owner.CompanyName;
                reportEntity.PrintOperator = ApplicationManager.GetUserName(operatorId);
                reportEntity.PrintTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                reportEntity.Remark = plan.Remark;
                reportEntity.WarehouseName = WarehouseManager.GetWarehouseName(plan.WarehouseId);

                // details;
                List<InboundPlanDetailView> billDetails = GetInboundPlanDetailView(planId);
                foreach (InboundPlanDetailView billDetail in billDetails)
                {
                    InboundPlanDetailReportEntity detailEntity = new InboundPlanDetailReportEntity();
                    Sku Sku = SkuManager.GetSku(billDetail.SkuId);
                    if (Sku == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");
                    SkuManagement skuManagement = SkuManager.GetSkuManagementMode(billDetail.SkuId);
                    string otherInformation = string.Empty;
                    if (skuManagement.IsBigItem)
                        otherInformation = "大货";
                    if (skuManagement.IsHeavyItem)
                        otherInformation = otherInformation = " 重货";
                    if (skuManagement.PieceManagement)
                        otherInformation = otherInformation = " 单品";

                    detailEntity.ModelSpec = string.Format("{0} / {1}", Sku.Model, Sku.Specification);
                    detailEntity.OtherInformation = otherInformation;
                    detailEntity.Qty = string.Format("{0} / {1}", billDetail.ReceivedQty, billDetail.Qty);
                    detailEntity.SkuName = billDetail.SkuName;
                    detailEntity.SkuNumber = billDetail.SkuNumber;

                    reportEntity.Details.Add(detailEntity);
                }

                return reportEntity;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetNewBatchNumber(string warehouseCode)
        {
            try
            {
                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.GetByCode(warehouseCode);
                if (warehouse == null)
                    BusinessExceptionHelper.ThrowBusinessException("WAREHOUSE_NOTFOUND");

                return BillManager.GetNewBatchNumber(warehouse.WarehouseId);

            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return string.Empty;
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

        public string UploadReceivingPreparation(ReceivingPreparation receivingPreparation)
        {
            if (receivingPreparation == null)
                return string.Empty;

            InboundPlanDetailRepository repository = new InboundPlanDetailRepository();
            try
            {
                repository.BeginTransaction();

                InboundTask task = new InboundTask();
                task.ArrivalTime = receivingPreparation.ArrivalTime;
                task.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundTaskStatus.Created);
                task.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                task.CreateUser = receivingPreparation.Operator;
                task.DeliveryMan = receivingPreparation.DeliveryMan;
                task.Operator = receivingPreparation.Operator;
                task.PlanId = receivingPreparation.PlanId;
                task.Remark = "";
                task.TaskNumber = BillManager.GetNewBillNumber(receivingPreparation.WarehouseId, BillType.InboundBill);
                task.Vehicle = receivingPreparation.Vehicle;
                task.WarehouseId = receivingPreparation.WarehouseId;

                InboundTaskRepository taskRepository = new InboundTaskRepository();
                InboundTaskDetailRepository taskDetailRepository = new InboundTaskDetailRepository();
                InboundBatchRepository batchRepository = new InboundBatchRepository();
                int newId = taskRepository.Create(task);

                foreach (var detail in receivingPreparation.Details)
                {
                    InboundTaskDetail taskDetail = new InboundTaskDetail();
                    taskDetail.IsBatchManagement = detail.IsBatchManagement;
                    taskDetail.PackId = detail.PackId;
                    taskDetail.Qty = detail.ReceivingQty;
                    taskDetail.SkuId = detail.SkuId;
                    taskDetail.TaskId = newId;

                    taskDetailRepository.Create(taskDetail);

                    if (detail.IsBatchManagement)
                    {
                        foreach (var batch in detail.Batchs)
                        {
                            InboundBatch inboundBatch = new InboundBatch();
                            inboundBatch.BatchNumber = batch.BatchNumber;
                            inboundBatch.BillNumber = task.TaskNumber;
                            inboundBatch.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                            inboundBatch.CreateUser = receivingPreparation.Operator;
                            inboundBatch.ExpiringDate = batch.ExpiringDate;
                            inboundBatch.InboundDate = batch.InboundDate;
                            inboundBatch.ManufacturingOrigin = batch.ManufacturingOrigin;
                            inboundBatch.PlanNumber = batch.PlanNumber;
                            inboundBatch.ProductionBatch = batch.ProductionBatch;
                            inboundBatch.ProductionDate = batch.ProductionDate;
                            inboundBatch.PropertyValue1 = batch.PropertyValue1;
                            inboundBatch.PropertyValue2 = batch.PropertyValue2;
                            inboundBatch.PropertyValue3 = batch.PropertyValue3;
                            inboundBatch.PropertyValue4 = batch.PropertyValue4;
                            inboundBatch.PropertyValue5 = batch.PropertyValue5;
                            inboundBatch.PropertyValue6 = batch.PropertyValue6;
                            inboundBatch.Qty = batch.Qty;
                            inboundBatch.SkuId = batch.SkuId;
                            inboundBatch.WarehouseId = receivingPreparation.WarehouseId;

                            batchRepository.Create(inboundBatch);
                        }
                    }
                }
                
                repository.CommitTransaction();

                return task.TaskNumber;
            }
            catch (Exception ex)
            {
                repository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return string.Empty;
        }

        public List<InboundTask> GetInboundTaskByPlan(int planId)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));
                int status = DictionaryManager.GetDictionaryIdByCode((int)InboundTaskStatus.Created);
                query.Criteria.Add(new Criterion("BillStatus", CriteriaOperator.Equal, status));
                InboundTaskRepository repository = new InboundTaskRepository();
                return CollectionHelper.ToList<InboundTask>(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundTask>();
        }

        public List<InboundTaskDetailView> GetInboundTaskDetail(int taskId)
        {
            try
            {
                Query query = new Query();
                query.Criteria.Add(new Criterion("TaskId", CriteriaOperator.Equal, taskId));
                InboundTaskDetailRepository repository = new InboundTaskDetailRepository();
                IList<InboundTaskDetail> details = repository.GetListByQuery(query);

                InboundTaskRepository taskRepository = new InboundTaskRepository();
                InboundTask task = taskRepository.Get(taskId);
                if (task == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDTASK_NOTFOUND");

                List<InboundTaskDetailView> resultList = new List<InboundTaskDetailView>();
                foreach (var detail in details)
                {
                    InboundTaskDetailView view = new InboundTaskDetailView();

                    view.IsBatchManagement = detail.IsBatchManagement;
                    view.PackId = detail.PackId;
                    view.SkuId = detail.SkuId;
                    view.TaskId = detail.TaskId;
                    view.Qty = detail.Qty;

                    Sku sku = SkuManager.GetSku(detail.SkuId);
                    if (sku == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKU_NOTFOUND");
                    view.Barcode = sku.Barcode;
                    view.UPC = sku.Upc;
                    view.SkuName = sku.SkuName;
                    view.SkuNumber = sku.SkuNumber;

                    Pack pack = SkuManager.GetPack(detail.PackId);
                    if (pack == null)
                        BusinessExceptionHelper.ThrowBusinessException("PACK_NOTFOUND");
                    view.PackName = pack.PackName;

                    SkuManagement skuManagement = SkuManager.GetSkuManagementMode(detail.SkuId);
                    if (skuManagement == null)
                        BusinessExceptionHelper.ThrowBusinessException("SKUMANAGEMENT_NOTFOUND");

                    view.IsBarcodeManagement = skuManagement.BarcodeManagement;
                    view.IsContainerManagement = skuManagement.ContainerManagement;
                    view.IsPieceManagement = skuManagement.PieceManagement;

                    InboundBatchRepository batchRepository = new InboundBatchRepository();
                    Query batchQuery = new Query();
                    batchQuery.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, task.WarehouseId));
                    batchQuery.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, detail.SkuId));
                    batchQuery.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, task.TaskNumber));
                    List<InboundBatch> batchs = CollectionHelper.ToList<InboundBatch>(batchRepository.GetListByQuery(batchQuery));

                    view.Batchs = batchs;
                    resultList.Add(view);
                }

                return resultList;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundTaskDetailView>();
        }
        #endregion

        #region inbound bill
        public InboundBill GetInboundBill(int billId)
        {
            try
            {
                var repository = new InboundBillRepository();
                return repository.Get(billId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<InboundBill> GetInboundBillByQuery(Query query)
        {
            try
            {
                var repository = new InboundBillRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundBill>();
        }

        public List<InboundBill> GetInboundBillByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new InboundBillRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundBill>();
        }

        public InboundBill GetInboundBillByNumber(string warehouseCode, string billNumber)
        {
            try
            {
                var repository = new InboundBillRepository();
                return repository.GetByBillNumber(warehouseCode, billNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetInboundBillNewNumber(int warehouseId)
        {
            try
            {
                return BillManager.GetNewBillNumber(warehouseId, BillType.InboundBill);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public InboundBill CreateInboundBill(InboundBill inboundBill)
        {
            var billRepository = new InboundBillRepository();
            var dictionaryRepository = new DataDictionaryRepository();
            try
            {
                inboundBill.BillNumber = BillManager.GetNewBillNumber(inboundBill.WarehouseId, BillType.InboundBill);
                inboundBill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                inboundBill.EditTime = string.Empty;
                inboundBill.AuditTime = string.Empty;

                DataDictionary dictionary = dictionaryRepository.GetByCode(ApplicationInformation.ApplicationCode, ((int)InboundBillStatus.Created).ToString());
                if (dictionary != null)
                    inboundBill.BillStatus = dictionary.DictionaryId;
                int billId = billRepository.Create(inboundBill);
                if (billId <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_CREATE_ERROR");

                inboundBill.BillId = billId;
                return inboundBill;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdateInboundBill(InboundBill inboundBill)
        {

            var billRepository = new InboundBillRepository();
            try
            {
                inboundBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                // if current status is created, set status modified
                if (DictionaryManager.IsEuqalDictionary(inboundBill.BillStatus, (int)InboundBillStatus.Created))
                    inboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundBillStatus.Modified);

                bool updateResult = billRepository.Update(inboundBill);
                if (!updateResult)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_UPDATE_ERROR");

                return true;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ConfirmInboundBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Confirm(warehouseId, BillType.InboundBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RevokeInboundBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Revoke(warehouseId, BillType.InboundBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public int AddInboundBillDetail(int inboundBillId, InboundBillDetail billDetail)
        {
            var billDetailRepository = new InboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                InboundBill bill = GetInboundBill(inboundBillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                billDetail.BillId = inboundBillId;
                int newID = billDetailRepository.Create(billDetail);

                foreach (string sn in billDetail.SerialNumbers)
                {
                    //Framework.Core.Logger.LogHelper.WriteDebugLog("SN: " + sn);
                    SerialNumberManager.CreateBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber, sn);
                }

                billDetailRepository.CommitTransaction();
                return newID;
            }
            catch (Exception ex)
            {
                billDetailRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateInboundBillDetail(InboundBillDetail billDetail)
        {
            var billDetailRepository = new InboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                InboundBill bill = GetInboundBill(billDetail.BillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                bool result = billDetailRepository.Update(billDetail);

                // delete bill sn
                List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber);
                foreach (var billSn in sns)
                    SerialNumberManager.DeleteBillSn(billSn);

                // create bill sn
                foreach (var sn in billDetail.SerialNumbers)
                {
                    SerialNumberManager.CreateBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber, sn);
                }

                billDetailRepository.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                billDetailRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RemoveInboundBillDetail(int billDetailId)
        {
            var billDetailRepository = new InboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                InboundBillDetail billDetail = billDetailRepository.Get(billDetailId);
                if (billDetail == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILLDETAIL_NOTFOUND");

                InboundBill bill = GetInboundBill(billDetail.BillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                // delete bill sn
                List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber);
                foreach (var billSn in sns)
                    SerialNumberManager.DeleteBillSn(billSn);

                bool result = billDetailRepository.Delete(billDetailId);
                billDetailRepository.CommitTransaction();
                return result;
            }
            catch (Exception ex)
            {
                billDetailRepository.RollBackTransaction();
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ImportInboundBill(string clientCode, string message)
        {
            throw new NotImplementedException();
        }

        public List<InboundBillDetail> GetInboundBillDetails(int billId)
        {
            try
            {
                InboundBill bill = GetInboundBill(billId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                var query = new Query();
                query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

                var repository = new InboundBillDetailRepository();
                List<InboundBillDetail> list =  CollectionHelper.ToList<InboundBillDetail>(repository.GetListByQuery(query));

                foreach (var detail in list)
                {
                    List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, detail.SkuId, detail.PackId, detail.BatchNumber);
                    List<string> SNList = new List<string>();
                    foreach (var item in sns)
                        SNList.Add(item.Sn);
                    detail.SerialNumbers = SNList;
                }

                return list;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundBillDetail>();
        }

        public List<InboundBillDetailView> GetInboundBillDetailView(int billId)
        {
            try
            {
                InboundBill bill = GetInboundBill(billId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                var repository = new InboundBillDetailRepository();
                List<InboundBillDetailView> list = CollectionHelper.ToList<InboundBillDetailView>(repository.GetViewByBill(billId));

                foreach (var detail in list)
                {
                    List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.InboundBill, bill.BillId, detail.SkuId, detail.PackId, detail.BatchNumber);
                    List<string> SNList = new List<string>();
                    foreach (var item in sns)
                        SNList.Add(item.Sn);
                    detail.SerialNumbers = SNList;
                }

                return list;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<InboundBillDetailView>();
        }

        //public List<InboundBill> GetInboundBillsByPlan(int billDetailId)
        //{
        //    throw new NotImplementedException();
        //}

        public List<BillSn> GetSerialNumbersByBill(int billId)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));
                var repository = new BillSnRepository();
                return CollectionHelper.ToList<BillSn>(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }
            return new List<BillSn>();
        }

        //public BillSn AddBillSN(int warehouseId, BillType billType, int billId, int skuId, int packId, string batchNumber, string sn)
        //{
        //     SerialNumberManager snmanager = new SerialNumberManager();
        //     return snmanager.CreateBillSn(warehouseId, billType, billId, skuId, packId, batchNumber, sn);
        //}

        //public bool RemoveBillSN(int billsnId)
        //{
        //    var billSnRepository = new BillSnRepository();
        //    try
        //    {
        //        return billSnRepository.Delete(billsnId);
        //    }
        //    catch (Exception ex)
        //    {
        //        ServiceExceptionHelper.ThrowServiceException(ex);
        //    }

        //    return false;
        //}
        #endregion

        #region inbound batch

        public InboundBatch CreateInboundBatch(InboundBatch inboundBatch)
        {
            var repository = new InboundBatchRepository();
            try
            {
                int newId = repository.Create(inboundBatch);
                if (newId > 0)
                    return repository.Get(newId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion

        #region serial number
        public SerialNumber GetSerialNumber(int planId, int skuId, int packId, string sn)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                query.Criteria.Add(new Criterion("packId", CriteriaOperator.Equal, packId));
                query.Criteria.Add(new Criterion("Sn", CriteriaOperator.Equal, sn));

                var repository = new SerialNumberRepository();
                return repository.GetByQuery(query);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public BillSn GetBillSn(int skuId, int packId, string sn)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                query.Criteria.Add(new Criterion("packId", CriteriaOperator.Equal, packId));
                query.Criteria.Add(new Criterion("Sn", CriteriaOperator.Equal, sn));

                var repository = new BillSnRepository();
                return repository.GetByQuery(query);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }
        #endregion
    }
}
