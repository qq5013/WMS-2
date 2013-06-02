using Business.DataAccess.Contract.Repository.Wms;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class PackRepository : Repository<Pack>, IPackRepository
    {
        public PackRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public Pack GetPiecePack(int skuId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("SkuId", CriteriaOperator.Equal, skuId));
            query.Criteria.Add(new Criterion("PackLevel", CriteriaOperator.Equal, 3));
            query.Criteria.Add(new Criterion("ToPieceQty", CriteriaOperator.Equal, 1));

            return GetByQuery(query);
        }
    }
}