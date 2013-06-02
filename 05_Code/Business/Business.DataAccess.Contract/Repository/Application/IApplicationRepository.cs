namespace Business.DataAccess.Contract.Repository.Application
{
    public interface IApplicationRepository : IRepository<Domain.Application.Application>
    {
        Domain.Application.Application GetByCode(string applicationCode);
    }
}