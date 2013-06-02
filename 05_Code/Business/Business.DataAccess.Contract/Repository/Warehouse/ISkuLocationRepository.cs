using System.Collections.Generic;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ISkuLocationRepository : IRepository<SkuLocation>
    {
        List<Location> GetLocations(int warehouseId, int areaTypeId, int skuId);
    }
}