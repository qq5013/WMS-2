using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class BatchPropertyRepository : Repository<BatchProperty>, IBatchPropertyRepository
    {
        public BatchPropertyRepository()
        {
            Database = DatabaseConfigName.Wms;
        }
    }
}