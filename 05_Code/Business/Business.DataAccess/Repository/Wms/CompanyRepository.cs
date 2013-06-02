using System.Collections.Generic;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;
using Business.Common.QueryModel;

namespace Business.DataAccess.Repository.Wms
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public Company GetByCode(string companyCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("CompanyCode", CriteriaOperator.Equal, companyCode));

            return GetByQuery(query);
        }

        public IList<Company> GetByType(int companyTypeId)
        {
            return GetListByCommand<Company>("Company.GetByType", companyTypeId);
        }

        public IList<CompanyType> GetTypes(int companyId)
        {
            return GetListByCommand<CompanyType>("Company.GetTypes", companyId);
        }
    }
}