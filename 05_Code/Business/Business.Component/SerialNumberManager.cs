using System;
using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.Common.QueryModel;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Inventory;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Inventory;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Core.Logger;

namespace Business.Component
{
    /// <summary>
    /// 单品序列号管理器
    /// </summary>
    public class SerialNumberManager
    {
        private static readonly object Locker = new object();

        /// <summary>
        /// 获取仓库单品序列号前缀
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <returns>返回仓库代码作为序列号前缀</returns>
        private static string GetSerialNumberPrefix(int warehouseId)
        {
            var repository = new WarehouseRepository();
            Warehouse warehouse = repository.Get(warehouseId);
            if (warehouse != null)
                return warehouse.WarehouseCode;

            return string.Empty;
        }

        /// <summary>
        /// 创建新单品序列号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <returns>返回新单品序列号</returns>
        public static string GetNewSerialNumber(int warehouseId)
        {
            lock (Locker)
            {
                string settingCode = "SerialNumber";
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
                    LogHelper.WriteExceptionLog(string.Format("货物序列号{0}转换成int类型失败。", numberStr));
                    ExceptionHelper.HandleException(ex, true, false);
                }

                long newNumber = oldNumber + 1;
                string newNumberStr = RadixConvertHelper.X2X(newNumber.ToString(), 10, 36);
                setting.SettingValue = newNumberStr;
                SettingManager.UpdateSetting(warehouseId, settingCode, setting.SettingValue, setting.Remark, 0);

                return "SN" + GetSerialNumberPrefix(warehouseId) + BillManager.ToSixDigital(newNumberStr);
            }
        }

        /// <summary>
        /// 创建一组新序列号对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="qty">创建数量</param>
        /// <param name="userId">创建用户编号</param>
        /// <returns>成功返回序列号对象列表，否则返回空列表</returns>
        public static List<SerialNumber> CreateSerialNumber(int warehouseId, int planId, int skuId, int packId, int qty,
                                                            int userId)
        {
            int index = GetMaxSnIndex(warehouseId, planId, skuId, packId);
            var repository = new SerialNumberRepository();
            var resultList = new List<SerialNumber>();

            for (int i = 1; i <= qty; i++) 
            {
                var sn = new SerialNumber
                             {
                                 CreateTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                                 CreateUser = userId,
                                 PackId = packId,
                                 PlanId = planId,
                                 SkuId = skuId,
                                 Sn = GetNewSerialNumber(warehouseId),
                                 SnIndex = index + i,
                                 WarehouseId = warehouseId,
                             };

                sn.Id = repository.Create(sn);
                resultList.Add(sn);
            }

            return resultList;
        }

        /// <summary>
        /// 获取货物最大序列号序号
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="planId">入库计划编号</param>
        /// <param name="skuId">包装编号</param>
        /// <param name="packId">包装编号</param>
        /// <returns>返回序列号最大序号</returns>
        private static int GetMaxSnIndex(int warehouseId, int planId, int skuId, int packId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var repository = new SerialNumberRepository();
            SerialNumber serialNumber = repository.GetByQuery(query);
            if (serialNumber != null)
                return serialNumber.SnIndex;

            return 0;
        }

        /// <summary>
        /// 创建单据序列号对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billType">单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="batchNumber">入库批次</param>
        /// <param name="sn">序列号</param>
        /// <returns>单据序列号对象</returns>
        public static BillSn CreateBillSn(int warehouseId, BillType billType, int billId, int skuId, int packId,
                                   string batchNumber, string sn)
        {
            var billSn = new BillSn
                             {
                                 BillId = billId,
                                 BillType = DictionaryManager.GetDictionaryIdByCode((int)billType),
                                 BatchNumber = batchNumber,
                                 PackId = packId,
                                 SkuId = skuId,
                                 Sn = sn,
                                 WarehouseId = warehouseId
                             };

            var repository = new BillSnRepository();
            billSn.Id = repository.Create(billSn);

            if (billSn.Id > 0)
                return billSn;

            return null;
        }

        /// <summary>
        /// 获取单据序列号列表
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="billType">单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="batchNumber">入库批次</param>
        /// <returns>成功返回单据序列号列表，否则返回空列表</returns>
        public static List<BillSn> GetBillSn(int warehouseId, BillType billType, int billId, int skuId, int packId,
                                   string batchNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            // to-do: has a bug in query condition of BatchNumber，cause a wrong sql
            //query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Like, batchNumber));
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
            query.Criteria.Add(new Criterion("BillType", CriteriaOperator.Equal, DictionaryManager.GetDictionaryIdByCode((int)billType)));
            

            var repository = new BillSnRepository();
            return CollectionHelper.ToList(repository.GetListByQuery(query));
        }

        /// <summary>
        /// 删除单据序列号
        /// </summary>
        /// <param name="billSn">单据序列号对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DeleteBillSn(BillSn billSn)
        {
            var repository = new BillSnRepository();
            return repository.Delete(billSn.Id);
        }
    }
}