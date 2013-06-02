using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Application;
using Business.Domain.Application;

namespace Business.DataAccess.Repository.Application
{
    public class GroupUserRepository : Repository<GroupUser>, IGroupUserRepository
    {
        private readonly IApplicationRepository _applicationRepository;

        public GroupUserRepository()
        {
            Database = DatabaseConfigName.Application;

            _applicationRepository = new ApplicationRepository();
        }

        #region IGroupUserRepository Members

        public bool AddUser(int groupId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            GroupUser groupUser = GetByQuery(query);
            if (groupUser == null)
            {
                groupUser = new GroupUser
                                {
                                    GroupId = groupId,
                                    UserId = userId
                                };

                return Create(groupUser) > 0;
            }

            return false;
        }

        public bool RemoveUser(int groupId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, groupId));
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));

            GroupUser groupUser = GetByQuery(query);
            if (groupUser != null)
            {
                return Delete(groupUser.Id);
            }

            return false;
        }
        #endregion
    }
}