using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IGroupUserRepository : IRepository<GroupUser>
    {
        bool AddUser(int groupId, int userId);

        bool RemoveUser(int groupId, int userId);
    }
}