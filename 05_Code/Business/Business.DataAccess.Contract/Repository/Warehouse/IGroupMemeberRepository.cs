using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IGroupMemberRepository : IRepository<GroupMember>
    {
        bool AddMember(int operatorGroupId, int userId);

        bool RemoveMember(int operatorGroupId, int userId);
    }
}