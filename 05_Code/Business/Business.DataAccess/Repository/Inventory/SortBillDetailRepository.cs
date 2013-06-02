using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Inventory
{
    public class SortBillDetailRepository : Repository<SortBillDetail>, ISortBillDetailRepository
    {
        public SortBillDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<InboundBillDetailView> GetViewByBill(long billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            var repository = new Repository<InboundBillDetailView>();
            repository.Database = DatabaseConfigName.Inventory;
            return repository.GetListByQuery(query);
        }
    }
}