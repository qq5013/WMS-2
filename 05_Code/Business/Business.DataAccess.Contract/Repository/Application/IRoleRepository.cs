using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IRoleRepository : IRepository<Role>
    {
        Role GetByCode(string applicationCode, string roleCode);

        IList<Function> GetFunctions(int roleId);

        IList<Group> GetGroups(int roleId);

        IList<User> GetUsers(int roleId);
    }
}