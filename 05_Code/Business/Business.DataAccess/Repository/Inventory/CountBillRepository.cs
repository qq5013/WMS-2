using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class CountBillRepository : Repository<CountBill>, ICountBillRepository
    {
        public CountBillRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}