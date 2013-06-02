using System.Collections.Generic;
using Business.Domain.Wms;

namespace Business.DataAccess.Contract.Repository.Wms
{
    public interface ICompanyRepository : IRepository<Company>
    {
        Company GetByCode(string companyCode);

        IList<Company> GetByType(int companyTypeId);

        IList<CompanyType> GetTypes(int companyId);
    }
}