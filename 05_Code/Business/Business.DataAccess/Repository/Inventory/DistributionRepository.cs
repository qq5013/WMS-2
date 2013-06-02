using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class DistributionRepository : Repository<Distribution>, IDistributionRepository
    {
        public DistributionRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}