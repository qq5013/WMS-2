using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class OutboundBillRepository : Repository<OutboundBill>, IOutboundBillRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public OutboundBillRepository()
        {
            Database = DatabaseConfigName.Inventory;

            _warehouseRepository = new WarehouseRepository();
        }

        public OutboundBill GetByBillNumber(string warehouseCode, string billNumber)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("BillNumber", CriteriaOperator.Equal, billNumber));

                return GetByQuery(query);
            }

            return null;
        }
    }
}