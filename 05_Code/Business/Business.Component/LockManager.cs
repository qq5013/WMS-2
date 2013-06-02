using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Inventory;
using Business.Domain.Inventory;
using Framework.Core.Collections;

namespace Business.Component
{
    /// <summary>
    /// 库存锁定管理器
    /// </summary>
    public class LockManager
    {
        /// <summary>
        /// 记录库存加锁解锁日志
        /// </summary>
        /// <param name="sourceLock">原库存锁定对象</param>
        /// <param name="lockLogType">锁定日志类型</param>
        private static void ApplendLockLog(Lock @sourceLock, LockLogType lockLogType)
        {
            var log = new LockLog
                          {
                              LockLogType = (int)lockLogType,
                              LockId = @sourceLock.LockId,
                              LockType = @sourceLock.LockType,
                              LockMode = @sourceLock.LockMode,
                              LockObject = @sourceLock.LockObject,
                              LockReason = @sourceLock.LockReason,
                              LockTime = @sourceLock.LockTime,
                              Operator = @sourceLock.Operator,
                              PackId = @sourceLock.PackId,
                              Qty = @sourceLock.Qty,
                              BatchNumber = @sourceLock.BatchNumber,
                              Remark = @sourceLock.Remark,
                              SkuId = @sourceLock.SkuId,
                              WarehouseId = @sourceLock.WarehouseId,
                              ContainerId = @sourceLock.ContainerId,
                              CreateTime = @sourceLock.CreateTime,
                              CreateUser = @sourceLock.CreateUser,
                              EditTime = @sourceLock.EditTime,
                              EditUser = @sourceLock.EditUser,
                              LocationId = @sourceLock.LocationId,
                          };

            var repository = new LockLogRepository();
            repository.Create(log);
        }

        /// <summary>
        /// 创建库存锁
        /// </summary>
        /// <param name="lock">库存锁对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool CreateLock(Lock @lock)
        {
            var repository = new LockRepository();
            int insertResult = repository.Create(@lock);
            if (insertResult > 0)
            {
                ApplendLockLog(@lock, LockLogType.CreateLock);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 编辑库存锁
        /// </summary>
        /// <param name="lock">库存锁对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool EditLock(Lock @lock)
        {
            var repository = new LockRepository();
            bool editResult = repository.Update(@lock);
            if (editResult)
            {
                ApplendLockLog(@lock, LockLogType.EditLock);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 释放库存锁
        /// </summary>
        /// <param name="lock">库存锁对象</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool ReleaseLock(Lock @lock)
        {
            var repository = new LockRepository();
            bool deleteResult = repository.Delete(@lock.LockId);
            if (deleteResult)
            {
                ApplendLockLog(@lock, LockLogType.ReleaseLock);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 获取货物锁定列表
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回库存锁定列表，否则返回空列表</returns>
        public static List<Lock> GetSkuLocks(int warehouseId, int skuId)
        {
            var repository = new LockRepository();
            return repository.GetSkuLocks(warehouseId, skuId);
        }

        /// <summary>
        /// 获取货物锁定总数量
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="locationId">库位编号</param>
        /// <param name="containerId">容器编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="batchNumber">入库批次</param>
        /// <returns>货物锁定总数量</returns>
        public static int GetLockedQty(int warehouseId, int locationId, int containerId, int skuId, int packId, string batchNumber)
        {
            var repository = new LockRepository();

            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
            query.Criteria.Add(new Criterion("ContainerId", CriteriaOperator.Equal, containerId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));
            query.Criteria.Add(new Criterion("BatchNumber", CriteriaOperator.Equal, batchNumber));

            List<Lock> locks = CollectionHelper.ToList<Lock>(repository.GetListByQuery(query));
            int totalQty = 0;
            foreach (var @lock in locks)
                totalQty = totalQty + @lock.Qty;

            return totalQty;
        }
    }
}