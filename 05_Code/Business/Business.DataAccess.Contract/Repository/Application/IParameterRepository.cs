using Business.Domain.Application;

namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IParameterRepository : IRepository<Parameter>
    {
        Parameter GetByCode(string applicationCode, string parameterCode);
    }
}