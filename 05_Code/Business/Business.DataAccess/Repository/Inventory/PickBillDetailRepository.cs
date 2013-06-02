using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class PickBillDetailRepository : Repository<PickBillDetail>, IPickBillDetailRepository
    {
        public PickBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}