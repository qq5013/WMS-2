using System.Collections.Generic;
using Business.Domain.Warehouse;
using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface ITagRepository : IRepository<Tag>
    {
        List<Sku> GetTagSkus(Tag tag);

        List<Location> GetTagLocations(int warehouseId, string tagNumber);

        List<Location> GetLocations(int warehouseId, int skuId, int areaType);

        Tag GetByNumber(string warehouseCode, string tagNumber);

        Tag GetByNumber(int warehouseId, string tagNumber);
    }
}