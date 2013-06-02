using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class ContainerTypeRepository : Repository<ContainerType>, IContainerTypeRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public ContainerTypeRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public ContainerType GetByCode(string warehouseCode, string typeCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("TypeCode", CriteriaOperator.Equal, typeCode));

                return GetByQuery(query);
            }

            return null;
        }

        public ContainerType GetByCode(int wareouseId, string typeCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, wareouseId));
            query.Criteria.Add(new Criterion("TypeCode", CriteriaOperator.Equal, typeCode));

            return GetByQuery(query);
        }
    }
}