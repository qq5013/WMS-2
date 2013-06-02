using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Inventory;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class OutboundPlanRepository : Repository<OutboundPlan>, IOutboundPlanRepository
    {
        private readonly WarehouseRepository _warehouseRepository;
        public OutboundPlanRepository()
        {
            Database = DatabaseConfigName.Inventory;
            _warehouseRepository = new WarehouseRepository();
        }

        public OutboundPlan GetByBillNumber(string warehouseCode, string billNumber)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("PlanNumber", CriteriaOperator.Equal, billNumber));

                return GetByQuery(query);
            }

            return null;
        }
    }
}