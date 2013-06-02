using System.Collections.Generic;
using Business.Domain.Inventory;

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public interface ILockRepository : IRepository<Lock>
    {
        List<Lock> GetSkuLocks(int warehouseId, int skuId);
    }
}