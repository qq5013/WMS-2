using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class SafetyStockRepository : Repository<SafetyStock>, ISafetyStockRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public SafetyStockRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public SafetyStock GetBySku(string warehouseCode, int skuId)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

                return GetByQuery(query);
            }

            return null;
        }
    }
}