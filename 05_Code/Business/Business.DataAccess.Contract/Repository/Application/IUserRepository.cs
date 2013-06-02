using System.Collections;
using System.Collections.Generic;
using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByCode(string applicationCode, string userCode);

        bool ChangePassword(User user, string newPassword);

        IList<UserFunctionView> GetFunctions(string applicationCode, string userCode);
    }
}