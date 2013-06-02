using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class DataDictionaryRepository : Repository<DataDictionary>, IDataDictionaryRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public DataDictionaryRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IDataDictionaryRepository Members

        public IList<DataDictionary> GetByCategory(string applicationCode, string category)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("Category", CriteriaOperator.Equal, category));

                return GetListByQuery(query);
            }

            return null;
        }

        public DataDictionary GetByCode(string applicationCode, string dataDictionaryCode)
        {
            Domain.Application.Application application = _applicationRepository.GetByCode(applicationCode);
            if (application != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ApplicationId", CriteriaOperator.Equal, application.ApplicationId));
                query.Criteria.Add(new Criterion("DictionaryCode", CriteriaOperator.Equal, dataDictionaryCode));

                return GetByQuery(query);
            }

            return null;
        }

        #endregion
    }
}