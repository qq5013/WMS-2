using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface IWarehouseUserRepository : IRepository<WarehouseUser>
    {
        bool AddUser(int warehouseId, int userId);

        bool RemoveUser(int warehouseId, int userId);

        bool IsWarehouseUser(int warehouseId, int userId);


    }
}