using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class ShelfRepository : Repository<Shelf>, IShelfRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public ShelfRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Shelf GetByCode(string warehouseCode, string shelfCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("ShelfCode", CriteriaOperator.Equal, shelfCode));

                return GetByQuery(query);
            }

            return null;
        }
    }
}