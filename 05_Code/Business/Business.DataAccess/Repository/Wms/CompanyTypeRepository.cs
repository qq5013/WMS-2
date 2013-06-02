using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class CompanyTypeRepository : Repository<CompanyType>, ICompanyTypeRepository
    {
        public CompanyTypeRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        public bool AddType(int companyId, int typeId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("CompanyId", CriteriaOperator.Equal, companyId));
            query.Criteria.Add(new Criterion("CompanyTypeId", CriteriaOperator.Equal, typeId));

            CompanyType companyType = GetByQuery(query);
            if (companyType == null)
            {
                companyType = new CompanyType
                {
                    CompanyId = companyId,
                    CompanyTypeId = typeId
                };

                return Create(companyType) > 0;
            }

            return false;
        }

        public bool RemoveType(int companyId, int typeId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("CompanyId", CriteriaOperator.Equal, companyId));
            query.Criteria.Add(new Criterion("CompanyTypeId", CriteriaOperator.Equal, typeId));

            CompanyType companyType = GetByQuery(query);
            if (companyType != null)
            {
                return Delete(companyType.Id);
            }

            return false;
        }
    }
}