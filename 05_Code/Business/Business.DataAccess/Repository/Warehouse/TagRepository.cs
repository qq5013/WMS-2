using System.Collections;
using System.Collections.Generic;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;
using Business.Domain.Wms;
using Framework.Core.Collections;
using Framework.Database.IBatis;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Repository.Wms;
using Business.Domain.Warehouse;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Warehouse
{
    public class TagRepository : Repository<Tag>, ITagRepository
    {
        private readonly WarehouseRepository _warehouseRepository;

        public TagRepository()
        {
            Database = DatabaseConfigName.Warehouse;

            _warehouseRepository = new WarehouseRepository();
        }

        #region ITagRepository Members

        public List<Sku> GetTagSkus(Tag tag)
        {
            return CollectionHelper.ToList(DataMapperHelper.GetMapper(Database).QueryForList<Sku>("Tag.GetTagSkus", tag));
        }

        public List<Location> GetTagLocations(int warehouseId, string tagNumber)
        {
            var parameter = new Hashtable();
            parameter.Add("WarehouseId", warehouseId);
            parameter.Add("TagNumber", tagNumber);
            return
                CollectionHelper.ToList(
                    DataMapperHelper.GetMapper(Database).QueryForList<Location>("Tag.GetTagLocations", parameter));
        }

        public List<Location> GetLocations(int warehouseId, int skuId, int areaType)
        {
            var parameter = new Hashtable();
            parameter.Add("WarehouseId", warehouseId);
            parameter.Add("SkuId", skuId);
            parameter.Add("AreaType", areaType);
            return
                CollectionHelper.ToList(
                    DataMapperHelper.GetMapper(Database).QueryForList<Location>("Tag.GetSkuLocations", parameter));
        }


        public Tag GetByNumber(string warehouseCode, string tagNumber)
        {
            Domain.Wms.Warehouse warehouse = _warehouseRepository.GetByCode(warehouseCode);
            if (warehouse != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouse.WarehouseId));
                query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));

                return GetByQuery(query);
            }

            return null;
        }


        public Tag GetByNumber(int warehouseId, string tagNumber)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("WarehouseId", CriteriaOperator.Equal, warehouseId));
            query.Criteria.Add(new Criterion("TagNumber", CriteriaOperator.Equal, tagNumber));

            return GetByQuery(query);
        }
        #endregion
    }
}