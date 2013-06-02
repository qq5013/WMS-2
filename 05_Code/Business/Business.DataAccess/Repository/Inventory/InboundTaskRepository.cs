using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundTaskRepository : Repository<InboundTask>, IInboundTaskRepository
    {
        public InboundTaskRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}