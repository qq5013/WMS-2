using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class RoleGroupRepository : Repository<RoleGroup>, IRoleGroupRepository
    {
        public RoleGroupRepository()
        {
            Database = DatabaseConfigName.Application;
        }

        #region IRoleGroupRepository Members

        public bool AddGroup(int roleId, int groupId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));

            RoleGroup roleGroup = GetByQuery(query);
            if (roleGroup == null)
            {
                roleGroup = new RoleGroup
                                {
                                    RoleId = roleId,
                                    GroupId = groupId
                                };

                return Create(roleGroup) > 0;
            }

            return false;
        }

        public bool RemoveGroup(int roleId, int groupId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("RoleId", CriteriaOperator.Equal, roleId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));

            RoleGroup roleGroup = GetByQuery(query);
            if (roleGroup != null)
            {
                return Delete(roleGroup.Id);
            }

            return false;
        }

        #endregion
    }
}