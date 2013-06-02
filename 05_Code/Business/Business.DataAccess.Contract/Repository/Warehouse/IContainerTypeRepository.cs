using Business.Domain.Warehouse;

namespace Business.DataAccess.Contract.Repository.Warehouse
{
    public interface IContainerTypeRepository : IRepository<ContainerType>
    {
        ContainerType GetByCode(string warehouseCode, string typeCode);

        ContainerType GetByCode(int warehouseId, string typeCode);
    }
}