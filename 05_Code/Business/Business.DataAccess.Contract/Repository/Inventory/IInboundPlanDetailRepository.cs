using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;     

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public interface IInboundPlanDetailRepository : IRepository<InboundPlanDetail>
    {
        IList<InboundPlanDetailView> GetViewByPlan(long planId);
    }
}