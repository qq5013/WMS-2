using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class StockSnRepository : Repository<StockSn>, IStockSnRepository
    {
        public StockSnRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}