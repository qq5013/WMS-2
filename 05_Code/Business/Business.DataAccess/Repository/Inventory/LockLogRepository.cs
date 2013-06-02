using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class LockLogRepository : Repository<LockLog>, ILockLogRepository
    {
        public LockLogRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}