using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class LocationTagRepository : Repository<LocationTag>, ILocationTagRepository
    {
        public LocationTagRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }
    }
}