using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class StockSnLogRepository : Repository<StockSnLog>, IStockSnLogRepository
    {
        public StockSnLogRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}