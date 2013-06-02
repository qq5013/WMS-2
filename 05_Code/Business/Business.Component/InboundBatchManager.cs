using System;
using System.Collections.Generic;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Inventory;
using Business.Domain.Inventory;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Core.Logger;

namespace Business.Component
{
    /// <summary>
    /// 入库批次管理器
    /// </summary>
    public class InboundBatchManager
    {
        /// <summary>
        /// 创建入库批次
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="inboundBillNumber">入库单号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="qty">数量</param>
        /// <param name="batchProperties">批次属性</param>
        /// <param name="userId">创建用户编号</param>
        /// <returns>成功返回入库批次对象，否则返回null</returns>
        public static InboundBatch CreateInboundBatch(int warehouseId, string inboundBillNumber, int skuId, int qty,
                                                      Dictionary<BatchProperty, string> batchProperties, int userId)
        {
            var batch = new InboundBatch();
            batch.BatchNumber = GetNewBatchNumber(warehouseId, skuId, userId);
            batch.BillNumber = inboundBillNumber;
            batch.InboundDate = TypeConvertHelper.DateToString(DateTime.Now);
            batch.SkuId = skuId;
            batch.Qty = qty;
            batch.CreateUser = userId;
            batch.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

            InboundBill bill = BillManager.GetInboundBill(warehouseId, inboundBillNumber);
            if (bill != null)
            {
                InboundPlan plan = BillManager.GetInboundPlan(bill.PlanId);
                if (plan != null)
                    batch.PlanNumber = plan.PlanNumber;
            }

            //遍历整个字典
            foreach (var property in batchProperties)
            {
                BatchProperty bp = property.Key;
                if (bp.PropertyCode == "ProductionDate")
                    batch.ProductionDate = property.Value;

                if (bp.PropertyCode == "ExpiringDate")
                    batch.ExpiringDate = property.Value;

                if (bp.PropertyCode == "ProductionBatch")
                    batch.ProductionBatch = property.Value;

                if (bp.PropertyCode == "ManufacturingOrigin")
                    batch.ManufacturingOrigin = property.Value;

                if (bp.PropertyCode == "Property1")
                    batch.PropertyValue1 = property.Value;

                if (bp.PropertyCode == "Property2")
                    batch.PropertyValue2 = property.Value;

                if (bp.PropertyCode == "Property3")
                    batch.PropertyValue3 = property.Value;

                if (bp.PropertyCode == "Property4")
                    batch.PropertyValue4 = property.Value;

                if (bp.PropertyCode == "Property5")
                    batch.PropertyValue5 = property.Value;

                if (bp.PropertyCode == "Property6")
                    batch.PropertyValue6 = property.Value;
            }

            var repository = new InboundBatchRepository();
            batch.Id = repository.Create(batch);
            if (batch.Id <= 0)
                BusinessExceptionHelper.ThrowBusinessException("4104");

            return batch;
        }

        /// <summary>
        /// 创建入库批次
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="inboundBillNumber">入库单号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="qty">数量</param>
        /// <param name="userId">创建用户编号</param>
        /// <returns>成功返回入库批次对象，否则返回null</returns>
        public static InboundBatch CreateInboundBatch(int warehouseId, string inboundBillNumber, int skuId, int qty,
                                                      int userId)
        {
            var batch = new InboundBatch();
            batch.BatchNumber = GetNewBatchNumber(warehouseId, skuId, userId);
            batch.BillNumber = inboundBillNumber;
            batch.InboundDate = TypeConvertHelper.DateToString(DateTime.Now);
            batch.SkuId = skuId;
            batch.Qty = qty;
            batch.CreateUser = userId;
            batch.CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now);

            InboundBill bill = BillManager.GetInboundBill(warehouseId, inboundBillNumber);
            if (bill != null)
            {
                InboundPlan plan = BillManager.GetInboundPlan(bill.PlanId);
                if (plan != null)
                    batch.PlanNumber = plan.PlanNumber;
            }

            var repository = new InboundBatchRepository();
            batch.Id = repository.Create(batch);
            if (batch.Id <= 0)
                BusinessExceptionHelper.ThrowBusinessException("4104");

