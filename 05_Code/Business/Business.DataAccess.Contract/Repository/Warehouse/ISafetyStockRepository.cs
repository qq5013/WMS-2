using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ISafetyStockRepository : IRepository<SafetyStock>
    {
        SafetyStock GetBySku(string warehouseCode, int skuId);
    }
}