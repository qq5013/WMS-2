using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class FunctionRepository : Repository<Function>, IFunctionRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public FunctionRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IFunctionRepository Members

        public Function GetByCode(string applicationCode, string functionCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("FunctionCode", CriteriaOperator.Equal, functionCode));

                return GetByQuery(query);
            }

            return null;
        }

        #endregion
    }
}