using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class WarehouseUserRepository : Repository<WarehouseUser>, IWarehouseUserRepository
    {
        public WarehouseUserRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public bool AddUser(int warehouseId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            WarehouseUser warehouseUser = GetByQuery(query);
            if (warehouseUser == null)
            {
                warehouseUser = new WarehouseUser
                {
                    WarehouseId = warehouseId,
                    UserId = userId
                };

                return Create(warehouseUser) > 0;
            }

            return false;
        }

        public bool RemoveUser(int warehouseId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            WarehouseUser warehouseUser = GetByQuery(query);
            if (warehouseUser != null)
            {
                return Delete(warehouseUser.Id);
            }

            return false;
        }

        public bool IsWarehouseUser(int warehouseId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            WarehouseUser warehouseUser = GetByQuery(query);
            if (warehouseUser != null)
                return true;

            return false;
        }
    }
}