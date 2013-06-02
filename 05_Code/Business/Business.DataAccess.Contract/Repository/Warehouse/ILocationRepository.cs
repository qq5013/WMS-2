using System.Collections.Generic;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ILocationRepository : IRepository<Location>
    {
        Location GetByCode(string warehouseCode, string locationCode);

        Location GetByCode(int warehouseId, string locationCode);

        //IList<Location> GetBySku(int warehouseId, int skuId, int areaType);

        //IList<Location> GetByTag(int warehouseId, int skuId, int areaType);
    }
}