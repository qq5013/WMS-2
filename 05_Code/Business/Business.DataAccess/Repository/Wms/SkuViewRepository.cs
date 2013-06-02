using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class SkuViewRepository : Repository<SkuView>, ISkuViewRepository
    {
        private readonly CompanyRepository _companyRepository;

        public SkuViewRepository()
        {
            Database = DatabaseConfigName.Wms;

            _companyRepository = new CompanyRepository();
        }

        public SkuView GetByNumber(string clientCode, string skuNumber)
        {
            Company client = _companyRepository.GetByCode(clientCode);
            if (client != null)
            {
                var query = new Query();
                query.Criteria.Add(new Criterion("ClientId", CriteriaOperator.Equal, client.CompanyId));
                query.Criteria.Add(new Criterion("SkuNumber", CriteriaOperator.Equal, skuNumber));

                return GetByQuery(query);
            }

            return null;
        }
    }
}