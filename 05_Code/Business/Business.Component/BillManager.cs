using System;
using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.DataAccess.Repository.Inventory;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Core.Logger;

namespace Business.Component
{
    /// <summary>
    /// 单据管理器
    /// </summary>
    public class BillManager
    {
        /// <summary>
        /// 并发锁定对象
        /// </summary>
        private static readonly object Locker = new object();

        #region bill number
        /// <summary>
        /// 获取单据号前缀
        /// </summary>
        /// <param name="billType">单据类型枚举</param>
        /// <returns>单据前缀</returns>
        private static string GetBillNumberPrefix(BillType billType)
        {
            switch (billType)
            {
                case BillType.CountBill:
                    {
                        return "CB";
                    }
                case BillType.InboundBill:
                    {
                        return "IB";
                    }
                case BillType.InboundPlan:
                    {
                        return "IP";
                    }
                case BillType.OutboundBill:
                    {
                        return "OB";
                    }
                case BillType.OutboundPlan:
                    {
                        return "OP";
                    }
                case BillType.Package:
                    {
                        return "PG";
                    }
                case BillType.PickBill:
                    {
                        return "PB";
                    }
                case BillType.PutawayBill:
                    {
                        return "TB";
                    }
                case BillType.SortBill:
                    {
                        return "SB";
                    }
                case BillType.TransferBill:
                    {
                        return "TB";
                    }
                case BillType.ReplenishBill:
                    {
                        return "TB";
                    }
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取新单据号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billType">单据类型枚举</param>
        /// <returns>新单据号</returns>
        public static string GetNewBillNumber(int warehouseId, BillType billType)
        {
            string settingCode = billType.ToString().ToUpper() + "_BILLNUMBER";
            return GetNewNumber(warehouseId, settingCode, GetBillNumberPrefix(billType));
        }

        public static string GetNewBatchNumber(int warehouseId)
        {
            return GetNewNumber(warehouseId, "BATCH_BILLNUMBER", "BN");
        }

        private static string GetNewNumber(int warehouseId, string settingCode, string prefix)
        {
            lock (Locker)
            {
                Setting setting = SettingManager.GetSetting(warehouseId, settingCode);

                if (setting == null)
                    setting = SettingManager.CreateSetting(warehouseId, settingCode, "String", "0", string.Empty, 0);

                string currentSn = setting.SettingValue;
                string numberStr = RadixConvertHelper.X2X(currentSn, 36, 10);
                long oldNumber = 0;
                try
                {
                    oldNumber = long.Parse(numberStr);
                }
                catch (Exception ex)
                {
                    LogHelper.WriteExceptionLog(string.Format("序号{0}转换成int类型失败。", numberStr));
                    ExceptionHelper.HandleException(ex, true, false);
                }

                long newNumber = oldNumber + 1;
                string newNumberStr = RadixConvertHelper.X2X(newNumber.ToString(), 10, 36);
                setting.SettingValue = newNumberStr;
                SettingManager.UpdateSetting(warehouseId, settingCode, setting.SettingValue, setting.Remark, 0);

                WarehouseRepository warehouseRepository = new WarehouseRepository();
                Warehouse warehouse = warehouseRepository.Get(warehouseId);
                string warehouseCode = string.Empty;
                if (warehouse != null)
                    warehouseCode = warehouse.WarehouseCode;

                return prefix + warehouseCode + ToSixDigital(newNumberStr);
            }
        }

        /// <summary>
        /// 以前缀0补全6位字符串
        /// </summary>
        /// <param name="number">字符串</param>
        /// <returns>返回6位字符串</returns>
        public static string ToSixDigital(string number)
        {
            if (number.Length < 6)
            {
                string s = "000000" + number;
                return s.Substring(s.Length - 6, 6);
            }

            return number;
        }
        #endregion

        #region confirm & revoke bill
        /// <summary>
        /// 审核单据
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billType">单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>审核成功返回true，否则返回false</returns>
        public static bool Confirm(int warehouseId, BillType billType, int billId, int userId)
        {
            switch (billType)
            {
                case BillType.CountBill:
                    {
                        return ConfirmCountBill(warehouseId, billId, userId);
                    }
                case BillType.InboundBill:
                    {
                        return ConfirmInboundBill(warehouseId, billId, userId);
                    }
                case BillType.InboundPlan:
                    {
                        return ConfirmInboundPlan(warehouseId, billId, userId);
                    }
                case BillType.OutboundBill:
                    {
                        return ConfirmOutboundBill(warehouseId, billId, userId);
                    }
                case BillType.OutboundPlan:
                    {
                        return ConfirmOutboundPlan(warehouseId, billId, userId);
                    }
                case BillType.Package:
                    {
                        return false;
                    }
                case BillType.PickBill:
                    {
                        return false;
                    }
                case BillType.PutawayBill:
                    {
                        return ConfirmTransferBill(warehouseId, billId, userId);
                    }
                case BillType.SortBill:
                    {
                        return false;
                    }
                case BillType.TransferBill:
                    {
                        return ConfirmTransferBill(warehouseId, billId, userId);
                    }
                case BillType.ReplenishBill:
                    {
                        return ConfirmTransferBill(warehouseId, billId, userId);
                    }
            }

            return false;
        }

        /// <summary>
        /// 撤销单据
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billType">单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>审核成功返回true，否则返回false</returns>
        public static bool Revoke(int warehouseId, BillType billType, int billId, int userId)
        {
            switch (billType)
            {
                case BillType.CountBill:
                    {
                        return RevokeCountBill(warehouseId, billId, userId);
                    }
                case BillType.InboundBill:
                    {
                       return RevokeInboundBill(warehouseId, billId, userId);
                    }
                case BillType.InboundPlan:
                    {
                        return RevokeInboundPlan(warehouseId, billId, userId);
                    }
                case BillType.OutboundBill:
                    {
                        return RevokeOutboundBill(warehouseId, billId, userId);
                    }
                case BillType.OutboundPlan:
                    {
                        return RevokeOutboundPlan(warehouseId, billId, userId);
                    }
                case BillType.Package:
                    {
                        return false;
                    }
                case BillType.PickBill:
                    {
                        return false;
                    }
                case BillType.PutawayBill:
                    {
                        break;//return RevokeTransferBill(warehouseId, billId, userId);
                    }
                case BillType.SortBill:
                    {
                        return false;
                    }
                case BillType.TransferBill:
                    {
                        break;//return RevokeTransferBill(warehouseId, billId, userId);
                    }
                case BillType.ReplenishBill:
                    {
                        break;//return RevokeTransferBill(warehouseId, billId, userId);
                    }
            }

            return false;
        }

        #region revoke  bill
        /// <summary>
        /// 撤销入库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划单据编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool RevokeInboundPlan(int warehouseId, int planId, int userId)
        {
            InboundPlan plan = GetInboundPlan(planId);
            if (plan == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.Created)
                && !DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.Modified)
                && !DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.Confirmed))
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_STATUS_ERROR");

