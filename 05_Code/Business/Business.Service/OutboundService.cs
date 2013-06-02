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
    public class OutboundService : IOutboundService
    {
        #region outbound plan
        public OutboundPlan GetOutboundPlan(int planId)
        {
            try
            {
                var repository = new OutboundPlanRepository();
                return repository.Get(planId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<OutboundPlan> GetOutboundPlanByQuery(Query query)
        {
            try
            {
                var repository = new OutboundPlanRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundPlan>();
        }

        public List<OutboundPlan> GetOutboundPlanByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new OutboundPlanRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundPlan>();
        }

        public OutboundPlan GetOutboundPlanByNumber(string warehouseCode, string planNumber)
        {
            try
            {
                var repository = new OutboundPlanRepository();
                return repository.GetByBillNumber(warehouseCode, planNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetOutboundPlanNewNumber(int warehouseId)
        {
            try
            {
                return BillManager.GetNewBillNumber(warehouseId, BillType.OutboundPlan);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public OutboundPlan CreateOutboundPlan(OutboundPlan outboundPlan)
        {
            var planRepository = new OutboundPlanRepository();
            var dictionaryRepository = new DataDictionaryRepository();
            try
            {
                outboundPlan.PlanNumber = BillManager.GetNewBillNumber(outboundPlan.WarehouseId, BillType.OutboundPlan);
                outboundPlan.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                outboundPlan.EditTime = string.Empty;
                outboundPlan.AuditTime = string.Empty;
                outboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Created);

                int planId = planRepository.Create(outboundPlan);
                if (planId <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_CREATE_ERROR");

                outboundPlan.PlanId = planId;
                return outboundPlan;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdateOutboundPlan(OutboundPlan outboundPlan)
        {

            var planRepository = new OutboundPlanRepository();
            try
            {
                outboundPlan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                // if current status is created, set status modified
                if (DictionaryManager.IsEuqalDictionary(outboundPlan.BillStatus, (int)OutboundPlanStatus.Created))
                    outboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Modified);

                bool updateResult = planRepository.Update(outboundPlan);
                if (!updateResult)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_UPDATE_ERROR");

                return true;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ConfirmOutboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                return BillManager.Confirm(warehouseId, BillType.OutboundPlan, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool CloseOutboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                //return BillManager.Confirm(warehouseId, BillType.OutboundPlan, planId, userId);
                //return BillManager.CloseOutboundPlan(warehouseId, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RevokeOutboundPlan(int warehouseId, int planId, int userId)
        {
            try
            {
                return BillManager.Revoke(warehouseId, BillType.OutboundPlan, planId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public int AddOutboundPlanDetail(int OutboundPlanId, OutboundPlanDetail planDetail)
        {
            var planDetailRepository = new OutboundPlanDetailRepository();
            try
            {
                planDetail.PlanId = OutboundPlanId;
                return planDetailRepository.Create(planDetail);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return 0;
        }

        public bool UpdateOutboundPlanDetail(OutboundPlanDetail planDetail)
        {
            var planDetailRepository = new OutboundPlanDetailRepository();
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

        public bool RemoveOutboundPlanDetail(int planDetailId)
        {
            var planDetailRepository = new OutboundPlanDetailRepository();
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

        public bool ImportOutboundPlan(string clientCode, string message)
        {
            throw new NotImplementedException();
        }

        public List<OutboundPlanDetail> GetOutboundPlanDetails(int planId)
        {
            try
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

                var repository = new OutboundPlanDetailRepository();
                return CollectionHelper.ToList<OutboundPlanDetail>(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundPlanDetail>();
        }

        public List<OutboundPlanDetailView> GetOutboundPlanDetailView(int planId)
        {
            try
            {
                var repository = new OutboundPlanDetailRepository();
                List<OutboundPlanDetailView> list = CollectionHelper.ToList<OutboundPlanDetailView>(repository.GetViewByPlan(planId));

                return list;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundPlanDetailView>();
        }

        public List<OutboundBill> GetOutboundBillsByPlan(int planDetailId)
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
        #endregion

        #region outbound bill
        public OutboundBill GetOutboundBill(int billId)
        {
            try
            {
                var repository = new OutboundBillRepository();
                return repository.Get(billId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public List<OutboundBill> GetOutboundBillByQuery(Query query)
        {
            try
            {
                var repository = new OutboundBillRepository();
                return CollectionHelper.ToList(repository.GetListByQuery(query));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundBill>();
        }

        public List<OutboundBill> GetOutboundBillByPagerQuery(PagerQuery query, out int qty)
        {
            qty = 0;
            try
            {
                var repository = new OutboundBillRepository();
                return CollectionHelper.ToList(repository.GetByPager(query, out qty));
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return new List<OutboundBill>();
        }

        public OutboundBill GetOutboundBillByNumber(string warehouseCode, string billNumber)
        {
            try
            {
                var repository = new OutboundBillRepository();
                return repository.GetByBillNumber(warehouseCode, billNumber);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public string GetOutboundBillNewNumber(int warehouseId)
        {
            try
            {
                return BillManager.GetNewBillNumber(warehouseId, BillType.OutboundBill);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public OutboundBill CreateOutboundBill(OutboundBill outboundBill)
        {
            var billRepository = new OutboundBillRepository();
            var dictionaryRepository = new DataDictionaryRepository();
            try
            {
                outboundBill.BillNumber = BillManager.GetNewBillNumber(outboundBill.WarehouseId, BillType.OutboundBill);
                outboundBill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                outboundBill.EditTime = string.Empty;
                outboundBill.AuditTime = string.Empty;

                DataDictionary dictionary = dictionaryRepository.GetByCode(ApplicationInformation.ApplicationCode, ((int)OutboundBillStatus.Created).ToString());
                if (dictionary != null)
                    outboundBill.BillStatus = dictionary.DictionaryId;
                int billId = billRepository.Create(outboundBill);
                if (billId <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_CREATE_ERROR");

                outboundBill.BillId = billId;
                return outboundBill;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return null;
        }

        public bool UpdateOutboundBill(OutboundBill outboundBill)
        {

            var billRepository = new OutboundBillRepository();
            try
            {
                outboundBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                // if current status is created, set status modified
                if (DictionaryManager.IsEuqalDictionary(outboundBill.BillStatus, (int)OutboundBillStatus.Created))
                    outboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Modified);

                bool updateResult = billRepository.Update(outboundBill);
                if (!updateResult)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_UPDATE_ERROR");

                return true;
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool ConfirmOutboundBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Confirm(warehouseId, BillType.OutboundBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public bool RevokeOutboundBill(int warehouseId, int billId, int userId)
        {
            try
            {
                return BillManager.Revoke(warehouseId, BillType.OutboundBill, billId, userId);
            }
            catch (Exception ex)
            {
                ServiceExceptionHelper.ThrowServiceException(ex);
            }

            return false;
        }

        public int AddOutboundBillDetail(int outboundBillId, OutboundBillDetail billDetail)
        {
            var billDetailRepository = new OutboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                OutboundBill bill = GetOutboundBill(outboundBillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                billDetail.BillId = outboundBillId;
                int newID = billDetailRepository.Create(billDetail);

                foreach (string sn in billDetail.SerialNumbers)
                {
                    //Framework.Core.Logger.LogHelper.WriteDebugLog("SN: " + sn);
                    SerialNumberManager.CreateBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber, sn);
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

        public bool UpdateOutboundBillDetail(OutboundBillDetail billDetail)
        {
            var billDetailRepository = new OutboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                OutboundBill bill = GetOutboundBill(billDetail.BillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                bool result = billDetailRepository.Update(billDetail);

                // delete bill sn
                List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber);
                foreach (var billSn in sns)
                    SerialNumberManager.DeleteBillSn(billSn);

                // create bill sn
                //foreach (var sn in billDetail.SerialNumbers)
                //{
                //    SerialNumberManager.CreateBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber, sn);
                //}

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

        public bool RemoveOutboundBillDetail(int billDetailId)
        {
            var billDetailRepository = new OutboundBillDetailRepository();
            billDetailRepository.BeginTransaction();
            try
            {
                OutboundBillDetail billDetail = billDetailRepository.Get(billDetailId);
                if (billDetail == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILLDETAIL_NOTFOUND");

                OutboundBill bill = GetOutboundBill(billDetail.BillId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                // delete bill sn
                List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, billDetail.SkuId, billDetail.PackId, billDetail.BatchNumber);
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

        public bool ImportOutboundBill(string clientCode, string message)
        {
            throw new NotImplementedException();
        }

        public List<OutboundBillDetail> GetOutboundBillDetails(int billId)
        {
            try
            {
                OutboundBill bill = GetOutboundBill(billId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                var query = new Query();
                query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

                var repository = new OutboundBillDetailRepository();
                List<OutboundBillDetail> list = CollectionHelper.ToList<OutboundBillDetail>(repository.GetListByQuery(query));

                foreach (var detail in list)
                {
                    List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, detail.SkuId, detail.PackId, detail.BatchNumber);
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

            return new List<OutboundBillDetail>();
        }

        public List<OutboundBillDetailView> GetOutboundBillDetailView(int billId)
        {
            try
            {
                OutboundBill bill = GetOutboundBill(billId);
                if (bill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                var repository = new OutboundBillDetailRepository();
                List<OutboundBillDetailView> list = CollectionHelper.ToList<OutboundBillDetailView>(repository.GetViewByBill(billId));

                foreach (var detail in list)
                {
                    List<BillSn> sns = SerialNumberManager.GetBillSn(bill.WarehouseId, BillType.OutboundBill, bill.BillId, detail.SkuId, detail.PackId, detail.BatchNumber);
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

            return new List<OutboundBillDetailView>();
        }

        //public List<OutboundBill> GetOutboundBillsByPlan(int billDetailId)
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
    }
}
