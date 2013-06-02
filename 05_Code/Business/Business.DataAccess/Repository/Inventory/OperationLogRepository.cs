using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class OperationLogRepository : Repository<OperationLog>, IOperationLogRepository
    {
        public OperationLogRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}