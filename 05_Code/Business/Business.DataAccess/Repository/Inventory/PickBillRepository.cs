using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class PickBillRepository : Repository<PickBill>, IPickBillRepository
    {
        public PickBillRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}