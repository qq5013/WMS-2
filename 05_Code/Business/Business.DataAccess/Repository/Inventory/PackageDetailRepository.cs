using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class PackageDetailRepository : Repository<PackageDetail>, IPackageDetailRepository
    {
        public PackageDetailRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}