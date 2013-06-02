using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class CategoryPropertyRepository : Repository<CategoryProperty>, ICategoryPropertyRepository
    {
        public CategoryPropertyRepository()
        {
            Database = DatabaseConfigName.Wms;
        }
    }
}