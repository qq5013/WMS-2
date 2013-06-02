using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class CountBillDetailRepository : Repository<CountBillDetail>, ICountBillDetailRepository
    {
        public CountBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}