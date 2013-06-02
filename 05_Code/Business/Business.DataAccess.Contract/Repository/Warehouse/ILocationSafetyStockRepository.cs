using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ILocationSafetyStockRepository : IRepository<LocationSafetyStock>
    {
        LocationSafetyStock GetBySku(string warehouseCode, int skuId, int locationId);
    }
}