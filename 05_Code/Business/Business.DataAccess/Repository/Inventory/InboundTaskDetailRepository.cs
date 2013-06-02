using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundTaskDetailRepository : Repository<InboundTaskDetail>, IInboundTaskDetailRepository
    {
        public InboundTaskDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}