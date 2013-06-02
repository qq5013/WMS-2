using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class AisleRepository : Repository<Aisle>, IAisleRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public AisleRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Aisle GetByCode(string warehouseCode, string aisleCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("AisleCode", CriteriaOperator.Equal, aisleCode));

                return GetByQuery(query);
            }

            return null;
        }
    }
}