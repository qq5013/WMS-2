using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class SkuTagRepository : Repository<SkuTag>, ISkuTagRepository
    {
        public SkuTagRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

    }
}