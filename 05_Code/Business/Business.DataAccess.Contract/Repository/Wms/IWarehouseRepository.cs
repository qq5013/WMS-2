using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface IWarehouseRepository : IRepository<Domain.Wms.Warehouse>
    {
        Domain.Wms.Warehouse GetByCode(string warehouseCode);

        IList<User> GetUsers(int warehouseId);
    }
}