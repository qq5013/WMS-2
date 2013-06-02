using Business.Domain.Inventory;

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public interface IInboundPlanRepository : IRepository<InboundPlan>
    {
        InboundPlan GetByBillNumber(string warehouseCode, string billNumber);
    }
}