using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;

namespace Business.DataAccess.Repository.Application
{
    public class ApplicationRepository : Repository<Domain.Application.Application>, IApplicationRepository
    {
        public ApplicationRepository()
        {
            Database = DatabaseConfigName.Application;
        }

        #region IApplicationRepository Members

        public Domain.Application.Application GetByCode(string applicationCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("ApplicationCode", CriteriaOperator.Equal, applicationCode));

            return GetByQuery(query);
        }

        #endregion
    }
}