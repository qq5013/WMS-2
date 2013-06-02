using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Inventory
{
    public class InboundBillDetailRepository : Repository<InboundBillDetail>, IInboundBillDetailRepository
    {
        public InboundBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<InboundBillDetailView> GetViewByBill(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new Repository<InboundBillDetailView>();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }
    }
}