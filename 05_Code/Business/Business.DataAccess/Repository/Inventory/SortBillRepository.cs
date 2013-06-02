using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class SortBillRepository : Repository<SortBill>, ISortBillRepository
    {
        public SortBillRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}