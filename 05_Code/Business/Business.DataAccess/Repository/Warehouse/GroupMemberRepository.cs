using Business.Common.QueryModel;
using Business.DataAccess.Contract.Repository.Warehouse;
using Business.Domain.Warehouse;

namespace Business.DataAccess.Repository.Warehouse
{
    public class GroupMemberRepository : Repository<GroupMember>, IGroupMemberRepository
    {
        public GroupMemberRepository()
        {
            Database = DatabaseConfigName.Warehouse;
        }

        public bool AddMember(int operatorGroupId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, operatorGroupId));

            GroupMember groupMember = GetByQuery(query);
            if (groupMember == null)
            {
                groupMember = new GroupMember
                {
                    GroupId = operatorGroupId,
                    UserId = userId
                };

                return Create(groupMember) > 0;
            }

            return false;
        }

        public bool RemoveMember(int operatorGroupId, int userId)
        {
            var query = new Query();
            query.Criteria.Add(new Criterion("UserId", CriteriaOperator.Equal, userId));
            query.Criteria.Add(new Criterion("GroupId", CriteriaOperator.Equal, operatorGroupId));

            GroupMember groupMember = GetByQuery(query);
            if (groupMember != null)
            {
                return Delete(groupMember.Id);
            }

            return false;
        }
    }
}