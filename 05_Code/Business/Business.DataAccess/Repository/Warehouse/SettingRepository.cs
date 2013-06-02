using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class SettingRepository : Repository<Setting>, ISettingRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public SettingRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        public Setting GetByCode(string warehouseCode, string settingCode)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("SettingCode", CriteriaOperator.Equal, settingCode));

                return GetByQuery(query);
            }

            return null;
        }

        public Setting GetByCode(int warehouseId, string settingCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("SettingCode", CriteriaOperator.Equal, settingCode));

            return GetByQuery(query);
        }
    }
}