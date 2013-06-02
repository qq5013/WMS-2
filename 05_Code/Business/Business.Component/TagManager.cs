using System;
using System.Collections.Generic;
using Business.Common.DataDictionary; 
using Business.Common.QueryModel;
using Business.DataAccess.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Business.Domain.Inventory; 

namespace Business.Component
{ 
    /// <summary>
    /// 标签管理器
    /// </summary>
    public class TagManager
    {
        /// <summary>
        /// 创建标签
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <param name="userId">用户编号</param>
        /// <param name="remark">备注</param>
        /// <returns>成功返回Tag对象，失败返回null</returns>
        public static Tag CreateTag(int warehouseId, string tagNumber, int userId, string remark)
        {
            var tag = new Tag
                          {
                              WarehouseId = warehouseId,
                              TagNumber = tagNumber,
                              Remark = remark,
                              IsActive = true,
                              CreateUser = userId,
                              CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                          };
            var repository = new TagRepository();
            int insertResult = repository.Create(tag);

            if (insertResult > 0)
            {
                tag.TagId = insertResult;
                return tag;
            }

            return null;
        }

        /// <summary>
        /// 激活标签
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool EnableTag(int warehouseId, string tagNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));

            var repository = new TagRepository();
            Tag tag = repository.GetByQuery(query);
            if (tag != null)
            {
                tag.IsActive = true;
                return repository.Update(tag);
            }

            return false;
        }

        /// <summary>
        /// 禁用标签
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool DisableTag(int warehouseId, string tagNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));

            var repository = new TagRepository();
            Tag tag = repository.GetByQuery(query);
            if (tag != null)
            {
                tag.IsActive = false;
                return repository.Update(tag);
            }

            return false;
        }

        /// <summary>
        /// 应用库位标签
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <param name="locationId">库位编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool ApplyLocationTag(int warehouseId, string tagNumber, int locationId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));
            var repository = new TagRepository();
            Tag tag = repository.GetByQuery(query);

            var locationRepository = new LocationRepository();
            Location location = locationRepository.Get(locationId);

            if (tag != null && location != null)
            {
                var query1 = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
                query.Criteria.Add(new Criterion("TagId", CriteriaOperator.Equal, tagNumber));
                query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));

                var locationTagRepository = new LocationTagRepository();
                LocationTag locationTag = locationTagRepository.GetByQuery(query1);

                if (locationTag == null)
                {
                    locationTag = new LocationTag
                                      {
                                          LocationId = locationId,
                                          TagId = tag.TagId,
                                          WarehouseId = warehouseId
                                      };
                    int insertResult = locationTagRepository.Create(locationTag);
                    if (insertResult > 0)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 应用货物标签
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static bool ApplySkuTag(int warehouseId, string tagNumber, int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));
            var repository = new TagRepository();
            Tag tag = repository.GetByQuery(query);

            var skuRepository = new SkuRepository();
            Sku location = skuRepository.Get(skuId);

            if (tag != null && location != null)
            {
                var query1 = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
                query.Criteria.Add(new Criterion("TagId", CriteriaOperator.Equal, tagNumber));
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

                var skuTagRepository = new SkuTagRepository();
                SkuTag skuTag = skuTagRepository.GetByQuery(query1);

                if (skuTag == null)
                {
                    skuTag = new SkuTag
                                 {
                                     SkuId = skuId,
                                     TagId = tag.TagId,
                                     WarehouseId = warehouseId
                                 };
                    int insertResult = skuTagRepository.Create(skuTag);
                    if (insertResult > 0)
                        return true;
                }
            }

            return false;
        }

        /// <summary>
        /// 获取标签应用的所有货物
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static List<Sku> GetTagSkus(int warehouseId, string tagNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));
            var tagRepository = new TagRepository();
            Tag tag = tagRepository.GetByQuery(query);

            if (tag != null)
                return tagRepository.GetTagSkus(tag);

            return new List<Sku>();
        }

        /// <summary>
        /// 获取标签应用的所有库位
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="tagNumber">标签号</param>
        /// <returns>成功返回true，否则返回false</returns>
        public static List<Location> GetTagLocations(int warehouseId, string tagNumber)
        {
            var repository = new TagRepository();
            return repository.GetTagLocations(warehouseId, tagNumber);
        }

        /// <summary>
        /// 获取货物关联的所有拣货库位和存储库位
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回库位对象列表，否则返回空列表</returns>
        public static List<Location> GetSkuTagLocations(int warehouseId, int skuId)
        {
            List<Location> pickLocations = GetPickLocations(warehouseId, skuId);
            List<Location> storageLocations = GetStorageLocations(warehouseId, skuId);

            var locations = new List<Location>();
            foreach (Location location in pickLocations)
            {
                locations.Add(location);
            }

            foreach (Location location in storageLocations)
            {
                locations.Add(location);
            }

            return locations;
        }

        /// <summary>
        /// 获取货物可上架库位信息
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <param name="qty">待上架数量</param>
        /// <returns>成功返回可上架库位信息对象列表，否则返回空列表</returns>
        public static List<PutawayLocation> GetPutawayLocations(int warehouseId, int skuId, int qty)
        {
            List<Location> locations = GetSkuTagLocations(warehouseId, skuId);

            List<PutawayLocation> putawayLocations = new List<PutawayLocation>();
            List<PutawayLocation> putawayLocations1 = new List<PutawayLocation>();
            foreach (var location in locations)
            {
                var putawayLocation = new PutawayLocation()
                {
                    Barcode = location.Barcode,
                    LocationCode = location.LocationCode,
                    LocationName = location.LocationName,
                    LocationId = location.LocationId,
                    Route = location.Route
                };

                IList<Stock> stocks = StockManager.GetStocks(location.LocationId);
                int skuQty = 0;
                int otherQty = 0;
                foreach (var stock in stocks)
                {
                    if (stock.SkuId == skuId)
                        skuQty = skuQty + stock.Qty;
                    else
                        otherQty = otherQty + stock.Qty;
                }

                putawayLocation.SkuStockQty = skuQty;
                putawayLocation.OtherStockQty = otherQty;

                putawayLocations.Add(putawayLocation);
            }

            //foreach (var putawayLocation in putawayLocations)
            //{
            //    if (putawayLocation.SkuStockQty == 0)
            //    {
            //        putawayLocations1.Add(putawayLocation);
            //    }
            //}

            return putawayLocations;
        }

        /// <summary>
        /// 获取货物存储库位列表
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回库位对象列表，否则返回空列表</returns>
        public static List<Location> GetStorageLocations(int warehouseId, int skuId)
        {
            var repository = new TagRepository();
            return repository.GetLocations(warehouseId, skuId, DictionaryManager.GetDictionaryIdByCode((int)AreaType.Storage));
        }

        /// <summary>
        /// 获取货物拣货库位列表
        /// </summary>
        /// <param name="warehouseId">仓库编号</param>
        /// <param name="skuId">货物编号</param>
        /// <returns>成功返回库位对象列表，否则返回空列表</returns>
        public static List<Location> GetPickLocations(int warehouseId, int skuId)
        {
            var repository = new TagRepository();
            return repository.GetLocations(warehouseId, skuId, DictionaryManager.GetDictionaryIdByCode((int)AreaType.Picking));
        }
    }
}