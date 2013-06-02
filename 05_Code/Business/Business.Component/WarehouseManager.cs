using System;
using System.Collections.Generic;
using Business.Common.DataDictionary;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;
using Business.Domain.Wms;
using Business.Common.QueryModel;
using Framework.Core.Collections;

namespace Business.Component
{
    /// <summary>
    /// 仓库管理器
    /// </summary>
    public class WarehouseManager
    {
        public static Warehouse GetWarehouse(string warehouseCode)
        {
            var repository = new WarehouseRepository();
            return repository.GetByCode(warehouseCode);
        }

        public static Warehouse GetWarehouse(int warehouseId)
        {
            var repository = new WarehouseRepository();
            return repository.Get(warehouseId);
        }

        public static string GetWarehouseName(int warehouseId)
        {
            Warehouse warehouse = GetWarehouse(warehouseId);
            if (warehouse != null)
                return warehouse.WarehouseName;

            return string.Empty;
        }

        public static ContainerType GetContainerType(int typeId)
        {
            var repository = new ContainerTypeRepository();
            return repository.Get(typeId);
        }

        ///// <summary>
        ///// 获取货物关联拣货库位列表 （暂时不用此逻辑）
        ///// </summary>
        ///// <param name="warehouseId">仓库编号</param>
        ///// <param name="skuId">货物编号</param>
        ///// <returns>成功返回库位列表，否则返回空列表</returns>
        //public static List<Location> GetPickLocations(int warehouseId, int skuId)
        //{
        //    var repository = new SkuLocationRepository();
        //    return repository.GetLocations(warehouseId, (int) AreaType.Picking, skuId);
        //}

        ///// <summary>
        ///// 获取货物关联存储库位列表 （暂时不用此逻辑）
        ///// </summary>
        ///// <param name="warehouseId">仓库编号</param>
        ///// <param name="skuId">货物编号</param>
        ///// <returns>成功返回库位列表，否则返回空列表</returns>
        //public static List<Location> GetStorageLocations(int warehouseId, int skuId)
        //{
        //    var repository = new SkuLocationRepository();
        //    return repository.GetLocations(warehouseId, (int) AreaType.Storage, skuId);
        //}

        ///// <summary>
        ///// 获取货物关联二手品库位列表 （暂时不用此逻辑）
        ///// </summary>
        ///// <param name="warehouseId">仓库编号</param>
        ///// <param name="skuId">货物编号</param>
        ///// <returns>成功返回库位列表，否则返回空列表</returns>
        //public static List<Location> GetSecondHandLocations(int warehouseId, int skuId)
        //{
        //    var repository = new SkuLocationRepository();
        //    return repository.GetLocations(warehouseId, (int) AreaType.SecondHand, skuId);
        //}

        ///// <summary>
        ///// 获取货物关联坏品品库位列表 （暂时不用此逻辑）
        ///// </summary>
        ///// <param name="warehouseId">仓库编号</param>
        ///// <param name="skuId">货物编号</param>
        ///// <returns>成功返回库位列表，否则返回空列表</returns>
        //public static List<Location> GetBadLocations(int warehouseId, int skuId)
        //{
        //    var repository = new SkuLocationRepository();
        //    return repository.GetLocations(warehouseId, (int) AreaType.Bad, skuId);
        //}

        /// <summary>
        /// 获取库位对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="barcode">库位条码</param>
        /// <returns>成功返回库位对象，否则返回null</returns>
        public static Location GetLocationByBarcode(int warehouseId, string barcode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("Barcode", CriteriaOperator.Equal, barcode));

            LocationRepository repository = new LocationRepository();
            return repository.GetByQuery(query);
        }

        /// <summary>
        /// 获取容器对象
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="barcode">容器条码</param>
        /// <returns>成功返回容器对象，否则返回null</returns>
        public static Container GetContainerByBarcode(int warehouseId, string barcode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("Barcode", CriteriaOperator.Equal, barcode));

            ContainerRepository repository = new ContainerRepository();
            return repository.GetByQuery(query);
        } 

        /// <summary>
        /// 获取容器条码
        /// </summary>
        /// <param name="containerId">容器编号</param>
        /// <returns>成功返回容器条码，否则返回空字符串</returns>
        public static string GetContainerBarcode(int containerId)
        {
            ContainerRepository repository = new ContainerRepository();
            Container container = repository.Get(containerId);
            if (container != null)
                return container.Barcode;

            return string.Empty;
        }

        /// <summary>
        /// 获取库位条码
        /// </summary>
        /// <param name="locationId">库位编号</param>
        /// <returns>成功返回库位条码，否则返回空字符串</returns>
        public static string GetLocationBarcode(int locationId)
        {
            LocationRepository repository = new LocationRepository();
            Location location = repository.Get(locationId);
            if (location != null)
                return location.Barcode;

            return string.Empty;
        }

        public static Location GetLocationByCode(string warehosueCode, string locationCode)
        {
            LocationRepository repository = new LocationRepository();
            return repository.GetByCode(warehosueCode, locationCode);
        }

        public static Container GetContainerByCode(string warehosueCode, string containerCode)
        {
            ContainerRepository repository = new ContainerRepository();
            return repository.GetByCode(warehosueCode, containerCode);
        }

        /// <summary>
        /// 获取库位行走路径
        /// </summary>
        /// <param name="locationId">库位编号</param>
        /// <returns>成功返回库位行走路径，否则返回0</returns>
        public static int GetLocationRoute(int locationId)
        {
            LocationRepository repository = new LocationRepository();
            Location location = repository.Get(locationId);
            if (location != null)
                return location.Route;

            return 0;
        }

        public static Container GetContainerByCode(int warehouseId, string containerCode)
        {
            var repository = new ContainerRepository();
            return repository.GetByCode(warehouseId, containerCode);
        }

        public static List<LocationView> GetReceivingLocation(int warehouseId)
        {
            LocationViewRepository repository = new LocationViewRepository();
            Query query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            int areaTypeId = DictionaryManager.GetDictionaryIdByCode((int)AreaType.Receiving);
            query.Criteria.Add(new Criterion("AreaType", CriteriaOperator.Equal, areaTypeId));

            return CollectionHelper.ToList<LocationView>(repository.GetListByQuery(query));
        }
    } 
}