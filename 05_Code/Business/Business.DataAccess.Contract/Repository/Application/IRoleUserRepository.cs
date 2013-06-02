using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IRoleUserRepository : IRepository<RoleUser>
    {
        bool AddUser(int roleId, int userId);

        bool RemoveUser(int roleId, int userId);
    }
}