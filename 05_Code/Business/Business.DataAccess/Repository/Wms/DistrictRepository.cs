using System.Collections.Generic;
using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Wms;
using Business.Domain.Wms;

namespace Business.DataAccess.Repository.Wms
{
    public class DistrictRepository : Repository<District>, IDistrictRepository
    {
        public DistrictRepository()
        {
            Database = DatabaseConfigName.Wms;
        }

        #region IApplicationRepository Members

        public District GetByCode(string districtCode)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("DistrictCode", CriteriaOperator.Equal, districtCode));

            return GetByQuery(query);
        }


        public IList<District> GetByLevel(int districtLevel)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("DistrictLevel", CriteriaOperator.Equal, districtLevel));

            return GetListByQuery(query);
        }

        public IList<District> GetByParent(int parentId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("ParentId", CriteriaOperator.Equal, parentId));

            return GetListByQuery(query);
        }
        #endregion
    }
}