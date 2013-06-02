using Business.DataAccess.Contract.Repository.Inventory;
using Business.Domain.Inventory;

namespace Business.DataAccess.Repository.Inventory
{
    public class PackageRepository : Repository<Package>, IPackageRepository
    {
        public PackageRepository()
        {
            Database = DatabaseConfigName.Inventory;
        }
    }
}