using Business.DataAccess.Repository;
using Business.Domain.Inventory;

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public class InboundBillExceptionRepository : Repository<InboundBillException>, IInboundBillExceptionRepository
    {
        public InboundBillExceptionRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}