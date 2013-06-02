using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class AreaGroupRepository : Repository<AreaGroup>, IAreaGroupRepository
    {
        public AreaGroupRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

        public bool AddGroup(int areaId, int groupId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("AreaId", CriteriaOperator.Equal, areaId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));

            AreaGroup areaGroup = GetByQuery(query);
            if (areaGroup == null)
            {
                areaGroup = new AreaGroup
                {
                    GroupId = groupId,
                    AreaId = areaId
                };

                return Create(areaGroup) > 0;
            }

            return false;
        }

        public bool RemoveGroup(int areaId, int groupId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("AreaId", CriteriaOperator.Equal, areaId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));

            AreaGroup areaGroup = GetByQuery(query);
            if (areaGroup != null)
            {
                return Delete(areaGroup.Id);
            }

            return false;
        }
    }
}