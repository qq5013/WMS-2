using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Inventory
{
    public class OutboundBillDetailRepository : Repository<OutboundBillDetail>, IOutboundBillDetailRepository
    {
        public OutboundBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<OutboundBillDetailView> GetViewByBill(long billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new Repository<OutboundBillDetailView>();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }
    }
}