using Business.Domain.Inventory;
using System.Collections.Generic;
using Business.Domain.Inventory.Views; 

namespace Business.DataAccess.Contract.Repository.Inventory
{
    public interface ISortBillDetailRepository : IRepository<SortBillDetail>
    {
        //IList<InboundBillDetailView> GetViewByBill(long BillId);
    }
}