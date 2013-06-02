using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundPlanDetailRepository : Repository<InboundPlanDetail>, IInboundPlanDetailRepository
    {
        public InboundPlanDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<InboundPlanDetailView> GetViewByPlan(long planId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("PlanId", CriteriaOperator.Equal, planId));

            var repository = new Repository<InboundPlanDetailView>();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }
    }
}