using Business.DataAccess.Contract.Repository.Wms;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class SkuManagementRepository : Repository<SkuManagement>, ISkuManagementRepository
    {
        public SkuManagementRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public SkuManagement GetSkuManagement(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));

            return GetByQuery(query);
        }

 
    }
}