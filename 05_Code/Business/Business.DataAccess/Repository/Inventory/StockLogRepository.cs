using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class StockLogRepository : Repository<StockLog>, IStockLogRepository
    {
        public StockLogRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}