            return batch;
        }

        /// <summary>
        /// 删除入库批次
        /// </summary>
        /// <param name="id">入库批次编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DeleteInboundBatch(int id)
        {
            var repository = new InboundBatchRepository();
            return repository.Delete(id);
        }

        /// <summary>
        /// 更新入库批次
        /// </summary>
        /// <param name="id">入库批次编号</param>
        /// <param name="qty">数量</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool UpdateInboundBatchQty(int id, int qty)
        {
            var repository = new InboundBatchRepository();
            InboundBatch batch = repository.Get(id);
            batch.Qty = qty;
            return repository.Update(batch);
        }

        /// <summary>
        /// 获取新入库批次号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="userId">创建用户编号</param>
        /// <returns>成功返回新入库批次号，否则返回空字符串</returns>
        public static string GetNewBatchNumber(int warehouseId, int skuId, int userId)
        {
            Setting setting = SettingManager.GetSetting(warehouseId, "BATCH_NUMER");

            if (setting == null)
            {
                setting = SettingManager.CreateSetting(warehouseId, "BATCH_NUMER", "String", "0", string.Empty, userId);
            }

            string numberStr = RadixConvertHelper.X2X(setting.SettingValue, 36, 10);
            long oldNumber = 0;
            try
            {
                oldNumber = long.Parse(numberStr);
            }
            catch (Exception ex)
            {
                LogHelper.WriteExceptionLog(string.Format("批次序列号{0}转换成int类型失败。", numberStr));
                ExceptionHelper.HandleException(ex, true, false);
            }
            long newNumber = oldNumber + 1;
            string newNumberStr = RadixConvertHelper.X2X(newNumber.ToString(), 10, 36);

            setting.SettingValue = newNumberStr;
            bool updateResult = SettingManager.UpdateSetting(warehouseId, setting.SettingCode, "String", setting.Remark,
                                                             0);

            if (updateResult)
                return newNumberStr;
            else
            {
                ExceptionHelper.HandleException(new Exception("获取新批次号时保存仓库设置失败。"), true, false);
            }

            return string.Empty;
        }

        /// <summary>
        /// 获取入库批次对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billNumber">入库单号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="batchNumber">入库批次号</param>
        /// <returns>成功返回入库批次对象，否则返回null</returns>
        public static InboundBatch GetInboundBatch(int warehouseId, string billNumber, int skuId, string batchNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

            var repository = new InboundBatchRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取入库批次对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="batchNumber">入库批次号</param>
        /// <returns>成功返回入库批次对象，否则返回null</returns>
        public static InboundBatch GetInboundBatch(int warehouseId, int skuId, string batchNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

            var repository = new InboundBatchRepository();
            return repository.GetByQuery(query);
        }

        public static InboundBatch GetInboundBatch(int warehouseId, string batchNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

            var repository = new InboundBatchRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取入库批次对象列表
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billNumber">入库单号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回入库批次对象列表，否则返回空列表</returns>
        public static List<InboundBatch> GetInboundBatch(int warehouseId, string billNumber, int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

            var repository = new InboundBatchRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 检查入库批次数量
        /// </summary>
        /// <param name="billId">入库单号</param>
        /// <returns>批次数量相符返回true，否则返回false</returns>
        public static bool ValidateInboundBatchQty(int billId)
        {
            InboundBill bill = BillManager.GetInboundBill(billId);
            if (bill == null)
                BusinessExceptionHelper.ThrowBusinessException("INBOUNDBILL_NOTFOUND");

            List<InboundBillAggregate> aggregates = BillManager.GetInboundBillAggregate(billId);
            foreach (InboundBillAggregate aggregate in aggregates)
            {
                int qty = aggregate.Qty;
                List<InboundBatch> batches = GetInboundBatch(bill.WarehouseId, bill.BillNumber, aggregate.SkuId);
                int countedQty = 0;
                foreach (InboundBatch batch in batches)
                    countedQty = countedQty + batch.Qty;

                if (countedQty != qty)
                    return false;
            }

            return true;
        }
    }
}