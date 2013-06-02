using Business.DataAccess.Contract.Repository.Wms;
using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.Domain.Wms;
using Business.DataAccess.Repository;

namespace Business.DataAccess.Repository.Wms
{
    public class CategoryManagementRepository : Repository<CategoryManagement>, ICategoryManagementRepository
    {
        public CategoryManagementRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        #region ICategoryManagementRepository Members

        public CategoryManagement GetByCode(string categoryCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("CategoryCode", CriteriaOperator.Equal, categoryCode));

            return GetByQuery(query);
        }


        public IList<CategoryManagement> GetByLevel(int categoryLevel)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("CategoryLevel", CriteriaOperator.Equal, categoryLevel));

            return GetListByQuery(query);
        }

        public IList<CategoryManagement> GetByParent(int parentId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("ParentId", CriteriaOperator.Equal, parentId));

            return GetListByQuery(query);
        }

        public IList<BatchProperty> GetBatchProperty(int categoryId)
        {
            return GetListByCommand<BatchProperty>("CategoryManagement.GetBatchProperties", categoryId);
        }
        #endregion
    }
}