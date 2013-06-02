using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class AreaRepository : Repository<Area>, IAreaRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public AreaRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Area GetByCode(int warehouseId, string areaCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("AreaCode", CriteriaOperator.Equal, areaCode));

            return GetByQuery(query);
        }

        public Area GetByCode(string warehouseCode, string areaCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("AreaCode", CriteriaOperator.Equal, areaCode));

                return GetByQuery(query);
            }

            return null;
        }

        public IList<OperatorGroup> GetGroups(int areaId)
        {
            return GetListByCommand<OperatorGroup>("Area.GetGroups", areaId);
        }
    }
}