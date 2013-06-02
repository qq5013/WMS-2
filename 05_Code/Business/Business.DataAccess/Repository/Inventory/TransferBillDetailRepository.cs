using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class TransferBillDetailRepository : Repository<TransferBillDetail>, ITransferBillDetailRepository
    {
        public TransferBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}