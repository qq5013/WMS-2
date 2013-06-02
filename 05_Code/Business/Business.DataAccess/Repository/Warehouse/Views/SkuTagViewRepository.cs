using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Contract.Repository.Warehouse.Views;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Warehouse.Views
{
    public class SkuTagViewRepository : Repository<SkuTagView>, ISkuTagViewRepository
    {
        public SkuTagViewRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

        public SkuTagView Get(int skuId, int tagId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("TagId", CriteriaOperator.Equal, tagId));

            return GetByQuery(query);
        }
    }
}
