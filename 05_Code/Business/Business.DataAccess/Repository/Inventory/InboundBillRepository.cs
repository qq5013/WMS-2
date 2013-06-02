using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundBillRepository : Repository<InboundBill>, IInboundBillRepository
    {
        public InboundBillRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public InboundBill GetByBillNumber(string warehouseCode, string billNumber)
        {
            return null;
        }
    }
}