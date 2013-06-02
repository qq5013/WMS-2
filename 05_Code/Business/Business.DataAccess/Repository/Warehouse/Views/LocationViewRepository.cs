using System.Collections;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class LocationRepository : Repository<Location>, ILocationRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public LocationRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Location GetByCode(string warehouseCode, string locationCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("LocationCode", CriteriaOperator.Equal, locationCode));

                return GetByQuery(query);
            }

            return null;
        }

        public Location GetByCode(int warehouseId, string locationCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("LocationCode", CriteriaOperator.Equal, locationCode));

            return GetByQuery(query);
        }

        public IList<Location> GetBySku(int warehouseId, int skuId, int areaType)
        {
            var ht = new Hashtable {{"WarehouseId", warehouseId}, {"SkuId", skuId}, {"AreaType", areaType}};
            return GetListByCommand<Location>("Location.GetBySku", ht);
        }

        public IList<Location> GetByTag(int warehouseId, int skuId, int areaType)
        {
            var ht = new Hashtable { { "WarehouseId", warehouseId }, { "SkuId", skuId }, { "AreaType", areaType } };
            return GetListByCommand<Location>("Location.GetByTag", ht);
        }
    }
}