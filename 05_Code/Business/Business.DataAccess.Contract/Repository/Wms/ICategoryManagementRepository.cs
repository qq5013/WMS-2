using Business.Domain.Wms;
using System.Collections.Generic;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface ICategoryManagementRepository : IRepository<CategoryManagement>
    {
        CategoryManagement GetByCode(string categoryCode);

        IList<CategoryManagement> GetByLevel(int categoryLevel);

        IList<CategoryManagement> GetByParent(int parentId);

        IList<BatchProperty> GetBatchProperty(int categoryId);
    }
}