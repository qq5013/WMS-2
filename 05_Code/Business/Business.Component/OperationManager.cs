using System;
using Business.Common.DataDictionary;
using Business.Common.Toolkit;
using Business.DataAccess.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.Component
{
    /// <summary>
    /// 仓库操作管理器
    /// </summary>
    public class OperationManager
    {
        /// <summary>
        /// 仓库操作处理
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="userId">操作员编号</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="billType">关联单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="qty">数量</param>
        /// <param name="sourceLocationId">原库位编号</param>
        /// <param name="sourceContainerId">原容器编号</param>
        /// <param name="targetLocationInd">目标库位编号</param>
        /// <param name="targetContainerId">目标容器编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool Handle(int warehouseId, int userId, OperationType operationType, BillType billType,
                                  int billId, int skuId, int packId, int qty, int sourceLocationId,
                                  int sourceContainerId, int targetLocationInd, int targetContainerId)
        {
            AppendOperationLog(warehouseId, userId, operationType, billType, billId, skuId, packId, qty,
                               sourceLocationId, sourceContainerId, targetLocationInd, targetContainerId);

            // do something here
            throw new NotImplementedException();
        }

        /// <summary>
        /// 记录仓库操作日志
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="userId">操作员编号</param>
        /// <param name="operationType">操作类型</param>
        /// <param name="billType">关联单据类型</param>
        /// <param name="billId">单据编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="qty">数量</param>
        /// <param name="sourceLocationId">原库位编号</param>
        /// <param name="sourceContainerId">原容器编号</param>
        /// <param name="targetLocationInd">目标库位编号</param>
        /// <param name="targetContainerId">目标容器编号</param>
        private static void AppendOperationLog(int warehouseId, int userId, OperationType operationType,
                                               BillType billType, int billId, int skuId, int packId, int qty,
                                               int sourceLocationId, int sourceContainerId, int targetLocationInd,
                                               int targetContainerId)
        {
            var log = new OperationLog
                          {
                              WarehouseId = warehouseId,
                              LinkBillId = billId,
                              LinkBillType = (int) billType,
                              LogTime = TypeConvertHelper.DatetimeToString(DateTime.Now),
                              OperationType = (int) operationType,
                              Operator = userId,
                              PackId = packId,
                              Qty = qty,
                              SkuId = skuId,
                              SourceContainerId = sourceContainerId,
                              SourceLocationId = sourceLocationId,
                              TargetContainerId = targetContainerId,
                              TargetLocationId = targetLocationInd
                          };

            var repository = new OperationLogRepository();
            repository.Create(log);
        }
    }
}