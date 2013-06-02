using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IRoleGroupRepository : IRepository<RoleGroup>
    {
        bool AddGroup(int roleId, int groupId);

        bool RemoveGroup(int roleId, int groupId);
    }
}