            plan.EditUser = userId;
            plan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            plan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Cancelled);

            var repository = new InboundPlanRepository();
            return repository.Update(plan);
        }

        /// <summary>
        /// 撤销入库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">入库单单据编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool RevokeInboundBill(int warehouseId, int billId, int userId)
        {
            InboundBill bill = GetInboundBill(billId);
            if (bill == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)InboundBillStatus.Created)
                && !DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)InboundBillStatus.Modified))
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_STATUS_ERROR");

            bill.EditUser = userId;
            bill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundBillStatus.Cancelled);

            var repository = new InboundBillRepository();
            return repository.Update(bill);
        }

        /// <summary>
        /// 撤销出库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">出库计划单据编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool RevokeOutboundPlan(int warehouseId, int planId, int userId)
        {
            OutboundPlan plan = GetOutboundPlan(planId);
            if (plan == null)
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)OutboundPlanStatus.Created)
                && !DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)OutboundPlanStatus.Modified)
                && !DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)OutboundPlanStatus.Confirmed))
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_STATUS_ERROR");

            plan.EditUser = userId;
            plan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            plan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Cancelled);

            var repository = new OutboundPlanRepository();
            return repository.Update(plan);
        }
        
        /// <summary>
        /// 撤销出库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">出库单单据编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool RevokeOutboundBill(int warehouseId, int billId, int userId)
        {
            OutboundBill bill = GetOutboundBill(billId);
            if (bill == null)
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)OutboundBillStatus.Created)
                && !DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)OutboundBillStatus.Modified))
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_STATUS_ERROR");

            bill.EditUser = userId;
            bill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Cancelled);

            var repository = new OutboundBillRepository();
            return repository.Update(bill);
        }

        private static bool RevokeCountBill(int warehouseId, int billId, int userId)
        {
            CountBill bill = GetCountBill(billId);
            if (bill == null)
                BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_NOTFOUND");

            if (DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.Accounted)
                || DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.Cancelled)
                || DictionaryManager.IsEuqalDictionary(bill.BillStatus, (int)CountBillStatus.Confirmed))
                BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_STATUS_ERROR");

            bill.EditUser = userId;
            bill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)CountBillStatus.Cancelled);

            var repository = new CountBillRepository();
            return repository.Update(bill);
        }
        #endregion

        #region confirm bill
        /// <summary>
        /// 审核入库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划编号</param>
        /// <param name="userId">审核操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool ConfirmInboundPlan(int warehouseId, int planId, int userId)
        {
            InboundPlan plan = GetInboundPlan(planId);
            if (plan == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.Created)
                && !DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.Modified))
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_STATUS_ERROR");

            plan.Auditor = userId;
            plan.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            plan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Confirmed);

            var repository = new InboundPlanRepository();
            return repository.Update(plan);
        }

        /// <summary>
        /// 审核入库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">入库单编号</param>
        /// <param name="userId">操作员</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool ConfirmInboundBill(int warehouseId, int billId, int userId)
        {
            InboundBill inboundBill = null;
            try
            {
                inboundBill = GetInboundBill(billId);
                if (inboundBill == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

                bool isCreated = DictionaryManager.IsEuqalDictionary(inboundBill.BillStatus,(int)InboundBillStatus.Created);
                bool isModified = DictionaryManager.IsEuqalDictionary(inboundBill.BillStatus,(int)InboundBillStatus.Modified);
                if (!isCreated && !isModified)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_BILLSTATUS_ERROR");
                // create inventory data
                List<InboundBillDetail> billDetails = GetInboundBillDetail(billId);

                DateTime inboundDate = DateTime.Parse(inboundBill.ReceiveTime);

                foreach (InboundBillDetail inboundBillDetail in billDetails)
                {
                    StockManager.CreateStock(warehouseId, billId, inboundBillDetail.SkuId, inboundBillDetail.PackId,
                                             inboundBill.ReceiveLocationId, inboundBillDetail.ContainerId,
                                             inboundBillDetail.Qty, inboundBillDetail.BatchNumber, inboundBill.BillNumber, inboundDate.ToString("yyyy-MM-dd"));

                    // update inboundbillnumber of inboundbatch
                    if (inboundBillDetail.BatchNumber != string.Empty)
                        UpdateBillNumberInInboundBatch(inboundBillDetail.BatchNumber, inboundBill.BillNumber);

                    // update inboundplan detail received qty
                    var planDetail = GetInboundPlanDetail(inboundBill.PlanId, inboundBillDetail.SkuId,
                                                                        inboundBillDetail.PackId);
                    UpdateInboundPlanReceivedQty(planDetail, inboundBillDetail.Qty);
                }
                // update inboundbill status
                inboundBill.Auditor = userId;
                inboundBill.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                inboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundBillStatus.Received);
                //UpdateInboundBillStatus(inboundBill, InboundBillStatus.Received, userId);
                var repository = new InboundBillRepository();
                repository.Update(inboundBill);

                // update inboundplan status
                InboundPlan plan = GetInboundPlan(inboundBill.PlanId);
                if (plan == null)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

                bool isFullReceived = IsFullReceivedInboundPlan(inboundBill.PlanId);
                InboundPlanStatus inboundPlanStatus;
                if (isFullReceived)
                    inboundPlanStatus = InboundPlanStatus.Received;
                else
                    inboundPlanStatus = InboundPlanStatus.PartialReceived;

                UpdateInboundPlanStatus(plan, inboundPlanStatus, userId);

                // create putaway task;
                CreatePutawayTransferBill(inboundBill, 0);
                return true;
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(string.Format("审核入库单{0}失败。", inboundBill.BillNumber));
                LogHelper.WriteExceptionLog(ex.ToString());
                ExceptionHelper.HandleException(ex, true, true);
            }

            return false;
        }

        private static void UpdateBillNumberInInboundBatch(string batchNumber, string billNumber)
        {
            try
            {
                var repository = new InboundBatchRepository();
                var query = new Query();
                query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, ""));
                var batch = repository.GetByQuery(query);
                if (batch != null)
                {
                    batch.BillNumber = billNumber;
                    repository.Update(batch);
                }
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex, true, false);
            }
        }

        /// <summary>
        /// 审核出库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">单据编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>审核成功返回true，否则返回false</returns>
        private static bool ConfirmOutboundPlan(int warehouseId, int planId, int userId)
        {
            OutboundPlan outboundPlan = GetOutboundPlan(planId);
            if (outboundPlan == null)
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_NOTFOUND");

            if (DictionaryManager.IsEuqalDictionary(outboundPlan.BillStatus, (int)OutboundPlanStatus.Created) && DictionaryManager.IsEuqalDictionary(outboundPlan.BillStatus, (int)OutboundPlanStatus.Modified))
                BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_STATUS_ERROR");

            outboundPlan.Auditor = userId;
            outboundPlan.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            outboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundPlanStatus.Confirmed);

            var repository = new OutboundPlanRepository();
            return repository.Update(outboundPlan);
        }

        /// <summary>
        /// 审核出库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">单据编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>审核成功返回true，否则返回false</returns>
        private static bool ConfirmOutboundBill(int warehouseId, int billId, int userId)
        {
            OutboundBill outboundBill = null;
            try
            {
                outboundBill = GetOutboundBill(billId);
                if (outboundBill == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_NOTFOUND");

                if (DictionaryManager.IsEuqalDictionary(outboundBill.BillStatus, (int)OutboundBillStatus.Created) &&
                    DictionaryManager.IsEuqalDictionary(outboundBill.BillStatus, (int)OutboundBillStatus.Modified))
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDBILL_STATUS_ERROR");

                // create inventory data
                List<OutboundBillDetail> billDetails = GetOutboundBillDetail(billId);
                foreach (OutboundBillDetail billDetail in billDetails)
                {

                    Stock stock = StockManager.GetStock(billDetail.StockId);
                    if (stock == null)
                        BusinessExceptionHelper.ThrowBusinessException("STOCK_NOTFOUND");

                    if (stock.Qty < billDetail.Qty)
                        BusinessExceptionHelper.ThrowBusinessException("STOCK_LESS");
                    else
                        if (stock.Qty == billDetail.Qty)
                            StockManager.DestroyStock(billId, outboundBill.BillNumber, stock);
                        else
                        {
                            // stock.qty > billDetail.Qty
                            Stock issuedStock = StockManager.SplitStock(BillType.OutboundBill, outboundBill.BillId, outboundBill.BillNumber, stock, billDetail.Qty);
                            StockManager.DestroyStock(billId, outboundBill.BillNumber, issuedStock);
                        }

                    // update inboundplan detail received qty
                    OutboundPlanDetail planDetail = GetOutboundPlanDetail(outboundBill.PlanId, billDetail.SkuId, billDetail.PackId);
                    UpdateOutboundPlanIssuedQty(planDetail, billDetail.Qty);
                }

                // update inboundbill status
                outboundBill.Auditor = userId;
                outboundBill.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                outboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)OutboundBillStatus.Confirmed);
                OutboundBillRepository repository = new OutboundBillRepository();
                repository.Update(outboundBill);

                // update inboundplan status
                OutboundPlan plan = GetOutboundPlan(outboundBill.PlanId);
                if (plan == null)
                    BusinessExceptionHelper.ThrowBusinessException("OUTBOUNDPLAN_NOTFOUND");
                OutboundPlanStatus outboundPlanStatus = OutboundPlanStatus.Issued;

                UpdateOutboundPlanStatus(plan, outboundPlanStatus, userId);

                return true;
            }
            catch (Exception ex)
            {
                Framework.Core.Logger.LogHelper.WriteExceptionLog(string.Format("审核出库单{0}失败。", outboundBill.BillNumber));
                ExceptionHelper.HandleException(ex, true, true);
            }

            return false;
        }

        /// <summary>
        /// 审核盘点单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">单据编号</param>
        /// <param name="userId">用户编号</param>
        /// <returns>审核成功返回true，否则返回false</returns>
        private static bool ConfirmCountBill(int warehouseId, int billId, int userId)
        {
            CountBill countBill = GetCountBill(billId);
            if (countBill == null)
                BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(countBill.BillStatus,(int)CountBillStatus.SecondCounting))
                BusinessExceptionHelper.ThrowBusinessException("COUNTBILL_STATUS_ERROR");

            countBill.Auditor = userId;
            countBill.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            countBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)CountBillStatus.Confirmed);

            // todo: adjust stock here

            var repository = new CountBillRepository();
            return repository.Update(countBill);
        }

        /// <summary>
        /// 审核移货单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billId">移货单编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        private static bool ConfirmTransferBill(int warehouseId, int billId, int userId)
        {
            Framework.Core.Logger.LogHelper.WriteDebugLog("CONFIRM_TB");
            Framework.Core.Logger.LogHelper.WriteDebugLog("TB : " + billId.ToString());

            TransferBill transferBill = GetTransferBill(billId);
            if (transferBill == null)
                BusinessExceptionHelper.ThrowBusinessException("TRANSFERBILL_NOTFOUND");
            Framework.Core.Logger.LogHelper.WriteDebugLog("0.1");
            Framework.Core.Logger.LogHelper.WriteDebugLog(transferBill.BillStatus.ToString());
            Framework.Core.Logger.LogHelper.WriteDebugLog(TransferBillStatus.Transfered.ToString());
            if (!DictionaryManager.IsEuqalDictionary(transferBill.BillStatus, (int)TransferBillStatus.Transfered))
                BusinessExceptionHelper.ThrowBusinessException("TRANSFERBILL_STATUS_ERROR");

            Framework.Core.Logger.LogHelper.WriteDebugLog("1");

            // transfer stock
            List<TransferBillDetail> billDetails = GetTransferBillDetail(billId);
            foreach (var billDetail in billDetails)
            {
                //Stock sourceStock = StockManager.GetStock(warehouseId, billDetail.SourceLocationId,
                //                                          billDetail.SourceContainerId, billDetail.SkuId,
                //                                          billDetail.PackId, billDetail.BatchNumber);

                StockRepository stockRepository = new StockRepository();
                Stock sourceStock = stockRepository.Get(billDetail.StockId);
                Framework.Core.Logger.LogHelper.WriteDebugLog("2");
                if (sourceStock == null)
                    BusinessExceptionHelper.ThrowBusinessException("STOCK_NOTFOUND");

                if (sourceStock.Qty < billDetail.TransferedQty)
                    BusinessExceptionHelper.ThrowBusinessException("STOCK_LESS");
                Framework.Core.Logger.LogHelper.WriteDebugLog("3");
                Stock newStock = null;

                string statusCode = DictionaryManager.GetDictionaryCodeById(transferBill.TransferType);
                int intStatusCode = Int32.Parse(statusCode);
                TransferType tranferType = (TransferType)intStatusCode;

                if (sourceStock.Qty == billDetail.TransferedQty)
                {
                    newStock = StockManager.TransferStock(tranferType, billId, transferBill.BillNumber, sourceStock,
                                               billDetail.TargetLocationId, billDetail.TargetContainerId, userId);
                }
                Framework.Core.Logger.LogHelper.WriteDebugLog("4");
                if (sourceStock.Qty > billDetail.TransferedQty)
                {
                    Stock splitStock = StockManager.SplitStock(BillType.TransferBill, billId, transferBill.BillNumber, sourceStock,
                                                               billDetail.TransferedQty);

                    newStock = StockManager.TransferStock(tranferType, billId, transferBill.BillNumber, splitStock,
                                              billDetail.TargetLocationId, billDetail.TargetContainerId, userId);
                }
                Framework.Core.Logger.LogHelper.WriteDebugLog("5");
                if (newStock == null)
                    BusinessExceptionHelper.ThrowBusinessException("STOCK_TRANSFER_ERROR");
                Framework.Core.Logger.LogHelper.WriteDebugLog("6");
            }

            // update tranfer bill status 
            transferBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferBillStatus.Confirmed);
            transferBill.Auditor = userId;
            transferBill.AuditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            TransferBillRepository repository = new TransferBillRepository();
            repository.Update(transferBill);
            Framework.Core.Logger.LogHelper.WriteDebugLog("7");

            return true;
        }
        #endregion

        #endregion

        #region inbound plan
        /// <summary>
        /// 获取入库计划
        /// </summary>
        /// <param name="planId">入库计划编号</param>
        /// <returns>成功返回入库计划对象，否则返货null</returns>
        public static InboundPlan GetInboundPlan(int planId)
        {
            var repository = new InboundPlanRepository();
            return repository.Get(planId);
        }

        /// <summary>
        /// 关闭入库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划编号</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool CloseInboundPlan(int warehouseId, int planId, int userId)
        {
            InboundPlan plan = GetInboundPlan(planId);
            if (plan == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");

            if (!DictionaryManager.IsEuqalDictionary(plan.BillStatus, (int)InboundPlanStatus.PartialReceived))
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_STATUS_ERROR");

            plan.EditUser = userId;
            plan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
            plan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)InboundPlanStatus.Closed);

            var repository = new InboundPlanRepository();
            return repository.Update(plan);
        }

        /// <summary>
        /// 获取入库计划
        /// </summary>
        /// <param name="inboundBill">入库单</param>
        /// <returns>成功返回入库计划对象，否则返货null</returns>
        public static InboundPlan GetInboundPlanByInboundBill(InboundBill inboundBill)
        {
            if (inboundBill == null) return null;

            long planId = inboundBill.PlanId;
            var repository = new InboundPlanRepository();
            return repository.Get(planId);
        }

        /// <summary>
        /// 获取入库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planNumber">入库计划号</param>
        /// <returns>成功返回入库计划对象，否则返货null</returns>
        public static InboundPlan GetInboundPlan(int warehouseId, string planNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, planNumber));

            var repository = new InboundPlanRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取入库计划明细列表
        /// </summary>
        /// <param name="planId">入库计划编号</param>
        /// <returns>入库计划明细列表</returns>
        public static List<InboundPlanDetail> GetInboundPlanDetail(int planId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

            var repository = new InboundPlanDetailRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 获取入库计划明细
        /// </summary>
        /// <param name="planId">入库计划编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <returns>如果成功返回入库计划明细，否则返回null</returns>
        public static InboundPlanDetail GetInboundPlanDetail(int planId, int skuId, int packId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var repository = new InboundPlanDetailRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 更新入库计划已收货数量
        /// </summary>
        /// <param name="inboundPlanDetail">入库计划明细</param>
        /// <param name="qty">收货数量</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundPlanReceivedQty(InboundPlanDetail inboundPlanDetail, int qty)
        {
            if (inboundPlanDetail != null)
            {
                if ((inboundPlanDetail.ReceivedQty + qty) > inboundPlanDetail.Qty)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_MORE_QTY");

                inboundPlanDetail.ReceivedQty = inboundPlanDetail.ReceivedQty + qty;
                var repository = new InboundPlanDetailRepository();
                return repository.Update(inboundPlanDetail);
            }

            return false;
        }

        /// <summary>
        /// 判断入库计划明细是否完成收货
        /// </summary>
        /// <param name="planId">入库计划编号</param>
        /// <returns>完成收货返回true，否则返回false</returns>
        public static bool IsFullReceivedInboundPlan(int planId)
        {
            List<InboundPlanDetail> planDetails = GetInboundPlanDetail(planId);
            foreach (InboundPlanDetail planDetail in planDetails)
            {
                if (planDetail.ReceivedQty != planDetail.Qty)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// 更新入库计划状态
        /// </summary>
        /// <param name="inboundPlan">入库计划</param>
        /// <param name="planStatus">状态</param>
        /// <param name="userId">操作员</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundPlanStatus(InboundPlan inboundPlan, InboundPlanStatus planStatus, int userId)
        {
            if (inboundPlan != null)
            {
                inboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)planStatus);
                inboundPlan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                inboundPlan.EditUser = userId;

                var repository = new InboundPlanRepository();
                return repository.Update(inboundPlan);
            }

            return false;
        }

        #endregion inbound plan

        #region inbound bill
        /// <summary>
        /// 创建收货任务
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划编号</param>
        /// <param name="deliveryMan">送货员</param>
        /// <param name="vehicle">运输车辆</param>
        /// <param name="arrivalTime">到达时间</param>
        /// <param name="receiveLocationId">收货库位</param>
        /// <param name="remark">备注</param>
        /// <param name="userId">收货员</param>
        /// <returns>成功则返回入库单，否则返回null</returns>
        public static InboundBill CreateReceivingTask(int warehouseId, ref int planId, string deliveryMan,
                                                      string vehicle, string arrivalTime, int receiveLocationId,
                                                      string remark, int userId)
        {
            // get inbound plan
            InboundPlan plan = GetInboundPlan(planId);
            if (plan == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDPLAN_NOTFOUND");
            // create inboundbill
            var bill = new InboundBill
            {
                ArrivalTime = arrivalTime,
                BillNumber = GetNewBillNumber(warehouseId, BillType.InboundBill),
                BillStatus = (int)InboundBillStatus.Created,
                ClientId = plan.ClientId,
                CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                CreateUser = userId,
                MerchantId = plan.MerchantId,
                PlanId = planId,
                ReceiveLocationId = receiveLocationId,
                Vehicle = vehicle,
                VendorId = plan.VendorId,
                WarehouseId = warehouseId,
                Remark = remark
            };
            var inboundBillRepository = new InboundBillRepository();
            bill.BillId = inboundBillRepository.Create(bill);
            if (bill.BillId <= 0)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_CREATE_ERROR");
            // create inboundbill aggregate
            List<InboundPlanDetail> planDetails = GetInboundPlanDetail(planId);
            var inboundBillAggregateRepository = new InboundBillAggregateRepository();
            foreach (InboundPlanDetail inboundPlanDetail in planDetails)
            {
                var aggregate = new InboundBillAggregate
                {
                    BillId = bill.BillId,
                    PackId = inboundPlanDetail.PackId,
                    Qty = inboundPlanDetail.Qty,
                    SkuId = inboundPlanDetail.SkuId
                };
                aggregate.Id = inboundBillAggregateRepository.Create(aggregate);
                if (aggregate.Id <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("RECEIVINGTASK_DETAIL_CREATE_ERROR");
            }

            return bill;
        }

        /// <summary>
        /// 获取入库单
        /// </summary>
        /// <param name="billId">入库单编号</param>
        /// <returns>成功返回入库单，否则返回null</returns>
        public static InboundBill GetInboundBill(int billId)
        {
            var repository = new InboundBillRepository();
            return repository.Get(billId);
        }

        /// <summary>
        /// 获取入库单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billNumber">入库单号</param>
        /// <returns>成功返回入库单，否则返回null</returns>
        public static InboundBill GetInboundBill(int warehouseId, string billNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

            var repository = new InboundBillRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取入库单明细
        /// </summary>
        /// <param name="billId">入库单编号</param>
        /// <returns>成功返回入库单明细</returns>
        public static List<InboundBillDetail> GetInboundBillDetail(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new InboundBillDetailRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// 更新入库单状态
        /// </summary>
        /// <param name="inboundBill">入库单</param>
        /// <param name="status">状态</param>
        /// <param name="userId">操作员</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundBillStatus(InboundBill inboundBill, InboundBillStatus status, int userId)
        {
            if (inboundBill != null)
            {
                inboundBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)status);
                inboundBill.EditUser = userId;
                inboundBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                var repository = new InboundBillRepository();
                return repository.Update(inboundBill);
            }

            return false;
        }
        
        /// <summary>
        /// 获取收货异常明细
        /// </summary>
        /// <param name="billId">入库单</param>
        /// <returns>返回收货异常明细列表</returns>
        public static List<InboundBillException> GetInboundBillException(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new InboundBillExceptionRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 创建收货异常
        /// </summary>
        /// <param name="billId">入库单编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="qty">异常数量</param>
        /// <param name="reason">异常原因</param>
        /// <returns>成功返回收货异常，否则返回null</returns>
        public static InboundBillException CreateInboundBillException(int billId, int skuId, int packId, int qty,
                                                                      ExceptionReason reason)
        {
            var exception = new InboundBillException
                                {
                                    BillId = billId,
                                    ExceptionReason = (int)reason,
                                    PackId = packId,
                                    Qty = qty,
                                    SkuId = skuId
                                };

            var repository = new InboundBillExceptionRepository();
            exception.Id = repository.Create(exception);
            if (exception.Id > 0)
                return exception;

            return null;
        }
        /// <summary>
        /// 更新收货异常
        /// </summary>
        /// <param name="exception">收货异常</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundBillException(InboundBillException exception)
        {
            var repository = new InboundBillExceptionRepository();
            return repository.Update(exception);
        }

        /// <summary>
        /// 获取收货准备信息
        /// </summary>
        /// <param name="billId">入库单号</param>
        /// <returns>成功返回收货准备信息列表，否则返回空列表</returns>
        public static List<InboundBillAggregate> GetInboundBillAggregate(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new InboundBillAggregateRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 创建收货准备信息
        /// </summary>
        /// <param name="billId">入库单号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装信息</param>
        /// <param name="qty">包装数量</param>
        /// <param name="reason">异常原因</param>
        /// <returns>成功返回收货准备信息，否则返回空null</returns>
        public static InboundBillAggregate CreateInboundBillAggregate(int billId, int skuId, int packId, int qty,
                                                                      ExceptionReason reason)
        {
            var exception = new InboundBillAggregate
                                {
                                    BillId = billId,
                                    PackId = packId,
                                    Qty = qty,
                                    SkuId = skuId
                                };

            var repository = new InboundBillAggregateRepository();
            exception.Id = repository.Create(exception);
            if (exception.Id > 0)
                return exception;

            return null;
        }

        /// <summary>
        /// 更新收货准备信息
        /// </summary>
        /// <param name="aggregate">收货准备信息对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundBillAggregate(InboundBillAggregate aggregate)
        {
            var repository = new InboundBillAggregateRepository();
            return repository.Update(aggregate);
        }

        /// <summary>
        /// 上传入库单明细列表
        /// </summary>
        /// <param name="billDetails">入库单明细列表</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UploadInboundBillDetail(List<InboundBillDetail> billDetails)
        {
            var repository = new InboundBillDetailRepository();
            foreach (InboundBillDetail billDetail in billDetails)
            {
                billDetail.Id = repository.Create(billDetail);
                if (billDetail.Id <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_DETAIL_CREATE_ERROR");
            }

            return true;
        }

        #endregion inbound bill

        #region outbound plan
        /// <summary>
        /// 更新出库计划已发货数量
        /// </summary>
        /// <param name="planDetail">出库计划明细对象</param>
        /// <param name="issuedQty">发货数量</param>
        private static void UpdateOutboundPlanIssuedQty(OutboundPlanDetail planDetail, int issuedQty)
        {
            planDetail.IssuedQty = planDetail.IssuedQty + issuedQty;
            var outboundplanDetailRepository = new OutboundPlanDetailRepository();
            outboundplanDetailRepository.Update(planDetail);
        }

        /// <summary>
        /// 获取出库计划
        /// </summary>
        /// <param name="planId">出库计划编号</param>
        /// <returns>成功返回出库计划，否则返回null</returns>
        public static OutboundPlan GetOutboundPlan(int planId)
        {
            var repository = new OutboundPlanRepository();
            return repository.Get(planId);
        }

        /// <summary>
        /// 获取出库计划
        /// </summary>
        /// <param name="outboundBill">出库单</param>
        /// <returns>成功返回出库计划，否则返回null</returns>
        public static OutboundPlan GetOutboundPlanByOutboundBill(OutboundBill outboundBill)
        {
            if (outboundBill == null) return null;

            long planId = outboundBill.PlanId;
            var repository = new OutboundPlanRepository();
            return repository.Get(planId);
        }

        /// <summary>
        /// 获取出库计划
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planNumber">出库计划号</param>
        /// <returns>成功返回出库计划，否则返回null</returns>
        public static OutboundPlan GetOutboundPlan(int warehouseId, string planNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("PlanNumber", CriteriaOperator.Equal, planNumber));

            var repository = new OutboundPlanRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取出库计划明细
        /// </summary>
        /// <param name="planId">出库计划编号</param>
        /// <returns>返回出库计划明细列表</returns>
        public static List<OutboundPlanDetail> GetOutboundPlanDetail(int planId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

            var repository = new OutboundPlanDetailRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 获取出库计划明细
        /// </summary>
        /// <param name="planId">出库计划编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <returns>成功返回出库计划明细，否则返回null</returns>
        public static OutboundPlanDetail GetOutboundPlanDetail(int planId, int skuId, int packId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var repository = new OutboundPlanDetailRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 为出库计划分配库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">出库计划编号</param>
        public static void AssignStockForOutboundPlan(int warehouseId, int planId)
        {
            OutboundPlan outboundPlan = null;
            try
            {
                outboundPlan = GetOutboundPlan(planId);
                if (outboundPlan == null)
                    BusinessExceptionHelper.ThrowBusinessException("4400");

                if (outboundPlan.BillStatus != (int)OutboundPlanStatus.Confirmed)
                    BusinessExceptionHelper.ThrowBusinessException("4401");

                var planDetails = GetOutboundPlanDetail(planId);
                foreach (var planDetail in planDetails)
                {
                    AssignStockForOutboundPlanDetail(outboundPlan.WarehouseId, planDetail);
                }

                UpdateOutboundPlanStatus(outboundPlan, OutboundPlanStatus.Assigned, 0);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(string.Format("出库计划{0}分配库存失败。", outboundPlan.PlanNumber));
                ExceptionHelper.HandleException(ex, true, true);
            }
        }

        /// <summary>
        /// 为出库计划明细分配库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planDetail">出库计划明细</param>
        private static void AssignStockForOutboundPlanDetail(int warehouseId, OutboundPlanDetail planDetail)
        {
            bool assignResult = StockManager.AssignStock(warehouseId, planDetail.PlanId, planDetail.SkuId, planDetail.PackId, planDetail.BatchNumber, planDetail.Qty);
            if (!assignResult)
            {
                string message = string.Format("仓库{0}：为出库计划明细{1}商品{2}包装{3}批次{4}分配{5}库存失败。", warehouseId, planDetail.Id, planDetail.SkuId, planDetail.PackId, planDetail.BatchNumber, planDetail.Qty);
                LogHelper.WriteDebugLog(message);
            }
        }

        /// <summary>
        /// 更新出库计划状态
        /// </summary>
        /// <param name="outboundPlan">出库计划</param>
        /// <param name="planStatus">状态</param>
        /// <param name="userId">操作员</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateOutboundPlanStatus(OutboundPlan outboundPlan, OutboundPlanStatus planStatus, int userId)
        {
            if (outboundPlan != null)
            {
                outboundPlan.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)planStatus);
                outboundPlan.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                outboundPlan.EditUser = userId;

                var repository = new OutboundPlanRepository();
                return repository.Update(outboundPlan);
            }

            return false;
        }

        #endregion outbound plan

        #region outbound bill
        /// <summary>
        /// 获取出库单明细对象列表
        /// </summary>
        /// <param name="billId">出库单编号</param>
        /// <returns>成功返回出库单明细对象列表，否则返回空列表</returns>
        public static List<OutboundBillDetail> GetOutboundBillDetail(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new OutboundBillDetailRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 获取出库单
        /// </summary>
        /// <param name="billId">出库单编号</param>
        /// <returns>成功返回出库单，否则返回false</returns>
        public static OutboundBill GetOutboundBill(int billId)
        {
            var repository = new OutboundBillRepository();
            return repository.Get(billId);
        }
        #endregion 

        #region count bill
        /// <summary>
        /// 获取盘点单
        /// </summary>
        /// <param name="billId">盘点单编号</param>
        /// <returns>成功返回盘点单，否则返回null</returns>
        public static CountBill GetCountBill(int billId)
        {
            var repository = new CountBillRepository();
            return repository.Get(billId);
        }

        public static string CreateCountBill(int warehouseId, string areaCode, string locationCode, string inboundPlanNumber, string inboundBillNumber, string skuNumber, string batchNumber, int operatorId)
        {
            var query = new Query();
            if (areaCode != string.Empty)
                query.Criteria.Add(new Criterion("AreaCode", CriteriaOperator.Equal, areaCode));
            if (locationCode != string.Empty)
                query.Criteria.Add(new Criterion("LocationCode", CriteriaOperator.Equal, locationCode));
            if (inboundPlanNumber != string.Empty)
                query.Criteria.Add(new Criterion("PlanNumber", CriteriaOperator.Equal, inboundPlanNumber));
            if (inboundBillNumber != string.Empty)
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, inboundBillNumber));
            if (skuNumber != string.Empty)
                query.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, skuNumber));
            if (batchNumber != string.Empty)
                query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

            StockViewRepository stockViewRepostory = new StockViewRepository();
            stockViewRepostory.Database = DatabaseConfigName.Inventory;
            IList<StockView> stocks = stockViewRepostory.GetListByQuery(query);
            if (stocks.Count > 0)
            {
                CountBill bill = new CountBill();
                bill.BillNumber = GetNewBillNumber(warehouseId, BillType.CountBill);
                bill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)CountBillStatus.Created);
                bill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.CreateUser = operatorId;
                bill.PlanCountDate = TypeConvertHelper.DatetimeToString(DateTime.Now);
                bill.WarehouseId = warehouseId;

                CountBillRepository countBillRepostory = new CountBillRepository();
                CountBillDetailRepository countBillDetailRepository = new CountBillDetailRepository();
                int newBillId = countBillRepostory.Create(bill);

                foreach (StockView stock in stocks)
                {
                    CountBillDetail detail = new CountBillDetail();
                    detail.AccountQty = stock.Qty;
                    detail.BatchNumber = stock.BatchNumber;
                    detail.BillId = newBillId;
                    detail.ContainerId = stock.ContainerId;
                    detail.CountedQty = 0;
                    detail.LocationId = stock.LocationId;
                    detail.Operator = 0;
                    detail.PackId = stock.PackId;
                    detail.SkuId = stock.SkuId;
                    detail.StockId = stock.StockId;
                    countBillDetailRepository.Create(detail);
                }

                if (newBillId > 0)
                    return bill.BillNumber;
            }

            return string.Empty;
        }

        #endregion 

        #region transfer bill
        /// <summary>
        /// 创建入库单对应上架单
        /// </summary>
        /// <param name="inboundBill">入库单对象</param>
        /// <param name="userId">操作员编号</param>
        private static void CreatePutawayTransferBill(InboundBill inboundBill, int userId)
        {
            try
            {
                TransferBill transferBill = new TransferBill();
                transferBill.BillNumber = GetNewBillNumber(inboundBill.WarehouseId, BillType.TransferBill);
                transferBill.BillStatus = DictionaryManager.GetDictionaryIdByCode((int)TransferBillStatus.Created);
                transferBill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                transferBill.CreateUser = userId;
                transferBill.LinkBillId = inboundBill.BillId;
                transferBill.LinkBillType = DictionaryManager.GetDictionaryIdByCode((int)BillType.InboundBill);
                transferBill.PlanTransferDate = TypeConvertHelper.DatetimeToString(DateTime.Now);
                transferBill.TransferType = DictionaryManager.GetDictionaryIdByCode((int)TransferType.Putaway);
                transferBill.WarehouseId = inboundBill.WarehouseId;

                TransferBillRepository repository = new TransferBillRepository();
                repository.Create(transferBill);
            }
            catch (Exception ex)
            {
                ExceptionHelper.HandleException(ex, true, false);
                BusinessExceptionHelper.ThrowBusinessException("PUTAWAYBILL_CREATE_ERROR");
            }
        }

        /// <summary>
        /// 获取移货单
        /// </summary>
        /// <param name="billId">移货单编号</param>
        /// <returns>成功返回移货单，否则返回null</returns>
        public static TransferBill GetTransferBill(int billId)
        {
            var repository = new TransferBillRepository();
            return repository.Get(billId);
        }

        /// <summary>
        /// 获取移货单
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billNumber">移货单号</param>
        /// <returns>成功返回移货单，否则返回null</returns>
        public static TransferBill GetTransferBill(int warehouseId, string billNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

            var repository = new TransferBillRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取移货单明细列表
        /// </summary>
        /// <param name="billId">移货单号</param>
        /// <returns>返回移货单明细列表</returns>
        public static List<TransferBillDetail> GetTransferBillDetail(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new TransferBillDetailRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 更新移货单状态
        /// </summary>
        /// <param name="transferBill">移货单</param>
        /// <param name="status">状态</param>
        /// <param name="userId">操作员编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateTransferBillStatus(TransferBill transferBill, TransferBillStatus status, int userId)
        {
            if (transferBill != null)
            {
                transferBill.BillStatus = (int)status;
                transferBill.EditTime = TypeConvertHelper.DatetimeToString(DateTime.Now);
                transferBill.EditUser = userId;

                var repository = new TransferBillRepository();
                return repository.Update(transferBill);
            }

            return false;
        }

        /// <summary>
        /// 创建移货单
        /// </summary>
        /// <param name="transferBill">移货单</param>
        /// <returns>成功返回移货单，否则返回null</returns>
        public static TransferBill CreateTransferBill(TransferBill transferBill)
        {
            TransferBillRepository transferBillRepository = new TransferBillRepository();
            TransferBillDetailRepository transferBillDetailRepository = new TransferBillDetailRepository();
            if (transferBill != null)
            {
                if (transferBill.Details == null || transferBill.Details.Count <= 0)
                    BusinessExceptionHelper.ThrowBusinessException("TRANSFERBILL_CREATE_RROR");

                transferBill.BillNumber = GetNewBillNumber(transferBill.WarehouseId, BillType.TransferBill);
                transferBill.BillId = transferBillRepository.Create(transferBill);
                transferBill.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

                foreach (var billDetail in transferBill.Details)
                {
                    billDetail.BillId = transferBill.BillId;
                    billDetail.Id = transferBillDetailRepository.Create(billDetail);
                    if (billDetail.Id <= 0)
                        BusinessExceptionHelper.ThrowBusinessException("TRANSFERBILL_DETAIL_CREATE_RROR");
                }

                return transferBill;
            }

            return null;
        }
        #endregion transfer bill


    }
}