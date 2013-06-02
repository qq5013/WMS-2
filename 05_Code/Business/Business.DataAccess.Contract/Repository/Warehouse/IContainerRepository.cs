using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IContainerRepository : IRepository<Container>
    {
        Container GetByCode(int warehoueId, string containerCode);

        Container GetByCode(string warehouseCode, string containerCode);
    }
}