using System.Collections;
using System.Collections.Generic;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;
using Framework.Core.Collections;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository.Warehouse
{
    public class SkuLocationRepository : Repository<SkuLocation>, ISkuLocationRepository
    {
        public SkuLocationRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

        #region ISkuLocationRepository Members

        public List<Location> GetLocations(int warehouseId, int areaTypeId, int skuId)
        {
            var parameter = new Hashtable();
            parameter.Add("WarehouseId", warehouseId);
            parameter.Add("AreaType", areaTypeId);
            parameter.Add("SkuId", skuId);
            return
                CollectionHelper.ToList(
                    DataMapperHelper.GetMapper(Database).QueryForList<Location>("SkuLocation.GetLocations", parameter));
        }

        #endregion
    }
}