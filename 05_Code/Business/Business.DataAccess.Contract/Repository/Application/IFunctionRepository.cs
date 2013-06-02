using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IFunctionRepository : IRepository<Function>
    {
        Function GetByCode(string applicationCode, string functionCode);
    }
}