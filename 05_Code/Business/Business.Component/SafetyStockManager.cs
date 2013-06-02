using Business.Common.QueryModel;
using Business.DataAccess.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.Component
{
    /// <summary>
    /// 安全库存管理器
    /// </summary>
    public class SafetyStockManager
    {
        /// <summary>
        /// 获取货物仓库安全库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <returns>成功返回仓库安全库存对象，否则返回null</returns>
        public static SafetyStock GetWarehouseSafetyStock(int warehouseId, int skuId, int packId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var respository = new SafetyStockRepository();
            return respository.GetByQuery(query);
        }

        /// <summary>
        /// 设置仓库安全库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="minQty">最小库存量</param>
        /// <param name="maxQty">最大库存两</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool SetWarehouseSafetyStockQty(int warehouseId, int skuId, int packId, int minQty, int maxQty)
        {
            SafetyStock safetyStock = GetWarehouseSafetyStock(warehouseId, skuId, packId);
            if (safetyStock == null)
            {
                safetyStock = new SafetyStock
                                  {
                                      WarehouseId = warehouseId,
                                      SkuId = skuId,
                                      PackId = packId,
                                      MinQty = minQty,
                                      MaxQty = maxQty
                                  };
            }
            else
            {
                safetyStock.MinQty = minQty;
                safetyStock.MaxQty = maxQty;
            }

            var respository = new SafetyStockRepository();
            return respository.Update(safetyStock);
        }

        /// <summary>
        /// 获取货物拣货库位安全库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="locationId">拣货库位编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <returns>成功返回货物拣货库位安全库存对象，否则返回null</returns>
        public static LocationSafetyStock GetLocationSafetyStock(int warehouseId, int locationId, int skuId, int packId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
            query.Criteria.Add(new Criterion("PackId", CriteriaOperator.Equal, packId));

            var respository = new LocationSafetyStockRepository();
            return respository.GetByQuery(query);
        }

        /// <summary>
        /// 设置货物拣货库位安全库存
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="locationId">拣货库位编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="packId">包装编号</param>
        /// <param name="minQty">最小安全量</param>
        /// <param name="maxQty">最大安全量</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool SetLocationSafetyStockQty(int warehouseId, int locationId, int skuId, int packId, int minQty,
                                                     int maxQty)
        {
            LocationSafetyStock safetyStock = GetLocationSafetyStock(warehouseId, skuId, locationId, packId);
            if (safetyStock == null)
            {
                safetyStock = new LocationSafetyStock
                                  {
                                      WarehouseId = warehouseId,
                                      SkuId = skuId,
                                      LocationId = locationId,
                                      PackId = packId,
                                  };
            }
            else
            {
                safetyStock.MinQty = minQty;
                safetyStock.MaxQty = maxQty;
            }

            var respository = new LocationSafetyStockRepository();
            return respository.Update(safetyStock);
        }
    }
}