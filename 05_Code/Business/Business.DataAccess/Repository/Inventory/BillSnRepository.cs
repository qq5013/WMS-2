using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class BillSnRepository : Repository<BillSn>, IBillSnRepository
    {
        public BillSnRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}