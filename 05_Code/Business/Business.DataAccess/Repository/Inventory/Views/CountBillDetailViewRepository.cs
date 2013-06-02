using System;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;
using Business.Domain.Inventory.Views;
using Framework.Core.Collections;
using Framework.Core.Exception;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository.Inventory
{
    public class CountBillDetailViewRepository : Repository<CountBillDetailView>, ICountBillDetailViewRepository
    {
        public CountBillDetailViewRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }

        public IList<CountBillDetailView> GetViewByBill(int billId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("BillId", CriteriaOperator.Equal, billId));

            return GetListByQuery(query);
        }
    }
}
