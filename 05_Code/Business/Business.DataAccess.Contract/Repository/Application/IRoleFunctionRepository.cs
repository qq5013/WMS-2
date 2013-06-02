using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IRoleFunctionRepository : IRepository<RoleFunction>
    {
        bool AddFunction(int roleId, int functionId);

        bool RemoveFunction(int roleId, int functionId);
    }
}