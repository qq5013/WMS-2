using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class TransferBillRepository : Repository<TransferBill>, ITransferBillRepository
    {
        public TransferBillRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}