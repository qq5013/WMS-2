using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Inventory
{
    public class OutboundPlanDetailRepository : Repository<OutboundPlanDetail>, IOutboundPlanDetailRepository
    {
        public OutboundPlanDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<OutboundPlanDetailView> GetViewByPlan(long planId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

            var repository = new Repository<OutboundPlanDetailView>();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }


    }
}