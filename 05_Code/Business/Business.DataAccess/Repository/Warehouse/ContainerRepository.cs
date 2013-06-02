using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class ContainerRepository : Repository<Container>, IContainerRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public ContainerRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Container GetByCode(string warehouseCode, string containerCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("ContainerCode", CriteriaOperator.Equal, containerCode));

                return GetByQuery(query);
            }

            return null;
        }

        public Container GetByCode(int warehouseId, string containerCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("ContainerCode", CriteriaOperator.Equal, containerCode));

            return GetByQuery(query);
        }
    }
}