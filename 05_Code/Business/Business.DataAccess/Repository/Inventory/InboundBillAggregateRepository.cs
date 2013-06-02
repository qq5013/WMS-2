using Business.DataAccess.Repository;
using Business.Domain.Inventory;

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public class InboundBillAggregateRepository : Repository<InboundBillAggregate>, IInboundBillAggregateRepository
    {
        public InboundBillAggregateRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}