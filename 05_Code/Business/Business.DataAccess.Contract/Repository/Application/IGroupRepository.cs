using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IGroupRepository : IRepository<Group>
    {
        Group GetByCode(string applicationCode, string groupCode);

        IList<User> GetUsers(int groupId);
    }
}