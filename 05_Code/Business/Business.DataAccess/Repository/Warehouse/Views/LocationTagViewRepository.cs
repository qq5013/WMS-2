using Business.DataAccess.Contract.Repository.Warehouse;
using Business.DataAccess.Contract.Repository.Warehouse.Views;
using Business.Domain.Warehouse;
using Business.Domain.Warehouse.Views;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Warehouse.Views
{
    public class LocationTagViewRepository : Repository<LocationTagView>, ILocaionTagViewRepository
    {
        public LocationTagViewRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

        public LocationTagView Get(int locationId, int tagId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("LocationId", CriteriaOperator.Equal, locationId));
            query.Criteria.Add(new Criterion("TagId", CriteriaOperator.Equal, tagId));

            return GetByQuery(query);
        }
    }
}
