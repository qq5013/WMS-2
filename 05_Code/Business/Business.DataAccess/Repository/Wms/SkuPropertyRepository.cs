using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class SkuPropertyRepository : Repository<SkuProperty>, ISkuPropertyRepository
    {
        public SkuPropertyRepository()
        {
            Database = DatabaseConfigName.Wms;
        }
    }
}