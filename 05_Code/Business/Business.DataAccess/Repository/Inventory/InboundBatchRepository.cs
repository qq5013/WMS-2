using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundBatchRepository : Repository<InboundBatch>, IInboundBatchRepository
    {
        public InboundBatchRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}