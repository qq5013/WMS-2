using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class LocationSafetyStockRepository : Repository<LocationSafetyStock>, ILocationSafetyStockRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public LocationSafetyStockRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public LocationSafetyStock GetBySku(string warehouseCode, int skuId, int locationId)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
                query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));

                return GetByQuery(query);
            }

            return null;
        }
    }
}