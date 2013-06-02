using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Application;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class WarehouseRepository : Repository<Domain.Wms.Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public Domain.Wms.Warehouse GetByCode(string warehouseCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseCode", CriteriaOperator.Equal, warehouseCode));

            return GetByQuery(query);
        }

        public IList<User> GetUsers(int warehouseId)
        {
            return GetListByCommand<User>("Warehouse.GetUsers", warehouseId); ;
        }

       
    }
}