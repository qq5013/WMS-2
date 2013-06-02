using System;
using Business.Common.Exception;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;
using Framework.Database.IBatis;

namespace Business.DataAccess.Repository.Application
{
    public class ParameterRepository : Repository<Parameter>, IParameterRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public ParameterRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IParameterRepository Members

        public Parameter GetByCode(string applicationCode, string parameterCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("ParameterCode", CriteriaOperator.Equal, parameterCode));

                return GetByQuery(query);
            }

            return null;
        }

        #endregion
    }
}