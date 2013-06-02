using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class OperatorGroupRepository : Repository<OperatorGroup>, IOperatorGroupRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public OperatorGroupRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public OperatorGroup GetByName(string warehouseCode, string groupName)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("GroupName", CriteriaOperator.Equal, groupName));

                return GetByQuery(query);
            }

            return null;
        }

        public IList<User> GetMembers(int operatorGroupId)
        {
            return GetListByCommand<User>("OperatorGroup.GetMembers", operatorGroupId);
        }
    }
}